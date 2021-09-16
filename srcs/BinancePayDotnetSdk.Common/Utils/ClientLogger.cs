using System;
using BinancePayDotnetSdk.Common.Enums;

namespace BinancePayDotnetSdk.Common.Utils
{
    internal static class ClientLogger
    {
        private static bool _enabled = true;

        internal static void Enable()
        {
            if (_enabled)
            {
                return;
            }
            _enabled = true;
        }

        internal static void Disable()
        {
            if (!_enabled)
            {
                return;
            }
            _enabled = false;
        }
        internal static void Info(string message)
        {
            Log(LogType.Information, message);
        }

        internal static void Error(string message, Exception e)
        {
            Log(LogType.Error, message, e);
        }
        
        internal static void Warning(string message)
        {
            Log(LogType.Error, message);
        }

        private static void Log(LogType logType, string message, Exception e = null)
        {
            if (!_enabled)
            {
                return;
            }
            
            switch (logType)
            {
                case LogType.Information:
                    PrintTimestamp();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write("[INFO]");
                    Console.ResetColor();
                    Console.Write($"{message}");
                    Console.WriteLine();
                    return;
                case LogType.Error:
                    PrintTimestamp();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("[ERROR]");
                    Console.ResetColor();
                    Console.Write($"[{(string.IsNullOrEmpty(message) ? string.Empty : $"{message}")}]\n"+
                                  $"{(string.IsNullOrEmpty(e?.Source) ? string.Empty : $"{e.Source} ")}" +
                                  $"{(string.IsNullOrEmpty(e?.StackTrace) ? string.Empty : $"{e.StackTrace} ")}" +
                                  $"{(string.IsNullOrEmpty(e?.Message) ? string.Empty : $"{e.Message} ")}");
                    Console.WriteLine();
                    if (e != null) throw e;
                    return;
                case LogType.Warning:
                    PrintTimestamp();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("[WARN]");
                    Console.ResetColor();
                    Console.Write($"{message}");
                    Console.WriteLine();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(logType), logType, null);
            }
        }

        private static void PrintTimestamp()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"[{DateTime.UtcNow:dd/MM/yyyy HH:mm:ss}]");
            Console.ResetColor();
        }
    }
}