using Business.Application.DTOs.Venues;
using Business.Model.Entities.Venues;
using Xtech.Common.Pagination;

namespace Business.Application.Services.Venues
{
    public interface IVenueService
    {
        VenueDto CreateVenue(CreateVenueDto venue, int? artOrganizationId);
        VenueDto GetVenue(int id);
        PagedList<VenueDto> ListVenues(PagedListParams<VenueFilters> listParams);
        VenueDto EditVenue(int id, VenueDto venueDto);
        void DeleteVenue(int id);
    }
}
