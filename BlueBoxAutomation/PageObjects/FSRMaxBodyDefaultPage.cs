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
    internal class FSRMaxBodyDefaultPage : TestBase
    {
        public FSRMaxBodyDefaultPage(string[] area, string[] defaultPW, string[] defaultPower)
        {
            Area = area;
            DefaultsPW = defaultPW;
            DefaultsPower = defaultPower;
        }

        public string[] Area { get; set; }
        public string[] DefaultsPW { get; set; }
        public string[] DefaultsPower { get; set; }

        public Label FSRMaxBtn => window.Get<Label>(SearchCriteria.ByText("FSRMax"));
        public Label FSRLabel => window.Get<Label>(SearchCriteria.ByText("Body FSRMax"));
        public Label HandsFSR => window.Get<Label>(SearchCriteria.ByText("Hands"));
        public Label DecolletageFSR => window.Get<Label>(SearchCriteria.ByText("Decolletage"));
        public Label ButtocksFSR => window.Get<Label>(SearchCriteria.ByText("Buttocks"));
        public Label AbdomenFSR => window.Get<Label>(SearchCriteria.ByText("Abdomen"));
        public Label ArmsFSR => window.Get<Label>(SearchCriteria.ByText("Arms"));
        public Label savePW => window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(0));  //Save PW value
        public Label savePower => window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(1));  //Save Power value
        public Label LedOff => window.Get<Label>(SearchCriteria.ByText("START"));
        public Label FSRPWMaximumValue => window.Get<Label>(SearchCriteria.ByText("60"));
        public Label FSRPWMinimumValue => window.Get<Label>(SearchCriteria.ByText("10"));
        public Label FSRPowerMaximumValue => window.Get<Label>(SearchCriteria.ByText("6"));
        public Label FSRPowerMinimumValue => window.Get<Label>(SearchCriteria.ByText("1"));
        public Label pulseCounter => window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(15));  //Save pulse counter after pressing start
        public Label HandsdDefaultPW => window.Get<Label>(SearchCriteria.ByText("20"));
        public Label HandsDefaultPower => window.Get<Label>(SearchCriteria.ByText("3"));
        public Label DecolletageDefaultPW => window.Get<Label>(SearchCriteria.ByText("20"));
        public Label DecolletageDefaultPower => window.Get<Label>(SearchCriteria.ByText("3"));
        public Label ButtocksDefaultPW => window.Get<Label>(SearchCriteria.ByText("20"));
        public Label ButtocksDefaultPower => window.Get<Label>(SearchCriteria.ByText("3"));
        public Label AbdomenDefaultPW => window.Get<Label>(SearchCriteria.ByText("20"));
        public Label AbdomenDefaultPower => window.Get<Label>(SearchCriteria.ByText("3"));
        public Label ArmsDefaultPW => window.Get<Label>(SearchCriteria.ByText("20"));
        public Label ArmsDefaultPower => window.Get<Label>(SearchCriteria.ByText("2"));


        public void checkallinfo()
        {
            for (int i = 0; i < 40; i++)
                Console.WriteLine(i + " " + window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(i)));
            //0 WPFLabel.AutomationId:, Name: 20, ControlType: text, FrameworkId: WPF
            //1 WPFLabel.AutomationId:, Name: 3, ControlType: text, FrameworkId: WPF
            //2 WPFLabel.AutomationId:, Name: P.WIDTH[ms], ControlType: text, FrameworkId: WPF
            //3 WPFLabel.AutomationId:, Name: POWER[W], ControlType: text, FrameworkId: WPF
            //4 WPFLabel.AutomationId:, Name: Hands, ControlType: text, FrameworkId: WPF
            //5 WPFLabel.AutomationId:, Name: +, ControlType: text, FrameworkId: WPF
            //6 WPFLabel.AutomationId:, Name: +, ControlType: text, FrameworkId: WPF
            //7 WPFLabel.AutomationId:, Name: Decolletage, ControlType: text, FrameworkId: WPF
            //8 WPFLabel.AutomationId:, Name: Buttocks, ControlType: text, FrameworkId: WPF
            //9 WPFLabel.AutomationId:, Name: Abdomen, ControlType: text, FrameworkId: WPF
            //10 WPFLabel.AutomationId:, Name:–, ControlType: text, FrameworkId: WPF
            //11 WPFLabel.AutomationId:, Name:–, ControlType: text, FrameworkId: WPF
            //12 WPFLabel.AutomationId:, Name: Arms, ControlType: text, FrameworkId: WPF
            //13 WPFLabel.AutomationId:, Name: PULSES, ControlType: text, FrameworkId: WPF
            //14 WPFLabel.AutomationId:, Name: START, ControlType: text, FrameworkId: WPF
            //15 WPFLabel.AutomationId:, Name: Body FSRMax, ControlType:text, FrameworkId: WPF


        }

        public void FSRMAXPage()
        {
            FSRMaxBtn.Click();
            Thread.Sleep(2500);
        }

        public string HandsDefaultPWPower()
        {
            ClickOnScreen((int)HandsFSR.Location.X, (int)HandsFSR.Location.Y);
            Thread.Sleep(1500);

            var textPW = HandsdDefaultPW.Text;
            var textPower = HandsDefaultPower.Text;
            if (DefaultsPW[0] == textPW && DefaultsPower[0] == textPower) { return "Hands PW and Power defaults are OK!"; }
            else { return "Hands defaults are wrong!"; }
        }
        public string DecolletageDefaultPWPower()
        {
            ClickOnScreen((int)DecolletageFSR.Location.X, (int)DecolletageFSR.Location.Y);
            Thread.Sleep(1500);

            var textPW = DecolletageDefaultPW.Text;
            var textPower = DecolletageDefaultPower.Text;
            if (DefaultsPW[1] == textPW && DefaultsPower[1] == textPower) { return "Decolletage PW and Power defaults are OK!"; }
            else { return "Decolletage defaults are wrong!"; }
        }
        public string ButtocksDefaultPWPower()
        {
            ClickOnScreen((int)ButtocksFSR.Location.X, (int)ButtocksFSR.Location.Y);
            Thread.Sleep(1500);

            var textPW = ButtocksDefaultPW.Text;
            var textPower = ButtocksDefaultPower.Text;
            if (DefaultsPW[2] == textPW && DefaultsPower[2] == textPower) { return "Buttocks PW and Power defaults are OK!"; }
            else { return "Buttocks defaults are wrong!"; }
        }
        public string AbdomenDefaultPWPower()
        {
            ClickOnScreen((int)AbdomenFSR.Location.X, (int)AbdomenFSR.Location.Y);
            Thread.Sleep(1500);

            var textPW = AbdomenDefaultPW.Text;
            var textPower = AbdomenDefaultPower.Text;
            if (DefaultsPW[3] == textPW && DefaultsPower[3] == textPower) { return "Abdomen PW and Power defaults are OK!"; }
            else { return "Abdomen defaults are wrong!"; }
        }
        public string ArmsDefaultPWPower()
        {
            ClickOnScreen((int)ArmsFSR.Location.X, (int)ArmsFSR.Location.Y);
            Thread.Sleep(1500);

            var textPW = ArmsDefaultPW.Text;
            var textPower = ArmsDefaultPower.Text;
            if (DefaultsPW[4] == textPW && DefaultsPower[4] == textPower) { return "Arms PW and Power defaults are OK!"; }
            else { return "Arms defaults are wrong!"; }
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
                case "Hands":
                    ClickOnScreen((int)HandsFSR.Location.X, (int)HandsFSR.Location.Y);
                    Thread.Sleep(500);
                    ClickOnPWPluseIntensif(5);
                    break;
                case "Decolletage":
                    ClickOnScreen((int)DecolletageFSR.Location.X, (int)DecolletageFSR.Location.Y);
                    Thread.Sleep(500);
                    ClickOnPWPluseIntensif(5);
                    break;
                case "Buttocks":
                    ClickOnScreen((int)ButtocksFSR.Location.X, (int)ButtocksFSR.Location.Y);
                    Thread.Sleep(500);
                    ClickOnPWPluseIntensif(5);
                    break;
                case "Abdomen":
                    ClickOnScreen((int)AbdomenFSR.Location.X, (int)AbdomenFSR.Location.Y);
                    Thread.Sleep(500);
                    ClickOnPWPluseIntensif(5);
                    break;
                case "Arms":
                    ClickOnScreen((int)ArmsFSR.Location.X, (int)ArmsFSR.Location.Y);
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
        public string CheckFSRBodyEntered()
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
