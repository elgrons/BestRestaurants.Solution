using System.Collections.Generic;
using System;

namespace BestRestaurant.Models
{
  public class Cuisine
  {
    public int CuisineId { get; set; }

    public string RestaurantName { get; set; }

    public string CuisineType { get; set; } =null!;

    public List<Restaurant> Restaurants { get; set; }

  }
}