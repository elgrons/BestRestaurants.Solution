using Microsoft.AspNetCore.Mvc;
using BestRestaurant.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BestRestaurant.Controllers
{
  public class RestaurantsController : Controller
  {
    private readonly BestRestaurantContext _db;

    public RestaurantsController(BestRestaurantContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Restaurant> model = _db.Restaurants.Include(restaurant => restaurant.Cuisine).ToList();
      ViewBag.PageTitle = "View All Restaurants";
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "CuisineType");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Restaurant restaurant)
    {
      if (restaurant.CuisineId == 0)
      {
        return RedirectToAction("Create");
      }
      _db.Restaurants.Add(restaurant);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Restaurant thisRestaurant = _db.Restaurants
          .Include(restaurant => restaurant.Cuisine)
          .Include(restaurant => restaurant.JoinEntities)
          .ThenInclude(join => join.Review)
          .FirstOrDefault(restaurant => restaurant.RestaurantId == id);
      return View(thisRestaurant);
    }

    public ActionResult Edit(int id)
    {
      Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
      ViewBag.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "CuisineType");
      return View(thisRestaurant);
    }

    [HttpPost]
    public ActionResult Edit(Restaurant restaurant)
    {
        _db.Restaurants.Update(restaurant);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
        Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
        return View(thisRestaurant);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
        Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
        _db.Restaurants.Remove(thisRestaurant);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult AddReview(int id)
    {
      Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurants => restaurants.RestaurantId == id);
      ViewBag.ReviewId = new SelectList(_db.Reviews, "ReviewId", "Rating");
      return View(thisRestaurant);
    }

    [HttpPost]
    public ActionResult AddTag(Restaurant restaurant, int reviewId)
    {
      #nullable enable
      RestaurantReview? joinEntity = _db.RestaurantReviews.FirstOrDefault(join => (join.ReviewId == reviewId && join.RestaurantId == restaurant.RestaurantId));
      #nullable disable
      if (joinEntity == null && reviewId != 0)
      {
        _db.RestaurantReviews.Add(new RestaurantReview() { ReviewId = reviewId, RestaurantId = restaurant.RestaurantId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = restaurant.RestaurantId });
    }

    [HttpPost]
    public ActionResult DeleteJoin(int joinId)
    {
      RestaurantReview joinEntry = _db.RestaurantReviews.FirstOrDefault(entry => entry.RestaurantReviewId == joinId);
      _db.RestaurantReviews.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}