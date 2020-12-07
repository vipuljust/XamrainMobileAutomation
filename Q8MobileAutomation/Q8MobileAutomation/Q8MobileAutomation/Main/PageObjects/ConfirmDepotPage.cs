using Q8MobileAutomation.Main.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q8MobileAutomation.Main.PageObjects
{
    public class ConfirmDepotPage : Helper
    {
        public string otherDepotBtn = "topRightBtn";
        public string confirmThisDepotBtn = "bottomRightBtn";

        //click confirm depot button
        public void ConfirmDepot()
        {
            ClickElement(confirmThisDepotBtn);
            Console.WriteLine("Clicked on confirm this depot button.");
        }
    }
}
