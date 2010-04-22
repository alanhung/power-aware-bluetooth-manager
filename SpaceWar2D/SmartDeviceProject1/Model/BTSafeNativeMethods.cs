using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace PowerAwareBluetooth.Model
{
    public class BTSafeNativeMethods
    {
        private const string IRPROPS_DLL = "irprops.cpl";
        private const string KERNEL_DLL = "kernel32.dll";
        private const string WINSOCK_DLL = "Ws2.dll";

        #region Constants

        //TODO: TAL see that this is correct
        public const Int32 NS_BTH = 16;

        #endregion Constants

        #region Structs

        [StructLayout(LayoutKind.Sequential)]
        public struct BluetoothFindRadioParams
        {
            internal UInt32 dwSize;
            internal void Initialize()
            {
                this.dwSize = (UInt32)Marshal.SizeOf(typeof(BluetoothFindRadioParams));
            }
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct WSAQUERYSET
        {
            public Int32 dwSize;
            public String szServiceInstanceName;
            public IntPtr lpServiceClassId;
            public IntPtr lpVersion;
            public String lpszComment;
            public Int32 dwNameSpace;
            public IntPtr lpNSProviderId;
            public String lpszContext;
            public Int32 dwNumberOfProtocols;
            public IntPtr lpafpProtocols;
            public String lpszQueryString;
            public Int32 dwNumberOfCsAddrs;
            public IntPtr lpcsaBuffer;
            public Int32 dwOutputFlags;
            public IntPtr Blob;
        }

        #endregion Structs

        #region Methods

        /// <summary>
        /// get a handle to the bluetooth device
        /// </summary>
        /// <param name="pbtfrp">parameters</param>
        /// <param name="phRadio">will hold the bluetooth device ptr</param>
        /// <returns>a handle to the next bluetooth enumeration (should be closed with BluetoothFindRadioClosed)</returns>
        [DllImport(IRPROPS_DLL, SetLastError = true)]
        static extern IntPtr BluetoothFindFirstRadio(ref BluetoothFindRadioParams pbtfrp, out IntPtr phRadio);

        /// <summary>
        /// close bluetooth device pointer
        /// </summary>
        /// <param name="hObject"></param>
        /// <returns></returns>
        [DllImport(KERNEL_DLL, EntryPoint = "CloseHandle", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool CloseBluetoothDevice(IntPtr hObject);

        /// <summary>
        /// close a handle for find bluetooth radio
        /// </summary>
        /// <param name="hFind">the findRadio handler to close</param>
        /// <returns>true if closed succeeded, false otherwise</returns>
        [DllImport(IRPROPS_DLL, SetLastError = true)]
        private static extern bool BluetoothFindRadioClose(ref IntPtr hFind);

        #region WinSock

        [DllImport(WINSOCK_DLL)]
        public static extern int WSAStartup(ushort version, byte[] wsaData);

        [DllImport(WINSOCK_DLL)]
        public static extern int WSACleanup();

        //TODO: TAL see that WINSOCK_DLL is the right one
        [DllImport(WINSOCK_DLL, CharSet = CharSet.Auto, SetLastError = true)] 
        static extern Int32 WSALookupServiceBegin(WSAQUERYSET lpqsRestrictions, Int32 dwControlFlags, ref Int32 lphLookup);
        #endregion WinSock

        //[DllImport(WINSOCK_DLL, CharSet = CharSet.Auto, SetLastError = true)]
        //static extern Int32 WSALookupServiceBegin(WSAQUERYSET lpqsRestrictions, Int32 dwControlFlags, ref Int32 lphLookup);
        
        #endregion Methods
    }
}
