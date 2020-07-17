using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Address {
	
	public class Address {
		
		static async Task<HttpResponseMessage> HttpResponse(HttpClient client) {
			
			var httpResponseMessage = await client.GetAsync("http://[::1]:8080/newAddress");
			return httpResponseMessage;
			
		}
		
		static async Task<string> HttpResponseBody(HttpResponseMessage response) {
			
			return await response.Content.ReadAsStringAsync();
			
		}
		
		static void GetNewAddress() {
			
			string responseBody = "";
			Task.Run(() => {
				using (Process process = new Process()) {
					process.StartInfo.UseShellExecute = false;
					process.StartInfo.CreateNoWindow = true;
					process.StartInfo.FileName = "goAddress.exe";
					process.Start();
				}
			});
		
			while (responseBody == "") {
				
				try {
			
					HttpClient client = new HttpClient();
					HttpResponseMessage response = HttpResponse(client).Result;
					responseBody = HttpResponseBody(response).Result;
					Console.WriteLine(responseBody);
					using (StreamWriter streamWriter = new StreamWriter("address.txt")) {
						streamWriter.WriteLine(responseBody);
					}
				
				} catch(AggregateException e) {
					
					Thread.Sleep(100);
					
				}
				
			}
			
		}
		
		static void ReadCurrentAddress() {
			
			using (StreamReader sr = new StreamReader("address.txt")) {
				Console.WriteLine(sr.ReadLine());
			}
			
		}
			
		static void Main(string[] args) {
			
			if (args.Length == 1 && args[0] == "/new") {
				GetNewAddress();
			} else if (args.Length == 0) {
				ReadCurrentAddress();
			} else {
				Console.WriteLine("Command not recognized");
			}
			
		}
		
	}
	
}