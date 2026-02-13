
public class Goggen
{
    public static bool PWD(string[] args)
    {
        Console.WriteLine(Directory.GetCurrentDirectory());
        return false; 
    }

    public static bool Echo(string[] args)
    {
        string? input = Console.ReadLine();
        string[] text = input!.Split(' ');
        string message = string.Join(" ", text[1..]);
        Console.WriteLine(message);
        return false;
    }  
}