using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
  public class WorkDayCalculator : IWorkDayCalculator
  {

    public DateTime Calculate(DateTime startDate, int dayCount, WeekEnd[] weekEnds)
    { 
      if (dayCount <= 0)
      {
        return startDate;
      }
      if (weekEnds != null)
      {
        int startDayCountValue = dayCount;
        DateTime endDate = startDate;
        foreach (var weekend in weekEnds)
        {
          int weekendPeriod = weekend.EndDate.Subtract(weekend.StartDate).Days + 1;
          int difference = weekend.StartDate.Subtract(startDate).Days;
          if (difference >= 0 && difference < dayCount)
          {
            endDate = endDate.AddDays(weekendPeriod);
            dayCount -= difference;
          }
        }
        if(dayCount == startDayCountValue)
        {
          endDate = endDate.AddDays(dayCount-1);
        }
        else if (dayCount > 0)
        {
          endDate = endDate.AddDays(dayCount+1);
        }
        return endDate;
      }
      return startDate.AddDays(dayCount-1);
    }
  }
}
