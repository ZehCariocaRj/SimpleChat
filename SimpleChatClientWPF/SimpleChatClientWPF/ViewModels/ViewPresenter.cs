using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using IO.Swagger.Api;
using IO.Swagger.Client;

namespace SimpleChatClientWPF.ViewModels
{
    class ViewPresenter : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        Stack<FrameworkElement> elements;

        private ViewPresenter()
        {
            elements = new Stack<FrameworkElement>();
        }

        private static ViewPresenter _viewPresenter;
        public static ViewPresenter GetInstance()
        {
            if(_viewPresenter == null)
            {
                _viewPresenter = new ViewPresenter();
            }

            return _viewPresenter;
        }

        public static void PushView(FrameworkElement element)
        {
            var vm = GetInstance();
            vm.CurrentContentControl = element;
        }

        public static FrameworkElement PopView()
        {
            var vm = GetInstance();
            FrameworkElement top = null;

            // Return the view that is being removed from the screen
            if (vm.elements.Count > 0)
            {
                top = vm.elements.Pop();
            }

            // Display the previous view, if one exists,
            // by popping from the stack to the current
            // control variable and then triggering the
            // property change again.
            if (vm.elements.Count > 0)
            {
                vm.CurrentContentControl = vm.elements.Pop();
            }

            return top;
        }

        private FrameworkElement _currentContentControl;
        public FrameworkElement CurrentContentControl
        {
            get { return _currentContentControl; }
            set
            {
                _currentContentControl = value;
                elements.Push(_currentContentControl);
                PropertyChanged(this, new PropertyChangedEventArgs("CurrentContentControl"));
            }
        }
    }
}
