# Net7JwtAuthentication

implementing  authentication and authorization in ASP.NET Core by using Identity and JWT

I will try to teach step by step how to set up implementing authentication and authorization 
1.	Install below  packages using Nuget 
2.	Explanation about  jwt and identity
3.	Settings class  (jwt,identity)
4.	Add Configuration  jwt and identity
5.	its implementation 
6.	implementation login and register 

## JWT: 
JSON Web Token (JWT) is an open standard (RFC 7519) that defines a compact and self-contained way for securely transmitting information between parties as a JSON object.
## Identity : 
ASP.NET Core Identity is a membership system which allows you to add login functionality to your application.used to implement forms authentication


|Package|	Description|	Category|
|-------|------------|----------|
|Microsoft.AspNetCore.Authentication.JwtBearer|Contains types that enable support for JWT bearer based authentication.|Jwt|
|System.IdentityModel.Tokens.Jwt|Includes types that provide support for creating, serializing and validating JSON Web Tokens.|Jwt|
|Microsoft.AspNetCore.Identity.EntityFrameworkCore|Provides types for persisting Identity data with Entity Framework Core.|Identity|


## add Configuration Jwt in appsettings.json 
```
"Jwt": {
    "Key": "",
    "Issuer": "”
    "Audience": "",
    "Subject": ""
  }  
```
## Add Configuration base to  startup
```
app.UseAuthentication();
app.UseAuthorization();
```
## add Configuration  Identity to startup
```
 //Add the default identity system configuration for the specified User and Role types.
services.AddIdentity< ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<Context>()
                .AddDefaultTokenProviders();
//Add ContextConnection in  startup
services.AddDbContext<Context>(options => {
  options.UseSqlServer(Configuration.GetConnectionString("ContextConnection"));});
```
## Add Authentication(Authentication schemes are specified by registering authentication services) to startup(The config is in the following Code)
https://github.com/abolfazlSadeqi/Net7JwtAuthentication/blob/master/Common/Common/UI/Method/HelperAuthentication.cs

## Add Configure related an authorization header to your AddSwaggerGen (The config is in the following Code)
https://github.com/abolfazlSadeqi/Net7JwtAuthentication/blob/master/Common/Common/UI/Method/HelperSwagger.cs

## add Configure SecurityToken jwt(The config is in the following Code)
https://github.com/abolfazlSadeqi/Net7JwtAuthentication/blob/master/Common/Common/UI/Jwt/HelperJwt.cs

## Implementation register or login Action(It uses identity base classes (UserManager<ApplicationUser>)  )
https://github.com/abolfazlSadeqi/Net7JwtAuthentication/blob/master/UI/API/Controller/Users/UserJwtController.cs

## add attribute Authorize in Controller or Action for check access and Role
```
  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
```
### for testing with swagger. Click Authorize and enter token

		

