using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files_Bundler
{
    public static class Functions
    {
        //function that returns all the files that are in the binary tree of the given directory name.
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
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }

            return files;
        }



        // function that gets 

        public static List<string> GetListOfProgrammingLanguages()
        {
            // Create and return a list of programming languages
            return new List<string> { "C", "C++", "C#", "Java", "Python", "JavaScript", "Ruby", "Swift", "Kotlin", "Rust", "Go", "PHP", "Perl", "TypeScript", "Dart", "R", "MATLAB", "Fortran", "COBOL", "Ada", "Lisp", "Scheme", "Prolog", "Haskell", "Erlang", "Groovy", "Scala", "Ruby on Rails", "HTML/CSS", "SQL", "Assembly language", "VHDL", "Verilog", "Scratch", "Blockly" };

        }

        public static string GetLanguageFromExtension(string fileName)
        {
            string extension = Path.GetExtension(fileName).TrimStart('.').ToLower();

            // Define a dictionary to map file extensions to programming languages
            Dictionary<string, string> extensionToLanguage = new Dictionary<string, string>
        {
            { "c", "C" },
            { "cpp", "C++" },
            { "cs", "C#" },
            { "java", "Java" },
            { "py", "Python" },
            { "js", "JavaScript" },
            { "rb", "Ruby" },
            { "swift", "Swift" },
            { "kt", "Kotlin" },
            { "rs", "Rust" },
            { "go", "Go" },
            { "php", "PHP" },
            { "pl", "Perl" },
            { "ts", "TypeScript" },
            { "dart", "Dart" },
            { "r", "R" },
            { "m", "MATLAB" },
            { "f90", "Fortran" },
            { "cob", "COBOL" },
            { "ada", "Ada" },
            { "lisp", "Lisp" },
            { "scm", "Scheme" },
            { "pro", "Prolog" },
            { "hs", "Haskell" },
            { "erl", "Erlang" },
            { "groovy", "Groovy" },
            { "scala", "Scala" },
            { "html", "HTML/CSS" },
            { "css", "HTML/CSS" },
            { "sql", "SQL" },
            { "asm", "Assembly language" },
            { "vhd", "VHDL" },
            { "v", "Verilog" },
            { "sb3", "Scratch" },
            { "blk", "Blockly" }
        };

            // Check if the extension exists in the mapping, and return the corresponding language
            if (extensionToLanguage.TryGetValue(extension, out string language))
            {
                return language;
            }
            else
            {
                return "Unknown"; // Return "Unknown" for unrecognized extensions
            }
        }

        static public bool checkAllGivenLangsValidation(List<string> givenLangs, List<string> validProgrammingLanguages)
        {

            foreach (var lang in givenLangs)
            {
                bool isValidLang = false;
                foreach (var vLang in validProgrammingLanguages)
                {
                    if (lang == vLang)
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


    }
}
