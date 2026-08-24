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
    internal class SmallMaxDefaultPage : TestBase
    {
        public SmallMaxDefaultPage(string[] area, string[] defaultsPasses, string[] defaultsPower, string[] defaultsIntervalTime)
        {
            Area = area;
            DefaultsPasses = defaultsPasses;
            DefaultsPower = defaultsPower;
            DefaultsIntervalTime = defaultsIntervalTime;
        }

        public Button SmallMaxBtn => window.Get<Button>(SearchCriteria.ByText("SmallMax"));
        public Label SmallLabel => window.Get<Label>(SearchCriteria.ByText("Face SmallMax"));
        public Label SmallCheeks => window.Get<Label>(SearchCriteria.ByText("Cheeks"));
        public Label CheeksDefaultPasses => window.Get<Label>(SearchCriteria.ByText("10"));
        public Label CheeksDefaultPower => window.Get<Label>(SearchCriteria.ByText("40"));
        public Label CheeksIntervalTime => window.Get<Label>(SearchCriteria.ByText("30"));
        public Label SmallNeck => window.Get<Label>(SearchCriteria.ByText("Neck"));
        public Label NeckDefaultPasses => window.Get<Label>(SearchCriteria.ByText("10"));
        public Label NeckDefaultPower => window.Get<Label>(SearchCriteria.ByText("35"));
        public Label NeckIntervalTime => window.Get<Label>(SearchCriteria.ByText("30"));
        public Label SmallSubmental => window.Get<Label>(SearchCriteria.ByText("Submental"));
        public Label SubmentalDefaultPasses => window.Get<Label>(SearchCriteria.ByText("10"));
        public Label SubmentalDefaultPower => window.Get<Label>(SearchCriteria.ByText("40"));
        public Label SubmentalIntervalTime => window.Get<Label>(SearchCriteria.ByText("30"));
        public Label SmallDecolletage => window.Get<Label>(SearchCriteria.ByText("Decolletage"));
        public Label DecolltageDefaultPasses => window.Get<Label>(SearchCriteria.ByText("10"));
        public Label DecolltageDefaultPower => window.Get<Label>(SearchCriteria.ByText("40"));
        public Label DecolltageIntervalTime => window.Get<Label>(SearchCriteria.ByText("30"));
        public Label SmallLedOff => window.Get<Label>(SearchCriteria.ByText("START"));
        public Label SmallPassesMaximumValue => window.Get<Label>(SearchCriteria.ByText("15"));
        public Label SmallPassesMinimumValue => window.Get<Label>(SearchCriteria.ByText("0"));
        public Label SmallPowerMaximumValue => window.Get<Label>(SearchCriteria.ByText("60"));
        public Label SmallPowerMinimumValue => window.Get<Label>(SearchCriteria.ByText("20"));

        public Label savePasses => window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(0));  //Save Passes

        public Label savePower => window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(1));  //Save power

        public Label saveIntervalTime => window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(15));  //Save interval 


        public string[] Area { get; set; }
        public string[] DefaultsPasses { get; set; }
        public string[] DefaultsPower { get; set; }
        public string[] DefaultsIntervalTime { get; set; }

        public int maxPassesValue = 15;
        public int maxPowerValue = 60;
        public int minPowerValue = 20;

        public void checkallinfo()
        {
            for (int i = 0; i < 40; i++)
                Console.WriteLine(i + " " + window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(i)));
        }

        public void SmallMaxPage()
        {
            SmallMaxBtn.Click();
            WaitForTransition();
        }

        public string CheeksDefaultPassesPowerTime(/*string passes, string power, string intervalTime*/)
        {
            Thread.Sleep(1000);

            ClickOnScreen((int)SmallCheeks.Location.X, (int)SmallCheeks.Location.Y);

            var textPasses = CheeksDefaultPasses.Text;
            var textPower = CheeksDefaultPower.Text;
            var textIntervalTime = CheeksIntervalTime.Text;

            if (DefaultsPasses[0] == textPasses && DefaultsPower[0] == textPower && DefaultsIntervalTime[0] == textIntervalTime)
                return "Defaults are OK!";
            return "Defaults are wrong!";


        }

        public string NeckDefaultPassesPowerTime(/*string passes, string power, string intervalTime*/)
        {
            Thread.Sleep(1000);

            ClickOnScreen((int)SmallNeck.Location.X, (int)SmallNeck.Location.Y);

            var textPasses = NeckDefaultPasses.Text;
            var textPower = NeckDefaultPower.Text;
            var textIntervalTime = NeckIntervalTime.Text;

            if (DefaultsPasses[1] == textPasses && DefaultsPower[1] == textPower && DefaultsIntervalTime[1] == textIntervalTime)
                return "Defaults are OK!";
            return "Defaults are wrong!";

        }

        public string SubmentalDefaultPassesPowerTime(/*string passes, string power, string intervalTime*/)
        {
            Thread.Sleep(1000);

            ClickOnScreen((int)SmallSubmental.Location.X, (int)SmallSubmental.Location.Y);

            var textPasses = SubmentalDefaultPasses.Text;
            var textPower = SubmentalDefaultPower.Text;
            var textIntervalTime = SubmentalIntervalTime.Text;

            if (DefaultsPasses[2] == textPasses && DefaultsPower[2] == textPower && DefaultsIntervalTime[2] == textIntervalTime)
                return "Defaults are OK!";
            return "Defaults are wrong!";

        }

        public string DecolletageDefaultPassesPowerTime(/*string passes, string power, string intervalTime*/)
        {
            Thread.Sleep(1000);

            ClickOnScreen((int)SmallDecolletage.Location.X, (int)SmallDecolletage.Location.Y);

            var textPasses = DecolltageDefaultPasses.Text;
            var textPower = DecolltageDefaultPower.Text;
            var textIntervalTime = DecolltageIntervalTime.Text;

            if (DefaultsPasses[3] == textPasses && DefaultsPower[3] == textPower && DefaultsIntervalTime[3] == textIntervalTime)
                return "Defaults are OK!";
            return "Defaults are wrong!";

        }

        public bool LedOffCheck()
        {
            if (SmallLedOff.Text.Equals("START"))
                return true;

            return false;

        }

        public string PassesControledByUser_Pluse(string area)
        {
            int pressingAmount = 0;

            switch (area)
            {
                case "Cheeks":
                    ClickOnScreen((int)SmallCheeks.Location.X, (int)SmallCheeks.Location.Y);

                    pressingAmount = maxPassesValue - Convert.ToInt32(DefaultsPasses[0]);
                    ClickOnPassesPluse(pressingAmount);

                    break;

                case "Neck":
                    ClickOnScreen((int)SmallNeck.Location.X, (int)SmallNeck.Location.Y);

                    pressingAmount = maxPassesValue - Convert.ToInt32(DefaultsPasses[1]);
                    ClickOnPassesPluse(pressingAmount);

                    break;

                case "Submental":
                    ClickOnScreen((int)SmallSubmental.Location.X, (int)SmallSubmental.Location.Y);

                    pressingAmount = maxPassesValue - Convert.ToInt32(DefaultsPasses[2]);
                    ClickOnPassesPluse(pressingAmount);

                    break;

                case "Decolletage":
                    ClickOnScreen((int)SmallDecolletage.Location.X, (int)SmallDecolletage.Location.Y);

                    pressingAmount = maxPassesValue - Convert.ToInt32(DefaultsPasses[3]);
                    ClickOnPassesPluse(pressingAmount);

                    break;

            }

            int actualMaxValue = Convert.ToInt32(SmallPassesMaximumValue.Text);
            return actualMaxValue == 15 ? "Passes max value 15" : $"Passes max value is {actualMaxValue} instead of 15";

        }

        public string PassesControledByUser_Minus()
        {
            ClickOnPassesMinus(maxPassesValue);  //dec from maxPassesValue

            int actualMinValue = Convert.ToInt32(SmallPassesMinimumValue.Text);
            return actualMinValue == 0 ? "Passes min value 0" : $"Passes min value is {actualMinValue} instead of 0";

        }

        public string PowerControledByUser_Pluse()
        {
            int pressingAmount = 0;

            pressingAmount = maxPowerValue - Convert.ToInt32(DefaultsPower[1]); //[1] for selecting the minimum power value from the all areas

            ClickOnPowerPluse(pressingAmount);

            int actualMaxValue = Convert.ToInt32(SmallPowerMaximumValue.Text);
            return actualMaxValue == 60 ? "Power max value 60" : $"Power max Value is  {actualMaxValue} instead of 60";
          
        }

        public string PowerControledByUser_Minus()
        {
            int pressingAmount = maxPowerValue - minPowerValue;
            ClickOnPowerMinus(pressingAmount);


            int actualMinValue = Convert.ToInt32(SmallPowerMinimumValue.Text);
            return actualMinValue == 20 ? "Power min value 20" : $"Power min value is {actualMinValue} instead of 20";
          
        }

        public string CheckSmallEntered()
        {
            
            bool isSmallSelected = WaitUntil(() => SmallLabel.Visible && SmallCheeks.Enabled, 10000, "Small treatment area is not open");

            if (isSmallSelected)
                return "Face SmallMax is enterd";

            Logger.Error("Small area not displayed");
            return "Small area not enterd";
        }
    }
}
