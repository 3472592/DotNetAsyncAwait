using System.Windows;
using System.Threading;
using System.Windows.Threading;
using System;
using System.Threading.Tasks;

namespace AsyncAwaitWPFPractice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer timer = new();
        public MainWindow()
        {
            InitializeComponent();
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromSeconds(1);
        }

        private int i = 0;

        private void Timer_Tick(object? sender, EventArgs e)
        {
            progress.Text = (i++).ToString();
        }

        private async void CountButton_Click(object sender, RoutedEventArgs e)
        {
            countButton.IsEnabled = false;
            timer.Start();

            if (useAwaitAsync.IsChecked == true)
                await LongTaskAsync();
            else
                LongTask();
            countButton.IsEnabled = true;
        }

        private void LongTask()
        {
            Thread.Sleep(5000);
            timer.Stop();
        }

        private async Task LongTaskAsync()
        {
            await Task.Delay(5000);
            timer.Stop();
        }
    }
}
