﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace UnweWeatherApp
{
    public class LongToDateTimeConverter : IValueConverter
    {
        
            DateTime _time = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                long dateTime = (long)value; 
                return $"{_time.AddSeconds(dateTime).ToLocalTime().ToString("HH:mm")} ч.";
            }
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        
    }
}
