# Securing WCF With X-509, User name / Password & Roles

[![](https://github.com/favicon.ico)](https://github.com/rohansen/Code-Examples/tree/master/Technology%20Course%20Examples/WCF%20with%20SSL%20and%20UsernamePW)

## Steps needed for implementation



# Getting our basic workspace ready -> create the following projects in Visual Studio
  - A Windows Communication Foundation (WCF) Service Library ___(You could call it SecureService)___
  - A Console Application that can host your service ___(You could call it SecureServiceHost)___
  - A Console Application that can be the client of your service ___(You could call it SecureClient)___

Since you are going to host your service in a Console Application, you need to move your WCF Configuration to your hosts __app.config__

  - Your hosting console application needs to know the implementation of your service, so you must reference the service library from your console host.
  
Now your basic setup is done.
  
Before we move further, we need to acquire a X-509 Certificate.


