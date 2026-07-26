using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestStack.White;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.InputDevices;
using System.Windows;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Automation;
using System.Collections;
using System.Diagnostics.Eventing.Reader;
using TestStack.White.Utility;
using TestStack.White.UIItems.WPFUIItems;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace BlueBoxAutomation
{


    [TestClass]
    public class TestBase
    {
        public static TestStack.White.Application application = null;
        public static TestStack.White.UIItems.WindowItems.Window window = null;
        public static Rect WindowBounds;
        public static Mouse Mouse;
        public static List<TestStack.White.UIItems.WindowItems.Window> Windows; //Public field

        public Label PlusePasses => window.Get<Label>(SearchCriteria.ByText("+").AndIndex(0));

        //public Label MinusPasses => window.Get<Label>(SearchCriteria.ByText("−").AndIndex(6)); ////Element not found :(
        //public Label MinusPassesiFine => window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(10));  //MinusIFine

        public Label PlusePower => window.Get<Label>(SearchCriteria.ByText("+").AndIndex(1));
        public Button ReturnBtn => window.Get<Button>(SearchCriteria.ByAutomationId(""));
        public Label PopUpMessage => window.Get<Label>(SearchCriteria.ByText("Handpiece was disconnected. Press OK to continue."));

        public Button dissconectHPMsg => window.Get<Button>(SearchCriteria.ByText("Button").AndAutomationId(""));

        public string csvFilePath = @"D:\ND_DOC01152-00 Professional Systems, Output Power Measurements Template (Internal for V&V) Rev A02 Last Update in Arena.xlsx";  // Ensure this points to the correct file

        public Label LogsUploadButton => window.Get<Label>(SearchCriteria.ByText("Upload Logs"));
        public Label logsButtonOutput => window.Get<Label>(SearchCriteria.ByText("Done"));
        public Label START => window.Get<Label>(SearchCriteria.ByText("START"));
        public Label STOP => window.Get<Label>(SearchCriteria.ByText("STOP"));
        public Label FaceLabel => window.Get<Label>(SearchCriteria.ByText("Face"));



        public int DecreaseButtonYlocation = 420;
        public bool csvFlag = false;

        public static void SetUpForRunner()
        {
            application = TestStack.White.Application.Launch(@"D:\App\NewProGUI.exe");
            Thread.Sleep(3000);
            Windows = application.GetWindows();
            //window = Windows.Find(x => x.Name == "");
            window = application.GetWindows().FirstOrDefault(w =>w.AutomationElement.Current.ClassName == "NavigationWindow");
            WindowBounds = window.Bounds;
        }

        public void ClickOnScreen(int offsetX, int offsetY)
        {
            // Calculate the new mouse location relative to the window
            System.Windows.Point newLocation = new System.Windows.Point(/*WindowBounds.X +*/ offsetX, /*WindowBounds.Y*/ +offsetY);
            //Console.WriteLine(newLocation);
            // Move the mouse and click
            Mouse.Instance.Location = newLocation;
            Mouse.Instance.Click();
            Thread.Sleep(500); // Optional delay to stabilize UI interaction
        }

        public string ReturntoMain()
        {
            window = application.GetWindows().FirstOrDefault(w => w.AutomationElement.Current.ClassName == "NavigationWindow");
            WindowBounds = window.Bounds;

            try
            {
                ClickOnScreen((int)ReturnBtn.Location.X + 15, (int)ReturnBtn.Location.Y);
                Thread.Sleep(500);
                if (FaceLabel != null)
                    return "Main menu location";

            }
            catch
            {
                START.Click();
                ClickOnScreen((int)ReturnBtn.Location.X + 15, (int)ReturnBtn.Location.Y);
                Thread.Sleep(500);
                if (FaceLabel != null)
                    return "Main menu location";

            }
            return "Main menu is not appear";


        }

        public void ClickOnPassesPluse(int passesMaxValue)
        {
            //for (int i = 0; i < passesMaxValue; i++)
            //{
            //    ClickOnScreen((int)PlusePasses.Location.X, (int)PlusePasses.Location.Y);
            //}
            var DecreaseButton = window.Get(SearchCriteria.ByAutomationId("IncreaseButton")); //Parent
            var AllChildren = DecreaseButton.GetMultiple(SearchCriteria.All);       //Search all children
            for (int i = 0; i < passesMaxValue; i++)
            {
                AllChildren[0].Click();

            }
        }

        public void ClickOnPassesMinus(int passesMinValue)   ////To find Minus : add Y (+) by 348 to the get (Y) location
        {
            var DecreaseButton = window.Get(SearchCriteria.ByAutomationId("DecreaseButton")); //Parent
            var AllChildren = DecreaseButton.GetMultiple(SearchCriteria.All);       //Search all children
            for (int i = 0; i < passesMinValue; i++)
            {
                AllChildren[0].Click();
                //ClickOnScreen((int)PlusePasses.Location.X, (int)PlusePasses.Location.Y + DecreaseButtonYlocation);  //348
            }
        }

        public void ClickOnPowerPluse(double powerMaxValue)
        {
            var PowerSelector = window.Get(SearchCriteria.ByAutomationId("PowerSelector")); //Parent
            var AllChildren = PowerSelector.GetMultiple(SearchCriteria.All);       //Search all children
            for (int i = 0; i < powerMaxValue; i++)
            {
                AllChildren[2].Click();
            }

            //var Power_X_locationValue = ((int)POWERIntensif.Location.X) + 20;
            //var Power_Y_locationValue = ((int)POWERIntensif.Location.Y);
            //var power_Pluse_Y_location = Power_Y_locationValue + 80;  // Y + 74 = 250

            //for (int i = 0; i < powerMaxValue; i++)
            //{
            //    ClickOnScreen(Power_X_locationValue, power_Pluse_Y_location);
            //}
        }

        public void ClickOnPowerMinus(int powerMinValue)
        {
            var PowerSelector = window.Get(SearchCriteria.ByAutomationId("PowerSelector")); //Parent
            var AllChildren = PowerSelector.GetMultiple(SearchCriteria.All);       //Search all children
            for (int i = 0; i < powerMinValue; i++)
            {
                AllChildren[20].Click();
                //ClickOnScreen((int)PlusePower.Location.X, (int)PlusePower.Location.Y + DecreaseButtonYlocation); // 345
            }
        }

        public void ClickOnPWPluseIntensif(int PWMaxValue)
        {
            //var XPWlocation = ((int)PWIntensif.Location.X) + 10;
            //var YPWlocation = ((int)PWIntensif.Location.Y);
            //var PW_Pluse_Y_location = YPWlocation + 74;  // Y + 74 = 250

            //for (int i = 0; i < PWMaxValue; i++)
            //{
            //    ClickOnScreen(XPWlocation, PW_Pluse_Y_location);
            //}

            var WidthSelector = window.Get(SearchCriteria.ByAutomationId("DurationSelector"));     //Parent
            var AllChildren = WidthSelector.GetMultiple(SearchCriteria.All);       //Search all children
            for (int i = 0; i < PWMaxValue; i++)
            {
                AllChildren[2].Click();
            }

        }

        public void ClickOnPWMinus(int PWMinValue, string HP)   ////To find Minus : Add 405 to the pluse (Y) location
        {
            if (HP == "Intensif")
            {
                var WidthSelector = window.Get(SearchCriteria.ByAutomationId("WidthSelector")); //Parent
                var AllChildren = WidthSelector.GetMultiple(SearchCriteria.All);       //Search all children
                for (int i = 0; i < PWMinValue; i++)
                {
                    AllChildren[29].Click();
                    //ClickOnScreen((int)PlusePasses.Location.X, (int)(PlusePasses.Location.Y + 405));
                }
            }
            else if (HP == "FSR")
            {
                var WidthSelector = window.Get(SearchCriteria.ByAutomationId("PulseSelector")); //Parent
                var AllChildren = WidthSelector.GetMultiple(SearchCriteria.All);       //Search all children
                for (int i = 0; i < PWMinValue; i++)
                {
                    AllChildren[11].Click();
                    //ClickOnScreen((int)PlusePasses.Location.X, (int)(PlusePasses.Location.Y + 405));
                }
            }
        }

        public void ClickOnPowerMinusIntensif(double powerMinValue, string HP)   ////To find Minus : Add 405 to the pluse (Y) location
        {
            if (HP == "Intensif")
            {
                var PowerSelector = window.Get(SearchCriteria.ByAutomationId("PowerSelector")); //Parent
                var AllChildren = PowerSelector.GetMultiple(SearchCriteria.All);       //Search all children
                for (int i = 0; i < powerMinValue; i++)
                {
                    AllChildren[29].Click();
                    //ClickOnScreen((int)PlusePower.Location.X, (int)(PlusePower.Location.Y + 405));
                }
            }
            else if (HP == "FSR")
            {
                var PowerSelector = window.Get(SearchCriteria.ByAutomationId("PowerSelector")); //Parent
                var AllChildren = PowerSelector.GetMultiple(SearchCriteria.All);       //Search all children
                for (int i = 0; i < powerMinValue; i++)
                {
                    AllChildren[20].Click();
                    //ClickOnScreen((int)PlusePower.Location.X, (int)(PlusePower.Location.Y + 405));
                }
            }

        }

        public void ClickOnDepthPluse(double depthMaxValue)
        {
            var DepthSelector = window.Get(SearchCriteria.ByAutomationId("DepthSelector")); //Parent
            var AllChildren = DepthSelector.GetMultiple(SearchCriteria.All);       //Search all children
            for (int i = 0; i < depthMaxValue; i++)
            {
                AllChildren[3].Click();
                //ClickOnScreen((int)(PlusePower.Location.X - 204), (int)PlusePower.Location.Y);
            }

        }

        public void ClickOnDepthMinus(double depthMinValue)
        {
            var DepthSelector = window.Get(SearchCriteria.ByAutomationId("DepthSelector")); //Parent
            var AllChildren = DepthSelector.GetMultiple(SearchCriteria.All);       //Search all children
            for (int i = 0; i < depthMinValue; i++)
            {
                AllChildren[20].Click();
                //ClickOnScreen((int)(PlusePower.Location.X - 204), (int)(PlusePower.Location.Y + 347));
            }
        }

        public double GetIntensifPW()
        {
            var WidthSelector = window.Get(SearchCriteria.ByAutomationId("WidthSelector"));     //Parent
            var WidthSelectorAllChildren = WidthSelector.GetMultiple(SearchCriteria.All);       //Search all children
            var textPW = WidthSelectorAllChildren[0].Name;

            return (Convert.ToDouble(textPW));
        }

        public double GetIntensifDepth()
        {
            //var textDepth = saveDepth.Text;  //Save Depth 
            var DepthValue = window.Get(SearchCriteria.ByAutomationId("DepthSelector"));     //Parent
            var DepthSelectorAllChildren = DepthValue.GetMultiple(SearchCriteria.All);       //Search all children
            var textDepth = DepthSelectorAllChildren[0].Name;

            return (Convert.ToDouble(textDepth));
        }

        public double GetIntensifPower()
        {
            //var textPower = savePower.Text;  //Save Power
            var PowerSelector = window.Get(SearchCriteria.ByAutomationId("PowerSelector"));     //Parent
            var PowerSelectorAllChildren = PowerSelector.GetMultiple(SearchCriteria.All);       //Search all children
            var textPower = PowerSelectorAllChildren[0].Name;

            return (Convert.ToDouble(textPower));
        }

        public string ConnectHP(string hpType, string connectorSide)
        {
            if (string.IsNullOrEmpty(hpType)) return "No suggestion for connecting an HP";
            else
            {
                switch (hpType)
                {
                    case "iFine MAX":
                        //System.Windows.MessageBoxResult iFineResult = MessageBox.Show(
                        //    "Please connect iFine MAX HP to the " + connectorSide + " side.\nPress OK after the HP is connected!",
                        //    "Connect Device", MessageBoxButton.OKCancel, MessageBoxImage.Information);

                        var iFineResult = ConnectDeviceWindow.ShowDialogWindow("Please connect iFine MAX HP to the " + connectorSide + " side");
                        if (iFineResult == true)
                            return "iFine MAX is not connected properlly";
                        else
                            return "iFine MAX HP is connected!";

                    case "Small MAX":
                        //System.Windows.MessageBoxResult SmallResult = MessageBox.Show(
                        //   "Please connect Small MAX HP to the " + connectorSide + " side.\nPress OK after the HP is connected!",
                        //   "Connect Device", MessageBoxButton.OKCancel, MessageBoxImage.Information);

                        var SmallResult = ConnectDeviceWindow.ShowDialogWindow("Please connect Small MAX HP to the " + connectorSide + " side");
                        if (SmallResult == true)
                            return "Small MAX is not connected properlly";
                        else
                            return "Small MAX HP is connected!";

                    case "Mini Shaper MAX":
                        //System.Windows.MessageBoxResult MiniShaperResult = MessageBox.Show(
                        //    "Please connect Mini Shaper MAX HP to the " + connectorSide + " side.\nPress OK after the HP is connected!",
                        //    "Connect Device", MessageBoxButton.OKCancel, MessageBoxImage.Information);

                        var MiniShaperResult = ConnectDeviceWindow.ShowDialogWindow("Please connect MiniShaper MAX HP to the " + connectorSide + " side");
                        if (MiniShaperResult == true)
                            return "Mini Shaper MAX is not connected properlly";
                        else
                            return "Mini Shaper MAX HP is connected!";

                    case "Shaper MAX":
                        //System.Windows.MessageBoxResult ShaperResult = MessageBox.Show(
                        //    "Please connect Shaper MAX HP to the " + connectorSide + " side.\nPress OK after the HP is connected!",
                        //    "Connect Device", MessageBoxButton.OKCancel, MessageBoxImage.Information);

                        var ShaperResult = ConnectDeviceWindow.ShowDialogWindow("Please connect Shaper MAX HP to the " + connectorSide + " side");
                        if (ShaperResult == true)
                            return "Shaper MAX is not connected properlly";
                        else
                            return "Shaper MAX HP is connected!";

                    case "Contour MAX":
                        //System.Windows.MessageBoxResult ContourResult = MessageBox.Show(
                        //   "Please connect Contour MAX HP to the " + connectorSide + " side.\nPress OK after the HP is connected!",
                        //   "Connect Device", MessageBoxButton.OKCancel, MessageBoxImage.Information);

                        var ContourResult = ConnectDeviceWindow.ShowDialogWindow("Please connect Contour MAX HP to the " + connectorSide + " side");
                        if (ContourResult == true)
                            return "Contour MAX is not connected properlly";
                        else
                            return "Contour MAX HP is connected!";

                    case "Intensif MAX":
                        //System.Windows.MessageBoxResult IntensifResult = MessageBox.Show(
                        //   "Please connect Intensif MAX HP to the " + connectorSide + " side.\nPress OK after the HP is connected!",
                        //   "Connect Device", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                        //if (IntensifResult == MessageBoxResult.OK)

                        var IntensifResult = ConnectDeviceWindow.ShowDialogWindow("Please connect Intensif MAX HP to the " + connectorSide + " side");
                        if (IntensifResult == true)
                            return "Intensif MAX is not connected properlly";
                        else
                            return "Intensif MAX HP is connected!";

                    case "FSR MAX":
                        //System.Windows.MessageBoxResult FSRresult = MessageBox.Show(
                        //   "Please connect FSR MAX HP to the " + connectorSide + " side.\nPress OK after the HP is connected!",
                        //   "Connect Device", MessageBoxButton.OKCancel, MessageBoxImage.Information);

                        var FSRResult = ConnectDeviceWindow.ShowDialogWindow("Please connect FSR MAX HP to the " + connectorSide + " side");
                        if (FSRResult == true)
                            return "FSR MAX is not connected properlly";
                        else
                            return "FSR MAX HP is connected!";

                    default: return "No suggestion for connecting any HP";
                }
            }
        }

        public string DissconectHP(string hpType)
        {
            if (string.IsNullOrEmpty(hpType)) return "No suggestion for connecting an HP";
            else
            {
                PressingStart();
                switch (hpType)
                {
                    case "iFine MAX":
                        //System.Windows.MessageBoxResult iFineResult = MessageBox.Show(
                        //    "Please disconnect iFine MAX HP.\nPress OK after the HP is disconnected!",
                        //    "Disconnect Device", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                        //    if (iFineResult == MessageBoxResult.OK && PopUpMessage.Text.Equals("Handpiece was disconnected. Press OK to continue."))
                        //{
                        var iFineResult = ConnectDeviceWindow.ShowDialogWindow("Disconnect the HP from the system and wait for the POP-UP message to appear then confirm this message.");
                        if (iFineResult == true)
                        {
                            //PopUpMessage.Text.Equals("Handpiece was disconnected. Press OK to continue.");
                            dissconectHPMsg.Click();
                            return "iFine MAX HP is not disconnected properlly";
                        }
                        else
                            return "iFine MAX HP is disconnected!";

                    case "Small MAX":
                        //System.Windows.MessageBoxResult SmallResult = MessageBox.Show(
                        //   "Please disconnect Small MAX HP.\nPress OK after the HP is disconnected!",
                        //   "Disconnect Device", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                        //if (SmallResult == MessageBoxResult.OK && PopUpMessage.Text.Equals("Handpiece was disconnected. Press OK to continue."))
                        var SmallResult = ConnectDeviceWindow.ShowDialogWindow("Disconnect the HP from the system and wait for the POP-UP message to appear then confirm this message.");
                        if (SmallResult == true)
                        {
                            dissconectHPMsg.Click();
                            return "Small MAX is not disconnected properlly";
                        }
                        else
                            return "Small MAX HP is disconnected!";

                    case "Mini Shaper MAX":
                        //System.Windows.MessageBoxResult MiniShaperResult = MessageBox.Show(
                        //    "Please disconnect Mini Shaper MAX HP.\nPress OK after the HP is disconnected!",
                        //    "Disconnect Device", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                        //if (MiniShaperResult == MessageBoxResult.OK && PopUpMessage.Text.Equals("Handpiece was disconnected. Press OK to continue."))
                        var MiniShaperResult = ConnectDeviceWindow.ShowDialogWindow("Disconnect the HP from the system and wait for the POP-UP message to appear then confirm this message.");
                        if (MiniShaperResult == true)
                        {
                            dissconectHPMsg.Click();
                            return "Mini Shaper MAX is not disconnected properlly";
                        }
                        else
                            return "Mini Shaper MAX HP is disconnected!";

                    case "Shaper MAX":
                        //System.Windows.MessageBoxResult ShaperResult = MessageBox.Show(
                        //    "Please disconnect Shaper MAX HP.\nPress OK after the HP is disconnected!",
                        //    "Disconnect Device", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                        //if (ShaperResult == MessageBoxResult.OK && PopUpMessage.Text.Equals("Handpiece was disconnected. Press OK to continue."))
                        var ShaperResult = ConnectDeviceWindow.ShowDialogWindow("Disconnect the HP from the system and wait for the POP-UP message to appear then confirm this message.");
                        if (ShaperResult == true)
                        {
                            dissconectHPMsg.Click();
                            return "Shaper MAX is not disconnected properlly";
                        }
                        else
                            return "Shaper MAX HP is disconnected!";

                    case "Contour MAX":
                        //System.Windows.MessageBoxResult ContourResult = MessageBox.Show(
                        //   "Please disconnect Contour MAX HP.\nPress OK after the HP is disconnected!",
                        //   "Disconnect Device", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                        //if (ContourResult == MessageBoxResult.OK && PopUpMessage.Text.Equals("Handpiece was disconnected. Press OK to continue."))
                        var ContourResult = ConnectDeviceWindow.ShowDialogWindow("Disconnect the HP from the system and wait for the POP-UP message to appear then confirm this message.");
                        if (ContourResult == true)
                        {
                            dissconectHPMsg.Click();
                            return "Contour MAX is not disconnected properlly";
                        }
                        else
                            return "Contour MAX HP is disconnected!";

                    case "Intensif MAX":
                        //System.Windows.MessageBoxResult IntensifResult = MessageBox.Show(
                        //   "Please disconnect Intensif MAX HP.\nPress OK after the HP is disconnected!",
                        //   "Disconnect Device", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                        //if (IntensifResult == MessageBoxResult.OK && PopUpMessage.Text.Equals("Handpiece was disconnected. Press OK to continue."))
                        var IntensifResult = ConnectDeviceWindow.ShowDialogWindow("Disconnect the HP from the system and wait for the POP-UP message to appear then confirm this message.");
                        if (IntensifResult == true)
                        {
                            dissconectHPMsg.Click();
                            return "Intensif MAX is not disconnected properlly";
                        }
                        else
                            return "Intensif MAX HP is disconnected!";

                    case "FSR MAX":
                        //System.Windows.MessageBoxResult FSRresult = MessageBox.Show(
                        //   "Please disconnect FSR MAX HP.\nPress OK after the HP is disconnected!",
                        //   "Disconnect Device", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                        //if (FSRresult == MessageBoxResult.OK && PopUpMessage.Text.Equals("Handpiece was disconnected. Press OK to continue."))
                        var FSRresult = ConnectDeviceWindow.ShowDialogWindow("Disconnect the HP from the system and wait for the POP-UP message to appear then confirm this message.");
                        if (FSRresult == true)
                        {
                            dissconectHPMsg.Click();
                            return "FSR MAX is not disconnected properlly";
                        }
                        else
                            return "FSR MAX HP is disconnected!";

                    default: return "No suggestion for disconnected any HP";
                }
            }
        }
        public string CheckNoRotation(bool isMotionDetected)
        {
            if (isMotionDetected)
            {
                PressingStop();
                return "No motion warning functioning properly";
            }
            else
            {
                return "No motion warning NOT functioning properly";
            }
        }
        public string CheckRotation(bool isMotionDetected)
        {
            if (isMotionDetected)
            {
                return "Rotation warning is functioning properly";
            }
            else
            {
                return "Rotating HP NOT functioning properly";
            }
        }
        public string EvaluateBadContactDetection(bool isBadContactDetected)
        {
            if (isBadContactDetected)
            {
                return "Bad contact warning is functioning properly";
            }
            else
            {
                return "Bad contact warning is NOT functioning properly";
            }
        }

        public string ManualMotionTest()
        {
            //MessageBoxResult result = MessageBox.Show(
            //    "Please rotate the device.\nPress OK if motion is detected.",
            //    "Rotate Device", MessageBoxButton.OKCancel, MessageBoxImage.Information);

            var result = ConnectDeviceWindow.ShowDialogWindow("Motion test, please rotate the HP, press OK if motion message is deteced");

            bool isMotionDetected = Convert.ToBoolean(result);
            return CheckRotation(isMotionDetected);
        }

        public string ManualNoMotionTest()
        {
            //MessageBoxResult result = MessageBox.Show(
            //  "Please pause rotate the device.\nPress OK if No motion is detected.",
            //  "Rotate Device", MessageBoxButton.OKCancel, MessageBoxImage.Information);

            var result = ConnectDeviceWindow.ShowDialogWindow("Please pause to rotate the HP, press OK if message and error suond is deteced");

            bool isMotionDetected = Convert.ToBoolean(result);
            return CheckNoRotation(isMotionDetected);
        }

        public string ManualBadContactTest()
        {
            PressingStart();
            //MessageBoxResult result = MessageBox.Show(
            //    "Please simulate a bad contact.\n Click OK if Bad contact is detected.",
            //    "Coupling Device", MessageBoxButton.OKCancel, MessageBoxImage.Information);
            var result = ConnectDeviceWindow.ShowDialogWindow("Bad contact test, please simulate bad contact , press OK if message and error sound is deteced");

            bool isBadContactDetected = Convert.ToBoolean(result);
            return EvaluateBadContactDetection(isBadContactDetected);
        }

        public string GetCurrentPowerValue()
        {
            //var label = window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(1));
            //return label?.Text?.Trim();

            var PowerSelector = Retry.For(() => window.Get(SearchCriteria.ByAutomationId("PowerSelector")), TimeSpan.FromMilliseconds(100)); //Parent
            var AllChildren = PowerSelector.GetMultiple(SearchCriteria.All);       //Search all children
            var power = AllChildren.FirstOrDefault(c => int.TryParse(c.Name, out _));

            Console.WriteLine(power?.GetType().Name);
            return ((Label)power).Text.Trim();
        }

        public string GetCurrentPassesValue()
        {
            //var Label = window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(0));
            //return Label?.Text?.Trim();

            var PassesSelector = Retry.For(() => window.Get(SearchCriteria.ByAutomationId("PassesSelector")), TimeSpan.FromMilliseconds(100)); //Parent
            var AllChildren = PassesSelector.GetMultiple(SearchCriteria.All);       //Search all children
            var passes = AllChildren.FirstOrDefault(c => int.TryParse(c.Name, out _));

            Console.WriteLine(passes?.GetType().Name);
            return ((Label)passes).Text.Trim();

        }

        //INSPECT FOR INTERVAL NAME
        public string GetCurrentIntervalTimeValue()
        {
            //var intervalEnds = Retry.For(() => window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(11)), TimeSpan.FromMilliseconds(100));

            var PulseControl = Retry.For(() => window.Get(SearchCriteria.ByAutomationId("PulseControl")), TimeSpan.FromMilliseconds(100)); //Parent
            var AllChildren = PulseControl.GetMultiple(SearchCriteria.All);       //Search all children
            var intervalEnds = AllChildren.FirstOrDefault(c => int.TryParse(c.Name, out _));

            Console.WriteLine(intervalEnds?.GetType().Name);
            return ((Label)intervalEnds).Text.Trim();


            //if (index >= 0) למציאת הילד הבא לפי אינדקס
            //{
            //    Console.WriteLine("המספר הראשון שנמצא: " + AllChildren[index].Name);

            //    if (index + 1 < AllChildren.Count)
            //    {
            //        Console.WriteLine("הבא אחריו: " + AllChildren[index + 1].Name);
            //    }
            //    else
            //    {
            //        Console.WriteLine("אין אלמנט נוסף אחריו.");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("לא נמצא אלמנט עם מספר.");
            //}
        }

        public bool WaitUntil(Func<bool> condition, int timeoutMs, string errorMessage)
        {
            var startTime = DateTime.Now;

            while ((DateTime.Now - startTime).TotalMilliseconds < timeoutMs)
            {
                try
                {
                    if (condition())
                    {
                        return true;
                    }
                }
                catch
                {
                    // ignore temporary UI exceptions
                }

                Thread.Sleep(250);
            }

            throw new Exception(errorMessage);
        }
        public void WaitForTransition()
        {
            Thread.Sleep(1000);
        }

        public void PressStartAndWaitReady()
        {
            START.Click();

            WaitUntil(() => STOP != null && STOP.Visible, 15000, "System did not enter READY state");

            Thread.Sleep(1000); // debounce
        }

        public void PressStopAndWaitStandby()
        {
            STOP.Click();

            WaitUntil(() => START != null && START.Visible, 15000, "System did not return to STOP state");

            Thread.Sleep(1000);
        }


        public string UploadLogs()
        {
            ClickOnScreen((int)ReturnBtn.Location.X, (int)ReturnBtn.Location.Y);
            Thread.Sleep(2000);

            MessageBoxResult result = MessageBox.Show(
                "Please connect USB to the system.\nClick OK after device is connected.",
                "Connect Device", MessageBoxButton.OKCancel, MessageBoxImage.Information);
            if (result == MessageBoxResult.OK)
            {
                LogsUploadButton.Click();
                Thread.Sleep(7000);
                if (logsButtonOutput.Text.Equals("Done"))
                    return "Logs upload sucsses";
                else
                    return "Disk on key is not insert!";
            }
            else
            {
                return "No USB is conncted to the system";
            }
        }

        public string PulseTimer()
        {
            MessageBoxResult result = MessageBox.Show(
           "Counter dec.\nPlease emit pulse to check coutner decrease by 1.",
           "Counter dec.", MessageBoxButton.OKCancel, MessageBoxImage.Information);

            var saveCurrentPasses = GetCurrentPassesValue();
            int IntsaveCurrentPasses = Convert.ToInt32(saveCurrentPasses);
            Console.WriteLine("Current pass saved: " + IntsaveCurrentPasses);
            Thread.Sleep(500);
            PressingStart();   //Start button
            Thread.Sleep(1000);

            while (true)
            {
                var currentValue = GetCurrentIntervalTimeValue();

                if (currentValue == "0")
                {
                    Thread.Sleep(1000);
                    break;
                }
                else
                {
                    //Console.WriteLine("wait for paasses to decrease by 1, value is: " + currentValue);
                }
            }

            var newPasses = GetCurrentPassesValue();
            int IntNewPasses = Convert.ToInt32(newPasses);
            Console.WriteLine("New pass saved: " + IntNewPasses);
            PressingStop();
            Thread.Sleep(1000);

            if (IntsaveCurrentPasses - IntNewPasses == 1)
                return "Passes not decreased by 1";
            else
                return "Passes decreased by 1";
        }

        public void CSVOpenCheck()
        {
            if (csvFlag == false)
            {
                csvFlag = true;
                Process.Start(csvFilePath);
                Thread.Sleep(3000);
            }
            else { }
        }

        public void pressRetreat()
        {
            ClickOnScreen(3964, 940);
        }

        public void PressingStart()
        {
            START.Click();
            Thread.Sleep(2000);
        }
        public void PressingStop()
        {
            STOP.Click();
            Thread.Sleep(2000);
        }

        [AssemblyCleanup]
        public static void TearDown()
        {
            application?.Close();
            application?.Dispose();
        }
    }
}
