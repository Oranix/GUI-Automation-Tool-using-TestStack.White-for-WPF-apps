using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using static System.Net.Mime.MediaTypeNames;

namespace BlueBoxAutomation.PageObjects
{
    internal class SettingsMode : TestBase
    {
        public Label SystemInformation => window.Get<Label>(SearchCriteria.ByText("System Information"));
        public Label GuiVersionNumber => window.Get<Label>(SearchCriteria.ByText("01.05.13")/*.AndIndex(8)*/);
        public Label FWVersionNumber => window.Get<Label>(SearchCriteria.ByText("01.00.00")/*.AndIndex(13)*/);
        public Label FPGAVersionNumber => window.Get<Label>(SearchCriteria.ByText("")/*.AndIndex(17)*/);
        public Label NotConnectedFPGAVersionNumber => window.Get<Label>(SearchCriteria.ByText("")/*.AndIndex(17)*/);
        public Label SystemSerial => window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(27));
        public Label Password => window.Get<Label>(SearchCriteria.ByText("Password"));
        public Label CurrentPasswordTab => window.Get<Label>(SearchCriteria.ByText("CURRENT PASSWORD"));
        public Button one => window.Get<Button>(SearchCriteria.ByText("Button").AndIndex(2));  // 2 = 1digit
        public Button two => window.Get<Button>(SearchCriteria.ByText("Button").AndIndex(3));  //3 = 2digit
        public Button seven => window.Get<Button>(SearchCriteria.ByText("Button").AndIndex(9));  // 9 = 7digit
        public Button eight => window.Get<Button>(SearchCriteria.ByText("Button").AndIndex(10));  // 10 = 8digit
        public Label SavePassword => window.Get<Label>(SearchCriteria.ByText("SAVE PASSWORD"));
        public Label PasswordConfirmationMessage => window.Get<Label>(SearchCriteria.ByText("Password changed successfully!"));
        public Label InvalidSerialNumberMessage => window.Get<Label>(SearchCriteria.ByText("Invalid serial number!"));
        public Label SerialnumberupdatedMessage => window.Get<Label>(SearchCriteria.ByText("Serial number updated"));
        public Button okButton => window.Get<Button>(SearchCriteria.ByText("Button").AndIndex(0));   //Confirm change password request
        public Label SerialNumberMessage => window.Get<Label>(SearchCriteria.ByText("Serial number updated"));
        public Label CalibrationValueLabel => window.Get<Label>(SearchCriteria.ByText("CALIBRATION VALUE"));
        public Label SaveSNButton => window.Get<Label>(SearchCriteria.ByText("SAVE"));  // save button


