# Implementing UserNamePassword validation on your WCF Service (Part 2)
  - Go to your ```<serviceCredentials>``` element, and add the following
```xml
<userNameAuthentication userNamePasswordValidationMode="Custom" customUserNamePasswordValidatorType="MyPasswordValidator, ProjectName" />
```
  - This will enable you to use a Custom userNamePasswordValidator, that we are going to implement in a while.
  - The ```customUserNamePasswordValidatorType``` parameter, is referring to a class in your WCF Service project that handles the validation 
  - This class does not exist yet, but we are going to create it soon.
  - The value of this parameter ```"ProjectName.CredentialValidator, ProjectName"``` is referring the the Fully Qualified Class Name and the service ProjectName(AssemblyName)

  - Find your <bindings> in your Console Hosting application, and add the ```<message clientCredentialType="UserName" />``` element
  - In your ```<security mode="Transport">```, change the mode to ```TransportWithMessageCredential```
  - This will force your clients to provide at username and password before they are allowed to call the service
```xml
<bindings>
  <wsHttpBinding>
    <binding name="SecureBindingHttps">
      <security mode="TransportWithMessageCredential">
        <message clientCredentialType="UserName" />
        <transport clientCredentialType="None" />
      </security>
    </binding>
  </wsHttpBinding>
</bindings>
```
  - In your service project, create a Class called ```MyPasswordValidator```
  - Add a reference to the assembly ```System.IdentityModel``` in your WCF Service project
  - Let you class ```MyPasswordValidator``` inherit from the abstract class ```UserNamePasswordValidator```
  - Implement the abstract method ```void Validate(string userName, string password)```
  - Code snippet below:
```c#
public class MyPasswordValidator : UserNamePasswordValidator
{
    public override void Validate(string userName, string password)
    {
        //Call a method in your application that tries to retrieve a user with the given credentials.
        //If the user is found, and the password is valid, do nothing
        //If the user is not found, or the credentials are incorrect, throw and exception(eg. FaultException)
        //This example simply checks hardcoded values
        if(userName=="SuperStudent" && password == "1234")
        {

        }else
        {
            throw new FaultException<Exception>(new Exception("Incorrect Login"), "Invalid login attempt");
        }
    }
}  
```
### Run the Service Host Application again, and update the service reference in your Service Client Project. Then run the client at notice what happens.

You get an exception, because no credentials was passed with the service request.

### To pass username and password from the client, to the server, open your Console Clients Program.cs, and code to provide these.
```c#
static void Main(string[] args)
{
    ServicePointManager.ServerCertificateValidationCallback = (obj, certificate, chain, errors) => true;
    Service1Client cl = new Service1Client();
    //The following two lines of code are used to pass credentials to the service
    cl.ClientCredentials.UserName.UserName = "SuperStudent";
    cl.ClientCredentials.UserName.Password = "1234";
    var data =cl.GetData(123);
    Console.WriteLine(data);
    Console.ReadLine();
}
```

### Test out your client once again.

### You now have username and password validation and an encrypted connection to your web service

## This concludes part 2 of the WCF security tutorial

