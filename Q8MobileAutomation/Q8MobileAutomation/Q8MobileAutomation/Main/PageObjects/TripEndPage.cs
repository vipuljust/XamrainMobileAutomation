using Q8MobileAutomation.Main.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q8MobileAutomation.Main.PageObjects
{
    class TripEndPage : Helper
    {
        public string mainmenuBtn = "oneLeftBtn";
        public string screenId = "screenIdTitleTV";
        public string closetripBtn = "bottomRightBtn";
        public string closetripmiddlealertBtn = "middleAlertBtn";
        public string confirmthisdepotBtn = "bottomRightBtn";
        public string closetripgpsBtn = "leftBtn";
        public string tripendconfirmBtn = "oneRightBtn";

        /// <summary>
        /// Clicked on Main menu button
        /// </summary>
        public void ClickMainMenuBtn()
        {
            if(GetTextFromID(screenId, "3766"))
            {
                ClickElement(mainmenuBtn);
                Console.WriteLine("Clicked on Main Menu Button.");
            }
        }
        /// <summary>
        /// Clicked on Close Trip button 
        /// </summary>
        public void ClickCloseTripBtn()
        {
            if(GetTextFromID(screenId, "3116"))
             {
                ClickElement(closetripBtn);
                Console.WriteLine("Clicked on close trip Button.");
            }
        }

        /// <summary> 
        /// Moving to Close Trip
        /// </summary>
        public void CloseTripPopup()
        {
            if(GetTextFromID(screenID, "3755"))
            {
                ClickElement(closetripmiddlealertBtn);
                Console.WriteLine("Clicked on close trip Depot Button.");
            }
        }

        ///<summary>
        /// Select Depot from the list 
        /// </summary>
        public void CloseTripDepotList(string depot)
        {
            if (GetTextFromID(screenID, "3768"))
            {
                ScrollDownText(depot);
                Console.WriteLine("Scrolled Down to Depot: "+ depot);
                ClickElement(depot);
                Console.WriteLine("Clicked on Depot from the list");
             }
        }

        /// <summary>
        /// Click on Confirm this depot Button
        /// </summary>
        public void ClickConfirmThisDepotBtn()
        {
            if(GetTextFromID (screenId, "3756"))
            {
                ClickElement(confirmthisdepotBtn);
                Console.WriteLine("Clicked on Confirm this Depot button");
            }
        }

        /// <summary>
        /// Click on GPS Position Alert 
        /// </summary>
        public void ClickGPSPositionBtn()
        {
            if (GetTextFromID(screenId, "3644"))
            {
                ClickElement(closetripgpsBtn);
                Console.WriteLine("Clicked on GPS Position button");
            }
        }

        ///<summary> 
        /// Confirm Check and Correct KM/Mileage
        /// </summary>
        public void ConfirmCheckMileageBtn()
        {
            ClickElement(tripendconfirmBtn);
            Console.WriteLine("Clicked on Trip end confirm button");
        }
    }
}
