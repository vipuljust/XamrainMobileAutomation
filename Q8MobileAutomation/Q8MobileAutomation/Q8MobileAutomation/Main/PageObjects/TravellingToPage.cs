using Q8MobileAutomation.Main.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q8MobileAutomation.Main.PageObjects
{
    public class TravellingToPage : Helper
    {
        public string loadBtn = "topLeftBtn";
        public string deliverBtn = "topRightBtn";
        public string movingToBtn = "bottomLeftBtn";
        public string closeTripBtn = "bottomRightBtn";
        public String screenId = "screenIdTitleTV";

        public void PerformLoad()
        {
            ClickElement(loadBtn);
            Console.WriteLine("Clicked on load button.");
        }

        public void ClickDelivery()
        {
            if (GetTextFromID(screenId, "3116"))
            {
                ClickElement(deliverBtn);
                Console.WriteLine("Clicked on delivery button.");
            }
        }

        public void ClickMovingTo()
        {
            ClickElement(movingToBtn);
            Console.WriteLine("Clicked on moving to button.");
        }

        public void CloseTrip()
        {
            ClickElement(closeTripBtn);
            Console.WriteLine("Clicked on close trip button.");
        }
    }
}
