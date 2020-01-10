
using PICT.DataTransferObject;
using System.Collections.Generic;

namespace PICT.BLE.Api.Headcount.Helper
{
    public static class CountDataQueue
    {
        private static Queue<DtoBleSignal> _bleSignals;

        static CountDataQueue()
        {
            _bleSignals = new Queue<DtoBleSignal>();
        }

        public static void Enqueue(DtoBleSignal bleSignal)
        {
            _bleSignals.Enqueue(bleSignal);
        }

        public static DtoBleSignal Dequeue()
        {
            DtoBleSignal bleSignal;
            _bleSignals.TryDequeue(out bleSignal);
            return bleSignal;
        }
    }
}
