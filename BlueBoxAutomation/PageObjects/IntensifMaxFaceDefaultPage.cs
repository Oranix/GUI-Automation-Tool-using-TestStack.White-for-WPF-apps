using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems;
using System.Threading;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;
using System.Net.NetworkInformation;

namespace BlueBoxAutomation
{
    internal class IntensifMaxFaceDefaultPage : TestBase
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


        public int sloWtoleranceX;
        public int sloWtoleranceY;
        public bool checkupFlag = false;
        public int maxAttempets = 0;
        public int attempets = 0;
        public bool firstCheckupOn = false;


        public IntensifMaxFaceDefaultPage(string[] area, string[] defaultsPW, string[] defaultsDepth, string[] defaultsPower)
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

        public void checkallinfo()
        {
            for (int i = 0; i < 40; i++)
                Console.WriteLine(i + " " + window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(i)));
            //0 WPFLabel.AutomationId:, Name: 20, ControlType: text, FrameworkId: WPF
            //1 WPFLabel.AutomationId:, Name: 0.5, ControlType: text, FrameworkId: WPF
            //2 WPFLabel.AutomationId:, Name: 0, ControlType: text, FrameworkId: WPF
            //3 WPFLabel.AutomationId:, Name: P.WIDTH[ms], ControlType: text, FrameworkId: WPF
            //4 WPFLabel.AutomationId:, Name: DEPTH[mm], ControlType: text, FrameworkId: WPF
            //5 WPFLabel.AutomationId:, Name: POWER[W], ControlType: text, FrameworkId: WPF
            //6 WPFLabel.AutomationId:, Name: Forehead, ControlType: text, FrameworkId: WPF
            //7 WPFLabel.AutomationId:, Name: +, ControlType: text, FrameworkId: WPF
            //8 WPFLabel.AutomationId:, Name: +, ControlType: text, FrameworkId: WPF
            //9 WPFLabel.AutomationId:, Name: +, ControlType: text, FrameworkId: WPF
            //10 WPFLabel.AutomationId:, Name: Periorbital, ControlType: text, FrameworkId: WPF
            //11 WPFLabel.AutomationId:, Name: Cheeks, ControlType: text, FrameworkId: WPF
            //12 WPFLabel.AutomationId:, Name: Neck, ControlType: text, FrameworkId: WPF
            //13 WPFLabel.AutomationId:, Name:–, ControlType: text, FrameworkId: WPF
            //14 WPFLabel.AutomationId:, Name:–, ControlType: text, FrameworkId: WPF
            //15 WPFLabel.AutomationId:, Name:–, ControlType: text, FrameworkId: WPF
            //16 WPFLabel.AutomationId:, Name: PULSES, ControlType: text, FrameworkId: WPF
            //17 WPFLabel.AutomationId:, Name: Acc.Energy[mJ / pin], ControlType: text, FrameworkId: WPF
            //18 WPFLabel.AutomationId:, Name: SLOW, ControlType: text, FrameworkId: WPF
            //19 WPFLabel.AutomationId:, Name: MODERATE, ControlType: text, FrameworkId: WPF
            //20 WPFLabel.AutomationId:, Name: FAST, ControlType: text, FrameworkId: WPF
            //21 WPFLabel.AutomationId:, Name:, ControlType: text, FrameworkId: WPF
            //22 WPFLabel.AutomationId:, Name: CONTINUOUS, ControlType: text, FrameworkId: WPF
            //23 WPFLabel.AutomationId:, Name: START, ControlType: text, FrameworkId: WPF
            //24 WPFLabel.AutomationId:, Name: SINGLE, ControlType: text, FrameworkId: WPF
            //25 WPFLabel.AutomationId:, Name: Face IntensifMax, ControlType:text, FrameworkId: WPF
            //26 WPFLabel.AutomationId:, Name: Tip Checkup, ControlType:text, FrameworkId: WPF
        }

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

        public string ForeheadDefaultPWDepthPower(/*string PW, string depth, string power*/)
        {
            ClickOnScreen((int)ForeheadIntensif.Location.X, (int)ForeheadIntensif.Location.Y);
            Thread.Sleep(1500);

            var textPW = ForeheadDefaultPW.Text;
            var textDepth = ForeheadDepth.Text;
            var textPower = ForeheadDefaultPower.Text;
            if (DefaultsPW[0] == textPW && DefaultsDepth[0] == textDepth && DefaultsPower[0] == textPower)
            {
                return "Defaults are OK!";
            }
            else
            {
                return "Defaults are wrong!";
            }
        }

        public string PeriorbitalDefaultPWDepthPower(/*string PW, string depth, string power*/)
        {
            ClickOnScreen((int)PeriorbitalIntensif.Location.X, (int)PeriorbitalIntensif.Location.Y);
            Thread.Sleep(1500);

            var textPW = PeriorbitalDefaultPW.Text;
            var textDepth = PeriorbitalDefaultDepth.Text;
            var textPower = PeriorbitalDefaultPower.Text;
            if (DefaultsPW[1] == textPW && DefaultsDepth[1] == textDepth && DefaultsPower[1] == textPower)
            {
                return "Defaults are OK!";
            }
            else
            {
                return "Defaults are wrong!";
            }
        }

        public string CheeksDefaultPWDepthPower(/*string PW, string depth, string power*/)
        {
            ClickOnScreen((int)CheeksIntensif.Location.X, (int)CheeksIntensif.Location.Y);
            Thread.Sleep(1500);

            var textPW = CheeksDefaultPW.Text;
            var textDepth = CheeksDefaultDepth.Text;
            var textPower = CheeksDefaultPower.Text;
            if (DefaultsPW[2] == textPW && DefaultsDepth[2] == textDepth && DefaultsPower[2] == textPower)
            {
                return "Defaults are OK!";
            }
            else
            {
                return "Defaults are wrong!";
            }
        }

        public string NeckDefaultPWDepthPower(/*string PW, string depth, string power*/)
        {
            ClickOnScreen((int)NeckIntensif.Location.X, (int)NeckIntensif.Location.Y);
            Thread.Sleep(1500);

            var textPW = NeckDefaultPW.Text;
            var textDepth = NeckDefaultDepth.Text;
            var textPower = NeckDefaultPower.Text;
            if (DefaultsPW[3] == textPW && DefaultsDepth[3] == textDepth && DefaultsPower[3] == textPower)
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
            if (LedOff.Text.Equals("START"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string PWControledByUser_Pluse(string area)
        {
            switch (area)
            {
                case "Forehead":
                    ClickOnScreen((int)ForeheadIntensif.Location.X, (int)ForeheadIntensif.Location.Y);
                    Thread.Sleep(1000);
                    ClickOnPWPluse(42);
                    break;
                case "Periorbital":
                    ClickOnScreen((int)PeriorbitalIntensif.Location.X, (int)PeriorbitalIntensif.Location.Y);
                    Thread.Sleep(1000);
                    ClickOnPWPluse(42);
                    break;
                case "Cheeks":
                    ClickOnScreen((int)CheeksIntensif.Location.X, (int)CheeksIntensif.Location.Y);
                    Thread.Sleep(1000);
                    ClickOnPWPluse(42);
                    break;
                case "Neck":
                    ClickOnScreen((int)NeckIntensif.Location.X, (int)NeckIntensif.Location.Y);
                    Thread.Sleep(1000);
                    ClickOnPWPluse(42);
                    break;

            }
            if (IntensifPWMaximumValue.Text.Equals("500"))
                return "PW max value 500";
            else
                return "PW max value is not 500";
        }

        public string PWControledByUser_Minus()
        {
            ClickOnPWMinus(48);

            if (IntensifPWMinimumValue.Text.Equals("20"))
                return "PW min value 20";
            else
                return "PW min value is not 20";
        }

        public string DepthControledByUser_Pluse()
        {
            ClickOnDepthPluse(38);

            if (IntensifDepthMaximumValue.Text.Equals("5"))
                return "Depth max value 5";
            else
                return "Depth max value is not 5";

        }

        public string DepthControledByUser_Minus()
        {
            ClickOnDepthMinus(45);

            if (IntensifDepthMinimumValue.Text.Equals("0.5"))
                return "Depth min value 0.5";
            else
                return "Depth min value is not 1";
        }

        public string PowerControledByUser_Pluse()
        {
            ClickOnPowerPluse(25);

            if (IntensifPowerMaximumValue.Text.Equals("35"))
                return "Power max value 35";
            else
                return "Power max value is not 35";
            ;
        }
        public string PowerControledByUser_Minus()
        {
            ClickOnPowerMinusIntensif(38);

            if (IntensifPowerMinimumValue.Text.Equals("0"))
                return "Power min value 0";
            else
                return "Power min value is not 0";
        }
        public int CalculatePower(int pulseWidth)
        {
            if (pulseWidth <= 220)
                return 35;
            else if (pulseWidth <= 239)
                return 35;
            else if (pulseWidth <= 259)
                return 33;
            else if (pulseWidth <= 279)
                return 31;
            else if (pulseWidth <= 299)
                return 29;
            else if (pulseWidth <= 319)
                return 27;
            else if (pulseWidth <= 339)
                return 25;
            else if (pulseWidth <= 359)
                return 24;
            else if (pulseWidth <= 379)
                return 22;
            else if (pulseWidth <= 399)
                return 21;
            else if (pulseWidth <= 419)
                return 20;
            else if (pulseWidth <= 439)
                return 19;
            else if (pulseWidth <= 459)
                return 18;
            else if (pulseWidth <= 499)
                return 17;
            else
                return 16;
        }
        public int PowerLimitation(string value, int desiredPW, int PWincreaseNumber)
        {
            int expectedPower = 0;

            switch (value)
            {
                case "Forehead":
                    ForeheadIntensif.Click();
                    ClickOnPowerPluse(25);              //Get to 35W
                    ClickOnPWPluse(14);                  //Get to thershold 220PW
                    ClickOnPWPluse(PWincreaseNumber);
                    expectedPower = CalculatePower(desiredPW);
                    return expectedPower;
                case "Periorbital":
                    PeriorbitalIntensif.Click();
                    ClickOnPowerPluse(25);              //Get to 35W
                    ClickOnPWPluse(14);                  //Get to thershold 220PW
                    ClickOnPWPluse(PWincreaseNumber);
                    expectedPower = CalculatePower(desiredPW);
                    return expectedPower;
                case "Cheeks":
                    CheeksIntensif.Click();
                    ClickOnPowerPluse(21);               //Get to 35W
                    //ClickOnPWMinus(5);                   //Get to 20W
                    ClickOnPWPluse(11);                  //Get to thershold 220PW
                    ClickOnPWPluse(PWincreaseNumber);
                    expectedPower = CalculatePower(desiredPW);
                    return expectedPower;
                case "Neck":
                    NeckIntensif.Click();
                    ClickOnPowerPluse(23);              //Get to 35W
                    ClickOnPWPluse(14);                  //Get to 220PW
                    ClickOnPWPluse(PWincreaseNumber);
                    expectedPower = CalculatePower(desiredPW);
                    return expectedPower;
                default: return 0;
            }
        }

        public string ContinuousSingleSelect()
        {
            ForeheadIntensif.Click();
            Thread.Sleep(500);

            ContinuousBtn.Click();   //Continuous mode select

            if (SLOW.Location.X >= SLOW.Location.X - sloWtoleranceX && SLOW.Location.X <= SLOW.Location.X + sloWtoleranceX && SLOW.Location.Y >= SLOW.Location.Y - sloWtoleranceY && SLOW.Location.Y <= SLOW.Location.Y + sloWtoleranceY)
            {
                return "Continuous mode select";
            }
            else
                return "Continuous mode not selected";
        }

        public string SingleSelect()
        {
            ForeheadIntensif.Click();
            Thread.Sleep(500);

            SingleBtn.Click();   //Single mode 
            Thread.Sleep(500);

            return "Single mode select";
        }

        public string ContinuousSpeedOption(string speed)
        {
            sloWtoleranceX = (int)(SLOW.Location.X * 0.01);
            sloWtoleranceY = (int)(SLOW.Location.Y * 0.01);
            int moderatEtoleranceX = (int)(MODERATE.Location.X * 0.01);
            int moderatEtoleranceY = (int)(MODERATE.Location.Y * 0.01);
            int fasTtoleranceX = (int)(FAST.Location.X * 0.01);
            int fasTtoleranceY = (int)(FAST.Location.Y * 0.01);

            switch (speed)
            {
                case "SLOW":
                    SLOW.Click();
                    Thread.Sleep(500);
                    if (SLOW.Location.X >= SLOW.Location.X - sloWtoleranceX && SLOW.Location.X <= SLOW.Location.X + sloWtoleranceX && SLOW.Location.Y >= SLOW.Location.Y - sloWtoleranceY && SLOW.Location.Y <= SLOW.Location.Y + sloWtoleranceY)
                        return "SLOW Selected";
                    else
                        return "Fail to locate slow option";

                case "MODERATE":
                    MODERATE.Click();
                    Thread.Sleep(500);
                    if (MODERATE.Location.X >= MODERATE.Location.X - moderatEtoleranceX && MODERATE.Location.X <= MODERATE.Location.X + moderatEtoleranceX && MODERATE.Location.Y >= MODERATE.Location.Y - moderatEtoleranceY && MODERATE.Location.Y <= MODERATE.Location.Y + moderatEtoleranceY)
                        return "MODERATE Selected";
                    else
                        return "Fail to locate moderate option";

                case "FAST":
                    FAST.Click();
                    Thread.Sleep(500);
                    if (FAST.Location.X >= FAST.Location.X - fasTtoleranceX && FAST.Location.X <= FAST.Location.X + fasTtoleranceX && FAST.Location.Y >= FAST.Location.Y - fasTtoleranceY && FAST.Location.Y <= FAST.Location.Y + fasTtoleranceY)
                        return "FAST Selected";
                    else
                        return "Fail to locate fast option";

                default:
                    return "fail to select any speed option";
            }
        }
        public string changeAreasDuringContinuousSingleMode(string value)
        {
            switch (value)
            {
                case "Forehead": return ForeheadDefaultPWDepthPower(/*"80", "1.5", "10"*/);

                case "Periorbital": return PeriorbitalDefaultPWDepthPower(/*"80", "1.5", "10"*/);

                case "Cheeks": return CheeksDefaultPWDepthPower(/*"110", "2.5", "14"*/);

                case "Neck": return NeckDefaultPWDepthPower(/*"/*80", "1.8", "12"*/);

                default: return "No area selected";
            }
        }

        public bool tipCheckUpOnOff()
        {
            if (checkupFlag == false)
            {
                tipCheckUpBtn.Click();
                checkupFlag = true;
                Thread.Sleep(300);
                maxAttempets = 20;
                while (attempets < maxAttempets)
                {
                    var depthText = window.Get<Label>(SearchCriteria.ByText("5")).Text;
                    if (depthText == "5")
                        return true;

                    attempets++;
                }
                return false;
            }
            else
            {
                tipCheckUpBtn.Click();
                checkupFlag = false;
                Thread.Sleep(300);
                maxAttempets = 20;
                while (attempets < maxAttempets)
                {
                    //var depthText = window.Get<Label>(SearchCriteria.ByText("5")).Text;
                    //if (depthText == "5")
                    //{
                    //    firstCheckupOn = true;
                    //}
                    return false;

                    //attempets++;
                }

                return true;
            }

        }
        public string tipCheckUp(string value)
        {
            switch (value)
            {
                case "5.0mm":
                    maxAttempets = 20;
                    while (attempets < maxAttempets)
                    {
                        try
                        {
                            var depthText = window.Get<Label>(SearchCriteria.ByText("5")).Text;
                            if (depthText == "5")
                                return "5.0mm defined";
                        }
                        catch
                        {
                            ClickOnDepthMinus(5);
                            Thread.Sleep(200);
                            attempets++;
                        }
                    }
                    return "Attempts is over limit";
                case "4.5mm":
                    maxAttempets = 20;
                    while (attempets < maxAttempets)
                    {
                        try
                        {
                            var depthText = window.Get<Label>(SearchCriteria.ByText("4.5")).Text;
                            if (depthText == "4.5")
                                return "4.5mm defined";
                        }
                        catch
                        {
                            ClickOnDepthMinus(5);
                            Thread.Sleep(200);
                            attempets++;
                        }
                    }
                    return "Attempts is over limit";
                case "4.0mm":
                    maxAttempets = 20;
                    while (attempets < maxAttempets)
                    {
                        try
                        {
                            var depthText = window.Get<Label>(SearchCriteria.ByText("4")).Text;
                            if (depthText == "4")
                                return "4.0mm defined";
                        }
                        catch
                        {
                            ClickOnDepthMinus(5);
                            Thread.Sleep(200);
                            attempets++;
                        }
                    }
                    return "Attempts is over limit";
                case "3.5mm":
                    maxAttempets = 20;
                    while (attempets < maxAttempets)
                    {
                        try
                        {
                            var depthText = window.Get<Label>(SearchCriteria.ByText("3.5")).Text;
                            if (depthText == "3.5")
                                return "3.5mm defined";
                        }
                        catch
                        {
                            ClickOnDepthMinus(5);
                            Thread.Sleep(200);
                            attempets++;
                        }
                    }
                    return "Attempts is over limit";
                case "3.0mm":
                    maxAttempets = 20;
                    while (attempets < maxAttempets)
                    {
                        try
                        {
                            var depthText = window.Get<Label>(SearchCriteria.ByText("3")).Text;
                            if (depthText == "3")
                                return "3.0mm defined";
                        }
                        catch
                        {
                            ClickOnDepthMinus(5);
                            Thread.Sleep(200);
                            attempets++;
                        }
                    }
                    return "Attempts is over limit";
                case "2.5mm":
                    maxAttempets = 20;
                    while (attempets < maxAttempets)
                    {
                        try
                        {
                            var depthText = window.Get<Label>(SearchCriteria.ByText("2.5")).Text;
                            if (depthText == "2.5")
                                return "2.5mm defined";
                        }
                        catch
                        {
                            ClickOnDepthMinus(5);
                            Thread.Sleep(200);
                            attempets++;
                        }
                    }
                    return "Attempts is over limit";
                case "2.0mm":
                    maxAttempets = 20;
                    while (attempets < maxAttempets)
                    {
                        try
                        {
                            var depthText = window.Get<Label>(SearchCriteria.ByText("2")).Text;
                            if (depthText == "2")
                                return "2.0mm defined";
                        }
                        catch
                        {
                            ClickOnDepthMinus(5);
                            Thread.Sleep(200);
                            attempets++;
                        }
                    }
                    return "Attempts is over limit";
                case "1.5mm":
                    maxAttempets = 20;
                    while (attempets < maxAttempets)
                    {
                        try
                        {
                            var depthText = window.Get<Label>(SearchCriteria.ByText("1.5")).Text;
                            if (depthText == "1.5")
                                return "1.5mm defined";
                        }
                        catch
                        {
                            ClickOnDepthMinus(5);
                            Thread.Sleep(200);
                            attempets++;
                        }
                    }
                    return "Attempts is over limit";
                case "1.0mm":
                    maxAttempets = 20;
                    while (attempets < maxAttempets)
                    {
                        try
                        {
                            var depthText = window.Get<Label>(SearchCriteria.ByText("1")).Text;
                            if (depthText == "1")
                                return "1.0mm defined";
                        }
                        catch
                        {
                            ClickOnDepthMinus(5);
                            Thread.Sleep(200);
                            attempets++;
                        }
                    }
                    return "Attempts is over limit";
                case "0.5mm":
                    maxAttempets = 20;
                    while (attempets < maxAttempets)
                    {
                        try
                        {
                            var depthText = window.Get<Label>(SearchCriteria.ByText("0.5")).Text;
                            if (depthText == "0.5")
                                return "0.5mm defined";
                        }
                        catch
                        {
                            ClickOnDepthMinus(5);
                            Thread.Sleep(200);
                            attempets++;
                        }
                    }
                    return "Attempts is over limit";
                default:
                    return "No depth[mm] as defined";
            }

        }
        public (double pw, double depth, double power) setParameters(string area, double PW, double depth, double power)   //Method sign for return 3 variables
        {

            if (Area[0] == area)
            {
                ForeheadIntensif.Click();
                ClickOnPWPluse(Convert.ToInt32(PW));
                var textPW = savePW.Text;  //Save PW 

                ClickOnDepthPluse(Convert.ToInt32(depth));
                var textDepth = saveDepth.Text;  //Save Depth 

                ClickOnPowerPluse(Convert.ToInt32(power));
                var textPower = savePower.Text;  //Save Power

                return (Convert.ToDouble(textPW), Convert.ToDouble(textDepth), Convert.ToDouble(textPower));

            }
            else if (Area[1] == area)
            {
                PeriorbitalIntensif.Click();
                ClickOnPWPluse(Convert.ToInt32(PW));
                var textPW = savePW.Text;  //Save PW 

                ClickOnDepthPluse(Convert.ToInt32(depth));
                var textDepth = saveDepth.Text;  //Save Depth 

                ClickOnPowerPluse(Convert.ToInt32(power));
                var textPower = savePower.Text;  //Save Power

                return (Convert.ToDouble(textPW), Convert.ToDouble(textDepth), Convert.ToDouble(textPower));
            }
            else if (Area[2] == area)
            {
                CheeksIntensif.Click();
                ClickOnPWPluse(Convert.ToInt32(PW));
                var textPW = savePW.Text;  //Save PW 

                ClickOnDepthPluse(Convert.ToInt32(depth));
                var textDepth = saveDepth.Text;  //Save Depth 

                ClickOnPowerPluse(Convert.ToInt32(power));
                var textPower = savePower.Text;  //Save Power

                return (Convert.ToDouble(textPW), Convert.ToDouble(textDepth), Convert.ToDouble(textPower));
            }
            else if (Area[3] == area)
            {
                NeckIntensif.Click();
                ClickOnPWPluse(Convert.ToInt32(PW));
                var textPW = savePW.Text;  //Save PW 

                ClickOnDepthPluse(Convert.ToInt32(depth));
                var textDepth = saveDepth.Text;  //Save Depth 

                ClickOnPowerPluse(Convert.ToInt32(power));
                var textPower = savePower.Text;  //Save Power

                return (Convert.ToDouble(textPW), Convert.ToDouble(textDepth), Convert.ToDouble(textPower));
            }
            else
                return (PW, depth, power);
        }


    }
}
