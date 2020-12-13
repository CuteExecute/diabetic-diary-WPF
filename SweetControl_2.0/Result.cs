using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetControl_2._0
{
    class Result
    {
        event Action NewResultNotification;

        string Day { get; set; }
        string Time { get; set; }
        int CurrenеDayIndex { get; set; }
        double Resultation { get; set; }

        public Result(double Resultation, int CurrenеDayIndex)
        {
            this.Resultation = Resultation;
            this.CurrenеDayIndex = CurrenеDayIndex;

            Day = DateTime.Now.Date.ToString("dd.MM.yyyy");
            Time = DateTime.Now.ToString("HH:mm");

            if (NewResultNotification != null)
                NewResultNotification.Invoke(); // Notify for creating result 
        }
    }
}
