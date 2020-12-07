using Q8MobileAutomation.Main.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q8MobileAutomation.Main.PageObjects
{
    public class ComptStatusPage: Helper
    {
        public string cancelLdgBtn = "topLeftBtn";
        public string otherDepotBtn = "bottomLeftBtn";
        public string printStockBtn = "topRightBtn";
        public string nextBtn = "bottomRightBtn";

        public void CancelLoading()
        {
            ClickElement(cancelLdgBtn);
            Console.WriteLine("Clicked on cancel loading button.");
        }

        public void GotoOtherDepot()
        {
            ClickElement(otherDepotBtn);
            Console.WriteLine("Clicked on other depot button.");
        }

        public void PrintStock()
        {
            ClickElement(printStockBtn);
            Console.WriteLine("Clicked on print stock button.");
        }

        public void ClickNext()
        {
            ClickElement(nextBtn);
            Console.WriteLine("Clicked on next button.");
        }

    }
}
