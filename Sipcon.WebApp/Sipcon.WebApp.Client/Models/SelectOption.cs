using MudBlazor;
using MudBlazor.Utilities;
using System.ComponentModel.DataAnnotations;

namespace Sipcon.WebApp.Client.Models
{
    public class SelectOption 
    {

        public int Value { get; set; } 
        public string Text { get; set; }

        public SelectOption(int val, string option )
        {
            Value = val;
            Text = option;
        }

        public SelectOption()
        {
            Value = 0;
            Text = "Seleccione...";
        }

    }

}
