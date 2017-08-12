using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
namespace FoodsterApp.BLL
{
    public class Recommender
    {
        // This code requires the Nuget package Microsoft.AspNet.WebApi.Client to be installed.
// Instructions for doing this in Visual Studio:
// Tools -> Nuget Package Manager -> Package Manager Console
// Install-Package Microsoft.AspNet.WebApi.Client


            public static async Task<string> InvokeRequestResponseService(string UserID)
            {
                using (var client = new HttpClient())
                {
                    var scoreRequest = new
                    {
                        Inputs = new Dictionary<string, List<Dictionary<string, string>>>() {
                        {
                            "input1",
                            new List<Dictionary<string, string>>(){new Dictionary<string, string>(){
                                            {
                                                "UserID", UserID
                                            },
                                            {
                                                "FoodID", ""
                                            },
                                            {
                                                "Rating", ""
                                            },
                                }
                            }
                        },
                    },
                        GlobalParameters = new Dictionary<string, string>()
                        {
                        }
                    };

                    const string apiKey = "7SKQSs8Q877D7NkmHFYYVDuZk3uV7Ga5xVua4L37+SX90gO+HmI0iOZF5+u3NqUpCgPowD/RW2vsUn5lY06Q+A=="; // Replace this with the API key for the web service
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
                    client.BaseAddress = new Uri("https://ussouthcentral.services.azureml.net/subscriptions/5b916b361f9c4252859fad18854a49a0/services/ce822273722f477eaf976c1cbb88226b/execute?api-version=2.0&format=swagger");

                    // WARNING: The 'await' statement below can result in a deadlock
                    // if you are calling this code from the UI thread of an ASP.Net application.
                    // One way to address this would be to call ConfigureAwait(false)
                    // so that the execution does not attempt to resume on the original context.
                    // For instance, replace code such as:
                    //      result = await DoSomeTask()
                    // with the following:
                    //      result = await DoSomeTask().ConfigureAwait(false)

                    HttpResponseMessage response = await client.PostAsJsonAsync("", scoreRequest);

                return await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Result: {0}", result);
                    }
                    else
                    {
                        Console.WriteLine(string.Format("The request failed with status code: {0}", response.StatusCode));

                        // Print the headers - they include the requert ID and the timestamp,
                        // which are useful for debugging the failure
                        Console.WriteLine(response.Headers.ToString());

                        string responseContent = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(responseContent);
                    }
                }
            }
        
    
}
}