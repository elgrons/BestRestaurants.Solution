using Microsoft.VisualStudio.TestTools.UnitTesting;
using BestRestaurant.Models;
using System.Collections.Generic; 
using System;

namespace BestRestaurant.Tests
{
  [TestClass]
  public class CuisineTests
  {
  [TestMethod]
    public void ClassNameConstructor_CreatesInstanceOfClassName_ClassName()
    {
      // Arrange
      ClassName newClass = new ClassName(2, 3, 8);
      // Act
      //not needed here
      // Assert
    Assert.AreEqual(typeof(ClassName), newClass.GetType());
    }
  }
}