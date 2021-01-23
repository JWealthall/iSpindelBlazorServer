#nullable enable
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;

namespace iSpindelBlazorServer.Components.Forms
{
    public class InputDateTime<TValue> : InputBase<TValue>
    {
        //static InputDateTime()
        //{
        //    // Unwrap Nullable<T>, because InputBase already deals with the Nullable aspect
        //    // of it for us. We will only get asked to parse the T for nonempty inputs.
        //    var targetType = Nullable.GetUnderlyingType(typeof(TValue)) ?? typeof(TValue);
        //    if (targetType != typeof(DateTime)) throw new InvalidOperationException($"The type '{targetType}' is not a supported guid type.");

        //}

        /// <summary>
        /// Gets or sets the error message used when displaying an a parsing error.
        /// </summary>
        [Parameter] public string ParsingErrorMessage { get; set; } = "The {0} field must be a guid.";

        /// <inheritdoc />
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "input");
            builder.AddMultipleAttributes(1, AdditionalAttributes);
            builder.AddAttribute(2, "class", CssClass);
            builder.AddAttribute(3, "value", BindConverter.FormatValue(CurrentValue));
            builder.AddAttribute(4, "onchange", EventCallback.Factory.CreateBinder<string?>(this, __value => CurrentValueAsString = __value, CurrentValueAsString));
            builder.CloseElement();
        }

        /// <summary>
        /// Formats the value as a string. Derived classes can override this to determine the formatting used for <c>CurrentValueAsString</c>.
        /// </summary>
        /// <param name="value">The value to format.</param>
        /// <returns>A string representation of the value.</returns>
        protected override string? FormatValueAsString(TValue? value)
        {
            return value?.ToString();
        }

        /// <inheritdoc />
        protected override bool TryParseValueFromString(string? value, [MaybeNullWhen(false)] out TValue result, [NotNullWhen(false)] out string? validationErrorMessage)
        {
            if (typeof(TValue) == typeof(DateTime))
            {
                var res = DateTime.TryParse(value, out var parsedValue);
                result = (TValue) (object) parsedValue;
                validationErrorMessage = res ? null : "Not a valid DateTime";
                return res;
            }
            
            throw new InvalidOperationException($"{GetType()} does not support the type '{typeof(TValue)}'.");
        }
    }
}
