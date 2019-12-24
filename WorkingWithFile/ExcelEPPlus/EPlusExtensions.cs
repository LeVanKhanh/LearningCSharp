using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ExcelEPPlus
{
    public static class EPlusExtensions
    {
        public static ExcelRangeBase[] GetHeaderColumns(this ExcelWorksheet sheet, int startRow = 0)
        {
            var columnNames = new List<ExcelRangeBase>();

            if (startRow == 0)
            {
                startRow = sheet.Dimension.Start.Row;
            }

            foreach (var firstRowCell in sheet.Cells[startRow, sheet.Dimension.Start.Column, 1, sheet.Dimension.End.Column])
            {
                columnNames.Add(firstRowCell);
            }

            return columnNames.ToArray();
        }

        public static List<int> GetWorksheetRowIdx(ExcelWorksheet worksheet, int startRow)
        {
            var rowValues = worksheet.Cells
                .Select(cell => cell.Start.Row)
                .Distinct()
                .OrderBy(x => x);

            var collection = rowValues.Skip(startRow).Select(row => row).ToList();
            return collection;
        }

        public static string GetMergedRangeAddress(this ExcelRangeBase @this)
        {
            if (@this.Merge)
            {
                var idx = @this.Worksheet.GetMergeCellId(@this.Start.Row, @this.Start.Column);
                var mergedCells = @this.Worksheet.MergedCells[idx - 1];

                return mergedCells;
            }
            else
            {
                return @this.Address;
            }
        }

        public static string GetBellowAddress(this ExcelRangeBase @this)
        {
            return AddressReaderHelper.GetAddressCol(@this.Address) + (AddressReaderHelper.GetAddressRow(@this.Address) + 1);
        }

        public static class AddressReaderHelper
        {
            public static int GetAddressRow(string @this)
            {
                const string pattern = @"[A-Z]+";
                var address = Regex.Split(@this, pattern);
                return int.Parse(address[address.Length - 1]); // idx = 0 always = ""
            }

            public static string GetAddressCol(string @this)
            {
                const string pattern = @"\d+";
                var address = @this.Substring(0, Regex.Match(@this, pattern).Index);
                return address;
            }

            public static int RowToNumber(string colAddress)
            {
                var rowIdx = 0;
                var idx = colAddress.Length - 1;
                foreach (var item in colAddress)
                {
                    var c = item - 'A' + 1;
                    rowIdx += c * (int)Math.Pow(26, idx);
                    idx -= 1;
                }
                return rowIdx;
            }
        }
    }


    [AttributeUsage(AttributeTargets.All)]
    public class ColumnCustom : Attribute
    {
        public string ColumnName { get; set; }

        public ColumnCustom(string columnName)
        {
            ColumnName = columnName;
        }
    }
}
