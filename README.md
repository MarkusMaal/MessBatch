# ![image](https://user-images.githubusercontent.com/45605071/158536310-f2df0bf1-7100-4354-94db-e2f33a7ef5fe.png) <span style="margin-bottom: 20px">MessBatch</span>
This program allows you to semi-nondestructively corrupt batch files.<br/><br/>
![image](https://user-images.githubusercontent.com/45605071/158531943-299602ce-7cc2-41dc-878c-f557e6972c90.png)<br/>
## Features
- Line swapper: Swap lines causing weird things to happen
- Function swap: Redirect function references to other functions
- String corruptor: Swap characters in strings
- String reverser: Reverse random strings
- Substring corruptor: Modify substring ranges to random values
- Color swapper: Replace colors with other colors
- Variable strength value
- Does not lock files while they are open!
- Keeps original encoding and line endings!
- Compare original with the corrupted version
- Supports .cmd and .bat files
- Real time preview

## Files
- MainWindow.cs: The main window
- Compare.cs: The window where original version can be compared with the corrupted version!
- Program.cs: Intial function