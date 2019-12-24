using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace ExcelEPPlus
{
    public abstract class ImportExcelBase<T>
        where T : new()
    {
        protected List<string> DefaultHeaders;
        protected List<string> ExcelHeaders;
        protected string[] DefaultWorkSheets;
        protected T PropertyIndex;
        protected int RowHeaderBeginIndex;
        protected int RowHeaderEndIndex;
        protected int RowDataBeginIndex;
        protected Dictionary<string, Dictionary<string, Guid>> ReferenceData;
        protected Guid TenantId;
        protected ExcelPackage ErrorFile;
        protected Dictionary<string, ImportedResult> ImportedResults;
        protected int TotalRow;
        protected int TotalRowImported;
        protected int TotalRowError;
        private readonly string _joinSeparator;

        protected ImportExcelBase()
        {
            ImportedResults = new Dictionary<string, ImportedResult>();
            _joinSeparator = ";" + Environment.NewLine;
        }

        protected string GetImportedResult()
        {
            var message = new StringBuilder();
            message.Append("Upload Data Success!");

            foreach (var importedResult in ImportedResults)
            {
                message.Append("<br>");
                message.Append("<br>");
                message.Append(importedResult.Key);
                message.Append("<br>");
                message.Append(" - Total Row Read: ");
                message.Append(importedResult.Value.TotalRow);
                message.Append("<br>");
                message.Append(" - Total Row Imported: ");
                message.Append(importedResult.Value.TotalRowImported);
                message.Append("<br>");
                message.Append(" - Total Row Error: ");
                message.Append(importedResult.Value.TotalRowError);
            }

            return message.ToString();
        }

        protected void GetHeaders(ExcelWorksheet worksheet, int totalColumn)
        {
            ExcelHeaders = new List<string>();
            if (worksheet != null)
            {
                for (int i = 1; i <= totalColumn; i++)
                {
                    var cells = worksheet.Cells[RowHeaderBeginIndex, i, RowHeaderEndIndex, i];
                    GetHeader(cells, worksheet);
                }
            }

            //var a = string.Join("<br>", ExcelHeaders);
        }

        protected void GetHeader(ExcelRange cells, ExcelWorksheet worksheet)
        {
            var headers = new List<string>();
            var mergedAdress = new List<string>();
            foreach (var cell in cells)
            {
                if (cell.Merge)
                {
                    var idx = cell.Worksheet.GetMergeCellId(cell.Start.Row, cell.Start.Column);
                    string address = cell.Worksheet.MergedCells[idx - 1];//the array is 0-indexed but the mergeId is 1-indexed...

                    if (!mergedAdress.Contains(address))
                    {
                        mergedAdress.Add(address);
                        GetHeader(worksheet, headers, address);
                    }
                }
                else
                {
                    GetHeader(headers, cell.Text);
                }
            }

            if (headers.Any())
            {
                var header = string.Join(">", headers);
                ExcelHeaders.Add(header);
            }
        }

        protected void GetHeader(ExcelWorksheet worksheet, List<string> headers, string address)
        {
            var mergedCells = worksheet.Cells[address];

            foreach (var mergedCell in mergedCells)
            {
                GetHeader(headers, mergedCell.Text);
                break;
            }
        }

        protected void GetHeader(List<string> headers, string header)
        {
            header = header.Replace(" ", "").Replace("<br>", "").ToUpper();
            if (!string.IsNullOrEmpty(header))
            {
                headers.Add(header);
            }
        }

        protected void GetColumnIndex()
        {
            PropertyIndex = new T();
            var propeties = PropertyIndex.GetType().GetProperties();
            foreach (var propertyInfo in propeties)
            {
                var attr = propertyInfo.GetCustomAttributes(typeof(ColumnCustom), false).FirstOrDefault() as ColumnCustom;
                if (attr != null)
                {
                    int index = ExcelHeaders.IndexOf(attr.ColumnName);
                    propertyInfo.SetValue(PropertyIndex, index, null);
                }
            }
        }

        protected ExcelPackage ReadExcelFile(string path)
        {
            var package = new ExcelPackage();
            using (var stream = File.OpenRead(path))
            {
                package.Load(stream);
            }
            return package;
        }

        protected Guid? SaveErrorFile(string uploadedFilePath, string errofileName)
        {
            try
            {
                string uploadDirectory = "UploadPath";
                string rootDirectory = "";// MapPath(uploadDirectory);

                var uploadedFilePathFull = Path.Combine(rootDirectory, uploadedFilePath);

                var fileInfo = new FileInfo(uploadedFilePathFull);
                var errorFileId = Guid.NewGuid();

                if (fileInfo.Directory != null)
                {
                    var absolutePath = Path.Combine(fileInfo.Directory.FullName, errorFileId.ToString());
                    var errorFile = new FileInfo(absolutePath);

                    var lastSeperateIndex = uploadedFilePath.LastIndexOf('\\');

                    var relativePath = uploadedFilePath.Substring(0, lastSeperateIndex + 1) + errorFileId;

                    var byteArray = ErrorFile.GetAsByteArray();

                    File.WriteAllBytes(errorFile.FullName, byteArray);

                    var fileName = string.Format("{0}Error_{1:yyyyMMMddHHmmss}", errofileName, DateTime.Now);

                    var attachment = new
                    {
                        Id = errorFileId,
                        FileDisplayName = fileName,
                        FileExtension = ".xlsx",
                        FileName = fileName,
                        FilePath = relativePath,
                        FileSize = byteArray.Length,
                        ReferenceId = errorFileId,
                        ReferenceType = string.Format("{0}Error", errofileName)
                    };

                    //db.Add(Context, attachment);
                    //db.Commit();
                    return attachment.Id;
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                ErrorFile.Dispose();
            }
            return null;
        }

        protected void GetDefaultHeaders(Type type)
        {
            DefaultHeaders = type
                 .GetProperties()
                 .Where(x => x.GetCustomAttributes(typeof(ColumnCustom), false).Any())
                 .Select(p =>
                 {
                     ColumnCustom rawKey = p.GetCustomAttributes(typeof(ColumnCustom), false).First() as ColumnCustom;
                     var key = rawKey == null ? "" : rawKey.ColumnName;
                     return key;
                 }).ToList();
        }

        protected bool IsHeaderVaild(ExcelWorksheet worksheet, ExcelWorksheet errorWorksheet, int totalColumn)
        {
            GetHeaders(worksheet, totalColumn);
            var missingHeaders = DefaultHeaders.Except(ExcelHeaders).ToList();
            var totalMissing = missingHeaders.Count;

            if (totalMissing > 0)
            {
                errorWorksheet.Cells[RowDataBeginIndex, 1].Value = "In Valid Header";

                for (int i = 0; i < totalMissing; i++)
                {
                    errorWorksheet.Cells[RowDataBeginIndex + i + 1, 1].Value = missingHeaders[i];
                }

                return false;
            }
            return true;
        }

        protected ExcelWorksheet BuildErrorFile(ExcelPackage excelPackage, string sheetName, int totalColumn)
        {
            ErrorFile.Workbook.Worksheets.Add(sheetName);

            var errorworkSheet = ErrorFile.Workbook.Worksheets[sheetName];

            var workSheet = excelPackage.Workbook.Worksheets[sheetName];

            workSheet.Cells[1, 1, RowDataBeginIndex - 1, totalColumn].Copy(errorworkSheet.Cells[1, 1, RowDataBeginIndex - 1, totalColumn]);

            errorworkSheet.Cells[RowDataBeginIndex, 1].Value = string.Empty;

            return errorworkSheet;
        }

        protected object[] GetRowValues(ExcelWorksheet sheet, int rowIndex, int totalColumn)
        {
            object[] rowValue = new object[totalColumn];
            for (int i = 0; i < totalColumn; i++)
            {
                rowValue[i] = sheet.Cells[rowIndex, i + 1].Value;
            }

            return rowValue;
        }

        protected string GetErrorMessageIncorrectValue(string headerName)
        {
            return string.Format("[{0}] has an incorrect value. Please input the correct value", headerName);
        }

        private string GetErrorMessageRequied(string headerName)
        {
            return string.Format("[{0}]  is Mandatory", headerName);
        }

        protected decimal? GetNullableDecimal(object[] rowValues, int index)
        {
            string value = GetString(rowValues, index);
            decimal number;
            decimal.TryParse(value, out number);
            return number;
        }

        protected decimal GetDecimal(object[] rowValues, int index, string headerName, List<string> messages)
        {
            string value = GetString(rowValues, index);
            decimal number;
            if (decimal.TryParse(value, out number))
            {
                return number;
            }

            messages.Add(GetErrorMessageIncorrectValue(headerName));
            return 0;
        }

        protected int GetInt(object[] rowValues, int index, string headerName, List<string> messages)
        {
            string value = GetString(rowValues, index);
            int number;
            if (int.TryParse(value, out number))
            {
                return number;
            }

            messages.Add(GetErrorMessageIncorrectValue(headerName));
            return 0;
        }

        protected string GetString(object[] rowValues, int index)
        {
            var data = rowValues[index];
            if (data != null)
            {
                return data.ToString();
            }
            return string.Empty;
        }

        protected DateTime GetDate(object[] rowValues, int index, string headerName, List<string> messages)
        {
            string value = GetString(rowValues, index);
            double number;
            DateTime dateTime;

            if (double.TryParse(value, out number))
            {
                dateTime = DateTime.FromOADate(number);
                return dateTime;
            }

            value = value.Replace("-", "/").Replace(" ", "/");

            if (DateTime.TryParseExact(value, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime)
                || DateTime.TryParseExact(value, "dd/MMM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
            {
                return dateTime;
            }

            messages.Add(GetErrorMessageIncorrectValue(headerName));
            return DateTime.Now;
        }

        protected bool GetBool(object[] rowValues, int index, string compareString = "yes")
        {
            string value = GetString(rowValues, index);
            if (!string.IsNullOrEmpty(value))
            {
                return value.ToLower() == compareString;
            }
            return false;
        }

        protected string GetRequiredString(object[] rowValues, int index, string headerName, List<string> messages)
        {
            var data = GetString(rowValues, index);
            if (string.IsNullOrEmpty(data))
            {
                messages.Add(GetErrorMessageRequied(headerName));
            }

            return data;
        }

        protected Guid GetReferenceId(object[] rowValues, int dataIndex, string referenceName, string headerName, List<string> messages)
        {
            var refId = GetNullablReferenceId(rowValues, dataIndex, referenceName, headerName, messages);
            if (!refId.HasValue)
            {
                messages.Add(GetErrorMessageIncorrectValue(headerName));
                return Guid.Empty;
            }
            return refId.Value;
        }

        protected Guid? GetNullablReferenceId(object[] rowValues, int dataIndex, string referenceName, string headerName, List<string> messages)
        {
            var dataValue = rowValues[dataIndex] as string;

            if (string.IsNullOrEmpty(dataValue))
            {
                return null;
            }

            Guid referenceId;
            if (ReferenceData[referenceName].TryGetValue(dataValue.Trim().ToLower(), out referenceId))
            {
                return referenceId;
            }

            messages.Add(GetErrorMessageIncorrectValue(headerName));
            return Guid.Empty;
        }

        protected Guid GetReferenceId(string referenceName, string key)
        {
            Guid referenceId;
            if (ReferenceData[referenceName].TryGetValue(key.Trim().ToLower(), out referenceId))
            {
                return referenceId;
            }
            return Guid.Empty;
        }

        protected void WriteError(ExcelWorksheet worksheet,
            ExcelWorksheet errorWorksheet, int rowIndex, int totalColumn, List<string> messages)
        {
            worksheet.Cells[rowIndex, 1, rowIndex, totalColumn].Copy(errorWorksheet.Cells[RowDataBeginIndex + TotalRowError, 1, RowDataBeginIndex + TotalRowError, totalColumn]);
            errorWorksheet.Cells[RowDataBeginIndex + TotalRowError, totalColumn + 1].Value = string.Join(_joinSeparator, messages);
            errorWorksheet.Cells[RowDataBeginIndex + TotalRowError, totalColumn + 1].Style.WrapText = true;
            TotalRowError += 1;
        }

        protected abstract void GetReferenceData();
    }

    public class ImportedResult
    {
        public int TotalRow { get; set; }
        public int TotalRowImported { get; set; }
        public int TotalRowError { get; set; }
    }
}