        public void AllSystemInformationDisplay()
        {
            for (int i = 0; i < 100; i++)
                Console.WriteLine(i + " " + window.Get<Label>(SearchCriteria.ByClassName("TextBlock").AndIndex(i)));
            //0 WPFLabel.AutomationId:, Name:, ControlType: text, FrameworkId: WPF
            //1 WPFLabel.AutomationId:, Name: Українська, ControlType: text, FrameworkId: WPF
            //2 WPFLabel.AutomationId:, Name:, (Serial number message reviced) ControlType: text, FrameworkId: WPF
            //3 WPFLabel.AutomationId:, Name: CURRENT PASSWORD, ControlType:text, FrameworkId: WPF
            //4 WPFLabel.AutomationId:, Name: System Information, ControlType:text, FrameworkId: WPF
            //5 WPFLabel.AutomationId:, Name: English, ControlType: text, FrameworkId: WPF
            //6 WPFLabel.AutomationId:, Name: NEW PASSWORD, ControlType:text, FrameworkId: WPF
            //7 WPFLabel.AutomationId:, Name: SW Version:, ControlType: text, FrameworkId: WPF
            //8 WPFLabel.AutomationId:, Name: 01.05.12, ControlType: text, FrameworkId: WPF
            //9 WPFLabel.AutomationId:, Name: Adjust Volume, ControlType:text, FrameworkId: WPF
            //10 WPFLabel.AutomationId:, Name: 中文, ControlType: text, FrameworkId: WPF
            //11 WPFLabel.AutomationId:, Name: CONFIRM PASSWORD, ControlType:text, FrameworkId: WPF
            //12 WPFLabel.AutomationId:, Name: FW Version:, ControlType: text, FrameworkId: WPF
            //13 WPFLabel.AutomationId:, Name: 01.00.00, ControlType: text, FrameworkId: WPF
            //14 WPFLabel.AutomationId:, Name: 1, ControlType: text, FrameworkId: WPF
            //15 WPFLabel.AutomationId:, Name: العربية, ControlType: text, FrameworkId: WPF
            //16 WPFLabel.AutomationId:, Name: FPGA Version:, ControlType: text, FrameworkId: WPF
            //17 WPFLabel.AutomationId:, Name:, ControlType: text, FrameworkId: WPF
            //18 WPFLabel.AutomationId:, Name: Password, ControlType: text, FrameworkId: WPF
            //19 WPFLabel.AutomationId:, Name:, ControlType: text, FrameworkId: WPF
            //20 WPFLabel.AutomationId:, Name: RESET TO DEFAULT, ControlType: text, FrameworkId: WPF
            //21 WPFLabel.AutomationId:, Name: Board Revision:, ControlType: text, FrameworkId: WPF
            //22 WPFLabel.AutomationId:, Name: N / A, ControlType: text, FrameworkId: WPF
            //23 WPFLabel.AutomationId:, Name: Português, ControlType: text, FrameworkId: WPF
            //24 WPFLabel.AutomationId:, Name: VOLUME, ControlType: text, FrameworkId: WPF
            //25 WPFLabel.AutomationId:, Name: Upload Logs, ControlType:text, FrameworkId: WPF
            //26 WPFLabel.AutomationId:, Name: System S/ N:, ControlType: text, FrameworkId: WPF
            //27 WPFLabel.AutomationId:, Name: SM - 1234567899, ControlType: text, FrameworkId: WPF
            //28 WPFLabel.AutomationId:, Name: SAVE PASSWORD, ControlType:text, FrameworkId: WPF
            //29 WPFLabel.AutomationId:, Name: 10, ControlType: text, FrameworkId: WPF
            //30 WPFLabel.AutomationId:, Name: Русский, ControlType: text, FrameworkId: WPF
            //31 WPFLabel.AutomationId:, Name: Handpiece Version:, ControlType: text, FrameworkId: WPF
            //32 WPFLabel.AutomationId:, Name: N / A, ControlType: text, FrameworkId: WPF
            //33 WPFLabel.AutomationId:, Name: Media, ControlType: text, FrameworkId: WPF
            //34 WPFLabel.AutomationId:, Name: Français, ControlType: text, FrameworkId: WPF
            //35 WPFLabel.AutomationId:, Name: UPIC Version:, ControlType: text, FrameworkId: WPF
            //36 WPFLabel.AutomationId:, Name: N / A, ControlType: text, FrameworkId: WPF
            //37 WPFLabel.AutomationId:, Name: SYSTEM VOLUME, ControlType:text, FrameworkId: WPF
            //38 WPFLabel.AutomationId:, Name: SERIAL NUMBER, ControlType:text, FrameworkId: WPF
            //39 WPFLabel.AutomationId:, Name: SAVE, ControlType: text, FrameworkId: WPF
            //40 WPFLabel.AutomationId:, Name: Italiano, ControlType: text, FrameworkId: WPF
            //41 WPFLabel.AutomationId:, Name: Languages, ControlType: text, FrameworkId: WPF
            //42 WPFLabel.AutomationId:, Name: CALIBRATION VALUE, ControlType:text, FrameworkId: WPF
            //43 WPFLabel.AutomationId:, Name: SAVE, ControlType: text, FrameworkId: WPF
            //44 WPFLabel.AutomationId:, Name: Español, ControlType: text, FrameworkId: WPF

        }

        public bool GetToSettingsMode()
        {
            ClickOnScreen((int)ReturnBtn.Location.X, (int)ReturnBtn.Location.Y);
            Thread.Sleep(2000);

            if (SystemInformation != null)
                return true;
            return false;
        }

        public string GUIATMELVersionsCheck(string guiVersionNumber, string AtmelVersionNumner)
        {
            Console.WriteLine("GuiVersionNumber " + GuiVersionNumber.Text);
            Console.WriteLine("FWVersionNumber " + FWVersionNumber.Text);

            if (guiVersionNumber != GuiVersionNumber.Text || AtmelVersionNumner != FWVersionNumber.Text)
                return "GUI and Atmel are up to date";
            else return "GUI and Atmel are not up to date";

        }

