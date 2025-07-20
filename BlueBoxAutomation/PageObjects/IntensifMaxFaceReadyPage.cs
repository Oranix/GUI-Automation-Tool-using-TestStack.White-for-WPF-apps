using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;

namespace BlueBoxAutomation.PageObjects
{
    internal class IntensifMaxFaceReadyPage : TestBase
    {
        public Label IntensifMaxBtn => window.Get<Label>(SearchCriteria.ByText("IntensifMax"));
        public Label IntensifLabel => window.Get<Label>(SearchCriteria.ByText("Face IntensifMax"));
        public Label ForeheadIntensif => window.Get<Label>(SearchCriteria.ByText("Forehead"));
        public Label ForeheadDefaultPW => window.Get<Label>(SearchCriteria.ByText("80"));
        public Label ForeheadDepth => window.Get<Label>(SearchCriteria.ByText("1.5"));
        public Label ForeheadDefaultPower => window.Get<Label>(SearchCriteria.ByText("10"));
        public Label PeriorbitalIntensif => window.Get<Label>(SearchCriteria.ByText("Periorbital"));
        public Label PeriorbitalDefaultPW => window.Get<Label>(SearchCriteria.ByText("80"));
        public Label PeriorbitalDefaultDepth => window.Get<Label>(SearchCriteria.ByText("1.5"));
        public Label PeriorbitalDefaultPower => window.Get<Label>(SearchCriteria.ByText("10"));
        public Label CheeksIntensif => window.Get<Label>(SearchCriteria.ByText("Cheeks"));
        public Label CheeksDefaultPW => window.Get<Label>(SearchCriteria.ByText("110"));
        public Label CheeksDefaultDepth => window.Get<Label>(SearchCriteria.ByText("2.5"));
        public Label CheeksDefaultPower => window.Get<Label>(SearchCriteria.ByText("14"));
        public Label NeckIntensif => window.Get<Label>(SearchCriteria.ByText("Neck"));
        public Label NeckDefaultPW => window.Get<Label>(SearchCriteria.ByText("80"));
        public Label NeckDefaultDepth => window.Get<Label>(SearchCriteria.ByText("1.8"));
        public Label NeckDefaultPower => window.Get<Label>(SearchCriteria.ByText("12"));
        public Label LedOff => window.Get<Label>(SearchCriteria.ByText("START"));
        public Label IntensifPWMaximumValue => window.Get<Label>(SearchCriteria.ByText("500"));
        public Label IntensifPWMinimumValue => window.Get<Label>(SearchCriteria.ByText("20"));
        public Label IntensifDepthMaximumValue => window.Get<Label>(SearchCriteria.ByText("5"));
        public Label IntensifDepthMinimumValue => window.Get<Label>(SearchCriteria.ByText("0.5"));
        public Label IntensifPowerMaximumValue => window.Get<Label>(SearchCriteria.ByText("35"));
        public Label IntensifPowerMinimumValue => window.Get<Label>(SearchCriteria.ByText("0"));
        public Label ContinuousBtn => window.Get<Label>(SearchCriteria.ByText("CONTINUOUS"));
        public Label SingleBtn => window.Get<Label>(SearchCriteria.ByText("SINGLE"));
        public Label SLOW => window.Get<Label>(SearchCriteria.ByText("SLOW"));
        public Label MODERATE => window.Get<Label>(SearchCriteria.ByText("MODERATE"));
        public Label FAST => window.Get<Label>(SearchCriteria.ByText("FAST"));
        public Label IntensifPowerLimit => window.Get<Label>(SearchCriteria.ByText("16"));
        public Label tipCheckUpBtn => window.Get<Label>(SearchCriteria.ByText("Tip Checkup"));
        public Label savePW => window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(0));  //Save PW 
        public Label saveDepth => window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(1));  //Save Depth 
        public Label savePower => window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(2));  //Save Power


        //public int sloWtoleranceX;
        //public int sloWtoleranceY;
        //public bool checkupFlag = false;
        //public int maxAttempets = 0;
        //public int attempets = 0;
        //public bool firstCheckupOn = false;


        public IntensifMaxFaceReadyPage(string[] area, string[] defaultsPW, string[] defaultsDepth, string[] defaultsPower)
        {
            Area = area;
            DefaultsPW = defaultsPW;
            DefaultsDepth = defaultsDepth;
            DefaultsPower = defaultsPower;
        }

        public string[] Area { get; set; }
        public string[] DefaultsPower { get; set; }
        public string[] DefaultsPW { get; set; }
        public string[] DefaultsDepth { get; set; }

        public void IntneisfMAXPage()
        {
            IntensifMaxBtn.Click();
            Thread.Sleep(2500);
        }

        public string CheckIntneisfFaceEntered()
        {
            try
            {
                return IntensifLabel.Text;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public void ConnectTipsStatus(string tipType)
        {
            switch (tipType)
            {
                case "Hyper":
                    MessageBoxResult result = MessageBox.Show("Tip connect.\nPlease connect Hyper tip, press Ok after tip is connected.","Tip connect", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                 
                    break;

                case "Hybrid S":

                    break;

                case "Hybrid M":

                    break;

                case "Hybrid L":

                    break;

                case "Zebra":

                    break;


            }
        }
    }
}
