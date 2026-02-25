# cfind 
## 1. Overview

cfind is a tool that can find files matching a certain criteria (e.g., file name, sizes, etc.). 

The goals of this tool are:
- Serve as a friendlier alternative to the find tool built into most Unix systems.
- Expand on a previous tool I wrote, catchpat "{insert link to that project here later.}".



## 2. Requirements
### 2.1. Functional Requirements
Command Signature: The basic signature of the tool must follow the following structure:
cfind <pattern> <dir> [OptionalFlags]

Global Flags: There must be **at least** two global flags:
* -h, --help. This must print a help message and exit.
* -v, --version. This must print the application version and exit.

**A Note on Global and Optional Flags:**
A **global flag** is a flag that, when set, short-circuits the execution of the program, regardless of the presence of other flags and arguments.
For example:
cfind --version # Prints the application version and exits.
cfind --help # Prints help message and exits.

Optional Flags: These alter the behavior of the execution of the program, and thus will work in conjunction with <pattern> and <dir>. 
For example:
cfind <pattern> <dir> --copy # If implemented, copies files whose name contains pattern.
cfind <pattern> <dir> --delete # If implemented, deletes files whose name contains pattern.

Flag/Argument Precedence: If <pattern> and <dir> are present, and a global flag is set, then the global flag must take precedence over the preceding arguments. 
For example:
cfind <pattern> <dir> --help # Prints helps and exits.
    cfind <pattern> <dir> --version # Prints application version and exits.
Program execution must not continue after any global flag is set and the method for which they depend upon completes.


## 2.2 Error Handling

### 2.2.1 User Input Validation & Resolution

- Argument Validation: If <pattern> is empty or only contains whitespace, the program must print an error to stderr and exit.
- Exit Code: 2

- Argument Resolution: If <dir> is omitted, the tool must run in the current directory.

- Argument Validation: If <dir> does not exist, or the user does not have sufficient permissions to access it, the tool must print a message to stderr and exit.
- Exit Code: 2

- Argument Validation: If <dir> is a file, the tool must print a message to stderr and exit.
Exit Code: 2.

### 2.2.2 Runtime Error Handling 

- Permissions: If the user does not have sufficient permissions to access a file or directory in the search path, then the tool must skip that object. The search must continue.
- Tool Output: If no results are found, there must be no output from the tool.
Exit Code: 0


### 2.2.3 Error Styling and Display

- Error Streams: All errors, warnings, and help/usage messages must be printed to stderr.

- Error Output: All user input that appears in error messages must appear in single quotes. 
### Examples
- Invalid Flag Set: 
cfind <pattern> <dir> --invalid_flag 
Expected Output: "Invalid Option: '--invalid_flag'"
- Directory Does not Exist 
cfind <pattern> /path/to/dir/that/does/not/exist 
Expected Output: "Directory, '/path/to/dir/that/does/not/exist', does not exist."


## 3. Technical Architecture 
### 3.1. Search Logic 

**Simple Implementation for Now:**
Search Strategy: Look for files whose name contains the pattern specified by the user; for example:
cfind "alpha" 
Output:
alphabet.txt myalpha.txt
