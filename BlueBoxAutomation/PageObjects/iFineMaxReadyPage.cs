using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using static System.Net.Mime.MediaTypeNames;

namespace BlueBoxAutomation.PageObjects
{
    internal class iFineMaxReadyPage : TestBase
    {
        public iFineMaxReadyPage(string[] area, string[] defaultsPasses, string[] defaultsPower, string[] defaultsIntervalTime)
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

        public Button IfineMaxBtn => window.Get<Button>(SearchCriteria.ByText("iFineMax"));
        public Label IFineLabel => window.Get<Label>(SearchCriteria.ByText("Face iFineMax"));
        public Label PeriorbitalIfine => window.Get<Label>(SearchCriteria.ByText("Periorbital"));
        public Label Perioralfine => window.Get<Label>(SearchCriteria.ByText("Perioral"));
        public Label LedON => window.Get<Label>(SearchCriteria.ByText("STOP"));
        public Label iFinePassesMaximumValue => window.Get<Label>(SearchCriteria.ByText("15"));
        public Label iFinePassesMinimumValue => window.Get<Label>(SearchCriteria.ByText("0"));
        public Label iFinePowerMaximumValue => window.Get<Label>(SearchCriteria.ByText("6"));
        public Label iFinePowerMinimumValue => window.Get<Label>(SearchCriteria.ByText("1"));
        public Label savePasses => window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(0));  //Save Passes
        public Label savePower => window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(1));  //Save power
        public Label saveIntervalTime => window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(11));  //Save interval 
        public Label RetreatBtn => window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(15));
        public Label PeriorbitalIfinePasses => window.Get<Label>(SearchCriteria.ByText("10"));  //passes
        public Label PeriorbitalIfinePower => window.Get<Label>(SearchCriteria.ByText("3"));  //power
        public Label PerioralIfinePasses => window.Get<Label>(SearchCriteria.ByText("10"));  //passes
        public Label PerioralIfinePower => window.Get<Label>(SearchCriteria.ByText("3"));  //power
        public Label IntervalEnds => window.Get<Label>(SearchCriteria.ByText("0"));


        public void checkallinfo()
        {
            for (int i = 0; i < 40; i++)
                Console.WriteLine(i + " " + window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(i)));
            //0 WPFLabel.AutomationId:, Name: 10, ControlType: text, FrameworkId: WPF
            //1 WPFLabel.AutomationId:, Name: 3, ControlType: text, FrameworkId: WPF
            //2 WPFLabel.AutomationId:, Name: PASSES, ControlType: text, FrameworkId: WPF
            //3 WPFLabel.AutomationId:, Name: POWER[W], ControlType: text, FrameworkId: WPF
            //4 WPFLabel.AutomationId:, Name: +, ControlType: text, FrameworkId: WPF
            //5 WPFLabel.AutomationId:, Name: +, ControlType: text, FrameworkId: WPF
            //6 WPFLabel.AutomationId:, Name: Periorbital, ControlType: text, FrameworkId: WPF
            //7 WPFLabel.AutomationId:, Name: Perioral, ControlType: text, FrameworkId: WPF
            //8 WPFLabel.AutomationId:, Name:–, ControlType: text, FrameworkId: WPF
            //9 WPFLabel.AutomationId:, Name:–, ControlType: text, FrameworkId: WPF
            //10 WPFLabel.AutomationId:, Name: INTERVAL TIME[sec], ControlType:text, FrameworkId: WPF
            //11 WPFLabel.AutomationId:, Name: 30, ControlType: text, FrameworkId: WPF
            //12 WPFLabel.AutomationId:, Name: STOP, ControlType: text, FrameworkId: WPF
            //13 WPFLabel.AutomationId:, Name: Face iFineMax, ControlType:text, FrameworkId: WPF
            //14 WPFLabel.AutomationId:, Name: Thermal Camera, ControlType:text, FrameworkId: WPF

        }

        public void IFineMAX()
        {
            Thread.Sleep(1000);

            IfineMaxBtn.Click();
        }

        public string PeriorbitalDefaultPassesPowerTime(/*string passes, string power, string intervalTime*/)
        {
            Thread.Sleep(1000);

            ClickOnScreen((int)PeriorbitalIfine.Location.X, (int)PeriorbitalIfine.Location.Y);
            PressStartAndWaitReady();   //Start button

            var textPasses = PeriorbitalIfinePasses.Text;
            var textPower = PeriorbitalIfinePower.Text;
            var textIntervalTime = /*saveIntervalTime.Text*/ GetCurrentIntervalTimeValue();
            if (DefaultsPasses[0] == textPasses && DefaultsPower[0] == textPower && DefaultsIntervalTime[0] == textIntervalTime)
            {
                PressStopAndWaitStandby();  //Stop button
                return "Defaults are OK!";
            }
            else
            {
                return "Defaults are wrong!";
            }
        }
        public string PerioralDefaultPassesPowerTime(/*string passes, string power, string intervalTime*/)
        {
            Thread.Sleep(1000);

            ClickOnScreen((int)Perioralfine.Location.X, (int)Perioralfine.Location.Y);
            PressStartAndWaitReady();   //Start button

            var textPasses = PerioralIfinePasses.Text;
            var textPower = PerioralIfinePower.Text;
            var textIntervalTime = /*saveIntervalTime.Text*/ GetCurrentIntervalTimeValue();
            if (DefaultsPasses[1] == textPasses && DefaultsPower[1] == textPower && DefaultsIntervalTime[1] == textIntervalTime)
            {
                PressStopAndWaitStandby();  //Stop button
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
            if (LedON.Text.Equals("STOP"))
            {
                var LED = ConnectDeviceWindow.ShowDialogWindow("IS THE HP LED ON ?");
                if (LED == true)
                {
                    PressingStop();  //Stop button
                    return true;
                }
                else
                {
                    return false;
                }
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

            var timeout = DateTime.Now.AddSeconds(10);
            while (DateTime.Now < timeout)
            {
                try
                {
                    ClickOnScreen((int)PeriorbitalIfine.Location.X, (int)PeriorbitalIfine.Location.Y);
                    break;
                }
                catch { /*ignore*/ }
       
                    Thread.Sleep(250); //debounce every 250 ms
            }
            if (DateTime.Now == timeout)
            {
                throw new Exception("Timeout done for trying to click Periorbital area");
            }

            ClickOnPowerMinus(2); // Start from power  1W

            //Thread.Sleep(500);

            //var RF = ConnectDeviceWindow.ShowDialogWindow("Testit RF Power in 1 - 6  Watt");

            for (int expectedPower = 1; expectedPower <= 6; expectedPower++)
            {
                if (GetCurrentPowerValue() == expectedPower.ToString())
                {
                    Thread.Sleep(500);
                    PressStartAndWaitReady();  // Start button
                    //Thread.Sleep(5000);  //wait after state machine stablizing 

                    while (true)
                    {
                        var currentValue = GetCurrentIntervalTimeValue(); 

                        if (currentValue == "0")
                        {
                            Console.WriteLine("iFine Get to if with: " + currentValue + " num");
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

                    PressStopAndWaitStandby();  // Stop button
                    ClickOnPowerPluse(1); // Move to the next power level
                }
            }

            return successfulPowerLevels;
        }

        public string checkCounterDecrease(string value)
        {
            switch (value)
            {
                case "Periorbital":
                    ClickOnScreen((int)PeriorbitalIfine.Location.X, (int)PeriorbitalIfine.Location.Y);
                    Thread.Sleep(500);
                    return PulseTimer();

                case "Perioral":
                    ClickOnScreen((int)Perioralfine.Location.X, (int)Perioralfine.Location.Y);
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
                case "Periorbital":
                    ClickOnScreen((int)PeriorbitalIfine.Location.X, (int)PeriorbitalIfine.Location.Y);
                    Thread.Sleep(500);
                    RetreatBtn.Click();
                    break;

                case "Perioral":
                    ClickOnScreen((int)Perioralfine.Location.X, (int)Perioralfine.Location.Y);
                    Thread.Sleep(500);
                    RetreatBtn.Click();
                    break;

                default:
                    Console.WriteLine("No");
                    break;
            }
        }

        public string CheckiFineEntered()
        {
            try
            {
                return IFineLabel.Text;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
