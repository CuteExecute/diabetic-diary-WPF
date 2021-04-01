using SweetControl_2._0.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace SweetControl_2._0.ViewModels
{
    class ResultsViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Singleton for using in another ViewModel(and not only) 
        /// </summary>
        private static ResultsViewModel instance;
        public static ResultsViewModel getInstance()
        {
            if (instance == null)
                instance = new ResultsViewModel();
            return instance;
        }

        /// <summary>
        /// For notify the system about property changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        JsonFileWorker myJsonWorker = JsonFileWorker.getInstance();
        GraphicViewModel graphic    = GraphicViewModel.getInstance();
        Regex regex                 = new Regex("^[0-9]*[.][0-9]*$");

        /// <summary>
        /// Ctor, here the results are read from the file
        /// </summary>
        public ResultsViewModel()
        {
            Results = new ObservableCollection<Result>(myJsonWorker.ReadingFromFile().Reverse());
        }

        private ObservableCollection<Result> _Results;
        public ObservableCollection<Result> Results
        {
            get { return _Results; }
            set
            {
                _Results = value;
                OnPropertyChanged("Results");
            }
        }

        private Result _SelectedResult;
        public Result SelectedResult
        {
            get { return _SelectedResult; }
            set
            {
                _SelectedResult = value;
                OnPropertyChanged("");
            }
        }

        // temporary result to store the state of the old selected result 
        public static Result TempResult { get; set; } = new Result();
        public static int ListBoxSelectedIndex = 0;

        public ICommand AddResult
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    // write result to file
                    myJsonWorker.WriteToFile(obj.ToString(), 1);
                    MessageBox.Show($"Новый результат добавлен! {decimal.Parse(obj.ToString())}");

                    // update list in real time
                    Result res = new Result(decimal.Parse(obj.ToString()), 1);
                    Results.Insert(0, res);
                    SelectedResult = res;

                    // If added new day when, update current list of days in GraphicViewModel ( Does't work, idk why? )
                    Day newDay = new Day(DateTime.Now.Date.ToString("dd.MM.yyyy"));
                    graphic.Days.Insert(0, newDay);
                    graphic.SelectedDay = newDay;

                    // update graph if the listbox contains the current date
                    if (graphic.SelectedDay.Date == DateTime.Now.Date.ToString("dd.MM.yyyy"))
                        graphic.DrawGraphic();
                    else
                    {

                    }
                },
                (obj) => // a check that enables and disable button
                { 
                    if (obj != null && regex.IsMatch(obj.ToString()))
                        return true;
                    else
                        return false;
                } );
            }
        }

        public ICommand DeleteResult
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    // delete result from file
                    myJsonWorker.RemoveFileLine(SelectedResult.Date, SelectedResult.Time, "1", SelectedResult.Resultation);

                    MessageBox.Show($"Результат удален: {SelectedResult.Date} - {SelectedResult.Time} - {SelectedResult.Resultation}");

                    // delete result from listbox 
                    Results.RemoveAt(ListBoxSelectedIndex);

                    // update graph if the listbox contains the current date
                    if (graphic.SelectedDay.Date == DateTime.Now.Date.ToString("dd.MM.yyyy"))
                        graphic.DrawGraphic();
                    else
                    {

                    }

                },
                (obj) => // a check that enables and disable button
                {
                    if (SelectedResult != null)
                        return true;
                    else
                        return false;
                });
            }
        }

        public ICommand EditResult
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    //MessageBox.Show($"date - {TempResult.Date}" +
                    //    $"\n time - {TempResult.Time}" +
                    //    $"\n index - {TempResult.CurrentDayIndex.ToString()}" +
                    //    $"\n res - {TempResult.Resultation}" +
                    //    $"\n new res - {decimal.Parse((string)obj)}");

                    // Edit result in file
                    myJsonWorker.EditResultFileLine(TempResult.Date,
                        TempResult.Time,
                        TempResult.CurrentDayIndex.ToString(),
                        TempResult.Resultation,
                        decimal.Parse((string)obj));

                    // Update current temporary result
                    TempResult = new Result
                    {
                        CurrentDayIndex = TempResult.CurrentDayIndex,
                        Date = TempResult.Date,
                        Time = TempResult.Time,
                        Resultation = decimal.Parse((string)obj)
                    };

                    // update selected result that was changed
                    SelectedResult = Results[ListBoxSelectedIndex];

                    // update graph if the listbox contains the current date
                    if (graphic.SelectedDay.Date == SelectedResult.Date)
                        graphic.DrawGraphic();
                    else
                    {

                    }

                    MessageBox.Show($"Результат изменен с {TempResult.Resultation} на {SelectedResult.Resultation}");
                },
                (obj) => // a check that enables and disable button
                {
                    if (SelectedResult != null)
                        return true;
                    else
                        return false;
                });
            }
        }
    }
}
