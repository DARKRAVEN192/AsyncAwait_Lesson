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
using System.Net;


using ExampleWPF01.Models;
using System.Diagnostics;

namespace ExampleWPF01
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnSync_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            RunSyncLoad();

            stopwatch.Stop();
            long time = stopwatch.ElapsedMilliseconds;
            txtBlock.Text += $"Totat time: {time} ms \n\n";
        }

        private async void Btn_AsyncClick(object sender, RoutedEventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            await RunAsyncLoad();

            stopwatch.Stop();
            long time = stopwatch.ElapsedMilliseconds;
            txtBlock.Text += $"Totat time: {time} ms \n\n";
        }

        private async Task RunAsyncLoad()
        {
            List<string> sites = PrepareData();

            foreach (var site in sites)
            {
                DataModel model = await Task.Run(() => DownloadSite(site));
                ReportInfo(model);
            }
        }
        private void RunSyncLoad()
        {
            List<string> sites = PrepareData();

            foreach (var site in sites)
            {
                DataModel model = DownloadSite(site);
                ReportInfo(model);
            }
        }

        private void ReportInfo(DataModel dataModel)
        {
            txtBlock.Text += $"Site: {dataModel.Url}, Length: {dataModel.Data.Length}\n";
        }

        private List<string> PrepareData()
        {
            List<string> list = new List<string>()
            {
                "https://www.google.ru/",
                "https://www.youtube.com/",
                "https://github.com/DARKRAVEN192"
            };

            return list;
        }

        private DataModel DownloadSite(string url)
        {
            DataModel dataModel = new DataModel();

            dataModel.Url = url;

            //download from internet
            WebClient client = new WebClient();

            dataModel.Data = client.DownloadString(url);

            return dataModel;
        }
    }
}
