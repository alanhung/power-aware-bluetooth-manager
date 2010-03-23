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

        #region Structs

        [StructLayout(LayoutKind.Sequential)]
        private struct BluetoothFindRadioParams
        {
            internal UInt32 dwSize;
            internal void Initialize()
            {
                this.dwSize = (UInt32)Marshal.SizeOf(typeof(BluetoothFindRadioParams));
            }
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



        #endregion Methods
    }
}
