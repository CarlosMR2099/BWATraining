﻿using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace BlazingPizza.Client.Extensions
{
    public static class JSRuntimeExtensions
    {
        public static async ValueTask<bool> Confirm(this IJSRuntime jsRuntime, string message)
        {
            return await jsRuntime.InvokeAsync<bool>($"confirm", message);
        }

        public static async Task EvalVoidAsync(this IJSRuntime jsRuntime, string script)
        {
            if (script.Length > 0)
            {
                await jsRuntime.InvokeVoidAsync($"eval", script);
            }
        }

        public static async Task<T> EvalAsync<T>(this IJSRuntime jsRuntime, string script)
        {
            T result = default;

            if (script.Length > 0)
            {
                script = $"(function(){{{script}}})()";
                result = await jsRuntime.InvokeAsync<T>($"eval", script);
            }

            return result;
        }
    }
}
