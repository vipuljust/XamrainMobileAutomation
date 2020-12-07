using Q8MobileAutomation.Main.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q8MobileAutomation.Main.PageObjects
{
    class ADRStart : Helper
    {
        public String adrMsg = "txt_adr_message";
        public String screenId = "screenIdTitleTV";
        public String nextBtn = "yesBtn";
        public String confirmDepotBtn = "bottomRightBtn";
        public String gpsYesBtn = "leftBtn";
        public String manualADR = "rightBtn";
        public String warningMsgTv = "warningMsgTv";


        //click ADR Next button
        public void AdrNextBtn()
        {
            if (GetTextFromID(screenId, "3527"))
            {
                WaitForElement(adrMsg);
                Console.WriteLine("Please wait ADR uploading.");
            }

            if (GetTextFromID(screenId, "3528"))
            {
                ClickElement(manualADR);
                Console.WriteLine("Clicked I will make a manual ADR.");
            }
            if (GetTextFromID(screenId, "3529"))
             {
                ClickElement(nextBtn);
                Console.WriteLine("Clicked ADR Next button.");
            }
        }

        // Click on Depot button

        public void DepotBtn()
        {
            ClickElement(confirmDepotBtn);
            Console.WriteLine("Clicked Depot button.");
        }

        // Click on GPS Popup buttom
        public void  GPSPopupBtn()
        {
            if (GetTextFromID(screenId, "3775"))
            {
                WaitForElement(gpsYesBtn);
                ClickElement(gpsYesBtn);
                Console.WriteLine("The GPS Position doesn't correspond to the reference position");
            }
            

        }
        public void GPSPopupBtnPowerInterrupt()
        {
            if (GetTextFromID(screenId, "3616"))
            {
                WaitForElement(gpsYesBtn);
                ClickElement(gpsYesBtn);
                Console.WriteLine("The GPS Position doesn't correspond to the reference position");
            }


        }


    }
}
