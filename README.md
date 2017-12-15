# ServiceBusQueuesDemo

This is a slightly modified version of the MS Docs ServiceBus Queues guide. The primary difference is the use of `ServiceBusConnectionStringBuilder` to provide `TransportType.AmqpWebSockets` avoiding firewall issues it's possible to encounter on secure networks.

## Setup
From ServiceBus settings "Shared access policies" select a policy and from one of the connection strings take the `Endpoint`, `SharedAccessKeyName` and `SharedAccessKey` from the connection string:
```
Endpoint={THIS_ENDPOINT};SharedAccessKeyName={THIS_KEY_NAME};SharedAccessKey={THIS_KEY}
```
and add them along with the target queue name to the `GetConnectionStringBuilder()` named method parameters in `Program.cs`.

Make sure NuGet packages have restored before attempting to run.

## Running
Run the app locally from Visual Studio 2017 and enter 1 to add items to the queue, or run the app and enter 2 to read the items from the queue.