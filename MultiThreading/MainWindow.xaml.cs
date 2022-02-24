using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace MultiThreading
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int Counter { get; set; } = 0;

        public MainWindow()
        {
            InitializeComponent();

            Tbl_LongTask.Text = "Status";

            Tbl_ShortTask.Text = "Count";


        }

        private async void Btn_LongTask_Click(object sender, RoutedEventArgs e)
        {
            //TPL-Einsatz in WPF

            //Btn_LongTask.IsEnabled = false;

            //Thread.Sleep(2000);
            //Tbl_LongTask.Text = "Long Task Completed";
            //Btn_LongTask.IsEnabled = true;



            //var task = Task.Run(() =>
            //{
            //    Thread.Sleep(2000);
            //    return "Long Task Completed";
            //});

            //task.ContinueWith(t =>
            //{
            //    Dispatcher.Invoke(() =>
            //    {
            //        Btn_LongTask.IsEnabled = true;
            //        Tbl_LongTask.Text = t.IsFaulted? t.Exception.InnerException.Message : t.Result;
            //    });
            //});  


            ////Await lässt nachfolgenden Code der Async-Methode auf Task-Abschluss warten
            //string taskResult = "";
            //try
            //{
            //    taskResult = await Task.Run(() =>
            //    {
            //        Thread.Sleep(2000);
            //        return "Long Task Completed";
            //    });
            //}
            //catch(Exception ex)
            //{
            //    taskResult = ex.Message;
            //}
            //Btn_LongTask.IsEnabled = true;
            //Tbl_LongTask.Text = taskResult;


            var task1 = Task.Run(() =>
            {
                Thread.Sleep(2000);
                return "Long Task 1 Completed";
            });
            var task2 = Task.Run(() =>
            {
                Thread.Sleep(3000);
                return "Long Task 2 Completed";
            });
            var task3 = Task.Run(() =>
            {
                Thread.Sleep(4000);
                return "Long Task 3 Completed";
            });

            var results = await Task.WhenAll(task1, task2, task3);

            Btn_LongTask.IsEnabled = true;
            Tbl_LongTask.Text = "Completed: " + string.Join(", ", results);



            //Weitere Stichwörter: TaskParallelLibrary(TPL), Parallel-Class,

        }

        private void Btn_ShortTask_Click(object sender, RoutedEventArgs e)
        {
            Counter += 1;
            Tbl_ShortTask.Text = Counter.ToString();
        }
    }
}
