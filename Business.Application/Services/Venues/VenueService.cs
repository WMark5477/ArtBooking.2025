using AutoMapper;
using Business.Application.DTOs.Venues;
using Business.Model.Data;
using Business.Model.Entities.Venues;
using Xtech.Common.Pagination;

namespace Business.Application.Services.Venues
{
    public class VenueService : IVenueService
    {
        private readonly ArtBookingDbContext dbContext;
        private readonly IMapper mapper;

        public VenueService(ArtBookingDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public VenueDto CreateVenue(CreateVenueDto venueDto, int? artOrganizationId = null) 
        {
            var venue = mapper.Map<Venue>(venueDto);
            if (!IsNameUnique(venueDto.Name))
            {
                throw new ArgumentException();
            }
            venue.CreatedAt = DateTime.UtcNow;
            venue.ArtOrganizationId = artOrganizationId ?? 0; // Set to 0 if null


            dbContext.Venues.Add(venue);
            dbContext.SaveChanges();

            return mapper.Map<VenueDto>(venue);
        }

        public void DeleteVenue(int id)
        {
            throw new NotImplementedException();
        }

        public VenueDto EditVenue(int id, VenueDto venueDto)
        {
            var existingVenue = dbContext.Venues.Find(id);
            if (existingVenue == null)
            {
                return null;
            }

            if (!IsNameUnique(venueDto.Name))
            {
                throw new ArgumentException();
            }

            existingVenue.Name = venueDto.Name;
            existingVenue.Description = venueDto.Description;
            existingVenue.Address = venueDto.Address;
            existingVenue.City = venueDto.City;
            existingVenue.State = venueDto.State;
            existingVenue.Country = venueDto.Country;
            existingVenue.PostalCode = venueDto.PostalCode;
            existingVenue.Email = venueDto.Email;
            existingVenue.PhoneNumber = venueDto.PhoneNumber;
            existingVenue.Website = venueDto.Website;
            existingVenue.Capacity = venueDto.Capacity;
            existingVenue.ImageUrl = venueDto.ImageUrl;
            existingVenue.ArtOrganizationId = venueDto.ArtOrganizationId;


            mapper.Map(venueDto, existingVenue);
            dbContext.SaveChanges();

            return mapper.Map<VenueDto>(existingVenue);
        }

        public VenueDto GetVenue(int id)
        {
            var venue = dbContext.Venues.Find(id);
            return venue != null ? mapper.Map<VenueDto>(venue) : null;
        }

        public PagedList<VenueDto> ListVenues(PagedListParams<VenueFilters> listParams)
        {
            var query = dbContext.Venues.AsQueryable();

            if (listParams.Filters != null)
            {
                if (!string.IsNullOrEmpty(listParams.Filters.Name))
                {
                    query = query.Where(v => v.Name.ToLower().Contains(listParams.Filters.Name.ToLower()));
                }
                if (!string.IsNullOrEmpty(listParams.Filters.Description))
                {
                    query = query.Where(v => v.Name.ToLower().Contains(listParams.Filters.Name.ToLower()));
                }
            }

            if (listParams.HasSort())
            {
                if (listParams.SortByFieldIs("Name"))
                {
                    query = listParams.IsSortByAsc()
                        ? query.OrderBy(v => v.Name)
                        : query.OrderByDescending(v => v.Name);
                }
                else
                {
                    query = query.OrderBy(v => v.Name);
                }
            }
            else
            {
                query = query.OrderBy(v => v.Name);
            }

            var result = query.AsPagedList(listParams.PageNumber, listParams.PageSize);
            return new PagedList<VenueDto>(mapper.Map<List<VenueDto>>(result.Items), result.TotalCount, result.PageNumber, result.PageSize);
        }

        private bool IsNameUnique(string name)
        {
            var venue = dbContext.Venues.FirstOrDefault(v => v.Name == name);
            if (venue != null)
            {
                return false;
            }
            return true;
        }
    }
}
