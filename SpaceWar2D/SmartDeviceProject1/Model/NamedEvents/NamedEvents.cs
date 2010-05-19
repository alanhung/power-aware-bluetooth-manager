using System;
using System.Runtime.InteropServices;

namespace PowerAwareBluetooth.Model.NamedEvents
{
    /// <summary>
    /// exposes the Named-Events capability of Windows Mobile
    /// </summary>
    internal class NamedEvents
    {
        #region /// DLL Imports ///

        [DllImport("coredll.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Auto)]
        public static extern IntPtr CreateEvent(
            IntPtr lpEventAttributes,
            [In, MarshalAs(UnmanagedType.Bool)] bool bManualReset,
            [In, MarshalAs(UnmanagedType.Bool)] bool bIntialState,
            [In, MarshalAs(UnmanagedType.BStr)] string lpName);

        [DllImport("coredll.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseHandle(IntPtr hObject);

        [DllImport("coredll.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr OpenEvent(int desiredAccess, bool inheritHandle, string name);

        [DllImport("coredll.dll", SetLastError=true)]
        public static extern Int32 WaitForSingleObject(IntPtr Handle,Int32 Wait);


        [DllImport("coredll.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EventModify(IntPtr hEvent, [In, MarshalAs(UnmanagedType.U4)] int dEvent);

        #endregion

        #region /// Events-Flags Modifiers ///

        public enum EventFlags
        {
            PULSE = 1,
            RESET = 2,
            SET = 3
        }

        private static bool EventModify(IntPtr hEvent, EventFlags flags)
        {
            return EventModify(hEvent, (int)flags);
        }

        #endregion

        #region /// Constants ///

        const int STANDARD_RIGHTS_REQUIRED = 0x000F0000;
        const int SYNCHRONIZE = 0x00100000;
        const int EVENT_ALL_ACCESS = (STANDARD_RIGHTS_REQUIRED | SYNCHRONIZE | 0x3); 
        const int INFINITE = -1;

        #endregion

        #region /// Private Members //

        private  IntPtr m_Handle;

        #endregion

        #region /// Public API ///

        public bool IsOpened
        {
            get
            {
                return m_Handle != IntPtr.Zero;
            }
        }

        public void InitNamedEvent(string name)
        {
            m_Handle = CreateEvent(IntPtr.Zero, true, false, name);
        }

        public void OpenEvent(string name)
        {
            m_Handle = OpenEvent(EVENT_ALL_ACCESS, false, name);
        }

        public void CloseEvent()
        {
            if (m_Handle != IntPtr.Zero)
            {
                CloseHandle(m_Handle);
            }
        }

        public void WaitForEvent()
        {
            WaitForSingleObject(m_Handle, INFINITE);
        }

        public void PulseEvent()
        {
            EventModify(m_Handle, EventFlags.PULSE);
        }

        #endregion

    }
}
