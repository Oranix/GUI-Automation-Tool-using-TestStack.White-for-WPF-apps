using AutomationCore;
using BlueBoxAutomation.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestStack.White.UIA;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace BlueBoxAutomation
{
    public class TreatmentArea : TestBase
    {
        public Label FaceLabel => window.Get<Label>(SearchCriteria.ByText("Face"));
        public Label BodyLabel => window.Get<Label>(SearchCriteria.ByText("Body"));
        public Label IfineMaxBtn => window.Get<Label>(SearchCriteria.ByText("iFineMax"));  //To prove the face opening of the treatment area
        public Label ShaperBtn => window.Get<Label>(SearchCriteria.ByText("ShaperMax")); //To prove the body opening of the treatment area
        public Label SmallBtn => window.Get<Label>(SearchCriteria.ByText("SmallMax"));
        public Label FSRbtn => window.Get<Label>(SearchCriteria.ByText("FSRMax"));
        public Label Intensifbtn => window.Get<Label>(SearchCriteria.ByText("IntensifMax"));
        public Label ContourBtn => window.Get<Label>(SearchCriteria.ByText("ContourMax"));
        public Label MiniShaperBtn => window.Get<Label>(SearchCriteria.ByText("MiniShaperMax"));



        public void OpenFaceArea()
        {
            Thread.Sleep(1000);

            try
            {
                bool isfaceOpen = WaitUntil(() => FaceLabel.Visible && FaceLabel.Enabled, 5000, "Face area not open");
                if (!isfaceOpen)
                    Logger.Error("Face area not open");

                FaceLabel.Focus();
                Thread.Sleep(300);

                FaceLabel.Click();
                Thread.Sleep(500);

                //var point = FaceLabel.Bounds.Center();
                //Mouse.Click(point);

            }
            catch
            {
                Logger.Error("Face area not open");
            }
        }

        public bool CloseFaceArea()
        {
            try
            {
                bool isfaceClose = WaitUntil(() => FaceLabel.Visible && FaceLabel.Enabled, 5000, "Face area not close");
                if (!isfaceClose)
                    Logger.Error("Face area not closed");

                FaceLabel.Focus();
                Thread.Sleep(300);

                FaceLabel.Click();
                Thread.Sleep(500);

                return true;

                //var point = FaceLabel.Bounds.Center();
                //Mouse.Click(point);

            }
            catch
            {
                Logger.Error("Face area not closed");
            }

            return false;
        }

        public void OpenBodyArea()
        {
            Thread.Sleep(1000);

            try
            {
                bool isbodyOpen = WaitUntil(() => BodyLabel.Visible && BodyLabel.Enabled, 5000, "Body area not open");
                if (!isbodyOpen)
                    Logger.Error("Body area not open");

                BodyLabel.Focus();
                Thread.Sleep(300);

                BodyLabel.Click();
                Thread.Sleep(500);
                //var point = BodyLabel.Bounds.Center();
                //Mouse.Click(point);

            }
            catch (Exception ex)
            {
                //ClickOnScreen(4457,617); ////Body tre.
                Logger.Error(ex.Message);
            }
        }

        public bool CloseBodyArea()
        {
            try
            {
                bool isbodyClose = WaitUntil(() => BodyLabel.Visible && BodyLabel.Enabled, 5000, "Body area not open");
                if (!isbodyClose)
                    Logger.Error("Body area not closed");

                BodyLabel.Focus();
                Thread.Sleep(300);

                BodyLabel.Click();
                Thread.Sleep(500);

                return true;
                //var point = BodyLabel.Bounds.Center();
                //Mouse.Click(point);

            }
            catch
            {
                //ClickOnScreen(4457,617); ////Body tre.
                Logger.Error("Body area not closed");
            }

            return false;
        }

        // Find every button separtly - Because finding an element in faceAreaSelectCheck() does not guarantee that the same UI Automation element remains valid in bodyAreaSelectCheck().
        private bool isButtonsDisplayAndEnabled(Func<Label> buttonFinder)
        {
            try
            {
                Label button = buttonFinder();

                return button != null && button.Visible && button.Enabled;
            }
            catch
            {
                return false;
            }
        }

        private void AddMissingButton(List<string> missingButtons, string buttonName, Func<Label> buttonFinder)
        {
            if (!isButtonsDisplayAndEnabled(buttonFinder))
            {
                missingButtons.Add(buttonName);
            }
        }

        public string faceAreaSelectCheck()
        {

            bool checkVisibility = WaitUntil(() => isButtonsDisplayAndEnabled(() => IfineMaxBtn) && isButtonsDisplayAndEnabled(() => SmallBtn) && isButtonsDisplayAndEnabled(() => MiniShaperBtn) &&
            isButtonsDisplayAndEnabled(() => Intensifbtn) && isButtonsDisplayAndEnabled(() => FSRbtn), 10000, "face buttobs were not displayed");

            if (checkVisibility)
            {
                return "Face - All HP buttons displayed successfully";
            }

            List<string> missingButtons = new List<string>();

            AddMissingButton(missingButtons, "iFieMax", () => IfineMaxBtn);
            AddMissingButton(missingButtons, "SmallMax", () => SmallBtn);
            AddMissingButton(missingButtons, "MiniShaperMax", () => MiniShaperBtn);
            AddMissingButton(missingButtons, "IntensifMax", () => Intensifbtn);
            AddMissingButton(missingButtons, "FSRMax", () => FSRbtn);


            return $"Missing button: {string.Join(",", missingButtons)}";
        }

        private Label FindVisibleLabel(string text)
        {
            return window.GetMultiple(SearchCriteria.ByText(text)).OfType<Label>().FirstOrDefault(label => label.Visible);
        }

        //Body hp find (3 common hp)
        public Label BodyMiniShaperBtn => FindVisibleLabel("MiniShaperMax");
        public Label BodyIntensifBtn => FindVisibleLabel("IntensifMax");
        public Label BodyFSRBtn => FindVisibleLabel("FSRMax");

        public string bodyAreaSelectCheck()
        {

            bool checkVisibility = WaitUntil(() => isButtonsDisplayAndEnabled(() => ContourBtn) &&
            isButtonsDisplayAndEnabled(() => ShaperBtn) && isButtonsDisplayAndEnabled(() => BodyMiniShaperBtn) &&
            isButtonsDisplayAndEnabled(() => BodyIntensifBtn) && isButtonsDisplayAndEnabled(() => BodyFSRBtn), 10000, "Body buttos were not displayed");

            if (checkVisibility)
            {
                return "Body - All HP buttons displayed successfully";
            }


            List<string> missingButtons = new List<string>();

            AddMissingButton(missingButtons, "ContourMax", () => ContourBtn);
            AddMissingButton(missingButtons, "ShaperMax", () => ShaperBtn);
            AddMissingButton(missingButtons, "MiniShaperMax", () => BodyMiniShaperBtn);
            AddMissingButton(missingButtons, "IntensifMax", () => BodyIntensifBtn);
            AddMissingButton(missingButtons, "FSRMax", () => BodyFSRBtn);


            return $"Missing button: {string.Join(",", missingButtons)}";
        }

    }
}


