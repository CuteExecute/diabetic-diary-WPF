using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetControl_2._0
{
    interface IResult
    {
        string Day { get; set; }
        string Time { get; set; }
        int CurrenеDayIndex { get; set; }
        double Resultation { get; set; }
    }
}
