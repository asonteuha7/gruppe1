class David{
    public static bool help(string[] args){
        Console.WriteLine("Available commands");
        foreach(var arg in args){
            Console.WriteLine(arg);
        }
        return true;
    }
    public static bool cat(string[] args){
        if(args.Length != 1) return false;
        try{
            StreamReader reader = new StreamReader(args[0]);
            string? line = reader.ReadLine();
            while(line != null){
                Console.WriteLine(line);
                line = reader.ReadLine();
            }
        }
        catch{
            return false;
        }
        return true;
    }
}
