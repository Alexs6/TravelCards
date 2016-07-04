using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication3;
using System.Collections.Generic;
using System.Text;

namespace TravelCardTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestEquals()
        {
            var travelCardList = new List<TravelCard> { 
             new TravelCard { DeparturePoint = "Мельбурн", DestinationPoint ="Кельн"},
             new TravelCard { DeparturePoint = "Москва", DestinationPoint ="Париж"},
             new TravelCard { DeparturePoint = "Кельн", DestinationPoint ="Москва"}
            };

            var sortedTravelCardList = new List<TravelCard> { 
             new TravelCard { DeparturePoint = "Мельбурн", DestinationPoint ="Кельн"},
             new TravelCard { DeparturePoint = "Кельн", DestinationPoint ="Москва"},
             new TravelCard { DeparturePoint = "Москва", DestinationPoint ="Париж"}
            };

            var travelCardService = new TravelCardService();
            var error = travelCardService.SortTravelCards(ref travelCardList);

            CollectionAssert.AreEqual(sortedTravelCardList, travelCardList, new TravelCardComparer());
            Assert.AreEqual(error, string.Empty);
        }
        [TestMethod]
        public void TestTravelCardListIncorrectContent()
        {
            var travelCardList = new List<TravelCard> { 
             new TravelCard { DeparturePoint = "Мельбурн", DestinationPoint ="Кельн"},
             new TravelCard { DestinationPoint ="Париж"},
             new TravelCard { DeparturePoint = "Кельн", DestinationPoint ="Москва"}
            };

      
            var travelCardService = new TravelCardService();
            var error = travelCardService.SortTravelCards(ref travelCardList);

            Assert.AreEqual(error, TravelCardServiceErrors.TravelCardListIncorrectContent);
        }
        [TestMethod]
        public void TestTravelCardListEmpty()
        {
            var travelCardList = new List<TravelCard>();


            var travelCardService = new TravelCardService();
            var error = travelCardService.SortTravelCards(ref travelCardList);
            Assert.AreEqual(error, TravelCardServiceErrors.TravelCardListEmpty);
        }
        [TestMethod]
        public void TestTravelCardDepartureMissing()
        {
            var travelCardList = new List<TravelCard> { 
             new TravelCard { DeparturePoint = "Мельбурн", DestinationPoint ="Кельн"},
             new TravelCard { DeparturePoint = "Москва", DestinationPoint ="Париж"},
             new TravelCard { DeparturePoint = "Кельн", DestinationPoint ="Саратов"}
            };


            var travelCardService = new TravelCardService();
            var error = travelCardService.SortTravelCards(ref travelCardList);

            StringAssert.Contains(error, TravelCardServiceErrors.TravelCardDepartureMissing);
        }
    }
}
