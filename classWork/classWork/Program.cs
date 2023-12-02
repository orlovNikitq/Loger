using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;
using System;
using System.IO;

public class User
{
    public string UserName { get; set; }

    public User(string userName)
    {
        UserName = userName;
    }
}

public class Logger
{
    private readonly string logFilePath;

    public Logger(string logFilePath)
    {
        this.logFilePath = logFilePath;
    }

    public void LogMessage(string messageType, string messageText, User user)
    {
        using (StreamWriter sw = File.AppendText(logFilePath))
        {
            sw.WriteLine($"[{DateTime.Now}] {messageType} - {user.UserName}: {messageText}");
        }
    }
}

class Program
{
    static void Main()
    {
        User user = new User("asd");
        Logger logger = new Logger("log.txt");

        logger.LogMessage("Info", "Программа запущена", user);
        logger.LogMessage("Warning", "Низкий уровень заряда", user);
        logger.LogMessage("Error", "Не удалось открыть файл", user);

        Console.WriteLine("Записи добавлены в лог-файл.");
    }
}