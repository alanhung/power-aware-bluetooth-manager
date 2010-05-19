//TODO: adam + tal verify with tal that the place for WinMessageAdapter is the model tier

namespace PowerAwareBluetooth.Model
{
    /// <summary>
    /// an adapter for sending and listening to a special event
    /// </summary>
    public static class WinMessageAdapter
    {
        /// <summary>
        /// the windows-name of the event 
        /// </summary>
        private const string EVENT_NAME = "PowerAwareBT_EVENT";

        /// <summary>
        /// the named-events object that will be used to notigy and listen to events
        /// </summary>
        private static NamedEvents.NamedEvents m_EventObject;

        // TODO: adam + tal: think what is best - re-read from file or listen to object from pipe
        // NOW we save a file and then the manager will take the saved file

        /// <summary>
        /// notifies the event listeners that a change was made
        /// to the rules-list
        /// </summary>
        public static void NotifyListChanged()
        {
            NamedEvents.NamedEvents namedEvents = new NamedEvents.NamedEvents();
            namedEvents.OpenEvent(EVENT_NAME);
            if (namedEvents.IsOpened)
            {
                namedEvents.PulseEvent();
            }
        }

        /// <summary>
        /// waits for the UI to notify that a change was made to the user-defined
        /// rules-list
        /// </summary>
        public static void WaitForMessage()
        {
            m_EventObject.WaitForEvent();
        }

        /// <summary>
        /// initializes the adapter
        /// </summary>
        public static void Init()
        {
            m_EventObject = new NamedEvents.NamedEvents();
            m_EventObject.InitNamedEvent(EVENT_NAME);
        }
    }
}
