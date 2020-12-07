using Q8MobileAutomation.Main.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q8MobileAutomation.Main.PageObjects
{
    public class LoadingFlowPage
    {

    }

    public class PlannedLoading : Helper
    {
        public string cancelLdgBtn = "oneLeftBtn";
        public string printStckBtn = "topRightBtn";
        public string nextBtn = "bottomRightBtn";

        public void ClickNext()
        {
            ClickElement(nextBtn);
            Console.WriteLine("Clicked on next button.");
        }
    }

    public class ActualLoading : Helper
    {
        public string noMixLoadCodeBtn = "topLeftBtn";
        public string printStckBtn = "middleLeftBtn";
        public string cancelLdgBtn = "bottomLeftBtn";
        public string selLdgPrdBtn = "topRightBtn";
        public string allLdgPrdBtn = "bottomRightBtn";

        public void ClickAllLoadedProductsButton()
        {
            ClickElement(allLdgPrdBtn);
            Console.WriteLine("Clicked on all loaded products entered button.");
        }

        public void ClickNoMixLoadCode()
        {
            ClickElement(noMixLoadCodeBtn);
            Console.WriteLine("Clicked on No-Mix load code button.");
        }

        public void SelectNoMixReason(String nomix)
        {
            ScrollDownText(nomix);
            ClickElement(nomix);
            Console.WriteLine("Selected reason for No-Mix.");

        }

        public void EnterNoMixCode(string code)
        {
            EnterValueFromKeyboard(code);
            Console.WriteLine("Entered no mix code : '" + code + "'.");
            ClickElement(base.confirmBtn);
            Console.WriteLine("Clicked confirm button.");
        }

        public void ClickSelectLoadedProductButton()
        {
            ClickElement(selLdgPrdBtn);
            Console.WriteLine("Clicked on select loaded product button.");
            
        }

       public void  SelectProductFromList(String product)
        {
            ScrollDownText(product);
            ClickElement(product);
            Console.WriteLine("Selected product is:" + product);
        }

        public void EnterLoadQuantity(string loadValue)
        {
            EnterValueFromKeyboard(loadValue);
            Console.WriteLine("Entered Total load quantity : '" + loadValue + "'.");
            ClickElement(base.confirmBtn);
            Console.WriteLine("Clicked confirm button.");
        }

         public void AssignAlternativeQuantity(string loadValue)
        {
            EnterValueFromKeyboard(loadValue);
            Console.WriteLine("Entered Ambient load quantity : '" + loadValue + "'.");
            ClickElement(allLdgPrdBtn);
            Console.WriteLine("Clicked confirm button.");
        }



    }

    public class OverrideNoMixCode : Helper
    {
        public string genAnotherCodeBtn = "oneLeftBtn";
        public string nextBtn = "oneRightBtn";

        public void ClickNext()
        {
            ClickElement(nextBtn);
            Console.WriteLine("Clicked on next button.");
        }
    }

    public class LoadingSummary : Helper
    {
        public string cancelLdgBtn = "oneLeftBtn";
        public string cnfrmLdgBtn = "oneRightBtn";

        public void ConfirmLoading()
        {
            ClickElement(cnfrmLdgBtn);
            Console.WriteLine("Clicked on confirm loading button.");
        }
    }

    public class LoadingInfo : Helper
    {
        public string bolnumText = "bolLblText";
        public string confirmBtn = "okayKeyboardBtn";

        public void ClickBolNum()
        {
            ClickElement(bolnumText);
            Console.WriteLine("Clicked on BOL Number input.");
        }

        public void EnterBOLNumber(string bol)
        {
            EnterValueFromKeyboard(bol);
            Console.WriteLine("Entered bol number : '" + bol + "'.");
            ClickElement(confirmBtn);
            Console.WriteLine("Clicked confirm button.");
        }

    }

}
