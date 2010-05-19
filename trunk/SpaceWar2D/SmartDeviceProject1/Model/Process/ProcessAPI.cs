using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace PowerAwareBluetooth.Model.Process
{
    /// <summary>
    /// bases on code from:
    /// http://msdn.microsoft.com/en-us/library/aa446560.aspx
    /// </summary>
    public class ProcessAPI
    {

        private const int TH32CS_SNAPPROCESS = 0x00000002;
        [DllImport("toolhelp.dll")]
        public static extern IntPtr CreateToolhelp32Snapshot(uint flags, uint processid);
        [DllImport("toolhelp.dll")]
        public static extern int CloseToolhelp32Snapshot(IntPtr handle);
        [DllImport("toolhelp.dll")]
        public static extern int Process32First(IntPtr handle, byte[] pe);
        [DllImport("toolhelp.dll")]
        public static extern int Process32Next(IntPtr handle, byte[] pe);
        [DllImport("coredll.dll")]
        private static extern IntPtr OpenProcess(int flags, bool fInherit, int PID);
        private const int PROCESS_TERMINATE = 1;
        [DllImport("coredll.dll")]
        private static extern bool TerminateProcess(IntPtr hProcess, uint ExitCode);
        [DllImport("coredll.dll")]
        private static extern bool CloseHandle(IntPtr handle);
        private const int INVALID_HANDLE_VALUE = -1;

        private string processName;
        private int threadCount;
        private int baseAddress;
        private ulong pid;

        //default constructor
        public ProcessAPI()
        {

        }

        //private helper constructor
        private ProcessAPI(ulong pid, string procname, int threadcount, int baseaddress)
        {
            this.pid = pid;
            processName = procname;
            threadCount = threadcount;
            baseAddress = baseaddress;
        }

        public static System.Diagnostics.Process GetProcessByName(string processName)
        {
            ProcessAPI processApi = GetProccessAPIByName(processName);
            if (processApi != null)
            {
                return System.Diagnostics.Process.GetProcessById((int)processApi.PID);
            }
            return null;
        }

        public static ProcessAPI GetProccessAPIByName(string processName)
        {
            List<ProcessAPI> processList = GetProcesses();
            foreach (ProcessAPI processApi in processList)
            {
                if (processApi.ProcessName == processName)
                {
                    return processApi;
                }
            }
            return null;
        }

        public static List<ProcessAPI> GetProcesses()
        {
            //temp ArrayList
            List<ProcessAPI> procList = new List<ProcessAPI>();

            IntPtr handle = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);

            if ((int)handle > 0)
            {
                try
                {
                    PROCESSENTRY32 peCurrent;
                    PROCESSENTRY32 pe32 = new PROCESSENTRY32();
                    //Get byte array to pass to the API calls
                    byte[] peBytes = pe32.ToByteArray();
                    //Get the first process
                    int retval = Process32First(handle, peBytes);
                    while (retval == 1)
                    {
                        //Convert bytes to the class
                        peCurrent = new PROCESSENTRY32(peBytes);

                        //New instance of the ProcessAPI class
                        ProcessAPI proc = new ProcessAPI(peCurrent.PID,
                                       peCurrent.Name, (int)peCurrent.ThreadCount,
                                       (int)peCurrent.BaseAddress);

                        procList.Add(proc);

                        retval = Process32Next(handle, peBytes);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Exception: " + ex.Message);
                }
                //Close handle
                CloseToolhelp32Snapshot(handle);

                return procList;

            }
            else
            {
                throw new Exception("Unable to create snapshot");
            }
        }

        //ToString implementation for ListBox binding
        public override string ToString()
        {
            return processName;
        }

        public int BaseAddress
        {
            get
            {
                return baseAddress;
            }
        }

        public int ThreadCount
        {
            get
            {
                return threadCount;
            }
        }

//        public IntPtr Handle
//        {
//            get
//            {
//                return handle;
//            }
//        }

        public string ProcessName
        {
            get
            {
                return processName;
            }
        }

        public int BaseAddess
        {
            get
            {
                return baseAddress;
            }
        }

        public ulong PID
        {
            get
            {
                return pid;
            }
        }

    }

}
