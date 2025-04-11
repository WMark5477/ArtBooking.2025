using Business.Application.DTOs.Events;
using Xtech.Common.Pagination;

namespace Business.Application.Services.Events
{
    public interface IArtEventService
    {
        ArtEventDto CreateEvent(CreateArtEventDto eventDto, int? artOrganizationId = null);
        ArtEventDto GetEvent(int id);
        PagedList<ArtEventDto> ListEvents(PagedListParams<ArtEventFilters> listParams);
        ArtEventDto EditEvent(int id, CreateArtEventDto eventDto);
        void DeleteEvent(int id);
    }
}