using SweetControl_2._0.Models;
using SweetControl_2._0.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace SweetControl_2._0.ViewModels
{
    class GraphicViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// For use in other ViewModel (and not only)
        /// </summary>
        private static GraphicViewModel instance;
        public static GraphicViewModel getInstance()
        {
            if (instance == null)
                instance = new GraphicViewModel();
            return instance;
        }

        /// <summary>
        /// For notify the system about property changes 
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        JsonFileWorker myJsonWorker = JsonFileWorker.getInstance();

        /// <summary>
        /// Ctor, creating a collection of days with results and set selected day
        /// </summary>
        public GraphicViewModel()
        {
            Days     = new ObservableCollection<Day>();
            Results  = new ObservableCollection<Result>(myJsonWorker.ReadingFromFile().Reverse());

            // Group result by only date
            var days = from wRes in Results
                       group wRes.Date by wRes.Date into daysGroup
                       select daysGroup.Key;

            foreach (var item in days)
            {
                Days.Add(new Day(item));
            }

            _SelectedDay = new Day(Days[0].Date);

            // Temporary solution, until i fix the listbox update from another ViewModel
            if (_SelectedDay.Date != DateTime.Now.Date.ToString("dd.MM.yyyy"))
            {
                Day newDay = new Day(DateTime.Now.Date.ToString("dd.MM.yyyy"));
                Days.Insert(0, newDay);
            }
        }

        /// <summary>
        /// Listbox update procedure, but work only from this the ViewModel(GraphicViewModel)
        /// and only with help ICommand (in fatc not used)
        /// </summary>
        public void UpdateList()
        {
            Day newDay = new Day(DateTime.Now.Date.ToString("dd.MM.yyyy"));
            Days.Insert(0, newDay);
            SelectedDay = newDay;
        }

        public List<UserControlGraphic.Point> _PointList = new List<UserControlGraphic.Point>();
        public List<UserControlGraphic.Point> PointList
        {
            get { return _PointList; }
            set
            {
                _PointList = value;
                OnPropertyChanged("PointList");
            }
        }

        public ObservableCollection<Result> Results { get; set; }

        private ObservableCollection<Day> _Days;
        public ObservableCollection<Day> Days
        {
            get
            {
                return _Days;
            }
            set
            {
                _Days = value;
                OnPropertyChanged("Days");
            }
        }

        private Day _SelectedDay;
        public Day SelectedDay
        {
            get { return _SelectedDay; }
            set
            {
                _SelectedDay = value;
                OnPropertyChanged("SelectedDay");

                // update graphic
                DrawGraphic(); 
            }
        }

        /// <summary>
        /// Graphic upd procedure - update on View(UserControlGraphic)
        /// </summary>
        public void DrawGraphic()
        {
            PointList.Clear();
            
            PointList.AddRange(getResultsByDay(SelectedDay.Date));

            // I know, not a very beautiful architectural solution... but... (´• ︹ •)
            // otherwise i couldn't do it
            MainWindow.graphic.PointList = PointList;
            MainWindow.graphic.Update(PointList);
        }

        /// <summary>
        /// Accepts a date and return point array  
        /// </summary>
        /// <param name="Date"> selected day </param>
        /// <returns></returns>
        public UserControlGraphic.Point[] getResultsByDay(string Date) 
        {
            Result[] wrapperResults = myJsonWorker.ReadingFromFile();

            // get result by date
            var dayResults = from wRes in wrapperResults
                             where wRes.Date == Date
                             select wRes;

            Result[] results = dayResults.ToArray();
            UserControlGraphic.Point[] dayPoints = new UserControlGraphic.Point[results.Length];

            for (int i = 0; i < dayPoints.Length; i++)
            {
                dayPoints[i] = new UserControlGraphic.Point(i, (double)results[i].Resultation);
            }

            return dayPoints;
        }

        /// <summary>
        /// Update command, not use in current time
        /// </summary>
        public ICommand Update
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    UpdateList();
                });
            }
        }
    }

    /// <summary>
    /// Day class contains date and is needed for days list
    /// </summary>
    public class Day : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public Day()
        {

        }
        public Day(string Date)
        {
            this.Date = Date;
        }

        private string _Date;
        public string Date
        {
            get { return _Date; }
            set
            {
                _Date = value;
                OnPropertyChanged("Date");
            }
        }
    }
}
