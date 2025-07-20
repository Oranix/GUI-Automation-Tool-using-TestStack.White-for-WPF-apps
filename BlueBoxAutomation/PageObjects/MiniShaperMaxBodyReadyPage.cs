using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.Utility;
using static System.Net.Mime.MediaTypeNames;

namespace BlueBoxAutomation.PageObjects
{
    internal class MiniShaperMaxBodyReadyPage : TestBase
    {
        public MiniShaperMaxBodyReadyPage(string[] area, string[] defaultsPasses, string[] defaultsPower, string[] defaultsIntervalTime)
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

        public Label MiniShaperBtn => window.Get<Label>(SearchCriteria.ByText("MiniShaperMax"));
        public Label MiniShaperBodyLabel => window.Get<Label>(SearchCriteria.ByText("Body MiniShaperMax"));
        public Label MiniShaperLedON => window.Get<Label>(SearchCriteria.ByText("STOP"));
        public Label savePasses => window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(0));  //Save Passes
        public Label savePower => window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(1));  //Save power
        public Label saveIntervalTime => window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(12));  //Save interval 
        public Label DecolletageMiniShaper => window.Get<Label>(SearchCriteria.ByText("Decolletage"));
        public Label DecolletageDefaultPasses => window.Get<Label>(SearchCriteria.ByText("10"));
        public Label DecolletageDefaultPower => window.Get<Label>(SearchCriteria.ByText("40"));
        public Label DecolletageIntervalTime => window.Get<Label>(SearchCriteria.ByText("30"));
        public Label ArmsMiniShaper => window.Get<Label>(SearchCriteria.ByText("Arms"));
        public Label ArmsDefaultPasses => window.Get<Label>(SearchCriteria.ByText("13"));
        public Label ArmsDefaultPower => window.Get<Label>(SearchCriteria.ByText("30"));
        public Label ArmsIntervalTime => window.Get<Label>(SearchCriteria.ByText("30"));
        public Label KneesMiniShaper => window.Get<Label>(SearchCriteria.ByText("Knees"));
        public Label KneesDefaultPasses => window.Get<Label>(SearchCriteria.ByText("13"));
        public Label KneesDefaultPower => window.Get<Label>(SearchCriteria.ByText("35"));
        public Label KneesIntervalTime => window.Get<Label>(SearchCriteria.ByText("30"));
        public Label MiniShaperLedOff => window.Get<Label>(SearchCriteria.ByText("START"));

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
            //6 WPFLabel.AutomationId:, Name: Decolletage, ControlType: text, FrameworkId: WPF
            //7 WPFLabel.AutomationId:, Name: Arms, ControlType: text, FrameworkId: WPF
            //8 WPFLabel.AutomationId:, Name: Knees, ControlType: text, FrameworkId: WPF
            //9 WPFLabel.AutomationId:, Name:–, ControlType: text, FrameworkId: WPF
            //10 WPFLabel.AutomationId:, Name:–, ControlType: text, FrameworkId: WPF
            //11 WPFLabel.AutomationId:, Name: INTERVAL TIME[sec], ControlType:text, FrameworkId: WPF
            //12 WPFLabel.AutomationId:, Name: 30, ControlType: text, FrameworkId: WPF
            //13 WPFLabel.AutomationId:, Name: STOP, ControlType: text, FrameworkId: WPF
            //14 WPFLabel.AutomationId:, Name: Body MiniShaperMax, ControlType:text, FrameworkId: WPF
            //15 WPFLabel.AutomationId:, Name: Thermal Camera, ControlType:text, FrameworkId: WPF
        }

        public void MiniShaperMaxPage()
        {
            MiniShaperBtn.Click();
            Thread.Sleep(2500);
        }

        public string DecolletageDefaultPassesPowerTime(/*string passes, string power, string intervalTime*/)
        {
            ClickOnScreen((int)DecolletageMiniShaper.Location.X, (int)DecolletageMiniShaper.Location.Y);
            Thread.Sleep(500);
            PressingStart();   //Start button

            var textPasses = DecolletageDefaultPasses.Text;
            var textPower = DecolletageDefaultPower.Text;
            var textIntervalTime = saveIntervalTime.Text;
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

        public string ArmsDefaultPassesPowerTime(/*string passes, string power, string intervalTime*/)
        {
            ClickOnScreen((int)ArmsMiniShaper.Location.X, (int)ArmsMiniShaper.Location.Y);
            Thread.Sleep(500);
            PressingStart();   //Start button

            var textPasses = ArmsDefaultPasses.Text;
            var textPower = ArmsDefaultPower.Text;
            var textIntervalTime = saveIntervalTime.Text;
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

        public string KneesDefaultPassesPowerTime(/*string passes, string power, string intervalTime*/)
        {
            ClickOnScreen((int)KneesMiniShaper.Location.X, (int)KneesMiniShaper.Location.Y);
            Thread.Sleep(500);
            PressingStart();   //Start button

            var textPasses = KneesDefaultPasses.Text;
            var textPower = KneesDefaultPower.Text;
            var textIntervalTime = saveIntervalTime.Text;
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

        public bool LedONCheck()
        {
            Thread.Sleep(500);
            PressingStart();   //Start button
            if (MiniShaperLedON.Text.Equals("STOP"))
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
            ClickOnScreen((int)DecolletageMiniShaper.Location.X, (int)DecolletageMiniShaper.Location.Y);
            Thread.Sleep(500);
            ClickOnPowerMinus(20); // Start from power power 20
            Thread.Sleep(1000);
            for (int expectedPower = 20; expectedPower <= 70; expectedPower += 5)
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
                            Console.WriteLine("Get to if with: " + currentValue + " num");
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
                case "Decolletage":
                    ClickOnScreen((int)DecolletageMiniShaper.Location.X, (int)DecolletageMiniShaper.Location.Y);
                    Thread.Sleep(500);
                    return PulseTimer();

                case "Arms":
                    ClickOnScreen((int)ArmsMiniShaper.Location.X, (int)ArmsMiniShaper.Location.Y);
                    Thread.Sleep(500);
                    return PulseTimer();

                case "Knees":
                    ClickOnScreen((int)KneesMiniShaper.Location.X, (int)KneesMiniShaper.Location.Y);
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
                case "Decolletage":
                    ClickOnScreen((int)DecolletageMiniShaper.Location.X, (int)DecolletageMiniShaper.Location.Y);
                    Thread.Sleep(500);

                    //pressRetreat();
                    break;

                case "Arms":
                    ClickOnScreen((int)ArmsMiniShaper.Location.X, (int)ArmsMiniShaper.Location.Y);
                    Thread.Sleep(500);
                    pressRetreat();

                    break;

                case "Knees":
                    ClickOnScreen((int)KneesMiniShaper.Location.X, (int)KneesMiniShaper.Location.Y);
                    Thread.Sleep(500);
                    pressRetreat();

                    break;

                default:
                    Console.WriteLine("No");
                    break;
            }
        }
        public string CheckMiniShaperBodyEntered()
        {
            try
            {
                return MiniShaperBodyLabel.Text;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

    }
}
