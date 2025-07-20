using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestStack.White.InputDevices;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems;
using TestStack.White.Utility;

namespace BlueBoxAutomation
{
    internal class CommunicationStatus : TestBase
    {
        public Label doneLabel = window.Get<Label>(SearchCriteria.ByAutomationId("MessageDataText"));
        public bool communicationStatus(bool value)
        {

            if (value)
            {
                var timeout = DateTime.Now.AddSeconds(20);
                while (DateTime.Now < timeout)
                {
                    try
                    {
                        if (doneLabel == null)
                            break; // Found the label, exit the loop
                    }
                    catch
                    {
                        // Ignore errors if the label is not found yet
                    }

                    Thread.Sleep(500); // Check every 500ms
                }
                if (DateTime.Now == timeout)
                {
                    throw new Exception("Timeout waiting for 'Done' message.");
                }
            }
            else
            {
                Thread.Sleep(3000);
                //ClickOnScreen(7206, 953);   ////Lost comminication OK button

                Button communicationOkBtn = window.Get<Button>(SearchCriteria.ByAutomationId("OKButton"));
                communicationOkBtn.Click();

                //Calculate the new mouse location relative to the window
                //System.Windows.Point newLocation = new System.Windows.Point(WindowBounds.X + 7206, WindowBounds.Y + 953);

                //// Move the mouse and perform the click
                //Mouse.Instance.Location = newLocation;
                //Console.WriteLine(Mouse.Instance.Location);
                //Mouse.Instance.Click();
                //Thread.Sleep(2000); // Optional delay to stabilize UI interaction
            }

            return value;
        }

    }
}
