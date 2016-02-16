using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SimpleChatClientWPF.Views
{
    /// <summary>
    /// Interaction logic for ChatView.xaml
    /// </summary>
    public partial class ChatView : Window
    {

        ViewModels.ChatViewModel chatViewModel;
        public ChatView()
        {
            InitializeComponent();
            InitializeView(null);
        }

        public ChatView(int chatId)
        {
            InitializeComponent();
            InitializeView(chatId);
        }

        private void InitializeView(int? chatId)
        {
            if(chatId != null)
                chatViewModel = new ViewModels.ChatViewModel(chatId.Value);
            else
                chatViewModel = new ViewModels.ChatViewModel();

            chatViewModel.SetListBox(ParticipantList);
            chatViewModel.SetScrollViewer(ChatScroll);

            DataContext = chatViewModel;

            Loaded += ChatView_Loaded;
        }

        ~ChatView()
        {
            _timer.Dispose();
        }

        private Timer _timer;
        private void ChatView_Loaded(object sender, RoutedEventArgs e)
        {
            chatViewModel.PopulateChat(); // Execute once to populate

            _timer = new Timer();
            _timer.Interval = 250 * 1; // Update every 0.25 second
            _timer.Elapsed += (object _sender, ElapsedEventArgs _e) => chatViewModel.PopulateChat();
            _timer.Enabled = true;
            _timer.AutoReset = true;
        }
    }
}
