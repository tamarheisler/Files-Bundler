# Files-Bundler-CLI-command
A new CLI command that enables the user to bundle few code files to one readable and neat file.

Just run the command  <fib bundle> to bundle the code files in your directory to a one file.

Add options to your command to enable another featurs:


1.  --language -> (required) Add different programming languages to instruct the file bundler tool to bundle only the code files from those languages. 

2.  --output -> Add the bundle file path and name. Default path is current path.

3.  --note -> Whether to list the source code as a comment in the bundle file.

4.  --sort -> The order of copying the code files, according to the alphabet of the file name or according to the type of code. (Default value is A-Z on the files' names)

5.  --remove-empty-lines -> Add this option to tell the program to delete blank lines in the source files.

6.  --author -> Type it and the program's creator name to register the name of the creator of the file.

In order to bundle code files in the directory <dir> just open the CLI in the directory and type: 

<fib bundle --language C C++ Java --output file1.txt --note> then you will get a new bundled file (file1.txt) 

with all the C, C++ and Java files you have in your directory + the source of the code written in the buttom of file1.txt file.


# Setting the command to be active in the entire file space on the computer
After forking and downloading the files-bundler, the command is enabled only in the project directory, as a local project.
In order to enable the command in all the directories of your computer ypu have to set this project path to an [enviroment variable]([url](https://www.c-sharpcorner.com/article/how-to-addedit-path-environment-variable-in-windows-11/)https://www.c-sharpcorner.com/article/how-to-addedit-path-environment-variable-in-windows-11/), follow this steps:
1. On the Windows taskbar, right-click the Windows icon and select System.

2. In the Settings window, under Related Settings, click Advanced system settings.

3. On the Advanced tab, click Environment Variables.

4. Click New to create a new environment variable paste the project path in the blank line.
   
5. click Apply and then OK to have the change take effect.

- Example for running a command:
  fib bundle --output file1.txt --lang "c c++ java javascript" --sort --author "anonimus"
  -> Will return:
     an output file in the current directory, that includes, ordered by the programming language,
     all the files that are written in c, c++, java and javascript and are under the current directory.
     Including "anonimus" as the author, on the buttom of the output file (file1.txt)


Enjoy!
