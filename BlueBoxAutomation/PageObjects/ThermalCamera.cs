using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;

namespace BlueBoxAutomation
{
    internal class ThermalCamera : Login
    {
        public Label ThermalCameraSwitch => window.Get<Label>(SearchCriteria.ByText("Thermal Camera"));
        public Label ThermalCameraFUSION => window.Get<Label>(SearchCriteria.ByText("FUSION"));
        public Label ThermalCameraRAINBOW => window.Get<Label>(SearchCriteria.ByText("RAINBOW"));
        public Label ThermalCameraGREYSCALE => window.Get<Label>(SearchCriteria.ByText("GREYSCALE"));
        public Label ThermalCameraHOTSwitch => window.Get<Label>(SearchCriteria.ByText("HOT"));
        public Label ThermalCameraAVERAGE => window.Get<Label>(SearchCriteria.ByText("AVERAGE"));
        public Label ThermalCameraPOINT => window.Get<Label>(SearchCriteria.ByText("POINT"));
        public Label thermalCameraCalibrationWarningMsg => window.Get<Label>(SearchCriteria.ByText("Warning"));
        public Label thermalCameraExitBtn => window.Get<Label>(SearchCriteria.ByText(""));

        public string ThermalCameraOnOff()
        {
            ThermalCameraSwitch.Click();    ////Open camera window


            Thread.Sleep(5000);
            try
            {
                ClickOnScreen((int)thermalCameraCalibrationWarningMsg.Location.X + 50, (int)thermalCameraCalibrationWarningMsg.Location.Y + 250); ////Confirm warning

                ThermalCameraFUSION.Click();
                Thread.Sleep(1000);
                ThermalCameraRAINBOW.Click();
                Thread.Sleep(1000);
                ThermalCameraGREYSCALE.Click();
                Thread.Sleep(1000);
                ThermalCameraHOTSwitch.Click();
                Console.WriteLine(ThermalCameraAVERAGE.Text);
                Console.WriteLine(ThermalCameraPOINT.Text);
                ClickOnScreen((int)thermalCameraExitBtn.Location.X, (int)thermalCameraExitBtn.Location.Y);         ////Close camera window


                return "Thermal camera NOT CALIBRATED but working";
            }
            catch
            {
                ThermalCameraFUSION.Click();
                Thread.Sleep(1000);
                ThermalCameraRAINBOW.Click();
                Thread.Sleep(1000);
                ThermalCameraGREYSCALE.Click();
                Thread.Sleep(1000);
                ThermalCameraHOTSwitch.Click();
                Console.WriteLine(ThermalCameraAVERAGE.Text);
                Console.WriteLine(ThermalCameraPOINT.Text);
                ClickOnScreen((int)thermalCameraExitBtn.Location.X, (int)thermalCameraExitBtn.Location.Y);          ////Close camera window

                return "Thermal camera CALIBRATED and working fine";
            }
        }
    }
}
