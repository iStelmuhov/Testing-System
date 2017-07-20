using System;
using System.Diagnostics.Tracing;
using Microsoft.Practices.EnterpriseLibrary.SemanticLogging;
using Microsoft.Practices.Unity;

namespace TestingSystem.Dependencies.Logging
{
    public class LogListener : IDisposable
    {
        internal void OnStartup()
        {
            listenerInfo = FlatFileLog.CreateListener("testing_services.log");
            listenerInfo.EnableEvents(Log, EventLevel.LogAlways, TestSystemEventSource.Keywords.ServiceTracing);

            listenerErrors = FlatFileLog.CreateListener("testing_diagnostic.log");
            listenerErrors.EnableEvents(Log, EventLevel.LogAlways, TestSystemEventSource.Keywords.Diagnostic);

            Log.StartupSucceeded();
        }

        public void Dispose()
        {
            listenerInfo.DisableEvents(Log);
            listenerErrors.DisableEvents(Log);

            listenerInfo.Dispose();
            listenerErrors.Dispose();
        }


        [Dependency]
        protected TestSystemEventSource Log { get; set; }

        private EventListener listenerInfo;
        private EventListener listenerErrors;
    }
}