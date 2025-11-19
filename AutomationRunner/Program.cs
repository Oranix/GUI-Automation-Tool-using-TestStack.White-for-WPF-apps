using System;
using System.Runtime.InteropServices;
using System.Threading;
using AutomationCore;
using BlueBoxAutomation;

//CODE SUORCE D:\automation\exeAutomation\AutomationRunner\bin\Debug

namespace AutomationRunner
{
    internal class Program
    {
        static void RunTest(string name, Action action)
        {
            try
            {
                Logger.Info($"Running test: {name}");
                action();
                Logger.TestResult(name, true);
            }
            catch (Exception ex)
            {
                Logger.TestResult(name, false, ex.Message);
            }
        }

        [STAThread]
        static void Main()
        {
            try
            {
                Console.WriteLine("Starting Automation Runner...");

                TestBase.SetUpForRunner();  // Open Automation app
                Console.WriteLine("Application launched successfully.");

                PROMAXGUI proMaxTest = new PROMAXGUI();

                RunTest("TC_01_CommunicationTest", proMaxTest.TC_01_CommunicationTest);
                Thread.Sleep(5000);
                RunTest("TC_02_Login", proMaxTest.TC_02_Login);
                RunTest("TC_03_SelectArea", proMaxTest.TC_03_SelectArea);
                //RunTest("TC_04_iFineMaxDefault", proMaxTest.TC_04_iFineMaxDefault); //PASS
                //RunTest("TC_05_SmallMaxDefault", proMaxTest.TC_05_SmallMaxDefault);  //PASS
                //RunTest("TC_06_MiniShaperMaxFaceDefault", proMaxTest.TC_06_MiniShaperMaxFaceDefault); //PASS
                //RunTest("TC_07_MiniShaperMaxBodyDefault", proMaxTest.TC_07_MiniShaperMaxBodyDefault); //PASS
                //RunTest("TC_08_ShaperMaxDefault", proMaxTest.TC_08_ShaperMaxDefault); //PASS
                //RunTest("TC_09_ContourMaxDefault", proMaxTest.TC_09_ContourMaxDefault); //PASS
                RunTest("TC_10_IntensifMaxFaceDefault", proMaxTest.TC_10_IntensifMaxFaceDefault);
                RunTest("TC_11_IntensifMaxBodyDefault", proMaxTest.TC_11_IntensifMaxBodyDefault);
                RunTest("TC_12_FSRMaxFaceDefault", proMaxTest.TC_12_FSRMaxFaceDefault);
                RunTest("TC_13_FSRMaxBodyDefault", proMaxTest.TC_13_FSRMaxBodyDefault);
                //RunTest("TC_14_iFineMaxReady", proMaxTest.TC_14_iFineMaxReady);
                //RunTest("TC_15_SmallMaxReady", proMaxTest.TC_15_SmallMaxReady);
                //RunTest("TC_15_SmallMaxReady", proMaxTest.TC_16_MiniShaperMaxFaceReady);
                //RunTest("TC_17_MiniShaperMaxBodyReady", proMaxTest.TC_17_MiniShaperMaxBodyReady);
                //RunTest("TC_18_ShaperMaxReady", proMaxTest.TC_18_ShaperMaxReady);
                //RunTest("TC_19_ContourMaxReady", proMaxTest.TC_19_ContourMaxReady);
                //RunTest("TC_20_IntneisfMaxFaceReady", proMaxTest.TC_20_IntneisfMaxFaceReady);
                //RunTest("TC_21_IntneisfMaxBodyReady", proMaxTest.TC_21_IntneisfMaxBodyReady);







            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                TestBase.TearDown();
                Console.WriteLine("Application closed.");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }


    }
}
