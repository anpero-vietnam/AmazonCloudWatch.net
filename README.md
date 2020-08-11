# AmazonCloudWatch.net sample
1) Support for CreateLogGroup if awslogs-group does not exist,
2) Support for CreateLogStream if awslogs-Stream does not exist
3) Config in App.config or Web.config file
Amazone setup
1) In top menu click your name > My Security Credentials > Access keys (access key ID and secret access key) > get access key ID and secret access key

Config code
1) Install-Package AWSSDK ( if error)
2) Open App.config or Web.config file
update value keys
  <add key="awsAccessKeyId" value="get in Amazone setup step 3 "/>
  <add key="awsSecretAccessKey" value="get in Amazone setup step 3"/>
  <add key="logGroupName" value="get in Amazone setup step 1"/>
  <add key="logStreamName" value="get in Amazone setup step 2"/>

3) Select regionEndpoint near your server in the link below and set value for key  <add key="regionEndpoint" value=""/>
   https://docs.aws.amazon.com/sdkfornet/v3/apidocs/items/Amazon/TRegionEndpoint.html
   
Amazon.RegionEndpoint list

AFSouth1 => The Africa (Cape Town) endpoint.
APEast1 => The Asia Pacific (Hong Kong) endpoint.
APNortheast1 => The Asia Pacific (Tokyo) endpoint.
APNortheast2 => The Asia Pacific (Seoul) endpoint.
APNortheast3 => The Asia Pacific (Osaka-Local) endpoint.
APSouth1 => The Asia Pacific (Mumbai) endpoint.
APSoutheast1 => The Asia Pacific (Singapore) endpoint.
APSoutheast2 => The Asia Pacific (Sydney) endpoint.
CACentral1 => The Canada (Central) endpoint.
CNNorth1 => The China (Beijing) endpoint.
CNNorthWest1 => The China (Ningxia) endpoint.
EUCentral1 => The EU Central (Frankfurt) endpoint.
EUNorth1 => The EU North (Stockholm) endpoint.
EUSouth1 => The Europe (Milan) endpoint.
EUWest1 => The EU West (Ireland) endpoint.
EUWest2 => The EU West (London) endpoint.
EUWest3 => The EU West (Paris) endpoint.
MESouth1 => The Middle East (Bahrain) endpoint.
SAEast1 => The South America (Sao Paulo) endpoint.
USEast1 => 	The US East (Virginia) endpoint.
USEast2 => The US East (Ohio) endpoint.
USGovCloudEast1 => The US GovCloud East (Virginia) endpoint.
USGovCloudWest1 => 	The US GovCloud West (Oregon) endpoint.
USWest1 => The US West (N. California) endpoint.
USWest2 => The US West (Oregon) endpoint.
   
