/*//exe1 bundle --output D:\folder\bundleFile.txt
using System.CommandLine;


var rootCommand = new RootCommand("Root command for file bundler CLI");
var bundleCommand = new Command("bundle", "Bundle code files to a single file");
var bundleOutputOption = new Option<FileInfo>("--output", "file path and name");
var bundleNoteOption = new Option<bool>("--note", "file path and name");
var bundleLangOption = new Option<List<string>>("--lang", "required langueges for the bundled output")
{
    IsRequired = true,
};

bundleCommand.AddOption(bundleOutputOption);
bundleCommand.AddOption(bundleLangOption);

bundleCommand.SetHandler((output) =>
{
    try
    {
        Console.WriteLine(output.Name);

        File.Create(output.FullName);
        Console.WriteLine("file created successfully" + " " + string.Join(", ", bundleLangOption));

    }
    catch (DirectoryNotFoundException ex)
    {
        Console.WriteLine("ERROR: file path is invalid");
    }
}, bundleOutputOption);

bundleCommand.Handler = CommandHandler.Create<FileInfo, List<string>>((output, languages) =>
{
    try
    {
        File.Create(output.FullName);
        Console.WriteLine("File created successfully");

        if (languages.Any())
        {
            Console.WriteLine("List of selected languages:");
            foreach (var language in languages)
            {
                Console.WriteLine(language);
            }
        }
        else
        {
            Console.WriteLine("No languages selected.");
        }
    }
    catch (DirectoryNotFoundException ex)
    {
        Console.WriteLine("ERROR: File path is invalid");
    }
});
rootCommand.AddCommand(bundleCommand);
rootCommand.InvokeAsync(args);*/

using System;
using System.CommandLine;
using System.CommandLine.Invocation; // Import the Invocation namespace
using System.IO;
using System.Linq;
using System.Collections.Generic; // Import the namespace for List

var rootCommand = new RootCommand("Root command for file bundler CLI");
var bundleCommand = new Command("bundle", "Bundle code files to a single file");

var bundleOutputOption = new Option<FileInfo>("--output", "file path and name");
var bundleNoteOption = new Option<bool>("--note", "Include source code references as comments in the bundled file"); // Added note option
var bundleLangOption = new Option<List<string>>("--lang", "required languages for the bundled output")
{
    IsRequired = true,
};

bundleCommand.AddOption(bundleOutputOption);
bundleCommand.AddOption(bundleLangOption);
bundleCommand.AddOption(bundleNoteOption);

bundleCommand.Handler = CommandHandler.Create<FileInfo, List<string>, bool>((output, languages, includeNotes) =>
{
    try
    {
        File.Create(output.FullName);
        Console.WriteLine("File created successfully");

        if (includeNotes)
        {
            Console.WriteLine("Including source code references as comments.");
        }

        if (languages.Any())
        {
            Console.WriteLine("List of selected languages:");
            foreach (var language in languages)
            {
                Console.WriteLine(language);
            }
        }
        else
        {
            Console.WriteLine("No languages selected.");
        }
    }
    catch (DirectoryNotFoundException ex)
    {
        Console.WriteLine("ERROR: File path is invalid");
    }
});


rootCommand.AddCommand(bundleCommand);
rootCommand.Invoke(args);
