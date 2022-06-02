using Newtonsoft.Json;
using SystemInfo.Core.Devices.Drives;
using SystemInfo.Core.Devices.Verifiers;
using SystemInfo.Core.Gigabytes.Extensions;
using SystemInfo.Core.Logger;
using SystemInfo.Core.Options;
using SystemInfo.Core.Systems.Data.Repositories.Windows;
using SystemInfo.Core.Systems.Data.Result;
using SystemInfo.Core.Weather;

Options options = JsonConvert.DeserializeObject<Options>(File.ReadAllText("options.json"));

ISystemDataResult systemDataResult = new WindowsSystemDataRepository().ReadData();
if (RegisteredVerifiers.MemoryDeviceSpaceVerifier.Verify(systemDataResult.Memory.DeviceSpace, options.MaxOccupiedSpaceInPercentages))
{
    ConsoleWriter.WriteLineWarning($"Occupied space is more than {options.MaxOccupiedSpaceInPercentages}%! " +
        $"({systemDataResult.Memory.AvaliableFreeSpace.ConvertItToGigabytes()}/{systemDataResult.Memory.Capacity.ConvertItToGigabytes()}");
}

foreach (Drive drive in systemDataResult.Drives)
{
    if (RegisteredVerifiers.MemoryDeviceSpaceVerifier.Verify(systemDataResult.Memory.DeviceSpace, options.MaxOccupiedSpaceInPercentages))
    {
        ConsoleWriter.WriteLineWarning($"Drive '{drive.Name}' Occupied space is more than {options.MaxOccupiedSpaceInPercentages}%! " +
            $"({drive.AvaliableFreeSpace.ConvertItToGigabytes()}/{drive.Capacity.ConvertItToGigabytes()})");
    }
}

Root root = await Weather.Get("Tallinn");
ConsoleWriter.WriteLineInformation("Temperature in Tallinn right now: " + root.current.temp_c);

Console.ReadLine();

public sealed class ConsoleWriter
{
    private static readonly ILogger logger = new Logger();



    public enum Message
    {
        Information,
        Warning,
        Error
    }



    public static void WriteLine(string text, ConsoleColor color = ConsoleColor.Gray, Message message = Message.Information)
    {
        if (text == null)
        {
            throw new ArgumentNullException(nameof(text));
        }

        ConsoleColor lastColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.WriteLine($"[{message}] >> {text}");
        Console.ForegroundColor = lastColor;
    }

    public static void WriteLineInformation(string text, ConsoleColor color = ConsoleColor.Gray)
    {
        if (text == null)
        {
            throw new ArgumentNullException(nameof(text));
        }

        logger.Log($"[{DateTime.Now}] >> [{Message.Information}] {text}");
        WriteLine(text, color, Message.Information);
    }

    public static void WriteLineWarning(string text, ConsoleColor color = ConsoleColor.Yellow)
    {
        if (text == null)
        {
            throw new ArgumentNullException(nameof(text));
        }

        logger.Log($"[{DateTime.Now}] >> [{Message.Warning}] {text}");
        WriteLine(text, color, Message.Warning);
    }

    public static void WriteLineError(string text, ConsoleColor color = ConsoleColor.Red)
    {
        if (text == null)
        {
            throw new ArgumentNullException(nameof(text));
        }

        logger.Log($"[{DateTime.Now}] >> [{Message.Error}] {text}");
        WriteLine(text, color, Message.Error);
    }
}