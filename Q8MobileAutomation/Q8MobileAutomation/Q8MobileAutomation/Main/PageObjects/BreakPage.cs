using Q8MobileAutomation.Main.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q8MobileAutomation.Main.PageObjects
{
    class BreakPage : Helper
    {
        public string breaklocationBtn = "breakLocationBtn";
        public string breakconfirmBtn = "oneRightBtn";
        public string owndieselTxt = "txtDieselVal";
        public string ownadblueTxt = "txtAdBlueVal";


        /// <summary>
        /// Click on Break Location
        /// </summary>
        public void ClickBreakLocation()
        {
            WaitForElement("3761");
            ClickElement(breaklocationBtn);
            Console.WriteLine("Clicked on Break Location Button.");

        }

        /// <summary>
        /// Select Break Type 
        /// </summary>
        public void SelectBreakType(string breakType)
        {
            ScrollDownText(breakType);
            ClickElement(breakType);
            Console.WriteLine("Scroll down and select the Break type: " + breakType);
        }

        /// <summary>
        /// Click on  break screen Confirm button
        /// </summary>
        public void ClickBreakConfirmBtn()
        {
            ClickElement(breakconfirmBtn);
            Console.WriteLine("Clicked on break confirm button");
        }

        /// <summary> 
        /// Click on End break button 
        /// </summary>
        public void ClickEndBreakBtn()
        {
            ClickElement(breakconfirmBtn);
            Console.WriteLine("Clicked on End break button");
        }

        /// <summary> 
        /// Diesel Own Consumption Screen
        /// </summary>
        
        public void EnterDieselOwnConsumption(string ownDiesel)
        {
            ClickElement(owndieselTxt);
            Console.WriteLine("Clicked on own consumption diesel");
            EnterValueFromKeyboard(ownDiesel);
            Console.WriteLine("Entered diesel supplied");
            ClickElement(breakconfirmBtn);
            Console.WriteLine("Clicked confirm button");
        }

        /// <summary> 
        /// AD Blue Own Consumption Screen
        /// </summary>

        public void EnterAdBlueOwnConsumption(string ownBlue)
        {
            ClickElement(ownadblueTxt);
            Console.WriteLine("Clicked on own consumption AD Blue");
            EnterValueFromKeyboard(ownBlue);
            Console.WriteLine("Entered AD Blue supplied");
            ClickElement(breakconfirmBtn);
            Console.WriteLine("Clicked confirm button");
        }

        ///<summary> 
        /// Clicked on Own consumption button
        /// </summary>
        public void ClickOwnConsumptionBtn()
        {
            ClickElement(breakconfirmBtn);
            Console.WriteLine("Clicked own consumption confirm button");
        }
    }
}
