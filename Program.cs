class ProgramPointer{
    public string m_program_name{get; private init;}
    private Func<string[], bool> m_fptr{get; init;}
    public bool call(string[] args){
        if(m_fptr == null) throw new Exception("fptr not loaded");
        return m_fptr(args);
    }
    public ProgramPointer(string program_name, Func<string[], bool> fptr){
        m_program_name = program_name;
        m_fptr = fptr;
    }
}

class App{
    private static List<ProgramPointer> m_list_of_programs = new List<ProgramPointer>
        {
            new ProgramPointer("pwd", Goggen.PWD),
            new ProgramPointer("help", David.help),
            new ProgramPointer("echo", Goggen.Echo),
            new ProgramPointer("cat", David.cat),
            new ProgramPointer("wc", David.wc)
        };
    public static void program(string[] args){
        if(args.Length == 0) return;
        string program = args[0].ToLower().Trim();
        string[] program_args = new string[args.Length - 1];
        string[] all_programs = new string[m_list_of_programs.Count];
        for(int i = 0; i < m_list_of_programs.Count; ++i){
            all_programs[i] = m_list_of_programs[i].m_program_name;
        }
        for(int i = 1; i < args.Length; ++i){
            program_args[i-1] = args[i]; // bad code
        }
        var ptr = m_list_of_programs.Find(x => x.m_program_name == program);
        if(ptr == null) return;
        bool status;
        if(ptr.m_program_name == "help"){
            status = ptr.call(all_programs);
        }
        else{
            status = ptr.call(program_args);
        }
    }
    public static void Main(string[] args){
        try{
            program(args);
        }
        catch(Exception ex){
            Console.WriteLine(ex.Message);
        }
    }
}
