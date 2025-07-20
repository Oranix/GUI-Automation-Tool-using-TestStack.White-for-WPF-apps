using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems;
using System.Threading;

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

        public void MiniShaperMaxPage()
        {
            MiniShaperBtn.Click();
            Thread.Sleep(2500);
        }

        public string CheeksDefaultPassesPowerTime(/*string passes, string power, string intervalTime*/)
        {
            ClickOnScreen((int)CheeksMiniShaper.Location.X, (int)CheeksMiniShaper.Location.Y);
            Thread.Sleep(1500);

            var textPasses = CheeksDefaultPasses.Text;
            var textPower = CheeksDefaultPower.Text;
            var textIntervalTime = CheeksIntervalTime.Text;
            if (DefaultsPasses[0] == textPasses && DefaultsPower[0] == textPower && DefaultsIntervalTime[0] == textIntervalTime)
            {
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
            Thread.Sleep(1500);

            var textPasses = JawlineDefaultPasses.Text;
            var textPower = JawlineDefaultPower.Text;
            var textIntervalTime = JawlineIntervalTime.Text;
            if (DefaultsPasses[1] == textPasses && DefaultsPower[1] == textPower && DefaultsIntervalTime[1] == textIntervalTime)
            {
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
            Thread.Sleep(1500);

            var textPasses = SubmentalDefaultPasses.Text;
            var textPower = SubmentalDefaultPower.Text;
            var textIntervalTime = SubmentalIntervalTime.Text;
            if (DefaultsPasses[2] == textPasses && DefaultsPower[2] == textPower && DefaultsIntervalTime[2] == textIntervalTime)
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
            if (MiniShaperLedOff.Text.Equals("START"))
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
                case "Cheeks":
                    ClickOnScreen((int)CheeksMiniShaper.Location.X, (int)CheeksMiniShaper.Location.Y);
                    Thread.Sleep(1000);
                    ClickOnPassesPluse(6);
                    break;
                case "Jawline":
                    ClickOnScreen((int)JawlineMiniShaper.Location.X, (int)JawlineMiniShaper.Location.Y);
                    Thread.Sleep(1000);
                    ClickOnPassesPluse(6);
                    break;
                case "Submental":
                    ClickOnScreen((int)SubmentalMiniShaper.Location.X, (int)SubmentalMiniShaper.Location.Y);
                    Thread.Sleep(1000);
                    ClickOnPassesPluse(6);
                    break;
            }
            if (MiniShaperPassesMaximumValue.Text.Equals("15"))
                return "Passes max value 15";
            else
                return "Passes max value is not 15";
        }

        public string PassesControledByUser_Minus()
        {
            ClickOnPassesMinus(15);

            if (MiniShaperPassesMinimumValue.Text.Equals("0"))
                return "Passes min value 0";
            else
                return "Passes min Value is not 0";
        }

        public string PowerControledByUser_Pluse()
        {
            ClickOnPowerPluse(50);

            if (MiniShaperPowerMaximumValue.Text.Equals("70"))
                return "Power max Value 70";
            else
                return "Power max Value is not 70";
        }
        public string PowerControledByUser_Minus()
        {
            ClickOnPowerMinus(50);

            if (MiniShaperPowerMinimumValue.Text.Equals("20"))
                return "Power min Value 20";
            else
                return "Power min Value is not 20";
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
