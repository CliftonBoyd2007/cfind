using System;
using System.CommandLine;
using System.CommandLine.Parsing;
using System.CommandLine.Invocation;

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
        Argument<String> patternArg = new("pattern")
        {
            Description = "The pattern to search for."
        };
        Argument<String> dirArg = new("dir")
        {
            Description = "The directory to search."
        };
        // Define the root command and add the above arguments to it.
        var rootCmd = new RootCommand("Finds files whose names contains the specified pattern.");
        rootCmd.Arguments.Add(patternArg);
        rootCmd.Arguments.Add(dirArg);

        rootCmd.SetAction(parseResult =>
        {
            String? pattern = parseResult.GetValue(patternArg);
            String? dir = parseResult.GetValue(dirArg);
            // Other code not implemented yet. Argument parsing works.
        });
        ParseResult parseResult = rootCmd.Parse(args);

        return parseResult.Invoke();




    }
}
