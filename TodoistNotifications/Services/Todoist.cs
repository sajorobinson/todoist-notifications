namespace Services
{
    public class Todoist
    {
        const string ApiBaseUrl = "https://api.todoist.com/rest/v2/";

        public static async Task<string> GetActiveTasks()
        {
            string token = Private.Credentials.TodoistApiToken();
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"{ApiBaseUrl}tasks");
            request.Headers.Add("Authorization", token);
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return jsonString;
            }
            else
            {
                return $"Error: Response status code {response.StatusCode}";
            }
        }
    }
}