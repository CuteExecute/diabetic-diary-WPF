using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetControl_2._0
{
    class Result : WrapperResult
    {
        event Action NewResultNotification;

        //public string Day { get; set; }
        //public string Time { get; set; }
        //public int CurrenеDayIndex { get; set; }
        //public double Resultation { get; set; }

        public Result(double Resultation, int CurrenеDayIndex)
        {
            base.Resultation = Resultation;
            base.CurrenеDayIndex = CurrenеDayIndex;

            base.Day = DateTime.Now.Date.ToString("dd.MM.yyyy");
            base.Time = DateTime.Now.ToString("HH:mm");

            if (NewResultNotification != null)
                NewResultNotification.Invoke(); // Notify for creating result 
        }
    }
}
