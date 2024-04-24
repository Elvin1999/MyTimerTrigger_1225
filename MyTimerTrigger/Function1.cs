using System;
using System.IO;
using System.Text;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace MyTimerTrigger
{
    public class Function1
    {
        [FunctionName("Function1")]
        public void Run([TimerTrigger("*/3 * * * * *")] TimerInfo myTimer, ILogger log,
            [Blob("logs/mydata.txt", System.IO.FileAccess.Write, Connection = "MyAzureStorage")] Stream blobStream)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            var data = Encoding.UTF8.GetBytes($"Step Academy LOGS : {DateTime.Now}");
            blobStream.Write(data, 0, data.Length);
            blobStream.Close();
            blobStream.Dispose();
        }
    }
}
