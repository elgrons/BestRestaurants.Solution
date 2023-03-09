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

    public string Restaurant { get; set; }

    public string RestaurantId { get; set; }

  public List<RestaurantReview> JoinEntities { get;}

  }
}