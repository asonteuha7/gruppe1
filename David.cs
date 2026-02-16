class David{
    public static bool help(string[] args){
        Console.WriteLine("Available commands");
        foreach(var arg in args){
            Console.WriteLine(arg);
        }
        return true;
    }
    private static (bool, string) cat_impl(string file){
        string result = "";
        try{
            StreamReader reader = new StreamReader(file);
            string? line = reader.ReadLine();
            while(line != null){
                result += line + '\n';
                line = reader.ReadLine();
            }
        }
        catch{
            return (false, result);
        }
        return (true, result);
    }
    public static bool cat(string[] args){
        if(args.Length != 1) throw new Exception("bad number of arguments to cat");
        var (ok, file) = cat_impl(args[0]);
        if(!ok) return false;
        Console.WriteLine(file);
        return true;
    }

    [Flags]
    private enum WC_ARGS : int{
        BYTES = 1, // x
        CHARS = 2, // m
        LINES = 4, // l
        WORDS = 8 // w
    };

    private static (bool, WC_ARGS) get_args(string str){
        WC_ARGS result = 0;
        for(int i = 0; i < str.Length; ++i){
            switch(str[i]){
                case '-':
                break;
                case 'x':
                    result |= WC_ARGS.BYTES;
                break;
                case 'm': // renamed this because dotnet run captures -c, probably
                    result |= WC_ARGS.CHARS; 
                break;
                case 'l':
                    result |= WC_ARGS.LINES;
                break;
                case 'w':
                    result |= WC_ARGS.WORDS;
                break;
                default:
                    return (false, result);
            }
        }
        return (true, result);
    }

    public static bool wc(string[] args){
        WC_ARGS wc_args = 0;
        string? file_name = null;
        for(int i = 0; i < args.Length; ++i){
            var w = args[i];
            if(w[0] == '-'){
                var (ok, parsed_wc_args) = get_args(w);
                if(!ok) throw new Exception("invalid arguments");
                wc_args |= parsed_wc_args;
            }
            else if(i == args.Length - 1){
                file_name = w;
            }
            else{
                throw new Exception("bad format");
            }
        }
        if(file_name == null) throw new Exception("did not specify a file");
        var (_ok, file) = cat_impl(file_name);
        if(!_ok) throw new Exception($"could not read the file: {file}"); // really want to rethrow
        if((wc_args & WC_ARGS.BYTES) != 0){
            Console.Write(new FileInfo(file_name).Length + " ");
        }
        if((wc_args & WC_ARGS.CHARS) != 0){
            Console.Write(file.Length + " ");
        }
        if((wc_args & WC_ARGS.LINES) != 0){
            int count = 0;
            foreach(char ch in file){
                if(ch == '\n')
                    ++count;
            }
            Console.Write(count + " ");
        }
        if((wc_args & WC_ARGS.WORDS) != 0){
            int count = 0;
            bool is_break = true;
            foreach(char ch in file){
                switch(ch){
                    case ' ': case '\n': case '\t':
                        is_break = true;
                    break;
                    default:
                        if(is_break){
                            is_break = false;
                            ++count;
                        }
                    break;
                }
            }
            Console.Write(count + " ");
        }

        Console.Write($"{file_name}\n");
        return true;
    }
}
