using NUnit.Framework;
using Q8MobileAutomation.Main.PageObjects;
using Q8MobileAutomation.Main.Utils;
using System;
using Xamarin.UITest;

namespace Q8MobileAutomation.Test
{
    [TestFixture(Platform.Android)]
    public class RunAutomation
    {
        public static IApp app;
        Platform platform;

        #region Page object classes reference

        Helper helperObj = null;
        MainPage mainPageObj = null;
        LoginPage loginPageObj = null;
        ComptTempPage comptTempObj = null;
        ActualStockPage actStockObj = null;
        ComptEditPage comptEditObj = null;
        ComptCapacity comptCapacityObj = null;
        ShiftStartPage selShiftObj = null;
        TripStartPage trpStartObj = null;
        TravellingToPage trvlToObj = null;
        KMControlPage kmCtrlObj = null;
        ComptStatusPage comptStatusObj = null;
        ConfirmDepotPage cnfrmDepotObj = null;
        ConfirmNamePage cnfrmNameObj = null;
        PlannedLoading plannedLdgObj = null;
        ActualLoading actualLdgObj = null;
        LoadingSummary ldgSummaryObj = null;
        LoadingInfo ldgInfoObj = null;
        OverrideNoMixCode ovrdCodeobj = null;
        ComptAssignmentPage comptAssgnObj = null;
        CustomerSelection custSelObj = null;
        DeliveryDetails delDetailsObj = null;
        CustomerArrival custArrivalObj = null;
        PlannedDeliveryDetails plndDelDetObj = null;
        ReviewTankDips rvwTnkDipsObj = null;
        DeliveryScheme delSchemeObj = null;
        ProductDischarge prodDschgObj = null;
        ConfirmDelivery cnfrmDelObj = null;
        ADRStart adrobj = null;
        ExcelReader xlRdrObj = null;
        BreakPage breakObj = null;
        TripEndPage tripendObj = null;
        ShiftEndPage shiftendObj = null;

        #endregion

        bool isSpotTrailer = false;
        string noOfCompt = string.Empty;
        string comptCapacity = string.Empty;
        string tankNo1 = string.Empty;
        string tankNo2 = string.Empty;
        string tankNo3 = string.Empty;
        int stockVal1 ;
        int stockVal2 ;
        int stockVal3 ;
        int stockVal;
        int[] calculatedValue = null;

        //one argument class constructor
        public RunAutomation(Platform platform)
        {
            this.platform = platform;

            #region Reference initialization
            helperObj = new Helper();
            mainPageObj = new MainPage();
            loginPageObj = new LoginPage();
            comptTempObj = new ComptTempPage();
            actStockObj = new ActualStockPage();
            comptEditObj = new ComptEditPage();
            comptCapacityObj = new ComptCapacity();
            selShiftObj = new ShiftStartPage();
            trpStartObj = new TripStartPage();
            trvlToObj = new TravellingToPage();
            kmCtrlObj = new KMControlPage();
            xlRdrObj = new ExcelReader();
            comptStatusObj = new ComptStatusPage();
            cnfrmDepotObj = new ConfirmDepotPage();
            cnfrmNameObj = new ConfirmNamePage();
            plannedLdgObj = new PlannedLoading();
            actualLdgObj = new ActualLoading();
            ldgSummaryObj = new LoadingSummary();
            ldgInfoObj = new LoadingInfo();
            ovrdCodeobj = new OverrideNoMixCode();
            comptAssgnObj = new ComptAssignmentPage();
            custSelObj = new CustomerSelection();
            delDetailsObj = new DeliveryDetails();
            custArrivalObj = new CustomerArrival();
            plndDelDetObj = new PlannedDeliveryDetails();
            rvwTnkDipsObj = new ReviewTankDips();
            delSchemeObj = new DeliveryScheme();
            prodDschgObj = new ProductDischarge();
            cnfrmDelObj = new ConfirmDelivery();
            adrobj = new ADRStart();
            breakObj = new BreakPage();
            tripendObj = new TripEndPage();
            shiftendObj = new ShiftEndPage();
            #endregion

            xlRdrObj.GetCompleteExcelData();
            isSpotTrailer = Convert.ToBoolean(xlRdrObj.GetValueFromSheet("TrailerDetails", "SpotTrailer"));
            noOfCompt = xlRdrObj.GetValueFromSheet("TrailerDetails", "NoOfCompartments");
            comptCapacity = xlRdrObj.GetValueFromSheet("TrailerDetails", "CompartmentCapacity");
            tankNo1 = xlRdrObj.GetValueFromSheet("TrailerDetails", "TankNumber1");
            tankNo2 = xlRdrObj.GetValueFromSheet("TrailerDetails", "TankNumber2");
            tankNo3 = xlRdrObj.GetValueFromSheet("TrailerDetails", "TankNumber3");
            stockVal1 = Convert.ToInt32(xlRdrObj.GetValueFromSheet("TrailerDetails", "StockValue1"));
            stockVal2 = Convert.ToInt32(xlRdrObj.GetValueFromSheet("TrailerDetails", "StockValue2"));
            stockVal3 = Convert.ToInt32(xlRdrObj.GetValueFromSheet("TrailerDetails", "StockValue3"));
            stockVal = stockVal1 + stockVal1 + stockVal3;

            calculatedValue = new int[Convert.ToUInt32(noOfCompt)];
        }

