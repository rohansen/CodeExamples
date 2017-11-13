# Securing WCF With X-509, User name / Password & Roles

[![](https://github.com/favicon.ico)](https://github.com/rohansen/Code-Examples/tree/master/Technology%20Course%20Examples/WCF%20with%20SSL%20and%20UsernamePW)

## Steps needed for implementation



# Getting our basic workspace ready
_create the following projects in Visual Studio_
  - A Windows Communication Foundation (WCF) Service Library ___(You could call it SecureService)___
  - A Console Application that can host your service ___(You could call it SecureServiceHost)___
  - A Console Application that can be the client of your service ___(You could call it SecureClient)___

Since you are going to host your service in a Console Application, you need to move your WCF Configuration from your WCF Service Library __app.config__ to your hosts __app.config__

  - Your hosting console application needs to know the implementation of your service, so you must reference the service library assembly from your console host project.
  
Now your basic setup is done.
  
Before you move further, you need to acquire a X-509 Certificate.

# Setting up an X-509 Certificate
Run the following command in a PowerShell terminal
```javascript
New-SelfSignedCertificate -DnsName "localhost" -CertStoreLocation "cert:\LocalMachine\My" -FriendlyName "UCN Computer Science 3rd Semester" -Subject "Ronni Hansen"
```
This will generate a X-509 Certificate with the Microsoft default settings (RSA 2048 bit key, sha256 signature algorithm), and install it to your local keystore at the "LocalMachine\My" location. 

  - Open "Run" in windows, type "certmgr" and press return.
  - Navigate to Certificates->Personal->Certificates and review you new certificate.


