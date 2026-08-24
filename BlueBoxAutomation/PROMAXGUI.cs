using BlueBoxAutomation.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Documents;

//CODE SUORCE D:\Autmation_ALL
//Main automation source for testing PROMAX.
//Include all regreisions up to SW V01.06.05.28.00.00


namespace BlueBoxAutomation
{
    [TestClass]
    public class PROMAXGUI : TestBase
    {
        public bool commStatus = true;

        [TestMethod]
        public void TC_01_CommunicationTest()
        {
            CommunicationStatus status = new CommunicationStatus();
            status.communicationStatus(commStatus);    ////false - No communication, true - communication ok
            Assert.IsNotNull(status);
        }

        [TestMethod]
        public void TC_02_Login()
        {
            Login log = new Login();
            log.LoginToMainMenu();
            Assert.IsTrue(log.checkLoginOk(), "Login failed");
        }

        [TestMethod]
        public void TC_03_SelectArea()
        {
            TreatmentArea treatmentArea = new TreatmentArea();

            treatmentArea.OpenFaceArea();
            Assert.AreEqual("Face - All HP buttons displayed successfully", treatmentArea.faceAreaSelectCheck());
            Assert.IsTrue(treatmentArea.CloseFaceArea(), "Face - Label not close");
          
            treatmentArea.OpenBodyArea();
            Assert.AreEqual("Body - All HP buttons displayed successfully", treatmentArea.bodyAreaSelectCheck());
            Assert.IsTrue(treatmentArea.CloseBodyArea(), "Body - Label not close");      
        }

