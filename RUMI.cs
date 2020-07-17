using System;
using System.IO;
using Help;
using Address;

public class RUMI {
	
	static void Main(string[] args) {
		
		if (args.Length == 1 && (args[0] == "-a" || args[0] == "--address")) {
			Address.Address.ReadCurrentAddress();
		} else if (args.Length == 2 && (args[0] == "-a" || args[0] == "--address") && args[1] == "/new") {
			Address.Address.GetNewAddress();
		} else if (args.Length == 1 && (args[0] == "-h" || args[0] == "--help") || args.Length == 0) {
			Help.Help.DisplayHelp();
		} else {
			Console.WriteLine("Command not recognized, use \"rumi --help\"");
		}
		
	}
	
}