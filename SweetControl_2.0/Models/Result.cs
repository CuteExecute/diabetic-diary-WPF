using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace SweetControl_2._0.Models
{
    class Result : IResult, INotifyPropertyChanged
    {
        // for notify the system about property change
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        // Model properties: Date, Time, CurrentDayIndex, Resultation
        private string _Date;
        private string _Time;
        private int _CurrentDayIndex;
        private decimal _Resultation;

        public string Date 
        {
            get { return _Date; }
            set
            {
                _Date = value;
                OnPropertyChanged("Date");
            }
        }
        public string Time 
        {
            get { return _Time; } 
            set
            {
                _Time = value;
                OnPropertyChanged("Time");
            }
        }
        public int CurrentDayIndex 
        {
            get { return _CurrentDayIndex; } 
            set
            {
                _CurrentDayIndex = value;
                OnPropertyChanged("CurrentDayIndex");
            }
        }
        public decimal Resultation 
        {
            get { return _Resultation; } 
            set
            {
                _Resultation = value;
                OnPropertyChanged("Resultation");
            }
        }

        // For notify about the creation of the result (not used in current time)
        event Action NewResultNotification;

        public Result()
        {

        }

        // Ctro for creating new result
        public Result(decimal Resultation, int CurrentDayIndex)
        {
            this.Resultation = Resultation;
            this.CurrentDayIndex = CurrentDayIndex;

            this.Date = DateTime.Now.Date.ToString("dd.MM.yyyy");
            this.Time = DateTime.Now.ToString("HH:mm");

            // Notify about the creation of the result 
            if (NewResultNotification != null)
                NewResultNotification.Invoke(); 
        }
    }

    // Result validation rules (wpf feature)
    public class ResultRule : ValidationRule
    {
        Regex regex_validate_float = new Regex("^[0-9]*[.][0-9]*$");
        Regex regex_validete_float_support = new Regex("^[0-9]*[.]$");

        private double min = 0;
        private double max = 50;

        public double Min
        {
            get { return min; }
            set { min = value; }
        }

        public double Max
        {
            get { return max; }
            set { max = value; }
        }


        public override ValidationResult Validate(object value, System.Globalization.CultureInfo ci)
        {
            string result = "";

            try
            {
                result = (string)value;
            }
            catch
            {
                return new ValidationResult(false, "Недопустимые символы.");
            }
            if (regex_validate_float.IsMatch(result.ToString()) == false || regex_validete_float_support.IsMatch(result.ToString()))
            {
                return new ValidationResult(false, "Недопустимые символы.");
            }
            try
            {
                if ((Double.Parse(result) < Min) || (Double.Parse(result) > Max))
                {
                    return new ValidationResult(false,
                      "Не входит в диапазон " + Min + " до " + Max + ".");
                }
            }
            catch
            {
                
            }
            return new ValidationResult(true, null);
        }
    }
}
