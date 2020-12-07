using Q8MobileAutomation.Main.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q8MobileAutomation.Main.PageObjects
{
    class ShiftEndPage : Helper
    {
        public string closeshiftBtn = "bottomLeftBtn";
        public string screenId = "screenIdTitleTV";
        public string shiftendcentreBtn = "centerBtn";
        public string confirmendshiftBtn = "leftBtn";
        public string shiftendconfirmBtn = "oneRightBtn";

        /// <summary> 
        /// CLicked on Close Shift button
        /// </summary>

        public void ClickCloseShiftBtn()

        {
           if(GetTextFromID(screenID, "3200"))
            {
                ClickElement(closeshiftBtn);
                Console.WriteLine("Clicked on Close Shift Button");
            }
        }

        ///<summary>
        /// Clicked on End Shit button 
        /// </summary>
        public void ClickMiddleShiftBtn()

        {
            if (GetTextFromID(screenID, "3790"))
            {
                ClickElement(shiftendcentreBtn);
                Console.WriteLine("Clicked on centre Shift end Button");
            }
        }

        ///<summary>
        /// Clicked on Confirm End shift button
        /// </summary>
        public void ClickConfirmEndShiftBtn()

        {
            if (GetTextFromID(screenID, "3791"))
            {
                ClickElement(confirmendshiftBtn);
                Console.WriteLine("Clicked on confirm end Shift button");
            }
        }

        ///<summary> 
        /// Confirm Check and shift Correct KM/Mileage
        /// </summary>
        public void ConfirmShiftCheckMileageBtn()
        {
            ClickElement(shiftendconfirmBtn);
            Console.WriteLine("Clicked on Trip end confirm button");
        }

    }
}
