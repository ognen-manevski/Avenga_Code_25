using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;

namespace NotesApp.Helpers;


public static class LoggingConfigurationHelper
{
    // [2026-09-16 INF] Message 
    // Exception
    private const string OutputTemplate = "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}";

    public static ILogger CreateSerilogLogger()
    {
        return new LoggerConfiguration()
            .MinimumLevel.Information()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .MinimumLevel.Override("System", LogEventLevel.Information)

            // Enrichers - non mandatory, but useful for adding additional context to log events
            .Enrich.FromLogContext()
            .Enrich.WithMachineName()
            .Enrich.WithThreadId()

            //writing
            .WriteTo.Console(outputTemplate: OutputTemplate, restrictedToMinimumLevel: LogEventLevel.Debug)
            .WriteTo.File(
                path: "Logs/notesapp-.txt",
                rollingInterval: RollingInterval.Day,
                retainedFileCountLimit: 7,
                outputTemplate: OutputTemplate)

            //with json formatting
            .WriteTo.File(
                path: "Logs/notesapp-.json",
                rollingInterval: RollingInterval.Day,
                formatter: new CompactJsonFormatter())  
            
            //write to db
            .WriteTo.MSSqlServer




            .CreateLogger();
    }


}
