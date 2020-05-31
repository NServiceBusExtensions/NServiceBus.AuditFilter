<!--
GENERATED FILE - DO NOT EDIT
This file was generated by [MarkdownSnippets](https://github.com/SimonCropp/MarkdownSnippets).
Source File: /readme.source.md
To change this file edit the source file and then run MarkdownSnippets.
-->

# <img src="/src/icon.png" height="30px"> NServiceBus.AuditFilter

[![Build status](https://ci.appveyor.com/api/projects/status/chhl6coclht4mm9h/branch/master?svg=true)](https://ci.appveyor.com/project/SimonCropp/nservicebus-AuditFilter)
[![NuGet Status](https://img.shields.io/nuget/v/NServiceBus.AuditFilter.svg)](https://www.nuget.org/packages/NServiceBus.AuditFilter/)

Add message auditing filtering functionality to [NServiceBus](https://docs.particular.net/nservicebus/operations/auditing).

<!-- toc -->
## Contents

  * [Community backed](#community-backed)
    * [Sponsors](#sponsors)
    * [Patrons](#patrons)
  * [Support via TideLift](#support-via-tidelift)
  * [Usage](#usage)
    * [Decorate messages with attributes](#decorate-messages-with-attributes)
    * [Add to EndpointConfiguration](#add-to-endpointconfiguration)
    * [Delegate filter fallback](#delegate-filter-fallback)
  * [Include/Exclude logic flow](#includeexclude-logic-flow)
  * [Sample](#sample)
    * [Decorate messages with attributes](#decorate-messages-with-attributes-1)
    * [Add to EndpointConfiguration](#add-to-endpointconfiguration-1)
  * [Security contact information](#security-contact-information)<!-- endtoc -->

<!--- StartOpenCollectiveBackers -->

[Already a Patron? skip past this section](#endofbacking)


## Community backed

**It is expected that all developers either [become a Patron](https://opencollective.com/nservicebusextensions/contribute/patron-6976) or have a [Tidelift Subscription](#support-via-tidelift) to use NServiceBusExtensions. [Go to licensing FAQ](https://github.com/NServiceBusExtensions/Home/#licensingpatron-faq)**


### Sponsors

Support this project by [becoming a Sponsor](https://opencollective.com/nservicebusextensions/contribute/sponsor-6972). The company avatar will show up here with a website link. The avatar will also be added to all GitHub repositories under the [NServiceBusExtensions organization](https://github.com/NServiceBusExtensions).


### Patrons

Thanks to all the backing developers. Support this project by [becoming a patron](https://opencollective.com/nservicebusextensions/contribute/patron-6976).

<img src="https://opencollective.com/nservicebusextensions/tiers/patron.svg?width=890&avatarHeight=60&button=false">

<a href="#" id="endofbacking"></a>

<!--- EndOpenCollectiveBackers -->


## Support via TideLift

Support is available via a [Tidelift Subscription](https://tidelift.com/subscription/pkg/nuget-nservicebus.auditfilter?utm_source=nuget-nservicebus.auditfilter&utm_medium=referral&utm_campaign=enterprise).


## NuGet package

https://nuget.org/packages/NServiceBus.AuditFilter/


## Usage


### Decorate messages with attributes

<!-- snippet: MessageToIncludeAudit -->
<a id='snippet-messagetoincludeaudit'/></a>
```cs
[IncludeInAudit]
public class MessageToIncludeAudit :
    IMessage
{
}
```
<sup><a href='/src/Sample/MessageToIncludeAudit.cs#L4-L10' title='File snippet `messagetoincludeaudit` was extracted from'>snippet source</a> | <a href='#snippet-messagetoincludeaudit' title='Navigate to start of snippet `messagetoincludeaudit`'>anchor</a></sup>
<a id='snippet-messagetoincludeaudit-1'/></a>
```cs
[IncludeInAudit]
public class MessageToIncludeAudit :
    IMessage
{
}
```
<sup><a href='/src/Tests/Snippets/MessageToIncludeAudit.cs#L4-L12' title='File snippet `messagetoincludeaudit` was extracted from'>snippet source</a> | <a href='#snippet-messagetoincludeaudit-1' title='Navigate to start of snippet `messagetoincludeaudit`'>anchor</a></sup>
<!-- endsnippet -->

<!-- snippet: MessageToExcludeFromAudit -->
<a id='snippet-messagetoexcludefromaudit'/></a>
```cs
[ExcludeFromAudit]
public class MessageToExcludeFromAudit :
    IMessage
{
}
```
<sup><a href='/src/Sample/MessageToExcludeFromAudit.cs#L4-L10' title='File snippet `messagetoexcludefromaudit` was extracted from'>snippet source</a> | <a href='#snippet-messagetoexcludefromaudit' title='Navigate to start of snippet `messagetoexcludefromaudit`'>anchor</a></sup>
<a id='snippet-messagetoexcludefromaudit-1'/></a>
```cs
[ExcludeFromAudit]
public class MessageToExcludeFromAudit :
    IMessage
{
}
```
<sup><a href='/src/Tests/Snippets/MessageToExcludeFromAudit.cs#L4-L12' title='File snippet `messagetoexcludefromaudit` was extracted from'>snippet source</a> | <a href='#snippet-messagetoexcludefromaudit-1' title='Navigate to start of snippet `messagetoexcludefromaudit`'>anchor</a></sup>
<!-- endsnippet -->


### Add to EndpointConfiguration

With include by default

<!-- snippet: DefaultIncludeInAudit -->
<a id='snippet-defaultincludeinaudit'/></a>
```cs
configuration.FilterAuditQueue(FilterResult.IncludeInAudit);
```
<sup><a href='/src/Tests/Snippets/Usage.cs#L8-L12' title='File snippet `defaultincludeinaudit` was extracted from'>snippet source</a> | <a href='#snippet-defaultincludeinaudit' title='Navigate to start of snippet `defaultincludeinaudit`'>anchor</a></sup>
<!-- endsnippet -->

With exclude by default

<!-- snippet: DefaultExcludeFromAudit -->
<a id='snippet-defaultexcludefromaudit'/></a>
```cs
configuration.FilterAuditQueue(FilterResult.ExcludeFromAudit);
```
<sup><a href='/src/Tests/Snippets/Usage.cs#L13-L17' title='File snippet `defaultexcludefromaudit` was extracted from'>snippet source</a> | <a href='#snippet-defaultexcludefromaudit' title='Navigate to start of snippet `defaultexcludefromaudit`'>anchor</a></sup>
<!-- endsnippet -->


### Delegate filter fallback

The fallback/default value can also be controlled by a delegate.

<!-- snippet: FilterAuditByDelegate -->
<a id='snippet-filterauditbydelegate'/></a>
```cs
configuration.FilterAuditQueue(
    filter: (instance, headers) =>
    {
        if (instance is MyMessage)
        {
            return FilterResult.ExcludeFromAudit;
        }

        return FilterResult.IncludeInAudit;
    });
```
<sup><a href='/src/Tests/Snippets/Usage.cs#L18-L31' title='File snippet `filterauditbydelegate` was extracted from'>snippet source</a> | <a href='#snippet-filterauditbydelegate' title='Navigate to start of snippet `filterauditbydelegate`'>anchor</a></sup>
<!-- endsnippet -->


## Include/Exclude logic flow

<img src="/src/flow.png" width="200px">


## Sample

The sample uses the [Learning Transport](https://docs.particular.net/transports/learning/) and the resultant messages can be viewed in the [Storage Directory](https://docs.particular.net/transports/learning/#usage-storage-directory).


### Decorate messages with attributes

<!-- snippet: MessageToExcludeFromAudit -->
<a id='snippet-messagetoexcludefromaudit'/></a>
```cs
[ExcludeFromAudit]
public class MessageToExcludeFromAudit :
    IMessage
{
}
```
<sup><a href='/src/Sample/MessageToExcludeFromAudit.cs#L4-L10' title='File snippet `messagetoexcludefromaudit` was extracted from'>snippet source</a> | <a href='#snippet-messagetoexcludefromaudit' title='Navigate to start of snippet `messagetoexcludefromaudit`'>anchor</a></sup>
<a id='snippet-messagetoexcludefromaudit-1'/></a>
```cs
[ExcludeFromAudit]
public class MessageToExcludeFromAudit :
    IMessage
{
}
```
<sup><a href='/src/Tests/Snippets/MessageToExcludeFromAudit.cs#L4-L12' title='File snippet `messagetoexcludefromaudit` was extracted from'>snippet source</a> | <a href='#snippet-messagetoexcludefromaudit-1' title='Navigate to start of snippet `messagetoexcludefromaudit`'>anchor</a></sup>
<!-- endsnippet -->

<!-- snippet: MessageToIncludeAudit -->
<a id='snippet-messagetoincludeaudit'/></a>
```cs
[IncludeInAudit]
public class MessageToIncludeAudit :
    IMessage
{
}
```
<sup><a href='/src/Sample/MessageToIncludeAudit.cs#L4-L10' title='File snippet `messagetoincludeaudit` was extracted from'>snippet source</a> | <a href='#snippet-messagetoincludeaudit' title='Navigate to start of snippet `messagetoincludeaudit`'>anchor</a></sup>
<a id='snippet-messagetoincludeaudit-1'/></a>
```cs
[IncludeInAudit]
public class MessageToIncludeAudit :
    IMessage
{
}
```
<sup><a href='/src/Tests/Snippets/MessageToIncludeAudit.cs#L4-L12' title='File snippet `messagetoincludeaudit` was extracted from'>snippet source</a> | <a href='#snippet-messagetoincludeaudit-1' title='Navigate to start of snippet `messagetoincludeaudit`'>anchor</a></sup>
<!-- endsnippet -->


### Add to EndpointConfiguration

<!-- snippet: Enable -->
<a id='snippet-enable'/></a>
```cs
endpointConfiguration.AuditProcessedMessagesTo("audit");
endpointConfiguration.FilterAuditQueue(
    defaultFilter: FilterResult.IncludeInAudit);
```
<sup><a href='/src/Sample/Program.cs#L19-L25' title='File snippet `enable` was extracted from'>snippet source</a> | <a href='#snippet-enable' title='Navigate to start of snippet `enable`'>anchor</a></sup>
<!-- endsnippet -->


## Security contact information

To report a security vulnerability, use the [Tidelift security contact](https://tidelift.com/security). Tidelift will coordinate the fix and disclosure.


## Icon

[Audit](https://thenounproject.com/term/audit/618766/) designed by [Delwar Hossain](https://thenounproject.com/delwar/) from [The Noun Project](https://thenounproject.com/).
