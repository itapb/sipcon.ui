using MudBlazor;
using MudBlazor.Utilities;
using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    // Changed from class to record to fix CS8865, as only records can inherit from records.
    public record ModuleAction : BreadcrumbItem
    {

        public string ActionName { get; set; } = string.Empty;

        public Color Color { get; set; } = Color.Default;


        // Added a constructor to fix CS1729, as BreadcrumbItem does not have a parameterless constructor.
        public ModuleAction(string text, string? href = null, bool disabled = false, string? icon = null, string actionName = "", Color color = Color.Default)
            : base(text, href, disabled, icon)
        {
            ActionName = actionName;

            Color = color;
        }
    }

}
