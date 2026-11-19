using AddisEats.Api.Models;
using AddisEats.Api.Data;
using AddisEats.Api.DTOs;
using AddisEats.Api.Mappers;

namespace AddisEats.Api.Services.RestaurantServices;

public class RestaurantService : IRestaurantService
{
    public static readonly List<Restaurant> allRestaurants = SeedData.Restaurants;

    public Restaurant? GetById(int id)
    {
        return allRestaurants.FirstOrDefault(r => r.Id == id);
    }

    public PaginatedResultDTO<RestaurantDTO> GetAll(RestaurantQuery query)
    {
        var restaurants = allRestaurants
            .Where(r => query.Address == null ||
                        r.Address.Contains(query.Address))
            .Where(r => query.Name == null ||
                        r.Name.Contains(query.Name))
            .Where(r => query.IsActive == null ||
                        r.IsActive == query.IsActive)
            .OrderBy(r => r.Name)
            .ToList();

        var totalCount = restaurants.Count;

        var toReturn = restaurants
            .Skip((query.Page - 1) * query.PageSize)
            .Take(query.PageSize)
            .ToList();

        PaginatedResultDTO<RestaurantDTO> resultDTO = new PaginatedResultDTO<RestaurantDTO>
        {
            TotalCount = totalCount,
            Page = query.Page,
            PageSize = query.PageSize,
            Data = toReturn.Select(r => r.ToDTO()).ToList()
        };

        return resultDTO;
    }

    public List<Restaurant> GetAllActive()
    {
        return allRestaurants
            .Where(r => r.IsActive)
            .ToList();
    }
    public Restaurant createRestaurant(CreateRestaurantDTO createDTO)
    {
        var newRestaurant = new Restaurant
        {
            Id = allRestaurants.Max(r => r.Id) + 1,
            Name = createDTO.Name,
            Address = createDTO.Address,
            Phone = createDTO.Phone,
            //OwnerAddress = createDTO.OwnerAddress,
            IsActive = true
        };
        allRestaurants.Add(newRestaurant);
        return newRestaurant;
    }
}