        /// <summary>
        /// Method to called be only once before running any tests 
        /// </summary>
        [OneTimeSetUp]
        public void Init()
        {
            helperObj.CloseExcelInstance();
            app = Helper.StartApp(platform);
            //generate compartment capacities
            for (int ctr = 0; ctr < Convert.ToInt32(noOfCompt); ctr++)
            {
                calculatedValue[ctr] = Convert.ToInt32(comptCapacity) + (ctr + 1) * 500;
            }
        }

        /// <summary>
        /// Method to open the application
        /// </summary>
        [Test, Order(1)]
        public void OpenApplication_Test()

        {
            Console.WriteLine("Opened the application");
            comptEditObj.WaitForSyncProcessBar();
            Assert.AreEqual("Start\nNederlands", mainPageObj.VerifyStartDutchApplication());
            Assert.AreEqual("Start\nFrançais", mainPageObj.VerifyStartFrenchApplication());
            Assert.AreEqual("Start\nEnglish", mainPageObj.VerifyStartEnglishApplication());
            Assert.AreEqual(mainPageObj.VerifyTitleName(), xlRdrObj.GetValueFromSheet("Language", "ScreenTitle"));
            mainPageObj.SelectLanguage(xlRdrObj.GetValueFromSheet("Language", "Langoption"));
            mainPageObj.TranstionBtwScreens();
        }

        /// <summary>
        /// Method for login into the application
        /// </summary>
        [Test, Order(2)]
        public void ApplicationLogin_Test()
        {
            Console.WriteLine("Opened the Shift Finished Screen");
            Assert.AreEqual(helperObj.VerifyScreenID(), "1011");
            loginPageObj.ClickLogon();

        }

        /// <summary>
        /// Method for login into application
        /// </summary>
        [Test, Order(3)]
        public void DriverLogin_Test()
        {
            Console.WriteLine("Opened the Enter Your Driver Login Screen");
            loginPageObj.EnterDriverPIN(xlRdrObj.GetValueFromSheet("DriverDetails", "DriverPIN"));
            loginPageObj.SelectTruckNumber(xlRdrObj.GetValueFromSheet("DriverDetails", "TruckNO"));
            Assert.AreEqual(mainPageObj.VerifyScreenID(), "3031");
            cnfrmNameObj.SelectDeliveryCountry(xlRdrObj.GetValueFromSheet("DriverDetails", "Country"));
            cnfrmNameObj.EnterTruckID(xlRdrObj.GetValueFromSheet("DriverDetails", "LicencePlate"));
            cnfrmNameObj.EnterTrailerID(xlRdrObj.GetValueFromSheet("DriverDetails", "TrailerID"));
            Assert.AreEqual(xlRdrObj.GetValueFromSheet("DriverDetails", "TruckNO"), cnfrmNameObj.VerifyTruckNumber());
            Assert.AreEqual(xlRdrObj.GetValueFromSheet("DriverDetails", "DriverName").Trim(), cnfrmNameObj.VerifyDriverName().Trim());
            cnfrmNameObj.ConfirmVehicleDetails();
            mainPageObj.TranstionBtwScreens();
        }

