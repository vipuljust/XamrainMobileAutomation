using Q8MobileAutomation.Main.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q8MobileAutomation.Main.PageObjects
{
    public class ActualStockPage : Helper
    {
        public string confirmStockBtn = "oneRightBtn";
        public string printBtn = "topLeftBtn";
        public string editStockBtn = "bottomLeftBtn";
        public string stockValEle = "stockValText";
        public string popupYesBtn = "rightBtn";
        public string totalStockVal = "stockValText";

        //click confirm button for actual stock
        public void ConfirmActualStock()
        {
            WaitTimeFromElement(confirmStockBtn);
            ClickElement(confirmStockBtn);
            Console.WriteLine("Clicked on confirm stock button.");
        }

        //click edit button for actual stock
        public void EditActualStock()
        {
            WaitTimeFromElement(editStockBtn);
            ClickElement(editStockBtn);
            Console.WriteLine("Clicked on edit stock button.");
            WaitTimeFromElement(popupYesBtn);
            ClickElement(popupYesBtn);
            Console.WriteLine("Clicked on Yes button.");
        }

        
        public bool VerifyDisplayedStockValue(string ExpectedValue, string TankNumber)
        {
            // string actualValue = GetValue(stockValEle, Convert.ToInt16(TankNumber) - 1);
          //  Console.WriteLine("AAAAA"+ExpectedValue);

          //  Console.WriteLine("BBBBB"+TankNumber);

           // RunAutomation.app.Query(x => x.Id("stockValText"))[1].Text


            string actualValue = GetValue(totalStockVal, Convert.ToInt16(TankNumber) - 1);
            //Convert.ToInt16(actualValue);
            //Console.WriteLine(actualValue);


            if (actualValue.Equals(ExpectedValue))
                return true;
            else
                return false;
        }
    }
}
