using System;

namespace SignalRDemo.Services
{
    /// <summary>
    /// 全局的服务上下文, 为静态类使用注入提供支持
    /// </summary>
    public static class ServicesContext
    {
        /// <summary>
        /// 服务提供商, 需要在 Startup 中初始化
        /// </summary>        
        public static IServiceProvider Provider { get; set; }

    }
}
