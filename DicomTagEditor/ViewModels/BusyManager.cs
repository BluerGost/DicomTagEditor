using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DicomTagEditor.ViewModels
{
    static class BusyManager
    {
        public enum ESTATUS
        {
            BUSY,
            IDLE,
        }

        private static object lockObj = new object();
        public static int cnt = 0;
        public class StatusChangedEventArgs : EventArgs
        {
            public ESTATUS Status { get; set; }
        }
        public delegate void StatusChangedEventHandler(object sender, StatusChangedEventArgs e);
        public static event StatusChangedEventHandler StatusChanged;
        public static void Add([System.Runtime.CompilerServices.CallerMemberName] string aCallerMemberName = "",
            [System.Runtime.CompilerServices.CallerFilePath] string aCallerFilePath = "",
            [System.Runtime.CompilerServices.CallerLineNumber] int aCallerLineNumber = 0)
        {
            lock (lockObj)
            {
                cnt++;
                if (cnt == 1) StatusChanged?.Invoke(null, new StatusChangedEventArgs() { Status = ESTATUS.BUSY });
            }

            var cmn = aCallerMemberName;
            var cfp = aCallerFilePath;
            var cln = aCallerLineNumber;

            Utility.Log.I($"+ {cmn}\t{cfp}({cln})");
        }

        public static void Delete([System.Runtime.CompilerServices.CallerMemberName] string aCallerMemberName = "",
            [System.Runtime.CompilerServices.CallerFilePath] string aCallerFilePath = "",
            [System.Runtime.CompilerServices.CallerLineNumber] int aCallerLineNumber = 0)
        {
            lock (lockObj)
            {
                cnt--;
                if (cnt == 0) StatusChanged?.Invoke(null, new StatusChangedEventArgs() { Status = ESTATUS.IDLE });
            }

            var cmn = aCallerMemberName;
            var cfp = aCallerFilePath;
            var cln = aCallerLineNumber;

            Utility.Log.I($"- {cmn}\t{cfp}({cln})");
        }
    }
}
