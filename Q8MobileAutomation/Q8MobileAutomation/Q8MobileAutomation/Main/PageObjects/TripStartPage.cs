using Q8MobileAutomation.Main.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q8MobileAutomation.Main.PageObjects
{
    public class TripStartPage : Helper
    {
        public string unplannedTripBtn = "topLeftBtn";
        public string closeShiftBtn = "bottomLeftBtn";
        public string preloadBtn = "topRightBtn";
        public string vislzeDelBtn = "middleRightBtn";
        public string startTripBtn = "bottomRightBtn";

        //select trip
        public void SelectTrip(string TripNumber)
        {
            ClickElement(TripNumber);
            Console.WriteLine("Selected the trip : " + TripNumber + "'.");
        }

        //click start trip button
        public void StartTrip()
        {
            ClickElement(startTripBtn);
            Console.WriteLine("Clicked start trip button.");
        }

        public void PerformKMControl()
        {

        }

        //click visualize deliveries button
        public void VisualizeDeliveries()
        {
            ClickElement(vislzeDelBtn);
            Console.WriteLine("Clicked visualize deliveries button.");
        }


    }
}
