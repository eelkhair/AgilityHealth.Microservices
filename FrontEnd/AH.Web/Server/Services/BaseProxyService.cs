using System.Text.Json;

namespace AH.Web.Server.Services;

public static class BaseProxyService
{
    public static async Task<List<T>> Get<T>(this HttpClient httpClient, string url)
    {
        try
        {
            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<List<T>>();
                return result ?? new List<T>();
            }

            // Handle HTTP response codes other than 2xx here, if necessary
            Console.WriteLine($"Failed to fetch data. Status code: {response.StatusCode}");
            return new List<T>();
        }
        catch (HttpRequestException ex)
        {
            // Handle exceptions related to the HTTP call here
            Console.WriteLine($"An error occurred while fetching data: {ex.Message}");
        }
        catch (JsonException ex)
        {
            // Handle exceptions related to JSON deserialization here
            Console.WriteLine($"An error occurred while deserializing data: {ex.Message}");
        }
        catch (Exception ex)
        {
            // Handle any unhandled exceptions here
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }

        return new List<T>();
    }

    public static async Task<T> Upsert<T>(this HttpClient httpClient, string url, object data, bool isUpdate)
    {
        try
        {
            var jsonContent = JsonContent.Create(data);
            HttpResponseMessage response;

            if (isUpdate)
            {
                response = await httpClient.PutAsync(url, jsonContent);
            }
            else
            {
                response = await httpClient.PostAsync(url, jsonContent);
            }

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<T>();
                return result!;
            }

            // handle error response
            Console.WriteLine($"Failed to upsert data. Status code: {response.StatusCode}");
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }

        return default!;
    }
    
    public static async Task<bool> Delete(this HttpClient httpClient, string url)
    {
        try
        {
            var response = await httpClient.DeleteAsync(url);
        
            if(response.IsSuccessStatusCode)
            {
                return true;
            }

            // Log status code
            Console.WriteLine($"Failed to delete. Status code: {response.StatusCode}");
        }
        catch (HttpRequestException ex)
        {
            // Handle exceptions related to the HTTP call here
            Console.WriteLine($"An error occurred while deleting data: {ex.Message}");
        }
        catch (Exception ex)
        {
            // Handle any unhandled exceptions here
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    
        return false;
    }
}