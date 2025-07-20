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
    internal class ShaperMaxReadyPage : TestBase
    {
        public ShaperMaxReadyPage(string[] area, string[] defaultsPasses, string[] defaultsPower, string[] defaultsIntervalTime)
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


        public Label ShaperBtn => window.Get<Label>(SearchCriteria.ByText("ShaperMax"));
        public Label ShaperLabel => window.Get<Label>(SearchCriteria.ByText("Body ShaperMax"));
        public Label FlanksShaper => window.Get<Label>(SearchCriteria.ByText("Flanks"));
        public Label ArmsShaper => window.Get<Label>(SearchCriteria.ByText("Arms"));
        public Label AbdomenShaper => window.Get<Label>(SearchCriteria.ByText("Abdomen"));
        public Label ButtocksShaper => window.Get<Label>(SearchCriteria.ByText("Buttocks"));
        public Label ThighsShaper => window.Get<Label>(SearchCriteria.ByText("Thighs"));
        public Label KneesShaper => window.Get<Label>(SearchCriteria.ByText("Knees"));
        public Label BackShaper => window.Get<Label>(SearchCriteria.ByText("Back"));
        public Label ShaperLedON => window.Get<Label>(SearchCriteria.ByText("STOP"));
        public Label savePasses => window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(0));  //Save Passes
        public Label savePower => window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(1));  //Save power
        public Label saveIntervalTime => window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(15));  //Save interval 
        public Label SmallLedOff => window.Get<Label>(SearchCriteria.ByText("START"));
        public Label FlanksDefaultPasses => window.Get<Label>(SearchCriteria.ByText("10"));
        public Label FlanksDefaultPower => window.Get<Label>(SearchCriteria.ByText("55"));
        public Label FlanksIntervalTime => window.Get<Label>(SearchCriteria.ByText("30"));
        public Label ArmsDefaultPasses => window.Get<Label>(SearchCriteria.ByText("10"));
        public Label ArmsDefaultPower => window.Get<Label>(SearchCriteria.ByText("45"));
        public Label ArmsIntervalTime => window.Get<Label>(SearchCriteria.ByText("30"));
        public Label AbdomenDefaultPasses => window.Get<Label>(SearchCriteria.ByText("10"));
        public Label AbdomenDefaultPower => window.Get<Label>(SearchCriteria.ByText("60"));
        public Label AbdomenIntervalTime => window.Get<Label>(SearchCriteria.ByText("30"));
        public Label ButtocksDefaultPasses => window.Get<Label>(SearchCriteria.ByText("10"));
        public Label ButtocksDefaultPower => window.Get<Label>(SearchCriteria.ByText("70"));
        public Label ButtocksIntervalTime => window.Get<Label>(SearchCriteria.ByText("30"));
        public Label ThighsDefaultPasses => window.Get<Label>(SearchCriteria.ByText("10"));
        public Label ThighsDefaultPower => window.Get<Label>(SearchCriteria.ByText("70"));
        public Label ThighsIntervalTime => window.Get<Label>(SearchCriteria.ByText("30"));
        public Label KneesDefaultPasses => window.Get<Label>(SearchCriteria.ByText("10"));
        public Label KneesDefaultPower => window.Get<Label>(SearchCriteria.ByText("45"));
        public Label KneesIntervalTime => window.Get<Label>(SearchCriteria.ByText("30"));
        public Label BackDefaultPasses => window.Get<Label>(SearchCriteria.ByText("10"));
        public Label BackDefaultPower => window.Get<Label>(SearchCriteria.ByText("60"));
        public Label BackIntervalTime => window.Get<Label>(SearchCriteria.ByText("30"));


        public void checkallinfo()
        {
            for (int i = 0; i < 40; i++)
                Console.WriteLine(i + " " + window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(i)));
            //0 WPFLabel.AutomationId:, Name: 10, ControlType: text, FrameworkId: WPF
            //1 WPFLabel.AutomationId:, Name: 55, ControlType: text, FrameworkId: WPF
            //2 WPFLabel.AutomationId:, Name: PASSES, ControlType: text, FrameworkId: WPF
            //3 WPFLabel.AutomationId:, Name: POWER[W], ControlType: text, FrameworkId: WPF
            //4 WPFLabel.AutomationId:, Name: Flanks, ControlType: text, FrameworkId: WPF
            //5 WPFLabel.AutomationId:, Name: +, ControlType: text, FrameworkId: WPF
            //6 WPFLabel.AutomationId:, Name: +, ControlType: text, FrameworkId: WPF
            //7 WPFLabel.AutomationId:, Name: Arms, ControlType: text, FrameworkId: WPF
            //8 WPFLabel.AutomationId:, Name: Abdomen, ControlType: text, FrameworkId: WPF
            //9 WPFLabel.AutomationId:, Name: Buttocks, ControlType: text, FrameworkId: WPF
            //10 WPFLabel.AutomationId:, Name:–, ControlType: text, FrameworkId: WPF
            //11 WPFLabel.AutomationId:, Name:–, ControlType: text, FrameworkId: WPF
            //12 WPFLabel.AutomationId:, Name: Thighs, ControlType: text, FrameworkId: WPF
            //13 WPFLabel.AutomationId:, Name: INTERVAL TIME[sec], ControlType:text, FrameworkId: WPF
            //14 WPFLabel.AutomationId:, Name: Knees, ControlType: text, FrameworkId: WPF
            //15 WPFLabel.AutomationId:, Name: 30, ControlType: text, FrameworkId: WPF
            //16 WPFLabel.AutomationId:, Name: Back, ControlType: text, FrameworkId: WPF
            //17 WPFLabel.AutomationId:, Name: STOP, ControlType: text, FrameworkId: WPF
            //18 WPFLabel.AutomationId:, Name: Body ShaperMax, ControlType:text, FrameworkId: WPF
            //19 WPFLabel.AutomationId:, Name: Thermal Camera, ControlType:text, FrameworkId: WPF

        }

        public void ShaperMaxPage()
        {
            ShaperBtn.Click();
            Thread.Sleep(2500);
        }

        public string FlanksDefaultPassesPowerTime(/*string passes, string power, string intervalTime*/)
        {
            ClickOnScreen((int)FlanksShaper.Location.X, (int)FlanksShaper.Location.Y);
            Thread.Sleep(500);
            PressingStart();   //Start button

            var textPasses = FlanksDefaultPasses.Text;
            var textPower = FlanksDefaultPower.Text;
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
            ClickOnScreen((int)ArmsShaper.Location.X, (int)ArmsShaper.Location.Y);
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
        public string AbdomenDefaultPassesPowerTime(/*string passes, string power, string intervalTime*/)
        {
            ClickOnScreen((int)AbdomenShaper.Location.X, (int)AbdomenShaper.Location.Y);
            Thread.Sleep(500);
            PressingStart();   //Start button

            var textPasses = AbdomenDefaultPasses.Text;
            var textPower = AbdomenDefaultPower.Text;
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
        public string ButtocksDefaultPassesPowerTime(/*string passes, string power, string intervalTime*/)
        {
            ClickOnScreen((int)ButtocksShaper.Location.X, (int)ButtocksShaper.Location.Y);
            Thread.Sleep(500);
            PressingStart();   //Start button

            var textPasses = ButtocksDefaultPasses.Text;
            var textPower = ButtocksDefaultPower.Text;
            var textIntervalTime = saveIntervalTime.Text;
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
            ClickOnScreen((int)ThighsShaper.Location.X, (int)ThighsShaper.Location.Y);
            Thread.Sleep(500);
            PressingStart();   //Start button

            var textPasses = ThighsDefaultPasses.Text;
            var textPower = ThighsDefaultPower.Text;
            var textIntervalTime = saveIntervalTime.Text;
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
        public string KneesDefaultPassesPowerTime(/*string passes, string power, string intervalTime*/)
        {
            ClickOnScreen((int)KneesShaper.Location.X, (int)KneesShaper.Location.Y);
            Thread.Sleep(500);
            PressingStart();   //Start button

            var textPasses = KneesDefaultPasses.Text;
            var textPower = KneesDefaultPower.Text;
            var textIntervalTime = saveIntervalTime.Text;
            if (DefaultsPasses[5] == textPasses && DefaultsPower[5] == textPower && DefaultsIntervalTime[5] == textIntervalTime)
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
            ClickOnScreen((int)BackShaper.Location.X, (int)BackShaper.Location.Y);
            Thread.Sleep(500);
            PressingStart();   //Start button

            var textPasses = BackDefaultPasses.Text;
            var textPower = BackDefaultPower.Text;
            var textIntervalTime = saveIntervalTime.Text;
            if (DefaultsPasses[6] == textPasses && DefaultsPower[6] == textPower && DefaultsIntervalTime[6] == textIntervalTime)
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
            if (ShaperLedON.Text.Equals("STOP"))
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
            ClickOnScreen((int)FlanksShaper.Location.X, (int)FlanksShaper.Location.Y);
            Thread.Sleep(500);
            ClickOnPowerMinus(20); // Start from level power 1
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
                            Console.WriteLine("Shaper Get to if with: " + currentValue + " num");
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
                case "Flanks":
                    ClickOnScreen((int)FlanksShaper.Location.X, (int)FlanksShaper.Location.Y);
                    Thread.Sleep(500);
                    return PulseTimer();

                case "Arms":
                    ClickOnScreen((int)ArmsShaper.Location.X, (int)ArmsShaper.Location.Y);
                    Thread.Sleep(500);
                    return PulseTimer();

                case "Abdomen":
                    ClickOnScreen((int)AbdomenShaper.Location.X, (int)AbdomenShaper.Location.Y);
                    Thread.Sleep(500);
                    return PulseTimer();

                case "Buttocks":
                    ClickOnScreen((int)ButtocksShaper.Location.X, (int)ButtocksShaper.Location.Y);
                    Thread.Sleep(500);
                    return PulseTimer();

                case "Thighs":
                    ClickOnScreen((int)ThighsShaper.Location.X, (int)ThighsShaper.Location.Y);
                    Thread.Sleep(500);
                    return PulseTimer();

                case "Knees":
                    ClickOnScreen((int)KneesShaper.Location.X, (int)KneesShaper.Location.Y);
                    Thread.Sleep(500);
                    return PulseTimer();

                case "Back":
                    ClickOnScreen((int)BackShaper.Location.X, (int)BackShaper.Location.Y);
                    Thread.Sleep(500);
                    return PulseTimer();

                default:
                    return "Area not selected";
            }
        }

        //public void RetreatTest(string area)
        //{
        //    switch (area)
        //    {
        //        case "Cheeks":
        //            ClickOnScreen((int)CheeksMiniShaper.Location.X, (int)CheeksMiniShaper.Location.Y);
        //            Thread.Sleep(500);

        //            //pressRetreat();
        //            break;

        //        case "Jawline":
        //            ClickOnScreen((int)JawlineMiniShaper.Location.X, (int)JawlineMiniShaper.Location.Y);
        //            Thread.Sleep(500);
        //            pressRetreat();

        //            break;

        //        case "Submental":
        //            ClickOnScreen((int)SubmentalMiniShaper.Location.X, (int)SubmentalMiniShaper.Location.Y);
        //            Thread.Sleep(500);
        //            pressRetreat();

        //            break;

        //        default:
        //            Console.WriteLine("No");
        //            break;
        //    }
        //}

        public string CheckShaperEntered()
        {
            try
            {
                return ShaperLabel.Text;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }






    }
}
