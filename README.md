# CleverDecksLauncher

This is a simple launcher for the CleverDecks project. It runs in the system tray and allows the user to start the CleverDecks server and client with a single click.

## Installation

### Option 1: Download the pre-built executable

You can download the pre-built executable from the [releases page](https://github.com/andrewmcdan/CleverDecksLauncher/releases). Once downloaded, extract the zip file.

### Option 2: Build from source

1. Clone the repository
2. Open the solution in Visual Studio
3. Build the solution
4. The executable will be in the `bin/Debug` or `bin/Release` directory
5. Profit

## Usage

You can run the executable directly, but only if you are using the fully packaged version of CleverDecks. In this case, the CleverDecks.exe file should be in the same directory as the CleverDecksLauncher.exe file.


Otherwise, you will need to specify the path to the index.js in the root of the CleverDecks project as a command line argument. This does require that you have Node.js installed on your system.
```
./CleverDecksLauncher.exe "C:\path\to\CleverDecks\index.js"
```

My preferred method is to create a shortcut to the executable and add the path to the index.js file as an argument in the shortcut's properties.

Once running, the launcher will appear in the system tray. Right-clicking the icon will show the context menu, which allows you to see the logs, quit, and open the CleverDecks web interface.

## License

CleverDecksLauncher is licensed under the AGL-3.0 license. See the LICENSE file for more information. This software use the QRCoder library, which is licensed under the MIT license. See [codebude/QRCoder](https://github.com/codebude/QRCoder) for more information.