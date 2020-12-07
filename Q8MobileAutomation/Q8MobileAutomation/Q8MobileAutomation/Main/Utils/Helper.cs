using System.IO;
using System.Reflection;
using Xamarin.UITest;
using System;
using Q8MobileAutomation.Test;
using System.Diagnostics;
using System.Linq;

namespace Q8MobileAutomation.Main.Utils
{
    public class Helper
    {
        public static string dirPath = string.Empty;
        public static string debugPathToTrim = string.Empty;
        public static string releasePathToTrim = string.Empty;
        Process processObj = null;

        //global elements
        public string numberPfx = "number";
        public string numberSuff = "KeyboardBtn";
        public string charaterPfx = "charater";
        public string confirmBtn = "oneRightBtn";
        public string deleteBtn = "deleteKeyboardBtn";
        public string cancelBtn = "cancelKeyboardBtn";

        ///Keyboard layout with 2 buttons
        public string firstRightBtn = "topRightBtn";
        public string secondRightBtn = "bottomRightBtn";

        //Screen title and Screen id 
        public string screenName = "toolbarTitleTV";
        public string screenID = "screenIdTitleTV";


        //class constructor
        public Helper()
        {
            try
            {
                dirPath = AppDomain.CurrentDomain.BaseDirectory;
                debugPathToTrim = @"\bin\Debug";
                releasePathToTrim = @"\bin\Release";
                processObj = new Process();

                //code to remove unwanted bin folders
                if (dirPath.Contains("Debug"))
                {
                    dirPath = dirPath.Replace(debugPathToTrim, "");
                }
                else if (dirPath.Contains("Release"))
                {
                    dirPath = dirPath.Replace(releasePathToTrim, "");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Exception ::: " + ex.ToString());
            }
        }

        /// <summary>
        /// Method to kill test data excel instances
        /// </summary>
        public void CloseExcelInstance()
        {
            try
            {
                Process[] AllProcesses = Process.GetProcesses();
                foreach (var process in AllProcesses)
                {
                    var procName = process.ProcessName.ToLower();
                    if (procName == "excel")
                    {
                        if (process.MainWindowTitle.Contains("AutomationTestData.xlsx") || string.IsNullOrEmpty(process.MainWindowTitle))
                            process.Kill();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Exception ::: " + ex.ToString());
            }
        }

        /// <summary>
        /// Method to launch app
        /// </summary>
        /// <param name="platform"></param>
        /// <returns></returns>
        public static IApp StartApp(Platform platform)
        {
            try
            {
                if (platform == Platform.Android)
                {

                    System.IO.Directory.SetCurrentDirectory(@"E:\Year\2019\July\");
                    return ConfigureApp
                        .Android
                        .KeyStore(dirPath + @"\Main\Utils\FuelStar.keystore", "FuelStar@123", "FuelStar@123", "FuelStar")
                        .InstalledApp("proteus.droid")
                        .EnableLocalScreenshots()
                        .StartApp();
                }
                return ConfigureApp.iOS.StartApp();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception ::: " + ex.ToString());
            }
        }

        /// <summary>
        /// Method to click element
        /// </summary>
        /// <param name="Element"></param>
        public void ClickElement(string Element)
        {
            try
            {
                
                RunAutomation.app.Tap(x => x.Marked(Element));
            }
            catch (Exception ex)
            {
                throw new Exception("Exception ::: " + ex.ToString());
            }
        }

        /// <summary>
        /// Method to get text value from element
        /// </summary>
        /// <param name="ElementId"></param>
        /// <param name="ElementPosition"></param>
        /// <returns></returns>
        public string GetValue(string ElementId, int ElementPosition)
        {
            try
            {

                var actualValue = RunAutomation.app.Query(x => x.Id(ElementId))[ElementPosition].Text;
                RunAutomation.app.Flash(x => x.Text(actualValue));
                return actualValue;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception ::: " + ex.ToString());
            }
        }

        /// <summary>
        /// Method to get text value from element
        /// </summary>
        /// <param name="ElementId"></param>
        /// <returns></returns>
        public string GetText(string ElementId)
        {

            var actualValue = RunAutomation.app.Query(x => x.Marked(ElementId))[0].Text;
            //    RunAutomation.app.Flash(x => x.Text(actualValue));
            return actualValue;

        }

        /// <summary>
        /// Method to invoke text from id 
        /// </summary>
        /// 
        public bool GetTextFromID(string ElementId, string Text)
        {
            // WaitForElement(Text);
             bool getbool = true ;

            for (int i = 0; i <= 5; i++)
            {
                var actualValue = RunAutomation.app.Query(x => x.Marked(ElementId).Invoke("getText"))[0];

                if (actualValue.Equals(Text))
                {

                    getbool = true;
                    break;
                }
                else
                {
                    System.Threading.Thread.Sleep(2000);
                    if (i == 5)
                    {
                        Console.WriteLine("Waiting for element");
                        getbool = false;
                        break;
                    }
                }
          }
            return getbool;
        }

        /// <summary>
        /// Method to get text value from element
        /// </summary>
        /// <param name="ElementId"></param>
        /// <returns></returns> 
        public string GetScreenID(string ScreenNo, string Element)
        {
            try
            {
                var actualValue = RunAutomation.app.Query(c => c.Id(Element).Text(ScreenNo));
                //   RunAutomation.app.Query(c => c.Id("screenIdTitleTV").Text(ScreenNo));
                return actualValue.ToString().Trim();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception ::: " + ex.ToString());
            }
        }



        /// <summary>
        /// Method to scroll down
        /// </summary>
        /// 
        public void ScrollDownText(string text)
        {
            try
            {
                RunAutomation.app.ScrollDownTo(x => x.Text(text));
            }
            catch (Exception ex)
            {
                throw new Exception("Exception ::: " + ex.ToString());
            }
        }

        /// <summary>
        /// Method to enter value from keyboard
        /// </summary>
        /// <param name="Value"></param>
        public void EnterValueFromKeyboard(string Value)
        {
            char[] valArray = new char[Value.Length];
            valArray = Value.ToCharArray();
            foreach (char item in valArray)
            {
                ClickNumber(numberPfx, item, numberSuff);
            }
        }


        /// <summary>
        /// Method to click number on keypad
        /// </summary>
        /// <param name="numPrefix"></param>
        /// <param name="number"></param>
        /// <param name="numSuffix"></param>
        public void ClickNumber(string numPrefix, char number, string numSuffix)
        {
            try
            {
                switch (number)
                {
                    case '0':
                        ClickElement(numPrefix + "Zero" + numSuffix);
                        break;
                    case '1':
                        ClickElement(numPrefix + "One" + numSuffix);
                        break;
                    case '2':
                        ClickElement(numPrefix + "Two" + numSuffix);
                        break;
                    case '3':
                        ClickElement(numPrefix + "Three" + numSuffix);
                        break;
                    case '4':
                        ClickElement(numPrefix + "Four" + numSuffix);
                        break;
                    case '5':
                        ClickElement(numPrefix + "Five" + numSuffix);
                        break;
                    case '6':
                        ClickElement(numPrefix + "Six" + numSuffix);
                        break;
                    case '7':
                        ClickElement(numPrefix + "Seven" + numSuffix);
                        break;
                    case '8':
                        ClickElement(numPrefix + "Eight" + numSuffix);
                        break;
                    case '9':
                        ClickElement(numPrefix + "Nine" + numSuffix);
                        break;
                    case 'X':
                        ClickElement(charaterPfx + "X" + numSuffix);
                        break;
                    case 'A':
                        ClickElement(charaterPfx + "A" + numSuffix);
                        break;
                    case 'B':
                        ClickElement(charaterPfx + "B" + numSuffix);
                        break;
                    case 'C':
                        ClickElement(charaterPfx + "C" + numSuffix);
                        break;
                    case 'D':
                        ClickElement(charaterPfx + "D" + numSuffix);
                        break;
                    case 'E':
                        ClickElement(charaterPfx + "E" + numSuffix);
                        break;
                    case 'F':
                        ClickElement(charaterPfx + "F" + numSuffix);
                        break;
                    case 'G':
                        ClickElement(charaterPfx + "G" + numSuffix);
                        break;
                    case 'H':
                        ClickElement(charaterPfx + "H" + numSuffix);
                        break;
                    case 'I':
                        ClickElement(charaterPfx + "I" + numSuffix);
                        break;
                    case 'J':
                        ClickElement(charaterPfx + "J" + numSuffix);
                        break;
                    case 'K':
                        ClickElement(charaterPfx + "K" + numSuffix);
                        break;
                    case 'L':
                        ClickElement(charaterPfx + "L" + numSuffix);
                        break;
                    case 'M':
                        ClickElement(charaterPfx + "M" + numSuffix);
                        break;
                    case 'N':
                        ClickElement(charaterPfx + "N" + numSuffix);
                        break;
                    case 'O':
                        ClickElement(charaterPfx + "O" + numSuffix);
                        break;
                    case 'P':
                        ClickElement(charaterPfx + "P" + numSuffix);
                        break;
                    case 'Q':
                        ClickElement(charaterPfx + "Q" + numSuffix);
                        break;
                    case 'R':
                        ClickElement(charaterPfx + "R" + numSuffix);
                        break;
                    case 'S':
                        ClickElement(charaterPfx + "S" + numSuffix);
                        break;
                    case 'T':
                        ClickElement(charaterPfx + "T" + numSuffix);
                        break;
                    case 'U':
                        ClickElement(charaterPfx + "U" + numSuffix);
                        break;
                    case 'V':
                        ClickElement(charaterPfx + "V" + numSuffix);
                        break;
                    case 'W':
                        ClickElement(charaterPfx + "W" + numSuffix);
                        break;
                    case 'Y':
                        ClickElement(charaterPfx + "Y" + numSuffix);
                        break;
                    case 'Z':
                        ClickElement(charaterPfx + "Z" + numSuffix);
                        break;
                    default:
                        Console.WriteLine("Unknown input");
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Exception ::: " + ex.ToString());
            }
        }

        public void EnterValueFromAlphaKeyboard(string Value)
        {
            char[] valArray = new char[Value.Length];
            valArray = Value.ToCharArray();
            foreach (char item in valArray)
            {
                ClickAlphaNumber(numberPfx, item, numberSuff);
            }
        }

        /// <summary>
        /// Method to click number on keypad
        /// </summary>
        /// <param name="numPrefix"></param>
        /// <param name="number"></param>
        /// <param name="numSuffix"></param>
        public void ClickAlphaNumber(string numPrefix, char number, string numSuffix)
        {
            try
            {
                switch (number)
                {
                    case '0':
                        ClickElement(numPrefix + "Zero" + numSuffix);
                        break;
                    case '1':
                        ClickElement(numPrefix + "One" + numSuffix);
                        break;
                    case '2':
                        ClickElement(numPrefix + "Two" + numSuffix);
                        break;
                    case '3':
                        ClickElement(numPrefix + "Three" + numSuffix);
                        break;
                    case '4':
                        ClickElement(numPrefix + "Four" + numSuffix);
                        break;
                    case '5':
                        ClickElement(numPrefix + "Five" + numSuffix);
                        break;
                    case '6':
                        ClickElement(numPrefix + "Six" + numSuffix);
                        break;
                    case '7':
                        ClickElement(numPrefix + "seven" + numSuffix);
                        break;
                    case '8':
                        ClickElement(numPrefix + "Eight" + numSuffix);
                        break;
                    case '9':
                        ClickElement(numPrefix + "nine" + numSuffix);
                        break;
                    case 'X':
                        ClickElement(charaterPfx + "X" + numSuffix);
                        break;
                    case 'A':
                        ClickElement(charaterPfx + "A" + numSuffix);
                        break;
                    case 'B':
                        ClickElement(charaterPfx + "B" + numSuffix);
                        break;
                    case 'C':
                        ClickElement(charaterPfx + "C" + numSuffix);
                        break;
                    case 'D':
                        ClickElement(charaterPfx + "D" + numSuffix);
                        break;
                    case 'E':
                        ClickElement(charaterPfx + "E" + numSuffix);
                        break;
                    case 'F':
                        ClickElement(charaterPfx + "F" + numSuffix);
                        break;
                    case 'G':
                        ClickElement(charaterPfx + "G" + numSuffix);
                        break;
                    case 'H':
                        ClickElement(charaterPfx + "H" + numSuffix);
                        break;
                    case 'I':
                        ClickElement(charaterPfx + "I" + numSuffix);
                        break;
                    case 'J':
                        ClickElement(charaterPfx + "J" + numSuffix);
                        break;
                    case 'K':
                        ClickElement(charaterPfx + "K" + numSuffix);
                        break;
                    case 'L':
                        ClickElement(charaterPfx + "L" + numSuffix);
                        break;
                    case 'M':
                        ClickElement(charaterPfx + "M" + numSuffix);
                        break;
                    case 'N':
                        ClickElement(charaterPfx + "N" + numSuffix);
                        break;
                    case 'O':
                        ClickElement(charaterPfx + "O" + numSuffix);
                        break;
                    case 'P':
                        ClickElement(charaterPfx + "P" + numSuffix);
                        break;
                    case 'Q':
                        ClickElement(charaterPfx + "Q" + numSuffix);
                        break;
                    case 'R':
                        ClickElement(charaterPfx + "R" + numSuffix);
                        break;
                    case 'S':
                        ClickElement(charaterPfx + "S" + numSuffix);
                        break;
                    case 'T':
                        ClickElement(charaterPfx + "T" + numSuffix);
                        break;
                    case 'U':
                        ClickElement(charaterPfx + "U" + numSuffix);
                        break;
                    case 'V':
                        ClickElement(charaterPfx + "V" + numSuffix);
                        break;
                    case 'W':
                        ClickElement(charaterPfx + "W" + numSuffix);
                        break;
                    case 'Y':
                        ClickElement(charaterPfx + "Y" + numSuffix);
                        break;
                    case 'Z':
                        ClickElement(charaterPfx + "Z" + numSuffix);
                        break;
                    default:
                        Console.WriteLine("Unknown input");
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Exception ::: " + ex.ToString());
            }
        }

        /// <summary>
        /// Method to Wait for element
        /// </summary>

        public void WaitForElement(string ElementId)
        {
            try
            {
                RunAutomation.app.WaitForElement(x => x.Marked(ElementId));
            }

            catch (Exception ex)
            {
                //  throw new Exception("Exception :::" + ex.ToString());
                   Console.WriteLine(ex.Message);
            }
        }

        ///<summary>
        ///Method to Wait for particular time span
        ///</summary>

        public static void WaitForTimeSpan(string ElementId, int Time)
        {
            try
            {
                RunAutomation.app.WaitForElement(x => x.Marked(ElementId),
                   "Did not see the success message.",
                   new TimeSpan(0, 0, 0, Time, 0));
            }
            catch (Exception ex)
            {
                throw new Exception("Exception :::" + ex.ToString());
            }
        }


        ///<summary>
        ///Method to to pause the test while some view, such as a progress dialog, is still on the screen:
        ///</summary>

        public static void WaitForNoElement(string ElementId, int Time)
        {
            try
            {
                RunAutomation.app.WaitForNoElement(x => x.Marked(ElementId).Text("Uploading data..."),
    "Upload is taking too long",
    new TimeSpan(0, 0, Time, 0));
            }
            catch (Exception ex)
            {
                throw new Exception("Exception :::" + ex.ToString());
            }
        }

        ///<summary>
        ///Method to to pause the test while some view, such as a progress dialog, is still on the screen:
        ///</summary>

        public static void WaitForNoEle(string ElementId, int Time)
        {
            try
            {
                 RunAutomation.app.WaitForNoElement(x => x.Marked(ElementId),"Upload is taking too long",
    new TimeSpan(0, 0, Time, 0));
            }
            catch (Exception ex)
            {
                throw new Exception("Exception :::" + ex.ToString());
            }
        }
        /// <summary>
        /// Method to highlight/flash the element
        /// </summary>
        /// <param name="ElementId"></param>
        /// <returns></returns>
        public void HightlightElement(String ElementId)
        {
            try
            {

                RunAutomation.app.Flash(x => x.Text(ElementId));
            }
            catch (Exception ex)
            {
                throw new Exception("Exception ::: " + ex.ToString());
            }
        }


        /// <summary>
        /// Method to run generatereport.bat file and open report in browser
        /// </summary>
        public void GenerateReport()
        {
            try
            {
                processObj.StartInfo.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory + @"BatchFiles\";
                processObj.StartInfo.FileName = "GenerateReport.bat";
                processObj.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                processObj.Start();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception ::: " + ex.ToString());
            }
        }

        /// <summary>
        /// Method to take capture screenshot
        /// </summary>

        public void TakeScreenshot(string title)
        {
            try
            {
                // RunAutomation.app.Screenshot("test");
                //for local run, save screenshot
                var fi = RunAutomation.app.Screenshot(title);
                //new name for screenshot
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), $"{title.Replace(" ", "_")}.png");
                if (File.Exists(filePath))
                {
                    //delete old file, if exist
                    File.Delete(filePath);
                }
                //move file with new name
                fi.MoveTo(filePath);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception ::: " + ex.ToString());
            }
        }

        public void CaptureScreenshot()
        {
            try
            {
                String screenid = VerifyScreenID();
                String screentitle = VerifyTitleName();
                String title = String.Concat(screenid, screentitle);
                RunAutomation.app.Screenshot(title);

            }
            catch (Exception ex)
            {
                throw new Exception("Exception ::: " + ex.ToString());
            }
        }

        public void WaitTimeFromElement(string Element)
        {
            try
            {
                RunAutomation.app.WaitForElement(Element, "Element Did Not Appear", TimeSpan.FromSeconds(60));
            }
            catch (Exception ex)
            {
                throw new Exception("Exception ::: " + ex.ToString());
            }
        }

        public string VerifyTitleName()
        {
            WaitTimeFromElement(screenName);
            return GetText(screenName);
        }

        public string VerifyScreenID()
        {
            WaitTimeFromElement(screenID);
            return GetText(screenID);
        }

        /// <summary>
        /// MEthod to verify Element is enabled or not 
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public bool IsElementEnabled(string ElementID)
        {
            return RunAutomation.app.Query(X => X.Marked(ElementID)).FirstOrDefault().Enabled;
        }
       
        ///<summary>
        ///Method to return the text 
        /// </summary>
        public String FetchText(string ElementID)
        {
            return RunAutomation.app.Query(x => x.Marked(ElementID)).FirstOrDefault().Text;
        }

        ///<summary>
        ///Method to calculate the length 
        /// </summary>
        public int CalculateLength(string ElementID)
        {
            return RunAutomation.app.Query(ElementID).Length;
        }
       
    }
}
