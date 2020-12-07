using Q8MobileAutomation.Main.Utils;
using System;

namespace Q8MobileAutomation.Main.PageObjects
{
    public class ComptTempPage : Helper
    {
        public new string confirmBtn = "bottomRightBtn";
        public string OkBtn = "okayKeyboardBtn";
        public string renewLogonBtn = "oneLeftBtn";
        public string otherComptBtn = "topRightBtn";

        //click confirm button for compartment-meter temperature check
        public void ConfirmCompartment_MeterTemperature()
        {
            ClickElement(confirmBtn);
            Console.WriteLine("Clicked on confirm button.");
        }

        //click other compartment button
        public void ClickOtherCompartmentButton()
        {
            
            if (GetTextFromID(screenID, "3060"))
            {
                ClickElement(otherComptBtn);
                Console.WriteLine("Clicked on other compartment button.");
            }
        }

        //enter number of compartment
        public void EnterNumberofCompartment(string NoOfCompts)
        {
            EnterValueFromKeyboard(NoOfCompts);
            Console.WriteLine("Entered number of compartments : '" + NoOfCompts + "'.");
            ClickElement(base.confirmBtn);
            Console.WriteLine("Clicked confirm button.");
        }
    }
}
