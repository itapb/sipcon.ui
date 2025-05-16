using MudBlazor;
using Sipcon.WebApp.Client.Pages;

namespace Sipcon.WebApp.Client.Helper
{
    public static class Useful
    {
        internal static async Task<DialogResult?> ShowDialog(this IDialogService dialogService, string? strMessage, string strTitle, string strPrimaryButton, Color mColor, string? strIcon)
        {
            var parameters = new DialogParameters<Dialog> { { x => x.ContentText, strMessage }, { x => x.TitleText, strTitle }, { x => x.ButtonText, strPrimaryButton }, { x => x.Color, mColor }, { x => x.strIcon, strIcon } };
            var mdialog = await dialogService.ShowAsync<Dialog>(strTitle, parameters, new DialogOptions { BackdropClick = false, MaxWidth = MaxWidth.ExtraSmall, FullWidth = true });
            return await mdialog.Result;
        }
        internal static T With<T>(this T obj, Action<T> action)
        {
            action(obj);
            return obj;
        }
        internal static string? ToActionIcon(this string? actionDisplay)
        {
            return actionDisplay switch
            {
                "Activar" => Icons.Material.Filled.VerifiedUser,
                "Desactivar" => Icons.Material.Filled.Dangerous,
                "Importar" => Icons.Material.Filled.Upload,
                "Exportar" => Icons.Material.Filled.Download, 
                "Asignar" => Icons.Material.Filled.GroupAdd,
                "Desasignar" => Icons.Material.Filled.GroupRemove,
                "Disponible" => Icons.Material.Filled.CheckCircle,
                "No Disponible" => Icons.Material.Filled.Cancel,
                _ => Icons.Material.Filled.HelpOutline
            };
        }        
    }
}
