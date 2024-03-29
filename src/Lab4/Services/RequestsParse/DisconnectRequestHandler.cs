using Itmo.ObjectOrientedProgramming.Lab4.Services.FileSystemCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.RequestsParse;

public class DisconnectRequestHandler : RequestHandlerBase
{
    public override IFileSystemCommand? Handle(string request)
    {
        string[] args = request.Split(' ');
        if (args[0] == "disconnect")
        {
            IFileSystemCommand command = new Disconnect();
            return command;
        }

        return NextCommandHandler?.Handle(request);
    }
}