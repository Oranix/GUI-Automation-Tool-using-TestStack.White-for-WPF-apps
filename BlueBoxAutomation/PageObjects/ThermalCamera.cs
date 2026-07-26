using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WPFUIItems;

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

        public string ThermalCameraEnable()
        {
            ThermalCameraSwitch.Click();    ////Open camera window
            bool isCameraOpen = WaitUntil(() => ThermalCameraFUSION != null, 5000, "Cmera window is not open");
            Thread.Sleep(5000);
            if (!isCameraOpen)
                return "Thermal camera window box can't open";
            return "Thermal camera window box is displayed";
        }

        public string ChangeCameraMode(string mode)
        {
            switch (mode)
            {
                case "FUSION":

                    if (ThermalCameraFUSION.Visible && ThermalCameraFUSION.Enabled)
                    {
                        ThermalCameraFUSION.Click();
                        WaitForTransition();

                        return "FUSION Mode active";
                    }
                    return "FUSION camera type not display / Press";

                case "GREYSCALE":

                    if (ThermalCameraGREYSCALE.Visible && ThermalCameraGREYSCALE.Enabled)
                    {
                        ThermalCameraGREYSCALE.Click();
                        WaitForTransition();

                        return "GREYSCALE Mode active";
                    }
                    return "GREYSCALE camera type not display / Press";


                case "RAINBOW":
                    if (ThermalCameraRAINBOW.Visible && ThermalCameraRAINBOW.Enabled)
                    {
                        ThermalCameraRAINBOW.Click();
                        WaitForTransition();

                        return "RAINBOW Mode active";
                    }
                    return "RAINBOW camera type not display / Press";

            }
            return "Can't select any mode";

        }

        public string ThermalCameraDisable()
        {
            ClickOnScreen((int)ThermalCameraSwitch.Location.X + 10, (int)(ThermalCameraSwitch.Location.Y + 50));

            bool isCameraClosed = WaitUntil(ThermalCameraClose, 5000, "The camera window did not close properly");


            return isCameraClosed ? "Thermal camera window is closed" : "Thermal camera window is still displayed";

        }

        public bool ThermalCameraClose()
        {
            try
            {
                return !ThermalCameraFUSION.Visible;
            }
            catch (Exception ex)
            {
                //The element is no longer in the UI tree.
                return true;
            }

        }
    }




}
