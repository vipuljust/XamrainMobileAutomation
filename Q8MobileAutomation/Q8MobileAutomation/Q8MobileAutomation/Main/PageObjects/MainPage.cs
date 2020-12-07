using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Q8MobileAutomation.Main.Utils;

namespace Q8MobileAutomation.Main.PageObjects
{
    public class MainPage : Helper
    {
        public string languagePfx = "btn_";
        public string languageSuff = "_selection";
        public string dutchBtn = "topRightBtn";
        public string frenchBtn = "middleRightBtn";
        public string englishBtn = "bottomRightBtn";
        public string screenName = "toolbarTitleTV";
        public string screenID = "screenIdTitleTV";
        public string messageoneTV = "messageOneTV";

        //select language option
        public void SelectLanguage(string language)
        {
            switch (language)
            {
                case "dutch":
                    ClickElement(dutchBtn);
                    break;
                case "french":
                    ClickElement(frenchBtn);
                    break;
                case "english":
                    ClickElement(englishBtn);
                    break;
                default:
                    Assert.Fail("No language specified in test data sheet.");
                    break;
            }
            Console.WriteLine("Selected language : '" + language + "'.");
        }

       public string VerifyTitleName()
        {
             WaitTimeFromElement(screenName);
            return GetText(screenName);
        }

        public string VerifyScreenID()
        {
            WaitForElement(screenID);
            return GetText(screenID);
        }

        /// <summary>
        /// Assert the text on dutch start application screen 
        /// </summary>
      public string VerifyStartDutchApplication()
        {   
            WaitForElement(dutchBtn);
            return FetchText(dutchBtn);
        }

        /// <summary>
        /// Assert the text on french start application screen 
        /// </summary>
        public string VerifyStartFrenchApplication()
        {
            return FetchText(frenchBtn);
        }

        /// <summary>
        /// Assert the text on french start application screen 
        /// </summary>
        public string VerifyStartEnglishApplication()
        {
            return FetchText(englishBtn);
        }

        ///<summary>
        ///Method to transtion between the screen
        /// </summary>
        public void TranstionBtwScreens()
        {
            WaitForNoEle(messageoneTV, 10);
        }
    }


}
