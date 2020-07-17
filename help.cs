using System;
using System.IO;

namespace Help {
	
	public static class Help {
		
		public static void DisplayHelp() {
			
			Console.WriteLine("--help|-h\t\t\t\t\tcommand list");
			Console.WriteLine("--address|-a [/new]\t\t\t\tdisplay existing address [or get new address]");
			Console.WriteLine("--send|-s ADDRESS|PARTY_NAME PLAINTEXT_MESSAGE\tsend text message");
			Console.WriteLine("--send|-s ADDRESS|PARTY_NAME /f:FILE_PATH\tsend file");
			Console.WriteLine("--receive|-r [/enable|/disable]\t\t\ttoggle receiving [or set to enable or disable receiving]");
			Console.WriteLine("--party|-p PARTY_NAME ADDRESS|PARTY_NAME,... \tcreate or change a party containing addresses or other parties");
			Console.WriteLine("--party|-p /a PARTY_NAME ADDRESS|PARTY_NAME,... add to an existing party");
			Console.WriteLine("--party|-p /r PARTY_NAME ADDRESS|PARTY_NAME,... remove from an existing party");
			Console.WriteLine("--party|-p /d PARTY_NAME \t\t\tdelete a party");
			Console.WriteLine("--party|-p /all \t\t\t\tshow all party info");
			Console.WriteLine("--party|-p PARTY_NAME \t\t\t\tshow specific party info");
			
		}
		
	}
	
}