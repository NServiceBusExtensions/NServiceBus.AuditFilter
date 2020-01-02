# <img src="/src/icon.png" height="30px"> NServiceBus.AuditFilter

[![Build status](https://ci.appveyor.com/api/projects/status/chhl6coclht4mm9h/branch/master?svg=true)](https://ci.appveyor.com/project/SimonCropp/nservicebus-AuditFilter)
[![NuGet Status](https://img.shields.io/nuget/v/NServiceBus.AuditFilter.svg)](https://www.nuget.org/packages/NServiceBus.AuditFilter/)

Add message auditing filtering functionality to [NServiceBus](https://docs.particular.net/nservicebus/operations/auditing).

toc

<!--- StartOpenCollectiveBackers -->

[Already a Patron? skip past this section](#endofbacking)


## Community backed

**It is expected that all developers [become a Patron](https://opencollective.com/nservicebusextensions/order/6976) to use this tool. [Go to licensing FAQ](https://github.com/NServiceBusExtensions/Home/#licensingpatron-faq)**

Thanks to the current backers.

<img src="https://opencollective.com/nservicebusextensions/tiers/patron.svg?width=890&avatarHeight=60&button=false">

<a href="#" id="endofbacking"></a>

<!--- EndOpenCollectiveBackers -->


## NuGet package

https://nuget.org/packages/NServiceBus.AuditFilter/


## Usage


### Decorate messages with attributes

snippet: MessageToIncludeAudit

snippet: MessageToExcludeFromAudit


### Add to EndpointConfiguration

With include by default

snippet: DefaultIncludeInAudit

With exclude by default

snippet: DefaultExcludeFromAudit


### Delegate filter fallback

The fallback/default value can also be controlled by a delegate.

snippet: FilterAuditByDelegate


## Include/Exclude logic flow

<img src="/src/flow.png" width="200px">


## Sample

The sample uses the [Learning Transport](https://docs.particular.net/transports/learning/) and the resultant messages can be viewed in the [Storage Directory](https://docs.particular.net/transports/learning/#usage-storage-directory).


### Decorate messages with attributes

snippet: MessageToExcludeFromAudit

snippet: MessageToIncludeAudit


### Add to EndpointConfiguration

snippet: Enable


## Release Notes

See [closed milestones](../../milestones?state=closed).


## Icon

[Audit](https://thenounproject.com/term/audit/618766/) designed by [Delwar Hossain](https://thenounproject.com/delwar/) from [The Noun Project](https://thenounproject.com/).