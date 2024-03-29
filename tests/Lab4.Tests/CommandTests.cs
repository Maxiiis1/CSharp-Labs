using Itmo.ObjectOrientedProgramming.Lab4.Services.FileSystemCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Services.RequestsParse;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class CommandTests
{
    [Fact]
    public void Handle_ShouldReturnConnectCommand_WhenConnectRequest()
    {
        var command = new ConnectRequestHandler().Handle("connect C:\\Users\\maxfi\\Desktop\\testingFS\\mainDirectory -m local") as Connect;

        Assert.True(command?.Address == "C:\\Users\\maxfi\\Desktop\\testingFS\\mainDirectory" && command.Mode == "local");
    }

    [Fact]
    public void Handle_ShouldReturnDisconnectCommand_WhenDisconnectConnectRequest()
    {
        IFileSystemCommand? command = new DisconnectRequestHandler().Handle("disconnect");

        Assert.True(command is Disconnect);
    }

    [Fact]
    public void Handle_ShouldReturnCopyCommand_WhenCopyRequest()
    {
        var command = new FileCopyRequestHandler().Handle("file copy file1.txt dictionary2") as Copy;

        Assert.True(command?.SourcePath == "file1.txt" && command.DestinationPath == "dictionary2");
    }

    [Fact]
    public void Handle_ShouldReturnRenameCommand_WhenRenameRequest()
    {
        var command = new FileRenameRequestHandler().Handle("file rename file1.txt file2.txt") as Rename;

        Assert.True(command?.Path == "file1.txt" && command.Name == "file2.txt");
    }

    [Fact]
    public void Handle_ShouldReturnMoveCommand_WhenMoveRequest()
    {
        var command = new FileMoveRequestHandler().Handle("file move file1.txt dictionary2") as MoveFile;

        Assert.True(command?.SourcePath == "file1.txt" && command.DestinationPath == "dictionary2");
    }

    [Fact]
    public void Handle_ShouldReturnDeleteCommand_WhenDeleteRequest()
    {
        var command = new FileDeleteRequestHandler().Handle("file delete file1.txt") as Delete;

        Assert.True(command?.Path == "file1.txt");
    }

    [Fact]
    public void Handle_ShouldReturnShowFileContentCommand_WhenShowRequest()
    {
        var command = new FileShowRequestHandler().Handle("file show file1.txt -m console") as ShowFileContent;

        Assert.True(command?.Path == "file1.txt" && command.Mode == "console");
    }

    [Fact]
    public void Handle_ShouldReturnGotoCommand_WhenGotoRequest()
    {
        var command = new GoToRequestHandler().Handle("tree goto dictionary2") as GoToCommand;

        Assert.True(command?.Path == "dictionary2");
    }

    [Fact]
    public void Handle_ShouldReturnTreeListCommand_WhenTreeListRequest()
    {
        var command = new ListRequestHandler().Handle("tree list -d 3") as TreeList;

        Assert.True(command?.Depth == "3");
    }
}