using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Dapper;
using System.Data.SqlClient;

namespace RewardPortalFunctions
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async void Run([TimerTrigger("0 */5 * * * *")]TimerInfo myTimer, ILogger log)
        {
            var connectionString = Environment.GetEnvironmentVariable("PortalDB");

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.ExecuteAsync("[rewardpo_earn].[sp_AddSurveyTasks]");
            }
            //log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }
}
