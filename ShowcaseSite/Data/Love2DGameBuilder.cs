using ShowcaseSite.Interfaces;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System;

namespace ShowcaseSite.Data
{
    public class Love2DGameBuilder : IGameBuilder
    {
        public void BuildGame(string gameName)
        {
            var errorMsg = "";
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = @"pwsh",
                Arguments = $".\\scripts\\build-love-game.ps1 {gameName}",
                RedirectStandardOutput = true,
                UseShellExecute = false
            };
            Process gameBuildProc = new Process { StartInfo = startInfo };
            gameBuildProc.Start();
            gameBuildProc.WaitForExit();
            if (gameBuildProc.ExitCode != 0)
            {
                throw new InvalidOperationException($"Building {gameName} failed with the error {errorMsg}");
            }
        }
    }
}
