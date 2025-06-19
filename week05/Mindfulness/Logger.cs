using System;
using System.IO;

public static class Logger
{
    private static readonly string logPath;

    static Logger()
    {
        string projectDir = AppDomain.CurrentDomain.BaseDirectory;
        string rootDir = Path.GetFullPath(Path.Combine(projectDir, @"..\..\.."));
        string logDirectory = Path.Combine(rootDir, "logs");

        Directory.CreateDirectory(logDirectory);

        string fileName = $"log_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.txt";
        logPath = Path.Combine(logDirectory, fileName);
    }

    public static void Log(string message)
    {
        string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
        File.AppendAllText(logPath, logMessage + Environment.NewLine);
    }
}