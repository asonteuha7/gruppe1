
public class Goggen
{
    public static bool PWD(string[] args)
    {
        Console.WriteLine(Directory.GetCurrentDirectory());
        return false; 
    }
    public static bool Echo(string[] args)
    {
        Console.WriteLine(string.Join(" ", args));
        return false;
    }  

}