using System;
using System.CommandLine;
using System.CommandLine.Parsing;
using System.CommandLine.Invocation;
using cfind.Engine;
using System.Linq.Expressions;

namespace cfind.BuildCommand;

class Program
{
    static int Main(string[] args)
    {
        return BuildRootCmd(args);
    }

    private static int BuildRootCmd(String[] args)
    {
        // Define the structure of the root command 
        // cfind <pattern> <dir> 
        // We will define optional flags later
        // Arguments:
        // pattern, dir 
        var patternArg = new Argument<string>("pattern")
        {
            Description = "The pattern to search for."
        };
        var dirArg = new Argument<string>("dir")
        {
            Description = "The directory to perform the search.",
            DefaultValueFactory = _ =>
                Directory.GetCurrentDirectory()
        };
        var flatOption = new Option<bool>("--flat")
        {
            Description = "Disable recursive search."
        };
        var verboseOption = new Option<bool>("--verbose", "-v")
        {
            Description = "Toggle more detailed output."
        };
        var rootCmd = new RootCommand("A utility that finds files based on a pattern within their name.");
        rootCmd.Arguments.Add(patternArg);
        rootCmd.Arguments.Add(dirArg);
        rootCmd.Options.Add(flatOption);
        rootCmd.Options.Add(verboseOption);


        rootCmd.SetAction(parseResult =>
        {
            string? pattern = parseResult.GetValue(patternArg);
            string? dir = parseResult.GetValue(dirArg);
            bool flat = parseResult.GetValue(flatOption);
            bool verbose = parseResult.GetValue(verboseOption);
            try
            {
                var scanner = new FileScanner(dir!, pattern!, flat, verbose);

                foreach (var file in scanner.EnumerateMatches())
                {
                    Console.Write(file + " ");
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error has occurred: {ex.Message}");
                Environment.Exit(1);
            }
        });

        ParseResult parseResult = rootCmd.Parse(args);

        return parseResult.Invoke();
    }
}