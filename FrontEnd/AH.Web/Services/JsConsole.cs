using Microsoft.JSInterop;

namespace AH.Web.Services;


public  class JsConsole(IJSRuntime jSRuntime)
{
    private IJSRuntime JsRuntime { get; } = jSRuntime;
    
    public async Task LogAsync(string message)
    {
        await JsRuntime.InvokeVoidAsync("console.log", message);
    }
}
