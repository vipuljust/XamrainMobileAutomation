using Q8MobileAutomation.Main.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q8MobileAutomation.Main.PageObjects
{
    public class ComptEditPage : Helper
    {
        public new string confirmBtn = "oneRightBtn";
        public string printBtn = "topLeftBtn";
        public string cancelModBtn = "bottomLeftBtn";
        public string productLabel = "productTV";
        public string selectProduct = "txt_non_delivery_reason";
        public string syncingValTxt = "progress";

        //click confirm button for editing compartment
        public void ConfirmCompartmentEdit()
        {
            ClickElement(confirmBtn);
            Console.WriteLine("Clicked on confirm button.");
        }

        //select tank for editing
        public void SelectTankToEdit(string TankNumber)
        {
            ClickElement(TankNumber);
            Console.WriteLine("Selected tank : " + TankNumber + " to edit.");
        }

        //enter stock value
        public void EnterNewStockValue(string StockValue)
        {
            EnterValueFromKeyboard(StockValue);
            Console.WriteLine("Entered value : '" + StockValue + "'.");
        }

        //Select the Product
        public void SelectProductValue(string product)
        {
            ClickElement(productLabel);
            Console.WriteLine("Clicked on Product label.");
            ScrollDownText(product);
            ClickElement(product);
            Console.WriteLine("Select the product. "+ product);
            ClickElement(base.confirmBtn);
            Console.WriteLine("Clicked on confirm button.");
        }

        // Wait for Syncing Progess bar at bottom
        public void WaitForSyncProcessBar()
        {
            WaitForNoEle(syncingValTxt, 30);
        }
    }
}
