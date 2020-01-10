using PICT.DataTransferObject;
using PICT.Service.CommandsQueries.Commands.BleSignalCommands;
using PICT.Service.Services.Commands.BleSignalServices;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace PICT.BLE.Api.Headcount.Helper
{
    public class TimerSaveSignal : IHostedService, IDisposable
    {
        private Timer _timer;
        private BleSignalCreateService _service;
        private int totalItem;
        private int totalTimesChecked;
        private List<DtoBleSignal> _bleSignals;

        public TimerSaveSignal(BleSignalCreateService service)
        {
            totalItem = 0;
            _service = service;
            _bleSignals = new List<DtoBleSignal>();
        }

        private async void DoWork(object state)
        {
            totalTimesChecked++;
            var bleSignal = SignalDataQueue.Dequeue();
            if (bleSignal != null)
            {
                totalItem++;
                _bleSignals.Add(bleSignal);
            }

            if (totalItem >= 1000 || (totalItem > 0 && totalTimesChecked >= 2000))
            {
                totalItem = 0;
                totalTimesChecked = 0;
                var command = new BleSignalCreateCommand
                {
                    Model = _bleSignals.ToList()
                };

                _bleSignals = new List<DtoBleSignal>();
                _service.Execute(command);
            }
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(1));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}