        public string FPGAVersionCheck(bool communicationStatus, string FPGAVersion)
        {
            Console.WriteLine("FPGAVersionNumber " + FPGAVersionNumber.Text);

            if (communicationStatus != true)
            {
                return NotConnectedFPGAVersionNumber.Text;
            }
            if (FPGAVersionNumber.Text == FPGAVersion)
                return FPGAVersionNumber.Text;
            else return "Error reading FPGA version";
        }

        public int SystemSerialLength()
        {
            Console.WriteLine("SystemSerialNumber " + SystemSerial.Text);
            int serialCheckSum = 0;

            for (int i = 0; i < SystemSerial.Text.Length; i++)
                serialCheckSum++;

            return serialCheckSum;

        }

        public string SystemSerialFormat()
        {
            if (SystemSerial.Text.StartsWith("SM-"))
                return "Serial format starts with SM-";
            else
                return "Wrong format";
        }

        public string ChangeLoginPassword()
        {
            Password.Click();
            Thread.Sleep(500);
            ClickOnScreen((int)CurrentPasswordTab.Location.X + 20, (int)CurrentPasswordTab.Location.Y + 50);   //Current password tab location
            //var currentPasswordTab = window.Get(SearchCriteria.ByAutomationId("").AndIndex(10));   //Current password tab
            //currentPasswordTab.Click();         
            EnterDigits(one);

            ClickOnScreen((int)CurrentPasswordTab.Location.X + 20, (int)CurrentPasswordTab.Location.Y + 150);   //Current password tab location
            //var newPasswordTab = window.Get(SearchCriteria.ByAutomationId("").AndIndex(14));    //New password tab
            //newPasswordTab.Click();
            EnterDigits(two);

            //var confirmPasswordTab = window.Get(SearchCriteria.ByAutomationId("").AndIndex(24));   //Confirm password tab
            //confirmPasswordTab.Click();
            ClickOnScreen((int)CurrentPasswordTab.Location.X + 20, (int)CurrentPasswordTab.Location.Y + 250);   //Current password tab location
            EnterDigits(two);

            ClickOnScreen((int)SavePassword.Location.X + 50, (int)SavePassword.Location.Y + 50);   //Save password button
            okButton.Click();
            Thread.Sleep(1000);

            Console.WriteLine(PasswordConfirmationMessage.Text);
            if (PasswordConfirmationMessage.Text.Equals("Password changed successfully!"))
            {
                okButton.Click();
                return "Password changed successfully!";
            }
            else
                return "Password not changed";
        }

        public void EnterDigits(IUIItem digitButton)
        {
            for (int i = 0; i < 6; i++)
                digitButton.Click();
        }

        public void EnterSNAndCalPassword() //Enter 787878  
        {
            ClickOnScreen((int)CurrentPasswordTab.Location.X + 20, (int)CurrentPasswordTab.Location.Y + 50);   //Current password tab location
            for (int i = 0; i < 3; i++)
            {
                seven.Click();
                Thread.Sleep(300);
                eight.Click();
            }
        }

        public string SystemSerialNumberAndCalibrationMenu()
        {

            EnterSNAndCalPassword();
            ClickOnScreen((int)SaveSNButton.Location.X + 20, (int)SaveSNButton.Location.Y + 30);    //Press save button in serial number area
            if (InvalidSerialNumberMessage.Text.Equals("Invalid serial number!"))
            {
                okButton.Click();
                return "Serial & Cal. value menu are displayed";
            }
            else
                return "Error with the Serial & Cal. menu";
        }

        public string EnterSNnumber()
        {
            EnterSNAndCalPassword();
            ClickOnScreen((int)SaveSNButton.Location.X - 60, (int)SaveSNButton.Location.Y + 40);    //Press SN tab
            //var SNTab = window.Get(SearchCriteria.ByAutomationId("").AndIndex(33));   //Current password tab
            //SNTab.Click();
            System.Windows.MessageBoxResult scanner = System.Windows.MessageBox.Show(
                          "Please connect barcode sacnner and scan 10 digits system serial number.\nPress OK after the serial is enterd!",
                          "Connect Device", System.Windows.MessageBoxButton.OKCancel, System.Windows.MessageBoxImage.Information);
            ClickOnScreen((int)SaveSNButton.Location.X + 20, (int)SaveSNButton.Location.Y + 30);    //Press save button in serial number area
            if(SerialnumberupdatedMessage.Text.Equals("Serial number updated"))
            {
                okButton.Click();
                return "Error with entering serial number";
            }
            else
            {
                return "Serial number updated";
            }

        }
    }
}

