using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace BestRestaurant.Models
{
  public class Review
  {
    public int ReviewId { get; set; }

    public string Rating { get; set; }

    public DateTime Date { get; set; }

    public int RestaurantId { get; set; }

    public Restaurant Restaurant { get; set; }

  }
}