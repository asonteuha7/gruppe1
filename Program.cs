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
            new ProgramPointer("pwd", Goggen.PWD),
            new ProgramPointer("help", David.help)
        };
    public static void Main(string[] args){
        if(args.Length == 0) return;
        string program = args[0].ToLower().Trim();
        string[] program_args = new string[args.Length - 1];
        string[] all_programs = new string[m_list_of_programs.Count];
        for(int i = 0; i < m_list_of_programs.Count; ++i){
            all_programs[i] = m_list_of_programs[i].m_program_name;
        }
        for(int i = 1; i < args.Length; ++i){
            program_args[i] = args[i];
        }
        var ptr = m_list_of_programs.Find(x => x.m_program_name == program);
        if(ptr == null) return;
        bool status;
        if(ptr.m_program_name == "help"){
            status = ptr.m_fptr(all_programs);
        }
        else{
            status = ptr.m_fptr(program_args);
        }
    }
}
