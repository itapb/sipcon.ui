using MudBlazor;
using MudBlazor.Utilities;
using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    
    public record ModuleAction : BreadcrumbItem
    {
        public int IdAction { get; set; } = 0;
        public string ActionName { get; set; } = string.Empty;

        public Color Color { get; set; } = Color.Default;


        public ModuleAction(string text, string? href = null, bool disabled = false, string? icon = null, int idAction = 0, string actionName = "", Color color = Color.Default)
            : base(text, href, disabled, icon)
        {
            IdAction = idAction;

            ActionName = actionName;

            Color = color;
        }
    }

}
