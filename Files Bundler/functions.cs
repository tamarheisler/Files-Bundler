

namespace Files_Bundler
{
    public static class Functions
    {
        public static List<string> DirSearch(string sDir)
        {
            List<string> files = new List<String>();
            try
            {
                foreach (string f in Directory.GetFiles(sDir))
                {
                    files.Add(f);
                }
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    files.AddRange(DirSearch(d));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return files;
        }
        public static List<string> GetListOfProgrammingLanguages()
        {
            return new List<string> { "c", "c++", "c#", "java", "python", "javascript", "js", "ruby", "swift", "kotlin", "rust", "go", "php", "perl", "typescript", "dart", "r", "matlab", "fortran", "cobol", "ada", "lisp", "scheme", "prolog", "haskell", "erlang", "groovy", "scala", "ruby", "html", "css", "sql", "assembly language", "vhdl", "verilog", "scratch", "blockly" };
        }
        public static List<string> removeUnnecessaryLangs(List<string> filesNames)
        {
            List<string> validLanguages = GetListOfProgrammingLanguages();
            List<string> filteredFileNames = new List<string>();
            foreach (string fileName in filesNames)
            {
                string language = GetLanguageFromExtension(fileName);
                if (validLanguages.Contains(language))
                {
                    filteredFileNames.Add(fileName);
                }
            }
            return filteredFileNames;
        }
        public static string GetLanguageFromExtension(string fileName)
        {
            string extension = Path.GetExtension(fileName).TrimStart('.').ToLower();
            Dictionary<string, string> extensionToLanguage = new Dictionary<string, string>
            {
                { "c", "c" },
                { "cpp", "c++" },
                { "cs", "c#" },
                { "json", "json" },
                { "java", "java" },
                { "py", "python" },
                { "js", "javascript" },
                { "rb", "ruby" },
                { "swift", "swift" },
                { "kt", "kotlin" },
                { "rs", "rust" },
                { "go", "go" },
                { "php", "php" },
                { "pl", "perl" },
                { "ts", "typescript" },
                { "dart", "dart" },
                { "r", "r" },
                { "m", "matlab" },
                { "f90", "fortran" },
                { "cob", "cobol" },
                { "ada", "ada" },
                { "lisp", "lisp" },
                { "scm", "scheme" },
                { "pro", "prolog" },
                { "hs", "haskell" },
                { "erl", "erlang" },
                { "groovy", "groovy" },
                { "scala", "scala" },
                { "html", "html" },
                { "css", "css" },
                { "sql", "sql" },
                { "asm", "assembly" },
                { "vhd", "vhdl" },
                { "v", "verilog" },
                { "sb3", "scratch" },
                { "blk", "blockly" }
            };
            if (extensionToLanguage.TryGetValue(extension, out string language))
            {
                return language;
            }
            else
            {
                return "Unknown";
            }
        }

        static public bool checkAllGivenLangsValidation(List<string> givenLangs, List<string> validProgrammingLanguages)
        {

            foreach (var lang in givenLangs)
            {
                bool isValidLang = false;
                foreach (var vLang in validProgrammingLanguages)
                {
                    if (lang.ToLower() == vLang)
                    {
                        isValidLang = true;
                    }
                }
                if (isValidLang == false)
                {
                    return false;
                }
            }
            return true;
        }
        public static List<string> sortByProgrammingLangs(List<string> listToSort)
        {
            var sortedFiles = listToSort
                .OrderBy(name => Path.GetExtension(name)) 
                .ToList();

            return sortedFiles;
        }
        public static bool RemoveEmptyLinesFromFile(string filePath)
        {
            try
            {
                string content = File.ReadAllText(filePath);
                string[] lines = content.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                string nonEmptyContent = string.Join(Environment.NewLine, lines.Where(line => !string.IsNullOrWhiteSpace(line)));
                File.WriteAllText(filePath, nonEmptyContent);
                return true;
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred while processing the file: " + e.Message);
                return false;
            }
        }
    }
}
