using Core.Application.Features.Events.Queries.GetEventsExport;

namespace Core.Application.Contracts.Infrastructure
{
    public interface ICsvExporter
    {
        byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos);
    }
}
