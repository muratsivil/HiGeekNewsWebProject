using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiGeekNewsWebProject.Business.Logger
{
    public class LoggerProvider : ILoggerProvider
    {
        IWebHostEnvironment _hostEnvironment;

        public LoggerProvider(IWebHostEnvironment hostEnvironment) => this._hostEnvironment = hostEnvironment;

        public ILogger CreateLogger(string categoryName) => new SystemLogger(_hostEnvironment);

        public void Dispose() => throw new NotImplementedException();
    }
}
