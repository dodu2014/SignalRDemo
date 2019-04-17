# SignalRDemo
asp.net core 中使用 signalR 的示例
本示例中引用了库: signalr, 通过js连接并注册响应方法, 并把结果打印出来.

### 现在存在的问题
我需要在自定义类中获取 DI 中的服务的示例. 如果是在控制器中获取 IHubContext 示例, 是可以正常使用的, 但通过 IServiceProvider 获取到的示例, 也非null, 但无法正常工作.

### IServiceProvider 方式获取IHubContext实例并广播的代码:
```c#
var _hc = ServicesContext.Provider.GetRequiredService<IHubContext<TestHub>>();
await _hc.Clients.All.SendAsync("OnResponse", new { desc = "from ServicesContext.Provider" });
```

_hc 是能获取到的, 但是广播无效...

希望高手们能指出问题所在... 非常感谢...