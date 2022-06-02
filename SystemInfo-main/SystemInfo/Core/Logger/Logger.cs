namespace SystemInfo.Core.Logger
{
    public sealed class Logger : ILogger
    {
        public void Log(string message)
        {
            using (StreamWriter writer = new StreamWriter("logs.txt", true))
            {
                writer.WriteLine(message);
            }
        }
    }
}
