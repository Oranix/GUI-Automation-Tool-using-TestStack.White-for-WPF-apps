using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems;
using System.Threading;
using AutomationCore;

namespace BlueBoxAutomation
{
    internal class MiniShaperMaxBodyDefaultPage : TestBase
    {
        public MiniShaperMaxBodyDefaultPage(string[] area, string[] defaultsPasses, string[] defaultsPower, string[] defaultsIntervalTime)
        {
            Area = area;
            DefaultsPasses = defaultsPasses;
            DefaultsPower = defaultsPower;
            DefaultsIntervalTime = defaultsIntervalTime;
        }

        public Label MiniShaperBtn => window.Get<Label>(SearchCriteria.ByText("MiniShaperMax"));
        public Label MiniShaperBodyLabel => window.Get<Label>(SearchCriteria.ByText("Body MiniShaperMax"));
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
        public Label MiniShaperPassesMaximumValue => window.Get<Label>(SearchCriteria.ByText("15"));
        public Label MiniShaperPassesMinimumValue => window.Get<Label>(SearchCriteria.ByText("0"));
        public Label MiniShaperPowerMaximumValue => window.Get<Label>(SearchCriteria.ByText("70"));
        public Label MiniShaperPowerMinimumValue => window.Get<Label>(SearchCriteria.ByText("20"));
        public Label NoExecuteIntervalTime => window.Get<Label>(SearchCriteria.ByText("30"));


        public Label savePasses => window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(0));  //Save Passes

        public Label savePower => window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(1));  //Save power

        public Label saveIntervalTime => window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(14));  //Save interval 

        public string[] Area { get; set; }
        public string[] DefaultsPasses { get; set; }
        public string[] DefaultsPower { get; set; }
        public string[] DefaultsIntervalTime { get; set; }

        public int maxPassesValue = 15;
        public int maxPowerValue = 70;
        public int minPowerValue = 20;

        public void checkallinfo()
        {
            for (int i = 0; i < 40; i++)
                Console.WriteLine(i + " " + window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(i)));

        }

        public void MiniShaperBodyMaxPage()
        {
            MiniShaperBtn.Click();
            WaitForTransition();
        }

        public string DecolletageDefaultPassesPowerTime(/*string passes, string power, string intervalTime*/)
        {
            ClickOnScreen((int)DecolletageMiniShaper.Location.X, (int)DecolletageMiniShaper.Location.Y);
            Thread.Sleep(1500);

            var textPasses = DecolletageDefaultPasses.Text;
            var textPower = DecolletageDefaultPower.Text;
            var textIntervalTime = DecolletageIntervalTime.Text;
            if (DefaultsPasses[0] == textPasses && DefaultsPower[0] == textPower && DefaultsIntervalTime[0] == textIntervalTime)
                return "Defaults are OK!";

            return "Defaults are wrong!";

        }
        public string ArmsDefaultPassesPowerTime(/*string passes, string power, string intervalTime*/)
        {
            ClickOnScreen((int)ArmsMiniShaper.Location.X, (int)ArmsMiniShaper.Location.Y);
            Thread.Sleep(1000);

            var textPasses = ArmsDefaultPasses.Text;
            var textPower = ArmsDefaultPower.Text;
            var textIntervalTime = ArmsIntervalTime.Text;
            if (DefaultsPasses[1] == textPasses && DefaultsPower[1] == textPower && DefaultsIntervalTime[1] == textIntervalTime)
                return "Defaults are OK!";

            return "Defaults are wrong!";

        }
        public string KneesDefaultPassesPowerTime(/*string passes, string power, string intervalTime*/)
        {
            ClickOnScreen((int)KneesMiniShaper.Location.X, (int)KneesMiniShaper.Location.Y);
            Thread.Sleep(1000);

            var textPasses = KneesDefaultPasses.Text;
            var textPower = KneesDefaultPower.Text;
            var textIntervalTime = KneesIntervalTime.Text;
            if (DefaultsPasses[2] == textPasses && DefaultsPower[2] == textPower && DefaultsIntervalTime[2] == textIntervalTime)
                return "Defaults are OK!";

            return "Defaults are wrong!";

        }

        public bool LedOffCheck()
        {
            string standbyModeMiniShaper = MiniShaperLedOff.Text;
            string intervalTime = NoExecuteIntervalTime.Text;

            if (standbyModeMiniShaper == "START" && intervalTime == "30")
            {
                Logger.Error("MiniShaper Body Standby Mode, LED indication - OFF");
                return true;
            }

            return false;

        }

        public string PassesControledByUser_Pluse(string area)
        {
            int pressingAmount = 0;

            switch (area)
            {
                case "Decolletage":
                    ClickOnScreen((int)DecolletageMiniShaper.Location.X, (int)DecolletageMiniShaper.Location.Y);

                    pressingAmount = maxPassesValue - Convert.ToInt32(DefaultsPasses[0]);
                    ClickOnPassesPluse(pressingAmount);

                    break;

                case "Arms":
                    ClickOnScreen((int)ArmsMiniShaper.Location.X, (int)ArmsMiniShaper.Location.Y);

                    pressingAmount = maxPassesValue - Convert.ToInt32(DefaultsPasses[1]);
                    ClickOnPassesPluse(pressingAmount);

                    break;

                case "Knees":
                    ClickOnScreen((int)KneesMiniShaper.Location.X, (int)KneesMiniShaper.Location.Y);

                    pressingAmount = maxPassesValue - Convert.ToInt32(DefaultsPasses[2]);
                    ClickOnPassesPluse(pressingAmount);

                    break;
            }

            int actualMaxValue = Convert.ToInt32(MiniShaperPassesMaximumValue.Text);
            return actualMaxValue == 15 ? "Passes max value 15" : $"Passes max value is {actualMaxValue} instead of 15";
        }

        public string PassesControledByUser_Minus()
        {

            ClickOnPassesMinus(maxPassesValue);  //dec from maxPassesValue

            int actualMinValue = Convert.ToInt32(MiniShaperPassesMinimumValue.Text);
            return actualMinValue == 0 ? "Passes min value 0" : $"Passes min value is {actualMinValue} instead of 0";
        }

        public string PowerControledByUser_Pluse()
        {
            int pressingAmount = 0;

            pressingAmount = maxPowerValue - Convert.ToInt32(DefaultsPower[1]); //[1] for selecting the minimum default power value from the all areas

            ClickOnPowerPluse(pressingAmount);

            int actualMaxValue = Convert.ToInt32(MiniShaperPowerMaximumValue.Text);
            return actualMaxValue == 70 ? "Power max value 70" : $"Power max Value is  {actualMaxValue} instead of 70";
        }

        public string PowerControledByUser_Minus()
        {
            int pressingAmount = maxPowerValue - minPowerValue;
            ClickOnPowerMinus(pressingAmount);

            ClickOnPowerMinus(maxPowerValue);

            int actualMaxValue = Convert.ToInt32(MiniShaperPowerMinimumValue.Text);
            return actualMaxValue == 20 ? "Power max value 20" : $"Power max Value is  {actualMaxValue} instead of 20";
        }
        public string CheckMiniShaperBodyEntered()
        {
            bool isMiniShaperSelected = WaitUntil(() => MiniShaperBodyLabel.Visible && DecolletageMiniShaper.Enabled, 10000, "MiniShaper body treatment area is not open");

            if (isMiniShaperSelected)
                return "Body MiniShaperMax page is enterd properly";

            Logger.Error("MiniShaper area not displayed");
            return "MiniShaper area not enterd";
        }


    }

}
