using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestStack.White.InputDevices;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems;

namespace BlueBoxAutomation
{
    public class Login : TestBase
    {
        public Button loginPasswordDigits => window.Get<Button>(SearchCriteria.ByAutomationId("").AndIndex(0));  //// Index 0 gives the password 111111
        public void LoginToMainMenu()
        {
             
            for (int a = 0; a < 6; a++)
            {
                loginPasswordDigits.Click();
                Thread.Sleep(750);
            }
            Button LoginButton = window.Get<Button>(SearchCriteria.ByAutomationId("LoginOKButton"));
            LoginButton.Click();
            Thread.Sleep(2000);
        }
        public bool checkLoginOk()
        {
            try
            {
                Label areaLabel = window.Get<Label>(SearchCriteria.ByText("Face"));
                return true;    
            }
            catch 
            {
                return false;     
            }
        }
   
    }
}
