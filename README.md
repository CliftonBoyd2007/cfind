# cfind 

A simple command line utility for finding files with a given string in their name.


## Installation 

Clone the repo 
```bash 
git clone https://github.com/CliftonBoyd2007/cfind
```
Then run:
```bash
dotnet publish 
```
Then move the binary into your path, wherever that may be.

Note that, because this is Native AOT-compiled, it may fail on Linux or Windows (I have not been able to get it to work). 
However, you can either remove the 
```xml
<PublishAot>true</PublishAot>
``` 
line from cfind.csproj to solve this problem. Be aware that this defeats the purpose of it being Native AoT compiled, as I intended this to be able to run on machines without the dotnet runtime installed, and without making the binary enormous by packaging the runtime with it.

## Intent of this Tool 

I built this tool as a command line file searcher by pattern, because I wanted to find all of the audio files within my Messages folder on my Mac without manually traversing it myself. 

## Usage 

```bash
cfind <pattern> <dir> [options]
```
When a file is found, its path is printed to the console. For example: 
```bash
cfind obj . # Search for files or directories in the current folder with 'obj' in their name 
# Output:  ./obj # The only directory with that pattern in its name 
```

## Optional Flags

--flat Disables recursive search; only searches the top-level directory. 

This is useful if you know that a file with a specific pattern is in the top-level directory and you want to avoid extra output from files within its subdirectories that get printed to the console.

Example Usage:

```bash
cfind 2022 ./testDir --flat 
# Files in testDir:
# 2020-06-06.txt
# 2022-01-18.txt
# 2025-02-03.txt
# 2025-04-03.txt
# 2025-04-08.txt
# dir2
# dir2/2022-01--08.txt
# dir2/2023-08-08.txt
# dir2/2026-01--08.txt

# Output: ./2022-01-18.txt 
```

Without --flat:

Output: ./2022-01-18.txt ./dir2/2022-01--08.txt 

### Other Flags 

-?, -h, --help Print usage information and exit.
--version Print application version and exit.
