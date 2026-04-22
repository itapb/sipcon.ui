using MudBlazor;
using MudBlazor.Utilities;
using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class SelectOption 
    {

        public int? Value { get; set; } 
        public string Text { get; set; }
        public int? ParentId { get; set; } = null;
        public string ParentText { get; set; } = string.Empty;
        public string ExtraText { get; set; } = string.Empty;
        public string? ValueStr { get; set; }

        public SelectOption(int val, string option )
        {
            Value = val;
            Text = option;
        }

        public SelectOption(string val, string option)
        {
            ValueStr = val;
            Text = option;
        }

        public SelectOption()
        {
            Value = null;  // = 0
            Text = string.Empty; // = "Seleccione"
        }

    }

}
