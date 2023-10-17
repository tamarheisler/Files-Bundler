using Files_Bundler;
using System.CommandLine;

var rootCommand = new RootCommand("Root command for file bundler CLI");
var bundleCommand = new Command("bundle", "Bundle code files to a single file");
var bundleOutputOption = new Option<FileInfo>("--output", "file path and name");
var bundleNoteOption = new Option<bool>("--note", "Include source code references as comments in the bundled file");
var bundleSortOption = new Option<bool>("--sort", "file path and name"); 
var bundleRemoveOption = new Option<bool>("--remove-empty-lines", "Remove empty lines in the code files");
var bundleAuthorOption = new Option<string>("--author", "file author name");
var bundleLangOption = new Option<string>("--lang", "required languages for the bundled output")
{
    IsRequired = true,
};

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
        List<string> filesNames = Functions.DirSearch(Directory.GetCurrentDirectory());
        filesNames = Functions.removeUnnecessaryLangs(filesNames);
        List<string> requestedFilesList = new List<string>();
        File.Create(output.FullName).Close();
        if (langueges == "all")
        {
            requestedFilesList = filesNames;
        }
        else
        {
            List<string> givenLangs = langueges.Split(' ').ToList();
            List<string> validProgrammingLanguages = Functions.GetListOfProgrammingLanguages();
            bool givenLangsValidation = Functions.checkAllGivenLangsValidation(givenLangs, validProgrammingLanguages);
            if (!givenLangsValidation)
            {
                throw new Exception("ERROR: one or more of the given languages is invalid");
            }
            foreach (var file in filesNames)
            {
                string fileLang = Functions.GetLanguageFromExtension(file);
                bool includeFile = false;
                foreach (var lang in givenLangs)
                {
                    if (fileLang == lang)
                    {
                        includeFile = true;
                    }
                }
                if (includeFile == true)
                {
                    requestedFilesList.Add(file);
                }
            }
        }
        if (sort == true)
        {
            Console.WriteLine("sort option is true");
            requestedFilesList = Functions.sortByProgrammingLangs(requestedFilesList);
        }
        else
        {
            requestedFilesList = requestedFilesList.OrderBy(name => Path.GetFileName(name)).ToList();
        }
        try
        {
            using (var outputFile = new FileStream(output.FullName, FileMode.Create))
            {
                foreach (string fileLocation in requestedFilesList)
                {
                    using (var inputFile = new FileStream(fileLocation, FileMode.Open))
                    {
                        inputFile.CopyTo(outputFile);
                    }
                }
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        if (remove == true)
        {
            Console.WriteLine("remove");
            try
            {
                bool success = Functions.RemoveEmptyLinesFromFile(output.FullName);

                if (success)
                {
                    Console.WriteLine("Empty lines removed from the file.");
                }
                else
                {
                    Console.WriteLine("Failed to remove empty lines from the file.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        try
        {
            if (author != null)
            {
                using (StreamWriter writer = new StreamWriter(output.FullName, true))
                {
                    writer.WriteLine("\nAuthor: " + author);
                }
            }
            if (note == true)
            {
                using (StreamWriter writer = new StreamWriter(output.FullName, true))
                {
                    writer.WriteLine("\nnote is on!");
                }
            }
            Console.WriteLine("Files bundled successfully to " + output.FullName);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    catch (DirectoryNotFoundException ex)
    {
        Console.WriteLine("ERROR: output file path is invalid");
    }
    catch (Exception ex)
    {
        Console.WriteLine("An error occurred: " + ex.Message);
    }
}, bundleOutputOption, bundleLangOption, bundleNoteOption, bundleAuthorOption, bundleSortOption, bundleRemoveOption);

rootCommand.AddCommand(bundleCommand);
rootCommand.InvokeAsync(args);
