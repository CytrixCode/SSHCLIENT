using Renci.SshNet;
using Renci.SshNet.Common;
using System.Text.RegularExpressions;

IDictionary<TerminalModes, uint> Modes = new Dictionary<TerminalModes, uint>();
Modes.Add(TerminalModes.ECHO, 53);

SshClient Client = new SshClient("bandit.labs.overthewire.org", 2220, "bandit0", "bandit0");
Client.Connect();
ShellStream Stream = Client.CreateShellStream("xterm", 80, 24, 800, 600, 1024, Modes);
String Output = Stream.Expect(new Regex(@"[$>]"));
Console.Write(Output);

string cmd = "cat readme";
Stream.WriteLine(cmd);
Output = Stream.Expect(new Regex(@"([$#>:])"));
Console.Write(Output);

Client.Disconnect();
Console.WriteLine("\nDisconnected");
Console.ReadLine();
