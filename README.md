# acrosure-dotnet-sdk

![Acrosure](./static/Acrosure-color.png)

.NET SDK for connecting with Acrosure Insurance Gateway

## Installation

Install via Install-Package :

`Install-Package acrosure-dotnet-sdk`

## Getting Started

Import Acrosure into your project.

```c#
using Acrosure;
```

Instantiate with an API key from [Acrosure Dashboard](https://dashboard.acrosure.com).

_If you're using this on client-side, DO NOT use your secret token._

```c#
AcrosureClient AcrosureClient  = new AcrosureClient("<your_api_key>")
```

## Basic Usage

AcrosureClient provides several objects such as `application`, `product`, etc. and associated APIs.

Any data will be inside an response object with `data` key, along with meta data, such as:

```json
{
  "data": { ... },
  "status": "ok",
  ...
}
```

AcrosureClient will return in Json.NET

Instantiate with Json.NET from [Json.NET](https://www.newtonsoft.com/json).

### Application

#### Get

Get application with specified id.

```c#
static async Task GetApplication()
{
  JObject application = await AcrosureClient.Application.Get("<application_id>")
}
static void Main()
{
  GetApplication().Wait();
}

```

#### Create

Create an application.

```c#
static async Task CreateApplication()
{
  JObject createdApplication = await AcrosureClient.Application.Create(@"{
    productId: '<product_id>', // required
    basic_data: {},
    package_options: {},
    additional_data: {},
    package_code: '<package_code>',
    attachments: []
  }")
}
static void Main()
{
  GetApplication().Wait();
}
```

#### Update

Update an application.

```c#
static async Task UpdateApplication()
{
  JObject updatedApplication = await AcrosureClient.Application.Update(@"{
    application_id: '<application_id>', // required
    basic_data: {},
    package_options: {},
    additional_data: {},
    package_code: '<package_code>',
    attachments: []
  }")
}
static void Main()
{
  UpdateApplication().Wait();
}
```

#### Get packages

Get current application available packages.

```c#
static async Task GetPackages()
{
  JObject packages = await AcrosureClient.Application.GetPackages(
    "<application_id>"
  )
}
static void Main()
{
  GetPackages().Wait();
}
```

#### Select package

Select package for current application.

```c#
static async Task SelectPackage()
{
  JObject updatedApplication = await AcrosureClient.Application.selectPackage({
    application_id: "<application_id>",
    package_code: "<package_code>"
  });
}
static void Main()
{
  SelectPackage().Wait();
}
```

#### Get package

Get selected package of current application.

```c#
static async Task GetPackage()
{
  JObject currentPackage = await AcrosureClient.Application.GetPackage(
    "<application_id>"
  );
}
static void Main()
{
  GetPackage().Wait();
}
```

#### Submit

Submit current application.

```c#
static async Task Submit()
{
  JObject submittedApplication = await AcrosureClient.Application.Submit(
    "<application_id>"
  );
}
static void Main()
{
  Submit().Wait();
}
```

#### Confirm

Confirm current application.

_This function needs secret API key._

```c#
static async Task Confirm()
{
  JObject confirmedApplication = await AcrosureClient.Application.Confirm(
    "<application_id>"
  );
}
static void Main()
{
  Confirm().Wait();
}
```

#### List

List your applications .

```c#
static async Task ListApplication()
{
  JObject applications = await AcrosureClient.Application.List();
}
static void Main()
{
  ListApplication().Wait();
}
```

### Product

#### Get

Get product with specified id.

```c#
static async Task GetProduct()
{
  JObject product = await AcrosureClient.Product.Get("<product_id>");
}
static void Main()
{
  GetProduct().Wait();
}
```

#### List

List your products.

```c#
static async Task ListProduct()
{
  JObject products = await AcrosureClient.Product.List();
}
static void Main()
{
  ListProduct().Wait();
}
```

### Policy

#### Get

Get policy with specified id.

```c#
static async Task GetPolicy()
{
  JObject policy = await AcrosureClient.policy.Get("<policy_id>");
}
static void Main()
{
  GetPolicy().Wait();
}
```

#### List

List your policies .

```c#
static async Task ListPolicies()
{
  JObject policies = await AcrosureClient.policy.List();
}
static void Main()
{
  ListPolicies().Wait();
}
```

### Data

#### Get

Get values for a handler (with or without dependencies, please refer to Acrosure API Document).

```c#
static async Task GetData()
{
  // Without dependencies
  JObject values = await AcrosureClient.Data.Get(@"{
    handler: "<some_handler>"
  }");

  // With dependencies
  JObject values = await AcrosureClient.Data.Get(@"{
    handler: '<some_handler>',
    dependencies: ['<dependency_1>', '<dependency_2>']
  }");
}
static void Main()
{
  GetData().Wait();
}
```

### Team

#### Get info

Get current team information.

```c#
static async Task GetTeam()
{
var teamInfo = await AcrosureClient.Team.getInfo();
}
static void Main()
{
  GetTeam().Wait();
}
```

### Other functionality

#### Verify webhook signature

Verify webhook signature by specify signature and raw data string. (Only Node.js environment)

```c#
static async Task VerifySignature()
{
  bool isSignatureValid = AcrosureClient.verifySignature(
    "<signature>",
    @"{'data':'<raw_data>'}"
  );
}
static void Main()
{
  VerifySignature().Wait();
}
```

## Advanced Usage

Please refer to [this document](https://acrosure.github.io/acrosure-js-sdk/AcrosureClient.html) for AcrosureClient usage.

And refer to [Acrosure API Document](https://docs.acrosure.com/docs/api-overall.html) for more details on Acrosure API.

## Associated Acrosure API endpoints

### Application

```
/applications/get
/applications/list
/applications/create
/applications/update
/applications/get-packages
/applications/get-package
/applications/select-package
/applications/submit
/applications/confirm
```

### Product

```
/products/get
/products/list
```

### Policy

```
/policies/get
/policies/list
```

### Data

```
/data/get
```

### Team

```
/teams/get-info
```
