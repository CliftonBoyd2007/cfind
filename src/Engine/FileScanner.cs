using System;
using System.IO;


namespace cfind.Engine;

public class FileScanner
{
    private readonly string _dir;
    private readonly string _pattern;
    private readonly bool _flat;
    private readonly bool _verbose;
    private readonly EnumerationOptions _options;
    public FileScanner(string dir, string pattern, bool flat, bool verbose)
    {

        _flat = flat;

        _verbose = verbose;
        if (string.IsNullOrEmpty(dir) || string.IsNullOrWhiteSpace(dir))
        {
            _dir = Directory.GetCurrentDirectory();

        }
        else
        {
            _dir = dir;
        }
        if (pattern is null)
        {
            _pattern = "";
        }
        else
        {
            _pattern = pattern;
        }
        _options = new EnumerationOptions()
        {
            IgnoreInaccessible = true,
            RecurseSubdirectories = !flat,
            AttributesToSkip = FileAttributes.System,
        };

    }
    public IEnumerable<string> EnumerateMatches()
    {
        var files = Directory.EnumerateFiles(_dir, "*", _options);
        var dirs = Directory.EnumerateDirectories(_dir, "*", _options);
        foreach (var file in files)
        {
            string fileName = Path.GetFileName(file);
            if (fileName.Contains(_pattern, StringComparison.OrdinalIgnoreCase))
            {
                yield return file;
            }

        }
        foreach (var dir in dirs)
        {
            string dirName = Path.GetFileName(dir);
            if (dirName.Contains(_pattern, StringComparison.OrdinalIgnoreCase))
            {
                yield return dir;
            }
        }
    }

}