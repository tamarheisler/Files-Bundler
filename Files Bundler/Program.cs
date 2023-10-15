//exe1 bundle --output D:\folder\bundleFile.txt
using System.CommandLine;


var rootCommand = new RootCommand("Root command for file bundler CLI");
var bundleCommand = new Command("bundle", "Bundle code files to a single file");
var bundleOutputOption = new Option<FileInfo>("--output", "file path and name");
var bundleNoteOption = new Option<bool>("--note", "Include source code references as comments in the bundled fil");
var bundleLangOption = new Option<List<string>>("--lang", "required langueges for the bundled output")
{
    IsRequired = true,
};

bundleCommand.AddOption(bundleOutputOption);
bundleCommand.AddOption(bundleLangOption);

bundleCommand.SetHandler((output, langueges, note ) =>
{
    try
    {
        Console.WriteLine("hello " + output.Name);

        File.Create(output.FullName);
        Console.WriteLine("file created successfully" + " " + string.Join(", ", bundleLangOption));
        using (StreamWriter writer = new StreamWriter(output.FullName))
        {
            writer.WriteLine("Hello new file!");
        }
        if (langueges.Any()) //check the lang
        {
            Console.WriteLine("there is langs in!");
        }
        if (note == true) //check the note
        {
            Console.WriteLine("note option is true");
        }
    }
    catch (DirectoryNotFoundException ex)
    {
        Console.WriteLine("ERROR: file path is invalid");
    }
}, bundleOutputOption, bundleLangOption, bundleNoteOption);


rootCommand.AddCommand(bundleCommand);
rootCommand.InvokeAsync(args);
