<a name='assembly'></a>
:octocat:
### Documentation has index for lookup should a need arise...
# Auth
![Patricks github stats](https://github-readme-stats.vercel.app/api?username=patrick-gourdet&count_private=true)
## This docker container has unit tests as well as API interaction using swagger, data storage is hndeled using Encrypted SQLite
<img src="./auth.png"/>
# The Service containes user authentication authenticated API key DB insert and Calculation calls
# as well as other features
[![Build Status](https://img.shields.io/badge/Development-build-green)](https://fedigital.org)</br>

## To run project clone then open in Visual Studios 
## Download and install Docker-Desktop
## Execute in VisualStudios Using the docker file

## Troubleshoot: Delete Docker file and right click project add Docker Support

# Test Calculation Method 
## Step 1: Register user using swagger
## Step 2: Save API Key using the credentials created in step 1
## Step 3: Make call to API entering amount and ZIP code

# Using Unit tests 
## Run API Docker container 
## Must alter the user then run test
## Then add user to unit test 3
## all expected values should return 201 or 200

## Contents

# DataBase Context Elements
- [ApiDbContext](#T-Auth-DataAccess-ApiDbContext 'Auth.DataAccess.ApiDbContext')
  - [#ctor(context)](#M-Auth-DataAccess-ApiDbContext-#ctor-Auth-DataAccess-DataContextApi- 'Auth.DataAccess.ApiDbContext.#ctor(Auth.DataAccess.DataContextApi)')
  - [GetApiKey(apiName,compareHash)](#M-Auth-DataAccess-ApiDbContext-GetApiKey-System-String,System-Byte[]- 'Auth.DataAccess.ApiDbContext.GetApiKey(System.String,System.Byte[])')
  - [SaveChanges(apiName,apiKeyToSave,compareHash)](#M-Auth-DataAccess-ApiDbContext-SaveChanges-Auth-Model-ApiDbItem- 'Auth.DataAccess.ApiDbContext.SaveChanges(Auth.Model.ApiDbItem)')
- [DataContextCalc](#T-Auth-DataAccess-DataContextCalc 'Auth.DataAccess.DataContextCalc')
- [DataContextTax](#T-Auth-DataAccess-DataContextTax 'Auth.DataAccess.DataContextTax') 
- [TaxServiceDbContext](#T-Auth-DataAccess-TaxServiceDbContext 'Auth.DataAccess.TaxServiceDbContext')
  - [Correction(id)](#M-Auth-DataAccess-TaxServiceDbContext-Correction-System-String- 'Auth.DataAccess.TaxServiceDbContext.Correction(System.String)')
  - [GetTaxItem()](#M-Auth-DataAccess-TaxServiceDbContext-GetTaxItem 'Auth.DataAccess.TaxServiceDbContext.GetTaxItem')
  - [GetTaxItems()](#M-Auth-DataAccess-TaxServiceDbContext-GetTaxItems 'Auth.DataAccess.TaxServiceDbContext.GetTaxItems')
  - [SaveChanges()](#M-Auth-DataAccess-TaxServiceDbContext-SaveChanges-Auth-Model-Rates- 'Auth.DataAccess.TaxServiceDbContext.SaveChanges(Auth.Model.Rates)')

# Controller Documentation 
-[AuthContext](#T-Auth-DataAccess-AuthContext 'Auth.DataAccess.AuthContext')
  - [GetUserHash(username)](#M-Auth-DataAccess-AuthContext-GetUserHash-System-String,System-String- 'Auth.DataAccess.AuthContext.GetUserHash(System.String,System.String)')
  - [Register(user,password)](#M-Auth-DataAccess-AuthContext-Register-Auth-Model-AuthModel,System-String- 'Auth.DataAccess.AuthContext.Register(Auth.Model.AuthModel,System.String)')
  - [Update(userToUpdate,username,password)](#M-Auth-DataAccess-AuthContext-Update-Auth-Model-AuthModel,System-String,System-String- 'Auth.DataAccess.AuthContext.Update(Auth.Model.AuthModel,System.String,System.String)')
  - [UserExists(username)](#M-Auth-DataAccess-AuthContext-UserExists-System-String- 'Auth.DataAccess.AuthContext.UserExists(System.String)')
- [AuthController](#T-Auth-Controllers-AuthController 'Auth.Controllers.AuthController')
  - [#ctor(repo,config,logger)](#M-Auth-Controllers-AuthController-#ctor-Auth-DataAccess-IAuthContext,Auth-DataAccess-IApiDbContext,Microsoft-Extensions-Configuration-IConfiguration,Microsoft-Extensions-Logging-ILogger{Auth-Controllers-AuthController}- 'Auth.Controllers.AuthController.#ctor(Auth.DataAccess.IAuthContext,Auth.DataAccess.IApiDbContext,Microsoft.Extensions.Configuration.IConfiguration,Microsoft.Extensions.Logging.ILogger{Auth.Controllers.AuthController})')
  - [Login(user)](#M-Auth-Controllers-AuthController-Login-Auth-Model-AuthRegisterDto- 'Auth.Controllers.AuthController.Login(Auth.Model.AuthRegisterDto)')
  - [Register(newUser)](#M-Auth-Controllers-AuthController-Register-Auth-Model-AuthRegisterDto- 'Auth.Controllers.AuthController.Register(Auth.Model.AuthRegisterDto)')
  - [SaveApi(apikey,apiName,authorized)](#M-Auth-Controllers-AuthController-SaveApi-System-String,System-String,System-String,System-String- 'Auth.Controllers.AuthController.SaveApi(System.String,System.String,System.String,System.String)')
  - [UserExists(user)](#M-Auth-Controllers-AuthController-UserExists-Auth-Model-AuthRegisterDto- 'Auth.Controllers.AuthController.UserExists(Auth.Model.AuthRegisterDto)')
 [TaxRatesController](#T-Auth-Controllers-TaxRatesController 'Auth.Controllers.TaxRatesController')
  - [#ctor(t)](#M-Auth-Controllers-TaxRatesController-#ctor-Auth-DataAccess-IAuthContext,Auth-ApiDataAccess-ITaxRates,Auth-DataAccess-ITaxServiceDbContext,Auth-DataAccess-IApiDbContext,Microsoft-Extensions-Logging-ILogger{Auth-Controllers-TaxRatesController}- 'Auth.Controllers.TaxRatesController.#ctor(Auth.DataAccess.IAuthContext,Auth.ApiDataAccess.ITaxRates,Auth.DataAccess.ITaxServiceDbContext,Auth.DataAccess.IApiDbContext,Microsoft.Extensions.Logging.ILogger{Auth.Controllers.TaxRatesController})')
  - [GetTaxInfo(query,apiName,authorized)](#M-Auth-Controllers-TaxRatesController-GetTaxInfo-System-String,System-String,System-String,System-String- 'Auth.Controllers.TaxRatesController.GetTaxInfo(System.String,System.String,System.String,System.String)')

# Models  
[ApiDbItem](#T-Auth-Model-ApiDbItem 'Auth.Model.ApiDbItem')
- [AuthModel](#T-Auth-Model-AuthModel 'Auth.Model.AuthModel')
- [AuthRegisterDto](#T-Auth-Model-AuthRegisterDto 'Auth.Model.AuthRegisterDto')
- [CalcRates](#T-Auth-ApiDataAccess-CalcRates 'Auth.ApiDataAccess.CalcRates')
  - [#ctor(contex)](#M-Auth-ApiDataAccess-CalcRates-#ctor-Auth-DataAccess-DataContextApi- 'Auth.ApiDataAccess.CalcRates.#ctor(Auth.DataAccess.DataContextApi)')
  - [GetOrderTaxRate()](#M-Auth-ApiDataAccess-CalcRates-GetOrderTaxRate-System-String,System-String,System-Byte[]- 'Auth.ApiDataAccess.CalcRates.GetOrderTaxRate(System.String,System.String,System.Byte[])')
- [Calculate](#T-Auth-Business-Calculate 'Auth.Business.Calculate')
- [CalculationsController](#T-Auth-Controllers-CalculationsController 'Auth.Controllers.CalculationsController')
  - [#ctor(t)](#M-Auth-Controllers-CalculationsController-#ctor-Auth-DataAccess-IAuthContext,Auth-ApiDataAccess-ICalcRates,Auth-DataAccess-ICalculateDbContext,Microsoft-Extensions-Logging-ILogger{Auth-Controllers-CalculationsController},Auth-Business-ICalculate- 'Auth.Controllers.CalculationsController.#ctor(Auth.DataAccess.IAuthContext,Auth.ApiDataAccess.ICalcRates,Auth.DataAccess.ICalculateDbContext,Microsoft.Extensions.Logging.ILogger{Auth.Controllers.CalculationsController},Auth.Business.ICalculate)')
- [CalculatorDbContext](#T-Auth-DataAccess-CalculatorDbContext 'Auth.DataAccess.CalculatorDbContext')
  - [#ctor(context)](#M-Auth-DataAccess-CalculatorDbContext-#ctor-Auth-DataAccess-DataContextCalc- 'Auth.DataAccess.CalculatorDbContext.#ctor(Auth.DataAccess.DataContextCalc)')
  - [Rates](#T-Auth-Model-Rates 'Auth.Model.Rates')
- [SummayRates](#T-Auth-Model-SummayRates 'Auth.Model.SummayRates')
- [TaxCalculationItemEvent](#T-Auth-Model-TaxCalculationItemEvent 'Auth.Model.TaxCalculationItemEvent')
- [TaxItemEvent](#T-Auth-Model-TaxItemEvent 'Auth.Model.TaxItemEvent')
- [TaxRates](#T-Auth-ApiDataAccess-TaxRates 'Auth.ApiDataAccess.TaxRates')
  - [#ctor(dbContext)](#M-Auth-ApiDataAccess-TaxRates-#ctor-Auth-DataAccess-DataContextApi,Auth-DataAccess-DataContextTax- 'Auth.ApiDataAccess.TaxRates.#ctor(Auth.DataAccess.DataContextApi,Auth.DataAccess.DataContextTax)')
  - [GetOrderTaxRate()](#M-Auth-ApiDataAccess-TaxRates-GetOrderTaxRate-System-String,System-String,System-Byte[]- 'Auth.ApiDataAccess.TaxRates.GetOrderTaxRate(System.String,System.String,System.Byte[])')
  - [GetTaxInfo(action)](#M-Auth-ApiDataAccess-TaxRates-GetTaxInfo-Auth-Model-Rates- 'Auth.ApiDataAccess.TaxRates.GetTaxInfo(Auth.Model.Rates)')
  - [rate](#T-Auth-Model-rate 'Auth.Model.rate')

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
- [HttpResponceExtention](#T-Auth-Extention-HttpResponceExtention 'Auth.Extention.HttpResponceExtention')

# Interfaces
- [IApiDbContext](#T-Auth-DataAccess-IApiDbContext 'Auth.DataAccess.IApiDbContext')
  - [GetApiKey(apiName,compareHash)](#M-Auth-DataAccess-IApiDbContext-GetApiKey-System-String,System-Byte[]- 'Auth.DataAccess.IApiDbContext.GetApiKey(System.String,System.Byte[])')
  - [SaveChanges(item)](#M-Auth-DataAccess-IApiDbContext-SaveChanges-Auth-Model-ApiDbItem- 'Auth.DataAccess.IApiDbContext.SaveChanges(Auth.Model.ApiDbItem)')
- [IAuthContext](#T-Auth-DataAccess-IAuthContext 'Auth.DataAccess.IAuthContext')
  - [GetUserHash(username,password)](#M-Auth-DataAccess-IAuthContext-GetUserHash-System-String,System-String- 'Auth.DataAccess.IAuthContext.GetUserHash(System.String,System.String)')
  - [Login(user,password)](#M-Auth-DataAccess-IAuthContext-Login-System-String,System-String- 'Auth.DataAccess.IAuthContext.Login(System.String,System.String)')
  - [Register(username,password,address1,address2,city,zip)](#M-Auth-DataAccess-IAuthContext-Register-Auth-Model-AuthModel,System-String- 'Auth.DataAccess.IAuthContext.Register(Auth.Model.AuthModel,System.String)')
  - [UserExists(username)](#M-Auth-DataAccess-IAuthContext-UserExists-System-String- 'Auth.DataAccess.IAuthContext.UserExists(System.String)')
- [IBaseDbContext](#T-Auth-DataAccess-IBaseDbContext 'Auth.DataAccess.IBaseDbContext')
  - [SaveChanges(item)](#M-Auth-DataAccess-IBaseDbContext-SaveChanges-Auth-Model-TaxCalculationItemEvent- 'Auth.DataAccess.IBaseDbContext.SaveChanges(Auth.Model.TaxCalculationItemEvent)')
- [ICalcRates](#T-Auth-ApiDataAccess-ICalcRates 'Auth.ApiDataAccess.ICalcRates')
- [ICalculate](#T-Auth-Business-ICalculate 'Auth.Business.ICalculate')
- [ICalculateDbContext](#T-Auth-DataAccess-ICalculateDbContext 'Auth.DataAccess.ICalculateDbContext')
- [ITaxRates](#T-Auth-ApiDataAccess-ITaxRates 'Auth.ApiDataAccess.ITaxRates')
  - [GetOrderTaxRate(query,apiName,userHash)](#M-Auth-ApiDataAccess-ITaxRates-GetOrderTaxRate-System-String,System-String,System-Byte[]- 'Auth.ApiDataAccess.ITaxRates.GetOrderTaxRate(System.String,System.String,System.Byte[])')
- [ITaxServiceDbContext](#T-Auth-DataAccess-ITaxServiceDbContext 'Auth.DataAccess.ITaxServiceDbContext')
- [ITax](#T-Auth-ApiDataAccess-ITax`1 'Auth.ApiDataAccess.ITax`1')


-[AuthLevel](#T-Auth-Model-AuthLevel 'Auth.Model.AuthLevel')
<a name='T-Auth-DataAccess-ApiDbContext'></a>
## ApiDbContext `type`

##### Namespace

Auth.DataAccess

##### Summary

Api Database Access to obtain the API key using authenticated user
This maps the user to each API key which the user is authorized to use

<a name='M-Auth-DataAccess-ApiDbContext-#ctor-Auth-DataAccess-DataContextApi-'></a>
### #ctor(context) `constructor`

##### Summary

Inject context this is how the base implementation should be throught the
application as to abstract the access to Database

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [Auth.DataAccess.DataContextApi](#T-Auth-DataAccess-DataContextApi 'Auth.DataAccess.DataContextApi') |  |

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
| apiName | [Auth.Model.ApiDbItem](#T-Auth-Model-ApiDbItem 'Auth.Model.ApiDbItem') |  |

<a name='T-Auth-Model-ApiDbItem'></a>
## ApiDbItem `type`

##### Namespace

Auth.Model

##### Summary

Base APi DB element for data interactions

<a name='T-Auth-DataAccess-AuthContext'></a>
## AuthContext `type`

##### Namespace

Auth.DataAccess

<a name='M-Auth-DataAccess-AuthContext-GetUserHash-System-String,System-String-'></a>
### GetUserHash(username) `method`

##### Summary

Get User Hash for api key authorization

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
| user | [Auth.Model.AuthModel](#T-Auth-Model-AuthModel 'Auth.Model.AuthModel') |  |
| password | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Auth-DataAccess-AuthContext-Update-Auth-Model-AuthModel,System-String,System-String-'></a>
### Update(userToUpdate,username,password) `method`

##### Summary

TODO still need proper thought

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| userToUpdate | [Auth.Model.AuthModel](#T-Auth-Model-AuthModel 'Auth.Model.AuthModel') |  |
| username | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| password | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Auth-DataAccess-AuthContext-UserExists-System-String-'></a>
### UserExists(username) `method`

##### Summary

Find if the user is in Database

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| username | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='T-Auth-Controllers-AuthController'></a>
## AuthController `type`

##### Namespace

Auth.Controllers

##### Summary

Authentication API Access for Gateway authentication method

<a name='M-Auth-Controllers-AuthController-#ctor-Auth-DataAccess-IAuthContext,Auth-DataAccess-IApiDbContext,Microsoft-Extensions-Configuration-IConfiguration,Microsoft-Extensions-Logging-ILogger{Auth-Controllers-AuthController}-'></a>
### #ctor(repo,config,logger) `constructor`

##### Summary

Cunstructor using IoC for logging the repo tied to the Auth methods 
and configuration methods from start

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| repo | [Auth.DataAccess.IAuthContext](#T-Auth-DataAccess-IAuthContext 'Auth.DataAccess.IAuthContext') |  |
| config | [Auth.DataAccess.IApiDbContext](#T-Auth-DataAccess-IApiDbContext 'Auth.DataAccess.IApiDbContext') |  |
| logger | [Microsoft.Extensions.Configuration.IConfiguration](#T-Microsoft-Extensions-Configuration-IConfiguration 'Microsoft.Extensions.Configuration.IConfiguration') |  |

<a name='M-Auth-Controllers-AuthController-Login-Auth-Model-AuthRegisterDto-'></a>
### Login(user) `method`

##### Summary

Standard login method using jwt tokens

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| user | [Auth.Model.AuthRegisterDto](#T-Auth-Model-AuthRegisterDto 'Auth.Model.AuthRegisterDto') |  |

<a name='M-Auth-Controllers-AuthController-Register-Auth-Model-AuthRegisterDto-'></a>
### Register(newUser) `method`

##### Summary

Registration method

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| newUser | [Auth.Model.AuthRegisterDto](#T-Auth-Model-AuthRegisterDto 'Auth.Model.AuthRegisterDto') |  |

<a name='M-Auth-Controllers-AuthController-SaveApi-System-String,System-String,System-String,System-String-'></a>
### SaveApi(apikey,apiName,authorized) `method`

##### Summary

Add API Key To the api keys for a specific user
eliminating the authorization as the assigning of api keys
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

To see if a user exsists befor attempting authorization process
providing a layer of abstration for brutforce attacks

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| user | [Auth.Model.AuthRegisterDto](#T-Auth-Model-AuthRegisterDto 'Auth.Model.AuthRegisterDto') |  |

<a name='T-Auth-Model-AuthLevel'></a>
## AuthLevel `type`

##### Namespace

Auth.Model

##### Summary

This is the authorization levels for an employee
given the level determines the privileges

<a name='T-Auth-Model-AuthModel'></a>
## AuthModel `type`

##### Namespace

Auth.Model

##### Summary

Main authentication model to find authorization levels
to register users or login

<a name='T-Auth-Model-AuthRegisterDto'></a>
## AuthRegisterDto `type`

##### Namespace

Auth.Model

##### Summary

Smaller dto as to not expose the hash fields to a user

<a name='T-Auth-ApiDataAccess-CalcRates'></a>
## CalcRates `type`

##### Namespace

Auth.ApiDataAccess

##### Summary

Main calculation method for all tax calculations

<a name='M-Auth-ApiDataAccess-CalcRates-#ctor-Auth-DataAccess-DataContextApi-'></a>
### #ctor(contex) `constructor`

##### Summary

Concrete implemnetation of the interface which also uses the Api access for authorization

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| contex | [Auth.DataAccess.DataContextApi](#T-Auth-DataAccess-DataContextApi 'Auth.DataAccess.DataContextApi') |  |

<a name='M-Auth-ApiDataAccess-CalcRates-GetOrderTaxRate-System-String,System-String,System-Byte[]-'></a>
### GetOrderTaxRate() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='T-Auth-Business-Calculate'></a>
## Calculate `type`

##### Namespace

Auth.Business

##### Summary

Calculate the tax for a given api call to taxjar using the combined tax rate

<a name='T-Auth-Controllers-CalculationsController'></a>
## CalculationsController `type`

##### Namespace

Auth.Controllers

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
| t | [Auth.DataAccess.IAuthContext](#T-Auth-DataAccess-IAuthContext 'Auth.DataAccess.IAuthContext') |  |

<a name='T-Auth-DataAccess-CalculatorDbContext'></a>
## CalculatorDbContext `type`

##### Namespace

Auth.DataAccess

##### Summary

Calculation Db access
the data from tax rates can be accessed either DB or API

<a name='M-Auth-DataAccess-CalculatorDbContext-#ctor-Auth-DataAccess-DataContextCalc-'></a>
### #ctor(context) `constructor`

##### Summary

Injecting the shared DB context into the controller
TODO Abstract db from controller in separate class

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [Auth.DataAccess.DataContextCalc](#T-Auth-DataAccess-DataContextCalc 'Auth.DataAccess.DataContextCalc') |  |

<a name='T-Auth-DataAccess-DataContextCalc'></a>
## DataContextCalc `type`

##### Namespace

Auth.DataAccess

##### Summary

Calculator Interface implements Save To Sqlite DB

<a name='T-Auth-DataAccess-DataContextTax'></a>
## DataContextTax `type`

##### Namespace

Auth.DataAccess

##### Summary

This is the TaxJar interaction interface
this will have the main functionality when interacting with the Tax apis

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

dispose method for the Socket handler method

##### Parameters

This method has no parameters.

<a name='M-TaxJar-Microservice-DataAccess-ApiHelper-HttpClientSingleton-Dispose-System-Boolean-'></a>
### Dispose(disposing) `method`

##### Summary

Dispose method to call if there is an error or memory issues

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

Remove header needed for authentication calls this is mainly for security reasons

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| headers | [System.Collections.Generic.Dictionary{System.String,System.String}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.Dictionary 'System.Collections.Generic.Dictionary{System.String,System.String}') |  |

<a name='M-TaxJar-Microservice-DataAccess-ApiHelper-HttpClientSingleton-RemoveHeaders-System-String,System-String,System-String,System-String-'></a>
### RemoveHeaders(apiKeyTitle,apiKey,apiSecretTitle,apiSecret) `method`

##### Summary

Remove header function override to accomodate the same format as the set header function set

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

Remove header overload function

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| apiKeyTitle | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| apiKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-TaxJar-Microservice-DataAccess-ApiHelper-HttpClientSingleton-RemoveHeadersAccept-System-String-'></a>
### RemoveHeadersAccept(apiKey) `method`

##### Summary

Remove header overload function

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| apiKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-TaxJar-Microservice-DataAccess-ApiHelper-HttpClientSingleton-SetHeaders-System-String,System-String,System-String,System-String-'></a>
### SetHeaders(apiKeyTitle,internalKey,apiSecretTitle,apiSecret) `method`

##### Summary

Set header over load function using api key and api secret

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

Set header override using a predefined dictionary key value pairs

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

Auth.Extention

##### Summary

Extenstion method  fir the Http response to return the error messages

<a name='T-Auth-DataAccess-IApiDbContext'></a>
## IApiDbContext `type`

##### Namespace

Auth.DataAccess

##### Summary

Api Context for access and storage of the
configured api keys for authenticated users

<a name='M-Auth-DataAccess-IApiDbContext-GetApiKey-System-String,System-Byte[]-'></a>
### GetApiKey(apiName,compareHash) `method`

##### Summary

Api key access function

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| apiName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| compareHash | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') |  |

<a name='M-Auth-DataAccess-IApiDbContext-SaveChanges-Auth-Model-ApiDbItem-'></a>
### SaveChanges(item) `method`

##### Summary

Save changes or new api keys the Item takes
the apikeyitem model

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| item | [Auth.Model.ApiDbItem](#T-Auth-Model-ApiDbItem 'Auth.Model.ApiDbItem') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='T-Auth-DataAccess-IAuthContext'></a>
## IAuthContext `type`

##### Namespace

Auth.DataAccess

##### Summary

Interface for Authorization calls

<a name='M-Auth-DataAccess-IAuthContext-GetUserHash-System-String,System-String-'></a>
### GetUserHash(username,password) `method`

##### Summary

Gets the user hash to see if the user is allowed to
access api key

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
| username | [Auth.Model.AuthModel](#T-Auth-Model-AuthModel 'Auth.Model.AuthModel') |  |
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

Auth.DataAccess

##### Summary

This is the base interface for the DB access functions

<a name='M-Auth-DataAccess-IBaseDbContext-SaveChanges-Auth-Model-TaxCalculationItemEvent-'></a>
### SaveChanges(item) `method`

##### Summary

This takes in the Model and saves to the Database in question        ///

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| item | [Auth.Model.TaxCalculationItemEvent](#T-Auth-Model-TaxCalculationItemEvent 'Auth.Model.TaxCalculationItemEvent') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='T-Auth-ApiDataAccess-ICalcRates'></a>
## ICalcRates `type`

##### Namespace

Auth.ApiDataAccess

##### Summary

Icalc rates access to the TaxRates over the Get Order Function
///

<a name='T-Auth-Business-ICalculate'></a>
## ICalculate `type`

##### Namespace

Auth.Business

##### Summary

The business logic interface

<a name='T-Auth-DataAccess-ICalculateDbContext'></a>
## ICalculateDbContext `type`

##### Namespace

Auth.DataAccess

##### Summary

Calculator class interface

<a name='T-Auth-ApiDataAccess-ITaxRates'></a>
## ITaxRates `type`

##### Namespace

Auth.ApiDataAccess

##### Summary

Access to base tax-rates for any order this can be expanded to
separate different tax brackets international or by region

<a name='M-Auth-ApiDataAccess-ITaxRates-GetOrderTaxRate-System-String,System-String,System-Byte[]-'></a>
### GetOrderTaxRate(query,apiName,userHash) `method`

##### Summary

Interface for all tax rate endpoints

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

Auth.DataAccess

##### Summary

The tax item is the configuration of Ibase Context

<a name='T-Auth-ApiDataAccess-ITax`1'></a>
## ITax\`1 `type`

##### Namespace

Auth.ApiDataAccess

##### Summary

Serves as the extenstion for the memento pattern

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='T-Auth-Model-Rates'></a>
## Rates `type`

##### Namespace

Auth.Model

##### Summary

Rates is the wrapper for the rate class so that JSON can serialize and deserialize

<a name='T-Auth-Model-SummayRates'></a>
## SummayRates `type`

##### Namespace

Auth.Model

##### Summary

Has not been implemented yet but will hold all the summary elements returned form TaxJar

<a name='T-Auth-Model-TaxCalculationItemEvent'></a>
## TaxCalculationItemEvent `type`

##### Namespace

Auth.Model

##### Summary

This is the data object responsible for transporting and storing the
calculated results from the api calls

<a name='T-Auth-Model-TaxItemEvent'></a>
## TaxItemEvent `type`

##### Namespace

Auth.Model

##### Summary

Tax Item information for DB storage for possible later
statistical analysis.

<a name='T-Auth-ApiDataAccess-TaxRates'></a>
## TaxRates `type`

##### Namespace

Auth.ApiDataAccess

##### Summary

The general Tax Rate retrieval
Access the APIDb directly
TODO In Future the API DB access should call class an not access the DB directly

<a name='M-Auth-ApiDataAccess-TaxRates-#ctor-Auth-DataAccess-DataContextApi,Auth-DataAccess-DataContextTax-'></a>
### #ctor(dbContext) `constructor`

##### Summary

Database context injection according to design

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| dbContext | [Auth.DataAccess.DataContextApi](#T-Auth-DataAccess-DataContextApi 'Auth.DataAccess.DataContextApi') |  |

<a name='M-Auth-ApiDataAccess-TaxRates-GetOrderTaxRate-System-String,System-String,System-Byte[]-'></a>
### GetOrderTaxRate() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-Auth-ApiDataAccess-TaxRates-GetTaxInfo-Auth-Model-Rates-'></a>
### GetTaxInfo(action) `method`

##### Summary

This will resolve any requests to the Database on the stored rates regions types

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| action | [Auth.Model.Rates](#T-Auth-Model-Rates 'Auth.Model.Rates') |  |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.NotImplementedException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.NotImplementedException 'System.NotImplementedException') |  |

<a name='T-Auth-Controllers-TaxRatesController'></a>
## TaxRatesController `type`

##### Namespace

Auth.Controllers

<a name='M-Auth-Controllers-TaxRatesController-#ctor-Auth-DataAccess-IAuthContext,Auth-ApiDataAccess-ITaxRates,Auth-DataAccess-ITaxServiceDbContext,Auth-DataAccess-IApiDbContext,Microsoft-Extensions-Logging-ILogger{Auth-Controllers-TaxRatesController}-'></a>
### #ctor(t) `constructor`

##### Summary

Access To the TaxJar API

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| t | [Auth.DataAccess.IAuthContext](#T-Auth-DataAccess-IAuthContext 'Auth.DataAccess.IAuthContext') |  |

<a name='M-Auth-Controllers-TaxRatesController-GetTaxInfo-System-String,System-String,System-String,System-String-'></a>
### GetTaxInfo(query,apiName,authorized) `method`

##### Summary

This api takes the query string the api endpoint and the user
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

Auth.DataAccess

##### Summary

Main context hub

<a name='M-Auth-DataAccess-TaxServiceDbContext-Correction-System-String-'></a>
### Correction(id) `method`

##### Summary

This allows for correction of faulty data TODO needs to be implemented

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
### GetTaxItem() `method`

##### Summary

Not yet implemented but will retrieve one of the past queries to the
Tax api

##### Returns



##### Parameters

This method has no parameters.

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.NotImplementedException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.NotImplementedException 'System.NotImplementedException') |  |

<a name='M-Auth-DataAccess-TaxServiceDbContext-GetTaxItems'></a>
### GetTaxItems() `method`

##### Summary

Not yet implemented. Will get all the elements of historical api calls

##### Returns



##### Parameters

This method has no parameters.

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.NotImplementedException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.NotImplementedException 'System.NotImplementedException') |  |

<a name='M-Auth-DataAccess-TaxServiceDbContext-SaveChanges-Auth-Model-Rates-'></a>
### SaveChanges() `method`

##### Summary

Save changes to the Tax Item Db

##### Returns



##### Parameters

This method has no parameters.

<a name='T-Auth-Model-rate'></a>
## rate `type`

##### Namespace

Auth.Model

##### Summary

The rate is the main object at this point
this will carry oll the information needed
