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
JObject application = AcrosureClient.Application.Get("<application_id>").Result;
```

or

```c#
JObject application = await AcrosureClient.Application.Get("<application_id>");
```

#### Create

Create an application.

```c#
JObject createdApplication = AcrosureClient.Application.Create(@"{
  productId: '<product_id>', // required
  basic_data: {},
  package_options: {},
  additional_data: {},
  package_code: '<package_code>',
  attachments: []
}").Result;
```

or

```c#
JObject createdApplication = await AcrosureClient.Application.Create(@"{
  productId: '<product_id>', // required
  basic_data: {},
  package_options: {},
  additional_data: {},
  package_code: '<package_code>',
  attachments: []
}");
```

#### Update

Update an application.

```c#
JObject updatedApplication = AcrosureClient.Application.Update(@"{
  application_id: '<application_id>', // required
  basic_data: {},
  package_options: {},
  additional_data: {},
  package_code: '<package_code>',
  attachments: []
}").Result;
```

or

```c#
JObject updatedApplication = await AcrosureClient.Application.Update(@"{
  application_id: '<application_id>', // required
  basic_data: {},
  package_options: {},
  additional_data: {},
  package_code: '<package_code>',
  attachments: []
}");
```

#### Get packages

Get current application available packages.

```c#
JObject packages = AcrosureClient.Application.GetPackages(
  "<application_id>"
).Result;
```

or

```c#
JObject packages = await AcrosureClient.Application.GetPackages(
  "<application_id>"
);
```

#### Select package

Select package for current application.

```c#
JObject updatedApplication =  AcrosureClient.Application.selectPackage({
  application_id: "<application_id>",
  package_code: "<package_code>"
}).Result;
```

or

```c#
JObject updatedApplication = await AcrosureClient.Application.selectPackage({
  application_id: "<application_id>",
  package_code: "<package_code>"
});
```

#### Get package

Get selected package of current application.

```c#
JObject currentPackage = AcrosureClient.Application.GetPackage(
  "<application_id>"
).Result;
```

or

```c#
JObject currentPackage = await AcrosureClient.Application.GetPackage(
  "<application_id>"
);
```

#### Submit

Submit current application.

```c#
JObject submittedApplication = AcrosureClient.Application.Submit(
  "<application_id>"
).Result;
```

or

```c#
JObject submittedApplication = await AcrosureClient.Application.Submit(
  "<application_id>"
);
```

#### Confirm

Confirm current application.

_This function needs secret API key._

```c#
JObject confirmedApplication = await AcrosureClient.Application.Confirm(
  "<application_id>"
).Result;
```

or

```c#
JObject confirmedApplication = await AcrosureClient.Application.Confirm(
  "<application_id>"
);
```

#### List

List your applications .

```c#
JObject applications = AcrosureClient.Application.List().Result;
```

or

```c#
JObject applications = await AcrosureClient.Application.List();
```

### Product

#### Get

Get product with specified id.

```c#
JObject product = await AcrosureClient.Product.Get("<product_id>");
```

#### List

List your products.

```c#
JObject products = AcrosureClient.Product.List().Result;
```

or

```c#
JObject products = await AcrosureClient.Product.List();
```

### Policy

#### Get

Get policy with specified id.

```c#
JObject policy = AcrosureClient.policy.Get("<policy_id>").Result;
```

or

```c#
JObject policy = await AcrosureClient.policy.Get("<policy_id>");
```

#### List

List your policies .

```c#
JObject policies = await AcrosureClient.policy.List().Result;
```

or

```c#
JObject policies = await AcrosureClient.policy.List();
```

### Data

#### Get

Get values for a handler (with or without dependencies, please refer to Acrosure API Document).

```c#
// Without dependencies
JObject values = AcrosureClient.Data.Get(@"{
  handler: "<some_handler>"
}").Result;

// With dependencies
JObject values = AcrosureClient.Data.Get(@"{
  handler: '<some_handler>',
  dependencies: ['<dependency_1>', '<dependency_2>']
}").Result;
```

or

```c#
// Without dependencies
JObject values = await AcrosureClient.Data.Get(@"{
  handler: "<some_handler>"
}");

// With dependencies
JObject values = await AcrosureClient.Data.Get(@"{
  handler: '<some_handler>',
  dependencies: ['<dependency_1>', '<dependency_2>']
}");
```

### Team

#### Get info

Get current team information.

```c#
const teamInfo = AcrosureClient.Team.getInfo().Result;
```

or

```c#
const teamInfo = await AcrosureClient.Team.getInfo();
```

### Other functionality

#### Verify webhook signature

Verify webhook signature by specify signature and raw data string. (Only Node.js environment)

```c#
bool isSignatureValid = AcrosureClient.verifySignature(
  "<signature>",
  @"{'data':'<raw_data>'}"
);
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
