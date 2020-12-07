using Q8MobileAutomation.Main.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q8MobileAutomation.Main.PageObjects
{
    public class DeliveryFlowPage
    {

    }

    public class CustomerSelection : Helper
    {
        public string createUnplannedDropBtn = "topLeftBtn";
        public string mainMenuBtn = "bottomLeftBtn";
        public string detailsBtn = "topRightBtn";
        public string selectNextDestBtn = "bottomRightBtn";
        public string selectCustomer = "relative_layout_address";
                public String screenId = "screenIdTitleTV";


        public void SelectDrop(string value)
        {
            //SelectFromList(value);
            //Console.WriteLine();
        }

        public void OpenDetails()
        {
            ClickElement(selectCustomer); 
            ClickElement(detailsBtn);
            Console.WriteLine("Clicked details button.");
        }
    }

    public class DeliveryDetails : Helper
    {
        public string dropListBtn = "oneLeftBtn";
        public string confirmNextLocationBtn = "oneRightBtn";
        public String screenId = "screenIdTitleTV";
        public string selectAsNextDestinBtn = "bottomRightBtn";


        public void OpenDropList()
        {
            ClickElement(dropListBtn);
            Console.WriteLine("Clicked drop list button.");
        }

        public void ConfirmNextLocation()
        {
                ClickElement(confirmNextLocationBtn);
                Console.WriteLine("Clicked 'Confirm as next location' button.");
         }
    }

    public class PlannedDeliveryDetails : Helper
    {
        public string dropListBtn = "oneLeftBtn";
        public string automaticDipsAvailableBtn = "oneRightBtn";

        public void ClickAutomaticDipsAvailableButton()
        {
            ClickElement(automaticDipsAvailableBtn);
            Console.WriteLine("Clicked 'automatic dips available' button.");
        }

    }

    public class CustomerArrival : Helper
    {
        public string arrivedDepotBtn = "topLeftBtn";
        public string arrivedOtherCustomerBtn = "bottomLeftBtn";
        public string confirmArrivalBtn = "oneRightBtn";

        public void ConfirmArrival()
        {
            ClickElement(confirmArrivalBtn);
            Console.WriteLine("Clicked 'confirm arrival' button.");
        }
    }

    public class ReviewTankDips : Helper
    {
        public string addTankBtn = "middleLeftBtn";
        public string cancelDelBtn = "bottomLeftBtn";
        public string reDipBtn = "topRightBtn";
        public new string confirmBtn = "bottomRightBtn";
        public string cannotdipBtn = "topLeftBtn";

        public void ClickCanNotTankDip()
        {
            ClickElement(cannotdipBtn);
            Console.WriteLine("Clicked on Can't Dip Tank Button");
        }

        public void SelectTank(string value)
        {
            ClickElement(value);
            Console.WriteLine("Selected tank : '" + value + "'.");
        }
        public void EnterDipValue(string value)
        {
            EnterValueFromKeyboard(value);
            Console.WriteLine("Entered dip value : '" + value + "'.");
            ClickElement(confirmBtn);
        }
        public void ClickConfirm()
        {
            ClickElement(confirmBtn);
            Console.WriteLine("Clicked confirm button.");
        }

    }

    public class DeliveryScheme : Helper
    {
        public new string cancelBtn = "oneLeftBtn";
        public string printBtn = "topRightBtn";
        public string nextBtn = "bottomRightBtn";

        public void ClickNext()
        {
            ClickElement(nextBtn);
            Console.WriteLine("Clicked next button.");
        }
    }

    public class ProductDischarge : Helper
    {
        public string editCancelBtn = "oneLeftBtn";
        public string printBtn = "topRightBtn";
        public string confirmInputsBtn = "bottomRightBtn";
        public string selectdeliveredValText = "deliveredValText";
        public string confirmCustomerTankBtn = "oneRightBtn";

        public void SelectProduct(string value)
        {
            ClickElement(value);
            Console.WriteLine("Selected product : '" + value + "'.");
        }
        public void EnterDeliveredVolume(string value)
        {
            EnterValueFromKeyboard(value);
            Console.WriteLine("Entered delivered volume : '" + value + "'.");
            ClickElement(base.secondRightBtn);
            Console.WriteLine("Clicked on confirm button");
        }

        public void ClickConfirmInputs()
        {
            ClickElement(confirmInputsBtn);
            Console.WriteLine("Clicked 'confirm inputs' button.");
        }

        public void ClickCustomerTankConfirm()
        {
            ClickElement(confirmCustomerTankBtn);
            Console.WriteLine("Clicked 'confirm inputs' button.");
        }

        //--------------------------

        public void SelectCompartment(string CompartmentNumber)
        {
            ClickElement(CompartmentNumber);
            Console.WriteLine("Selected the compartment : " + CompartmentNumber + "'.");
        }

        public void SelectFromWhichCompartment(string TankNumber)
        {
            ClickElement(TankNumber);
            Console.WriteLine("Selected the compartment :");

        }

        public void EnterVolumeFromCompartment(string value)
        {
            EnterValueFromKeyboard(value);
            Console.WriteLine("Entered volume (liters) : '" + value + "'.");
            ClickElement(base.secondRightBtn);
            Console.WriteLine("Clicked on confirm button");
        }

        public void SelectCustomerTank(string TankNumber)
        {
                       WaitForElement("3502");
                       ClickElement(TankNumber);
            Console.WriteLine("Selected the tank : " + TankNumber + "'.");
        }

        public void VolumeToBeDelivered(string value)
        {
            EnterValueFromKeyboard(value);
            Console.WriteLine("Entered volume : '" + value + "'.");
            ClickElement(base.confirmBtn);
            Console.WriteLine("Clicked on confirm button");
        }
    }

    public class ConfirmDelivery : Helper
    {
        public string editCancelDeBtn = "topRightBtn";
        public string reDipBtn = "middleRightBtn";
        public string confirmVolumeBtn = "bottomRightBtn";
        public string confirmStockBtn = "oneRightBtn";

        public void ClickConfirmVolume()
        {
            ClickElement(confirmVolumeBtn);
            Console.WriteLine("Clicked 'confirm volumes' button.");
        }

        public void ClickConfirmStock()
        {
            ClickElement(confirmStockBtn);
            Console.WriteLine("Clicked 'confirm stock' button.");
            ClickElement(confirmStockBtn);
        }
    }
        

}
