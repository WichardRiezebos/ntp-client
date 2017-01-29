# NtpClient
 
Portable NuGet library/package for communicating with ntp-server(s).

| | |
| --- | --- |
| **Build** | [![Build status](https://ci.appveyor.com/api/projects/status/pvnvw8q0qv3nr4r4?svg=true)](https://ci.appveyor.com/project/WichardRiezebos/ntp-client) |
| **NuGet** | [![NuGet](https://buildstats.info/nuget/NtpClient)](https://www.nuget.org/packages/NtpClient/) |
| **Gitter** | [![Join the chat at https://gitter.im/ntp-client/Lobby](https://badges.gitter.im/astar-navigator/Lobby.svg)](https://gitter.im/ntp-client/Lobby?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge) |

## Installation

Install the NuGet package using the command below,

```
Install-Package NtpClient
```

. . . or search for `NtpClient` in the NuGet index.

## Getting started
The code below is an example how to use the library.

```
using NtpClient;

var connection = new NtpConnection("pool.ntp.org");
var utcNow = connection.GetUtc(); 
```