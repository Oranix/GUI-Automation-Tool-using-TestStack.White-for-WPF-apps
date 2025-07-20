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
        //public Label MinusPasses => window.Get<Label>(SearchCriteria.ByText("−")); ////Element not found :(
        public Label PlusePower => window.Get<Label>(SearchCriteria.ByText("+").AndIndex(1));
        public Button ReturnBtn => window.Get<Button>(SearchCriteria.ByAutomationId(""));
        public Label PopUpMessage => window.Get<Label>(SearchCriteria.ByText("Handpiece was disconnected. Press OK to continue."));

        public Button dissconectHPMsg => window.Get<Button>(SearchCriteria.ByText("Button").AndAutomationId(""));

        public string csvFilePath = @"D:\ND_DOC01152-00 Professional Systems, Output Power Measurements Template (Internal for V&V) Rev A02 Last Update in Arena.xlsx";  // Ensure this points to the correct file

        public Label LogsUploadButton => window.Get<Label>(SearchCriteria.ByText("Upload Logs"));
        public Label logsButtonOutput => window.Get<Label>(SearchCriteria.ByText("Done"));
        public Label START => window.Get<Label>(SearchCriteria.ByText("START"));
        public Label STOP => window.Get<Label>(SearchCriteria.ByText("STOP"));



        public bool csvFlag = false;

        [AssemblyInitialize]
        public static void SetUp(TestContext context)
        {
            application = TestStack.White.Application.Launch(@"D:\App\NewProGUI.exe");
            Thread.Sleep(3000);
            Windows = application.GetWindows();
            window = Windows.Find(x => x.Name == "");
            WindowBounds = window.Bounds;
        }

        public void ClickOnScreen(int offsetX, int offsetY)
        {
            // Calculate the new mouse location relative to the window
            System.Windows.Point newLocation = new System.Windows.Point(/*WindowBounds.X +*/ offsetX, /*WindowBounds.Y*/ +offsetY);
            //Console.WriteLine(newLocation);
            // Move the mouse and perform the click
            Mouse.Instance.Location = newLocation;
            Mouse.Instance.Click();
            Thread.Sleep(500); // Optional delay to stabilize UI interaction
        }
        public void ReturntoMain()
        {
            try
            {
                ClickOnScreen((int)ReturnBtn.Location.X + 15, (int)ReturnBtn.Location.Y);
                Thread.Sleep(2000);
            }
            catch
            {
                START.Click();
                Thread.Sleep(2000);
                ClickOnScreen((int)ReturnBtn.Location.X + 15, (int)ReturnBtn.Location.Y);
                Thread.Sleep(2000);
            }
        }
        public void ClickOnPassesPluse(int passesMaxValue)
        {
            for (int i = 0; i < passesMaxValue; i++)
            {
                ClickOnScreen((int)PlusePasses.Location.X, (int)PlusePasses.Location.Y);
            }
        }
        public void ClickOnPassesMinus(int passesMinValue)   ////To find Minus : Add 348 to the pluse (Y) location
        {
            for (int i = 0; i < passesMinValue; i++)
            {
                ClickOnScreen((int)PlusePasses.Location.X, (int)PlusePasses.Location.Y + 348);
            }
        }
        public void ClickOnPowerPluse(int powerMaxValue)
        {
            for (int i = 0; i < powerMaxValue; i++)
            {
                ClickOnScreen((int)PlusePower.Location.X, (int)PlusePower.Location.Y);
            }
        }
        public void ClickOnPowerMinus(int powerMinValue)
        {
            for (int i = 0; i < powerMinValue; i++)
            {
                ClickOnScreen((int)PlusePower.Location.X, (int)PlusePower.Location.Y + 348);
            }
        }

        public void ClickOnPWPluse(int PWMaxValue)
        {
            for (int i = 0; i < PWMaxValue; i++)
            {
                ClickOnScreen((int)PlusePasses.Location.X, (int)PlusePasses.Location.Y);
            }
        }
        public void ClickOnPWMinus(int PWMinValue)   ////To find Minus : Add 405 to the pluse (Y) location
        {
            for (int i = 0; i < PWMinValue; i++)
            {
                ClickOnScreen((int)PlusePasses.Location.X, (int)PlusePasses.Location.Y + 405);
            }
        }

        public void ClickOnPowerMinusIntensif(int powerMinValue)   ////To find Minus : Add 405 to the pluse (Y) location
        {
            for (int i = 0; i < powerMinValue; i++)
            {
                ClickOnScreen((int)PlusePower.Location.X, (int)PlusePower.Location.Y + 405);
            }
        }

        public void ClickOnDepthPluse(int depthMaxValue)
        {
            for (int i = 0; i < depthMaxValue; i++)
            {
                ClickOnScreen((int)PlusePower.Location.X - 204, (int)PlusePower.Location.Y);
            }

        }
        public void ClickOnDepthMinus(int depthMinValue)
        {
            for (int i = 0; i < depthMinValue; i++)
            {
                ClickOnScreen((int)PlusePower.Location.X - 204, (int)PlusePower.Location.Y + 347);
            }
        }

        public string ConnectHP(string hpType, string connectorSide)
        {
            if (string.IsNullOrEmpty(hpType)) return "No suggestion for connecting an HP";
            else
            {
                switch (hpType)
                {
                    case "iFine MAX":
                        System.Windows.MessageBoxResult iFineResult = MessageBox.Show(
                            "Please connect iFine MAX HP to the " + connectorSide + " side.\nPress OK after the HP is connected!",
                            "Connect Device", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                        if (iFineResult == MessageBoxResult.OK)
                            return "iFine MAX is not connected properlly";
                        else
                            return "iFine MAX HP is connected!";

                    case "Small MAX":
                        System.Windows.MessageBoxResult SmallResult = MessageBox.Show(
                           "Please connect Small MAX HP to the " + connectorSide + " side.\nPress OK after the HP is connected!",
                           "Connect Device", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                        if (SmallResult == MessageBoxResult.OK)
                            return "Small MAX is not connected properlly";
                        else
                            return "Small MAX HP is connected!";

                    case "Mini Shaper MAX":
                        System.Windows.MessageBoxResult MiniShaperResult = MessageBox.Show(
                            "Please connect Mini Shaper MAX HP to the " + connectorSide + " side.\nPress OK after the HP is connected!",
                            "Connect Device", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                        if (MiniShaperResult == MessageBoxResult.OK)
                            return "Mini Shaper MAX is not connected properlly";
                        else
                            return "Mini Shaper MAX HP is connected!";

                    case "Shaper MAX":
                        System.Windows.MessageBoxResult ShaperResult = MessageBox.Show(
                            "Please connect Shaper MAX HP to the " + connectorSide + " side.\nPress OK after the HP is connected!",
                            "Connect Device", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                        if (ShaperResult == MessageBoxResult.OK)
                            return "Shaper MAX is not connected properlly";
                        else
                            return "Shaper MAX HP is connected!";

                    case "Contour MAX":
                        System.Windows.MessageBoxResult ContourResult = MessageBox.Show(
                           "Please connect Contour MAX HP to the " + connectorSide + " side.\nPress OK after the HP is connected!",
                           "Connect Device", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                        if (ContourResult == MessageBoxResult.OK)
                            return "Contour MAX is not connected properlly";
                        else
                            return "Contour MAX HP is connected!";

                    case "Intensif MAX":
                        System.Windows.MessageBoxResult IntensifResult = MessageBox.Show(
                           "Please connect Intensif MAX HP to the " + connectorSide + " side.\nPress OK after the HP is connected!",
                           "Connect Device", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                        if (IntensifResult == MessageBoxResult.OK)
                            return "Intensif MAX is not connected properlly";
                        else
                            return "Intensif MAX HP is connected!";

                    case "FSR MAX":
                        System.Windows.MessageBoxResult FSRresult = MessageBox.Show(
                           "Please connect FSR MAX HP to the " + connectorSide + " side.\nPress OK after the HP is connected!",
                           "Connect Device", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                        if (FSRresult == MessageBoxResult.OK)
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
                switch (hpType)
                {
                    case "iFine MAX":
                        System.Windows.MessageBoxResult iFineResult = MessageBox.Show(
                            "Please disconnect iFine MAX HP.\nPress OK after the HP is disconnected!",
                            "Disconnect Device", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                        if (iFineResult == MessageBoxResult.OK && PopUpMessage.Text.Equals("Handpiece was disconnected. Press OK to continue."))
                        {
                            dissconectHPMsg.Click();
                            return "iFine MAX HP is not disconnected properlly";
                        }
                        else
                            return "iFine MAX HP is disconnected!";

                    case "Small MAX":
                        System.Windows.MessageBoxResult SmallResult = MessageBox.Show(
                           "Please disconnect Small MAX HP.\nPress OK after the HP is disconnected!",
                           "Disconnect Device", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                        if (SmallResult == MessageBoxResult.OK && PopUpMessage.Text.Equals("Handpiece was disconnected. Press OK to continue."))
                        {
                            dissconectHPMsg.Click();
                            return "Small MAX is not disconnected properlly";
                        }
                        else
                            return "Small MAX HP is disconnected!";

                    case "Mini Shaper MAX":
                        System.Windows.MessageBoxResult MiniShaperResult = MessageBox.Show(
                            "Please disconnect Mini Shaper MAX HP.\nPress OK after the HP is disconnected!",
                            "Disconnect Device", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                        if (MiniShaperResult == MessageBoxResult.OK && PopUpMessage.Text.Equals("Handpiece was disconnected. Press OK to continue."))
                        {
                            dissconectHPMsg.Click();
                            return "Mini Shaper MAX is not disconnected properlly";
                        }
                        else
                            return "Mini Shaper MAX HP is disconnected!";

                    case "Shaper MAX":
                        System.Windows.MessageBoxResult ShaperResult = MessageBox.Show(
                            "Please disconnect Shaper MAX HP.\nPress OK after the HP is disconnected!",
                            "Disconnect Device", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                        if (ShaperResult == MessageBoxResult.OK && PopUpMessage.Text.Equals("Handpiece was disconnected. Press OK to continue."))
                        {
                            dissconectHPMsg.Click();
                            return "Shaper MAX is not disconnected properlly";
                        }
                        else
                            return "Shaper MAX HP is disconnected!";

                    case "Contour MAX":
                        System.Windows.MessageBoxResult ContourResult = MessageBox.Show(
                           "Please disconnect Contour MAX HP.\nPress OK after the HP is disconnected!",
                           "Disconnect Device", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                        if (ContourResult == MessageBoxResult.OK && PopUpMessage.Text.Equals("Handpiece was disconnected. Press OK to continue."))
                        {
                            dissconectHPMsg.Click();
                            return "Contour MAX is not disconnected properlly";
                        }
                        else
                            return "Contour MAX HP is disconnected!";

                    case "Intensif MAX":
                        System.Windows.MessageBoxResult IntensifResult = MessageBox.Show(
                           "Please disconnect Intensif MAX HP.\nPress OK after the HP is disconnected!",
                           "Disconnect Device", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                        if (IntensifResult == MessageBoxResult.OK && PopUpMessage.Text.Equals("Handpiece was disconnected. Press OK to continue."))
                        {
                            dissconectHPMsg.Click();
                            return "Intensif MAX is not disconnected properlly";
                        }
                        else
                            return "Intensif MAX HP is disconnected!";

                    case "FSR MAX":
                        System.Windows.MessageBoxResult FSRresult = MessageBox.Show(
                           "Please disconnect FSR MAX HP.\nPress OK after the HP is disconnected!",
                           "Disconnect Device", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                        if (FSRresult == MessageBoxResult.OK && PopUpMessage.Text.Equals("Handpiece was disconnected. Press OK to continue."))
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
            MessageBoxResult result = MessageBox.Show(
                "Please rotate the device.\nPress OK if motion is detected.",
                "Rotate Device", MessageBoxButton.OKCancel, MessageBoxImage.Information);

            bool isMotionDetected = result == MessageBoxResult.OK;
            return CheckRotation(isMotionDetected);
        }

        public string ManualNoMotionTest()
        {
            MessageBoxResult result = MessageBox.Show(
              "Please pause rotate the device.\nPress OK if No motion is detected.",
              "Rotate Device", MessageBoxButton.OKCancel, MessageBoxImage.Information);

            bool isMotionDetected = result == MessageBoxResult.OK;
            return CheckNoRotation(isMotionDetected);
        }

        public string ManualBadContactTest()
        {
            PressingStart();
            MessageBoxResult result = MessageBox.Show(
                "Please simulate a bad contact between the device and the load.\nClick OK if Bad contact is detected.",
                "Coupling Device", MessageBoxButton.OKCancel, MessageBoxImage.Information);

            bool isBadContactDetected = (result == MessageBoxResult.OK);
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


            //if (index >= 0)   למציאת הילד הבא לפי אינדקס
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
            Thread.Sleep(1000);
        }
        public void PressingStop()
        {
            STOP.Click();
            Thread.Sleep(1000);
        }

        [AssemblyCleanup]
        public static void TearDown()
        {
            application?.Close();
            application?.Dispose();
       }
    }
}
