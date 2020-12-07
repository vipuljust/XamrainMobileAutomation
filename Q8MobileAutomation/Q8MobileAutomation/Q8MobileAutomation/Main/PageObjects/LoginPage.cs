using Q8MobileAutomation.Main.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q8MobileAutomation.Main.PageObjects
{
    public class LoginPage : Helper
    {
        public string logonBtn = "btn_logon";
        public new string confirmBtn = "bottomBtn";
        public string renewLogonBtn = "oneBtn";
        public string otherComptBtn = "topBtn";
        public string truckNoBtn = "txt_non_delivery_reason";
        public string screenName = "toolbarTitleTV";



        //Click logon button
        public void ClickLogon()
        {   if (GetTextFromID(screenID, "1011"))
            {
                ClickElement(logonBtn);
                Console.WriteLine("Clicked on log on button.");
            }
        }

        //Enter driver PIN
        public void EnterDriverPIN(string driverPIN)
        {
            EnterValueFromKeyboard(driverPIN);
            Console.WriteLine("Entered driver PIN : '" + driverPIN + "'.");
            ClickElement(base.confirmBtn);
            Console.WriteLine("Clicked confirm button.");
        }

        // Select Q8 Truck number
        public void SelectTruckNumber(string truckNumber)
        {
          Console.WriteLine("Select truck Number : '" + truckNumber + "'.");
            ScrollDownText(truckNumber);
            ClickElement(truckNumber);
        }

        //check compartment meter temperature
        public void CheckCompartment_MeterTemperature()
        {
            ClickElement(confirmBtn);
            Console.WriteLine("Clicked on confirm button.");
        }

        public void CheckActualStock()
        {

        }

        // Verify the logon page title
        public string VerifyTitleName()
        {
            return GetText(screenName);
        }

    }
}
