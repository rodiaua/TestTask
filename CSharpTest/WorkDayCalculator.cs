using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
  public class WorkDayCalculator : IWorkDayCalculator
  {
    public DateTime Calculate(DateTime startDate, int dayCount, WeekEnd[] weekEnds)
    { 
      if (weekEnds != null)
      {
        int oneDay = 1;
        int i = 1;
        foreach (var weekEnd in weekEnds)
        {
          for (; i < dayCount;)
          {
            startDate = startDate.AddDays(oneDay);
            if (startDate.CompareTo(weekEnd.StartDate) < 0
              || startDate.CompareTo(weekEnd.EndDate) > 0)
            {
              i++;
            }
          }
        }
      }else startDate = startDate.AddDays(dayCount-1);
      return startDate;
    }
  }
}
