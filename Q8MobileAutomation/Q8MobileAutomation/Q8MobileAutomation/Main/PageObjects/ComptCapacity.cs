using Q8MobileAutomation.Main.Utils;
using System;
using NUnit.Framework;

namespace Q8MobileAutomation.Main.PageObjects
{
    public class ComptCapacity : Helper
    {
        public new string cancelBtn = "oneLeftBtn";
        public new string confirmBtn = "oneRightBtn";
        public string capacityEle = "txt_capacity";
        public string confirmFinalBtn = "bottomRightBtn";

        //click confirm button
        public void ClickConfirmButton()
        {
            ClickElement(confirmBtn);
            Console.WriteLine("Clicked on confirm button.");
        }

        //click confirm button
        public void ConfirmSpotTrailerCompartments()
        {
            ClickElement(confirmFinalBtn);
            Console.WriteLine("Clicked on confirm button.");
        }

        //[Spotrailer] select compartment and enter its capacity
        public void SelectCompartment_EnterCapacity(int ComptCount, string Capacity)
        {
            //int calculatedValue = 0;
            //for (int ctr = 1; ctr <= Convert.ToInt32(ComptCount); ctr++)
            //{
            ClickElement(ComptCount.ToString());
            //calculatedValue = Convert.ToInt32(Capacity) + ctr * 100;
            //Capacity = calculatedValue.ToString();
            EnterValueFromKeyboard(Capacity);
            Console.WriteLine("Entered compartment capacity as : '" + Capacity + "'.");
            ClickElement(base.confirmBtn);
            Console.WriteLine("Clicked confirm button.");
            //}
        }
    }
}
