using Signal_Windows.Models;
using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Signal_Windows.Controls
{
    public sealed partial class ThreadListItem : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ThreadListItem()
        {
            this.InitializeComponent();
            this.DataContextChanged += ThreadListItem_DataContextChanged;
        }

        public SignalThread Model
        {
            get
            {
                return DataContext as SignalThread;
            }
            set
            {
                DataContext = value;
            }
        }

        private uint _UnreadCount;

        public uint UnreadCount
        {
            get
            {
                return _UnreadCount;
            }
            set
            {
                _UnreadCount = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("UnreadString"));
            }
        }

        public string UnreadString
        {
            get
            {
                if (UnreadCount != 0)
                {
                    return UnreadCount.ToString();
                }
                else
                {
                    return "";
                }
            }
        }

        private void ThreadListItem_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            if (Model != null)
            {
                Model.View = this;
                ConversationDisplayName.Text = Model.ThreadDisplayName;
                UnreadCount = Model.Unread;
            }
        }

        public void Update(SignalThread thread)
        {
            Model.ThreadDisplayName = thread.ThreadDisplayName;
            Model.LastActiveTimestamp = thread.LastActiveTimestamp;
            ConversationDisplayName.Text = thread.ThreadDisplayName;
            UnreadCount = thread.Unread;
        }
    }
}