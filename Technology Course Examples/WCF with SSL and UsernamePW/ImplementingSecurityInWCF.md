# Securing WCF With X-509, User name / Password & Roles (On Windows)

[![](https://github.com/favicon.ico)](https://github.com/rohansen/Code-Examples/tree/master/Technology%20Course%20Examples/WCF%20with%20SSL%20and%20UsernamePW)

## Steps needed for implementation



# Getting our basic workspace ready
_create the following projects in Visual Studio_
  - A Windows Communication Foundation (WCF) Service Library ___(You could call it SecureService)___
  - A Console Application that can host your service ___(You could call it SecureServiceHost, set this as your startup project)___
  - A Console Application that can be the client of your service ___(You could call it SecureClient)___

Since you are going to host your service in a Console Application, you need to move your WCF Configuration from your WCF Service Library __app.config__ to your hosts __app.config__

  - Your hosting console application needs to know the implementation of your service, so you must reference the service library assembly from your console host project.
  
Now your basic setup is done.
  
Before you move further, you need to acquire a X-509 Certificate.

# Setting up an X-509 Certificate
Run the following command in a PowerShell terminal
```c#
New-SelfSignedCertificate -DnsName "localhost" -CertStoreLocation "cert:\LocalMachine\My" -FriendlyName "UCN Computer Science 3rd Semester" -Subject "Ronni Hansen"
```
This will generate a X-509 Certificate with the Microsoft default settings (RSA 2048 bit key, sha256 signature algorithm), and install it to your local keystore at the "LocalMachine\My" location. [(documentation)](https://docs.microsoft.com/en-us/powershell/module/pkiclient/new-selfsignedcertificate?view=win10-ps)

  - Open "Run" in windows, type "certmgr" and press return.
  - Navigate to Certificates->Personal->Certificates and review you new certificate.

# Configuring your host application
  - Open you host application __app.config__ file.
  - Change your service base address to something more simple, like the following, remember HTTPS in the url! 
  - Take note of the port, you are going to use this later, when you bind your certificate to a certain port 
```xml
<baseAddresses>
    <add baseAddress = "https://localhost:9977" />
</baseAddresses>
```
  - Change your default endpoints binding to wsHttpBinding, and name it something (like eg. SecureService)
```xml
 <endpoint address="SecureService" binding="wsHttpBinding" contract="ProjectName.IService1">
```
The next step is to configure the service it self, and the associated endpoint, so it supports the security you want.
  - Find the `<serviceBehaviors>` element, and modify the `<behavior>` element, and add a name to the behavior
  - Set httpGetEnabled="False" on the `<serviceMetaData>` element.
  - For debugging purposes, set includeExceptionDetailInFaults="False" on the `<serviceDebug>` element.
  - Add the `<serviceCredentials>` element (see the code snippet below)
    * In the `<serviceCertificate>` element, you configure how to find your new certificate on your machine.
    * x509FindType is the way WCF will search for the certificate, findValue is what it will search for, the storeName is the certificate store you are searching in, and the storeLocation is, well the location.
    * you need to set the findValue to the thumbprint of your certificate
    * you can find the thumbprint by typing `Get-ChildItem -path cert:\LocalMachine\My` into a PowerShell terminal
  
```xml
<serviceBehaviors>
    <behavior name="SecureBehavior">
        <serviceMetadata httpGetEnabled="False" httpsGetEnabled="True"/>
        <serviceDebug includeExceptionDetailInFaults="False" />
        <serviceCredentials>
            <serviceCertificate x509FindType="FindByThumbprint" findValue="c9c9366de42f8dc2875b8139fb17f8aba9f5ba66" storeName="My" storeLocation="LocalMachine"/>
        </serviceCredentials>
    </behavior>
</serviceBehaviors>
```
  - Go to the `<service name="ProjectName.Service1">` element, and add the property behaviorConfiguration, and set it to the serviceBehavior your just modified and named "SecureBehavior"
  ```xml
<service name="ProjectName.Service1" behaviorConfiguration="SecureBehavior">
  ```
