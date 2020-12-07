using Q8MobileAutomation.Main.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q8MobileAutomation.Main.PageObjects
{
    public class ConfirmNamePage : Helper
    {
        public string otherDrvBtn = "oneLeftBtn";
        public string cnfrmNameBtn = "oneRightBtn";
        public string defDelCountVal = "txtDefaultDeliverCountryVal";
        public string backBtn = "oneLeftBtn";
        public string trailerIDTxt = "txtTrailerIdVal"; 
        public string licensePlateTxt = "txtLicencePlateVal";
        public string confirmKeyboardBtn = "okayKeyboardBtn";
        public string txttruckmameVal = "txtTruckNameVal";
        public string txtdriverVal = "txtDriverIdVal";


        public void ConfirmVehicleDetails()
        {
            ClickElement(cnfrmNameBtn);
            Console.WriteLine("Clicked on confirm name button.");
        }

        public void EnterTruckID(string Value)
        {
            Console.WriteLine("Tapped the Licence Plate text box: '");
            ClickElement(licensePlateTxt);
            Console.WriteLine("Entered Licence Plate : '" + Value + "'.");
            EnterValueFromKeyboard(Value);
            Console.WriteLine("Entered License Plate : '" + Value + "'.");
            ClickElement(confirmKeyboardBtn);
            Console.WriteLine("Clicked confirm button.");
        }
        public void EnterTrailerID(string Value)
        {
            ClickElement(trailerIDTxt);
            Console.WriteLine("Tapped the trailer ID text box: '");
            EnterValueFromKeyboard(Value);
            Console.WriteLine("Entered trailer ID : '" + Value + "'.");
            ClickElement(confirmKeyboardBtn);
            Console.WriteLine("Clicked confirm button.");
            System.Threading.Thread.Sleep(2000);
        }

        public void SelectDeliveryCountry(String Country)
        {
            Console.WriteLine("Select the Default Deliver Country list: ");
            ClickElement(defDelCountVal);
            Console.WriteLine("Select the Default Deliver Country : '" + Country + "'.");
            ScrollDownText(Country);
            ClickElement(Country);
         }

        /// <summary>
        /// Method to verfiy truck number
        /// </summary>
        /// <returns></returns>
        public string VerifyTruckNumber()
        {

            string[] text = FetchText(txttruckmameVal).Split(' ');

            return text[1];
        }

        /// <summary>
        /// Method to verfiy truck number
        /// </summary>
        /// <returns></returns>
        public string VerifyDriverName()
        {
            return FetchText(txtdriverVal);
        }

    }
}
