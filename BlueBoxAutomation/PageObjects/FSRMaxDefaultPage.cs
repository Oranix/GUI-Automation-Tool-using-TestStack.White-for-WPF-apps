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
    internal class FSRMaxDefaultPage : TestBase
    {
        public FSRMaxDefaultPage(string[] area, string[] defaultPW, string[] defaultPower)
        {
            Area = area;
            DefaultsPW = defaultPW;
            DefaultsPower = defaultPower;
        }

        public string[] Area { get; set; }
        public string[] DefaultsPW { get; set; }
        public string[] DefaultsPower { get; set; }

        public Label FSRMaxBtn => window.Get<Label>(SearchCriteria.ByText("FSRMax"));
        public Label FSRLabel => window.Get<Label>(SearchCriteria.ByText("Face FSRMax"));
        public Label ForeheadFSR => window.Get<Label>(SearchCriteria.ByText("Forehead"));
        public Label PeriorbitalFSR => window.Get<Label>(SearchCriteria.ByText("Periorbital"));
        public Label CheeksFSR => window.Get<Label>(SearchCriteria.ByText("Cheeks"));
        public Label NeckFSR => window.Get<Label>(SearchCriteria.ByText("Neck"));
        public Label savePW => window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(0));  //Save PW value
        public Label savePower => window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(1));  //Save Power value
        public Label LedOff => window.Get<Label>(SearchCriteria.ByText("START"));
        public Label FSRPWMaximumValue => window.Get<Label>(SearchCriteria.ByText("60"));
        public Label FSRPWMinimumValue => window.Get<Label>(SearchCriteria.ByText("10"));
        public Label FSRPowerMaximumValue => window.Get<Label>(SearchCriteria.ByText("6"));
        public Label FSRPowerMinimumValue => window.Get<Label>(SearchCriteria.ByText("1"));
        public Label pulseCounter => window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(15));  //Save pulse counter after pressing start
        public Label ForeheadDefaultPW => window.Get<Label>(SearchCriteria.ByText("20"));
        public Label ForeheadDefaultPower => window.Get<Label>(SearchCriteria.ByText("3"));
        public Label PeriorbitalDefaultPW => window.Get<Label>(SearchCriteria.ByText("20"));
        public Label PeriorbitalDefaultPower => window.Get<Label>(SearchCriteria.ByText("3"));
        public Label CheeksDefaultPW => window.Get<Label>(SearchCriteria.ByText("30"));
        public Label CheeksDefaultPower => window.Get<Label>(SearchCriteria.ByText("3"));
        public Label NeckDefaultPW => window.Get<Label>(SearchCriteria.ByText("30"));
        public Label NeckDefaultPower => window.Get<Label>(SearchCriteria.ByText("3"));

        public void checkallinfo()
        {
            for (int i = 0; i < 40; i++)
                Console.WriteLine(i + " " + window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(i)));
            //0 WPFLabel.AutomationId:, Name: 20, ControlType: text, FrameworkId: WPF
            //1 WPFLabel.AutomationId:, Name: 3, ControlType: text, FrameworkId: WPF
            //2 WPFLabel.AutomationId:, Name: P.WIDTH[ms], ControlType: text, FrameworkId: WPF
            //3 WPFLabel.AutomationId:, Name: POWER[W], ControlType: text, FrameworkId: WPF
            //4 WPFLabel.AutomationId:, Name: Forehead, ControlType: text, FrameworkId: WPF
            //5 WPFLabel.AutomationId:, Name: +, ControlType: text, FrameworkId: WPF
            //6 WPFLabel.AutomationId:, Name: +, ControlType: text, FrameworkId: WPF
            //7 WPFLabel.AutomationId:, Name: Periorbital, ControlType: text, FrameworkId: WPF
            //8 WPFLabel.AutomationId:, Name: Cheeks, ControlType: text, FrameworkId: WPF
            //9 WPFLabel.AutomationId:, Name: Neck, ControlType: text, FrameworkId: WPF
            //10 WPFLabel.AutomationId:, Name:–, ControlType: text, FrameworkId: WPF
            //11 WPFLabel.AutomationId:, Name:–, ControlType: text, FrameworkId: WPF
            //12 WPFLabel.AutomationId:, Name: PULSES, ControlType: text, FrameworkId: WPF
            //13 WPFLabel.AutomationId:, Name: START, ControlType: text, FrameworkId: WPF
            //14 WPFLabel.AutomationId:, Name: Face FSRMax, ControlType:text, FrameworkId: WPF


        }

        public void FSRMAXPage()
        {
            FSRMaxBtn.Click();
            Thread.Sleep(2500);
        }

        public string ForeheadDefaultPWPower()
        {
            ClickOnScreen((int)ForeheadFSR.Location.X, (int)ForeheadFSR.Location.Y);
            Thread.Sleep(1500);

            var textPW = ForeheadDefaultPW.Text;
            var textPower = ForeheadDefaultPower.Text;
            if (DefaultsPW[0] == textPW && DefaultsPower[0] == textPower) { return "Forehead PW and Power defaults are OK!"; }
            else { return "Forehead defaults are wrong!"; }
        }
        public string PeriorbitalDefaultPWPower()
        {
            ClickOnScreen((int)PeriorbitalFSR.Location.X, (int)PeriorbitalFSR.Location.Y);
            Thread.Sleep(1500);

            var textPW = PeriorbitalDefaultPW.Text;
            var textPower = PeriorbitalDefaultPower.Text;
            if (DefaultsPW[1] == textPW && DefaultsPower[1] == textPower) { return "Periorbital PW and Power defaults are OK!"; }
            else { return "Periorbital defaults are wrong!"; }
        }
        public string CheeksDefaultPWPower()
        {
            ClickOnScreen((int)CheeksFSR.Location.X, (int)CheeksFSR.Location.Y);
            Thread.Sleep(1500);

            var textPW = CheeksDefaultPW.Text;
            var textPower = CheeksDefaultPower.Text;
            if (DefaultsPW[2] == textPW && DefaultsPower[2] == textPower) { return "Cheeks PW and Power defaults are OK!"; }
            else { return "Cheeks defaults are wrong!"; }
        }
        public string NeckDefaultPWPower()
        {
            ClickOnScreen((int)NeckFSR.Location.X, (int)NeckFSR.Location.Y);
            Thread.Sleep(1500);

            var textPW = NeckDefaultPW.Text;
            var textPower = NeckDefaultPower.Text;
            if (DefaultsPW[3] == textPW && DefaultsPower[3] == textPower) { return "Neck PW and Power defaults are OK!"; }
            else { return "Neck defaults are wrong!"; }
        }

        public bool LedOffCheck()
        {
            if (LedOff.Text.Equals("START"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string PWControledByUser_Pluse(string area)
        {
            switch (area)
            {
                case "Forehead":
                    ClickOnScreen((int)ForeheadFSR.Location.X, (int)ForeheadFSR.Location.Y);
                    Thread.Sleep(500);
                    ClickOnPWPluseIntensif(5);
                    break;
                case "Periorbital":
                    ClickOnScreen((int)PeriorbitalFSR.Location.X, (int)PeriorbitalFSR.Location.Y);
                    Thread.Sleep(500);
                    ClickOnPWPluseIntensif(5);
                    break;
                case "Cheeks":
                    ClickOnScreen((int)CheeksFSR.Location.X, (int)CheeksFSR.Location.Y);
                    Thread.Sleep(500);
                    ClickOnPWPluseIntensif(5);
                    break;
                case "Neck":
                    ClickOnScreen((int)NeckFSR.Location.X, (int)NeckFSR.Location.Y);
                    Thread.Sleep(500);
                    ClickOnPWPluseIntensif(5);
                    break;

            }
            if (FSRPWMaximumValue.Text.Equals("60"))
                return "PW max value 60";
            else
                return "PW max value is not 60";
        }

        public string PWControledByUser_Minus()
        {
            ClickOnPWMinus(8, "FSR");

            if (FSRPWMinimumValue.Text.Equals("10"))
                return "PW min value 10";
            else
                return "PW min value is not 10";
        }

        public string PowerControledByUser_Pluse()
        {
            ClickOnPowerPluse(8);

            if (FSRPowerMaximumValue.Text.Equals("6"))
                return "Power max value 6";
            else
                return "Power max value is not 6";
            ;
        }
        public string PowerControledByUser_Minus()
        {
            ClickOnPowerMinusIntensif(8, "FSR");

            if (FSRPowerMinimumValue.Text.Equals("1"))
                return "Power min value 1";
            else
                return "Power min value is not 1";
        }
        public string TreatmentTimer()
        {
            return pulseCounter.Text;
        }
        public string CheckFSRFaceEntered()
        {
            try
            {
                return FSRLabel.Text;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
