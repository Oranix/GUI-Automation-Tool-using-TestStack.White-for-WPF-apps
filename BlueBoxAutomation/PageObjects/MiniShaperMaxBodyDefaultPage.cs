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

        public Label savePasses => window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(0));  //Save Passes

        public Label savePower => window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(1));  //Save power

        public Label saveIntervalTime => window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(14));  //Save interval 

        public string[] Area { get; set; }
        public string[] DefaultsPasses { get; set; }
        public string[] DefaultsPower { get; set; }
        public string[] DefaultsIntervalTime { get; set; }

        public void checkallinfo()
        {
            for (int i = 0; i < 40; i++)
                Console.WriteLine(i + " " + window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(i)));
      
        }

        public void MiniShaperBodyMaxPage()
        {
            MiniShaperBtn.Click();
            Thread.Sleep(2500);
        }

        public string DecolletageDefaultPassesPowerTime(/*string passes, string power, string intervalTime*/)
        {
            ClickOnScreen((int)DecolletageMiniShaper.Location.X, (int)DecolletageMiniShaper.Location.Y);
            Thread.Sleep(1500);

            var textPasses = DecolletageDefaultPasses.Text;
            var textPower = DecolletageDefaultPower.Text;
            var textIntervalTime = DecolletageIntervalTime.Text;
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
            ClickOnScreen((int)ArmsMiniShaper.Location.X, (int)ArmsMiniShaper.Location.Y);
            Thread.Sleep(1500);

            var textPasses = ArmsDefaultPasses.Text;
            var textPower = ArmsDefaultPower.Text;
            var textIntervalTime = ArmsIntervalTime.Text;
            if (DefaultsPasses[1] == textPasses && DefaultsPower[1] == textPower && DefaultsIntervalTime[1] == textIntervalTime)
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
            ClickOnScreen((int)KneesMiniShaper.Location.X, (int)KneesMiniShaper.Location.Y);
            Thread.Sleep(1500);

            var textPasses = KneesDefaultPasses.Text;
            var textPower = KneesDefaultPower.Text;
            var textIntervalTime = KneesIntervalTime.Text;
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
                case "Decolletage":
                    ClickOnScreen((int)DecolletageMiniShaper.Location.X, (int)DecolletageMiniShaper.Location.Y);
                    Thread.Sleep(1000);
                    ClickOnPassesPluse(5);
                    break;
                case "Arms":
                    ClickOnScreen((int)ArmsMiniShaper.Location.X, (int)ArmsMiniShaper.Location.Y);
                    Thread.Sleep(1000);
                    ClickOnPassesPluse(2);
                    break;
                case "Knees":
                    ClickOnScreen((int)KneesMiniShaper.Location.X, (int)KneesMiniShaper.Location.Y);
                    Thread.Sleep(1000);
                    ClickOnPassesPluse(2);
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
            ClickOnPowerPluse(40);

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
        public string CheckMiniShaperBodyEntered()
        {
            try
            {
                return MiniShaperBodyLabel.Text;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


    }

}
