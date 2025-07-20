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

        public void checkallinfo()
        {
            for (int i = 0; i < 40; i++)
                Console.WriteLine(i + " " + window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(i)));          
        }

        public void SmallMaxPage()
        {
            SmallMaxBtn.Click();
            Thread.Sleep(2500);
        }

        public string CheeksDefaultPassesPowerTime(/*string passes, string power, string intervalTime*/)
        {
            ClickOnScreen((int)SmallCheeks.Location.X, (int)SmallCheeks.Location.Y);
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

        public string NeckDefaultPassesPowerTime(/*string passes, string power, string intervalTime*/)
        {
            ClickOnScreen((int)SmallNeck.Location.X, (int)SmallNeck.Location.Y);
            Thread.Sleep(1500);

            var textPasses = NeckDefaultPasses.Text;
            var textPower = NeckDefaultPower.Text;
            var textIntervalTime = NeckIntervalTime.Text;
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
            ClickOnScreen((int)SmallSubmental.Location.X, (int)SmallSubmental.Location.Y);
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

        public string DecolletageDefaultPassesPowerTime(/*string passes, string power, string intervalTime*/)
        {
            ClickOnScreen((int)SmallDecolletage.Location.X, (int)SmallDecolletage.Location.Y);
            Thread.Sleep(1500);

            var textPasses = DecolltageDefaultPasses.Text;
            var textPower = DecolltageDefaultPower.Text;
            var textIntervalTime = DecolltageIntervalTime.Text;
            if (DefaultsPasses[3] == textPasses && DefaultsPower[3] == textPower && DefaultsIntervalTime[3] == textIntervalTime)
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
            if (SmallLedOff.Text.Equals("START"))
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
            switch (area) {
                case "Cheeks":
                ClickOnScreen((int)SmallCheeks.Location.X, (int)SmallCheeks.Location.Y);
                Thread.Sleep(1000);
                ClickOnPassesPluse(5);
                    break;
                case "Neck":
                    ClickOnScreen((int)SmallNeck.Location.X, (int)SmallNeck.Location.Y);
                    Thread.Sleep(1000);
                    ClickOnPassesPluse(5);
                    break;
                case "Submental":
                    ClickOnScreen((int)SmallSubmental.Location.X, (int)SmallSubmental.Location.Y);
                    Thread.Sleep(1000);
                    ClickOnPassesPluse(5);
                    break;
                case "Decolletage":
                    ClickOnScreen((int)SmallDecolletage.Location.X, (int)SmallDecolletage.Location.Y);
                    Thread.Sleep(1000);
                    ClickOnPassesPluse(5);
                    break;

            }
            if (SmallPassesMaximumValue.Text.Equals("15"))
                return "Passes max value 15";
            else
                return "Passes max value is not 15";
        }

        public string PassesControledByUser_Minus()
        {
            ClickOnPassesMinus(15);

            if (SmallPassesMinimumValue.Text.Equals("0"))
                return "Passes min value 0";
            else
                return "Passes min Value is not 0";
        }

        public string PowerControledByUser_Pluse()
        {
            ClickOnPowerPluse(25);

            if (SmallPowerMaximumValue.Text.Equals("60"))
                return "Power max Value 60";
            else
                return "Power max Value is not 60";
        }

        public string PowerControledByUser_Minus()
        {
            ClickOnPowerMinus(40);

            if (SmallPowerMinimumValue.Text.Equals("20"))
                return "Power min Value 20";
            else
                return "Power min Value is not 20";
        }

        public string CheckSmallEntered()
        {
            try
            {
                return SmallLabel.Text;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
