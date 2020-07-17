using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Address {
	
	public static class Address {
		
		static async Task<HttpResponseMessage> HttpResponse(HttpClient client) {
			
			var httpResponseMessage = await client.GetAsync("http://[::1]:8080/newAddress");
			return httpResponseMessage;
			
		}
		
		static async Task<string> HttpResponseBody(HttpResponseMessage response) {
			
			return await response.Content.ReadAsStringAsync();
			
		}
		
		public static void GetNewAddress() {
			
			int processAttemptCounter = 0;
		ProcessAttempt:
			using (Process process = new Process()) {
			
				string responseBody = "";
				process.StartInfo.UseShellExecute = false;
				process.StartInfo.CreateNoWindow = true;
				process.StartInfo.FileName = "goAddress.exe";
				process.Start();
				
				int httpResponseAttemptCounter = 0;
				while (responseBody == "") {
					
					try {
				
						HttpClient client = new HttpClient();
						Task.Run(() => {
							Thread.Sleep(3000);
							httpResponseAttemptCounter += 1;
						});
						if (httpResponseAttemptCounter >= 5) {
							processAttemptCounter += 1;
							if (processAttemptCounter >= 4) {
								Console.WriteLine("Error, timeout!");
								return;
							}
							try {
								process.CloseMainWindow();
							} catch (InvalidOperationException) {
								//process already closed
							}
							goto ProcessAttempt;
						}
						HttpResponseMessage response = HttpResponse(client).Result;
						responseBody = HttpResponseBody(response).Result;
						Console.WriteLine(responseBody);
						using (StreamWriter streamWriter = new StreamWriter("address.txt")) {
							streamWriter.WriteLine(responseBody);
						}
					
					} catch (AggregateException e) {
						
						Thread.Sleep(100);
						
						
					}
					
				}
				
				try {
					process.CloseMainWindow();
				} catch (InvalidOperationException) {
					//process already closed
				}
				
			}
			
		}
		
		public static void ReadCurrentAddress() {
			
			using (StreamReader sr = new StreamReader("address.txt")) {
				Console.WriteLine(sr.ReadLine());
			}
			
		}
		
	}
	
}