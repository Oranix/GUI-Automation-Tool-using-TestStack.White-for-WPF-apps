using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;

namespace BlueBoxAutomation.PageObjects
{
    internal class SmallMaxReadyPage : TestBase
    {
        public SmallMaxReadyPage(string[] area, string[] defaultsPasses, string[] defaultsPower, string[] defaultsIntervalTime)
        {
            Area = area;
            DefaultsPasses = defaultsPasses;
            DefaultsPower = defaultsPower;
            DefaultsIntervalTime = defaultsIntervalTime;
        }

        public string[] Area { get; set; }
        public string[] DefaultsPasses { get; set; }
        public string[] DefaultsPower { get; set; }
        public string[] DefaultsIntervalTime { get; set; }

        public Button SmallMaxBtn => window.Get<Button>(SearchCriteria.ByText("SmallMax"));
        public Label SmallLabel => window.Get<Label>(SearchCriteria.ByText("Face SmallMax"));
        public Label SmallLedON => window.Get<Label>(SearchCriteria.ByText("STOP"));
        public Label savePasses => window.Get<Label>(SearchCriteria.ByAutomationId("TextBlock").AndIndex(0));  //Save Passes
        public Label savePower => window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(1));  //Save power
        public Label saveIntervalTime => window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(13));  //Save interval time
        public Label retreat => window.Get<Label>(SearchCriteria.ByClassName("Image"));  //Retreat 
        public Label SmallCheeks => window.Get<Label>(SearchCriteria.ByText("Cheeks"));
        public Label CheeksDefaultPasses => window.Get<Label>(SearchCriteria.ByText("10"));
        public Label CheeksDefaultPower => window.Get<Label>(SearchCriteria.ByText("40"));
        public Label CheeksIntervalTime => window.Get<Label>(SearchCriteria.ByText("30"));
        public Label SmallNeck => window.Get<Label>(SearchCriteria.ByText("Neck"));
        public Label NeckDefaultPasses => window.Get<Label>(SearchCriteria.ByText("10"));
        public Label NeckDefaultPower => window.Get<Label>(SearchCriteria.ByText("35"));
        public Label NeckIntervalTime => window.Get<Label>(SearchCriteria.ByText("30"));
        public Label SmallSubmental => window.Get<Label>(SearchCriteria.ByText("Submental"));
        public Label SubmentalDefaultPasses => window.Get<Label>(SearchCriteria.ByText("10"));
        public Label SubmentalDefaultPower => window.Get<Label>(SearchCriteria.ByText("40"));
        public Label SubmentalIntervalTime => window.Get<Label>(SearchCriteria.ByText("30"));
        public Label SmallDecolletage => window.Get<Label>(SearchCriteria.ByText("Decolletage"));
        public Label DecolltageDefaultPasses => window.Get<Label>(SearchCriteria.ByText("10"));
        public Label DecolltageDefaultPower => window.Get<Label>(SearchCriteria.ByText("40"));
        public Label DecolltageIntervalTime => window.Get<Label>(SearchCriteria.ByText("30"));

        public void checkallinfo()
        {
            for (int i = 0; i < 40; i++)
                Console.WriteLine(i + " " + window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(i)));
            //0 WPFLabel.AutomationId:, Name: 10, ControlType: text, FrameworkId: WPF
            //1 WPFLabel.AutomationId:, Name: 40, ControlType: text, FrameworkId: WPF
            //2 WPFLabel.AutomationId:, Name: PASSES, ControlType: text, FrameworkId: WPF
            //3 WPFLabel.AutomationId:, Name: POWER[W], ControlType: text, FrameworkId: WPF
            //4 WPFLabel.AutomationId:, Name: +, ControlType: text, FrameworkId: WPF
            //5 WPFLabel.AutomationId:, Name: +, ControlType: text, FrameworkId: WPF
            //6 WPFLabel.AutomationId:, Name: Cheeks, ControlType: text, FrameworkId: WPF
            //7 WPFLabel.AutomationId:, Name: Neck, ControlType: text, FrameworkId: WPF
            //8 WPFLabel.AutomationId:, Name: Submental, ControlType: text, FrameworkId: WPF
            //9 WPFLabel.AutomationId:, Name:–, ControlType: text, FrameworkId: WPF
            //10 WPFLabel.AutomationId:, Name:–, ControlType: text, FrameworkId: WPF
            //11 WPFLabel.AutomationId:, Name: Decolletage, ControlType: text, FrameworkId: WPF
            //12 WPFLabel.AutomationId:, Name: INTERVAL TIME[sec], ControlType:text, FrameworkId: WPF
            //13 WPFLabel.AutomationId:, Name: 30, ControlType: text, FrameworkId: WPF
            //14 WPFLabel.AutomationId:, Name: STOP, ControlType: text, FrameworkId: WPF
            //15 WPFLabel.AutomationId:, Name: Face SmallMax, ControlType:text, FrameworkId: WPF
            //16 WPFLabel.AutomationId:, Name: Thermal Camera, ControlType:text, FrameworkId: WPF

        }

        public void SmallMAX()
        {
            SmallMaxBtn.Click();
            Thread.Sleep(2500);
        }

        public string CheeksDefaultPassesPowerTime(/*string passes, string power, string intervalTime*/)
        {
            ClickOnScreen((int)SmallCheeks.Location.X, (int)SmallCheeks.Location.Y);
            Thread.Sleep(500);
            PressingStart();   //Start button

            var textPasses = CheeksDefaultPasses.Text;
            var textPower = CheeksDefaultPower.Text;
            var textIntervalTime = CheeksIntervalTime.Text;
            if (DefaultsPasses[0] == textPasses && DefaultsPower[0] == textPower && DefaultsIntervalTime[0] == textIntervalTime)
            {
                PressingStop();  //Stop button
                return "Defaults are OK!";
            }
            else
            {
                return "Defaults are wrong!";
            }
        }

        public string NeckDefaultPassesPowerTime(/*string passes, string power, string intervalTime*/)
        {
            ClickOnScreen((int)SmallNeck.Location.X, (int)SmallNeck.Location.Y);
            Thread.Sleep(500);
            PressingStart();   //Start button

            var textPasses = NeckDefaultPasses.Text;
            var textPower = NeckDefaultPower.Text;
            var textIntervalTime = NeckIntervalTime.Text;
            if (DefaultsPasses[1] == textPasses && DefaultsPower[1] == textPower && DefaultsIntervalTime[1] == textIntervalTime)
            {
                PressingStop();  //Stop button
                return "Defaults are OK!";
            }
            else
            {
                return "Defaults are wrong!";
            }
        }

        public string SubmentalDefaultPassesPowerTime(/*string passes, string power, string intervalTime*/)
        {
            ClickOnScreen((int)SmallSubmental.Location.X, (int)SmallSubmental.Location.Y);
            Thread.Sleep(500);
            PressingStart();   //Start button

            var textPasses = SubmentalDefaultPasses.Text;
            var textPower = SubmentalDefaultPower.Text;
            var textIntervalTime = SubmentalIntervalTime.Text;
            if (DefaultsPasses[2] == textPasses && DefaultsPower[2] == textPower && DefaultsIntervalTime[2] == textIntervalTime)
            {
                PressingStop();  //Stop button
                return "Defaults are OK!";
            }
            else
            {
                return "Defaults are wrong!";
            }
        }

        public string DecolletageDefaultPassesPowerTime(/*string passes, string power, string intervalTime*/)
        {
            ClickOnScreen((int)SmallDecolletage.Location.X, (int)SmallDecolletage.Location.Y);
            Thread.Sleep(500);
            PressingStart();   //Start button

            var textPasses = DecolltageDefaultPasses.Text;
            var textPower = DecolltageDefaultPower.Text;
            var textIntervalTime = DecolltageIntervalTime.Text;
            if (DefaultsPasses[3] == textPasses && DefaultsPower[3] == textPower && DefaultsIntervalTime[3] == textIntervalTime)
            {
                PressingStop();  //Stop button
                return "Defaults are OK!";
            }
            else
            {
                return "Defaults are wrong!";
            }
        }

        public bool LedONCheck()
        {
            Thread.Sleep(500);
            PressingStart();   //Start button
            if (SmallLedON.Text.Equals("STOP"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int OutputPowerMeasuring()
        {
            int successfulPowerLevels = 0;
            //CSVOpenCheck();   //Open CSV file for measuring the outputpower from the Scope
            ClickOnScreen((int)SmallCheeks.Location.X, (int)SmallCheeks.Location.Y);
            Thread.Sleep(500);
            ClickOnPowerMinus(20); // Start from power power 1
            Thread.Sleep(1000);
            for (int expectedPower = 20; expectedPower <= 60; expectedPower += 5)
            {
                if (GetCurrentPowerValue() == expectedPower.ToString())
                {
                    PressingStart();  // Start button
                    Thread.Sleep(500);

                    while (true)
                    {
                        var currentValue = GetCurrentIntervalTimeValue();

                        if (currentValue == "0")
                        {
                            Console.WriteLine("Small Get to if with: " + currentValue + " num");
                            successfulPowerLevels++;
                            break;
                            //}
                        }
                        else /*(AutomationException ex)*/
                        {
                            //Console.WriteLine("Caught: " + ex.GetType().Name); //Get exception name
                            Console.WriteLine("else: " + currentValue + " num");
                        }
                    }

                    PressingStop();  // Stop button
                    Thread.Sleep(1000);
                    ClickOnPowerPluse(5); // Move to the next power level
                }
                else
                {
                    Console.WriteLine("GetCurrentPowerValue() != expectedPower.ToString(), fail");
                }
            }

            return successfulPowerLevels;
        }
        public string checkCounterDecrease(string value)
        {

            switch (value)
            {
                case "Cheeks":
                    ClickOnScreen((int)SmallCheeks.Location.X, (int)SmallCheeks.Location.Y);
                    Thread.Sleep(500);
                    return PulseTimer();

                case "Neck":
                    ClickOnScreen((int)SmallNeck.Location.X, (int)SmallNeck.Location.Y);
                    Thread.Sleep(500);
                    return PulseTimer();

                case "Submental":
                    ClickOnScreen((int)SmallSubmental.Location.X, (int)SmallSubmental.Location.Y);
                    Thread.Sleep(500);
                    return PulseTimer();

                case "Decolletage":
                    ClickOnScreen((int)SmallDecolletage.Location.X, (int)SmallDecolletage.Location.Y);
                    Thread.Sleep(500);
                    return PulseTimer();

                default:
                    return "Area not selected";
            }
        }
        public void RetreatTest(string area)
        {
            switch (area)
            {
                case "Cheeks":
                    ClickOnScreen((int)SmallCheeks.Location.X, (int)SmallCheeks.Location.Y);
                    Thread.Sleep(500);
                    retreat.Click();
                    Console.WriteLine(retreat.Text);
                    //pressRetreat();
                    break;

                case "Neck":
                    ClickOnScreen((int)SmallNeck.Location.X, (int)SmallNeck.Location.Y);
                    Thread.Sleep(500);
                    pressRetreat();

                    break;

                case "Submental":
                    ClickOnScreen((int)SmallSubmental.Location.X, (int)SmallSubmental.Location.Y);
                    Thread.Sleep(500);
                    pressRetreat();

                    break;

                case "Decolletage":
                    ClickOnScreen((int)SmallDecolletage.Location.X, (int)SmallDecolletage.Location.Y);
                    Thread.Sleep(500);
                    pressRetreat();

                    break;

                default:
                    Console.WriteLine("No");
                    break;
            }
        }
        public string CheckSmallEntered()
        {
            try
            {
                return SmallLabel.Text;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}
