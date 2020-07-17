using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Address;

public class DiagnosticAddress {
	
	static void Main() {
		
		int diagnosticCounter = 0;
		
		for (int i = 0; i < 100; i++) {
				Address.Address.GetNewAddress();
				diagnosticCounter += 1;
				Console.WriteLine(diagnosticCounter);
		}
		
		while (diagnosticCounter < 100) {
			Thread.Sleep(100);
		}
		
	}
	
}