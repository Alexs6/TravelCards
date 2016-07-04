using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication3
{
    public class TravelCardComparer : IComparer, IComparer<TravelCard>
    {
        public int Compare(TravelCard x, TravelCard y)
        {
            if (x.DestinationPoint == y.DestinationPoint && x.DeparturePoint == y.DeparturePoint)
            {
                return 0;
            }
            return 1;
        }

        public int Compare(object x, object y)
        {
            var _x = x as TravelCard;
            var _y = y as TravelCard;
            if (_x == null || _y == null) throw new InvalidOperationException();
            return Compare(_x, _y);
        }
    }
}
