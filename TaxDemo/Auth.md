<a name='assembly'></a>
# TaxDemo

## Contents

- [ApiDbContext](#T-Auth-DataAccess-ApiDbContext 'TaxDemo.DataAccess.ApiDbContext')
  - [#ctor(context)](#M-Auth-DataAccess-ApiDbContext-#ctor-Auth-DataAccess-Contexts-DataContextApi- 'TaxDemo.DataAccess.ApiDbContext.#ctor(TaxDemo.DataAccess.Contexts.DataContextApi)')
  - [GetApiKey(apiName,compareHash)](#M-Auth-DataAccess-ApiDbContext-GetApiKey-System-String,System-Byte[]- 'TaxDemo.DataAccess.ApiDbContext.GetApiKey(System.String,System.Byte[])')
  - [SaveChanges(apiName,apiKeyToSave,compareHash)](#M-Auth-DataAccess-ApiDbContext-SaveChanges-Auth-Model-ApiDbItem- 'TaxDemo.DataAccess.ApiDbContext.SaveChanges(TaxDemo.Model.ApiDbItem)')
- [ApiDbItem](#T-Auth-Model-ApiDbItem 'TaxDemo.Model.ApiDbItem')
- [AuthContext](#T-Auth-DataAccess-AuthContext 'TaxDemo.DataAccess.AuthContext')
  - [GetUserHash(username)](#M-Auth-DataAccess-AuthContext-GetUserHash-System-String,System-String- 'TaxDemo.DataAccess.AuthContext.GetUserHash(System.String,System.String)')
  - [Register(user,password)](#M-Auth-DataAccess-AuthContext-Register-Auth-Model-AuthModel,System-String- 'TaxDemo.DataAccess.AuthContext.Register(TaxDemo.Model.AuthModel,System.String)')
  - [Update(userToUpdate,username,password)](#M-Auth-DataAccess-AuthContext-Update-Auth-Model-AuthModel,System-String,System-String- 'TaxDemo.DataAccess.AuthContext.Update(TaxDemo.Model.AuthModel,System.String,System.String)')
  - [UserExists(username)](#M-Auth-DataAccess-AuthContext-UserExists-System-String- 'TaxDemo.DataAccess.AuthContext.UserExists(System.String)')
- [AuthController](#T-Auth-Controllers-AuthController 'TaxDemo.Controllers.AuthController')
  - [#ctor(repo,config,logger)](#M-Auth-Controllers-AuthController-#ctor-Auth-DataAccess-InterfaceContexts-IAuthContext,Auth-DataAccess-InterfaceContexts-IApiDbContext,Microsoft-Extensions-Configuration-IConfiguration,Microsoft-Extensions-Logging-ILogger{Auth-Controllers-AuthController}- 'TaxDemo.Controllers.AuthController.#ctor(TaxDemo.DataAccess.InterfaceContexts.IAuthContext,TaxDemo.DataAccess.InterfaceContexts.IApiDbContext,Microsoft.Extensions.Configuration.IConfiguration,Microsoft.Extensions.Logging.ILogger{TaxDemo.Controllers.AuthController})')
  - [Login(user)](#M-Auth-Controllers-AuthController-Login-Auth-Model-AuthRegisterDto- 'TaxDemo.Controllers.AuthController.Login(TaxDemo.Model.AuthRegisterDto)')
  - [Register(newUser)](#M-Auth-Controllers-AuthController-Register-Auth-Model-AuthRegisterDto- 'TaxDemo.Controllers.AuthController.Register(TaxDemo.Model.AuthRegisterDto)')
  - [SaveApi(apikey,apiName,authorized)](#M-Auth-Controllers-AuthController-SaveApi-System-String,System-String,System-String,System-String- 'TaxDemo.Controllers.AuthController.SaveApi(System.String,System.String,System.String,System.String)')
  - [UserExists(user)](#M-Auth-Controllers-AuthController-UserExists-Auth-Model-AuthRegisterDto- 'TaxDemo.Controllers.AuthController.UserExists(TaxDemo.Model.AuthRegisterDto)')
- [AuthLevel](#T-Auth-Model-AuthLevel 'TaxDemo.Model.AuthLevel')
- [AuthModel](#T-Auth-Model-AuthModel 'TaxDemo.Model.AuthModel')
- [AuthRegisterDto](#T-Auth-Model-AuthRegisterDto 'TaxDemo.Model.AuthRegisterDto')
- [Calculate](#T-Auth-Business-Calculate 'TaxDemo.Business.Calculate')
  - [CalculatedTax(item,amount)](#M-Auth-Business-Calculate-CalculatedTax-Auth-Model-RatesRate,System-Decimal- 'TaxDemo.Business.Calculate.CalculatedTax(TaxDemo.Model.RatesRate,System.Decimal)')
- [CalculationsController](#T-Auth-Controllers-CalculationsController 'TaxDemo.Controllers.CalculationsController')
  - [#ctor(t)](#M-Auth-Controllers-CalculationsController-#ctor-Auth-DataAccess-InterfaceContexts-IAuthContext,Auth-ApiDataAccess-ICalculatorApiAccessor,Auth-DataAccess-InterfaceContexts-ICalculateDbContext,Microsoft-Extensions-Logging-ILogger{Auth-Controllers-CalculationsController},Auth-Business-ICalculate- 'TaxDemo.Controllers.CalculationsController.#ctor(TaxDemo.DataAccess.InterfaceContexts.IAuthContext,TaxDemo.ApiDataAccess.ICalculatorApiAccessor,TaxDemo.DataAccess.InterfaceContexts.ICalculateDbContext,Microsoft.Extensions.Logging.ILogger{TaxDemo.Controllers.CalculationsController},TaxDemo.Business.ICalculate)')
  - [Get(amount,zip,user,password)](#M-Auth-Controllers-CalculationsController-Get-System-Decimal,System-String,System-String,System-String- 'TaxDemo.Controllers.CalculationsController.Get(System.Decimal,System.String,System.String,System.String)')
  - [Get(amount,query,apiname,user,password)](#M-Auth-Controllers-CalculationsController-Get-System-String,System-String,System-String,System-String,System-String- 'TaxDemo.Controllers.CalculationsController.Get(System.String,System.String,System.String,System.String,System.String)')
  - [Get(user,password)](#M-Auth-Controllers-CalculationsController-Get-System-String,System-String- 'TaxDemo.Controllers.CalculationsController.Get(System.String,System.String)')
- [CalculatorDbContext](#T-Auth-DataAccess-CalculatorDbContext 'TaxDemo.DataAccess.CalculatorDbContext')
  - [#ctor(context)](#M-Auth-DataAccess-CalculatorDbContext-#ctor-Auth-DataAccess-Contexts-DataContextCalc- 'TaxDemo.DataAccess.CalculatorDbContext.#ctor(TaxDemo.DataAccess.Contexts.DataContextCalc)')
- [CalculatorTaxTatesAPIAccessor](#T-Auth-ApiDataAccess-CalculatorTaxTatesAPIAccessor 'TaxDemo.ApiDataAccess.CalculatorTaxTatesAPIAccessor')
  - [#ctor(contex)](#M-Auth-ApiDataAccess-CalculatorTaxTatesAPIAccessor-#ctor-Auth-DataAccess-Contexts-DataContextApi- 'TaxDemo.ApiDataAccess.CalculatorTaxTatesAPIAccessor.#ctor(TaxDemo.DataAccess.Contexts.DataContextApi)')
  - [GetOrderTaxRate()](#M-Auth-ApiDataAccess-CalculatorTaxTatesAPIAccessor-GetOrderTaxRate-System-String,System-String,System-Byte[]- 'TaxDemo.ApiDataAccess.CalculatorTaxTatesAPIAccessor.GetOrderTaxRate(System.String,System.String,System.Byte[])')
  - [GetTaxInfo(action)](#M-Auth-ApiDataAccess-CalculatorTaxTatesAPIAccessor-GetTaxInfo-Auth-Model-RatesRate- 'TaxDemo.ApiDataAccess.CalculatorTaxTatesAPIAccessor.GetTaxInfo(TaxDemo.Model.RatesRate)')
- [DataContextCalc](#T-Auth-DataAccess-Contexts-DataContextCalc 'TaxDemo.DataAccess.Contexts.DataContextCalc')
- [DataContextTax](#T-Auth-DataAccess-Contexts-DataContextTax 'TaxDemo.DataAccess.Contexts.DataContextTax')
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
- [HttpResponceExtention](#T-Auth-Extention-HttpResponceExtention 'TaxDemo.Extention.HttpResponceExtention')
- [IApiDbContext](#T-Auth-DataAccess-InterfaceContexts-IApiDbContext 'TaxDemo.DataAccess.InterfaceContexts.IApiDbContext')
  - [GetApiKey(apiName,compareHash)](#M-Auth-DataAccess-InterfaceContexts-IApiDbContext-GetApiKey-System-String,System-Byte[]- 'TaxDemo.DataAccess.InterfaceContexts.IApiDbContext.GetApiKey(System.String,System.Byte[])')
  - [SaveChanges(item)](#M-Auth-DataAccess-InterfaceContexts-IApiDbContext-SaveChanges-Auth-Model-ApiDbItem- 'TaxDemo.DataAccess.InterfaceContexts.IApiDbContext.SaveChanges(TaxDemo.Model.ApiDbItem)')
- [IAuthContext](#T-Auth-DataAccess-InterfaceContexts-IAuthContext 'TaxDemo.DataAccess.InterfaceContexts.IAuthContext')
  - [GetUserHash(username,password)](#M-Auth-DataAccess-InterfaceContexts-IAuthContext-GetUserHash-System-String,System-String- 'TaxDemo.DataAccess.InterfaceContexts.IAuthContext.GetUserHash(System.String,System.String)')
  - [Login(user,password)](#M-Auth-DataAccess-InterfaceContexts-IAuthContext-Login-System-String,System-String- 'TaxDemo.DataAccess.InterfaceContexts.IAuthContext.Login(System.String,System.String)')
  - [Register(username,password,address1,address2,city,zip)](#M-Auth-DataAccess-InterfaceContexts-IAuthContext-Register-Auth-Model-AuthModel,System-String- 'TaxDemo.DataAccess.InterfaceContexts.IAuthContext.Register(TaxDemo.Model.AuthModel,System.String)')
  - [UserExists(username)](#M-Auth-DataAccess-InterfaceContexts-IAuthContext-UserExists-System-String- 'TaxDemo.DataAccess.InterfaceContexts.IAuthContext.UserExists(System.String)')
- [IBaseDbContext](#T-Auth-DataAccess-InterfaceContexts-IBaseDbContext 'TaxDemo.DataAccess.InterfaceContexts.IBaseDbContext')
  - [SaveChanges(item)](#M-Auth-DataAccess-InterfaceContexts-IBaseDbContext-SaveChanges-Auth-Model-TaxCalculationItemEvent- 'TaxDemo.DataAccess.InterfaceContexts.IBaseDbContext.SaveChanges(TaxDemo.Model.TaxCalculationItemEvent)')
- [ICalculate](#T-Auth-Business-ICalculate 'TaxDemo.Business.ICalculate')
- [ICalculateDbContext](#T-Auth-DataAccess-InterfaceContexts-ICalculateDbContext 'TaxDemo.DataAccess.InterfaceContexts.ICalculateDbContext')
- [ICalculatorApiAccessor](#T-Auth-ApiDataAccess-ICalculatorApiAccessor 'TaxDemo.ApiDataAccess.ICalculatorApiAccessor')
- [ITaxRates](#T-Auth-ApiDataAccess-ITaxRates 'TaxDemo.ApiDataAccess.ITaxRates')
  - [GetOrderTaxRate(query,apiName,userHash)](#M-Auth-ApiDataAccess-ITaxRates-GetOrderTaxRate-System-String,System-String,System-Byte[]- 'TaxDemo.ApiDataAccess.ITaxRates.GetOrderTaxRate(System.String,System.String,System.Byte[])')
- [ITaxServiceDbContext](#T-Auth-DataAccess-InterfaceContexts-ITaxServiceDbContext 'TaxDemo.DataAccess.InterfaceContexts.ITaxServiceDbContext')
- [ITax\`1](#T-Auth-ApiDataAccess-ITax`1 'TaxDemo.ApiDataAccess.ITax`1')
- [RatesRate](#T-Auth-Model-RatesRate 'TaxDemo.Model.RatesRate')
- [SubRate](#T-Auth-Model-SubRate 'TaxDemo.Model.SubRate')
- [SummayRates](#T-Auth-Model-SummayRates 'TaxDemo.Model.SummayRates')
- [TaxCalculationItemEvent](#T-Auth-Model-TaxCalculationItemEvent 'TaxDemo.Model.TaxCalculationItemEvent')
- [TaxItemEvent](#T-Auth-Model-TaxItemEvent 'TaxDemo.Model.TaxItemEvent')
- [TaxRatesByZIPCodeAPIAccessor](#T-Auth-ApiDataAccess-TaxRatesByZIPCodeAPIAccessor 'TaxDemo.ApiDataAccess.TaxRatesByZIPCodeAPIAccessor')
  - [#ctor(dbContext)](#M-Auth-ApiDataAccess-TaxRatesByZIPCodeAPIAccessor-#ctor-Auth-DataAccess-Contexts-DataContextApi,Auth-DataAccess-Contexts-DataContextTax- 'TaxDemo.ApiDataAccess.TaxRatesByZIPCodeAPIAccessor.#ctor(TaxDemo.DataAccess.Contexts.DataContextApi,TaxDemo.DataAccess.Contexts.DataContextTax)')
  - [_base](#F-Auth-ApiDataAccess-TaxRatesByZIPCodeAPIAccessor-_base 'TaxDemo.ApiDataAccess.TaxRatesByZIPCodeAPIAccessor._base')
  - [GetOrderTaxRate(query,apiName,userHash)](#M-Auth-ApiDataAccess-TaxRatesByZIPCodeAPIAccessor-GetOrderTaxRate-System-String,System-String,System-Byte[]- 'TaxDemo.ApiDataAccess.TaxRatesByZIPCodeAPIAccessor.GetOrderTaxRate(System.String,System.String,System.Byte[])')
  - [GetTaxInfo(action)](#M-Auth-ApiDataAccess-TaxRatesByZIPCodeAPIAccessor-GetTaxInfo-Auth-Model-RatesRate- 'TaxDemo.ApiDataAccess.TaxRatesByZIPCodeAPIAccessor.GetTaxInfo(TaxDemo.Model.RatesRate)')
- [TaxRatesController](#T-Auth-Controllers-TaxRatesController 'TaxDemo.Controllers.TaxRatesController')
  - [#ctor(t)](#M-Auth-Controllers-TaxRatesController-#ctor-Auth-DataAccess-InterfaceContexts-IAuthContext,Auth-ApiDataAccess-ITaxRates,Auth-DataAccess-InterfaceContexts-ITaxServiceDbContext,Microsoft-Extensions-Logging-ILogger{Auth-Controllers-TaxRatesController}- 'TaxDemo.Controllers.TaxRatesController.#ctor(TaxDemo.DataAccess.InterfaceContexts.IAuthContext,TaxDemo.ApiDataAccess.ITaxRates,TaxDemo.DataAccess.InterfaceContexts.ITaxServiceDbContext,Microsoft.Extensions.Logging.ILogger{TaxDemo.Controllers.TaxRatesController})')
  - [Get(user,password)](#M-Auth-Controllers-TaxRatesController-Get-System-String,System-String- 'TaxDemo.Controllers.TaxRatesController.Get(System.String,System.String)')
  - [GetQueriedTaxByFrequency(user,password)](#M-Auth-Controllers-TaxRatesController-GetQueriedTaxByFrequency-System-String,System-String,System-Decimal- 'TaxDemo.Controllers.TaxRatesController.GetQueriedTaxByFrequency(System.String,System.String,System.Decimal)')
  - [GetTaxInfo(query,zip)](#M-Auth-Controllers-TaxRatesController-GetTaxInfo-System-String,System-String,System-String,System-String- 'TaxDemo.Controllers.TaxRatesController.GetTaxInfo(System.String,System.String,System.String,System.String)')
  - [GetTaxInfoQuery(query,user,password)](#M-Auth-Controllers-TaxRatesController-GetTaxInfoQuery-System-String,System-String,System-String- 'TaxDemo.Controllers.TaxRatesController.GetTaxInfoQuery(System.String,System.String,System.String)')
- [TaxServiceDbContext](#T-Auth-DataAccess-TaxServiceDbContext 'TaxDemo.DataAccess.TaxServiceDbContext')
  - [Correction(id)](#M-Auth-DataAccess-TaxServiceDbContext-Correction-System-String- 'TaxDemo.DataAccess.TaxServiceDbContext.Correction(System.String)')
  - [GetQueriedTaxByFrequency()](#M-Auth-DataAccess-TaxServiceDbContext-GetQueriedTaxByFrequency 'TaxDemo.DataAccess.TaxServiceDbContext.GetQueriedTaxByFrequency')
  - [GetTaxItem()](#M-Auth-DataAccess-TaxServiceDbContext-GetTaxItem 'TaxDemo.DataAccess.TaxServiceDbContext.GetTaxItem')
  - [GetTaxItems()](#M-Auth-DataAccess-TaxServiceDbContext-GetTaxItems 'TaxDemo.DataAccess.TaxServiceDbContext.GetTaxItems')
  - [SaveChanges()](#M-Auth-DataAccess-TaxServiceDbContext-SaveChanges-Auth-Model-RatesRate- 'TaxDemo.DataAccess.TaxServiceDbContext.SaveChanges(TaxDemo.Model.RatesRate)')

<a name='T-Auth-DataAccess-ApiDbContext'></a>
## ApiDbContext `type`

##### Namespace

TaxDemo.DataAccess

##### Summary

Api Database Access to obtain the API key using authenticated user
This maps the user to each API key which the user is authorized to use

<a name='M-Auth-DataAccess-ApiDbContext-#ctor-Auth-DataAccess-Contexts-DataContextApi-'></a>
### #ctor(context) `constructor`

##### Summary

Inject context this is how the base implementation should be throught the
application as to abstract the access to Database

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [TaxDemo.DataAccess.Contexts.DataContextApi](#T-Auth-DataAccess-Contexts-DataContextApi 'TaxDemo.DataAccess.Contexts.DataContextApi') |  |

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

Find if the user is in Database

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

Authentication API Access for Gateway authentication method

<a name='M-Auth-Controllers-AuthController-#ctor-Auth-DataAccess-InterfaceContexts-IAuthContext,Auth-DataAccess-InterfaceContexts-IApiDbContext,Microsoft-Extensions-Configuration-IConfiguration,Microsoft-Extensions-Logging-ILogger{Auth-Controllers-AuthController}-'></a>
### #ctor(repo,config,logger) `constructor`

##### Summary

Constructor using IoC

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| repo | [TaxDemo.DataAccess.InterfaceContexts.IAuthContext](#T-Auth-DataAccess-InterfaceContexts-IAuthContext 'TaxDemo.DataAccess.InterfaceContexts.IAuthContext') |  |
| config | [TaxDemo.DataAccess.InterfaceContexts.IApiDbContext](#T-Auth-DataAccess-InterfaceContexts-IApiDbContext 'TaxDemo.DataAccess.InterfaceContexts.IApiDbContext') |  |
| logger | [Microsoft.Extensions.Configuration.IConfiguration](#T-Microsoft-Extensions-Configuration-IConfiguration 'Microsoft.Extensions.Configuration.IConfiguration') |  |

<a name='M-Auth-Controllers-AuthController-Login-Auth-Model-AuthRegisterDto-'></a>
### Login(user) `method`

##### Summary

Standard login method using jwt tokens
 [HttpPost("login")]

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

authorization as the assigning of api keys
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

To see if a user exists before attempting authorization process
providing a layer of protection against brute force attacks

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

This is the authorization levels for an employee
given the level determines the privileges

<a name='T-Auth-Model-AuthModel'></a>
## AuthModel `type`

##### Namespace

TaxDemo.Model

##### Summary

Main authentication model to find authorization levels
to register users or login

<a name='T-Auth-Model-AuthRegisterDto'></a>
## AuthRegisterDto `type`

##### Namespace

TaxDemo.Model

##### Summary

Smaller dto as to not expose the hash fields to a user

<a name='T-Auth-Business-Calculate'></a>
## Calculate `type`

##### Namespace

TaxDemo.Business

##### Summary

Calculate the tax for an order using taxjar

<a name='M-Auth-Business-Calculate-CalculatedTax-Auth-Model-RatesRate,System-Decimal-'></a>
### CalculatedTax(item,amount) `method`

##### Summary

This method uses the (combined tax rate) field from TaxJar

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| item | [TaxDemo.Model.RatesRate](#T-Auth-Model-RatesRate 'TaxDemo.Model.RatesRate') |  |
| amount | [System.Decimal](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Decimal 'System.Decimal') |  |

<a name='T-Auth-Controllers-CalculationsController'></a>
## CalculationsController `type`

##### Namespace

TaxDemo.Controllers

##### Summary

gives access to the calculated DB
and the function to calculate the rates for an order

<a name='M-Auth-Controllers-CalculationsController-#ctor-Auth-DataAccess-InterfaceContexts-IAuthContext,Auth-ApiDataAccess-ICalculatorApiAccessor,Auth-DataAccess-InterfaceContexts-ICalculateDbContext,Microsoft-Extensions-Logging-ILogger{Auth-Controllers-CalculationsController},Auth-Business-ICalculate-'></a>
### #ctor(t) `constructor`

##### Summary

Access To the TaxJar API

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| t | [TaxDemo.DataAccess.InterfaceContexts.IAuthContext](#T-Auth-DataAccess-InterfaceContexts-IAuthContext 'TaxDemo.DataAccess.InterfaceContexts.IAuthContext') |  |

<a name='M-Auth-Controllers-CalculationsController-Get-System-Decimal,System-String,System-String,System-String-'></a>
### Get(amount,zip,user,password) `method`

##### Summary

Tax Jar Endpoint For Calculator

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| amount | [System.Decimal](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Decimal 'System.Decimal') |  |
| zip | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| user | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| password | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Auth-Controllers-CalculationsController-Get-System-String,System-String,System-String,System-String,System-String-'></a>
### Get(amount,query,apiname,user,password) `method`

##### Summary

Access to assign API keys to Employees on a no Trust Basis

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| amount | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| query | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| apiname | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| user | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| password | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Auth-Controllers-CalculationsController-Get-System-String,System-String-'></a>
### Get(user,password) `method`

##### Summary

Endpoint to obtain all prior calculated orders

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| user | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| password | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='T-Auth-DataAccess-CalculatorDbContext'></a>
## CalculatorDbContext `type`

##### Namespace

TaxDemo.DataAccess

##### Summary

Calculation Db access
the data from tax rates can be accessed either DB or API

<a name='M-Auth-DataAccess-CalculatorDbContext-#ctor-Auth-DataAccess-Contexts-DataContextCalc-'></a>
### #ctor(context) `constructor`

##### Summary

Injecting the shared DB context into the controller
TODO Abstract db from controller in separate class

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [TaxDemo.DataAccess.Contexts.DataContextCalc](#T-Auth-DataAccess-Contexts-DataContextCalc 'TaxDemo.DataAccess.Contexts.DataContextCalc') |  |

<a name='T-Auth-ApiDataAccess-CalculatorTaxTatesAPIAccessor'></a>
## CalculatorTaxTatesAPIAccessor `type`

##### Namespace

TaxDemo.ApiDataAccess

##### Summary

Main calculation method for all tax calculations

<a name='M-Auth-ApiDataAccess-CalculatorTaxTatesAPIAccessor-#ctor-Auth-DataAccess-Contexts-DataContextApi-'></a>
### #ctor(contex) `constructor`

##### Summary

Concrete implemnetation of the interface which also uses the Api access for authorization

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| contex | [TaxDemo.DataAccess.Contexts.DataContextApi](#T-Auth-DataAccess-Contexts-DataContextApi 'TaxDemo.DataAccess.Contexts.DataContextApi') |  |

<a name='M-Auth-ApiDataAccess-CalculatorTaxTatesAPIAccessor-GetOrderTaxRate-System-String,System-String,System-Byte[]-'></a>
### GetOrderTaxRate() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-Auth-ApiDataAccess-CalculatorTaxTatesAPIAccessor-GetTaxInfo-Auth-Model-RatesRate-'></a>
### GetTaxInfo(action) `method`

##### Summary

TODO Dynamic tax info retrieval

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| action | [TaxDemo.Model.RatesRate](#T-Auth-Model-RatesRate 'TaxDemo.Model.RatesRate') |  |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.NotImplementedException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.NotImplementedException 'System.NotImplementedException') |  |

<a name='T-Auth-DataAccess-Contexts-DataContextCalc'></a>
## DataContextCalc `type`

##### Namespace

TaxDemo.DataAccess.Contexts

##### Summary

Calculator Interface implements Save To Sqlite DB

<a name='T-Auth-DataAccess-Contexts-DataContextTax'></a>
## DataContextTax `type`

##### Namespace

TaxDemo.DataAccess.Contexts

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

TaxDemo.Extention

##### Summary

Extenstion method  fir the Http response to return the error messages

<a name='T-Auth-DataAccess-InterfaceContexts-IApiDbContext'></a>
## IApiDbContext `type`

##### Namespace

TaxDemo.DataAccess.InterfaceContexts

##### Summary

Api Context for access and storage of the
configured api keys for authenticated users

<a name='M-Auth-DataAccess-InterfaceContexts-IApiDbContext-GetApiKey-System-String,System-Byte[]-'></a>
### GetApiKey(apiName,compareHash) `method`

##### Summary

Api key access function

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| apiName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| compareHash | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') |  |

<a name='M-Auth-DataAccess-InterfaceContexts-IApiDbContext-SaveChanges-Auth-Model-ApiDbItem-'></a>
### SaveChanges(item) `method`

##### Summary

Save changes or new api keys the Item takes
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

<a name='T-Auth-DataAccess-InterfaceContexts-IAuthContext'></a>
## IAuthContext `type`

##### Namespace

TaxDemo.DataAccess.InterfaceContexts

##### Summary

Interface for Authorization calls

<a name='M-Auth-DataAccess-InterfaceContexts-IAuthContext-GetUserHash-System-String,System-String-'></a>
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

<a name='M-Auth-DataAccess-InterfaceContexts-IAuthContext-Login-System-String,System-String-'></a>
### Login(user,password) `method`

##### Summary

Login consisting of User Password

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| user | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| password | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Auth-DataAccess-InterfaceContexts-IAuthContext-Register-Auth-Model-AuthModel,System-String-'></a>
### Register(username,password,address1,address2,city,zip) `method`

##### Summary

Register User Interface

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| username | [TaxDemo.Model.AuthModel](#T-Auth-Model-AuthModel 'TaxDemo.Model.AuthModel') |  |
| password | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Auth-DataAccess-InterfaceContexts-IAuthContext-UserExists-System-String-'></a>
### UserExists(username) `method`

##### Summary

User Lookup by Username

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| username | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='T-Auth-DataAccess-InterfaceContexts-IBaseDbContext'></a>
## IBaseDbContext `type`

##### Namespace

TaxDemo.DataAccess.InterfaceContexts

##### Summary

This is the base interface for the DB access functions

<a name='M-Auth-DataAccess-InterfaceContexts-IBaseDbContext-SaveChanges-Auth-Model-TaxCalculationItemEvent-'></a>
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

<a name='T-Auth-Business-ICalculate'></a>
## ICalculate `type`

##### Namespace

TaxDemo.Business

##### Summary

The business logic interface

<a name='T-Auth-DataAccess-InterfaceContexts-ICalculateDbContext'></a>
## ICalculateDbContext `type`

##### Namespace

TaxDemo.DataAccess.InterfaceContexts

##### Summary

Calculator class interface

<a name='T-Auth-ApiDataAccess-ICalculatorApiAccessor'></a>
## ICalculatorApiAccessor `type`

##### Namespace

TaxDemo.ApiDataAccess

##### Summary

Icalc rates access to the TaxRates over the Get Order Function
///

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

Interface for all tax rate endpoints

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| query | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| apiName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| userHash | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') |  |

<a name='T-Auth-DataAccess-InterfaceContexts-ITaxServiceDbContext'></a>
## ITaxServiceDbContext `type`

##### Namespace

TaxDemo.DataAccess.InterfaceContexts

##### Summary

The tax item is the configuration of Ibase Context

<a name='T-Auth-ApiDataAccess-ITax`1'></a>
## ITax\`1 `type`

##### Namespace

TaxDemo.ApiDataAccess

##### Summary

Serves as the extenstion for the memento pattern

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='T-Auth-Model-RatesRate'></a>
## RatesRate `type`

##### Namespace

TaxDemo.Model

##### Summary

Rates is the wrapper for the rate class so that JSON can serialize and deserialize

<a name='T-Auth-Model-SubRate'></a>
## SubRate `type`

##### Namespace

TaxDemo.Model

##### Summary

The rate is the main object at this point
this will carry oll the information needed

<a name='T-Auth-Model-SummayRates'></a>
## SummayRates `type`

##### Namespace

TaxDemo.Model

##### Summary

Has not been implemented yet but will hold all the summary elements returned form TaxJar

<a name='T-Auth-Model-TaxCalculationItemEvent'></a>
## TaxCalculationItemEvent `type`

##### Namespace

TaxDemo.Model

##### Summary

This is the data object responsible for transporting and storing the
calculated results from the api calls

<a name='T-Auth-Model-TaxItemEvent'></a>
## TaxItemEvent `type`

##### Namespace

TaxDemo.Model

##### Summary

Tax Item information for DB storage for possible later
statistical analysis.

<a name='T-Auth-ApiDataAccess-TaxRatesByZIPCodeAPIAccessor'></a>
## TaxRatesByZIPCodeAPIAccessor `type`

##### Namespace

TaxDemo.ApiDataAccess

##### Summary

Tax Rate retrieval
Access the APIDb directly
TODO In Future the API DB access should call class an not access the DB directly

<a name='M-Auth-ApiDataAccess-TaxRatesByZIPCodeAPIAccessor-#ctor-Auth-DataAccess-Contexts-DataContextApi,Auth-DataAccess-Contexts-DataContextTax-'></a>
### #ctor(dbContext) `constructor`

##### Summary

Database context injection according to design

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| dbContext | [TaxDemo.DataAccess.Contexts.DataContextApi](#T-Auth-DataAccess-Contexts-DataContextApi 'TaxDemo.DataAccess.Contexts.DataContextApi') |  |

<a name='F-Auth-ApiDataAccess-TaxRatesByZIPCodeAPIAccessor-_base'></a>
### _base `constants`

<a name='M-Auth-ApiDataAccess-TaxRatesByZIPCodeAPIAccessor-GetOrderTaxRate-System-String,System-String,System-Byte[]-'></a>
### GetOrderTaxRate(query,apiName,userHash) `method`

##### Summary

Get Tax Rates for a query

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| query | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| apiName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| userHash | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') |  |

<a name='M-Auth-ApiDataAccess-TaxRatesByZIPCodeAPIAccessor-GetTaxInfo-Auth-Model-RatesRate-'></a>
### GetTaxInfo(action) `method`

##### Summary

TODO resolve any requests to the Database on the stored rates regions types

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| action | [TaxDemo.Model.RatesRate](#T-Auth-Model-RatesRate 'TaxDemo.Model.RatesRate') |  |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.NotImplementedException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.NotImplementedException 'System.NotImplementedException') |  |

<a name='T-Auth-Controllers-TaxRatesController'></a>
## TaxRatesController `type`

##### Namespace

TaxDemo.Controllers

##### Summary

Auth

<a name='M-Auth-Controllers-TaxRatesController-#ctor-Auth-DataAccess-InterfaceContexts-IAuthContext,Auth-ApiDataAccess-ITaxRates,Auth-DataAccess-InterfaceContexts-ITaxServiceDbContext,Microsoft-Extensions-Logging-ILogger{Auth-Controllers-TaxRatesController}-'></a>
### #ctor(t) `constructor`

##### Summary

Access To the TaxJar API

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| t | [TaxDemo.DataAccess.InterfaceContexts.IAuthContext](#T-Auth-DataAccess-InterfaceContexts-IAuthContext 'TaxDemo.DataAccess.InterfaceContexts.IAuthContext') |  |

<a name='M-Auth-Controllers-TaxRatesController-Get-System-String,System-String-'></a>
### Get(user,password) `method`

##### Summary

Retuen all rates

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| user | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| password | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Auth-Controllers-TaxRatesController-GetQueriedTaxByFrequency-System-String,System-String,System-Decimal-'></a>
### GetQueriedTaxByFrequency(user,password) `method`

##### Summary

Retuen all rates above x from the database

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| user | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| password | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Auth-Controllers-TaxRatesController-GetTaxInfo-System-String,System-String,System-String,System-String-'></a>
### GetTaxInfo(query,zip) `method`

##### Summary

hash obtained from the password to retrieve the API Key to make

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| query | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| zip | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Auth-Controllers-TaxRatesController-GetTaxInfoQuery-System-String,System-String,System-String-'></a>
### GetTaxInfoQuery(query,user,password) `method`

##### Summary

Get Tax info for region of interest

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| query | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| user | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| password | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='T-Auth-DataAccess-TaxServiceDbContext'></a>
## TaxServiceDbContext `type`

##### Namespace

TaxDemo.DataAccess

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

<a name='M-Auth-DataAccess-TaxServiceDbContext-GetQueriedTaxByFrequency'></a>
### GetQueriedTaxByFrequency() `method`

##### Summary

Get all calculated items

##### Returns



##### Parameters

This method has no parameters.

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

<a name='M-Auth-DataAccess-TaxServiceDbContext-SaveChanges-Auth-Model-RatesRate-'></a>
### SaveChanges() `method`

##### Summary

Save changes to the Tax Item Db

##### Returns



##### Parameters

This method has no parameters.
