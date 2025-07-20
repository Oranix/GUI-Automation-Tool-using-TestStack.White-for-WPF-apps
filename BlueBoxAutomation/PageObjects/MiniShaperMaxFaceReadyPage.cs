using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using static System.Net.Mime.MediaTypeNames;

namespace BlueBoxAutomation.PageObjects
{
    internal class MiniShaperMaxFaceReadyPage : TestBase
    {
        public MiniShaperMaxFaceReadyPage(string[] area, string[] defaultsPasses, string[] defaultsPower, string[] defaultsIntervalTime)
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

        public Button MiniShaperBtn => window.Get<Button>(SearchCriteria.ByText("MiniShaperMax"));
        public Label MiniShaperFaceLabel => window.Get<Label>(SearchCriteria.ByText("Face MiniShaperMax"));
        public Label MiniShaperLedON => window.Get<Label>(SearchCriteria.ByText("STOP"));
        public Label savePasses => window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(0));  //Save Passes
        public Label savePower => window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(1));  //Save power
        public Label saveIntervalTime => window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(12));  //Save interval 
        public Label CheeksMiniShaper => window.Get<Label>(SearchCriteria.ByText("Cheeks"));
        public Label CheeksDefaultPasses => window.Get<Label>(SearchCriteria.ByText("9"));
        public Label CheeksDefaultPower => window.Get<Label>(SearchCriteria.ByText("35"));
        public Label CheeksIntervalTime => window.Get<Label>(SearchCriteria.ByText("30"));
        public Label JawlineMiniShaper => window.Get<Label>(SearchCriteria.ByText("Jawline"));
        public Label JawlineDefaultPasses => window.Get<Label>(SearchCriteria.ByText("10"));
        public Label JawlineDefaultPower => window.Get<Label>(SearchCriteria.ByText("25"));
        public Label JawlineIntervalTime => window.Get<Label>(SearchCriteria.ByText("30"));
        public Label SubmentalMiniShaper => window.Get<Label>(SearchCriteria.ByText("Submental"));
        public Label SubmentalDefaultPasses => window.Get<Label>(SearchCriteria.ByText("10"));
        public Label SubmentalDefaultPower => window.Get<Label>(SearchCriteria.ByText("20"));
        public Label SubmentalIntervalTime => window.Get<Label>(SearchCriteria.ByText("30"));

        public void checkallinfo()
        {
            for (int i = 0; i < 40; i++)
                Console.WriteLine(i + " " + window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(i)));
            //0 WPFLabel.AutomationId:, Name: 9, ControlType: text, FrameworkId: WPF
            //1 WPFLabel.AutomationId:, Name: 35, ControlType: text, FrameworkId: WPF
            //2 WPFLabel.AutomationId:, Name: PASSES, ControlType: text, FrameworkId: WPF
            //3 WPFLabel.AutomationId:, Name: POWER[W], ControlType: text, FrameworkId: WPF
            //4 WPFLabel.AutomationId:, Name: +, ControlType: text, FrameworkId: WPF
            //5 WPFLabel.AutomationId:, Name: +, ControlType: text, FrameworkId: WPF
            //6 WPFLabel.AutomationId:, Name: Cheeks, ControlType: text, FrameworkId: WPF
            //7 WPFLabel.AutomationId:, Name: Jawline, ControlType: text, FrameworkId: WPF
            //8 WPFLabel.AutomationId:, Name: Submental, ControlType: text, FrameworkId: WPF
            //9 WPFLabel.AutomationId:, Name:–, ControlType: text, FrameworkId: WPF
            //10 WPFLabel.AutomationId:, Name:–, ControlType: text, FrameworkId: WPF
            //11 WPFLabel.AutomationId:, Name: INTERVAL TIME[sec], ControlType:text, FrameworkId: WPF
            //12 WPFLabel.AutomationId:, Name: 30, ControlType: text, FrameworkId: WPF
            //13 WPFLabel.AutomationId:, Name: STOP, ControlType: text, FrameworkId: WPF
            //14 WPFLabel.AutomationId:, Name: Face MiniShaperMax, ControlType:text, FrameworkId: WPF
            //15 WPFLabel.AutomationId:, Name: Thermal Camera, ControlType:text, FrameworkId: WPF

        }

        public void MiniShaperMaxPage()
        {
            MiniShaperBtn.Click();
            Thread.Sleep(2500);
        }

        public string CheeksDefaultPassesPowerTime(/*string passes, string power, string intervalTime*/)
        {
            ClickOnScreen((int)CheeksMiniShaper.Location.X, (int)CheeksMiniShaper.Location.Y);
            Thread.Sleep(500);
            PressingStart();   //Start button

            var textPasses = CheeksDefaultPasses.Text;
            var textPower = CheeksDefaultPower.Text;
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

        public string JawlineDefaultPassesPowerTime(/*string passes, string power, string intervalTime*/)
        {
            ClickOnScreen((int)JawlineMiniShaper.Location.X, (int)JawlineMiniShaper.Location.Y);
            Thread.Sleep(500);
            PressingStart();   //Start button

            var textPasses = JawlineDefaultPasses.Text;
            var textPower = JawlineDefaultPower.Text;
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

        public string SubmentalDefaultPassesPowerTime(/*string passes, string power, string intervalTime*/)
        {
            ClickOnScreen((int)SubmentalMiniShaper.Location.X, (int)SubmentalMiniShaper.Location.Y);
            Thread.Sleep(500);
            PressingStart();   //Start button

            var textPasses = SubmentalDefaultPasses.Text;
            var textPower = SubmentalDefaultPower.Text;
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
            ClickOnScreen((int)CheeksMiniShaper.Location.X, (int)CheeksMiniShaper.Location.Y);
            Thread.Sleep(500);
            ClickOnPowerMinus(20); // Start from power power 1
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
                            Console.WriteLine("MiniShaper Face Get to if with: " + currentValue + " num");
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
                    ClickOnScreen((int)CheeksMiniShaper.Location.X, (int)CheeksMiniShaper.Location.Y);
                    Thread.Sleep(500);
                    return PulseTimer();

                case "Jawline":
                    ClickOnScreen((int)JawlineMiniShaper.Location.X, (int)JawlineMiniShaper.Location.Y);
                    Thread.Sleep(500);
                    return PulseTimer();

                case "Submental":
                    ClickOnScreen((int)SubmentalMiniShaper.Location.X, (int)SubmentalMiniShaper.Location.Y);
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
                    ClickOnScreen((int)CheeksMiniShaper.Location.X, (int)CheeksMiniShaper.Location.Y);
                    Thread.Sleep(500);

                    //pressRetreat();
                    break;

                case "Jawline":
                    ClickOnScreen((int)JawlineMiniShaper.Location.X, (int)JawlineMiniShaper.Location.Y);
                    Thread.Sleep(500);
                    pressRetreat();

                    break;

                case "Submental":
                    ClickOnScreen((int)SubmentalMiniShaper.Location.X, (int)SubmentalMiniShaper.Location.Y);
                    Thread.Sleep(500);
                    pressRetreat();

                    break;

                default:
                    Console.WriteLine("No");
                    break;
            }
        }
        public string CheckMiniShaperFaceEntered()
        {
            try
            {
                return MiniShaperFaceLabel.Text;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}
