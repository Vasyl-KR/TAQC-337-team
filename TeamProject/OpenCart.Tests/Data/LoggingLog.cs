using System;
using System.IO;

namespace WebServiceTest
{
    public class LoggingLog
    {
        #region Fields

        private static StreamWriter streamWriter;
        private static FileStream fileStream;
        private static string directory;

        #endregion

        #region Public Methods

        public static void Dispose()
        {
            if (streamWriter != null)
            {
                streamWriter.Close();
            }
        }

        /// <summary>
        /// Initialization logging
        /// </summary>
        public static void InitializationLogging()
        {
            directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            DirectoryInfo lDirectoryInfo = new DirectoryInfo(string.Format("{0}\\TestsLog\\", directory));
            if (!lDirectoryInfo.Exists)
            {
                lDirectoryInfo.Create();
            }

            fileStream =
                File.Open(
                    string.Format("{0}\\TestsLog\\Logging.{1}.txt", directory, DateTime.Now.ToString("MM/dd/yyyy")),
                    FileMode.Append,
                    FileAccess.Write,
                    FileShare.Read);
            streamWriter = new StreamWriter(fileStream);
        }

        /// <summary>
        /// Write log
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static void WritingLogging(string message, Exception exception )
        {
            if (exception != null)
            {
                streamWriter.WriteLine("{0}; {1}", DateTime.Now, string.Format($"{exception.Message} \n stack trace:\n {exception.StackTrace}"));
            }
            else
            {
                streamWriter.WriteLine("{0}; {1}", DateTime.Now, message);
            }
                
                streamWriter.Flush();
            }
        
        #endregion
    }
}
