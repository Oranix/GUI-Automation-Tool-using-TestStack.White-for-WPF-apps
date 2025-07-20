using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace BlueBoxAutomation
{
    public class TreatmentArea : TestBase
    {
        public Label FaceLabel => window.Get<Label>(SearchCriteria.ByText("Face"));
        public Label BodyLabel => window.Get<Label>(SearchCriteria.ByText("Body"));
        public void faceArea()
        {
            try
            {
                FaceLabel.Click();
                Thread.Sleep(2500);
            }
            catch (Exception ex)
            {
                //ClickOnScreen(4457,257); ////Face tre.
                Console.WriteLine(ex.Message);
            }
        }
        public void bodyArea()
        {
            try
            {
                BodyLabel.Click();
                Thread.Sleep(2500);
            }
            catch (Exception ex)
            {
                //ClickOnScreen(4457,617); ////Face tre.
                Console.WriteLine(ex.Message);
            }
        }

        public string faceAreaSelectCheck()
        {
            try
            {
                Label iFineLabel = window.Get<Label>(SearchCriteria.ByText("iFineMax"));

                Label SmallLabel = window.Get<Label>(SearchCriteria.ByText("SmallMax"));

                Label MiniShaperLabel = window.Get<Label>(SearchCriteria.ByText("MiniShaperMax"));

                Label FSRLabel = window.Get<Label>(SearchCriteria.ByText("FSRMax"));

                Label IntensifLabel = window.Get<Label>(SearchCriteria.ByText("IntensifMax"));

                return "All 5 HP'S are in face treatment";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        public string bodyAreaSelectCheck()
        {
            try
            {
                Label shaperLabel = window.Get<Label>(SearchCriteria.ByText("ShaperMax"));

                Label Contourabel = window.Get<Label>(SearchCriteria.ByText("ContourMax"));

                Label MiniShaperLabel = window.Get<Label>(SearchCriteria.ByText("MiniShaperMax"));

                Label FSRLabel = window.Get<Label>(SearchCriteria.ByText("FSRMax"));

                Label IntensifLabel = window.Get<Label>(SearchCriteria.ByText("IntensifMax"));

                return "All 5 HP'S are in body treatment";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}
