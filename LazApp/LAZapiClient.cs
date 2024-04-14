using System.Net.Http.Headers;
using LAZapp.Base;

namespace LAZapp;

public class LAZapiClient : HttpClient
{
    public LAZapiClient(Uri baseAddress)
    {
        BaseAddress = baseAddress;
        DefaultRequestHeaders.Accept.Clear();
        DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<Question> GetQuestion(int id)
    {
        var response = await GetAsync($"questions/{id}");
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Could not retreive data from API!");
        }

        return await response.Content.ReadAsAsync<Question>();
    }

    public async Task<Question[]?> GetRandomQuestions(int count)
    {
        try
        {
            var response = await GetAsync($"randomQuestions/{count}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Could not retreive data from API!");
            }
            return await response.Content.ReadAsAsync<Question[]>();
        }
        catch
        {
            return null;
        }
    }
}
