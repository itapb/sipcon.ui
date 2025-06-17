using MudBlazor;
using Sipcon.WebApp.Client.Pages;
namespace Sipcon.WebApp.Client.Helper
{
    internal static class Useful
    { 
        internal static int userId = 1;
        internal static int supplierId = 4069;
        internal static string OkSavedMessage = "Registro guardado satisfactoriamente.";
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
        internal static string GetTitle(this string? moduleCode)
        {
            return moduleCode switch
            {
                "Zone" => "Zonas",
                "Warehouse" => "Almacen",
                _ => ""
            };
        }
        internal static string? GetmoduleName(this string? moduleCode)
        {
            return moduleCode switch
            {
                "Zone" => "INVENTARIO-ZONAS",
                "Warehouse" => "INVENTARIO-ALMACEN",
                _ => null
            };
        }
        internal static string? ToActionIcon(this string? actionDisplay)
        {
            return actionDisplay switch
            {
                "Home" => Icons.Material.Filled.Home,
                "Activar" => Icons.Material.Filled.VerifiedUser,
                "Desactivar" => Icons.Material.Filled.Dangerous,
                "Importar" => Icons.Material.Filled.Upload,
                "Exportar" => Icons.Material.Filled.Download, 
                "Asignar" => Icons.Material.Filled.Label,
                "Desasignar" => Icons.Material.Outlined.LabelOff,
                "Disponible" => Icons.Material.Filled.DirectionsCarFilled,
                "No Disponible" => Icons.Material.Filled.CarCrash,
                "Generar" => Icons.Material.Outlined.Task,
                "Rechazar" => Icons.Material.Filled.ThumbDown,
                "Inventario" => Icons.Material.Filled.Inventory,
                "Procesos" => Icons.Material.Filled.Hardware,
                "Recepcion" => Icons.Material.Filled.AddBusiness,
                "Traslado" => Icons.Material.Filled.MoveDown,
                _ => Icons.Material.Filled.HelpOutline
            };
        }
        internal static async Task OpenForm<TComponent, TModel>(this IDialogService dialogService, int? Id, MudDataGrid<TModel>? MyMudDataGrid) where TComponent : class, Microsoft.AspNetCore.Components.IComponent
        {
            var options = new DialogOptions { MaxWidth = MaxWidth.Large, BackdropClick = false, NoHeader = true };
            var dialogReference = await dialogService.ShowAsync<TComponent>("", new DialogParameters { ["Value"] = Id }, options);
            var dialogResult = await dialogReference.Result;
            if (!dialogResult!.Canceled)
                await MyMudDataGrid!.ReloadServerData();
        }

        internal static async Task<bool> AsyncDialogResultIsOk(IDialogReference? dialogReference) => !((await dialogReference!.Result)!.Canceled);
    }
}
