using System;
using System.Text;

namespace Logger
{
    public static class Logger
    {
        private static log4net.ILog Log { get; set; }

        static Logger()
        {
            Log = log4net.LogManager.GetLogger(typeof(Logger));
        }

        public static void LogInfo(object msg)
        {
            Log.Info(msg);
        }

        public static void LogWarn(object msg)
        {
            Log.Warn(msg);
        }

        public static void LogDebug(object msg)
        {
            Log.Debug(msg);
        }

        public static void LogError(object msg)
        {
            Log.Error(msg);
        }

        public static void LogError(Exception ex)
        {
            StringBuilder sbMsg = new StringBuilder();

            sbMsg.Append(System.Environment.NewLine);
            sbMsg.Append("Stack Trace:");
            sbMsg.Append(System.Environment.NewLine);
            sbMsg.Append("----------------------------------------------------------------------");
            sbMsg.Append(System.Environment.NewLine);
            sbMsg.Append(ex.Message);
            sbMsg.Append(System.Environment.NewLine);
            sbMsg.Append(ex.StackTrace);

            if (ex.InnerException != null)
            {
                sbMsg.Append(System.Environment.NewLine);
                sbMsg.Append("Inner Exception");

                if (!string.IsNullOrEmpty(ex.InnerException.Message))
                {
                    sbMsg.Append(System.Environment.NewLine);
                    sbMsg.Append(ex.InnerException.Message);
                }

                if (!string.IsNullOrEmpty(ex.InnerException.StackTrace))
                {
                    sbMsg.Append(System.Environment.NewLine);
                    sbMsg.Append(ex.InnerException.StackTrace);
                }
            }

            sbMsg.Append(System.Environment.NewLine);
            sbMsg.Append("----------------------------------------------------------------------");

            Log.Error("----------------------------------------------------------------------");
            Log.Error(ex);
            Log.Error(sbMsg.ToString());
        }

        public static void LogError(object msg, Exception ex)
        {
            StringBuilder sbMsg = new StringBuilder();

            sbMsg.Append(System.Environment.NewLine);
            sbMsg.Append("Stack Trace:");
            sbMsg.Append(System.Environment.NewLine);
            sbMsg.Append("----------------------------------------------------------------------");
            sbMsg.Append(System.Environment.NewLine);
            sbMsg.Append(msg.ToString());
            sbMsg.Append(System.Environment.NewLine);
            sbMsg.Append(ex.Message);
            sbMsg.Append(System.Environment.NewLine);
            sbMsg.Append(ex.StackTrace);

            if (ex.InnerException != null)
            {
                sbMsg.Append(System.Environment.NewLine);
                sbMsg.Append("Inner Exception");

                if (!string.IsNullOrEmpty(ex.InnerException.Message))
                {
                    sbMsg.Append(System.Environment.NewLine);
                    sbMsg.Append(ex.InnerException.Message);
                }

                if (!string.IsNullOrEmpty(ex.InnerException.StackTrace))
                {
                    sbMsg.Append(System.Environment.NewLine);
                    sbMsg.Append(ex.InnerException.StackTrace);
                }
            }

            sbMsg.Append(System.Environment.NewLine);
            sbMsg.Append("----------------------------------------------------------------------");

            Log.Error("----------------------------------------------------------------------");
            Log.Error(msg,ex);
            Log.Error(sbMsg.ToString());
        }
    }
}
