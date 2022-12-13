class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the hours and the minutes as separate inputs: ");
        int hours;
        int minutes;
        while (true)
        {
            if (!int.TryParse(Console.ReadLine(), out hours) || !int.TryParse(Console.ReadLine(), out minutes))
                Console.WriteLine("Please Enter a valid integer value!");
            else if (hours < 0 || hours > 12 || minutes < 0 || minutes > 59)
                Console.WriteLine("Please Enter hour values between 0 and 12, minute values between 0 and 59!");
            else // values are valid integers and in correct time format
                break;
        }
        double hourInDegrees = (hours * 30) + (minutes * 30.0 / 60);
        double minuteInDegrees = minutes * 6;
        double lesserAngle = Math.Abs(hourInDegrees - minuteInDegrees);
        if (lesserAngle > 180)
        {
            lesserAngle = 360 - lesserAngle;
        }
        Console.WriteLine($"Angle between {hours} hour and {minutes} minute is {lesserAngle} degrees");
        Console.ReadKey();
    }
}