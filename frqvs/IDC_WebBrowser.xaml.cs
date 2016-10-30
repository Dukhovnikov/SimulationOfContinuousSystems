using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Awesomium.Core;
using Awesomium.Windows.Controls;
namespace frqvs
{
    /// <summary>
    /// Логика взаимодействия для IDC_WebBrowser.xaml
    /// </summary>
    public partial class IDC_WebBrowser : Window
    {
        public IDC_WebBrowser()
        {
            InitializeComponent();
        }
        public Uri Source
        {
            get { return (Uri)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }
        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register("Source",
            typeof(Uri), typeof(IDC_WebBrowser),
            new FrameworkPropertyMetadata(null));

        public IntPtr NativeView
        {
            get { return (IntPtr)GetValue(NativeViewProperty); }
            private set { this.SetValue(IDC_WebBrowser.NativeViewPropertyKey, value); }
        }

        private static readonly DependencyPropertyKey NativeViewPropertyKey =
            DependencyProperty.RegisterReadOnly("NativeView",
            typeof(IntPtr), typeof(IDC_WebBrowser),
            new FrameworkPropertyMetadata(IntPtr.Zero));

        public static readonly DependencyProperty NativeViewProperty =
            NativeViewPropertyKey.DependencyProperty;

        public bool IsRegularWindow
        {
            get { return (bool)GetValue(IsRegularWindowProperty); }
            private set { this.SetValue(IDC_WebBrowser.IsRegularWindowPropertyKey, value); }
        }

        private static readonly DependencyPropertyKey IsRegularWindowPropertyKey =
            DependencyProperty.RegisterReadOnly("IsRegularWindow",
            typeof(bool), typeof(IDC_WebBrowser),
            new FrameworkPropertyMetadata(true));

        public static readonly DependencyProperty IsRegularWindowProperty =
            IsRegularWindowPropertyKey.DependencyProperty;

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            webControl.Dispose();
        }
    }
}
