using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace ConsoleApplication3
{
    public class TravelCardService
    {
        public string SortTravelCards(ref List<TravelCard> travelCardList)
        {

            var resultTravelCardList = new List<TravelCard>();
            #region Проверки

            if (travelCardList.Any(c => string.IsNullOrEmpty(c.DeparturePoint) || string.IsNullOrEmpty(c.DestinationPoint)))
            {
                return TravelCardServiceErrors.TravelCardListIncorrectContent;
            }
            if (!travelCardList.Any())
            {
                return TravelCardServiceErrors.TravelCardListEmpty;
            }

            #endregion
            #region Начальная инициализация

            var firstTravelCard = travelCardList.FirstOrDefault();
            resultTravelCardList.Add(firstTravelCard);
            string currentDestinationPoint = firstTravelCard.DestinationPoint;

            #endregion
            #region Построение метрики в цикле
            //Цикл продолжается, пока количество элементов в итоговом листе не станет равно количеству элементов в изначальном листе
            do
            {
                var nextTravelCard = travelCardList.FirstOrDefault(c => c.DeparturePoint == currentDestinationPoint);
                if (nextTravelCard == null)
                {
                    return TravelCardServiceErrors.TravelCardDepartureMissing + currentDestinationPoint;
                }
                resultTravelCardList.Add(nextTravelCard);
                currentDestinationPoint = nextTravelCard.DestinationPoint;
               
            } while ( resultTravelCardList.Count != travelCardList.Count);

            #endregion
            travelCardList = resultTravelCardList;
            return string.Empty;
        }
    }
}
