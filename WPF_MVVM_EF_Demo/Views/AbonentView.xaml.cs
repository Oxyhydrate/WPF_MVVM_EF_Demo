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
using System.IO;

namespace Demo.UI.Views
{

    public partial class AbonentView : Window
    {
        public double NormalTop { get; set; }
        public double NormalLeft { get; set; }
        public double NormalWidth { get; set; }
        public double NormalHeight { get; set; }

        private void MaximizeWindow(object sender, RoutedEventArgs e)
        {
            if ((this.Width == SystemParameters.WorkArea.Width) && (this.Height == SystemParameters.WorkArea.Height) && ((int)this.Top == 0) && ((int)this.Left == 0))
            {
                this.Left = NormalLeft;
                this.Top = NormalTop;
                this.Height = NormalHeight;
                this.Width = NormalWidth;
            }
            else
            {
                this.Top = 0;
                this.Left = 0;

                this.Width = SystemParameters.WorkArea.Width;
                this.Height = SystemParameters.WorkArea.Height;
            }

        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
            NormalLeft = this.Left;
            NormalTop = this.Top;
            NormalHeight = this.Height;
            NormalWidth = this.Width;
        }

        private void CloseApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MinimizeWindow(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if ((this.Width != SystemParameters.WorkArea.Width) && (this.Height != SystemParameters.WorkArea.Height) && ((int)this.Top != 0) && ((int)this.Left != 0))
            {
                NormalLeft = this.Left;
                NormalTop = this.Top;
                NormalHeight = this.Height;
                NormalWidth = this.Width;
            }

        }
        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public AbonentView()
        {
            InitializeComponent();
            NormalLeft = this.Left;
            NormalTop = this.Top;
            NormalHeight = this.Height;
            NormalWidth = this.Width;
        }

        #endregion






    }
}
