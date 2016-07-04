using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication3
{
    public static class TravelCardServiceErrors
    {
        public const string TravelCardListIncorrectContent = "Для всех карточек должен быть указан пункт отправления и пункт назначения";
        public const string TravelCardListEmpty = "Вы не указали ни одной карточки для сортировки";
        public const string TravelCardDepartureMissing = "Не найдена карточка с пунктом отправления - ";
    }
}
