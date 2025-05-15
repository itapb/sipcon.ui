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
    }
}
