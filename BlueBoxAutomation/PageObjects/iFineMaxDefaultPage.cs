using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.WPFUIItems;
using Label = TestStack.White.UIItems.Label;

namespace BlueBoxAutomation
{
    public class iFineMaxDefaultPage : TestBase
    {
        public Button IfineMaxBtn => window.Get<Button>(SearchCriteria.ByText("iFineMax"));
        public Label IFineLabel => window.Get<Label>(SearchCriteria.ByText("Face iFineMax"));
        public Label PeriorbitalIfine => window.Get<Label>(SearchCriteria.ByText("Periorbital"));   
        public Label Perioralfine => window.Get<Label>(SearchCriteria.ByText("Perioral"));        
        public Label LedOff => window.Get<Label>(SearchCriteria.ByText("START"));
        public Label iFinePassesMaximumValue => window.Get<Label>(SearchCriteria.ByText("15"));
        public Label iFinePassesMinimumValue => window.Get<Label>(SearchCriteria.ByText("0"));
        public Label iFinePowerMaximumValue => window.Get<Label>(SearchCriteria.ByText("6"));
        public Label iFinePowerMinimumValue => window.Get<Label>(SearchCriteria.ByText("1"));
        public Label savePasses => window.Get<Label>(SearchCriteria.ByText("10")/*.AndIndex(0)*/);  //Save Passes
        public Label savePower => window.Get<Label>(SearchCriteria.ByText("3")/*.AndIndex(1)*/);  //Save power

        //public Label saveIntervalTime => window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(13));  //Save interval 
        public Label saveIntervalTime => window.Get<Label>(SearchCriteria.ByText("30")/*.AndIndex(13)*/);  //Save interval 


        public iFineMaxDefaultPage(string[] area, string[] defaultsPasses, string[] defaultsPower, string[] defaultsIntervalTime)
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

        public void IFineMAX()
        {
            IfineMaxBtn.Click();
            Thread.Sleep(2500);                   
        }

        public string PeriorbitalDefaultPassesPowerTime(/*string passes, string power, string intervalTime*/)
        {
            ClickOnScreen((int)PeriorbitalIfine.Location.X, (int)PeriorbitalIfine.Location.Y);
            Thread.Sleep(1500);

            var textPasses = savePasses.Text;
            var textPower = savePower.Text;
            var textIntervalTime = saveIntervalTime.Text;
            if (DefaultsPasses[0] == textPasses && DefaultsPower[0] == textPower && DefaultsIntervalTime[0] == textIntervalTime)
            {
                return "Defaults are OK!";
            }
            else
            {
                return "Defaults are wrong!";
            }
        }

        public string PerioralDefaultPassesPowerTime(/*string passes, string power, string intervalTime*/)
        {
            ClickOnScreen((int)Perioralfine.Location.X, (int)Perioralfine.Location.Y);
            Thread.Sleep(1500);

            var textPasses = savePasses.Text;
            var textPower = savePower.Text;
            var textIntervalTime = saveIntervalTime.Text;
            if (DefaultsPasses[1] == textPasses && DefaultsPower[1] == textPower && DefaultsIntervalTime[1] == textIntervalTime)
            {
                return "Defaults are OK!";
            }
            else
            {
                return "Defaults are wrong!";
            }
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

        public string PassesControledByUser_Pluse(string area)
        {
            switch (area)
            {
                case "Periorbital":
                    ClickOnScreen((int)PeriorbitalIfine.Location.X, (int)PeriorbitalIfine.Location.Y);
                    Thread.Sleep(1000);
                    ClickOnPassesPluse(5);
                    break;
                case "Perioral":
                    ClickOnScreen((int)Perioralfine.Location.X, (int)Perioralfine.Location.Y);
                    Thread.Sleep(1000);
                    ClickOnPassesPluse(5);
                    break;
            }

            if (iFinePassesMaximumValue.Text.Equals("15"))
                return "Passes max value 15";
            else
                return "Passes max value is not 15";
        }

        public string PassesControledByUser_Minus()
        {
            ClickOnPassesMinus(15);

            if (iFinePassesMinimumValue.Text.Equals("0"))
                return "Passes min value 0";
            else
                return "Passes min value is not 0";
        }

        public string PowerControledByUser_Pluse()
        {
            ClickOnPowerPluse(3);

            if (iFinePowerMaximumValue.Text.Equals("6"))
                return "Power max Value 6";
            else
                return "Power max Value is not 6";
        }
        public string PowerControledByUser_Minus()
        {
            ClickOnPowerMinus(5);

            if (iFinePowerMinimumValue.Text.Equals("1"))
                return "Power min Value 1";
            else
                return "Power min Value is not 1";
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
