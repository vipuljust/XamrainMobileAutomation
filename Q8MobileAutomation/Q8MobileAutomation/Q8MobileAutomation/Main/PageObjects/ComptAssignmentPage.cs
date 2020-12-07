using Q8MobileAutomation.Main.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q8MobileAutomation.Main.PageObjects
{
    public class ComptAssignmentPage : Helper
    {
        public string cancelLdgDieselBtn = "topLeftBtn";
        public string resetEntryDieselBtn = "bottomLeftBtn";
        public string stillToAttrBtn = "oneRightBtn";
        public string cnfrmDieselLdgBtn = "oneRightBtn";
        public string confrmEntLdgBtn = "bottomRightBtn";
        
        public void SelectProduct(String compartment)
        {
            WaitTimeFromElement(compartment);
            ClickElement(compartment);
        }

        public void ConfirmDieselLoading()
        {
            WaitTimeFromElement(cnfrmDieselLdgBtn);
            ClickElement(cnfrmDieselLdgBtn);
            Console.WriteLine("Clicked on confirm diesel loading button.");
        }

        public void ConfirmLoading()
        {
            WaitTimeFromElement(confrmEntLdgBtn);
            ClickElement(confrmEntLdgBtn);
            Console.WriteLine("Clicked on confirm loading button.");
        }

    }
}
