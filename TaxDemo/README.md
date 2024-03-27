![Patricks GitHub stats](index.html)

<a width=150 href="https://hub.docker.com/repository/docker/pgourdet/auth">![DockerRepo](https://raisingcodeblog.com/wp-content/uploads/2019/03/whale-from-docker-logo-small-min.png)<h1>Tax Api Docker Container</h1></a>


# The tax calculated may not be accurate as it uses the combined tax and does not have access to the nexus 
### Possibly could build a database with all the state to state regulations to create the Nexus lookup table.
### Documentation has indexed for lookup should a need arise...
# Auth
![Patricks GitHub stats](https://github-readme-stats.vercel.app/api?username=patrick-gourdet&count_private=true)
## This docker container has unit tests as well as API interaction using swagger, data storage is handled using Encrypted SQLite
<img src="./Auth/TaxDemo.png"/>
# The Service contains user authentication authenticated API key, SQLite DB insert, and Calculation calls
# as well as other features

[![Build Status](https://img.shields.io/badge/Development-build-green)](https://fedigital.org)</br>

## To run project clone then open in Visual Studios 
## Download and install Docker-Desktop
## Execute in VisualStudios Using the docker file

## Troubleshoot: Delete Docker file and right-click project add Docker Support

# Test Calculation Method 
## Step 1: Register user using swagger
## Step 2: Save API Key using the credentials created in step 1
## Step 3: Make a call to API entering amount and ZIP code

## Test Tax rates endpoint will return the values for given zip code
## Enter password and the user 
## The Endpoint right above in swagger is geared towards more complicated queries, but the API key does not allow thus is not tested

# Using Unit tests, they are located together with the project on the test branch
## Run API Docker container 
## Must alter the user then run the test
## Then add a user to unit test 3
## all expected values should return 201 or 200

## Contents

# DataBase Context Elements
- [ApiDbContext](#T-Auth-DataAccess-ApiDbContext 'TaxDemo.DataAccess.ApiDbContext')
  - [#ctor(context)](#M-Auth-DataAccess-ApiDbContext-#ctor-Auth-DataAccess-DataContextApi- 'TaxDemo.DataAccess.ApiDbContext.#ctor(TaxDemo.DataAccess.DataContextApi)')
  - [GetApiKey(apiName,compareHash)](#M-Auth-DataAccess-ApiDbContext-GetApiKey-System-String,System-Byte[]- 'TaxDemo.DataAccess.ApiDbContext.GetApiKey(System.String,System.Byte[])')
  - [SaveChanges(apiName,apiKeyToSave,compareHash)](#M-Auth-DataAccess-ApiDbContext-SaveChanges-Auth-Model-ApiDbItem- 'TaxDemo.DataAccess.ApiDbContext.SaveChanges(TaxDemo.Model.ApiDbItem)')
- [DataContextCalc](#T-Auth-DataAccess-DataContextCalc 'TaxDemo.DataAccess.DataContextCalc')
- [DataContextTax](#T-Auth-DataAccess-DataContextTax 'TaxDemo.DataAccess.DataContextTax') 
- [TaxServiceDbContext](#T-Auth-DataAccess-TaxServiceDbContext 'TaxDemo.DataAccess.TaxServiceDbContext')
  - [Correction(id)](#M-Auth-DataAccess-TaxServiceDbContext-Correction-System-String- 'TaxDemo.DataAccess.TaxServiceDbContext.Correction(System.String)')
  - [GetTaxItem()](#M-Auth-DataAccess-TaxServiceDbContext-GetTaxItem 'TaxDemo.DataAccess.TaxServiceDbContext.GetTaxItem')
  - [GetTaxItems()](#M-Auth-DataAccess-TaxServiceDbContext-GetTaxItems 'TaxDemo.DataAccess.TaxServiceDbContext.GetTaxItems')
  - [SaveChanges()](#M-Auth-DataAccess-TaxServiceDbContext-SaveChanges-Auth-Model-Rates- 'TaxDemo.DataAccess.TaxServiceDbContext.SaveChanges(TaxDemo.Model.Rates)')
 
# Authorization Levels Variable
### Auth Level is a row of prime numbers 
-[AuthLevel](#T-Auth-Model-AuthLevel 'TaxDemo.Model.AuthLevel')

# Controller Documentation 
-[AuthContext](#T-Auth-DataAccess-AuthContext 'TaxDemo.DataAccess.AuthContext')
  - [GetUserHash(username)](#M-Auth-DataAccess-AuthContext-GetUserHash-System-String,System-String- 'TaxDemo.DataAccess.AuthContext.GetUserHash(System.String,System.String)')
  - [Register(user,password)](#M-Auth-DataAccess-AuthContext-Register-Auth-Model-AuthModel,System-String- 'TaxDemo.DataAccess.AuthContext.Register(TaxDemo.Model.AuthModel,System.String)')
  - [Update(userToUpdate,username,password)](#M-Auth-DataAccess-AuthContext-Update-Auth-Model-AuthModel,System-String,System-String- 'TaxDemo.DataAccess.AuthContext.Update(TaxDemo.Model.AuthModel,System.String,System.String)')
  - [UserExists(username)](#M-Auth-DataAccess-AuthContext-UserExists-System-String- 'TaxDemo.DataAccess.AuthContext.UserExists(System.String)')
- [AuthController](#T-Auth-Controllers-AuthController 'TaxDemo.Controllers.AuthController')
  - [#ctor(repo,config,logger)](#M-Auth-Controllers-AuthController-#ctor-Auth-DataAccess-IAuthContext,Auth-DataAccess-IApiDbContext,Microsoft-Extensions-Configuration-IConfiguration,Microsoft-Extensions-Logging-ILogger{Auth-Controllers-AuthController}- 'TaxDemo.Controllers.AuthController.#ctor(TaxDemo.DataAccess.IAuthContext,TaxDemo.DataAccess.IApiDbContext,Microsoft.Extensions.Configuration.IConfiguration,Microsoft.Extensions.Logging.ILogger{TaxDemo.Controllers.AuthController})')
  - [Login(user)](#M-Auth-Controllers-AuthController-Login-Auth-Model-AuthRegisterDto- 'TaxDemo.Controllers.AuthController.Login(TaxDemo.Model.AuthRegisterDto)')
  - [Register(newUser)](#M-Auth-Controllers-AuthController-Register-Auth-Model-AuthRegisterDto- 'TaxDemo.Controllers.AuthController.Register(TaxDemo.Model.AuthRegisterDto)')
  - [SaveApi(apikey,apiName,authorized)](#M-Auth-Controllers-AuthController-SaveApi-System-String,System-String,System-String,System-String- 'TaxDemo.Controllers.AuthController.SaveApi(System.String,System.String,System.String,System.String)')
  - [UserExists(user)](#M-Auth-Controllers-AuthController-UserExists-Auth-Model-AuthRegisterDto- 'TaxDemo.Controllers.AuthController.UserExists(TaxDemo.Model.AuthRegisterDto)')
 [TaxRatesController](#T-Auth-Controllers-TaxRatesController 'TaxDemo.Controllers.TaxRatesController')
  - [#ctor(t)](#M-Auth-Controllers-TaxRatesController-#ctor-Auth-DataAccess-IAuthContext,Auth-ApiDataAccess-ITaxRates,Auth-DataAccess-ITaxServiceDbContext,Auth-DataAccess-IApiDbContext,Microsoft-Extensions-Logging-ILogger{Auth-Controllers-TaxRatesController}- 'TaxDemo.Controllers.TaxRatesController.#ctor(TaxDemo.DataAccess.IAuthContext,TaxDemo.ApiDataAccess.ITaxRates,TaxDemo.DataAccess.ITaxServiceDbContext,TaxDemo.DataAccess.IApiDbContext,Microsoft.Extensions.Logging.ILogger{TaxDemo.Controllers.TaxRatesController})')
  - [GetTaxInfo(query,apiName,authorized)](#M-Auth-Controllers-TaxRatesController-GetTaxInfo-System-String,System-String,System-String,System-String- 'TaxDemo.Controllers.TaxRatesController.GetTaxInfo(System.String,System.String,System.String,System.String)')

# Models  
[ApiDbItem](#T-Auth-Model-ApiDbItem 'TaxDemo.Model.ApiDbItem')
- [AuthModel](#T-Auth-Model-AuthModel 'TaxDemo.Model.AuthModel')
- [AuthRegisterDto](#T-Auth-Model-AuthRegisterDto 'TaxDemo.Model.AuthRegisterDto')
- [CalcRates](#T-Auth-ApiDataAccess-CalcRates 'TaxDemo.ApiDataAccess.CalcRates')
  - [#ctor(contex)](#M-Auth-ApiDataAccess-CalcRates-#ctor-Auth-DataAccess-DataContextApi- 'TaxDemo.ApiDataAccess.CalcRates.#ctor(TaxDemo.DataAccess.DataContextApi)')
  - [GetOrderTaxRate()](#M-Auth-ApiDataAccess-CalcRates-GetOrderTaxRate-System-String,System-String,System-Byte[]- 'TaxDemo.ApiDataAccess.CalcRates.GetOrderTaxRate(System.String,System.String,System.Byte[])')
- [Calculate](#T-Auth-Business-Calculate 'TaxDemo.Business.Calculate')
- [CalculationsController](#T-Auth-Controllers-CalculationsController 'TaxDemo.Controllers.CalculationsController')
  - [#ctor(t)](#M-Auth-Controllers-CalculationsController-#ctor-Auth-DataAccess-IAuthContext,Auth-ApiDataAccess-ICalcRates,Auth-DataAccess-ICalculateDbContext,Microsoft-Extensions-Logging-ILogger{Auth-Controllers-CalculationsController},Auth-Business-ICalculate- 'TaxDemo.Controllers.CalculationsController.#ctor(TaxDemo.DataAccess.IAuthContext,TaxDemo.ApiDataAccess.ICalcRates,TaxDemo.DataAccess.ICalculateDbContext,Microsoft.Extensions.Logging.ILogger{TaxDemo.Controllers.CalculationsController},TaxDemo.Business.ICalculate)')
- [CalculatorDbContext](#T-Auth-DataAccess-CalculatorDbContext 'TaxDemo.DataAccess.CalculatorDbContext')
  - [#ctor(context)](#M-Auth-DataAccess-CalculatorDbContext-#ctor-Auth-DataAccess-DataContextCalc- 'TaxDemo.DataAccess.CalculatorDbContext.#ctor(TaxDemo.DataAccess.DataContextCalc)')
  - [Rates](#T-Auth-Model-Rates 'TaxDemo.Model.Rates')
- [SummayRates](#T-Auth-Model-SummayRates 'TaxDemo.Model.SummayRates')
- [TaxCalculationItemEvent](#T-Auth-Model-TaxCalculationItemEvent 'TaxDemo.Model.TaxCalculationItemEvent')
- [TaxItemEvent](#T-Auth-Model-TaxItemEvent 'TaxDemo.Model.TaxItemEvent')
- [TaxRates](#T-Auth-ApiDataAccess-TaxRates 'TaxDemo.ApiDataAccess.TaxRates')
  - [#ctor(dbContext)](#M-Auth-ApiDataAccess-TaxRates-#ctor-Auth-DataAccess-DataContextApi,Auth-DataAccess-DataContextTax- 'TaxDemo.ApiDataAccess.TaxRates.#ctor(TaxDemo.DataAccess.DataContextApi,TaxDemo.DataAccess.DataContextTax)')
  - [GetOrderTaxRate()](#M-Auth-ApiDataAccess-TaxRates-GetOrderTaxRate-System-String,System-String,System-Byte[]- 'TaxDemo.ApiDataAccess.TaxRates.GetOrderTaxRate(System.String,System.String,System.Byte[])')
  - [GetTaxInfo(action)](#M-Auth-ApiDataAccess-TaxRates-GetTaxInfo-Auth-Model-Rates- 'TaxDemo.ApiDataAccess.TaxRates.GetTaxInfo(TaxDemo.Model.Rates)')
  - [rate](#T-Auth-Model-rate 'TaxDemo.Model.rate')

# Helper Methods
- [HttpClientSingleton](#T-TaxJar-Microservice-DataAccess-ApiHelper-HttpClientSingleton 'TaxJar.Microservice.DataAccess.ApiHelper.HttpClientSingleton')
  - [TaxClient](#P-TaxJar-Microservice-DataAccess-ApiHelper-HttpClientSingleton-TaxClient 'TaxJar.Microservice.DataAccess.ApiHelper.HttpClientSingleton.TaxClient')
  - [Dispose()](#M-TaxJar-Microservice-DataAccess-ApiHelper-HttpClientSingleton-Dispose 'TaxJar.Microservice.DataAccess.ApiHelper.HttpClientSingleton.Dispose')
  - [Dispose(disposing)](#M-TaxJar-Microservice-DataAccess-ApiHelper-HttpClientSingleton-Dispose-System-Boolean- 'TaxJar.Microservice.DataAccess.ApiHelper.HttpClientSingleton.Dispose(System.Boolean)')
  - [GetScoketHandler()](#M-TaxJar-Microservice-DataAccess-ApiHelper-HttpClientSingleton-GetScoketHandler 'TaxJar.Microservice.DataAccess.ApiHelper.HttpClientSingleton.GetScoketHandler')
  - [RemoveHeaders(headers)](#M-TaxJar-Microservice-DataAccess-ApiHelper-HttpClientSingleton-RemoveHeaders-System-Collections-Generic-Dictionary{System-String,System-String}- 'TaxJar.Microservice.DataAccess.ApiHelper.HttpClientSingleton.RemoveHeaders(System.Collections.Generic.Dictionary{System.String,System.String})')
  - [RemoveHeaders(apiKeyTitle,apiKey,apiSecretTitle,apiSecret)](#M-TaxJar-Microservice-DataAccess-ApiHelper-HttpClientSingleton-RemoveHeaders-System-String,System-String,System-String,System-String- 'TaxJar.Microservice.DataAccess.ApiHelper.HttpClientSingleton.RemoveHeaders(System.String,System.String,System.String,System.String)')
  - [RemoveHeaders(apiKeyTitle,apiKey)](#M-TaxJar-Microservice-DataAccess-ApiHelper-HttpClientSingleton-RemoveHeaders-System-String,System-String- 'TaxJar.Microservice.DataAccess.ApiHelper.HttpClientSingleton.RemoveHeaders(System.String,System.String)')
  - [RemoveHeadersAccept(apiKey)](#M-TaxJar-Microservice-DataAccess-ApiHelper-HttpClientSingleton-RemoveHeadersAccept-System-String- 'TaxJar.Microservice.DataAccess.ApiHelper.HttpClientSingleton.RemoveHeadersAccept(System.String)')
  - [SetHeaders(apiKeyTitle,internalKey,apiSecretTitle,apiSecret)](#M-TaxJar-Microservice-DataAccess-ApiHelper-HttpClientSingleton-SetHeaders-System-String,System-String,System-String,System-String- 'TaxJar.Microservice.DataAccess.ApiHelper.HttpClientSingleton.SetHeaders(System.String,System.String,System.String,System.String)')
  - [SetHeaders(apiKeyTitle,internalKey)](#M-TaxJar-Microservice-DataAccess-ApiHelper-HttpClientSingleton-SetHeaders-System-String,System-String- 'TaxJar.Microservice.DataAccess.ApiHelper.HttpClientSingleton.SetHeaders(System.String,System.String)')
  - [SetHeaders(headers)](#M-TaxJar-Microservice-DataAccess-ApiHelper-HttpClientSingleton-SetHeaders-System-Collections-Generic-Dictionary{System-String,System-String}- 'TaxJar.Microservice.DataAccess.ApiHelper.HttpClientSingleton.SetHeaders(System.Collections.Generic.Dictionary{System.String,System.String})')
  - [SetHeadersAccept(key)](#M-TaxJar-Microservice-DataAccess-ApiHelper-HttpClientSingleton-SetHeadersAccept-System-String- 'TaxJar.Microservice.DataAccess.ApiHelper.HttpClientSingleton.SetHeadersAccept(System.String)')

# Extension Classes
- [HttpResponceExtention](#T-Auth-Extention-HttpResponceExtention 'TaxDemo.Extention.HttpResponceExtention')

# Interfaces
- [IApiDbContext](#T-Auth-DataAccess-IApiDbContext 'TaxDemo.DataAccess.IApiDbContext')
  - [GetApiKey(apiName,compareHash)](#M-Auth-DataAccess-IApiDbContext-GetApiKey-System-String,System-Byte[]- 'TaxDemo.DataAccess.IApiDbContext.GetApiKey(System.String,System.Byte[])')
  - [SaveChanges(item)](#M-Auth-DataAccess-IApiDbContext-SaveChanges-Auth-Model-ApiDbItem- 'TaxDemo.DataAccess.IApiDbContext.SaveChanges(TaxDemo.Model.ApiDbItem)')
- [IAuthContext](#T-Auth-DataAccess-IAuthContext 'TaxDemo.DataAccess.IAuthContext')
  - [GetUserHash(username,password)](#M-Auth-DataAccess-IAuthContext-GetUserHash-System-String,System-String- 'TaxDemo.DataAccess.IAuthContext.GetUserHash(System.String,System.String)')
  - [Login(user,password)](#M-Auth-DataAccess-IAuthContext-Login-System-String,System-String- 'TaxDemo.DataAccess.IAuthContext.Login(System.String,System.String)')
  - [Register(username,password,address1,address2,city,zip)](#M-Auth-DataAccess-IAuthContext-Register-Auth-Model-AuthModel,System-String- 'TaxDemo.DataAccess.IAuthContext.Register(TaxDemo.Model.AuthModel,System.String)')
  - [UserExists(username)](#M-Auth-DataAccess-IAuthContext-UserExists-System-String- 'TaxDemo.DataAccess.IAuthContext.UserExists(System.String)')
- [IBaseDbContext](#T-Auth-DataAccess-IBaseDbContext 'TaxDemo.DataAccess.IBaseDbContext')
  - [SaveChanges(item)](#M-Auth-DataAccess-IBaseDbContext-SaveChanges-Auth-Model-TaxCalculationItemEvent- 'TaxDemo.DataAccess.IBaseDbContext.SaveChanges(TaxDemo.Model.TaxCalculationItemEvent)')
- [ICalcRates](#T-Auth-ApiDataAccess-ICalcRates 'TaxDemo.ApiDataAccess.ICalcRates')
- [ICalculate](#T-Auth-Business-ICalculate 'TaxDemo.Business.ICalculate')
- [ICalculateDbContext](#T-Auth-DataAccess-ICalculateDbContext 'TaxDemo.DataAccess.ICalculateDbContext')
- [ITaxRates](#T-Auth-ApiDataAccess-ITaxRates 'TaxDemo.ApiDataAccess.ITaxRates')
  - [GetOrderTaxRate(query,apiName,userHash)](#M-Auth-ApiDataAccess-ITaxRates-GetOrderTaxRate-System-String,System-String,System-Byte[]- 'TaxDemo.ApiDataAccess.ITaxRates.GetOrderTaxRate(System.String,System.String,System.Byte[])')
- [ITaxServiceDbContext](#T-Auth-DataAccess-ITaxServiceDbContext 'TaxDemo.DataAccess.ITaxServiceDbContext')
- [ITax](#T-Auth-ApiDataAccess-ITax`1 'TaxDemo.ApiDataAccess.ITax`1')


<a name='T-Auth-DataAccess-ApiDbContext'></a>
## ApiDbContext `type`

##### Namespace

TaxDemo.DataAccess

##### Summary

Api Database Access to obtain the API key using authenticated user
This maps the user to each API key which the user is authorized to use

<a name='M-Auth-DataAccess-ApiDbContext-#ctor-Auth-DataAccess-DataContextApi-'></a>
### #ctor(context) `constructor`

##### Summary

Inject context this is how the base implementation should be through the
application as to abstract the access to Database

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [TaxDemo.DataAccess.DataContextApi](#T-Auth-DataAccess-DataContextApi 'TaxDemo.DataAccess.DataContextApi') |  |

<a name='M-Auth-DataAccess-ApiDbContext-GetApiKey-System-String,System-Byte[]-'></a>
### GetApiKey(apiName,compareHash) `method`

##### Summary

With Hash To compare to retrieve the relevant Api Key

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| apiName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| compareHash | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') |  |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.UnauthorizedAccessException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.UnauthorizedAccessException 'System.UnauthorizedAccessException') |  |

<a name='M-Auth-DataAccess-ApiDbContext-SaveChanges-Auth-Model-ApiDbItem-'></a>
### SaveChanges(apiName,apiKeyToSave,compareHash) `method`

##### Summary

Using the user password hash map the API key to the user in question
TODO this needs a maintainer service to assure when passwords are changed or user leave that the mappings are updated

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| apiName | [TaxDemo.Model.ApiDbItem](#T-Auth-Model-ApiDbItem 'TaxDemo.Model.ApiDbItem') |  |

<a name='T-Auth-Model-ApiDbItem'></a>
## ApiDbItem `type`

##### Namespace

TaxDemo.Model

##### Summary

Base APi DB element for data interactions

<a name='T-Auth-DataAccess-AuthContext'></a>
## AuthContext `type`

##### Namespace

TaxDemo.DataAccess

<a name='M-Auth-DataAccess-AuthContext-GetUserHash-System-String,System-String-'></a>
### GetUserHash(username) `method`

##### Summary

Get User Hash for api key authorization.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| username | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Auth-DataAccess-AuthContext-Register-Auth-Model-AuthModel,System-String-'></a>
### Register(user,password) `method`

##### Summary



##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| user | [TaxDemo.Model.AuthModel](#T-Auth-Model-AuthModel 'TaxDemo.Model.AuthModel') |  |
| password | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Auth-DataAccess-AuthContext-Update-Auth-Model-AuthModel,System-String,System-String-'></a>
### Update(userToUpdate,username,password) `method`

##### Summary

TODO still need proper thought

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| userToUpdate | [TaxDemo.Model.AuthModel](#T-Auth-Model-AuthModel 'TaxDemo.Model.AuthModel') |  |
| username | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| password | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Auth-DataAccess-AuthContext-UserExists-System-String-'></a>
### UserExists(username) `method`

##### Summary

Find if the user is in Database.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| username | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='T-Auth-Controllers-AuthController'></a>
## AuthController `type`

##### Namespace

TaxDemo.Controllers

##### Summary

Authentication API Access for a Gateway authentication method

<a name='M-Auth-Controllers-AuthController-#ctor-Auth-DataAccess-IAuthContext,Auth-DataAccess-IApiDbContext,Microsoft-Extensions-Configuration-IConfiguration,Microsoft-Extensions-Logging-ILogger{Auth-Controllers-AuthController}-'></a>
### #ctor(repo,config,logger) `constructor`

##### Summary

Constructor using IoC for logging the repo tied to the Auth methods 
and configuration methods from start

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| repo | [TaxDemo.DataAccess.IAuthContext](#T-Auth-DataAccess-IAuthContext 'TaxDemo.DataAccess.IAuthContext') |  |
| config | [TaxDemo.DataAccess.IApiDbContext](#T-Auth-DataAccess-IApiDbContext 'TaxDemo.DataAccess.IApiDbContext') |  |
| logger | [Microsoft.Extensions.Configuration.IConfiguration](#T-Microsoft-Extensions-Configuration-IConfiguration 'Microsoft.Extensions.Configuration.IConfiguration') |  |

<a name='M-Auth-Controllers-AuthController-Login-Auth-Model-AuthRegisterDto-'></a>
### Login(user) `method`

##### Summary

Standard login method using jwt tokens

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| user | [TaxDemo.Model.AuthRegisterDto](#T-Auth-Model-AuthRegisterDto 'TaxDemo.Model.AuthRegisterDto') |  |

<a name='M-Auth-Controllers-AuthController-Register-Auth-Model-AuthRegisterDto-'></a>
### Register(newUser) `method`

##### Summary

Registration method

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| newUser | [TaxDemo.Model.AuthRegisterDto](#T-Auth-Model-AuthRegisterDto 'TaxDemo.Model.AuthRegisterDto') |  |

<a name='M-Auth-Controllers-AuthController-SaveApi-System-String,System-String,System-String,System-String-'></a>
### SaveApi(apikey,apiName,authorized) `method`

##### Summary

Add API Key To the API keys for a specific user
eliminating the authorization as the assigning of API keys
will be the authorization

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| apikey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| apiName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| authorized | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Auth-Controllers-AuthController-UserExists-Auth-Model-AuthRegisterDto-'></a>
### UserExists(user) `method`

##### Summary

To see if a user exists before attempting the authorization process
providing a layer of abstraction for brute force attacks

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| user | [TaxDemo.Model.AuthRegisterDto](#T-Auth-Model-AuthRegisterDto 'TaxDemo.Model.AuthRegisterDto') |  |

<a name='T-Auth-Model-AuthLevel'></a>
## AuthLevel `type`

##### Namespace

TaxDemo.Model

##### Summary

This is the authorization levels Enumeration for an employee
the Level determines the privileges; They are all prime numbers thus can be used in combinations. If the hybrids are pairs, we need to add 1 to obtain a unique value specific to the authorization level. In odd combinations, the resulting number is also prime, thus requires no further manipulation.

<a name='T-Auth-Model-AuthModel'></a>
## AuthModel `type`

##### Namespace

TaxDemo.Model

##### Summary

Primary authentication model to find authorization levels
to register users or login

<a name='T-Auth-Model-AuthRegisterDto'></a>
## AuthRegisterDto `type`

##### Namespace

TaxDemo.Model

##### Summary

Smaller dto as to not expose the hash fields to a user

<a name='T-Auth-ApiDataAccess-CalcRates'></a>
## CalcRates `type`

##### Namespace

TaxDemo.ApiDataAccess

##### Summary

Primary calculation method for all tax calculations

<a name='M-Auth-ApiDataAccess-CalcRates-#ctor-Auth-DataAccess-DataContextApi-'></a>
### #ctor(contex) `constructor`

##### Summary

Concrete implementation of the interface, which also uses the API access for authorization

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| contex | [TaxDemo.DataAccess.DataContextApi](#T-Auth-DataAccess-DataContextApi 'TaxDemo.DataAccess.DataContextApi') |  |

<a name='M-Auth-ApiDataAccess-CalcRates-GetOrderTaxRate-System-String,System-String,System-Byte[]-'></a>
### GetOrderTaxRate() `method`

##### Summary

*Inherit from the parent.*

##### Parameters

This method has no parameters.

<a name='T-Auth-Business-Calculate'></a>
## Calculate `type`

##### Namespace

TaxDemo.Business

##### Summary

Calculate the tax for a given API call to taxjar using the combined tax rate

<a name='T-Auth-Controllers-CalculationsController'></a>
## CalculationsController `type`

##### Namespace

TaxDemo.Controllers

##### Summary

Calculator controller
gives access to the calculated DB
and the function to calculate the rates for an order

<a name='M-Auth-Controllers-CalculationsController-#ctor-Auth-DataAccess-IAuthContext,Auth-ApiDataAccess-ICalcRates,Auth-DataAccess-ICalculateDbContext,Microsoft-Extensions-Logging-ILogger{Auth-Controllers-CalculationsController},Auth-Business-ICalculate-'></a>
### #ctor(t) `constructor`

##### Summary

Access To the TaxJar API

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| t | [TaxDemo.DataAccess.IAuthContext](#T-Auth-DataAccess-IAuthContext 'TaxDemo.DataAccess.IAuthContext') |  |

<a name='T-Auth-DataAccess-CalculatorDbContext'></a>
## CalculatorDbContext `type`

##### Namespace

TaxDemo.DataAccess

##### Summary

Calculation Db access
the data from tax rates can be accessed either DB or API

<a name='M-Auth-DataAccess-CalculatorDbContext-#ctor-Auth-DataAccess-DataContextCalc-'></a>
### #ctor(context) `constructor`

##### Summary

Injecting the shared DB context into the controller
TODO Abstract DB from controller in a separate class

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [TaxDemo.DataAccess.DataContextCalc](#T-Auth-DataAccess-DataContextCalc 'TaxDemo.DataAccess.DataContextCalc') |  |

<a name='T-Auth-DataAccess-DataContextCalc'></a>
## DataContextCalc `type`

##### Namespace

TaxDemo.DataAccess

##### Summary

Calculator Interface implements Save To Sqlite DB.

<a name='T-Auth-DataAccess-DataContextTax'></a>
## DataContextTax `type`

##### Namespace

TaxDemo.DataAccess

##### Summary

This is the TaxJar interaction interface
this will have the main functionality when interacting with the Tax APIs

<a name='T-TaxJar-Microservice-DataAccess-ApiHelper-HttpClientSingleton'></a>
## HttpClientSingleton `type`

##### Namespace

TaxJar.Microservice.DataAccess.ApiHelper

##### Summary

Http Singleton class

<a name='P-TaxJar-Microservice-DataAccess-ApiHelper-HttpClientSingleton-TaxClient'></a>
### TaxClient `property`

##### Summary

Public accessor for the HttpClient

<a name='M-TaxJar-Microservice-DataAccess-ApiHelper-HttpClientSingleton-Dispose'></a>
### Dispose() `method`

##### Summary

dispose of the method for the Socket handler method

##### Parameters

This method has no parameters.

<a name='M-TaxJar-Microservice-DataAccess-ApiHelper-HttpClientSingleton-Dispose-System-Boolean-'></a>
### Dispose(disposing) `method`

##### Summary

Dispose of the method  if there is an error or memory issues

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| disposing | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') |  |

<a name='M-TaxJar-Microservice-DataAccess-ApiHelper-HttpClientSingleton-GetScoketHandler'></a>
### GetScoketHandler() `method`

##### Summary

handle socket pooling and timeouts

##### Returns



##### Parameters

This method has no parameters.

<a name='M-TaxJar-Microservice-DataAccess-ApiHelper-HttpClientSingleton-RemoveHeaders-System-Collections-Generic-Dictionary{System-String,System-String}-'></a>
### RemoveHeaders(headers) `method`

##### Summary

Remove the header needed for authentication calls. This is mainly for security reasons.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| headers | [System.Collections.Generic.Dictionary{System.String,System.String}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.Dictionary 'System.Collections.Generic.Dictionary{System.String,System.String}') |  |

<a name='M-TaxJar-Microservice-DataAccess-ApiHelper-HttpClientSingleton-RemoveHeaders-System-String,System-String,System-String,System-String-'></a>
### RemoveHeaders(apiKeyTitle,apiKey,apiSecretTitle,apiSecret) `method`

##### Summary

Remove the header function override to accommodate the same format as the set header function set.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| apiKeyTitle | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| apiKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| apiSecretTitle | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| apiSecret | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-TaxJar-Microservice-DataAccess-ApiHelper-HttpClientSingleton-RemoveHeaders-System-String,System-String-'></a>
### RemoveHeaders(apiKeyTitle,apiKey) `method`

##### Summary

Remove header overload function.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| apiKeyTitle | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| apiKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-TaxJar-Microservice-DataAccess-ApiHelper-HttpClientSingleton-RemoveHeadersAccept-System-String-'></a>
### RemoveHeadersAccept(apiKey) `method`

##### Summary

Remove header overload function.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| apiKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-TaxJar-Microservice-DataAccess-ApiHelper-HttpClientSingleton-SetHeaders-System-String,System-String,System-String,System-String-'></a>
### SetHeaders(apiKeyTitle,internalKey,apiSecretTitle,apiSecret) `method`

##### Summary

Set header overload function using an API key and API secret

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| apiKeyTitle | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| internalKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| apiSecretTitle | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| apiSecret | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-TaxJar-Microservice-DataAccess-ApiHelper-HttpClientSingleton-SetHeaders-System-String,System-String-'></a>
### SetHeaders(apiKeyTitle,internalKey) `method`

##### Summary

Set header overload for simplistic header addition

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| apiKeyTitle | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| internalKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-TaxJar-Microservice-DataAccess-ApiHelper-HttpClientSingleton-SetHeaders-System-Collections-Generic-Dictionary{System-String,System-String}-'></a>
### SetHeaders(headers) `method`

##### Summary

Set header override using a predefined dictionary key-value pairs.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| headers | [System.Collections.Generic.Dictionary{System.String,System.String}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.Dictionary 'System.Collections.Generic.Dictionary{System.String,System.String}') |  |

<a name='M-TaxJar-Microservice-DataAccess-ApiHelper-HttpClientSingleton-SetHeadersAccept-System-String-'></a>
### SetHeadersAccept(key) `method`

##### Summary

Set Header Overload

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='T-Auth-Extention-HttpResponceExtention'></a>
## HttpResponceExtention `type`

##### Namespace

TaxDemo.Extention

##### Summary

The extension method for the Http response to return the error messages.

<a name='T-Auth-DataAccess-IApiDbContext'></a>
## IApiDbContext `type`

##### Namespace

TaxDemo.DataAccess

##### Summary

APIContext for access and storage of the
configured API keys for authenticated users

<a name='M-Auth-DataAccess-IApiDbContext-GetApiKey-System-String,System-Byte[]-'></a>
### GetApiKey(apiName,compareHash) `method`

##### Summary

API key access function

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| apiName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| compareHash | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') |  |

<a name='M-Auth-DataAccess-IApiDbContext-SaveChanges-Auth-Model-ApiDbItem-'></a>
### SaveChanges(item) `method`

##### Summary

Save changes or new API keys the Item takes
the apikeyitem model

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| item | [TaxDemo.Model.ApiDbItem](#T-Auth-Model-ApiDbItem 'TaxDemo.Model.ApiDbItem') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='T-Auth-DataAccess-IAuthContext'></a>
## IAuthContext `type`

##### Namespace

TaxDemo.DataAccess

##### Summary

Interface for Authorization calls

<a name='M-Auth-DataAccess-IAuthContext-GetUserHash-System-String,System-String-'></a>
### GetUserHash(username,password) `method`

##### Summary

Gets the user hash to see if the user is allowed to
access API key

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| username | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| password | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Auth-DataAccess-IAuthContext-Login-System-String,System-String-'></a>
### Login(user,password) `method`

##### Summary

Login consisting of User Password

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| user | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| password | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Auth-DataAccess-IAuthContext-Register-Auth-Model-AuthModel,System-String-'></a>
### Register(username,password,address1,address2,city,zip) `method`

##### Summary

Register User Interface

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| username | [TaxDemo.Model.AuthModel](#T-Auth-Model-AuthModel 'TaxDemo.Model.AuthModel') |  |
| password | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Auth-DataAccess-IAuthContext-UserExists-System-String-'></a>
### UserExists(username) `method`

##### Summary

User Lookup by Username

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| username | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='T-Auth-DataAccess-IBaseDbContext'></a>
## IBaseDbContext `type`

##### Namespace

TaxDemo.DataAccess

##### Summary

This is the base interface for the DB access functions.

<a name='M-Auth-DataAccess-IBaseDbContext-SaveChanges-Auth-Model-TaxCalculationItemEvent-'></a>
### SaveChanges(item) `method`

##### Summary

This takes in the Model and saves to the Database in question        ///

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| item | [TaxDemo.Model.TaxCalculationItemEvent](#T-Auth-Model-TaxCalculationItemEvent 'TaxDemo.Model.TaxCalculationItemEvent') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='T-Auth-ApiDataAccess-ICalcRates'></a>
## ICalcRates `type`

##### Namespace

TaxDemo.ApiDataAccess

##### Summary

Icalc rates access to the tax rates over the Get Order Function
///

<a name='T-Auth-Business-ICalculate'></a>
## ICalculate `type`

##### Namespace

TaxDemo.Business


##### Summary

The business logic interface, where all business logic should occur. The distinction is quickly apparent,
if the function could be in a console application, then it is most likely only dependent on the input, thus 
does not care where the data comes from.

<a name='T-Auth-DataAccess-ICalculateDbContext'></a>
## ICalculateDbContext `type`

##### Namespace

TaxDemo.DataAccess

##### Summary

This is the concrete implementation of the Auth interface, and the DB sets thereof.

<a name='T-Auth-ApiDataAccess-ITaxRates'></a>
## ITaxRates `type`

##### Namespace

TaxDemo.ApiDataAccess

##### Summary

Access to base tax-rates for any order this can be expanded to
separate different tax brackets international or by region

<a name='M-Auth-ApiDataAccess-ITaxRates-GetOrderTaxRate-System-String,System-String,System-Byte[]-'></a>
### GetOrderTaxRate(query,apiName,userHash) `method`

##### Summary

All DataContext Interfaces will propagate the element through the Service bus using reflection as every service will implement the interface.

##### Returns


##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| query | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| apiName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| userHash | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') |  |

<a name='T-Auth-DataAccess-ITaxServiceDbContext'></a>
## ITaxServiceDbContext `type`

##### Namespace

TaxDemo.DataAccess

##### Summary

The Tax DB context interfaces the concrete implementation of DataContexTax implements the DbContext and is used to pass around access as needed.

<a name='T-Auth-ApiDataAccess-ITax`1'></a>
## ITax\`1 `type`

##### Namespace

TaxDemo.ApiDataAccess

##### Summary

Serves as the extension for the memento pattern

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='T-Auth-Model-Rates'></a>
## Rates `type`

##### Namespace

TaxDemo.Model

##### Summary

Rates is the wrapper for the rate class so that JSON can serialize and deserialize

<a name='T-Auth-Model-SummayRates'></a>
## SummayRates `type`

##### Namespace

TaxDemo.Model

##### Summary
Data Transfer Object

<a name='T-Auth-Model-TaxCalculationItemEvent'></a>
## TaxCalculationItemEvent `type`

##### Namespace

TaxDemo.Model

##### Summary

This is the data object responsible for transporting and storing the
calculated results from the API calls

<a name='T-Auth-Model-TaxItemEvent'></a>
## TaxItemEvent `type`

##### Namespace

TaxDemo.Model

##### Summary

Tax Item information for DB storage for possible later
statistical analysis.

<a name='T-Auth-ApiDataAccess-TaxRates'></a>
## TaxRates `type`

##### Namespace

TaxDemo.ApiDataAccess

##### Summary

The general Tax Rate retrieval
Access the APIDb directly
TODO In Future, the API DB access should be encapsulated in a decorator access the DB directly

<a name='M-Auth-ApiDataAccess-TaxRates-#ctor-Auth-DataAccess-DataContextApi,Auth-DataAccess-DataContextTax-'></a>
### #ctor(dbContext) `constructor`

##### Summary

Database context injection according to design

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| dbContext | [TaxDemo.DataAccess.DataContextApi](#T-Auth-DataAccess-DataContextApi 'TaxDemo.DataAccess.DataContextApi') |  |

<a name='M-Auth-ApiDataAccess-TaxRates-GetOrderTaxRate-System-String,System-String,System-Byte[]-'></a>
### GetOrderTaxRate() `method`

##### Summary
Gets the tax rate for a specific region using the zip code as an identifier.

##### Parameters

This method has no parameters.

<a name='M-Auth-ApiDataAccess-TaxRates-GetTaxInfo-Auth-Model-Rates-'></a>
### GetTaxInfo(action) `method`

##### Summary

This will resolve any requests to the Database on the stored rates regions types.

##### Returns


##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| action | [TaxDemo.Model.Rates](#T-Auth-Model-Rates 'TaxDemo.Model.Rates') |  |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.NotImplementedException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.NotImplementedException 'System.NotImplementedException') |  |

<a name='T-Auth-Controllers-TaxRatesController'></a>
## TaxRatesController `type`

##### Namespace

TaxDemo.Controllers

<a name='M-Auth-Controllers-TaxRatesController-#ctor-Auth-DataAccess-IAuthContext,Auth-ApiDataAccess-ITaxRates,Auth-DataAccess-ITaxServiceDbContext,Auth-DataAccess-IApiDbContext,Microsoft-Extensions-Logging-ILogger{Auth-Controllers-TaxRatesController}-'></a>
### #ctor(t) `constructor`

##### Summary

Access To the TaxJar API

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| t | [TaxDemo.DataAccess.IAuthContext](#T-Auth-DataAccess-IAuthContext 'TaxDemo.DataAccess.IAuthContext') |  |

<a name='M-Auth-Controllers-TaxRatesController-GetTaxInfo-System-String,System-String,System-String,System-String-'></a>
### GetTaxInfo(query,apiName,authorized) `method`

##### Summary

This API takes the query string the API endpoint and the user
hash obtained from the password to retrieve the API Key to make
the desired request.

##### Returns

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| query | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| apiName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| authorized | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='T-Auth-DataAccess-TaxServiceDbContext'></a>
## TaxServiceDbContext `type`

##### Namespace

TaxDemo.DataAccess

##### Summary

Main context hub

<a name='M-Auth-DataAccess-TaxServiceDbContext-Correction-System-String-'></a>
### Correction(id) `method`

##### Summary

This allows for the correction of data or updating with new information.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.NotImplementedException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.NotImplementedException 'System.NotImplementedException') |  |

<a name='M-Auth-DataAccess-TaxServiceDbContext-GetTaxItem'></a>
### GetItemsBeyondThreshold() `method`

##### Summary
takes a given an amount in reference to the dollar returns all the values and the zip codes that 
exceed that value.

##### Returns


<a name='M-Auth-DataAccess-TaxServiceDbContext-GetTaxItems'></a>
### GetTaxItems() `method`

##### Summary

Returns all elements in DB: Currently, this will do but should be limited or paginated.

##### Returns

<a name='M-Auth-DataAccess-TaxServiceDbContext-SaveChanges-Auth-Model-Rates-'></a>
### SaveChanges() `method`

##### Summary

Saves changes to the Tax Item Db

##### Returns



##### Parameters

This method has no parameters.

<a name='T-Auth-Model-rate'></a>
## rate `type`

##### Namespace

TaxDemo.Model

##### Summary

The rate is the main object at this point
this will carry all the information needed
