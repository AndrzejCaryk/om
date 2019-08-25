using log4net;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseOmada
{
    /// <summary>
    /// Simple result logger 
    /// </summary>
    class ExerciseLogger
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public void CreateTestLogs(TestContext context)
        {
            log.InfoFormat("=====NEW TEST=====");
            log.InfoFormat("Test Name: {0}", context.Test.Name);
            log.InfoFormat("Test Status: {0}", context.Result.Outcome.Status.ToString());
            log.InfoFormat("Test Message: {0}", context.Result.Message);
            log.InfoFormat("Test StackTrace: {0}", context.Result.StackTrace);
            log.InfoFormat("=====END TEST=====");
        }
    }
}