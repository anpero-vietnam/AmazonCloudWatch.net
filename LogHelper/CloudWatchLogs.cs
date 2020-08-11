using Amazon.CloudWatchLogs;
using Amazon.CloudWatchLogs.Model;
using Amazon.ConfigService;
using Amazon.ECS.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
//Run Install-Package AWSSDK -Version 2.3.55.2
namespace LogHelper
{

    /// <summary>
    ///
    /// </summary>
    public class CloudWatchLogs : ILogger
    {
        private AmazonCloudWatchLogsClient client;
        public CloudWatchLogs()
        {
            awsAccessKeyId = ConfigurationManager.AppSettings["awsAccessKeyId"];
            awsSecretAccessKey = ConfigurationManager.AppSettings["awsSecretAccessKey"];
            logGroupName = ConfigurationManager.AppSettings["logGroupName"];
            logStreamName = ConfigurationManager.AppSettings["logStreamName"];
            regionEndpoint = ConfigurationManager.AppSettings["regionEndpoint"];
        }
        public bool Log(string message)
        {
            
            client = new AmazonCloudWatchLogsClient(awsAccessKeyId, awsSecretAccessKey, GetAmazonRegionEndpoint(regionEndpoint));
            List<InputLogEvent> listLog = new List<InputLogEvent>();
            listLog.Add(new InputLogEvent()
            {
                Message = message,
                Timestamp = DateTime.Now
            });

            var putLogEventRequest = new PutLogEventsRequest()
            {
                LogGroupName = logGroupName,
                LogStreamName = logStreamName,
                LogEvents = listLog
            };
            CheckGroupName(client, logGroupName);
            CheckStream(client, logGroupName, logStreamName);
            var describeLogStreamsRequest = new DescribeLogStreamsRequest(logGroupName);
            var describeLogStreamsResponse = client.DescribeLogStreams(describeLogStreamsRequest);
            var logStreams = describeLogStreamsResponse.LogStreams;
            var logStream = logStreams.FirstOrDefault(ls => ls.LogStreamName == logStreamName);
            if (logStream != null)
            {
                putLogEventRequest.SequenceToken = logStream.UploadSequenceToken;
            }
            try
            {
                var response = client.PutLogEvents(putLogEventRequest);

            }
            catch (Amazon.CloudWatchLogs.Model.InvalidParameterException e)
            {
                // log to file                
                throw;
            }
            finally
            {
                client?.Dispose();
            }
            return true;
        }
        
        #region private function            
        private readonly string awsAccessKeyId, awsSecretAccessKey, logGroupName, logStreamName, regionEndpoint;
        /// <summary>
        /// Check for existence of Stream by name, if not, create a new one
        /// </summary>
        /// <param name="client">AmazonCloudWatchLogsClient</param>
        /// <param name="groupName">groupName</param>
        /// <param name="streamName">streamName</param>
        private void CheckStream(AmazonCloudWatchLogsClient client, string groupName, string streamName)
        {
            var response = client.DescribeLogStreams(new DescribeLogStreamsRequest { OrderBy = OrderBy.LogStreamName, LogGroupName = groupName, LogStreamNamePrefix = streamName, Limit = 1 });
            var streamInfo = response.LogStreams.FirstOrDefault();
            if (streamInfo == null || streamInfo.LogStreamName != streamName)
            {
                client.CreateLogStream(new CreateLogStreamRequest { LogGroupName = groupName, LogStreamName = streamName });
            }
        }
        /// <summary>
        /// Check for existence of Group by name, if not, create a new one
        /// </summary>
        /// <param name="client">AmazonCloudWatchLogsClient</param>
        /// <param name="groupName">groupName</param>
        private void CheckGroupName(AmazonCloudWatchLogsClient client, string groupName)
        {

            var response = client.DescribeLogGroups(new DescribeLogGroupsRequest { Limit = 1, LogGroupNamePrefix = groupName });
            var groupsInfo = response.LogGroups.FirstOrDefault();
            if (groupsInfo == null || groupsInfo.LogGroupName != groupName)
            {
                client.CreateLogGroup(new CreateLogGroupRequest(groupName));
            }
        }
        private Amazon.RegionEndpoint GetAmazonRegionEndpoint(string regionEndpointString)
        {
            return Amazon.RegionEndpoint.EnumerableAllRegions.Where(r => r.ToString().Equals(regionEndpointString, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault() ?? Amazon.RegionEndpoint.APSoutheast1;
        }   

        #endregion private function
    }

}
