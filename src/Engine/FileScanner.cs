using System;
using System.IO;


namespace cfind.Engine;

public class FileScanner
{
    private readonly string _dir;
    private readonly string _pattern;
    private readonly bool _recursive;
    private readonly bool _verbose;
    public FileScanner(string dir, string pattern, bool recursive, bool verbose)
    {
        
        _recursive = recursive;

        _verbose = verbose;
        if (string.IsNullOrEmpty(dir) || string.IsNullOrWhiteSpace(dir))
        {
            _dir = Directory.GetCurrentDirectory();

        } else
        {
            _dir = dir;
        }
        if (pattern is null)
        {
            _pattern = "";
        } else
        {
            _pattern = pattern;
        }

    }

}