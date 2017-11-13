# Implementing UserNamePassword validation on your WCF Service (Part 2)
  - Go to your ```<serviceCredentials>``` element, and add the following
```
<userNameAuthentication userNamePasswordValidationMode="Custom" customUserNamePasswordValidatorType="CredentialValidator, ProjectName" />
```
  - This will enable you to use a Custom userNamePasswordValidator, that we are going to implement in a while.
  - The ```customUserNamePasswordValidatorType``` parameter, is referring to a class in your WCF Service project that handles the validation 
  - This class does not exist yet, but we are going to create it soon.
  - The value of this parameter ```"CredentialValidator, ProjectName"``` is referring the the Class name and the ProjectName(AssemblyName)

  - Find your <bindings> in your Console Hosting application, and add the ```<message clientCredentialType="UserName" />``` element
  - This will force your clients to provide at username and password before they are allowed to call the service
```xml
<bindings>
  <wsHttpBinding>
    <binding name="SecureBindingHttps">
      <security mode="Transport">
        <message clientCredentialType="UserName" />
        <transport clientCredentialType="None" />
      </security>
    </binding>
  </wsHttpBinding>
</bindings>
```
