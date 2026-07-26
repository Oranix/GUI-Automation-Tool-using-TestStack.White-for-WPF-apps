using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using static System.Net.Mime.MediaTypeNames;

namespace BlueBoxAutomation.PageObjects
{
    internal class ContourMaxReadyPage : TestBase
    {
        public ContourMaxReadyPage(string[] area, string[] defaultsPasses, string[] defaultsPower, string[] defaultsIntervalTime)
        {
            Area = area;
            DefaultsPasses = defaultsPasses;
            DefaultsPower = defaultsPower;
            DefaultsIntervalTime = defaultsIntervalTime;
        }

        public Button ContourBtn => window.Get<Button>(SearchCriteria.ByText("ContourMax"));
        public Label ContourLabel => window.Get<Label>(SearchCriteria.ByText("Body ContourMax"));
        public Label ContourLedON => window.Get<Label>(SearchCriteria.ByText("STOP"));
        public Label savePasses => window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(0));  //Save Passes
        public Label savePower => window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(1));  //Save power
        public Label saveIntervalTime => window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(14));  //Save interval 
        public Label FlanksContour => window.Get<Label>(SearchCriteria.ByText("Flanks"));
        public Label FlanksDefaultPasses => window.Get<Label>(SearchCriteria.ByText("10"));
        public Label FlanksDefaultPower => window.Get<Label>(SearchCriteria.ByText("65"));
        public Label FlanksIntervalTime => window.Get<Label>(SearchCriteria.ByText("30"));
        public Label AbdomenContour => window.Get<Label>(SearchCriteria.ByText("Abdomen"));
        public Label AbdomenDefaultPasses => window.Get<Label>(SearchCriteria.ByText("10"));
        public Label AbdomenDefaultPower => window.Get<Label>(SearchCriteria.ByText("70"));
        public Label AbdomenIntervalTime => window.Get<Label>(SearchCriteria.ByText("30"));
        public Label ButtocksContour => window.Get<Label>(SearchCriteria.ByText("Buttocks"));
        public Label ButtocksDefaultPasses => window.Get<Label>(SearchCriteria.ByText("10"));
        public Label ButtocksDefaultPower => window.Get<Label>(SearchCriteria.ByText("70"));
        public Label ButtocksIntervalTime => window.Get<Label>(SearchCriteria.ByText("30"));
        public Label ThighsContour => window.Get<Label>(SearchCriteria.ByText("Thighs"));
        public Label ThighsDefaultPasses => window.Get<Label>(SearchCriteria.ByText("10"));
        public Label ThighsDefaultPower => window.Get<Label>(SearchCriteria.ByText("70"));
        public Label ThighsIntervalTime => window.Get<Label>(SearchCriteria.ByText("30"));
        public Label BackContour => window.Get<Label>(SearchCriteria.ByText("Back"));
        public Label BackDefaultPasses => window.Get<Label>(SearchCriteria.ByText("10"));
        public Label BackDefaultPower => window.Get<Label>(SearchCriteria.ByText("60"));
        public Label BackIntervalTime => window.Get<Label>(SearchCriteria.ByText("30"));

        public string[] Area { get; set; }
        public string[] DefaultsPasses { get; set; }
        public string[] DefaultsPower { get; set; }
        public string[] DefaultsIntervalTime { get; set; }


        public void checkallinfo()
        {
            for (int i = 0; i < 40; i++)
                Console.WriteLine(i + " " + window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(i)));
            //0 WPFLabel.AutomationId:, Name: 10, ControlType: text, FrameworkId: WPF
            //1 WPFLabel.AutomationId:, Name: 65, ControlType: text, FrameworkId: WPF
            //2 WPFLabel.AutomationId:, Name: PASSES, ControlType: text, FrameworkId: WPF
            //3 WPFLabel.AutomationId:, Name: POWER[W], ControlType: text, FrameworkId: WPF
            //4 WPFLabel.AutomationId:, Name: Flanks, ControlType: text, FrameworkId: WPF
            //5 WPFLabel.AutomationId:, Name: +, ControlType: text, FrameworkId: WPF
            //6 WPFLabel.AutomationId:, Name: +, ControlType: text, FrameworkId: WPF
            //7 WPFLabel.AutomationId:, Name: Abdomen, ControlType: text, FrameworkId: WPF
            //8 WPFLabel.AutomationId:, Name: Back, ControlType: text, FrameworkId: WPF
            //9 WPFLabel.AutomationId:, Name: Buttocks, ControlType: text, FrameworkId: WPF
            //10 WPFLabel.AutomationId:, Name:–, ControlType: text, FrameworkId: WPF
            //11 WPFLabel.AutomationId:, Name:–, ControlType: text, FrameworkId: WPF
            //12 WPFLabel.AutomationId:, Name: Thighs, ControlType: text, FrameworkId: WPF
            //13 WPFLabel.AutomationId:, Name: INTERVAL TIME[sec], ControlType:text, FrameworkId: WPF
            //14 WPFLabel.AutomationId:, Name: 30, ControlType: text, FrameworkId: WPF
            //15 WPFLabel.AutomationId:, Name: STOP, ControlType: text, FrameworkId: WPF
            //16 WPFLabel.AutomationId:, Name: Body ContourMax, ControlType:text, FrameworkId: WPF
            //17 WPFLabel.AutomationId:, Name: Thermal Camera, ControlType:text, FrameworkId: WPF

        }

        public void ContourMaxPage()
        {
            ContourBtn.Click();
            Thread.Sleep(2500);
        }

        public string FlanksDefaultPassesPowerTime(/*string passes, string power, string intervalTime*/)
        {
            ClickOnScreen((int)FlanksContour.Location.X, (int)FlanksContour.Location.Y);
            Thread.Sleep(500);
            PressingStart();   //Start button

            var textPasses = FlanksDefaultPasses.Text;
            var textPower = FlanksDefaultPower.Text;
            var textIntervalTime = FlanksIntervalTime.Text;
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

        public string AbdomenDefaultPassesPowerTime(/*string passes, string power, string intervalTime*/)
        {
            ClickOnScreen((int)AbdomenContour.Location.X, (int)AbdomenContour.Location.Y);
            Thread.Sleep(500);
            PressingStart();   //Start button

            var textPasses = AbdomenDefaultPasses.Text;
            var textPower = AbdomenDefaultPower.Text;
            var textIntervalTime = AbdomenIntervalTime.Text;
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

        public string BackDefaultPassesPowerTime(/*string passes, string power, string intervalTime*/)
        {
            ClickOnScreen((int)BackContour.Location.X, (int)BackContour.Location.Y);
            Thread.Sleep(1500);

            var textPasses = BackDefaultPasses.Text;
            var textPower = BackDefaultPower.Text;
            var textIntervalTime = BackIntervalTime.Text;
            if (DefaultsPasses[2] == textPasses && DefaultsPower[2] == textPower && DefaultsIntervalTime[2] == textIntervalTime)
            {
                return "Defaults are OK!";
            }
            else
            {
                return "Defaults are wrong!";
            }
        }

        public string ButtocksDefaultPassesPowerTime(/*string passes, string power, string intervalTime*/)
        {
            ClickOnScreen((int)ButtocksContour.Location.X, (int)ButtocksContour.Location.Y);
            Thread.Sleep(500);
            PressingStart();   //Start button

            var textPasses = ButtocksDefaultPasses.Text;
            var textPower = ButtocksDefaultPower.Text;
            var textIntervalTime = ButtocksIntervalTime.Text;
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

        public string ThighsDefaultPassesPowerTime(/*string passes, string power, string intervalTime*/)
        {
            ClickOnScreen((int)ThighsContour.Location.X, (int)ThighsContour.Location.Y);
            Thread.Sleep(500);
            PressingStart();   //Start button

            var textPasses = ThighsDefaultPasses.Text;
            var textPower = ThighsDefaultPower.Text;
            var textIntervalTime = ThighsIntervalTime.Text;
            if (DefaultsPasses[4] == textPasses && DefaultsPower[4] == textPower && DefaultsIntervalTime[4] == textIntervalTime)
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
            if (ContourLedON.Text.Equals("STOP"))
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
            ClickOnScreen((int)FlanksContour.Location.X, (int)FlanksContour.Location.Y);
            Thread.Sleep(500);
            ClickOnPowerMinus(20); // Start from power power 1
            Thread.Sleep(1000);
            for (int expectedPower = 45; expectedPower <= 100; expectedPower += 5)
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
                            Console.WriteLine("Contour Get to if with: " + currentValue + " num");
                            successfulPowerLevels++;
                            break;
                            
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
                case "Flanks":
                    ClickOnScreen((int)FlanksContour.Location.X, (int)FlanksContour.Location.Y);
                    Thread.Sleep(500);
                    return PulseTimer();

                case "Abdomen":
                    ClickOnScreen((int)AbdomenContour.Location.X, (int)AbdomenContour.Location.Y);
                    Thread.Sleep(500);
                    return PulseTimer();

                case "Buttocks":
                    ClickOnScreen((int)ButtocksContour.Location.X, (int)ButtocksContour.Location.Y);
                    Thread.Sleep(500);
                    return PulseTimer();

                case "Thighs":
                    ClickOnScreen((int)ThighsContour.Location.X, (int)ThighsContour.Location.Y);
                    Thread.Sleep(500);
                    return PulseTimer();

                case "Back":
                    ClickOnScreen((int)BackContour.Location.X, (int)BackContour.Location.Y);
                    Thread.Sleep(500);
                    return PulseTimer();

                default:
                    return "Area not selected";
            }
        }






        public string CheckContourEntered()
        {
            try
            {
                return ContourLabel.Text;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}
