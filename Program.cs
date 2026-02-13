class ProgramPointer{
    public string m_program_name;
    public Func<string[], bool> m_fptr;
    public ProgramPointer(string program_name, Func<string[], bool> fptr){
        m_program_name = program_name;
        m_fptr = fptr;
    }
}

class App{
    private static List<ProgramPointer> m_list_of_programs = new List<ProgramPointer>
        {
            new ProgramPointer("help", David.help)
        };
    public static void Main(string[] args){
        if(args.Length == 0) return;
        string program = args[0];
        string[] program_args = new string[args.Length - 1];
        for(int i = 1; i < args.Length; ++i){
            program_args[i] = args[i];
        }
        var ptr = m_list_of_programs.Find(x => x.m_program_name == program);
        if(ptr == null) return;
        ptr.m_fptr(program_args);
    }
}
