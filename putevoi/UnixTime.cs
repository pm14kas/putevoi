using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


static class UnixTime 
{
    public static long Now { get {return (long)Math.Truncate((DateTime.Now.Subtract(new DateTime(1970, 1, 1))).TotalSeconds); } } //return current timestamp in UnixTime format

    public static long To(DateTime time)
        { 
        return (long)Math.Truncate((time.Subtract(new DateTime(1970, 1, 1))).TotalSeconds); 
    } 

    public static DateTime From(long unixtime)
    {
        DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Local);
        dateTime = dateTime.AddSeconds(unixtime).ToLocalTime();
        return dateTime;
    }

}

