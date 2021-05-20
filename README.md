# RingCentral Azure function Demo


## Setup

Ref: https://docs.microsoft.com/en-us/azure/azure-functions/create-first-function-vs-code-csharp


## Local run

In Visual Studio Code terminal press "F5"

Visit http://localhost:7071/api/CallRingCentral?clientId=<clientId>&clinetSecret=<clientSecret>&username=<username>&extension=<extension>&password=<password>


## Production instance

I deployed one, and you can access it by

https://rc-azure-first-demo.azurewebsites.net/api/callringcentral?clientId=clientId&clinetSecret=clientSecret&username=username&extension=extension&password=password