        /// <summary>
        /// Method to verify the compartment stock check test
        /// </summary>
        [Test, Order(4)]
        public void Compartment_StockCheck_Test()
        {
            Assert.Multiple(() =>
{
    if (isSpotTrailer)
    {
        comptTempObj.ClickOtherCompartmentButton();
        comptTempObj.EnterNumberofCompartment(noOfCompt);
        for (int ctr = 0; ctr < Convert.ToInt32(noOfCompt); ctr++)
        {
            comptCapacityObj.SelectCompartment_EnterCapacity(ctr + 1, calculatedValue[ctr].ToString());
        }
        comptCapacityObj.ClickConfirmButton();

        //verify compartment capacity
        for (int ctr = 0; ctr < Convert.ToInt32(noOfCompt); ctr++)
        {
            Assert.AreEqual(calculatedValue[ctr].ToString(), helperObj.GetValue(comptCapacityObj.capacityEle, ctr + 1));
            Console.WriteLine("Capacity as  '" + comptCapacity + "' verified for compartment : " + ctr);
        }
        comptCapacityObj.ConfirmSpotTrailerCompartments();
        comptEditObj.WaitForSyncProcessBar();
    }
    else
    {
        comptTempObj.ConfirmCompartment_MeterTemperature();
    }
    
    actStockObj.EditActualStock();
    comptEditObj.SelectTankToEdit(xlRdrObj.GetValueFromSheet("TrailerDetails", "TankNumber1"));
    comptEditObj.EnterNewStockValue(xlRdrObj.GetValueFromSheet("TrailerDetails", "StockValue1"));
    comptEditObj.SelectProductValue(xlRdrObj.GetValueFromSheet("TrailerDetails", "Product1"));
    comptEditObj.SelectTankToEdit(xlRdrObj.GetValueFromSheet("TrailerDetails", "TankNumber2"));
    comptEditObj.EnterNewStockValue(xlRdrObj.GetValueFromSheet("TrailerDetails", "StockValue2"));
    comptEditObj.SelectProductValue(xlRdrObj.GetValueFromSheet("TrailerDetails", "Product2"));
    comptEditObj.SelectTankToEdit(xlRdrObj.GetValueFromSheet("TrailerDetails", "TankNumber3"));
    comptEditObj.EnterNewStockValue(xlRdrObj.GetValueFromSheet("TrailerDetails", "StockValue3")); 
    comptEditObj.SelectProductValue(xlRdrObj.GetValueFromSheet("TrailerDetails", "Product3"));
    comptEditObj.ConfirmCompartmentEdit();
  
    adrobj.AdrNextBtn();
    System.Threading.Thread.Sleep(1000);

    //verify stock value
   
    Assert.AreEqual(stockVal1, Convert.ToInt32(helperObj.GetValue(actStockObj.stockValEle, Convert.ToInt16(tankNo1) - 1)));
    Assert.AreEqual(stockVal2, Convert.ToInt32(helperObj.GetValue(actStockObj.stockValEle, Convert.ToInt16(tankNo2) - 1)));
    Assert.AreEqual(stockVal3, Convert.ToInt32(helperObj.GetValue(actStockObj.stockValEle, Convert.ToInt16(tankNo3) - 1)));

    actStockObj.ConfirmActualStock();
});
        }
        /// <summary>
        /// Method to create to unplannned shift
        /// </summary>
        [Test, Order(5)]
        public void CreateUnplannedShift_Test()
        {
            comptEditObj.WaitForSyncProcessBar();
            selShiftObj.DeleteAllShift();
            selShiftObj.CreateUnplannedShift();
            selShiftObj.SelectCustomerName(xlRdrObj.GetValueFromSheet("ShiftDetails", "UnplannedShift"));
            selShiftObj.SelectCustomerElement();
            selShiftObj.SelectUnplannedCustomerDrop();
        }
 /*       /// <summary>
        /// Method to view the shift detail
        /// </summary>
        [Test, Order(6)]
        public void DetailsShift_Test()
        {
            helperObj.WaitForElement(xlRdrObj.GetValueFromSheet("ShiftDetails", "ShiftNumber"));
            helperObj.HightlightElement(xlRdrObj.GetValueFromSheet("ShiftDetails", "ShiftNumber"));
            selShiftObj.SelectShift(xlRdrObj.GetValueFromSheet("ShiftDetails", "ShiftNumber"));
            selShiftObj.ViewShiftDetails();
            selShiftObj.SelectOverviewTrips();
            selShiftObj.SelectListDeliveries();
            selShiftObj.SelectDeliveryDetails();
            selShiftObj.BackShiftDetailPage();
        }

        /// <summary>
        /// Methos to shift print button
        /// </summary>
        [Test, Order(7)]
        public void ShiftPrint_Test()
        {
            Assert.AreEqual(false, selShiftObj.VerifyPrintShift());
        }

        /// <summary>
        /// MEthod to delete the shift
        /// </summary>
        [Test, Order(8)]
        public void DeleteShift_Test()
        {
            helperObj.WaitForElement(xlRdrObj.GetValueFromSheet("ShiftDetails", "ShiftNumber"));
            selShiftObj.SelectShift(xlRdrObj.GetValueFromSheet("ShiftDetails", "ShiftNumber"));
            selShiftObj.ClickDeleteShittButton();
            selShiftObj.PopupConfirmEraseShift();
        }
        /// <summary>
        /// Mothod to verify the Shift start
        /// </summary>
        [Test, Order(9)]
        public void StartShift_Test()
        {
            selShiftObj.WaitForUnplannedBtn();
            selShiftObj.CreateUnplannedShift();
            selShiftObj.SelectCustomerName(xlRdrObj.GetValueFromSheet("ShiftDetails", "UnplannedShift"));
            selShiftObj.SelectCustomerElement();
            selShiftObj.SelectUnplannedCustomerDrop();
            selShiftObj.SelectShift(xlRdrObj.GetValueFromSheet("ShiftDetails", "ShiftNum"));
            selShiftObj.ClickStartShiftBtn();
            selShiftObj.StartShiftPopup();
            kmCtrlObj.EnterKMCurrentValue(xlRdrObj.GetValueFromSheet("KMControl", "CurrentValue"));
            kmCtrlObj.SelectDepot(xlRdrObj.GetValueFromSheet("KMControl", "SelectDepot"));
            kmCtrlObj.StartLocationShiftPopup();
        }

        /// <summary>
        /// Method to verify the trip start
        /// </summary>
        [Test, Order(10)]
        public void StartTrip_Test()
        {
            trpStartObj.SelectTrip(xlRdrObj.GetValueFromSheet("TripDetails", "TripNumber"));
            trpStartObj.StartTrip();
            kmCtrlObj.EnterKMCurrentValue(xlRdrObj.GetValueFromSheet("KMControl", "CurrentTripValue"));
        }

        /// <summary>
        /// Method for travel menu page
        /// </summary>
        [Test, Order(11)]
        public void TravellingTo_Test()
        {

            trvlToObj.PerformLoad();
        }
        /// <summary>
        /// Method to verify the load flow 
        /// </summary>
        [Test, Order(12)]
        public void Loading_Test()
        {
            // KM Control
            kmCtrlObj.SelectDepot(xlRdrObj.GetValueFromSheet("Loading", "SelectDepot"));
            adrobj.AdrNextBtn();
            cnfrmDepotObj.ConfirmDepot();
            adrobj.GPSPopupBtn();
            kmCtrlObj.EnterKMCurrentValue(xlRdrObj.GetValueFromSheet("KMControl", "CurrentLoadValue"));
            plannedLdgObj.ClickNext();
            ldgSummaryObj.ConfirmLoading();
            adrobj.GPSPopupBtnPowerInterrupt();
            kmCtrlObj.EnterKMCurrentValue(xlRdrObj.GetValueFromSheet("KMControl", "CurrentLoadValue2")); //screen not developed

            ///No Mix load code
            actualLdgObj.ClickNoMixLoadCode();
            actualLdgObj.SelectNoMixReason(xlRdrObj.GetValueFromSheet("Loading", "NoMixReason"));
            actualLdgObj.EnterNoMixCode(xlRdrObj.GetValueFromSheet("Loading", "NoMixCode"));
            ovrdCodeobj.ClickNext();

            actualLdgObj.ClickSelectLoadedProductButton();
            actualLdgObj.SelectProductFromList(xlRdrObj.GetValueFromSheet("Loading", "FirstProduct"));

            actualLdgObj.EnterLoadQuantity(xlRdrObj.GetValueFromSheet("Loading", "LoadValue"));

            actualLdgObj.AssignAlternativeQuantity(xlRdrObj.GetValueFromSheet("Loading", "LoadValue"));

            comptAssgnObj.SelectProduct(xlRdrObj.GetValueFromSheet("Loading", "FirstCompartment"));

            comptAssgnObj.ConfirmLoading();

            comptAssgnObj.ConfirmDieselLoading();

            actualLdgObj.ClickAllLoadedProductsButton();

            ldgInfoObj.ClickBolNum();

            ldgInfoObj.EnterBOLNumber(xlRdrObj.GetValueFromSheet("Loading", "BolNumber"));

            comptAssgnObj.ConfirmDieselLoading();

        }

        /// <summary>
        /// Method to verify the delivery flow
        /// </summary>
        [Test, Order(13)]
        public void Delivery_Test()
        {
            trvlToObj.ClickDelivery();
            custSelObj.OpenDetails();
            adrobj.AdrNextBtn();
            delDetailsObj.ConfirmNextLocation();
            //add code to verify customer details name with pincode
            custArrivalObj.ConfirmArrival();
            kmCtrlObj.EnterKMCurrentValue(xlRdrObj.GetValueFromSheet("Delivery", "DeliveryKM"));

            plndDelDetObj.ClickAutomaticDipsAvailableButton();
            rvwTnkDipsObj.ClickCanNotTankDip();
            rvwTnkDipsObj.SelectTank(xlRdrObj.GetValueFromSheet("Delivery", "TankNumber"));
            rvwTnkDipsObj.EnterDipValue(xlRdrObj.GetValueFromSheet("Delivery", "DipValue"));
            rvwTnkDipsObj.ClickConfirm();
            //add code to verify value
            delSchemeObj.ClickNext();
            prodDschgObj.SelectProduct(xlRdrObj.GetValueFromSheet("Delivery", "ProductName"));
            prodDschgObj.EnterDeliveredVolume(xlRdrObj.GetValueFromSheet("Delivery", "DeliveryVolume"));
            prodDschgObj.SelectFromWhichCompartment(xlRdrObj.GetValueFromSheet("Delivery", "CustomerTankNumber"));
            prodDschgObj.ClickConfirmInputs();

            prodDschgObj.SelectCompartment(xlRdrObj.GetValueFromSheet("Delivery", "CompartmentNumber"));
            prodDschgObj.ClickCustomerTankConfirm();
            //add code to check volumes delivered
            cnfrmDelObj.ClickConfirmVolume();
            prodDschgObj.SelectCustomerTank(xlRdrObj.GetValueFromSheet("Delivery", "CustomerTankNumber"));
            cnfrmDelObj.ClickConfirmStock();

        }
        
        /// <summary>
        /// Verify the Break Functionality
        /// </summary>
        [Test, Order(14)]
        public void BreakLocations_Test()
        {
            breakObj.ClickBreakLocation();
            breakObj.SelectBreakType(xlRdrObj.GetValueFromSheet("Break", "BreakType"));
            kmCtrlObj.EnterKMCurrentValue(xlRdrObj.GetValueFromSheet("Break", "BreakKM"));
            breakObj.ClickEndBreakBtn();
            breakObj.EnterDieselOwnConsumption(xlRdrObj.GetValueFromSheet("Break", "DieselOwn"));
            breakObj.EnterAdBlueOwnConsumption(xlRdrObj.GetValueFromSheet("Break", "ADBlue"));
            breakObj.ClickOwnConsumptionBtn();
            kmCtrlObj.EnterKMCurrentValue(xlRdrObj.GetValueFromSheet("Break", "BreakEndKM"));
        }

        /// <summary>
        /// Verify the Trip End functionality
        /// </summary>

        [Test, Order(15)]
        public void CloseTrip_Test()
        {
            tripendObj.ClickMainMenuBtn();
            tripendObj.ClickCloseTripBtn();
            tripendObj.CloseTripPopup();
            tripendObj.CloseTripDepotList(xlRdrObj.GetValueFromSheet("TripEnd", "TripEndDepot"));
            adrobj.AdrNextBtn();
            tripendObj.ClickConfirmThisDepotBtn();
            tripendObj.ClickGPSPositionBtn();
            kmCtrlObj.EnterKMCurrentValue(xlRdrObj.GetValueFromSheet("TripEnd", "TripEndKM"));
            tripendObj.ConfirmCheckMileageBtn();
        }
        /// <summary>
        /// Method to verify the shift end
        /// </summary>
        [Test, Order(16)]
        public void ShiftEnd_Test()
        {
            shiftendObj.ClickCloseShiftBtn();
            shiftendObj.ClickMiddleShiftBtn();
            shiftendObj.ClickConfirmEndShiftBtn();
            kmCtrlObj.EnterKMCurrentValue(xlRdrObj.GetValueFromSheet("ShiftEnd", "ShiftEndKM"));
            shiftendObj.ConfirmShiftCheckMileageBtn();
        }

    */   [Test, Order(17)]
        public void ReplTest()
        {
            app.Repl();
        }

        /// <summary>
        /// Method to be called in last when all tests have been executed either with exception also
        /// </summary>
        [OneTimeTearDown]
        public void GetReport()
        {
            try
            {
                helperObj.GenerateReport();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception ::: " + ex.ToString());
            }
        }
    }
}
