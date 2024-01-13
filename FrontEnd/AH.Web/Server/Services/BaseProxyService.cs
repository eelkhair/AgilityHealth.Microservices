using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;
using AH.Web.Server.Exceptions;
using FluentValidation.Results;

namespace AH.Web.Server.Services;

public static class BaseProxyService
{
    // private static void SetHeaders(HttpClient httpClient)
    // {
    //     var token = accessor.HttpContext?.Request.Headers["Authorization"].ToString() ?? string.Empty;
    //     httpClient.DefaultRequestHeaders.Authorization =
    //         new AuthenticationHeaderValue("Bearer", token.Replace("Bearer ", string.Empty));
    //     httpClient.DefaultRequestHeaders.Add("WebHost", accessor.HttpContext?.Request.Host.ToString());
    // }
    public static async Task<List<T>> GetList<T>(this HttpClient httpClient, string url)
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
    
    public static async Task<T?> Get<T>(this HttpClient httpClient, string url)
    {
        try
        {
            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<T>();
                return result;
            }

            // Handle HTTP response codes other than 2xx here, if necessary
            Console.WriteLine($"Failed to fetch data. Status code: {response.StatusCode}");
            return default;
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

        return default;
    }

    public static async Task<T> Upsert<T>(this HttpClient httpClient, string url, object data, bool isUpdate)
    {
        try
        {
            // SetHeaders(httpClient, accessor);
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

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                var res = await response.Content.ReadAsStringAsync();
                var document = JsonDocument.Parse(res);
                var errors = new Dictionary<string, List<string>>();
                if(document.RootElement.TryGetProperty("errors", out var errorsElement) 
                   && errorsElement.ValueKind == JsonValueKind.Object)
                {
                    foreach(var property in errorsElement.EnumerateObject())
                    {
                        errors[property.Name] = new List<string>();
                        if(property.Value.ValueKind == JsonValueKind.Array)
                        {
                            foreach(var arrayElement in property.Value.EnumerateArray())
                            {
                                errors[property.Name].Add(arrayElement.GetString()!);
                            }
                        }
                    }
                    throw new ValidationException(errors.SelectMany(x => x.Value.Select(y => new ValidationFailure(x.Key, y))).ToList());
                }
            }

            // handle error response
            Console.WriteLine($"Failed to upsert data. Status code: {response.StatusCode}");
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        catch (ValidationException)
        {
            throw;
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
          //  SetHeaders(httpClient, accessor);
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