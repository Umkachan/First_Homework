namespace ProjectTools
{
    public class ConsoleWorker
    {
        public static void ShowMessage(string message)
        {
            if (!string.IsNullOrWhiteSpace(message))
            {
                Console.WriteLine(message);
            }
        }

        public static bool GetIntFromConsoleInput(ref int resultValue)
        {
            var message = GetStringValueFromConsoleInput();
            var result = false;

            if (!string.IsNullOrWhiteSpace(message) && int.TryParse(message.Trim(), out resultValue))
            {
                result = !result;
            }
            else
            {
                ShowMessage("Not a number");
            }

            return result;
        }

        public static string GetStringValueFromConsoleInput()
        {
            var message = Console.ReadLine();

            return message;
        }
    }
}
