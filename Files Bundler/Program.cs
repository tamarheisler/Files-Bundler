using Files_Bundler;
using System.CommandLine;


var rootCommand = new RootCommand("Root command for file bundler CLI");
var bundleCommand = new Command("bundle", "Bundle code files to a single file");
var bundleOutputOption = new Option<FileInfo>("--output", "file path and name");
var bundleNoteOption = new Option<bool>("--note", "Include source code references as comments in the bundled fil");
var bundleLangOption = new Option<string>("--lang", "required langueges for the bundled output")
{
    IsRequired = true,
};
var bundleSortOption = new Option<bool>("--sort", "file path and name"); //if true- sort by program lang, else- by name of file 
var bundleRemoveOption = new Option<bool>("--remove-empty-lines", "Remove empty lines in the code files");
var bundleAuthorOption = new Option<string>("--author", "file author name");


bundleCommand.AddOption(bundleOutputOption);
bundleCommand.AddOption(bundleLangOption);
bundleCommand.AddOption(bundleNoteOption);
bundleCommand.AddOption(bundleAuthorOption);
bundleCommand.AddOption(bundleRemoveOption);
bundleCommand.AddOption(bundleSortOption);

bundleCommand.SetHandler((output, langueges, note, author, sort, remove) =>
{
    try
    {
        Console.WriteLine("hello " + output.Name);
        List<string> filesNames = Functions.DirSearch(Directory.GetCurrentDirectory()); // list of all the code files names in current folder
        File.Create(output.FullName).Close();

        /*foreach (var file in filesNames) // checks if the function of finding all the code files is working or not
        {                                  // and also the func of the extensions.  both works!
            Console.WriteLine(file + ", ");
            Console.WriteLine(Functions.GetLanguageFromExtension(file) + ", ");
        }*/

        using (StreamWriter writer = new StreamWriter(output.FullName))
        {
            writer.WriteLine("Hello new file!");
        }

        // -----------------Langs option:
        if (langueges == "all") 
        {
            Console.WriteLine("all langs");
        }
        else //the user want a list of specific langs
        {
            List<string> givenLangs = langueges.Split(' ').ToList();
            List<string> validProgrammingLanguages = Functions.GetListOfProgrammingLanguages();
            bool givenLangsValidation = Functions.checkAllGivenLangsValidation(givenLangs, validProgrammingLanguages);
            if (!givenLangsValidation)
            {
                throw new Exception("ERROR: one or more of the given langueges is invalid");
            }
            Console.WriteLine("there is langs in!, you don't want all");
        }

        // -----------------Note option:
        if (note == true) //check the note
        {

            Console.WriteLine("note option is true");
        }
        // -----------------Sort option:
        if (sort == true)
        {
            Console.WriteLine("sort option is true");
            // sort by the programming languages
        }
        else
        {
            // sort by A -Z
        }
        if (remove == true)
        {
            // remove lines in the final file
        }
    }
    catch (DirectoryNotFoundException ex)
    {
        Console.WriteLine("ERROR: file path is invalid");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}, bundleOutputOption, bundleLangOption, bundleNoteOption, bundleAuthorOption, bundleSortOption, bundleRemoveOption);

rootCommand.AddCommand(bundleCommand);
rootCommand.InvokeAsync(args);


