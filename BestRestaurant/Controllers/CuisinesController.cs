using Microsoft.AspNetCore.Mvc;
using BestRestaurant.Models;
using System.Collections.Generic;
using System.Linq;

namespace BestRestaurant.Controllers
{
  public class CuisinesController : Controller
  {
    private readonly BestRestaurantContext _db;

    public CuisinesController(BestRestaurantContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Cuisine> model = _db.Cuisines.ToList();
      return View(model);
    }
  }
}