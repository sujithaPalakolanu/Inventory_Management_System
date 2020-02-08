using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Services
{
    public class CustomSchedular
    {
        public static void IntervalInDays(int hour, int min, double interval, Action task)
        {
            interval = interval * 24;
            ScheduledServices.Instance.ScheduleTask(hour, min, interval, task);
        }
    }
}