using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FilesSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Provider;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Strategies.ShowFileStrategies;
using Itmo.ObjectOrientedProgramming.Lab4.Services.FileSystemCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Services.PathValidation;
using Itmo.ObjectOrientedProgramming.Lab4.Services.RequestResults;
using Itmo.ObjectOrientedProgramming.Lab4.Services.RequestsParse;

namespace Itmo.ObjectOrientedProgramming.Lab4.Program;

public class ProgramRunner
{
    private static void Main()
    {
        IReadOnlyDictionary<string, IFileSystem> supportedFileSystems =
            new Dictionary<string, IFileSystem>
            {
                { "local", new LocalFileSystem() },
            };
        IReadOnlyDictionary<string, IShowStrategy> supportedShowStrategies =
            new Dictionary<string, IShowStrategy>
            {
                { "console", new ConsoleStrategy() },
            };

        IFileSystemProvider fileSystemProvider = new FileSystemProvider(supportedFileSystems, supportedShowStrategies, new PathValidator());

        var connectHandler = new ConnectRequestHandler();
        connectHandler
            .SetNext(new FileCopyRequestHandler())
            .SetNext(new FileMoveRequestHandler())
            .SetNext(new GoToRequestHandler())
            .SetNext(new ListRequestHandler())
            .SetNext(new FileShowRequestHandler())
            .SetNext(new FileRenameRequestHandler())
            .SetNext(new DisconnectRequestHandler())
            .SetNext(new FileDeleteRequestHandler());

        while (true)
        {
            Console.Write("Введите запрос:");
            string? request = Console.ReadLine();
            if (request == "stop")
            {
                break;
            }

            if (!string.IsNullOrWhiteSpace(request))
            {
                IFileSystemCommand? systemCommand = connectHandler.Handle(request);
                if (systemCommand is null)
                {
                    Console.WriteLine("Wrong enter");
                    continue;
                }

                RequestResult requestResult = systemCommand.Execute(fileSystemProvider);
                if (requestResult is RequestResult.RequestError result)
                {
                    Console.WriteLine(result.Problem);
                    continue;
                }

                Console.WriteLine("Success request!");
            }
        }
    }
}

// connect C:\Users\maxfi\Desktop\testingFS\mainDirectory -m local
// file show Directory2\file1.txt -m console
// tree goto Directory2\directory3
// tree list -d 3