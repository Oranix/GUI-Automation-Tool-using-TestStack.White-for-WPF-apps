using System;
using System.IO;

namespace AutomationCore
{
    public static class Logger
    {
        private static readonly string logFilePath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "automation_log.txt");

        public static void Info(string message)
        {
            Write("INFO", message);
        }

        public static void Error(string message)
        {
            Write("ERROR", message);
        }

        public static void TestResult(string testName, bool success, string errorMessage = null)
        {
            if (success)
                Write("PASS", $"{testName} passed successfully.");
            else
                Write("FAIL", $"{testName} failed. Error: {errorMessage}");
        }

        private static void Write(string level, string message)
        {
            string line = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] {message}";
            File.AppendAllText(logFilePath, line + Environment.NewLine);
        }
    }
}
