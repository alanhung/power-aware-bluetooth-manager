using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace PowerAwareBluetooth.Common
{
    [Serializable]
    /// <summary>
    /// a binding list that synchronizes the changes to its internal objects
    /// so that change will be made only on the thread that is the owner of the
    /// invoke member.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AsyncBindingList<T> : BindingList<T>
    {
        [NonSerialized]
        private Control m_ParentControl;
        delegate void ListChangedDelegate(ListChangedEventArgs e);

        public Control ParentControl
        {
            get { return m_ParentControl; }
            set { m_ParentControl = value; }
        }

        protected override void OnListChanged(ListChangedEventArgs e)
        {
            if (ParentControl != null && ParentControl.InvokeRequired)
            {
                IAsyncResult iAsyncResult = ParentControl.BeginInvoke(new ListChangedDelegate(base.OnListChanged), new object[] { e });
            }
            else
            {
                base.OnListChanged(e);
            }
        }
    }
}