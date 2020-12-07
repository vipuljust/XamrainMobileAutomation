using Q8MobileAutomation.Main.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q8MobileAutomation.Main.PageObjects
{
    public class KMControlPage : Helper
    {
        public string prevKMTxtVal = "previousKmValueTV";
        public string confMlgTxtVal = "confirmMileageValTV";
        public string currentValTxt = "currentValTV";
        public string recMlgLbl = "receiveMileageLblTv";
        public string selectaDepot = "txt_non_delivery_reason";
        public string popupYesBtn = "rightBtn";
        public string confBtn = "oneRightBtn";
        public string popupMessage = "warningMsgTv";
        public string popupMessageLocationShift = "messageTv";
        public string screenId = "screenIdTitleTV";

        //enter current value
        public void EnterKMCurrentValue(string Value)
        {
            WaitForElement(prevKMTxtVal);
            EnterValueFromKeyboard(Value);
            Console.WriteLine("Entered current value as :'" + Value + "'.");
            ClickElement(confBtn);
            Console.WriteLine("Clicked confirm button.");
        }

        //Method to select depot
        public void SelectDepot(string Depot)
        {
            WaitForElement(selectaDepot);
            ScrollDownText(Depot);
            ClickElement(Depot);
            Console.WriteLine("Selected Depot value as :'" + Depot + "'.");
        }

        // Method to select yes fot start location populp
        public void StartLocationShiftPopup()
        {
            WaitForElement(screenId);
            if (GetText(screenId).Contains("3750"))
            {
                ClickElement(popupYesBtn);
                Console.WriteLine("Confirm Start Location Shift with Yes button.");
            }
        }

        public void KMControlPopup()
        {
            if (GetText(popupMessage).Contains("DROVE"))
            {
                ClickElement(popupYesBtn);
                Console.WriteLine("Clicked on Popup i.e YOU ARE ABOUT TO START A SHIFT IN NOT CHRONOLOGICAL ORDER. CONTINUE ?");
            }


        }
    }
}
