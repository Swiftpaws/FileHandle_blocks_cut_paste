//Setup
var dir = Directory.GetCurrentDirectory();
//File used in handle
var handleFilePath = Path.Combine(dir, "handleFile.txt");
using (File.Create(handleFilePath)) { }

//File used to cut/copy paste
var moveFilePath = Path.Combine(dir, "moveFile.txt");
using (File.Create(moveFilePath)) { }

//Blocks File.Move
File.OpenHandle(
    handleFilePath,
    mode: FileMode.Open,
    access: FileAccess.Read,
    share: FileShare.Delete | FileShare.ReadWrite
);

//Will throw Exception
try
{
    File.Move(moveFilePath, handleFilePath, true);
}
catch (Exception ex)
{
    System.Diagnostics.Debugger.Break();
}

//Works
File.Copy(moveFilePath, handleFilePath, true);