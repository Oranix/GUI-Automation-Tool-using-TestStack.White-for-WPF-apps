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
    internal class ContourMaxDefaultPage : TestBase
    {
        public ContourMaxDefaultPage(string[] area, string[] defaultsPasses, string[] defaultsPower, string[] defaultsIntervalTime)
        {
            Area = area;
            DefaultsPasses = defaultsPasses;
            DefaultsPower = defaultsPower;
            DefaultsIntervalTime = defaultsIntervalTime;
        }

        public Button ContourBtn => window.Get<Button>(SearchCriteria.ByText("ContourMax"));
        public Label ContourLabel => window.Get<Label>(SearchCriteria.ByText("Body ContourMax"));
        public Label FlanksContour => window.Get<Label>(SearchCriteria.ByText("Flanks"));
        public Label FlanksDefaultPasses => window.Get<Label>(SearchCriteria.ByText("10"));
        public Label FlanksDefaultPower => window.Get<Label>(SearchCriteria.ByText("65"));
        public Label FlanksIntervalTime => window.Get<Label>(SearchCriteria.ByText("30"));
        public Label AbdomenContour => window.Get<Label>(SearchCriteria.ByText("Abdomen"));
        public Label AbdomenDefaultPasses => window.Get<Label>(SearchCriteria.ByText("10"));
        public Label AbdomenDefaultPower => window.Get<Label>(SearchCriteria.ByText("70"));
        public Label AbdomenIntervalTime => window.Get<Label>(SearchCriteria.ByText("30"));
        public Label ButtocksContour => window.Get<Label>(SearchCriteria.ByText("Buttocks"));
        public Label ButtocksDefaultPasses => window.Get<Label>(SearchCriteria.ByText("10"));
        public Label ButtocksDefaultPower => window.Get<Label>(SearchCriteria.ByText("70"));
        public Label ButtocksIntervalTime => window.Get<Label>(SearchCriteria.ByText("30"));
        public Label ThighsContour => window.Get<Label>(SearchCriteria.ByText("Thighs"));
        public Label ThighsDefaultPasses => window.Get<Label>(SearchCriteria.ByText("10"));
        public Label ThighsDefaultPower => window.Get<Label>(SearchCriteria.ByText("70"));
        public Label ThighsIntervalTime => window.Get<Label>(SearchCriteria.ByText("30"));
        public Label BackContour => window.Get<Label>(SearchCriteria.ByText("Back"));
        public Label BackDefaultPasses => window.Get<Label>(SearchCriteria.ByText("10"));
        public Label BackDefaultPower => window.Get<Label>(SearchCriteria.ByText("60"));
        public Label BackIntervalTime => window.Get<Label>(SearchCriteria.ByText("30"));
        public Label ContourLedOff => window.Get<Label>(SearchCriteria.ByText("START"));
        public Label ContourPassesMaximumValue => window.Get<Label>(SearchCriteria.ByText("15"));
        public Label ContourPassesMinimumValue => window.Get<Label>(SearchCriteria.ByText("0"));
        public Label ContourPowerMaximumValue => window.Get<Label>(SearchCriteria.ByText("100"));
        public Label ContourPowerMinimumValue => window.Get<Label>(SearchCriteria.ByText("50"));

        public Label savePasses => window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(0));  //Save Passes

        public Label savePower => window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(1));  //Save power

        public Label saveIntervalTime => window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(15));  //Save interval 
        public Label NoExecuteIntervalTime => window.Get<Label>(SearchCriteria.ByText("30"));


        public string[] Area { get; set; }
        public string[] DefaultsPasses { get; set; }
        public string[] DefaultsPower { get; set; }
        public string[] DefaultsIntervalTime { get; set; }

        public int maxPassesValue = 15;
        public int maxPowerValue = 100;
        public int minPowerValue = 50;

        public void checkallinfo()
        {
            for (int i = 0; i < 40; i++)
                Console.WriteLine(i + " " + window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(i)));

        }

        public void ContourMaxPage()
        {
            ContourBtn.Click();
            WaitForTransition();
        }

        public string FlanksDefaultPassesPowerTime(/*string passes, string power, string intervalTime*/)
        {
            ClickOnScreen((int)FlanksContour.Location.X, (int)FlanksContour.Location.Y);
            Thread.Sleep(1000);

            var textPasses = FlanksDefaultPasses.Text;
            var textPower = FlanksDefaultPower.Text;
            var textIntervalTime = FlanksIntervalTime.Text;
            if (DefaultsPasses[0] == textPasses && DefaultsPower[0] == textPower && DefaultsIntervalTime[0] == textIntervalTime)
                return "Defaults are OK!";

            return "Defaults are wrong!";

        }

        public string AbdomenDefaultPassesPowerTime(/*string passes, string power, string intervalTime*/)
        {
            ClickOnScreen((int)AbdomenContour.Location.X, (int)AbdomenContour.Location.Y);
            Thread.Sleep(1000);

            var textPasses = AbdomenDefaultPasses.Text;
            var textPower = AbdomenDefaultPower.Text;
            var textIntervalTime = AbdomenIntervalTime.Text;
            if (DefaultsPasses[1] == textPasses && DefaultsPower[1] == textPower && DefaultsIntervalTime[1] == textIntervalTime)
                return "Defaults are OK!";

            return "Defaults are wrong!";

        }

        public string BackDefaultPassesPowerTime(/*string passes, string power, string intervalTime*/)
        {
            ClickOnScreen((int)BackContour.Location.X, (int)BackContour.Location.Y);
            Thread.Sleep(1000);

            var textPasses = BackDefaultPasses.Text;
            var textPower = BackDefaultPower.Text;
            var textIntervalTime = BackIntervalTime.Text;
            if (DefaultsPasses[2] == textPasses && DefaultsPower[2] == textPower && DefaultsIntervalTime[2] == textIntervalTime)
                return "Defaults are OK!";

            return "Defaults are wrong!";

        }

        public string ButtocksDefaultPassesPowerTime(/*string passes, string power, string intervalTime*/)
        {
            ClickOnScreen((int)ButtocksContour.Location.X, (int)ButtocksContour.Location.Y);
            Thread.Sleep(1000);

            var textPasses = ButtocksDefaultPasses.Text;
            var textPower = ButtocksDefaultPower.Text;
            var textIntervalTime = ButtocksIntervalTime.Text;
            if (DefaultsPasses[3] == textPasses && DefaultsPower[3] == textPower && DefaultsIntervalTime[3] == textIntervalTime)
                return "Defaults are OK!";

            return "Defaults are wrong!";

        }

        public string ThighsDefaultPassesPowerTime(/*string passes, string power, string intervalTime*/)
        {
            ClickOnScreen((int)ThighsContour.Location.X, (int)ThighsContour.Location.Y);
            Thread.Sleep(1000);

            var textPasses = ThighsDefaultPasses.Text;
            var textPower = ThighsDefaultPower.Text;
            var textIntervalTime = ThighsIntervalTime.Text;
            if (DefaultsPasses[4] == textPasses && DefaultsPower[4] == textPower && DefaultsIntervalTime[4] == textIntervalTime)
                return "Defaults are OK!";

            return "Defaults are wrong!";

        }

        public bool LedOffCheck()
        {
            string standbyContour = ContourLedOff.Text;
            string intervalTime = NoExecuteIntervalTime.Text;

            if (standbyContour == "START" && intervalTime == "30")
            {
                Logger.Error("Contour Standby Mode, LED indication - OFF");
                return true;
            }

            return false;

        }

        public string PassesControledByUser_Pluse(string area)
        {
            int pressingAmount = 0;

            switch (area)
            {
                case "Flanks":
                    ClickOnScreen((int)FlanksContour.Location.X, (int)FlanksContour.Location.Y);

                    pressingAmount = maxPassesValue - Convert.ToInt32(DefaultsPasses[0]);
                    ClickOnPassesPluse(pressingAmount);

                    break;

                case "Abdomen":
                    ClickOnScreen((int)AbdomenContour.Location.X, (int)AbdomenContour.Location.Y);
                    Thread.Sleep(1000);
                    ClickOnPassesPluse(5);
                    break;
                case "Buttocks":
                    ClickOnScreen((int)ButtocksContour.Location.X, (int)ButtocksContour.Location.Y);

                    pressingAmount = maxPassesValue - Convert.ToInt32(DefaultsPasses[1]);
                    ClickOnPassesPluse(pressingAmount);

                    break;

                case "Thighs":
                    ClickOnScreen((int)ThighsContour.Location.X, (int)ThighsContour.Location.Y);

                    pressingAmount = maxPassesValue - Convert.ToInt32(DefaultsPasses[2]);
                    ClickOnPassesPluse(pressingAmount);

                    break;

                case "Back":
                    ClickOnScreen((int)BackContour.Location.X, (int)BackContour.Location.Y);

                    pressingAmount = maxPassesValue - Convert.ToInt32(DefaultsPasses[3]);
                    ClickOnPassesPluse(pressingAmount);

                    break;
            }

            int actualMaxValue = Convert.ToInt32(ContourPassesMaximumValue.Text);
            return actualMaxValue == 15 ? "Passes max value 15" : $"Passes max value is {actualMaxValue} instead of 15";
        }

        public string PassesControledByUser_Minus()
        {
            ClickOnPassesMinus(maxPassesValue);  //dec from maxPassesValue

            int actualMinValue = Convert.ToInt32(ContourPassesMinimumValue.Text);
            return actualMinValue == 0 ? "Passes min value 0" : $"Passes min value is {actualMinValue} instead of 0";
        }

        public string PowerControledByUser_Pluse()
        {
            int pressingAmount = 0;

            pressingAmount = maxPowerValue - Convert.ToInt32(DefaultsPower[1]); //[1] for selecting the minimum default power value from the all areas

            ClickOnPowerPluse(pressingAmount);

            int actualMaxValue = Convert.ToInt32(ContourPowerMaximumValue.Text);
            return actualMaxValue == 100 ? "Power max value 100" : $"Power max Value is  {actualMaxValue} instead of 100";
        }

        public string PowerControledByUser_Minus()
        {
            int pressingAmount = maxPowerValue - minPowerValue;
            ClickOnPowerMinus(pressingAmount);

            ClickOnPowerMinus(maxPowerValue);

            int actualMaxValue = Convert.ToInt32(ContourPowerMinimumValue.Text);
            return actualMaxValue == 45 ? "Power max value 45" : $"Power max Value is  {actualMaxValue} instead of 45";
        }

        public string CheckContourEntered()
        {
            bool isContourSelected = WaitUntil(() => ContourLabel.Visible && FlanksContour.Enabled, 10000, "Contour body treatment area is not open");

            if (isContourSelected)
                return "Contour page is enterd properly";

            Logger.Error("Contour area not displayed");
            return "Contour area not enterd";
        }
    }
}
