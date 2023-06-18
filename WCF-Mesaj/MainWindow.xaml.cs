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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WCF_Mesaj
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {
        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
        public MainWindow()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();

            Closing += MainWindow_Closing;
            Loaded += MainWindow_Loaded;

            mesaj.Focus();

        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {

            if (System.IO.File.Exists("./data.txt"))
                isim.Text = System.IO.File.ReadAllText("./data.txt");

        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.IO.File.WriteAllText("./data.txt", isim.Text);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            txt1.Text = client.MesajGetir();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txt1.Text = client.MesajEkle("| " + isim.Text + " |  " + mesaj.Text + "  (" + DateTime.Now.ToString("dd/MM/yy HH:mm") + ")");
            mesaj.Text = "";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            client.MesajlarıiSil();
        }
    }
}
