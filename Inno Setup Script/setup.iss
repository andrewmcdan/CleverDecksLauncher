; -- Example2.iss --
; Same as Example1.iss, but creates its icon in the Programs folder of the
; Start Menu instead of in a subfolder, and also creates a desktop icon.

; SEE THE DOCUMENTATION FOR DETAILS ON CREATING .ISS SCRIPT FILES!

[Setup]
AppName=CleverDecks Launcher
AppVersion=1.0
WizardStyle=modern
DefaultDirName={autopf}\CleverDecks Launcher
; Since no icons will be created in "{group}", we don't need the wizard
; to ask for a Start Menu folder name:
DisableProgramGroupPage=yes
UninstallDisplayIcon={app}\CleverDecksLauncher.exe
Compression=lzma2
SolidCompression=yes
OutputDir=c:/CleverDecksLauncher

[Files]
Source: "CleverDecksLauncher.exe"; DestDir: "{app}"
Source: "CleverDecksLauncher.dll"; DestDir: "{app}"
Source: "CleverDecksLauncher.deps.json"; DestDir: "{app}"
Source: "CleverDecksLauncher.runtimeconfig.json"; DestDir: "{app}"
Source: "QRCoder.dll"; DestDir: "{app}"
Source: "dotnet_check.bat"; DestDir: "{tmp}"; Flags: deleteafterinstall
Source: "dotnet-sdk-8.0.203-win-x64.exe"; DestDir: "{tmp}"; Flags: deleteafterinstall

[Icons]
Name: "{autoprograms}\CleverDecks Launcher"; Filename: "{app}\CleverDecksLauncher.exe"
Name: "{autodesktop}\CleverDecks Launcher"; Filename: "{app}\CleverDecksLauncher.exe"

[Code]
function IsDotNetCoreInstalled(Version: string): Boolean;
var
  TempFileName: string;
  OutputLines: TStringList;
  I: Integer;
  ExitCode: Integer;
begin
  Result := False;
  ExtractTemporaryFile('dotnet_check.bat');
  TempFileName := ExpandConstant('{tmp}\output.txt');
  if Exec(ExpandConstant('{tmp}\dotnet_check.bat'),'',ExpandConstant('{tmp}'), SW_HIDE, ewWaitUntilTerminated, ExitCode) then
  begin
    // Check if the output file exists and read from it
    if FileExists(TempFileName) then
    begin
      OutputLines := TStringList.Create;
      try
        OutputLines.LoadFromFile(TempFileName);
        // Search for the version string in the output lines
        for I := 0 to OutputLines.Count - 1 do
        begin
          if Pos(Version, OutputLines.Strings[I]) > 0 then
          begin
            Result := True;
            Break;
          end;
        end;
      finally
        OutputLines.Free;
      end;
    end;
    DeleteFile(TempFileName);
  end
  else
  begin
    MsgBox('Failed to execute "dotnet --list-runtimes". Please ensure .NET Core is installed and the "dotnet" command is available in the system path.', mbError, MB_OK);
  end;
end;

function InitializeSetup(): Boolean;
var
  ErrorCode: Integer;
begin
  if not IsDotNetCoreInstalled('.NETCore.App 8') then
  begin
    // Prompt user to install .NET Core 8.0
    if MsgBox('.NET Core 8.0 is required for this application but was not detected. Would you like to download it now?', mbConfirmation, MB_YESNO) = IDYES then
    begin
      // Assuming the .NET Core installer is included in setup files
      if not ShellExec('', ExpandConstant('{tmp}\dotnet-sdk-8.0.203-win-x64.exe'), '', '', SW_SHOW, ewWaitUntilTerminated, ErrorCode) then
      begin
        MsgBox('Failed to execute the .NET Core 8.0 installer. Setup will now exit.', mbError, MB_OK);
        Result := False; // Abort installation
        Exit;
      end
      else
      begin
        // Optionally, recheck if .NET Core 8.0 was successfully installed
        if not IsDotNetCoreInstalled('.NETCore.App 8') then
        begin
          MsgBox('.NET Core 8.0 installation failed. Please manually install .NET Core 8.0 and retry installation. Setup will now exit.', mbError, MB_OK);
          Result := False; // Abort installation
          Exit;
        end;
      end;
    end
    else
    begin
      Result := False; // Abort installation if the user chooses not to install .NET Core 8.0
      Exit;
    end;
  end;

  Result := True; // Continue with installation if .NET Core 8.0 is installed or successfully installed
end;

