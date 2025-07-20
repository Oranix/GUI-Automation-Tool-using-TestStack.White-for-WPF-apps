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


        public string[] Area { get; set; }
        public string[] DefaultsPasses { get; set; }
        public string[] DefaultsPower { get; set; }
        public string[] DefaultsIntervalTime { get; set; }

        public void checkallinfo()
        {
            for (int i = 0; i < 40; i++)
                Console.WriteLine(i + " " + window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(i)));

        }

        public void ContourMaxPage()
        {
            ContourBtn.Click();
            Thread.Sleep(2500);
        }

        public string FlanksDefaultPassesPowerTime(/*string passes, string power, string intervalTime*/)
        {
            ClickOnScreen((int)FlanksContour.Location.X, (int)FlanksContour.Location.Y);
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
        public string AbdomenDefaultPassesPowerTime(/*string passes, string power, string intervalTime*/)
        {
            ClickOnScreen((int)AbdomenContour.Location.X, (int)AbdomenContour.Location.Y);
            Thread.Sleep(1500);

            var textPasses = AbdomenDefaultPasses.Text;
            var textPower = AbdomenDefaultPower.Text;
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
        public string BackDefaultPassesPowerTime(/*string passes, string power, string intervalTime*/)
        {
            ClickOnScreen((int)BackContour.Location.X, (int)BackContour.Location.Y);
            Thread.Sleep(1500);

            var textPasses = BackDefaultPasses.Text;
            var textPower = BackDefaultPower.Text;
            var textIntervalTime = BackIntervalTime.Text;
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
            ClickOnScreen((int)ButtocksContour.Location.X, (int)ButtocksContour.Location.Y);
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
            ClickOnScreen((int)ThighsContour.Location.X, (int)ThighsContour.Location.Y);
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
        public bool LedOffCheck()
        {
            if (ContourLedOff.Text.Equals("START"))
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
                    ClickOnScreen((int)FlanksContour.Location.X, (int)FlanksContour.Location.Y);
                    Thread.Sleep(1000);
                    ClickOnPassesPluse(5);
                    break;               
                case "Abdomen":
                    ClickOnScreen((int)AbdomenContour.Location.X, (int)AbdomenContour.Location.Y);
                    Thread.Sleep(1000);
                    ClickOnPassesPluse(5);
                    break;
                case "Buttocks":
                    ClickOnScreen((int)ButtocksContour.Location.X, (int)ButtocksContour.Location.Y);
                    Thread.Sleep(1000);
                    ClickOnPassesPluse(5);
                    break;
                case "Thighs":
                    ClickOnScreen((int)ThighsContour.Location.X, (int)ThighsContour.Location.Y);
                    Thread.Sleep(1000);
                    ClickOnPassesPluse(5);
                    break;              
                case "Back":
                    ClickOnScreen((int)BackContour.Location.X, (int)BackContour.Location.Y);
                    Thread.Sleep(1000);
                    ClickOnPassesPluse(5);
                    break;
            }
            if (ContourPassesMaximumValue.Text.Equals("15"))
                return "Passes max value 15";
            else
                return "Passes max value is not 15";
        }
        public string PassesControledByUser_Minus()
        {
            ClickOnPassesMinus(15);

            if (ContourPassesMinimumValue.Text.Equals("0"))
                return "Passes min value 0";
            else
                return "Passes min Value is not 0";
        }

        public string PowerControledByUser_Pluse()
        {
            ClickOnPowerPluse(40);

            if (ContourPowerMaximumValue.Text.Equals("100"))
                return "Power max Value 100";
            else
                return "Power max Value is not 100";
        }
        public string PowerControledByUser_Minus()
        {
            ClickOnPowerMinus(50);

            if (ContourPowerMinimumValue.Text.Equals("50"))
                return "Power min Value 50";
            else
                return "Power min Value is not 50";
        }
        public string CheckContourEntered()
        {
            try
            {
                return ContourLabel.Text;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
