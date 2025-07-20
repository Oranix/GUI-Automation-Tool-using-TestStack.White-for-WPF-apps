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
    internal class ShaperMaxDefaultPage : TestBase
    {
        public ShaperMaxDefaultPage(string[] area, string[] defaultsPasses, string[] defaultsPower, string[] defaultsIntervalTime)
        {
            Area = area;
            DefaultsPasses = defaultsPasses;
            DefaultsPower = defaultsPower;
            DefaultsIntervalTime = defaultsIntervalTime;
        }

        public Label ShaperBtn => window.Get<Label>(SearchCriteria.ByText("ShaperMax"));
        public Label ShaperLabel => window.Get<Label>(SearchCriteria.ByText("Body ShaperMax"));
        public Label FlanksShaper => window.Get<Label>(SearchCriteria.ByText("Flanks"));
        public Label FlanksDefaultPasses => window.Get<Label>(SearchCriteria.ByText("10"));
        public Label FlanksDefaultPower => window.Get<Label>(SearchCriteria.ByText("55"));
        public Label FlanksIntervalTime => window.Get<Label>(SearchCriteria.ByText("30"));
        public Label ArmsShaper => window.Get<Label>(SearchCriteria.ByText("Arms"));
        public Label AbdomenShaper => window.Get<Label>(SearchCriteria.ByText("Abdomen"));
        public Label ButtocksShaper => window.Get<Label>(SearchCriteria.ByText("Buttocks"));
        public Label ThighsShaper => window.Get<Label>(SearchCriteria.ByText("Thighs"));
        public Label KneesShaper => window.Get<Label>(SearchCriteria.ByText("Knees"));
        public Label BackShaper => window.Get<Label>(SearchCriteria.ByText("Back"));
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
        public Label ShaperLedOff => window.Get<Label>(SearchCriteria.ByText("START"));
        public Label ShaperPassesMaximumValue => window.Get<Label>(SearchCriteria.ByText("15"));
        public Label ShaperPassesMinimumValue => window.Get<Label>(SearchCriteria.ByText("0"));
        public Label ShaperPowerMaximumValue => window.Get<Label>(SearchCriteria.ByText("100"));
        public Label ShaperPowerMinimumValue => window.Get<Label>(SearchCriteria.ByText("45"));
        public Label savePasses => window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(0));  //Save Passes

        public Label savePower => window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(1));  //Save power

        public Label saveIntervalTime => window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(17));  //Save interval 

        public string[] Area { get; set; }
        public string[] DefaultsPasses { get; set; }
        public string[] DefaultsPower { get; set; }
        public string[] DefaultsIntervalTime { get; set; }

        public void checkallinfo()
        {
            for (int i = 0; i < 40; i++)
                Console.WriteLine(i + " " + window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(i)));

        }

        public void ShaperMaxPage()
        {
            ShaperBtn.Click();
            Thread.Sleep(2500);
        }

        public string FlanksDefaultPassesPowerTime(/*string passes, string power, string intervalTime*/)
        {
            ClickOnScreen((int)FlanksShaper.Location.X, (int)FlanksShaper.Location.Y);
            Thread.Sleep(1500);

            var textPasses = FlanksDefaultPasses.Text;
            var textPower = FlanksDefaultPower.Text;
            var textIntervalTime = FlanksIntervalTime.Text;
            if (DefaultsPasses[0] == textPasses && DefaultsPower[0] == textPower && DefaultsIntervalTime[0] == textIntervalTime)
            {
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
            Thread.Sleep(1500);

            var textPasses = ArmsDefaultPasses.Text;
            var textPower = ArmsDefaultPower.Text;
            var textIntervalTime = AbdomenIntervalTime.Text;
            if (DefaultsPasses[1] == textPasses && DefaultsPower[1] == textPower && DefaultsIntervalTime[1] == textIntervalTime)
            {
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
            Thread.Sleep(1500);

            var textPasses = AbdomenDefaultPasses.Text;
            var textPower = AbdomenDefaultPower.Text;
            var textIntervalTime = AbdomenIntervalTime.Text;
            if (DefaultsPasses[2] == textPasses && DefaultsPower[2] == textPower && DefaultsIntervalTime[2] == textIntervalTime)
            {
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
            Thread.Sleep(1500);

            var textPasses = ButtocksDefaultPasses.Text;
            var textPower = ButtocksDefaultPower.Text;
            var textIntervalTime = ButtocksIntervalTime.Text;
            if (DefaultsPasses[3] == textPasses && DefaultsPower[3] == textPower && DefaultsIntervalTime[3] == textIntervalTime)
            {
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
            Thread.Sleep(1500);

            var textPasses = ThighsDefaultPasses.Text;
            var textPower = ThighsDefaultPower.Text;
            var textIntervalTime = ThighsIntervalTime.Text;
            if (DefaultsPasses[4] == textPasses && DefaultsPower[4] == textPower && DefaultsIntervalTime[4] == textIntervalTime)
            {
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
            Thread.Sleep(1500);

            var textPasses = KneesDefaultPasses.Text;
            var textPower = KneesDefaultPower.Text;
            var textIntervalTime = KneesIntervalTime.Text;
            if (DefaultsPasses[5] == textPasses && DefaultsPower[5] == textPower && DefaultsIntervalTime[5] == textIntervalTime)
            {
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
            Thread.Sleep(1500);

            var textPasses = BackDefaultPasses.Text;
            var textPower = BackDefaultPower.Text;
            var textIntervalTime = BackIntervalTime.Text;
            if (DefaultsPasses[6] == textPasses && DefaultsPower[6] == textPower && DefaultsIntervalTime[6] == textIntervalTime)
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
            if (ShaperLedOff.Text.Equals("START"))
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
                case "Flanks":
                    ClickOnScreen((int)FlanksShaper.Location.X, (int)FlanksShaper.Location.Y);
                    Thread.Sleep(1000);
                    ClickOnPassesPluse(5);
                    break;
                case "Arms":
                    ClickOnScreen((int)ArmsShaper.Location.X, (int)ArmsShaper.Location.Y);
                    Thread.Sleep(1000);
                    ClickOnPassesPluse(5);
                    break;
                case "Abdomen":
                    ClickOnScreen((int)AbdomenShaper.Location.X, (int)AbdomenShaper.Location.Y);
                    Thread.Sleep(1000);
                    ClickOnPassesPluse(5);
                    break;
                case "Buttocks":
                    ClickOnScreen((int)ButtocksShaper.Location.X, (int)ButtocksShaper.Location.Y);
                    Thread.Sleep(1000);
                    ClickOnPassesPluse(5);
                    break;
                case "Thighs":
                    ClickOnScreen((int)ThighsShaper.Location.X, (int)ThighsShaper.Location.Y);
                    Thread.Sleep(1000);
                    ClickOnPassesPluse(5);
                    break;
                case "Knees":
                    ClickOnScreen((int)KneesShaper.Location.X, (int)KneesShaper.Location.Y);
                    Thread.Sleep(1000);
                    ClickOnPassesPluse(5);
                    break;
                case "Back":
                    ClickOnScreen((int)BackShaper.Location.X, (int)BackShaper.Location.Y);
                    Thread.Sleep(1000);
                    ClickOnPassesPluse(5);
                    break;
            }
            if (ShaperPassesMaximumValue.Text.Equals("15"))
                return "Passes max value 15";
            else
                return "Passes max value is not 15";
        }

        public string PassesControledByUser_Minus()
        {
            ClickOnPassesMinus(15);

            if (ShaperPassesMinimumValue.Text.Equals("0"))
                return "Passes min value 0";
            else
                return "Passes min Value is not 0";
        }

        public string PowerControledByUser_Pluse()
        {
            ClickOnPowerPluse(55);

            if (ShaperPowerMaximumValue.Text.Equals("100"))
                return "Power max Value 100";
            else
                return "Power max Value is not 100";
        }
        public string PowerControledByUser_Minus()
        {
            ClickOnPowerMinus(55);

            if (ShaperPowerMinimumValue.Text.Equals("45"))
                return "Power min Value 45";
            else
                return "Power min Value is not 45";
        }
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
