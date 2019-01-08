using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;

namespace DoctorPortal.Web.Common
{
    public static class Logger
    {
        // ReSharper disable once InconsistentNaming
        public static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
    }
}