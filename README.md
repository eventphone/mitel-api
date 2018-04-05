# mitel-api

.NET Library for the [SIP-DECT OM Application XML Interface](http://www.mitel.com/sites/default/files/aad-0384_OM_AXI_OM_Rel_6.1_0.pdf) used by Mitel OMM. This project was inspired by [python-mitel](https://github.com/thomasDOTde/python-mitel/).

## status
**very early and broken pre-alpha**

Currently only the base types, events and functions are implemented (as needed). The library is fully async and also supports events sent from OMM. All functionality is based on the publicly available api documentation (v6.1) from mitel, wireshark traces captured from OMP to OMM and MOM to OMM and contains some *undocumented* features like `ppnOld` on `PPUserType` or `SetPP`.

## usage

### Login

``` csharp
var client = new OmmClient("example.com");
await _client.LoginAsync("omm", "god");
```

### Request / Reponse

``` csharp
var user = new PPUserType()
{
    Name = "John Doe",
    Num = "1337",
    Hierarchy1 = "Lorem Ipsum",
    AddId = "1337",
    Pin = "0000",
    SipAuthId = "1337",
    SipPw = "god"
};
var user = await client.CreatePPUser(user, cancellationToken);
```

### Events

``` csharp
var resetEvent = new ManualResetEventSlim();
//attach event handler
client.DECTSubscriptionModeChanged += (s, e) =>
{
    var data = e.Event;
    Console.WriteLine($"{data.Mode}");
    resetEvent.Set();
};
//subscribe to event
await client.Subscribe(EventType.DECTSubscriptionMode, cancellationToken);
//wait for event
resetEvent.Wait(TimeSpan.FromSeconds(5));
```