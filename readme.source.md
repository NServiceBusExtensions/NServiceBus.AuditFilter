# <img src="/src/icon.png" height="30px"> NServiceBus.Community.AuditFilter

[![Build status](https://img.shields.io/appveyor/build/SimonCropp/nservicebus-community-auditFilter)](https://ci.appveyor.com/project/SimonCropp/nservicebus-community-auditFilter)
[![NuGet Status](https://img.shields.io/nuget/v/NServiceBus.Community.AuditFilter.svg)](https://www.nuget.org/packages/NServiceBus.Community.AuditFilter/)

Add message auditing filtering functionality to [NServiceBus](https://docs.particular.net/nservicebus/operations/auditing).

**See [Milestones](../../milestones?state=closed) for release notes.**


<!--- StartOpenCollectiveBackers -->

[Already a Patron? skip past this section](#endofbacking)


## Community backed

**It is expected that all developers [become a Patron](https://opencollective.com/nservicebuscommunity/contribute/patron-6976) to use NServiceBus Community Extensions. [Go to licensing FAQ](https://github.com/NServiceBusCommunity/Home/#licensingpatron-faq)**


### Sponsors

Support this project by [becoming a Sponsor](https://opencollective.com/nservicebuscommunity/contribute/sponsor-6972). The company avatar will show up here with a website link. The avatar will also be added to all GitHub repositories under the [NServiceBusCommunity organization](https://github.com/NServiceBusCommunity).


### Patrons

Thanks to all the backing developers. Support this project by [becoming a patron](https://opencollective.com/nservicebuscommunity/contribute/patron-6976).

<img src="https://opencollective.com/nservicebuscommunity/tiers/patron.svg?width=890&avatarHeight=60&button=false">

<a href="#" id="endofbacking"></a>

<!--- EndOpenCollectiveBackers -->


## NuGet package

https://nuget.org/packages/NServiceBus.Community.AuditFilter/


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


## Icon

[Audit](https://thenounproject.com/term/audit/618766/) designed by [Delwar Hossain](https://thenounproject.com/delwar/) from [The Noun Project](https://thenounproject.com/).