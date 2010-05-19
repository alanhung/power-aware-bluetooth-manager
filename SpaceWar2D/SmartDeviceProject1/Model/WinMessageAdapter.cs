//TODO: adam + tal verify with tal that the place for WinMessageAdapter is the model tier

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Messaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using PowerAwareBluetooth.Model.Process;

namespace PowerAwareBluetooth.Model
{
    public static class WinMessageAdapter
    {
//        #region /// P/Invoke Import ///
//
//        [DllImport("coredll", CharSet = CharSet.Auto, SetLastError = true)]
//        [return: MarshalAs(UnmanagedType.Bool)]
//        private static extern bool PostMessage(IntPtr hwnd, uint Msg, IntPtr wParam, IntPtr lParam);
//
//        [StructLayout(LayoutKind.Sequential)]
//        public struct POINT
//        {
//	        public int X;
//	        public int Y;
//
//	        public POINT(int x, int y)
//	        {
//		        this.X = x;
//		        this.Y = y;
//	        }
//
//	        public static implicit operator System.Drawing.Point(POINT p)
//	        {
//		        return new System.Drawing.Point(p.X, p.Y);
//	        }
//		    
//            public static implicit operator POINT(System.Drawing.Point p)
//	        {
//		        return new POINT(p.X, p.Y);
//	        }
//        }
//
//        [StructLayout(LayoutKind.Sequential)]
//	    public struct MSG
//	    {
//	        public IntPtr hwnd;
//	        public UInt32 message;
//	        public IntPtr wParam;
//	        public IntPtr lParam;
//	        public UInt32 time;
//	        public POINT pt;
//        }
//
//        [DllImport("coredll", CharSet = CharSet.Auto, SetLastError = true)]
//        [return: MarshalAs(UnmanagedType.Bool)]
//        static extern bool GetMessage(out MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax);
//
//        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
//        static extern uint RegisterWindowMessage(string lpString);
//
//        #endregion
//
//        private static string PowerAwareBlueToothAssemblyName;
//
//        static WinMessageAdapter()
//        {
//            PowerAwareBlueToothAssemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
//            PowerAwareBlueToothAssemblyName += @".exe";
//        }

//        private const uint RF_TESTMESSAGE = 0xA123;
//
//        private static string QUEUE_NAME = @".\PABT_MessQue";
//        private static string MESSAGE_LABEL_NEW_LIST = "NewList";
//        private static MessageQueue staticMessageQueue;

        public const string EVENT_NAME = "PowerAwareBT_EVENT";

        private static NamedEvents.NamedEvents m_EventObject;

//        public static void RegisterWindowMessage()
//        {
//            RegisterWindowMessage("Test");
//        }

//        public static void PostMessageAPI(string toProcess)
//        {
//            //get all other (possible) running instances
//            System.Diagnostics.Process targetProcess = ProcessAPI.GetProcessByName(toProcess);
//
//            if (targetProcess != null)
//            {
//                bool res = PostMessage(targetProcess.MainWindowHandle, RF_TESTMESSAGE, IntPtr.Zero, IntPtr.Zero);
//                int x;
//                x = 10;
//            }
//        }

        // TODO: adam + tal: think what is best - re-read from file or listen to object from pipe
        // NOW we save a file and then the manager will take the saved file
        public static void NotifyListChanged(RuleList newList)
        {
            NamedEvents.NamedEvents namedEvents = new NamedEvents.NamedEvents();
            namedEvents.OpenEvent(EVENT_NAME);
            if (namedEvents.IsOpened)
            {
                namedEvents.PulseEvent();
            }
//            PostMessageAPI(PowerAwareBlueToothAssemblyName);
         //   System.ServiceModel.
//            if (MessageQueue.Exists(QUEUE_NAME))
//            {
//                MessageQueue messageQueue = new MessageQueue(QUEUE_NAME);
//                messageQueue.Send(newList, MESSAGE_LABEL_NEW_LIST);
//            }
        }


//        /// <summary>
//        /// creates the message queue if it does not exist
//        /// </summary>
//        public static void InitQueue()
//        {
//            if (!MessageQueue.Exists(QUEUE_NAME))
//            {
//                staticMessageQueue = MessageQueue.Create(QUEUE_NAME);
//            }
//        }

        /// <summary>
        /// gets a rules-list from the queue, this message will block
        /// until a new message arrives to the queue
        /// </summary>
        /// <returns>a rules list from the UI</returns>
//        public static RuleList GetListFromQueue()
//        {
//            Message message = staticMessageQueue.Receive();
//            RuleList ruleList = message.Body as RuleList;
//            return ruleList;
//        }

        public static void WaitForMessage()
        {
            m_EventObject.WaitForEvent();
//            MSG msg;
//            GetMessage(out msg, IntPtr.Zero, 0, 0);
//            int x;
//            x = 10;
        }

        public static void Init()
        {
            m_EventObject = new NamedEvents.NamedEvents();
            m_EventObject.InitNamedEvent(EVENT_NAME);
        }
    }
}
