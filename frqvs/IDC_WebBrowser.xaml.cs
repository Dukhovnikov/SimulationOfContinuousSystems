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
        // Identifies the <see cref="Source"/> dependency property.
        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register("Source",
            typeof(Uri), typeof(IDC_WebBrowser),
            new FrameworkPropertyMetadata(null));


        // This will be set to the created child view that the WebControl will wrap,
        // when ShowCreatedWebView is the result of 'window.open'. The WebControl, 
        // is bound to this property.
        public IntPtr NativeView
        {
            get { return (IntPtr)GetValue(NativeViewProperty); }
            private set { this.SetValue(IDC_WebBrowser.NativeViewPropertyKey, value); }
        }

        private static readonly DependencyPropertyKey NativeViewPropertyKey =
            DependencyProperty.RegisterReadOnly("NativeView",
            typeof(IntPtr), typeof(IDC_WebBrowser),
            new FrameworkPropertyMetadata(IntPtr.Zero));

        // Identifies the <see cref="NativeView"/> dependency property.
        public static readonly DependencyProperty NativeViewProperty =
            NativeViewPropertyKey.DependencyProperty;

        // The visibility of the address bar and status bar, depends
        // on the value of this property. We set this to false when
        // the window wraps a WebControl that is the result of JavaScript
        // 'window.open'.
        public bool IsRegularWindow
        {
            get { return (bool)GetValue(IsRegularWindowProperty); }
            private set { this.SetValue(IDC_WebBrowser.IsRegularWindowPropertyKey, value); }
        }

        private static readonly DependencyPropertyKey IsRegularWindowPropertyKey =
            DependencyProperty.RegisterReadOnly("IsRegularWindow",
            typeof(bool), typeof(IDC_WebBrowser),
            new FrameworkPropertyMetadata(true));

        // Identifies the <see cref="IsRegularWindow"/> dependency property.
        public static readonly DependencyProperty IsRegularWindowProperty =
            IsRegularWindowPropertyKey.DependencyProperty;

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            // Destroy the WebControl and its underlying view.
            webControl.Dispose();
        }
    }
}
