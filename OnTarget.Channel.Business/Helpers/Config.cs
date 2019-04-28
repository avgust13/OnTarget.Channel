using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTarget.Channel.Business.Helpers
{
    public static class Config
    {
        private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static string YouTubeApiKey
        {
            get { return ConfigurationManager.AppSettings["YouTubeApiKey"]; }
        }

        public static string ChannelName
        {
            get { return ConfigurationManager.AppSettings["ChannelName"]; }
        }

        public static DateTime ChannelFromDate
        {
            get
            {
                string dateString = ConfigurationManager.AppSettings["ChannelFromDate"];// 1/12/2018
                string format = "dd/MM/yyyy";
                DateTime? dateTime = null;

                try
                {
                    dateTime = DateTime.ParseExact(dateString, format, CultureInfo.InvariantCulture);
                }
                catch (ArgumentNullException ane)
                {
                    _log.Error("Specify date from in app.config", ane);
                    throw new ArgumentNullException("Specify date from in app.config", ane);
                }
                catch (FormatException fe)
                {
                    _log.Error("Date from is in wrong format", fe);
                    throw new FormatException("Date from is in wrong format", fe);
                }

                return dateTime.Value;
            }
        }
    }
}
