using Q8MobileAutomation.Main.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q8MobileAutomation.Main.PageObjects
{
    public class ShiftStartPage : Helper
    {
        public string unplannedShiftBtn = "topLeftBtn";
        public string changeTrlrBtn = "middleLeftBtn";
        public string delShiftBtn = "bottomLeftBtn";
        public string printBtn = "topRightBtn";
        public string detailsBtn = "middleRightBtn";
        public string startShiftBtn = "bottomRightBtn";
        public string eraseShiftPop = "leftBtn";
        public string selectTrip = "tripLabel";
        public string visualizeDeliversiesBtn = "bottomRightBtn";
        public string customerList = "customerNameValText";
        public string detailDeliversiesBtn = "bottomRightBtn";
        public string backBtn = "topRightBtn";
        public string dropListBtn = "oneRightBtn";
        public string toolbarListDeliveriesTitle = "LIST DELIVERIES";
        public string toolbarOverviewTripsTitle = "OVERVIEW TRIPS";
        public string shiftNumberLabelBtn = "shiftNumberLabel";
        public string popupMessage = "warningMsgTv";
        public string popupYesBtn = "leftBtn";
        public string popupNextBtn = "yesBtn";
        public string unplannedshiftBtn = "topLeftBtn";
        public string confirmkeyboardBtn = "okayKeyboardBtn";
        public string selectsearchEle = "customerNoValText";
        public string noshiftAvailable = "noDataTV";
        public string screenId = "screenIdTitleTV";

        // Create unplanned shift
        public void CreateUnplannedShift()
        {
          //  HightlightElement(unplannedshiftBtn);
            ClickElement(unplannedshiftBtn);
            Console.WriteLine("Clicked the Unplanned Shift button ");
        }

        // Select Customer name 
        public void SelectCustomerName(String CustomerName)
        {
            EnterValueFromAlphaKeyboard(CustomerName);
            Console.WriteLine("Selected the Customer Name : '" + CustomerName + "'.");
            ClickElement(confirmkeyboardBtn);
        }
       // Select the search customer result
        public void SelectCustomerElement()
        {
            ClickElement(selectsearchEle);
            Console.WriteLine("Selected the Customer Name");
        }

        // Select this customer 
        public void SelectUnplannedCustomerDrop()
        {
            ClickElement(dropListBtn);
            Console.WriteLine("Selected the Select for an unplanned drop");
        }

        //select shift
        public void SelectShift(string ShiftNumber)
        {
            WaitForElement(ShiftNumber);
          //  HightlightElement(ShiftNumber);
            ClickElement(ShiftNumber);
            Console.WriteLine("Selected the shift : '" + ShiftNumber + "'.");
        }

        //click shift start button
        public void ClickStartShiftButton()
        {
            ClickElement(startShiftBtn);
            Console.WriteLine("Clicked on start shift button.");
        }

        //view shift details
        public void ViewShiftDetails()
        {
            ClickElement(detailsBtn);
            Console.WriteLine("Clicked on details button.");
        }

        // Delete shift 
        public void ClickDeleteShittButton()
        {
            ClickElement(delShiftBtn);
            Console.WriteLine("Clicked on delete button.");
        }

        // Warning Confirm Erase Shift
        public void PopupConfirmEraseShift()
        {
            ClickElement(eraseShiftPop);
            Console.WriteLine("Clicked on Yes button for Confirm Erase Shift.");
        }

        // Select Overview Trips
        public void SelectOverviewTrips()
        {
            WaitForElement(selectTrip);
            ClickElement(selectTrip);
            Console.WriteLine("Highlighted the Overview Trips.");
            ClickElement(visualizeDeliversiesBtn);
            Console.WriteLine("Clicked on Visualize Deliversies Btn.");
        }

        //Select the list deliveries
        public void SelectListDeliveries()
        {
            WaitForElement(customerList);
            ClickElement(customerList);
            Console.WriteLine("Selected List Deliversies.");
            ClickElement(detailDeliversiesBtn);
            Console.WriteLine("Clicked on List Deliversiess Btn.");
        }

        // Delivery Details 
        public void SelectDeliveryDetails()
        {
            WaitForElement(dropListBtn);
            ClickElement(dropListBtn);
            Console.WriteLine("Clicked on Drop List Btn.");
        }

        // Move to back shift detail page 
        public void BackShiftDetailPage()
        {
            WaitForElement(toolbarListDeliveriesTitle);
            ClickElement(backBtn);
            Console.WriteLine("Clicked on Back Button on List Deliveries.");
            WaitForElement(toolbarOverviewTripsTitle);
            ClickElement(backBtn);
            Console.WriteLine("Clicked on Back Button on Overview Trips.");
        }

        // Method to Click on Shift start button
        public void ClickStartShiftBtn()
        {
            WaitForElement(startShiftBtn);
          //  HightlightElement(startShiftBtn);
     //       Console.WriteLine("Highlighted the Shift.");
            ClickElement(startShiftBtn);
            Console.WriteLine("Clicked on Start Shift Button.");
        }

        // Method to handle the popup for shift start
        public void StartShiftPopup()
        {

 /*           if (GetText(screenId).Contains("3051"))
            {
                Console.WriteLine("KM value screen");
            }
              if(GetText(popupMessage).Contains("CHRONOLOGICAL"))
                        {
                            ClickElement(popupYesBtn);
                            Console.WriteLine("Clicked on Popup i.e YOU ARE ABOUT TO START A SHIFT IN NOT CHRONOLOGICAL ORDER. CONTINUE ?");
                        }

            //     if (GetText(screenId).Contains("FUTUR"))
            if (GetText(screenId).Contains("3180"))
            {
                ClickElement(popupYesBtn);
                Console.WriteLine("Clicked on Popup i.e YOU ARE ABOUT TO START A SHIFT FROM WHICH DATE IS IN THE FUTUR. CONTINUE ? ");
            }

                        if (GetText(popupMessage).Contains("AMBIENT"))
                        {
                            ClickElement(popupNextBtn);
                            Console.WriteLine("Clicked on Popup i.e Temperature should match Temperature usually used in country:15° Temperature used by truck: AMBIENT");
                        }

                        if (GetText(popupMessage).Contains("conflict"))
                        {
                            ClickElement(popupYesBtn);
                            Console.WriteLine("Clicked on Popup i.e Temperature trailer and country in conflict");
                        } */

            if(GetTextFromID(screenId, "3051"))
            {
                Console.WriteLine("KM value screen");
            }

            if (GetTextFromID(screenId, "3180"))
            {
                ClickElement(popupYesBtn);
                Console.WriteLine("Clicked on Popup i.e YOU ARE ABOUT TO START A SHIFT FROM WHICH DATE IS IN THE FUTUR. CONTINUE ? ");
            }


        }

        // Click on Print button
        public void ClickShiftPrintBtn()
        {
            Console.WriteLine("Clicked on Shift Print Button");
            ClickElement(printBtn);
        }

        // Wait for Unplanned shift button
        public void WaitForUnplannedBtn()
        {
            System.Threading.Thread.Sleep(2000);
        }

        ///<summary> 
        /// Verify Shift print button is enabled or not
        /// </summary>
        public bool VerifyPrintShift()
        {
            return IsElementEnabled(printBtn);
        }

        ///<summary>
        /// Method to delete all shifts 
        /// </summary>
        public void DeleteAllShift()
        {
            if (GetTextFromID(screenId, "3100"))
            {
                for (int i = 1; i <= CalculateLength(shiftNumberLabelBtn); i++)
                {
                    ClickElement(shiftNumberLabelBtn);
                    ClickDeleteShittButton();
                    PopupConfirmEraseShift();
                }
            }
        }

    }
}
