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
    internal class MiniShaperMaxFaceDefaultPage : TestBase
    {
        public MiniShaperMaxFaceDefaultPage(string[] area, string[] defaultsPasses, string[] defaultsPower, string[] defaultsIntervalTime)
        {
            Area = area;
            DefaultsPasses = defaultsPasses;
            DefaultsPower = defaultsPower;
            DefaultsIntervalTime = defaultsIntervalTime;
        }

        public Button MiniShaperBtn => window.Get<Button>(SearchCriteria.ByText("MiniShaperMax"));
        public Label MiniShaperFaceLabel => window.Get<Label>(SearchCriteria.ByText("Face MiniShaperMax"));
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
        public Label MiniShaperLedOff => window.Get<Label>(SearchCriteria.ByText("START"));
        public Label MiniShaperPassesMaximumValue => window.Get<Label>(SearchCriteria.ByText("15"));
        public Label MiniShaperPassesMinimumValue => window.Get<Label>(SearchCriteria.ByText("0"));
        public Label MiniShaperPowerMaximumValue => window.Get<Label>(SearchCriteria.ByText("70"));
        public Label MiniShaperPowerMinimumValue => window.Get<Label>(SearchCriteria.ByText("20"));
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

        public void MiniShaperMaxPage()
        {
            MiniShaperBtn.Click();
            WaitForTransition();
        }

        public string CheeksDefaultPassesPowerTime(/*string passes, string power, string intervalTime*/)
        {
            Thread.Sleep(1000);

            ClickOnScreen((int)CheeksMiniShaper.Location.X, (int)CheeksMiniShaper.Location.Y);

            var textPasses = CheeksDefaultPasses.Text;
            var textPower = CheeksDefaultPower.Text;
            var textIntervalTime = CheeksIntervalTime.Text;
            if (DefaultsPasses[0] == textPasses && DefaultsPower[0] == textPower && DefaultsIntervalTime[0] == textIntervalTime)
                return "Defaults are OK!";

            return "Defaults are wrong!";

        }

        public string JawlineDefaultPassesPowerTime(/*string passes, string power, string intervalTime*/)
        {
            Thread.Sleep(1000);

            ClickOnScreen((int)JawlineMiniShaper.Location.X, (int)JawlineMiniShaper.Location.Y);

            var textPasses = JawlineDefaultPasses.Text;
            var textPower = JawlineDefaultPower.Text;
            var textIntervalTime = JawlineIntervalTime.Text;
            if (DefaultsPasses[1] == textPasses && DefaultsPower[1] == textPower && DefaultsIntervalTime[1] == textIntervalTime)
                return "Defaults are OK!";

            return "Defaults are wrong!";

        }

        public string SubmentalDefaultPassesPowerTime(/*string passes, string power, string intervalTime*/)
        {
            Thread.Sleep(1000);

            ClickOnScreen((int)SubmentalMiniShaper.Location.X, (int)SubmentalMiniShaper.Location.Y);

            var textPasses = SubmentalDefaultPasses.Text;
            var textPower = SubmentalDefaultPower.Text;
            var textIntervalTime = SubmentalIntervalTime.Text;
            if (DefaultsPasses[2] == textPasses && DefaultsPower[2] == textPower && DefaultsIntervalTime[2] == textIntervalTime)
                return "Defaults are OK!";

            return "Defaults are wrong!";

        }
        public bool LedOffCheck()
        {
            if (MiniShaperLedOff.Text.Equals("START"))
                return true;

            return false;

        }

        public string PassesControledByUser_Pluse(string area)
        {
            int pressingAmount = 0;

            switch (area)
            {
                case "Cheeks":
                    ClickOnScreen((int)CheeksMiniShaper.Location.X, (int)CheeksMiniShaper.Location.Y);

                    pressingAmount = maxPassesValue - Convert.ToInt32(DefaultsPasses[0]);
                    ClickOnPassesPluse(pressingAmount);

                    break;

                case "Jawline":
                    ClickOnScreen((int)JawlineMiniShaper.Location.X, (int)JawlineMiniShaper.Location.Y);

                    pressingAmount = maxPassesValue - Convert.ToInt32(DefaultsPasses[1]);
                    ClickOnPassesPluse(pressingAmount);

                    break;

                case "Submental":
                    ClickOnScreen((int)SubmentalMiniShaper.Location.X, (int)SubmentalMiniShaper.Location.Y);

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

            pressingAmount = maxPowerValue - Convert.ToInt32(DefaultsPower[2]); //[1] for selecting the minimum default power value from the all areas

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
        public string CheckMiniShaperFaceEntered()
        {
            bool isMiniShaperSelected = WaitUntil(() => MiniShaperFaceLabel.Visible && CheeksMiniShaper.Enabled, 10000, "MiniShaper treatment area is not open");

            if (isMiniShaperSelected)
                return "Face MiniShaperMax page is enterd properly";

            Logger.Error("MiniShaper area not displayed");
            return "MiniShaper area not enterd";

        }
    }
}
