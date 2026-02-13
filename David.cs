class David{
    public static bool help(string[] args){
        Console.WriteLine("Available commands");
        foreach(var arg in args){
            Console.WriteLine(arg);
        }
        return true;
    }
    public static bool cat(string[] args){
        return false;

    }
}
