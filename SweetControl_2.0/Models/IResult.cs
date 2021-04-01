using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetControl_2._0
{
    interface IResult
    {
        string Date { get; set; }
        string Time { get; set; }
        int CurrentDayIndex { get; set; }
        decimal Resultation { get; set; }
    }
}
