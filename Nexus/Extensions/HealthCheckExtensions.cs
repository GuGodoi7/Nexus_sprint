using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Net.Mime;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Nexus.Extensions
{
    public class HealthCheckExtensions
    {
        public static Task WriteResponse(HttpContext context, HealthReport report)
        {
            JsonSerializerOptions jsonSerializerOptions = new()
            {
                WriteIndented = false,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            string json = JsonSerializer.Serialize(
                new
                {
                    Status = report.Status.ToString(),
                    Duration = report.TotalDuration,
                    Info = report.Entries.Select(entry =>
                        new
                        {
                            entry.Key,
                            entry.Value.Description,
                            entry.Value.Duration,
                            Status = Enum.GetName(typeof(HealthStatus), entry.Value.Status),
                            Error = entry.Value.Exception?.Message,
                            entry.Value.Data
                        }).ToList()
                }, jsonSerializerOptions);

            context.Response.ContentType = MediaTypeNames.Application.Json;

            return context.Response.WriteAsync(json);
        }
    }
}
