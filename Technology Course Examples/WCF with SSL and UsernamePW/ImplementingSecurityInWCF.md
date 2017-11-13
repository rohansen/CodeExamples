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
            <serviceCertificate x509FindType="FindByThumbprint" findValue="DD5A370484E791A6018CDE67A23968C29B2590CB" storeName="My" storeLocation="LocalMachine"/>
        </serviceCredentials>
    </behavior>
</serviceBehaviors>
```
  - Go to the `<service name="ProjectName.Service1">` element, and add the property behaviorConfiguration, and set it to the serviceBehavior your just modified and named "SecureBehavior"
  ```xml
<service name="ProjectName.Service1" behaviorConfiguration="SecureBehavior">
  ```
  - Next up is finishing the configuration, by adding some extra binding configuration.
  - Create a ```<bindings>``` tag in the root of ```<system.serviceModel>``` with the following contents:
```xml
<bindings>
    <wsHttpBinding>
        <binding name="SecureBindingHttps">
            <security mode="Transport">
                <transport clientCredentialType="None" />
            </security>
        </binding>
    </wsHttpBinding>
</bindings>
```
  - Go back to your ```<endpoint>``` and add the bindingConfiguration tag, so it points at your new configuration with the name  __"SecureBindingHttps"__. 
  Code snippet:
```xml
  <endpoint address="SecureService" binding="wsHttpBinding" contract="ProjectName.IService1"  bindingConfiguration="SecureBindingHttps" >
```
 
 Your ```<system.serviceModel>``` should look something like this:
 ```xml
<system.serviceModel>
  <services>
    <service name="ProjectName.Service1" behaviorConfiguration="SecureBehavior">
      <host>
        <baseAddresses>
          <add baseAddress = "https://localhost:9977" />
        </baseAddresses>
      </host>
      <endpoint address="SecureService" binding="wsHttpBinding" contract="ProjectName.IService1"  bindingConfiguration="SecureBindingHttps" >
        <identity>
          <dns value="localhost"/>
        </identity>
      </endpoint>
      <endpoint address="mex" binding="mexHttpsBinding" contract="IMetadataExchange"/>
    </service>
  </services>
  <behaviors>
    <serviceBehaviors>
      <behavior name="SecureBehavior">
        <serviceMetadata httpGetEnabled="false" httpsGetEnabled="True"/>
        <serviceDebug includeExceptionDetailInFaults="False" />
        <serviceCredentials>
          <serviceCertificate x509FindType="FindByThumbprint" findValue="DD5A370484E791A6018CDE67A23968C29B2590CB" storeName="My" storeLocation="LocalMachine"/>
        </serviceCredentials>
      </behavior>
    </serviceBehaviors>
  </behaviors>
  <bindings>
    <wsHttpBinding>
      <binding name="SecureBindingHttps">
        <security mode="Transport">
          <transport clientCredentialType="None" />
        </security>
      </binding>
    </wsHttpBinding>
  </bindings>
</system.serviceModel>
```

##Finally, you need to bind your X-509 certificate to the port you have specified in your ```<baseAddress>``` element.
  - Type the port you have used in your binding in the ipport=0.0.0.0:xxxx part of the command
  - Type the certificate thumbprint in the certhash=xxxx part of the command
  - Type the appid of your Console Host application. You can find this in your Visual studio project in the Properties section of your project in the AssemblyInfo.cs file.[(screenshot)](https://i.imgur.com/xZwhA8L.png)
```netsh http add sslcert ipport=0.0.0.0:9977 certhash=DD5A370484E791A6018CDE67A23968C29B2590CB appid='{f2c71a08-1f05-4bff-8c06-7f0e25177215}'``` [(documentation)](https://msdn.microsoft.com/en-us/library/windows/desktop/cc307220(v=vs.85).aspx)
