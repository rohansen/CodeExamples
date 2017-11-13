# Checking roles on your secure WCF service


  - Go to your ```<behavior name="SecureBehavior">``` element, and add the following
```xml
<serviceAuthorization principalPermissionMode="Custom" serviceAuthorizationManagerType="ProjectName.MyRoleManager,ProjectName" />
```
  - This will enable you to use a Custom principalPermissionMode (that allows role assignment), that we are going to implement in a while.
  - The ```serviceAuthorizationManagerType``` parameter, is referring to a class in your WCF Service project that handles the validation 
  - This class does not exist yet, but we are going to create it soon.
  - The value of this parameter ```"ProjectName.MyRoleManager, ProjectName"``` is referring the the Fully Qualified Class Name and the service ProjectName(AssemblyName)

  - In your service project, create a Class called ```MyRoleManager```
  - Let your class ```MyRoleManager``` inherit from the class ```ServiceAuthorizationManager```
  - Implement the method ```bool CheckAccessCore(OperationContext operationContext)```
  - Code snippet below:
```c#
protected override bool CheckAccessCore(OperationContext operationContext)
{
    //Get the current pipeline user context
    var identity = operationContext.ServiceSecurityContext.PrimaryIdentity;
    //simulate that we get a user and all his roles from the database
    bool? userFound = true;
    string[] userRolesFound = new string[] { "Admin" };
    if (userFound==null && userFound==false)
    {
        throw new Exception("User not found");
    }
    else
    {
        //Assign roles to the Principal property for runtime to match with PrincipalPermissionAttributes decorated on the service operation.
        var principal = new GenericPrincipal(operationContext.ServiceSecurityContext.PrimaryIdentity, userRolesFound);
        //assign principal to auth context with the users roles
        operationContext.ServiceSecurityContext.AuthorizationContext.Properties["Principal"] = principal;
        //return true if all goes well
        return true;
    }
}
```
### You have now hooked up roles in your system. 
To apply these roles to your method calls (on our operation contracts), you can annotate your implemented OperationContracts in your service with
```c#
[PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
```
### Test out your application once again. 
### Try and see what happens if you assign the user a role that is different from the PrincipalPermission

### You now have username and password validation, role authorization and an encrypted connection to your web service

## This concludes part 2 of the WCF security tutorial