        [TestMethod]
        public void TC_04_iFineMaxDefault()
        {
            string[] areas = { "Periorbital", "Perioral" };
            string[] defaultPasses = { "10", "10" };
            string[] defaultsPower = { "3", "3" };
            string[] defaultIntervalTime = { "30", "30" };

            TreatmentArea treatmentArea = new TreatmentArea();
            treatmentArea.OpenFaceArea();

            iFineMaxDefaultPage iFineMaxPage = new iFineMaxDefaultPage(areas, defaultPasses, defaultsPower, defaultIntervalTime);

            iFineMaxPage.IFineMAX();
            Assert.AreEqual(iFineMaxPage.CheckiFineEntered(), "Face iFineMax is enterd");
            Assert.AreEqual(iFineMaxPage.PeriorbitalDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.AreEqual(iFineMaxPage.PerioralDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.IsTrue(iFineMaxPage.LedOffCheck(), "LED is not OFF!");
            Assert.AreEqual(iFineMaxPage.PassesControledByUser_Pluse(areas[0]), "Passes max value 15");
            Assert.AreEqual(iFineMaxPage.PassesControledByUser_Minus(), "Passes min value 0");
            Assert.AreEqual(iFineMaxPage.PowerControledByUser_Pluse(), "Power max Value 6");
            Assert.AreEqual(iFineMaxPage.PowerControledByUser_Minus(), "Power min Value 1");
            Assert.AreEqual(iFineMaxPage.PassesControledByUser_Pluse(areas[1]), "Passes max value 15");
            Assert.AreEqual(iFineMaxPage.PassesControledByUser_Minus(), "Passes min value 0");
            Assert.AreEqual(iFineMaxPage.PowerControledByUser_Pluse(), "Power max Value 6");
            Assert.AreEqual(iFineMaxPage.PowerControledByUser_Minus(), "Power min Value 1");

            //ThermalCamera camera = new ThermalCamera();
            //Assert.AreEqual(camera.ThermalCameraEnable(), "Thermal camera window box is displayed");
            //Assert.AreEqual(camera.ChangeCameraMode("FUSION"), "FUSION Mode active");
            //Assert.AreEqual(camera.ChangeCameraMode("GREYSCALE"), "GREYSCALE Mode active");
            //Assert.AreEqual(camera.ChangeCameraMode("RAINBOW"), "RAINBOW Mode active");
            //Assert.AreEqual(camera.ThermalCameraDisable(), "Thermal camera window is closed");
            Assert.AreEqual(ReturntoMain(), "Main menu location");
        }

        [TestMethod]
        public void TC_05_SmallMaxDefault()
        {
            string[] areas = { "Cheeks", "Neck", "Submental", "Decolletage" };
            string[] defaultPasses = { "10", "10", "10", "10" };
            string[] defaultsPower = { "40", "35", "40", "40" };
            string[] defaultIntervalTime = { "30", "30", "30", "30" };

            TreatmentArea treatmentArea = new TreatmentArea();
            treatmentArea.OpenFaceArea();

            SmallMaxDefaultPage smallMaxDefaultPage = new SmallMaxDefaultPage(areas, defaultPasses, defaultsPower, defaultIntervalTime);

            smallMaxDefaultPage.SmallMaxPage();
            Assert.AreEqual(smallMaxDefaultPage.CheckSmallEntered(), "Face SmallMax is enterd");
            Assert.AreEqual(smallMaxDefaultPage.CheeksDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.AreEqual(smallMaxDefaultPage.NeckDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.AreEqual(smallMaxDefaultPage.SubmentalDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.AreEqual(smallMaxDefaultPage.DecolletageDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.AreEqual(smallMaxDefaultPage.PassesControledByUser_Pluse(areas[0]), "Passes max value 15");
            Assert.AreEqual(smallMaxDefaultPage.PassesControledByUser_Minus(), "Passes min value 0");
            Assert.AreEqual(smallMaxDefaultPage.PowerControledByUser_Pluse(), "Power max value 60");
            Assert.AreEqual(smallMaxDefaultPage.PowerControledByUser_Minus(), "Power min value 20");
            Assert.AreEqual(smallMaxDefaultPage.PassesControledByUser_Pluse(areas[1]), "Passes max value 15");
            Assert.AreEqual(smallMaxDefaultPage.PassesControledByUser_Minus(), "Passes min value 0");
            Assert.AreEqual(smallMaxDefaultPage.PowerControledByUser_Pluse(), "Power max value 60");
            Assert.AreEqual(smallMaxDefaultPage.PowerControledByUser_Minus(), "Power min value 20");
            Assert.AreEqual(smallMaxDefaultPage.PassesControledByUser_Pluse(areas[2]), "Passes max value 15");
            Assert.AreEqual(smallMaxDefaultPage.PassesControledByUser_Minus(), "Passes min value 0");
            Assert.AreEqual(smallMaxDefaultPage.PowerControledByUser_Pluse(), "Power max value 60");
            Assert.AreEqual(smallMaxDefaultPage.PowerControledByUser_Minus(), "Power min value 20");
            Assert.AreEqual(smallMaxDefaultPage.PassesControledByUser_Pluse(areas[3]), "Passes max value 15");
            Assert.AreEqual(smallMaxDefaultPage.PassesControledByUser_Minus(), "Passes min value 0");
            Assert.AreEqual(smallMaxDefaultPage.PowerControledByUser_Pluse(), "Power max value 60");
            Assert.AreEqual(smallMaxDefaultPage.PowerControledByUser_Minus(), "Power min value 20");

            ThermalCamera camera = new ThermalCamera();
            Assert.AreEqual(camera.ThermalCameraEnable(), "Thermal camera window box is displayed");
            Assert.AreEqual(camera.ChangeCameraMode("FUSION"), "FUSION Mode active");
            Assert.AreEqual(camera.ChangeCameraMode("GREYSCALE"), "GREYSCALE Mode active");
            Assert.AreEqual(camera.ChangeCameraMode("RAINBOW"), "RAINBOW Mode active");
            Assert.AreEqual(camera.ThermalCameraDisable(), "Thermal camera window box is closed");

            Assert.AreEqual(ReturntoMain(), "Main menu location");
        }

        [TestMethod]
        public void TC_06_MiniShaperMaxFaceDefault()
        {
            string[] areas = { "Cheeks", "Jawline", "Submental" };
            string[] defaultPasses = { "9", "10", "10" };
            string[] defaultsPower = { "35", "25", "20" };
            string[] defaultIntervalTime = { "30", "30", "30" };

            TreatmentArea treatmentArea = new TreatmentArea();
            treatmentArea.OpenFaceArea();

            MiniShaperMaxFaceDefaultPage miniShaperMaxFaceDefaultPage = new MiniShaperMaxFaceDefaultPage(areas, defaultPasses, defaultsPower, defaultIntervalTime);

            miniShaperMaxFaceDefaultPage.MiniShaperMaxPage();
            Assert.AreEqual(miniShaperMaxFaceDefaultPage.CheckMiniShaperFaceEntered(), "Face MiniShaperMax page is enterd properly");
            Assert.AreEqual(miniShaperMaxFaceDefaultPage.CheeksDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.AreEqual(miniShaperMaxFaceDefaultPage.JawlineDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.AreEqual(miniShaperMaxFaceDefaultPage.SubmentalDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.AreEqual(miniShaperMaxFaceDefaultPage.PassesControledByUser_Pluse(areas[0]), "Passes max value 15");
            Assert.AreEqual(miniShaperMaxFaceDefaultPage.PassesControledByUser_Minus(), "Passes min value 0");
            Assert.AreEqual(miniShaperMaxFaceDefaultPage.PowerControledByUser_Pluse(), "Power max Value 70");
            Assert.AreEqual(miniShaperMaxFaceDefaultPage.PowerControledByUser_Minus(), "Power min Value 20");
            Assert.AreEqual(miniShaperMaxFaceDefaultPage.PassesControledByUser_Pluse(areas[1]), "Passes max value 15");
            Assert.AreEqual(miniShaperMaxFaceDefaultPage.PassesControledByUser_Minus(), "Passes min value 0");
            Assert.AreEqual(miniShaperMaxFaceDefaultPage.PowerControledByUser_Pluse(), "Power max Value 70");
            Assert.AreEqual(miniShaperMaxFaceDefaultPage.PowerControledByUser_Minus(), "Power min Value 20");
            Assert.AreEqual(miniShaperMaxFaceDefaultPage.PassesControledByUser_Pluse(areas[2]), "Passes max value 15");
            Assert.AreEqual(miniShaperMaxFaceDefaultPage.PassesControledByUser_Minus(), "Passes min value 0");
            Assert.AreEqual(miniShaperMaxFaceDefaultPage.PowerControledByUser_Pluse(), "Power max Value 70");
            Assert.AreEqual(miniShaperMaxFaceDefaultPage.PowerControledByUser_Minus(), "Power min Value 20");

            ThermalCamera camera = new ThermalCamera();
            Assert.AreEqual(camera.ThermalCameraEnable(), "Thermal camera window box is displayed");
            Assert.AreEqual(camera.ChangeCameraMode("FUSION"), "FUSION Mode active");
            Assert.AreEqual(camera.ChangeCameraMode("GREYSCALE"), "GREYSCALE Mode active");
            Assert.AreEqual(camera.ChangeCameraMode("RAINBOW"), "RAINBOW Mode active");
            Assert.AreEqual(camera.ThermalCameraDisable(), "Thermal camera window box is closed");
            Assert.AreEqual(ReturntoMain(), "Main menu location");
        }

        [TestMethod]
        public void TC_07_MiniShaperMaxBodyDefault()
        {
            string[] areas = { "Decolletage", "Arms", "Knees" };
            string[] defaultPasses = { "10", "13", "13" };
            string[] defaultsPower = { "40", "30", "35" };
            string[] defaultIntervalTime = { "30", "30", "30" };

            TreatmentArea treatmentArea = new TreatmentArea();
            treatmentArea.OpenBodyArea();
            MiniShaperMaxBodyDefaultPage miniShaperMaxBodyDefaultPage = new MiniShaperMaxBodyDefaultPage(areas, defaultPasses, defaultsPower, defaultIntervalTime);
            miniShaperMaxBodyDefaultPage.MiniShaperBodyMaxPage();
            Assert.AreEqual(miniShaperMaxBodyDefaultPage.CheckMiniShaperBodyEntered(), "Body MiniShaperMax page is enterd properly");
            Assert.AreEqual(miniShaperMaxBodyDefaultPage.DecolletageDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.AreEqual(miniShaperMaxBodyDefaultPage.ArmsDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.AreEqual(miniShaperMaxBodyDefaultPage.KneesDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.AreEqual(miniShaperMaxBodyDefaultPage.PassesControledByUser_Pluse(areas[0]), "Passes max value 15");
            Assert.AreEqual(miniShaperMaxBodyDefaultPage.PassesControledByUser_Minus(), "Passes min value 0");
            Assert.AreEqual(miniShaperMaxBodyDefaultPage.PowerControledByUser_Pluse(), "Power max Value 70");
            Assert.AreEqual(miniShaperMaxBodyDefaultPage.PowerControledByUser_Minus(), "Power min Value 20");
            Assert.AreEqual(miniShaperMaxBodyDefaultPage.PassesControledByUser_Pluse(areas[1]), "Passes max value 15");
            Assert.AreEqual(miniShaperMaxBodyDefaultPage.PassesControledByUser_Minus(), "Passes min value 0");
            Assert.AreEqual(miniShaperMaxBodyDefaultPage.PowerControledByUser_Pluse(), "Power max Value 70");
            Assert.AreEqual(miniShaperMaxBodyDefaultPage.PowerControledByUser_Minus(), "Power min Value 20");
            Assert.AreEqual(miniShaperMaxBodyDefaultPage.PassesControledByUser_Pluse(areas[2]), "Passes max value 15");
            Assert.AreEqual(miniShaperMaxBodyDefaultPage.PassesControledByUser_Minus(), "Passes min value 0");
            Assert.AreEqual(miniShaperMaxBodyDefaultPage.PowerControledByUser_Pluse(), "Power max Value 70");
            Assert.AreEqual(miniShaperMaxBodyDefaultPage.PowerControledByUser_Minus(), "Power min Value 20");

            ThermalCamera camera = new ThermalCamera();
            Assert.AreEqual(camera.ThermalCameraEnable(), "Thermal camera window box is displayed");
            Assert.AreEqual(camera.ChangeCameraMode("FUSION"), "FUSION Mode active");
            Assert.AreEqual(camera.ChangeCameraMode("GREYSCALE"), "GREYSCALE Mode active");
            Assert.AreEqual(camera.ChangeCameraMode("RAINBOW"), "RAINBOW Mode active");
            Assert.AreEqual(camera.ThermalCameraDisable(), "Thermal camera window box is closed");
            Assert.AreEqual(ReturntoMain(), "Main menu location");
        }

        [TestMethod]
        public void TC_08_ShaperMaxDefault()
        {
            string[] areas = { "Flanks", "Arms", "Abdomen", "Buttocks", "Thighs", "Knees", "Back" };
            string[] defaultPasses = { "10", "10", "10", "10", "10", "10", "10" };
            string[] defaultsPower = { "55", "45", "60", "70", "70", "45", "60" };
            string[] defaultIntervalTime = { "30", "30", "30", "30", "30", "30", "30" };

            TreatmentArea treatmentArea = new TreatmentArea();
            treatmentArea.OpenBodyArea();
            ShaperMaxDefaultPage shaperMaxDefaultPage = new ShaperMaxDefaultPage(areas, defaultPasses, defaultsPower, defaultIntervalTime);
            shaperMaxDefaultPage.ShaperMaxPage();
            Assert.AreEqual(shaperMaxDefaultPage.CheckShaperEntered(), "ShaperMax page is enterd properly");
            Assert.AreEqual(shaperMaxDefaultPage.FlanksDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.AreEqual(shaperMaxDefaultPage.ArmsDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.AreEqual(shaperMaxDefaultPage.AbdomenDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.AreEqual(shaperMaxDefaultPage.ButtocksDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.AreEqual(shaperMaxDefaultPage.ThighsDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.AreEqual(shaperMaxDefaultPage.KneesDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.AreEqual(shaperMaxDefaultPage.BackDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.AreEqual(shaperMaxDefaultPage.PassesControledByUser_Pluse(areas[0]), "Passes max value 15");
            Assert.AreEqual(shaperMaxDefaultPage.PassesControledByUser_Minus(), "Passes min value 0");
            Assert.AreEqual(shaperMaxDefaultPage.PowerControledByUser_Pluse(), "Power max Value 100");
            Assert.AreEqual(shaperMaxDefaultPage.PowerControledByUser_Minus(), "Power min Value 45");
            Assert.AreEqual(shaperMaxDefaultPage.PassesControledByUser_Pluse(areas[1]), "Passes max value 15");
            Assert.AreEqual(shaperMaxDefaultPage.PassesControledByUser_Minus(), "Passes min value 0");
            Assert.AreEqual(shaperMaxDefaultPage.PowerControledByUser_Pluse(), "Power max Value 100");
            Assert.AreEqual(shaperMaxDefaultPage.PowerControledByUser_Minus(), "Power min Value 45");
            Assert.AreEqual(shaperMaxDefaultPage.PassesControledByUser_Pluse(areas[2]), "Passes max value 15");
            Assert.AreEqual(shaperMaxDefaultPage.PassesControledByUser_Minus(), "Passes min value 0");
            Assert.AreEqual(shaperMaxDefaultPage.PowerControledByUser_Pluse(), "Power max Value 100");
            Assert.AreEqual(shaperMaxDefaultPage.PowerControledByUser_Minus(), "Power min Value 45");
            Assert.AreEqual(shaperMaxDefaultPage.PassesControledByUser_Pluse(areas[3]), "Passes max value 15");
            Assert.AreEqual(shaperMaxDefaultPage.PassesControledByUser_Minus(), "Passes min value 0");
            Assert.AreEqual(shaperMaxDefaultPage.PowerControledByUser_Pluse(), "Power max Value 100");
            Assert.AreEqual(shaperMaxDefaultPage.PowerControledByUser_Minus(), "Power min Value 45");
            Assert.AreEqual(shaperMaxDefaultPage.PassesControledByUser_Pluse(areas[4]), "Passes max value 15");
            Assert.AreEqual(shaperMaxDefaultPage.PassesControledByUser_Minus(), "Passes min value 0");
            Assert.AreEqual(shaperMaxDefaultPage.PowerControledByUser_Pluse(), "Power max Value 100");
            Assert.AreEqual(shaperMaxDefaultPage.PowerControledByUser_Minus(), "Power min Value 45");
            Assert.AreEqual(shaperMaxDefaultPage.PassesControledByUser_Pluse(areas[5]), "Passes max value 15");
            Assert.AreEqual(shaperMaxDefaultPage.PassesControledByUser_Minus(), "Passes min value 0");
            Assert.AreEqual(shaperMaxDefaultPage.PowerControledByUser_Pluse(), "Power max Value 100");
            Assert.AreEqual(shaperMaxDefaultPage.PowerControledByUser_Minus(), "Power min Value 45");
            Assert.AreEqual(shaperMaxDefaultPage.PassesControledByUser_Pluse(areas[6]), "Passes max value 15");
            Assert.AreEqual(shaperMaxDefaultPage.PassesControledByUser_Minus(), "Passes min value 0");
            Assert.AreEqual(shaperMaxDefaultPage.PowerControledByUser_Pluse(), "Power max Value 100");
            Assert.AreEqual(shaperMaxDefaultPage.PowerControledByUser_Minus(), "Power min Value 45");

            ThermalCamera camera = new ThermalCamera();
            Assert.AreEqual(camera.ThermalCameraEnable(), "Thermal camera window box is displayed");
            Assert.AreEqual(camera.ChangeCameraMode("FUSION"), "FUSION Mode active");
            Assert.AreEqual(camera.ChangeCameraMode("GREYSCALE"), "GREYSCALE Mode active");
            Assert.AreEqual(camera.ChangeCameraMode("RAINBOW"), "RAINBOW Mode active");
            Assert.AreEqual(camera.ThermalCameraDisable(), "Thermal camera window box is closed");
            Assert.AreEqual(ReturntoMain(), "Main menu location");
        }

        [TestMethod]
        public void TC_09_ContourMaxDefault()
        {
            string[] areas = { "Flanks", "Abdomen", "Back", "Buttocks", "Thighs" };
            string[] defaultPasses = { "10", "10", "10", "10", "10" };
            string[] defaultsPower = { "65", "70", "60", "70", "70" };
            string[] defaultIntervalTime = { "30", "30", "30", "30", "30" };

            TreatmentArea treatmentArea = new TreatmentArea();
            treatmentArea.OpenBodyArea();
            ContourMaxDefaultPage contourMaxDefaultPage = new ContourMaxDefaultPage(areas, defaultPasses, defaultsPower, defaultIntervalTime);
            contourMaxDefaultPage.ContourMaxPage();
            Assert.AreEqual(contourMaxDefaultPage.CheckContourEntered(), "Contour page is enterd properly");
            Assert.AreEqual(contourMaxDefaultPage.FlanksDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.AreEqual(contourMaxDefaultPage.AbdomenDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.AreEqual(contourMaxDefaultPage.BackDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.AreEqual(contourMaxDefaultPage.ButtocksDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.AreEqual(contourMaxDefaultPage.ThighsDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.AreEqual(contourMaxDefaultPage.PassesControledByUser_Pluse(areas[0]), "Passes max value 15");
            Assert.AreEqual(contourMaxDefaultPage.PassesControledByUser_Minus(), "Passes min value 0");
            Assert.AreEqual(contourMaxDefaultPage.PowerControledByUser_Pluse(), "Power max Value 100");
            Assert.AreEqual(contourMaxDefaultPage.PowerControledByUser_Minus(), "Power min Value 50");
            Assert.AreEqual(contourMaxDefaultPage.PassesControledByUser_Pluse(areas[1]), "Passes max value 15");
            Assert.AreEqual(contourMaxDefaultPage.PassesControledByUser_Minus(), "Passes min value 0");
            Assert.AreEqual(contourMaxDefaultPage.PowerControledByUser_Pluse(), "Power max Value 100");
            Assert.AreEqual(contourMaxDefaultPage.PowerControledByUser_Minus(), "Power min Value 50");
            Assert.AreEqual(contourMaxDefaultPage.PassesControledByUser_Pluse(areas[2]), "Passes max value 15");
            Assert.AreEqual(contourMaxDefaultPage.PassesControledByUser_Minus(), "Passes min value 0");
            Assert.AreEqual(contourMaxDefaultPage.PowerControledByUser_Pluse(), "Power max Value 100");
            Assert.AreEqual(contourMaxDefaultPage.PowerControledByUser_Minus(), "Power min Value 50");
            Assert.AreEqual(contourMaxDefaultPage.PassesControledByUser_Pluse(areas[3]), "Passes max value 15");
            Assert.AreEqual(contourMaxDefaultPage.PassesControledByUser_Minus(), "Passes min value 0");
            Assert.AreEqual(contourMaxDefaultPage.PowerControledByUser_Pluse(), "Power max Value 100");
            Assert.AreEqual(contourMaxDefaultPage.PowerControledByUser_Minus(), "Power min Value 50");
            Assert.AreEqual(contourMaxDefaultPage.PassesControledByUser_Pluse(areas[4]), "Passes max value 15");
            Assert.AreEqual(contourMaxDefaultPage.PassesControledByUser_Minus(), "Passes min value 0");
            Assert.AreEqual(contourMaxDefaultPage.PowerControledByUser_Pluse(), "Power max Value 100");
            Assert.AreEqual(contourMaxDefaultPage.PowerControledByUser_Minus(), "Power min Value 50");
            ThermalCamera camera = new ThermalCamera();
            Assert.AreEqual(camera.ThermalCameraEnable(), "Thermal camera window box is displayed");
            Assert.AreEqual(camera.ChangeCameraMode("FUSION"), "FUSION Mode active");
            Assert.AreEqual(camera.ChangeCameraMode("GREYSCALE"), "GREYSCALE Mode active");
            Assert.AreEqual(camera.ChangeCameraMode("RAINBOW"), "RAINBOW Mode active");
            Assert.AreEqual(camera.ThermalCameraDisable(), "Thermal camera window box is closed");
            Assert.AreEqual(ReturntoMain(), "Main menu location");
        }

        [TestMethod]
        public void TC_10_IntensifMaxFaceDefault()
        {
            TreatmentArea treatmentArea = new TreatmentArea();
            treatmentArea.OpenFaceArea();
            string[] areas = { "Forehead", "Periorbital", "Cheeks", "Neck" };
            string[] defaultsPW = { "80", "80", "110", "80" };
            string[] defaultsDepth = { "1.5", "1.5", "2.5", "1.8" };
            string[] defaultsPower = { "10", "10", "14", "12" };

            IntensifMaxFaceDefaultPage intensifMaxFacePage = new IntensifMaxFaceDefaultPage(areas, defaultsPW, defaultsDepth, defaultsPower);
            intensifMaxFacePage.IntneisfMAXPage();
            Assert.AreEqual(intensifMaxFacePage.CheckIntneisfFaceEntered(), "Face IntensifMax");
            Assert.AreEqual(intensifMaxFacePage.ForeheadDefaultPWDepthPower(), "Defaults are OK!");
            Assert.AreEqual(intensifMaxFacePage.PeriorbitalDefaultPWDepthPower(), "Defaults are OK!");
            Assert.AreEqual(intensifMaxFacePage.CheeksDefaultPWDepthPower(), "Defaults are OK!");
            Assert.AreEqual(intensifMaxFacePage.NeckDefaultPWDepthPower(), "Defaults are OK!");

            Assert.AreEqual(intensifMaxFacePage.PWControledByUser_Pluse(areas[0]), "PW max value 500");
            Assert.AreEqual(intensifMaxFacePage.PWControledByUser_Minus(), "PW min value 20");
            Assert.AreEqual(intensifMaxFacePage.DepthControledByUser_Pluse(areas[0]), "Depth max value 5");
            Assert.AreEqual(intensifMaxFacePage.DepthControledByUser_Minus(), "Depth min value 0.5");
            Assert.AreEqual(intensifMaxFacePage.PowerControledByUser_Pluse(areas[0]), "Power max value 35");
            Assert.AreEqual(intensifMaxFacePage.PowerControledByUser_Minus(), "Power min value 0");

            Assert.AreEqual(intensifMaxFacePage.PWControledByUser_Pluse(areas[1]), "PW max value 500");
            Assert.AreEqual(intensifMaxFacePage.PWControledByUser_Minus(), "PW min value 20");
            Assert.AreEqual(intensifMaxFacePage.DepthControledByUser_Pluse(areas[1]), "Depth max value 5");
            Assert.AreEqual(intensifMaxFacePage.DepthControledByUser_Minus(), "Depth min value 0.5");
            Assert.AreEqual(intensifMaxFacePage.PowerControledByUser_Pluse(areas[1]), "Power max value 35");
            Assert.AreEqual(intensifMaxFacePage.PowerControledByUser_Minus(), "Power min value 0");

            Assert.AreEqual(intensifMaxFacePage.PWControledByUser_Pluse(areas[2]), "PW max value 500");
            Assert.AreEqual(intensifMaxFacePage.PWControledByUser_Minus(), "PW min value 20");
            Assert.AreEqual(intensifMaxFacePage.DepthControledByUser_Pluse(areas[2]), "Depth max value 5");
            Assert.AreEqual(intensifMaxFacePage.DepthControledByUser_Minus(), "Depth min value 0.5");
            Assert.AreEqual(intensifMaxFacePage.PowerControledByUser_Pluse(areas[2]), "Power max value 35");
            Assert.AreEqual(intensifMaxFacePage.PowerControledByUser_Minus(), "Power min value 0");

            Assert.AreEqual(intensifMaxFacePage.PWControledByUser_Pluse(areas[3]), "PW max value 500");
            Assert.AreEqual(intensifMaxFacePage.PWControledByUser_Minus(), "PW min value 20");
            Assert.AreEqual(intensifMaxFacePage.DepthControledByUser_Pluse(areas[3]), "Depth max value 5");
            Assert.AreEqual(intensifMaxFacePage.DepthControledByUser_Minus(), "Depth min value 0.5");
            Assert.AreEqual(intensifMaxFacePage.PowerControledByUser_Pluse(areas[3]), "Power max value 35");
            Assert.AreEqual(intensifMaxFacePage.PowerControledByUser_Minus(), "Power min value 0");

            ////Power vs P.W. linitation
            int a = 0;           
            int l = 0;
            while (a < 4)
            {
                for (int i = 220; i <= 500; i += 20)
                {
                    Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[a], i, l), intensifMaxFacePage.CalculatePower(i));
                    l += 1;
                }

                a++;
            }
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[0], 240, 1), intensifMaxFacePage.CalculatePower(240));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[0], 260, 2), intensifMaxFacePage.CalculatePower(260));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[0], 280, 3), intensifMaxFacePage.CalculatePower(280));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[0], 300, 4), intensifMaxFacePage.CalculatePower(300));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[0], 320, 5), intensifMaxFacePage.CalculatePower(320));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[0], 340, 6), intensifMaxFacePage.CalculatePower(340));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[0], 360, 7), intensifMaxFacePage.CalculatePower(360));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[0], 380, 8), intensifMaxFacePage.CalculatePower(380));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[0], 400, 9), intensifMaxFacePage.CalculatePower(400));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[0], 420, 10), intensifMaxFacePage.CalculatePower(420));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[0], 440, 11), intensifMaxFacePage.CalculatePower(440));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[0], 460, 12), intensifMaxFacePage.CalculatePower(460));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[0], 480, 13), intensifMaxFacePage.CalculatePower(480));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[0], 500, 14), intensifMaxFacePage.CalculatePower(500));

            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[1], 220, 0), intensifMaxFacePage.CalculatePower(220));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[1], 240, 1), intensifMaxFacePage.CalculatePower(240));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[1], 260, 2), intensifMaxFacePage.CalculatePower(260));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[1], 280, 3), intensifMaxFacePage.CalculatePower(280));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[1], 300, 4), intensifMaxFacePage.CalculatePower(300));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[1], 320, 5), intensifMaxFacePage.CalculatePower(320));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[1], 340, 6), intensifMaxFacePage.CalculatePower(340));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[1], 360, 7), intensifMaxFacePage.CalculatePower(360));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[1], 380, 8), intensifMaxFacePage.CalculatePower(380));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[1], 400, 9), intensifMaxFacePage.CalculatePower(400));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[1], 420, 10), intensifMaxFacePage.CalculatePower(420));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[1], 440, 11), intensifMaxFacePage.CalculatePower(440));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[1], 460, 12), intensifMaxFacePage.CalculatePower(460));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[1], 480, 13), intensifMaxFacePage.CalculatePower(480));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[1], 500, 14), intensifMaxFacePage.CalculatePower(500));

            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[2], 220, 0), intensifMaxFacePage.CalculatePower(220));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[2], 240, 1), intensifMaxFacePage.CalculatePower(240));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[2], 260, 2), intensifMaxFacePage.CalculatePower(260));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[2], 280, 3), intensifMaxFacePage.CalculatePower(280));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[2], 300, 4), intensifMaxFacePage.CalculatePower(300));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[2], 320, 5), intensifMaxFacePage.CalculatePower(320));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[2], 340, 6), intensifMaxFacePage.CalculatePower(340));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[2], 360, 7), intensifMaxFacePage.CalculatePower(360));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[2], 380, 8), intensifMaxFacePage.CalculatePower(380));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[2], 400, 9), intensifMaxFacePage.CalculatePower(400));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[2], 420, 10), intensifMaxFacePage.CalculatePower(420));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[2], 440, 11), intensifMaxFacePage.CalculatePower(440));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[2], 460, 12), intensifMaxFacePage.CalculatePower(460));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[2], 480, 13), intensifMaxFacePage.CalculatePower(480));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[2], 500, 14), intensifMaxFacePage.CalculatePower(500));

            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[3], 220, 0), intensifMaxFacePage.CalculatePower(220));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[3], 240, 1), intensifMaxFacePage.CalculatePower(240));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[3], 260, 2), intensifMaxFacePage.CalculatePower(260));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[3], 280, 3), intensifMaxFacePage.CalculatePower(280));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[3], 300, 4), intensifMaxFacePage.CalculatePower(300));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[3], 320, 5), intensifMaxFacePage.CalculatePower(320));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[3], 340, 6), intensifMaxFacePage.CalculatePower(340));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[3], 360, 7), intensifMaxFacePage.CalculatePower(360));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[3], 380, 8), intensifMaxFacePage.CalculatePower(380));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[3], 400, 9), intensifMaxFacePage.CalculatePower(400));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[3], 420, 10), intensifMaxFacePage.CalculatePower(420));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[3], 440, 11), intensifMaxFacePage.CalculatePower(440));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[3], 460, 12), intensifMaxFacePage.CalculatePower(460));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[3], 480, 13), intensifMaxFacePage.CalculatePower(480));
            //Assert.AreEqual(intensifMaxFacePage.PowerLimitation(areas[3], 500, 14), intensifMaxFacePage.CalculatePower(500));

            Assert.AreEqual(intensifMaxFacePage.ContinuousSingleSelect(), "Continuous mode select");
            Assert.AreEqual(intensifMaxFacePage.ContinuousSpeedOption("SLOW"), "SLOW Selected");
            Assert.AreEqual(intensifMaxFacePage.changeAreasDuringContinuousSingleMode(areas[0]), "Defaults are OK!");
            Assert.AreEqual(intensifMaxFacePage.changeAreasDuringContinuousSingleMode(areas[1]), "Defaults are OK!");
            Assert.AreEqual(intensifMaxFacePage.changeAreasDuringContinuousSingleMode(areas[2]), "Defaults are OK!");
            Assert.AreEqual(intensifMaxFacePage.changeAreasDuringContinuousSingleMode(areas[3]), "Defaults are OK!");
            Assert.AreEqual(intensifMaxFacePage.ContinuousSpeedOption("MODERATE"), "MODERATE Selected");
            Assert.AreEqual(intensifMaxFacePage.changeAreasDuringContinuousSingleMode(areas[0]), "Defaults are OK!");
            Assert.AreEqual(intensifMaxFacePage.changeAreasDuringContinuousSingleMode(areas[1]), "Defaults are OK!");
            Assert.AreEqual(intensifMaxFacePage.changeAreasDuringContinuousSingleMode(areas[2]), "Defaults are OK!");
            Assert.AreEqual(intensifMaxFacePage.changeAreasDuringContinuousSingleMode(areas[3]), "Defaults are OK!");
            Assert.AreEqual(intensifMaxFacePage.ContinuousSpeedOption("FAST"), "FAST Selected");
            Assert.AreEqual(intensifMaxFacePage.changeAreasDuringContinuousSingleMode(areas[0]), "Defaults are OK!");
            Assert.AreEqual(intensifMaxFacePage.changeAreasDuringContinuousSingleMode(areas[1]), "Defaults are OK!");
            Assert.AreEqual(intensifMaxFacePage.changeAreasDuringContinuousSingleMode(areas[2]), "Defaults are OK!");
            Assert.AreEqual(intensifMaxFacePage.changeAreasDuringContinuousSingleMode(areas[3]), "Defaults are OK!");
            Assert.AreEqual(intensifMaxFacePage.SingleSelect(), "Single mode select");
            Assert.AreEqual(intensifMaxFacePage.changeAreasDuringContinuousSingleMode(areas[0]), "Defaults are OK!");
            Assert.AreEqual(intensifMaxFacePage.changeAreasDuringContinuousSingleMode(areas[1]), "Defaults are OK!");
            Assert.AreEqual(intensifMaxFacePage.changeAreasDuringContinuousSingleMode(areas[2]), "Defaults are OK!");
            Assert.AreEqual(intensifMaxFacePage.changeAreasDuringContinuousSingleMode(areas[3]), "Defaults are OK!");
            Assert.IsTrue(intensifMaxFacePage.tipCheckUpOnOff(), "failed to select tip checkup button");
            Assert.AreEqual(intensifMaxFacePage.tipCheckUp("5.0mm"), "5.0mm defined");
            Assert.AreEqual(intensifMaxFacePage.tipCheckUp("4.5mm"), "4.5mm defined");
            Assert.AreEqual(intensifMaxFacePage.tipCheckUp("4.0mm"), "4.0mm defined");
            Assert.AreEqual(intensifMaxFacePage.tipCheckUp("3.5mm"), "3.5mm defined");
            Assert.AreEqual(intensifMaxFacePage.tipCheckUp("3.0mm"), "3.0mm defined");
            Assert.AreEqual(intensifMaxFacePage.tipCheckUp("2.5mm"), "2.5mm defined");
            Assert.AreEqual(intensifMaxFacePage.tipCheckUp("2.0mm"), "2.0mm defined");
            Assert.AreEqual(intensifMaxFacePage.tipCheckUp("1.5mm"), "1.5mm defined");
            Assert.AreEqual(intensifMaxFacePage.tipCheckUp("1.0mm"), "1.0mm defined");
            Assert.AreEqual(intensifMaxFacePage.tipCheckUp("0.5mm"), "0.5mm defined");
            Assert.IsFalse(intensifMaxFacePage.tipCheckUpOnOff(), "failed to disselect tip checkup button");
            var (Fpw, Fdepth, Fpower) = intensifMaxFacePage.setParameters(areas[0], 3, 5, 2);  //Saved parameters before tip checkup
            Assert.IsTrue(intensifMaxFacePage.tipCheckUpOnOff(), "failed to select tip checkup button");
            Assert.IsFalse(intensifMaxFacePage.tipCheckUpOnOff(), "failed to disselect tip checkup button");
            Assert.AreEqual(110, Fpw);
            Assert.AreEqual(2, Fdepth);
            Assert.AreEqual(12, Fpower);
            var (Ppw, Pdepth, Ppower) = intensifMaxFacePage.setParameters(areas[1], 3, 5, 2);  //Saved parameters before tip checkup
            Assert.IsTrue(intensifMaxFacePage.tipCheckUpOnOff(), "failed to select tip checkup button");
            Assert.IsFalse(intensifMaxFacePage.tipCheckUpOnOff(), "failed to disselect tip checkup button");
            Assert.AreEqual(110, Ppw);
            Assert.AreEqual(2, Pdepth);
            Assert.AreEqual(12, Ppower);
            var (Cpw, Cdepth, Cpower) = intensifMaxFacePage.setParameters(areas[2], 3, 5, 2);  //Saved parameters before tip checkup
            Assert.IsTrue(intensifMaxFacePage.tipCheckUpOnOff(), "failed to select tip checkup button");
            Assert.IsFalse(intensifMaxFacePage.tipCheckUpOnOff(), "failed to disselect tip checkup button");
            Assert.AreEqual(140, Cpw);
            Assert.AreEqual(3, Cdepth);
            Assert.AreEqual(16, Cpower);
            var (Npw, Ndepth, Npower) = intensifMaxFacePage.setParameters(areas[3], 3, 5, 2);  //Saved parameters before tip checkup
            Assert.IsTrue(intensifMaxFacePage.tipCheckUpOnOff(), "failed to select tip checkup button");
            Assert.IsFalse(intensifMaxFacePage.tipCheckUpOnOff(), "failed to disselect tip checkup button");
            Assert.AreEqual(110, Npw);
            Assert.AreEqual(2.3, Ndepth);
            Assert.AreEqual(14, Npower);
            Assert.AreEqual(ReturntoMain(), "Main menu location");
        }

        [TestMethod]
        public void TC_11_IntensifMaxBodyDefault()
        {
            TreatmentArea treatmentArea = new TreatmentArea();
            treatmentArea.OpenBodyArea();
            string[] areas = { "Decolletage", "Hands", "Buttocks", "Abdomen", "Arms" };
            string[] defaultsPW = { "80", "80", "110", "110", "110" };
            string[] defaultsDepth = { "1.8", "1.8", "2.5", "2.5", "2" };
            string[] defaultsPower = { "12", "12", "14", "15", "12" };

            IntensifMaxBodyPage intensifMaxBodyPage = new IntensifMaxBodyPage(areas, defaultsPW, defaultsDepth, defaultsPower);
            intensifMaxBodyPage.IntneisfMAXPage();
            Assert.AreEqual(intensifMaxBodyPage.CheckIntneisfBodyEntered(), "Body IntensifMax");
            Assert.AreEqual(intensifMaxBodyPage.DecolletageDefaultPWDepthPower(), "Defaults are OK!");
            Assert.AreEqual(intensifMaxBodyPage.HandsDefaultPWDepthPower(), "Defaults are OK!");
            Assert.AreEqual(intensifMaxBodyPage.ButtocksDefaultPWDepthPower(), "Defaults are OK!");
            Assert.AreEqual(intensifMaxBodyPage.AbdomenDefaultPWDepthPower(), "Defaults are OK!");
            Assert.AreEqual(intensifMaxBodyPage.ArmsDefaultPWDepthPower(), "Defaults are OK!");
            Assert.AreEqual(intensifMaxBodyPage.PWControledByUser_Pluse(areas[0]), "PW max value 500");
            Assert.AreEqual(intensifMaxBodyPage.PWControledByUser_Minus(), "PW min value 20");
            Assert.AreEqual(intensifMaxBodyPage.DepthControledByUser_Pluse(), "Depth max value 5");
            Assert.AreEqual(intensifMaxBodyPage.DepthControledByUser_Minus(), "Depth min value 0.5");
            Assert.AreEqual(intensifMaxBodyPage.PowerControledByUser_Pluse(), "Power max value 35");
            Assert.AreEqual(intensifMaxBodyPage.PowerControledByUser_Minus(), "Power min value 0");
            Assert.AreEqual(intensifMaxBodyPage.PWControledByUser_Pluse(areas[1]), "PW max value 500");
            Assert.AreEqual(intensifMaxBodyPage.PWControledByUser_Minus(), "PW min value 20");
            Assert.AreEqual(intensifMaxBodyPage.DepthControledByUser_Pluse(), "Depth max value 5");
            Assert.AreEqual(intensifMaxBodyPage.DepthControledByUser_Minus(), "Depth min value 0.5");
            Assert.AreEqual(intensifMaxBodyPage.PowerControledByUser_Pluse(), "Power max value 35");
            Assert.AreEqual(intensifMaxBodyPage.PowerControledByUser_Minus(), "Power min value 0");
            Assert.AreEqual(intensifMaxBodyPage.PWControledByUser_Pluse(areas[2]), "PW max value 500");
            Assert.AreEqual(intensifMaxBodyPage.PWControledByUser_Minus(), "PW min value 20");
            Assert.AreEqual(intensifMaxBodyPage.DepthControledByUser_Pluse(), "Depth max value 5");
            Assert.AreEqual(intensifMaxBodyPage.DepthControledByUser_Minus(), "Depth min value 0.5");
            Assert.AreEqual(intensifMaxBodyPage.PowerControledByUser_Pluse(), "Power max value 35");
            Assert.AreEqual(intensifMaxBodyPage.PowerControledByUser_Minus(), "Power min value 0");
            Assert.AreEqual(intensifMaxBodyPage.PWControledByUser_Pluse(areas[3]), "PW max value 500");
            Assert.AreEqual(intensifMaxBodyPage.PWControledByUser_Minus(), "PW min value 20");
            Assert.AreEqual(intensifMaxBodyPage.DepthControledByUser_Pluse(), "Depth max value 5");
            Assert.AreEqual(intensifMaxBodyPage.DepthControledByUser_Minus(), "Depth min value 0.5");
            Assert.AreEqual(intensifMaxBodyPage.PowerControledByUser_Pluse(), "Power max value 35");
            Assert.AreEqual(intensifMaxBodyPage.PowerControledByUser_Minus(), "Power min value 0");
            Assert.AreEqual(intensifMaxBodyPage.PWControledByUser_Pluse(areas[4]), "PW max value 500");
            Assert.AreEqual(intensifMaxBodyPage.PWControledByUser_Minus(), "PW min value 20");
            Assert.AreEqual(intensifMaxBodyPage.DepthControledByUser_Pluse(), "Depth max value 5");
            Assert.AreEqual(intensifMaxBodyPage.DepthControledByUser_Minus(), "Depth min value 0.5");
            Assert.AreEqual(intensifMaxBodyPage.PowerControledByUser_Pluse(), "Power max value 35");
            Assert.AreEqual(intensifMaxBodyPage.PowerControledByUser_Minus(), "Power min value 0");
            //Power vs P.W. linitation
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[0], 220, 0), intensifMaxBodyPage.CalculatePower(220));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[0], 240, 1), intensifMaxBodyPage.CalculatePower(240));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[0], 260, 2), intensifMaxBodyPage.CalculatePower(260));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[0], 280, 3), intensifMaxBodyPage.CalculatePower(280));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[0], 300, 4), intensifMaxBodyPage.CalculatePower(300));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[0], 320, 5), intensifMaxBodyPage.CalculatePower(320));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[0], 340, 6), intensifMaxBodyPage.CalculatePower(340));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[0], 360, 7), intensifMaxBodyPage.CalculatePower(360));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[0], 380, 8), intensifMaxBodyPage.CalculatePower(380));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[0], 400, 9), intensifMaxBodyPage.CalculatePower(400));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[0], 420, 10), intensifMaxBodyPage.CalculatePower(420));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[0], 440, 11), intensifMaxBodyPage.CalculatePower(440));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[0], 460, 12), intensifMaxBodyPage.CalculatePower(460));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[0], 480, 13), intensifMaxBodyPage.CalculatePower(480));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[0], 500, 14), intensifMaxBodyPage.CalculatePower(500));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[1], 220, 0), intensifMaxBodyPage.CalculatePower(220));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[1], 240, 1), intensifMaxBodyPage.CalculatePower(240));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[1], 260, 2), intensifMaxBodyPage.CalculatePower(260));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[1], 280, 3), intensifMaxBodyPage.CalculatePower(280));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[1], 300, 4), intensifMaxBodyPage.CalculatePower(300));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[1], 320, 5), intensifMaxBodyPage.CalculatePower(320));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[1], 340, 6), intensifMaxBodyPage.CalculatePower(340));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[1], 360, 7), intensifMaxBodyPage.CalculatePower(360));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[1], 380, 8), intensifMaxBodyPage.CalculatePower(380));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[1], 400, 9), intensifMaxBodyPage.CalculatePower(400));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[1], 420, 10), intensifMaxBodyPage.CalculatePower(420));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[1], 440, 11), intensifMaxBodyPage.CalculatePower(440));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[1], 460, 12), intensifMaxBodyPage.CalculatePower(460));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[1], 480, 13), intensifMaxBodyPage.CalculatePower(480));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[1], 500, 14), intensifMaxBodyPage.CalculatePower(500));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[2], 220, 0), intensifMaxBodyPage.CalculatePower(220));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[2], 240, 1), intensifMaxBodyPage.CalculatePower(240));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[2], 260, 2), intensifMaxBodyPage.CalculatePower(260));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[2], 280, 3), intensifMaxBodyPage.CalculatePower(280));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[2], 300, 4), intensifMaxBodyPage.CalculatePower(300));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[2], 320, 5), intensifMaxBodyPage.CalculatePower(320));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[2], 340, 6), intensifMaxBodyPage.CalculatePower(340));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[2], 360, 7), intensifMaxBodyPage.CalculatePower(360));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[2], 380, 8), intensifMaxBodyPage.CalculatePower(380));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[2], 400, 9), intensifMaxBodyPage.CalculatePower(400));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[2], 420, 10), intensifMaxBodyPage.CalculatePower(420));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[2], 440, 11), intensifMaxBodyPage.CalculatePower(440));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[2], 460, 12), intensifMaxBodyPage.CalculatePower(460));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[2], 480, 13), intensifMaxBodyPage.CalculatePower(480));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[2], 500, 14), intensifMaxBodyPage.CalculatePower(500));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[3], 220, 0), intensifMaxBodyPage.CalculatePower(220));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[3], 240, 1), intensifMaxBodyPage.CalculatePower(240));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[3], 260, 2), intensifMaxBodyPage.CalculatePower(260));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[3], 280, 3), intensifMaxBodyPage.CalculatePower(280));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[3], 300, 4), intensifMaxBodyPage.CalculatePower(300));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[3], 320, 5), intensifMaxBodyPage.CalculatePower(320));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[3], 340, 6), intensifMaxBodyPage.CalculatePower(340));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[3], 360, 7), intensifMaxBodyPage.CalculatePower(360));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[3], 380, 8), intensifMaxBodyPage.CalculatePower(380));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[3], 400, 9), intensifMaxBodyPage.CalculatePower(400));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[3], 420, 10), intensifMaxBodyPage.CalculatePower(420));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[3], 440, 11), intensifMaxBodyPage.CalculatePower(440));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[3], 460, 12), intensifMaxBodyPage.CalculatePower(460));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[3], 480, 13), intensifMaxBodyPage.CalculatePower(480));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[3], 500, 14), intensifMaxBodyPage.CalculatePower(500));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[4], 220, 0), intensifMaxBodyPage.CalculatePower(220));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[4], 240, 1), intensifMaxBodyPage.CalculatePower(240));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[4], 260, 2), intensifMaxBodyPage.CalculatePower(260));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[4], 280, 3), intensifMaxBodyPage.CalculatePower(280));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[4], 300, 4), intensifMaxBodyPage.CalculatePower(300));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[4], 320, 5), intensifMaxBodyPage.CalculatePower(320));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[4], 340, 6), intensifMaxBodyPage.CalculatePower(340));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[4], 360, 7), intensifMaxBodyPage.CalculatePower(360));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[4], 380, 8), intensifMaxBodyPage.CalculatePower(380));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[4], 400, 9), intensifMaxBodyPage.CalculatePower(400));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[4], 420, 10), intensifMaxBodyPage.CalculatePower(420));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[4], 440, 11), intensifMaxBodyPage.CalculatePower(440));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[4], 460, 12), intensifMaxBodyPage.CalculatePower(460));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[4], 480, 13), intensifMaxBodyPage.CalculatePower(480));
            Assert.AreEqual(intensifMaxBodyPage.PowerLimitation(areas[4], 500, 14), intensifMaxBodyPage.CalculatePower(500));
            Assert.AreEqual(intensifMaxBodyPage.ContinuousSingleSelect(), "Continuous mode select");
            Assert.AreEqual(intensifMaxBodyPage.ContinuousSpeedOption("SLOW"), "SLOW Selected");
            Assert.AreEqual(intensifMaxBodyPage.changeAreasDuringContinuousSingleMode(areas[0]), "Defaults are OK!");
            Assert.AreEqual(intensifMaxBodyPage.changeAreasDuringContinuousSingleMode(areas[1]), "Defaults are OK!");
            Assert.AreEqual(intensifMaxBodyPage.changeAreasDuringContinuousSingleMode(areas[2]), "Defaults are OK!");
            Assert.AreEqual(intensifMaxBodyPage.changeAreasDuringContinuousSingleMode(areas[3]), "Defaults are OK!");
            Assert.AreEqual(intensifMaxBodyPage.changeAreasDuringContinuousSingleMode(areas[4]), "Defaults are OK!");
            Assert.AreEqual(intensifMaxBodyPage.ContinuousSpeedOption("MODERATE"), "MODERATE Selected");
            Assert.AreEqual(intensifMaxBodyPage.changeAreasDuringContinuousSingleMode(areas[0]), "Defaults are OK!");
            Assert.AreEqual(intensifMaxBodyPage.changeAreasDuringContinuousSingleMode(areas[1]), "Defaults are OK!");
            Assert.AreEqual(intensifMaxBodyPage.changeAreasDuringContinuousSingleMode(areas[2]), "Defaults are OK!");
            Assert.AreEqual(intensifMaxBodyPage.changeAreasDuringContinuousSingleMode(areas[3]), "Defaults are OK!");
            Assert.AreEqual(intensifMaxBodyPage.changeAreasDuringContinuousSingleMode(areas[4]), "Defaults are OK!");
            Assert.AreEqual(intensifMaxBodyPage.ContinuousSpeedOption("FAST"), "FAST Selected");
            Assert.AreEqual(intensifMaxBodyPage.changeAreasDuringContinuousSingleMode(areas[0]), "Defaults are OK!");
            Assert.AreEqual(intensifMaxBodyPage.changeAreasDuringContinuousSingleMode(areas[1]), "Defaults are OK!");
            Assert.AreEqual(intensifMaxBodyPage.changeAreasDuringContinuousSingleMode(areas[2]), "Defaults are OK!");
            Assert.AreEqual(intensifMaxBodyPage.changeAreasDuringContinuousSingleMode(areas[3]), "Defaults are OK!");
            Assert.AreEqual(intensifMaxBodyPage.changeAreasDuringContinuousSingleMode(areas[4]), "Defaults are OK!");
            Assert.AreEqual(intensifMaxBodyPage.SingleSelect(), "Single mode select");
            Assert.AreEqual(intensifMaxBodyPage.changeAreasDuringContinuousSingleMode(areas[0]), "Defaults are OK!");
            Assert.AreEqual(intensifMaxBodyPage.changeAreasDuringContinuousSingleMode(areas[1]), "Defaults are OK!");
            Assert.AreEqual(intensifMaxBodyPage.changeAreasDuringContinuousSingleMode(areas[2]), "Defaults are OK!");
            Assert.AreEqual(intensifMaxBodyPage.changeAreasDuringContinuousSingleMode(areas[3]), "Defaults are OK!");
            Assert.AreEqual(intensifMaxBodyPage.changeAreasDuringContinuousSingleMode(areas[4]), "Defaults are OK!");
            Assert.IsTrue(intensifMaxBodyPage.tipCheckUpOnOff(), "failed to select tip checkup button");
            Assert.AreEqual(intensifMaxBodyPage.tipCheckUp("5.0mm"), "5.0mm defined");
            Assert.AreEqual(intensifMaxBodyPage.tipCheckUp("4.5mm"), "4.5mm defined");
            Assert.AreEqual(intensifMaxBodyPage.tipCheckUp("4.0mm"), "4.0mm defined");
            Assert.AreEqual(intensifMaxBodyPage.tipCheckUp("3.5mm"), "3.5mm defined");
            Assert.AreEqual(intensifMaxBodyPage.tipCheckUp("3.0mm"), "3.0mm defined");
            Assert.AreEqual(intensifMaxBodyPage.tipCheckUp("2.5mm"), "2.5mm defined");
            Assert.AreEqual(intensifMaxBodyPage.tipCheckUp("2.0mm"), "2.0mm defined");
            Assert.AreEqual(intensifMaxBodyPage.tipCheckUp("1.5mm"), "1.5mm defined");
            Assert.AreEqual(intensifMaxBodyPage.tipCheckUp("1.0mm"), "1.0mm defined");
            Assert.AreEqual(intensifMaxBodyPage.tipCheckUp("0.5mm"), "0.5mm defined");
            Assert.IsFalse(intensifMaxBodyPage.tipCheckUpOnOff(), "failed to disselect tip checkup button");
            var (Dpw, Ddepth, Dpower) = intensifMaxBodyPage.setParameters(areas[0], 3, 5, 2);  //Saved parameters before tip checkup
            Assert.IsTrue(intensifMaxBodyPage.tipCheckUpOnOff(), "failed to select tip checkup button");
            Assert.IsFalse(intensifMaxBodyPage.tipCheckUpOnOff(), "failed to disselect tip checkup button");
            Assert.AreEqual(110, Dpw);
            Assert.AreEqual(2.3, Ddepth);
            Assert.AreEqual(14, Dpower);
            var (Hpw, Hdepth, Hpower) = intensifMaxBodyPage.setParameters(areas[1], 3, 5, 2);  //Saved parameters before tip checkup
            Assert.IsTrue(intensifMaxBodyPage.tipCheckUpOnOff(), "failed to select tip checkup button");
            Assert.IsFalse(intensifMaxBodyPage.tipCheckUpOnOff(), "failed to disselect tip checkup button");
            Assert.AreEqual(110, Hpw);
            Assert.AreEqual(2.3, Hdepth);
            Assert.AreEqual(14, Hpower);
            var (Bpw, Bdepth, Bpower) = intensifMaxBodyPage.setParameters(areas[2], 3, 5, 2);  //Saved parameters before tip checkup
            Assert.IsTrue(intensifMaxBodyPage.tipCheckUpOnOff(), "failed to select tip checkup button");
            Assert.IsFalse(intensifMaxBodyPage.tipCheckUpOnOff(), "failed to disselect tip checkup button");
            Assert.AreEqual(140, Bpw);
            Assert.AreEqual(3, Bdepth);
            Assert.AreEqual(16, Bpower);
            var (Apw, Adepth, Apower) = intensifMaxBodyPage.setParameters(areas[3], 3, 5, 2);  //Saved parameters before tip checkup
            Assert.IsTrue(intensifMaxBodyPage.tipCheckUpOnOff(), "failed to select tip checkup button");
            Assert.IsFalse(intensifMaxBodyPage.tipCheckUpOnOff(), "failed to disselect tip checkup button");
            Assert.AreEqual(140, Apw);
            Assert.AreEqual(3, Adepth);
            Assert.AreEqual(17, Apower);
            var (Npw, Ndepth, Npower) = intensifMaxBodyPage.setParameters(areas[4], 3, 5, 2);  //Saved parameters before tip checkup
            Assert.IsTrue(intensifMaxBodyPage.tipCheckUpOnOff(), "failed to select tip checkup button");
            Assert.IsFalse(intensifMaxBodyPage.tipCheckUpOnOff(), "failed to disselect tip checkup button");
            Assert.AreEqual(140, Npw);
            Assert.AreEqual(2.5, Ndepth);
            Assert.AreEqual(14, Npower);

            Assert.AreEqual(ReturntoMain(), "Main menu location");
        }

        [TestMethod]
        public void TC_12_FSRMaxFaceDefault()
        {
            TreatmentArea treatmentArea = new TreatmentArea();
            treatmentArea.OpenFaceArea();

            string[] areas = { "Forehead", "Periorbital", "Cheeks", "Neck" };
            string[] defaultsPW = { "20", "20", "30", "30" };
            string[] defaultsPower = { "3", "3", "3", "3" };

            FSRMaxDefaultPage fsrMaxDefaultPage = new FSRMaxDefaultPage(areas, defaultsPW, defaultsPower);
            fsrMaxDefaultPage.FSRMAXPage();
            Assert.AreEqual(fsrMaxDefaultPage.CheckFSRFaceEntered(), "Face FSRMax");
            Assert.AreEqual(fsrMaxDefaultPage.ForeheadDefaultPWPower(), "Forehead PW and Power defaults are OK!");
            Assert.AreEqual(fsrMaxDefaultPage.PeriorbitalDefaultPWPower(), "Periorbital PW and Power defaults are OK!");
            Assert.AreEqual(fsrMaxDefaultPage.CheeksDefaultPWPower(), "Cheeks PW and Power defaults are OK!");
            Assert.AreEqual(fsrMaxDefaultPage.NeckDefaultPWPower(), "Neck PW and Power defaults are OK!");
            Assert.IsTrue(fsrMaxDefaultPage.LedOffCheck(), "LED is not OFF!");
            Assert.AreEqual(fsrMaxDefaultPage.PWControledByUser_Pluse(areas[0]), "PW max value 60");
            Assert.AreEqual(fsrMaxDefaultPage.PWControledByUser_Minus(), "PW min value 10");
            Assert.AreEqual(fsrMaxDefaultPage.PowerControledByUser_Pluse(), "Power max value 6");
            Assert.AreEqual(fsrMaxDefaultPage.PowerControledByUser_Minus(), "Power min value 1");
            Assert.AreEqual(fsrMaxDefaultPage.PWControledByUser_Pluse(areas[1]), "PW max value 60");
            Assert.AreEqual(fsrMaxDefaultPage.PWControledByUser_Minus(), "PW min value 10");
            Assert.AreEqual(fsrMaxDefaultPage.PowerControledByUser_Pluse(), "Power max value 6");
            Assert.AreEqual(fsrMaxDefaultPage.PowerControledByUser_Minus(), "Power min value 1");
            Assert.AreEqual(fsrMaxDefaultPage.PWControledByUser_Pluse(areas[2]), "PW max value 60");
            Assert.AreEqual(fsrMaxDefaultPage.PWControledByUser_Minus(), "PW min value 10");
            Assert.AreEqual(fsrMaxDefaultPage.PowerControledByUser_Pluse(), "Power max value 6");
            Assert.AreEqual(fsrMaxDefaultPage.PowerControledByUser_Minus(), "Power min value 1");
            Assert.AreEqual(fsrMaxDefaultPage.PWControledByUser_Pluse(areas[3]), "PW max value 60");
            Assert.AreEqual(fsrMaxDefaultPage.PWControledByUser_Minus(), "PW min value 10");
            Assert.AreEqual(fsrMaxDefaultPage.PowerControledByUser_Pluse(), "Power max value 6");
            Assert.AreEqual(fsrMaxDefaultPage.PowerControledByUser_Minus(), "Power min value 1");
            //Console.WriteLine(fsrMaxDefaultPage.TreatmentTimer());

            Assert.AreEqual(ReturntoMain(), "Main menu location");
        }

        [TestMethod]
        public void TC_13_FSRMaxBodyDefault()
        {
            TreatmentArea treatmentArea = new TreatmentArea();
            treatmentArea.OpenBodyArea();

            string[] areas = { "Hands", "Decolletage", "Buttocks", "Abdomen", "Arms" };
            string[] defaultsPW = { "20", "20", "20", "20", "20" };
            string[] defaultsPower = { "3", "3", "3", "3", "2" };

            FSRMaxBodyDefaultPage fsrMaxBodyDefaultPage = new FSRMaxBodyDefaultPage(areas, defaultsPW, defaultsPower);
            fsrMaxBodyDefaultPage.FSRMAXPage();
            Assert.AreEqual(fsrMaxBodyDefaultPage.CheckFSRBodyEntered(), "Body FSRMax");
            Assert.AreEqual(fsrMaxBodyDefaultPage.HandsDefaultPWPower(), "Hands PW and Power defaults are OK!");
            Assert.AreEqual(fsrMaxBodyDefaultPage.DecolletageDefaultPWPower(), "Decolletage PW and Power defaults are OK!");
            Assert.AreEqual(fsrMaxBodyDefaultPage.ButtocksDefaultPWPower(), "Buttocks PW and Power defaults are OK!");
            Assert.AreEqual(fsrMaxBodyDefaultPage.AbdomenDefaultPWPower(), "Abdomen PW and Power defaults are OK!");
            Assert.AreEqual(fsrMaxBodyDefaultPage.ArmsDefaultPWPower(), "Arms PW and Power defaults are OK!");
            Assert.IsTrue(fsrMaxBodyDefaultPage.LedOffCheck(), "LED is not OFF!");
            Assert.AreEqual(fsrMaxBodyDefaultPage.PWControledByUser_Pluse(areas[0]), "PW max value 60");
            Assert.AreEqual(fsrMaxBodyDefaultPage.PWControledByUser_Minus(), "PW min value 10");
            Assert.AreEqual(fsrMaxBodyDefaultPage.PowerControledByUser_Pluse(), "Power max value 6");
            Assert.AreEqual(fsrMaxBodyDefaultPage.PowerControledByUser_Minus(), "Power min value 1");
            Assert.AreEqual(fsrMaxBodyDefaultPage.PWControledByUser_Pluse(areas[1]), "PW max value 60");
            Assert.AreEqual(fsrMaxBodyDefaultPage.PWControledByUser_Minus(), "PW min value 10");
            Assert.AreEqual(fsrMaxBodyDefaultPage.PowerControledByUser_Pluse(), "Power max value 6");
            Assert.AreEqual(fsrMaxBodyDefaultPage.PowerControledByUser_Minus(), "Power min value 1");
            Assert.AreEqual(fsrMaxBodyDefaultPage.PWControledByUser_Pluse(areas[2]), "PW max value 60");
            Assert.AreEqual(fsrMaxBodyDefaultPage.PWControledByUser_Minus(), "PW min value 10");
            Assert.AreEqual(fsrMaxBodyDefaultPage.PowerControledByUser_Pluse(), "Power max value 6");
            Assert.AreEqual(fsrMaxBodyDefaultPage.PowerControledByUser_Minus(), "Power min value 1");
            Assert.AreEqual(fsrMaxBodyDefaultPage.PWControledByUser_Pluse(areas[3]), "PW max value 60");
            Assert.AreEqual(fsrMaxBodyDefaultPage.PWControledByUser_Minus(), "PW min value 10");
            Assert.AreEqual(fsrMaxBodyDefaultPage.PowerControledByUser_Pluse(), "Power max value 6");
            Assert.AreEqual(fsrMaxBodyDefaultPage.PowerControledByUser_Minus(), "Power min value 1");
            Assert.AreEqual(fsrMaxBodyDefaultPage.PWControledByUser_Pluse(areas[4]), "PW max value 60");
            Assert.AreEqual(fsrMaxBodyDefaultPage.PWControledByUser_Minus(), "PW min value 10");
            Assert.AreEqual(fsrMaxBodyDefaultPage.PowerControledByUser_Pluse(), "Power max value 6");
            Assert.AreEqual(fsrMaxBodyDefaultPage.PowerControledByUser_Minus(), "Power min value 1");
            //Console.WriteLine(fsrMaxDefaultPage.TreatmentTimer());

            Assert.AreEqual(ReturntoMain(), "Main menu location");
        }

        [TestMethod]
        public void TC_14_iFineMaxReady()
        {
            string[] areas = { "Periorbital", "Perioral" };
            string[] defaultPasses = { "10", "10" };
            string[] defaultsPower = { "3", "3" };
            string[] defaultIntervalTime = { "30", "30" };

            iFineMaxReadyPage iFineMaxPage = new iFineMaxReadyPage(areas, defaultPasses, defaultsPower, defaultIntervalTime);
            TreatmentArea treatmentArea = new TreatmentArea();
            treatmentArea.OpenFaceArea();
            Assert.AreEqual(ConnectHP("iFine MAX", "Left"), "iFine MAX is not connected properlly");
            iFineMaxPage.IFineMAX();
            //iFineMaxPage.checkallinfo();
            Assert.AreEqual(iFineMaxPage.CheckiFineEntered(), "iFineMax in ready mode is enterd");
            Assert.AreEqual(iFineMaxPage.PeriorbitalDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.AreEqual(iFineMaxPage.PerioralDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.IsTrue(iFineMaxPage.LedONCheck(), "LED is not ON!");
            Assert.AreEqual(iFineMaxPage.DissconectHP("iFine MAX"), "iFine MAX is disconnected, and the disconnection message appeared");
            treatmentArea.OpenFaceArea();
            Assert.AreEqual(ConnectHP("iFine MAX", "Right"), "iFine MAX is not connected properlly");
            iFineMaxPage.IFineMAX();
            Assert.AreEqual(iFineMaxPage.CheckiFineEntered(), "iFineMax in ready mode is enterd");
            Assert.AreEqual(iFineMaxPage.PeriorbitalDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.AreEqual(iFineMaxPage.PerioralDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.IsTrue(iFineMaxPage.LedONCheck(), "LED is not ON!");
            Assert.AreEqual(iFineMaxPage.DissconectHP("iFine MAX"), "iFine MAX is disconnected, and the disconnection message appeared");
            treatmentArea.OpenFaceArea();
            Assert.AreEqual(ConnectHP("iFine MAX", "Left"), "iFine MAX is not connected properlly");
            iFineMaxPage.IFineMAX();
            Assert.AreEqual(iFineMaxPage.CheckiFineEntered(), "iFineMax in ready mode is enterd");
            Assert.AreEqual(iFineMaxPage.OutputPowerMeasuring(), 6);   //6 stages of power should be tested otherwise fail
            Assert.AreEqual("Bad contact warning is functioning properly", ManualBadContactTest());
            Assert.AreEqual("Rotation warning is functioning properly", ManualMotionTest());
            Assert.AreEqual("No motion warning functioning properly", ManualNoMotionTest());
            Assert.AreEqual(iFineMaxPage.DissconectHP("iFine MAX"), "iFine MAX HP is not disconnected properlly");
            treatmentArea.OpenFaceArea();
            Assert.AreEqual(ConnectHP("iFine MAX", "Right"), "iFine MAX is not connected properlly");
            iFineMaxPage.IFineMAX();
            Assert.AreEqual(iFineMaxPage.CheckiFineEntered(), "iFineMax in ready mode is enterd");
            Assert.AreEqual(iFineMaxPage.OutputPowerMeasuring(), 6);   //6 stages of power should be tested otherwise fail
            Assert.AreEqual("Bad contact warning is functioning properly", ManualBadContactTest());
            Assert.AreEqual("Rotation warning is functioning properly", ManualMotionTest());
            Assert.AreEqual("No motion warning functioning properly", ManualNoMotionTest());
            Assert.AreEqual(iFineMaxPage.checkCounterDecrease(areas[0]), "Passes not decreased by 1");
            Assert.AreEqual(iFineMaxPage.checkCounterDecrease(areas[1]), "Passes not decreased by 1");
            Assert.AreEqual(ReturntoMain(), "Main menu location");
            Assert.AreEqual("Logs upload sucsses", UploadLogs());
            Assert.AreEqual(ReturntoMain(), "Main menu location");

            Login log = new Login();
            log.LoginToMainMenu();
            Assert.IsTrue(log.checkLoginOk(), "Login failed");
            //iFineMaxPage.RetreatTest("Periorbital");
            iFineMaxPage.RetreatTest("Perioral");
        }

        [TestMethod]
        public void TC_15_SmallMaxReady()
        {
            string[] areas = { "Cheeks", "Neck", "Submental", "Decolletage" };
            string[] defaultPasses = { "10", "10", "10", "10" };
            string[] defaultsPower = { "40", "35", "40", "40" };
            string[] defaultIntervalTime = { "30", "30", "30", "30" };

            SmallMaxReadyPage smallMaxPage = new SmallMaxReadyPage(areas, defaultPasses, defaultsPower, defaultIntervalTime);
            TreatmentArea treatmentArea = new TreatmentArea();
            treatmentArea.OpenFaceArea();
            Assert.AreEqual(ConnectHP("Small MAX", "Left"), "Small MAX is not connected properlly");
            smallMaxPage.SmallMAX();
            //smallMaxPage.checkallinfo();
            Assert.AreEqual(smallMaxPage.CheckSmallEntered(), "Face SmallMax");
            Assert.AreEqual(smallMaxPage.CheeksDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.AreEqual(smallMaxPage.NeckDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.AreEqual(smallMaxPage.SubmentalDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.AreEqual(smallMaxPage.DecolletageDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.IsTrue(smallMaxPage.LedONCheck(), "LED is not ON!");
            Assert.AreEqual(smallMaxPage.DissconectHP("Small MAX"), "Small MAX is not disconnected properlly");
            treatmentArea.OpenFaceArea();
            Assert.AreEqual(ConnectHP("Small MAX", "Right"), "Small MAX is not connected properlly");
            smallMaxPage.SmallMAX();
            Assert.AreEqual(smallMaxPage.CheckSmallEntered(), "Face SmallMax");
            Assert.AreEqual(smallMaxPage.CheeksDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.IsTrue(smallMaxPage.LedONCheck(), "LED is not ON!");
            Assert.AreEqual(smallMaxPage.DissconectHP("Small MAX"), "Small MAX is not disconnected properlly");
            treatmentArea.OpenFaceArea();
            Assert.AreEqual(ConnectHP("Small MAX", "Left"), "Small MAX is not connected properlly");
            smallMaxPage.SmallMAX();
            Assert.AreEqual(smallMaxPage.CheckSmallEntered(), "Face SmallMax");
            Assert.AreEqual(smallMaxPage.OutputPowerMeasuring(), 9);   //9 stages of power should be tested otherwise fail
            Assert.AreEqual("Bad contact warning is functioning properly", ManualBadContactTest());
            Assert.AreEqual("Rotation warning is functioning properly", ManualMotionTest());
            Assert.AreEqual("No motion warning functioning properly", ManualNoMotionTest());
            Assert.AreEqual(smallMaxPage.DissconectHP("Small MAX"), "Small MAX is not disconnected properlly");
            treatmentArea.OpenFaceArea();
            Assert.AreEqual(ConnectHP("Small MAX", "Right"), "Small MAX is not connected properlly");
            smallMaxPage.SmallMAX();
            Assert.AreEqual(smallMaxPage.CheckSmallEntered(), "Face SmallMax");
            Assert.AreEqual(smallMaxPage.OutputPowerMeasuring(), 9);   //9 stages of power should be tested otherwise fail
            Assert.AreEqual("Bad contact warning is functioning properly", ManualBadContactTest());
            Assert.AreEqual("Rotation warning is functioning properly", ManualMotionTest());
            Assert.AreEqual("No motion warning functioning properly", ManualNoMotionTest());
            Assert.AreEqual(smallMaxPage.checkCounterDecrease(areas[0]), "Passes not decreased by 1");
            Assert.AreEqual(smallMaxPage.checkCounterDecrease(areas[1]), "Passes not decreased by 1");
            Assert.AreEqual(smallMaxPage.checkCounterDecrease(areas[2]), "Passes not decreased by 1");
            Assert.AreEqual(smallMaxPage.checkCounterDecrease(areas[3]), "Passes not decreased by 1");
            Assert.AreEqual(ReturntoMain(), "Main menu location");
            Assert.AreEqual("Logs upload sucsses", UploadLogs());
            Assert.AreEqual(ReturntoMain(), "Main menu location");
            Login log = new Login();
            log.LoginToMainMenu();
            Assert.IsTrue(log.checkLoginOk(), "Login failed");
            //smallMaxPage.RetreatTest("Cheeks");
        }

        [TestMethod]
        public void TC_16_MiniShaperMaxFaceReady()
        {
            string[] areas = { "Cheeks", "Jawline", "Submental" };
            string[] defaultPasses = { "9", "10", "10" };
            string[] defaultsPower = { "35", "25", "20" };
            string[] defaultIntervalTime = { "30", "30", "30" };

            MiniShaperMaxFaceReadyPage miniShaperMaxFaceReadyPage = new MiniShaperMaxFaceReadyPage(areas, defaultPasses, defaultsPower, defaultIntervalTime);
            TreatmentArea treatmentArea = new TreatmentArea();
            treatmentArea.OpenFaceArea();
            Assert.AreEqual(ConnectHP("Mini Shaper MAX", "Left"), "Mini Shaper MAX is not connected properlly");
            miniShaperMaxFaceReadyPage.MiniShaperMaxPage();
            //miniShaperMaxFaceReadyPage.checkallinfo();
            Assert.AreEqual(miniShaperMaxFaceReadyPage.CheckMiniShaperFaceEntered(), "Face MiniShaperMax");
            Assert.AreEqual(miniShaperMaxFaceReadyPage.CheeksDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.AreEqual(miniShaperMaxFaceReadyPage.JawlineDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.AreEqual(miniShaperMaxFaceReadyPage.SubmentalDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.IsTrue(miniShaperMaxFaceReadyPage.LedONCheck(), "LED is not ON!");
            Assert.AreEqual(miniShaperMaxFaceReadyPage.DissconectHP("Mini Shaper MAX"), "Mini Shaper MAX is not disconnected properlly");
            treatmentArea.OpenFaceArea();
            Assert.AreEqual(ConnectHP("Mini Shaper MAX", "Right"), "Mini Shaper MAX is not connected properlly");
            miniShaperMaxFaceReadyPage.MiniShaperMaxPage();
            Assert.AreEqual(miniShaperMaxFaceReadyPage.CheckMiniShaperFaceEntered(), "Face MiniShaperMax");
            Assert.AreEqual(miniShaperMaxFaceReadyPage.CheeksDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.IsTrue(miniShaperMaxFaceReadyPage.LedONCheck(), "LED is not ON!");
            Assert.AreEqual(miniShaperMaxFaceReadyPage.DissconectHP("Mini Shaper MAX"), "Mini Shaper MAX is not disconnected properlly");
            treatmentArea.OpenFaceArea();
            Assert.AreEqual(ConnectHP("Mini Shaper MAX", "Left"), "Mini Shaper MAX is not connected properlly");
            miniShaperMaxFaceReadyPage.MiniShaperMaxPage();
            Assert.AreEqual(miniShaperMaxFaceReadyPage.CheckMiniShaperFaceEntered(), "Face MiniShaperMax");
            Assert.AreEqual(miniShaperMaxFaceReadyPage.OutputPowerMeasuring(), 11);   //11 stages of power should be tested otherwise fail
            Assert.AreEqual("Bad contact warning is functioning properly", ManualBadContactTest());
            Assert.AreEqual("Rotation warning is functioning properly", ManualMotionTest());
            Assert.AreEqual("No motion warning functioning properly", ManualNoMotionTest());
            Assert.AreEqual(miniShaperMaxFaceReadyPage.DissconectHP("Mini Shaper MAX"), "Mini Shaper MAX is not disconnected properlly");
            treatmentArea.OpenFaceArea();
            Assert.AreEqual(ConnectHP("Mini Shaper MAX", "Right"), "Mini Shaper MAX is not connected properlly");
            miniShaperMaxFaceReadyPage.MiniShaperMaxPage();
            Assert.AreEqual(miniShaperMaxFaceReadyPage.CheckMiniShaperFaceEntered(), "Face MiniShaperMax");
            Assert.AreEqual(miniShaperMaxFaceReadyPage.OutputPowerMeasuring(), 11);   //11 stages of power should be tested otherwise fail
            Assert.AreEqual("Bad contact warning is functioning properly", ManualBadContactTest());
            Assert.AreEqual("Rotation warning is functioning properly", ManualMotionTest());
            Assert.AreEqual("No motion warning functioning properly", ManualNoMotionTest());
            Assert.AreEqual(miniShaperMaxFaceReadyPage.checkCounterDecrease(areas[0]), "Passes not decreased by 1");
            Assert.AreEqual(miniShaperMaxFaceReadyPage.checkCounterDecrease(areas[1]), "Passes not decreased by 1");
            Assert.AreEqual(miniShaperMaxFaceReadyPage.checkCounterDecrease(areas[2]), "Passes not decreased by 1");
            Assert.AreEqual(ReturntoMain(), "Main menu location");
            Assert.AreEqual("Logs upload sucsses", UploadLogs());
            Assert.AreEqual(ReturntoMain(), "Main menu location");
            Login log = new Login();
            log.LoginToMainMenu();
            Assert.IsTrue(log.checkLoginOk(), "Login failed");
            //miniShaperMaxFaceReadyPage.RetreatTest("Cheeks");

        }

        [TestMethod]
        public void TC_17_MiniShaperMaxBodyReady()
        {
            string[] areas = { "Decolletage", "Arms", "Knees" };
            string[] defaultPasses = { "10", "13", "13" };
            string[] defaultsPower = { "40", "30", "35" };
            string[] defaultIntervalTime = { "30", "30", "30" };

            MiniShaperMaxBodyReadyPage miniShaperMaxBodyReadyPage = new MiniShaperMaxBodyReadyPage(areas, defaultPasses, defaultsPower, defaultIntervalTime);
            TreatmentArea treatmentArea = new TreatmentArea();
            treatmentArea.OpenBodyArea();
            Assert.AreEqual(ConnectHP("Mini Shaper MAX", "Left"), "Mini Shaper MAX is not connected properlly");
            miniShaperMaxBodyReadyPage.MiniShaperMaxPage();
            //miniShaperMaxBodyReadyPage.checkallinfo();
            Assert.AreEqual(miniShaperMaxBodyReadyPage.CheckMiniShaperBodyEntered(), "Body MiniShaperMax");
            Assert.AreEqual(miniShaperMaxBodyReadyPage.DecolletageDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.AreEqual(miniShaperMaxBodyReadyPage.ArmsDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.AreEqual(miniShaperMaxBodyReadyPage.KneesDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.IsTrue(miniShaperMaxBodyReadyPage.LedONCheck(), "LED is not ON!");
            Assert.AreEqual(miniShaperMaxBodyReadyPage.DissconectHP("Mini Shaper MAX"), "Mini Shaper MAX is not disconnected properlly");
            treatmentArea.OpenBodyArea();
            Assert.AreEqual(ConnectHP("Mini Shaper MAX", "Right"), "Mini Shaper MAX is not connected properlly");
            miniShaperMaxBodyReadyPage.MiniShaperMaxPage();
            Assert.AreEqual(miniShaperMaxBodyReadyPage.CheckMiniShaperBodyEntered(), "Body MiniShaperMax");
            Assert.AreEqual(miniShaperMaxBodyReadyPage.DecolletageDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.IsTrue(miniShaperMaxBodyReadyPage.LedONCheck(), "LED is not ON!");
            Assert.AreEqual(miniShaperMaxBodyReadyPage.DissconectHP("Mini Shaper MAX"), "Mini Shaper MAX is not disconnected properlly");
            treatmentArea.OpenBodyArea();
            Assert.AreEqual(ConnectHP("Mini Shaper MAX", "Left"), "Mini Shaper MAX is not connected properlly");
            miniShaperMaxBodyReadyPage.MiniShaperMaxPage();
            Assert.AreEqual(miniShaperMaxBodyReadyPage.CheckMiniShaperBodyEntered(), "Body MiniShaperMax");
            Assert.AreEqual(miniShaperMaxBodyReadyPage.OutputPowerMeasuring(), 11); //11 stages of power should be tested otherwise fail
            Assert.AreEqual("Bad contact warning is functioning properly", ManualBadContactTest());
            Assert.AreEqual("Rotation warning is functioning properly", ManualMotionTest());
            Assert.AreEqual("No motion warning functioning properly", ManualNoMotionTest());
            Assert.AreEqual(miniShaperMaxBodyReadyPage.DissconectHP("Mini Shaper MAX"), "Mini Shaper MAX is not disconnected properlly");
            treatmentArea.OpenBodyArea();
            Assert.AreEqual(ConnectHP("Mini Shaper MAX", "Right"), "Mini Shaper MAX is not connected properlly");
            miniShaperMaxBodyReadyPage.MiniShaperMaxPage();
            Assert.AreEqual(miniShaperMaxBodyReadyPage.CheckMiniShaperBodyEntered(), "Body MiniShaperMax");
            Assert.AreEqual(miniShaperMaxBodyReadyPage.OutputPowerMeasuring(), 11);   //11 stages of power should be tested otherwise fail
            Assert.AreEqual("Bad contact warning is functioning properly", ManualBadContactTest());
            Assert.AreEqual("Rotation warning is functioning properly", ManualMotionTest());
            Assert.AreEqual("No motion warning functioning properly", ManualNoMotionTest());
            Assert.AreEqual(miniShaperMaxBodyReadyPage.checkCounterDecrease(areas[0]), "Passes not decreased by 1");
            Assert.AreEqual(miniShaperMaxBodyReadyPage.checkCounterDecrease(areas[1]), "Passes not decreased by 1");
            Assert.AreEqual(miniShaperMaxBodyReadyPage.checkCounterDecrease(areas[2]), "Passes not decreased by 1");
            Assert.AreEqual(ReturntoMain(), "Main menu location");
            Assert.AreEqual("Logs upload sucsses", UploadLogs());
            Assert.AreEqual(ReturntoMain(), "Main menu location");
            Login log = new Login();
            log.LoginToMainMenu();
            Assert.IsTrue(log.checkLoginOk(), "Login failed");
            ////miniShaperMaxFaceReadyPage.RetreatTest("Cheeks");
        }

        [TestMethod]
        public void TC_18_ShaperMaxReady()
        {
            string[] areas = { "Flanks", "Arms", "Abdomen", "Buttocks", "Thighs", "Knees", "Back" };
            string[] defaultPasses = { "10", "10", "10", "10", "10", "10", "10" };
            string[] defaultsPower = { "55", "45", "60", "70", "70", "45", "60" };
            string[] defaultIntervalTime = { "30", "30", "30", "30", "30", "30", "30" };

            ShaperMaxReadyPage shaperMaxReadyPage = new ShaperMaxReadyPage(areas, defaultPasses, defaultsPower, defaultIntervalTime);
            TreatmentArea treatmentArea = new TreatmentArea();
            treatmentArea.OpenBodyArea();
            Assert.AreEqual(ConnectHP("Shaper MAX", "Left"), "Shaper MAX is not connected properlly");
            shaperMaxReadyPage.ShaperMaxPage();
            //shaperMaxReadyPage.checkallinfo();
            Assert.AreEqual(shaperMaxReadyPage.CheckShaperEntered(), "Body ShaperMax");
            Assert.AreEqual(shaperMaxReadyPage.FlanksDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.AreEqual(shaperMaxReadyPage.ArmsDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.AreEqual(shaperMaxReadyPage.AbdomenDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.AreEqual(shaperMaxReadyPage.ButtocksDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.AreEqual(shaperMaxReadyPage.ThighsDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.AreEqual(shaperMaxReadyPage.KneesDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.AreEqual(shaperMaxReadyPage.BackDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.IsTrue(shaperMaxReadyPage.LedONCheck(), "LED is not ON!");
            Assert.AreEqual(shaperMaxReadyPage.DissconectHP("Shaper MAX"), "Shaper MAX is not disconnected properlly");
            treatmentArea.OpenBodyArea();
            Assert.AreEqual(ConnectHP("Shaper MAX", "Right"), "Shaper MAX is not connected properlly");
            shaperMaxReadyPage.ShaperMaxPage();
            Assert.AreEqual(shaperMaxReadyPage.CheckShaperEntered(), "Body ShaperMax");
            Assert.AreEqual(shaperMaxReadyPage.FlanksDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.IsTrue(shaperMaxReadyPage.LedONCheck(), "LED is not ON!");
            Assert.AreEqual(shaperMaxReadyPage.DissconectHP("Shaper MAX"), "Shaper MAX is not disconnected properlly");
            treatmentArea.OpenBodyArea();
            Assert.AreEqual(ConnectHP("Shaper MAX", "Left"), "Shaper MAX is not connected properlly");
            shaperMaxReadyPage.ShaperMaxPage();
            Assert.AreEqual(shaperMaxReadyPage.CheckShaperEntered(), "Body ShaperMax");
            Assert.AreEqual(shaperMaxReadyPage.OutputPowerMeasuring(), 12); //12 stages of power should be tested otherwise fail
            Assert.AreEqual("Bad contact warning is functioning properly", ManualBadContactTest());
            Assert.AreEqual("Rotation warning is functioning properly", ManualMotionTest());
            Assert.AreEqual("No motion warning functioning properly", ManualNoMotionTest());
            Assert.AreEqual(shaperMaxReadyPage.DissconectHP("Shaper MAX"), "Shaper MAX is not disconnected properlly");
            treatmentArea.OpenBodyArea();
            Assert.AreEqual(ConnectHP("Shaper MAX", "Right"), "Shaper MAX is not connected properlly");
            shaperMaxReadyPage.ShaperMaxPage();
            Assert.AreEqual(shaperMaxReadyPage.CheckShaperEntered(), "Body ShaperMax");
            Assert.AreEqual(shaperMaxReadyPage.OutputPowerMeasuring(), 12);   //12 stages of power should be tested otherwise fail
            Assert.AreEqual("Bad contact warning is functioning properly", ManualBadContactTest());
            Assert.AreEqual("Rotation warning is functioning properly", ManualMotionTest());
            Assert.AreEqual("No motion warning functioning properly", ManualNoMotionTest());
            Assert.AreEqual(shaperMaxReadyPage.checkCounterDecrease(areas[0]), "Passes not decreased by 1");
            Assert.AreEqual(shaperMaxReadyPage.checkCounterDecrease(areas[1]), "Passes not decreased by 1");
            Assert.AreEqual(shaperMaxReadyPage.checkCounterDecrease(areas[2]), "Passes not decreased by 1");
            Assert.AreEqual(shaperMaxReadyPage.checkCounterDecrease(areas[3]), "Passes not decreased by 1");
            Assert.AreEqual(shaperMaxReadyPage.checkCounterDecrease(areas[4]), "Passes not decreased by 1");
            Assert.AreEqual(shaperMaxReadyPage.checkCounterDecrease(areas[5]), "Passes not decreased by 1");
            Assert.AreEqual(shaperMaxReadyPage.checkCounterDecrease(areas[6]), "Passes not decreased by 1");
            Assert.AreEqual(ReturntoMain(), "Main menu location");
            Assert.AreEqual("Logs upload sucsses", UploadLogs());
            Assert.AreEqual(ReturntoMain(), "Main menu location");
            Login log = new Login();
            log.LoginToMainMenu();
            Assert.IsTrue(log.checkLoginOk(), "Login failed");
            //// miniShaperMaxFaceReadyPage.RetreatTest("Cheeks");
        }

        [TestMethod]
        public void TC_19_ContourMaxReady()
        {
            string[] areas = { "Flanks", "Abdomen", "Back", "Buttocks", "Thighs" };
            string[] defaultPasses = { "10", "10", "10", "10", "10" };
            string[] defaultsPower = { "65", "70", "60", "70", "70" };
            string[] defaultIntervalTime = { "30", "30", "30", "30", "30" };

            ContourMaxReadyPage contourMaxReadyPage = new ContourMaxReadyPage(areas, defaultPasses, defaultsPower, defaultIntervalTime);
            TreatmentArea treatmentArea = new TreatmentArea();
            treatmentArea.OpenBodyArea();
            Assert.AreEqual(ConnectHP("Contour MAX", "Left"), "Contour MAX is not connected properlly");
            contourMaxReadyPage.ContourMaxPage();
            //contourMaxReadyPage.checkallinfo();
            Assert.AreEqual(contourMaxReadyPage.CheckContourEntered(), "Body ContourMax");
            Assert.AreEqual(contourMaxReadyPage.FlanksDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.AreEqual(contourMaxReadyPage.AbdomenDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.AreEqual(contourMaxReadyPage.BackDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.AreEqual(contourMaxReadyPage.ButtocksDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.AreEqual(contourMaxReadyPage.ThighsDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.IsTrue(contourMaxReadyPage.LedONCheck(), "LED is not ON!");
            Assert.AreEqual(contourMaxReadyPage.DissconectHP("Contour MAX"), "Contour MAX is not disconnected properlly");
            treatmentArea.OpenBodyArea();
            Assert.AreEqual(ConnectHP("Contour MAX", "Right"), "Contour MAX is not connected properlly");
            contourMaxReadyPage.ContourMaxPage();
            Assert.AreEqual(contourMaxReadyPage.CheckContourEntered(), "Body ContourMax");
            Assert.AreEqual(contourMaxReadyPage.FlanksDefaultPassesPowerTime(), "Defaults are OK!");
            Assert.IsTrue(contourMaxReadyPage.LedONCheck(), "LED is not ON!");
            Assert.AreEqual(contourMaxReadyPage.DissconectHP("Contour MAX"), "Contour MAX is not disconnected properlly");
            treatmentArea.OpenBodyArea();
            Assert.AreEqual(ConnectHP("Contour MAX", "Left"), "Contour MAX is not connected properlly");
            contourMaxReadyPage.ContourMaxPage();
            Assert.AreEqual(contourMaxReadyPage.CheckContourEntered(), "Body ContourMax");
            Assert.AreEqual(contourMaxReadyPage.OutputPowerMeasuring(), 11); //11 stages of power should be tested otherwise fail
            Assert.AreEqual("Bad contact warning is functioning properly", ManualBadContactTest());
            Assert.AreEqual("Rotation warning is functioning properly", ManualMotionTest());
            Assert.AreEqual("No motion warning functioning properly", ManualNoMotionTest());
            Assert.AreEqual(contourMaxReadyPage.DissconectHP("Contour MAX"), "Contour MAX is not disconnected properlly");
            treatmentArea.OpenBodyArea();
            Assert.AreEqual(ConnectHP("Contour MAX", "Right"), "Contour MAX is not connected properlly");
            contourMaxReadyPage.ContourMaxPage();
            Assert.AreEqual(contourMaxReadyPage.CheckContourEntered(), "Body ContourMax");
            Assert.AreEqual(contourMaxReadyPage.OutputPowerMeasuring(), 11);   //11 stages of power should be tested otherwise fail
            Assert.AreEqual("Bad contact warning is functioning properly", ManualBadContactTest());
            Assert.AreEqual("Rotation warning is functioning properly", ManualMotionTest());
            Assert.AreEqual("No motion warning functioning properly", ManualNoMotionTest());
            Assert.AreEqual(contourMaxReadyPage.checkCounterDecrease(areas[0]), "Passes not decreased by 1");
            Assert.AreEqual(contourMaxReadyPage.checkCounterDecrease(areas[1]), "Passes not decreased by 1");
            Assert.AreEqual(contourMaxReadyPage.checkCounterDecrease(areas[2]), "Passes not decreased by 1");
            Assert.AreEqual(contourMaxReadyPage.checkCounterDecrease(areas[3]), "Passes not decreased by 1");
            Assert.AreEqual(contourMaxReadyPage.checkCounterDecrease(areas[4]), "Passes not decreased by 1");
            Assert.AreEqual(contourMaxReadyPage.checkCounterDecrease(areas[5]), "Passes not decreased by 1");
            Assert.AreEqual(ReturntoMain(), "Main menu location");
            Assert.AreEqual("Logs upload sucsses", UploadLogs());
            Assert.AreEqual(ReturntoMain(), "Main menu location");
            Login log = new Login();
            log.LoginToMainMenu();
            Assert.IsTrue(log.checkLoginOk(), "Login failed");
            //ThermalCamera camera = new ThermalCamera();
            //Assert.AreEqual(camera.ThermalCameraOnOff(), "Thermal camera CALIBRATED and working fine");
        }

        [TestMethod]
        public void TC_20_IntneisfMaxFaceReady()
        {
            string[] areas = { "Forehead", "Periorbital", "Cheeks", "Neck" };
            string[] defaultsPW = { "80", "80", "110", "80" };
            string[] defaultsDepth = { "1.5", "1.5", "2.5", "1.8" };
            string[] defaultsPower = { "10", "10", "14", "12" };

            IntensifMaxFaceReadyPage intensifMaxFacePage = new IntensifMaxFaceReadyPage(areas, defaultsPW, defaultsDepth, defaultsPower);
            TreatmentArea treatmentArea = new TreatmentArea();
            treatmentArea.OpenFaceArea();
            Assert.AreEqual(ConnectHP("Intensif MAX", "Left"), "Intensif MAX is not connected properlly");
            intensifMaxFacePage.IntneisfMAXPage();
            Assert.AreEqual(intensifMaxFacePage.CheckIntneisfFaceEntered(), "Face IntensifMax");


        }

        [TestMethod]
        public void TC_21_IntneisfMaxBodyReady()
        {

        }

        [TestMethod]
        public void TC_22_FSRMaxFaceReady()
        {

        }

        [TestMethod]
        public void TC_23_FSRMaxBodyReady()
        {

        }

        [TestMethod]
        public void TC_24_SettingsMode()
        {
            List<string> errors = new List<string>();
            SettingsMode settingsMode = new SettingsMode(errors);
            Assert.IsTrue(settingsMode.GetToSettingsMode(), "Unable to access the settings page");
            Assert.AreEqual(settingsMode.OpenPasswordMenu(), "Password reset menu is open");
            Assert.AreEqual(settingsMode.OpenSerialAndCalibrationMenu(), "Serial and camera cal. bars are open");
            //Assert.AreEqual(settingsMode.EnterSNnumber(), "Serial number updated");
            settingsMode.EnterSNnumber();

            Assert.AreEqual(settingsMode.GUISWVersion("01.06.05"), "GUI is in the last version");
            //Assert.AreEqual(settingsMode.FPGAVersionCheck(commStatus, ""), "");
            //Assert.AreEqual(settingsMode.SystemSerialNumberAndCalibrationMenu(), "Serial & Cal. value menu are displayed");
            //Assert.AreEqual(settingsMode.SystemSerialLength(), 10);  //10 Checksum for sys serial length 

        }



    }
}
