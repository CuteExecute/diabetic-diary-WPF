using SweetControl_2._0.Models;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Timers;
using System.Windows.Input;

namespace SweetControl_2._0.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// For notify the system about property changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public MainViewModel()
        {
            _Counter = new Counter(0);

            // Create timer for RAM monitoring
            var timer = new Timer() { Interval = 1000 };
            timer.Start();
            timer.Elapsed += (o, e) =>
            {
                MemoryMonitor();
                Console.WriteLine();
            };
        }

        // Get the current used memory
        public void MemoryMonitor()
        {
            Memory  = "RAM ";
            Memory += (Process.GetCurrentProcess().WorkingSet64/1024/1024).ToString();
            Memory += " mb";
        }

        private string _Memory;
        public string Memory
        {
            get { return _Memory; }
            set
            {
                _Memory = value;
                OnPropertyChanged();
            }
        }

        // Counter clicks
        private Counter _Counter;
        public Counter Counter
        {
            get { return _Counter; }
            set
            {
                _Counter = value;
                OnPropertyChanged();
            }
        }

        // Count clicks on buttons
        public ICommand ClickAdd
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    _Counter.Count++;
                });
            }
        }
    }
}
