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

https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/Concepts.RegionsAndAvailabilityZones.html
   
Amazon.RegionEndpoint System name list

us-east-2 => US East (Ohio)

us-east-1 => US East (N. Virginia)

us-west-1 => US West (N. California)

us-west-2 => US West (Oregon)

af-south-1 => Africa (Cape Town)

ap-east-1 => Asia Pacific (Hong Kong)

ap-south-1 => Asia Pacific (Mumbai)

ap-northeast-3	 => Asia Pacific (Osaka-Local)

ap-northeast-2 => Asia Pacific (Seoul)

ap-southeast-1 => Asia Pacific (Singapore)

ap-southeast-2 => Asia Pacific (Sydney)

ap-northeast-1 => Asia Pacific (Tokyo)

ca-central-1 => Canada (Central)

cn-north-1 => TChina (Beijing)

cn-northwest-1 => China (Ningxia)

eu-central-1 => Europe (Frankfurt)

eu-west-1 => Europe (Ireland)

eu-west-2 => Europe (London)

eu-south-1 => Europe (Milan)

eu-west-3 => 	Europe (Paris)

eu-north-1 => Europe (Stockholm)

me-south-1 => Middle East (Bahrain)

sa-east-1 => 	South America (São Paulo)

us-gov-east-1 => AWS GovCloud (US-East)

us-gov-west-1 => AWS GovCloud (US)
   
