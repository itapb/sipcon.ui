using MudBlazor;
using Sipcon.WebApp.Client.Pages;
namespace Sipcon.WebApp.Client.Helper
{
    internal static class Useful
    { 
        internal static int userId = 1;
        internal static int supplierId = 4069;
        internal static int dealerId = 5103;
        internal static int customerId = 0;
        internal static string customerName = "";

        internal static string OkSavedMessage = "Registro guardado satisfactoriamente.";
        internal static async Task<DialogResult?> ShowDialog(this IDialogService dialogService, string? strMessage, string strTitle, string strPrimaryButton, Color mColor, string? strIcon)
        {
            var parameters = new DialogParameters<Dialog> { { x => x.ContentText, strMessage }, { x => x.TitleText, strTitle }, { x => x.ButtonText, strPrimaryButton }, { x => x.Color, mColor }, { x => x.strIcon, strIcon } };
            var mdialog = await dialogService.ShowAsync<Dialog>(strTitle, parameters, new DialogOptions { BackdropClick = false, MaxWidth = MaxWidth.ExtraSmall, FullWidth = true });
            return await mdialog.Result;
        }
        internal static async Task<DialogResult?> ShowUnexpected(this IDialogService dialogService)
        {
            var parameters = new DialogParameters<Dialog> { { x => x.ContentText, "Intente mas tarde o consulte con administrador" }, { x => x.TitleText, "Error" }, { x => x.ButtonText, "Ok" }, { x => x.Color, Color.Error }, { x => x.strIcon, Icons.Material.Filled.Error } };
            var mdialog = await dialogService.ShowAsync<Dialog>("Error", parameters, new DialogOptions { BackdropClick = false, MaxWidth = MaxWidth.ExtraSmall, FullWidth = true });
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
        internal static string TemplateLog(string mTitle, string mMessage)
        {
            return $"{mTitle} : Usuario : {userId}  Fecha : {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}  Mensaje : {mMessage}";            
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
            return actionDisplay!.ToUpper() switch
            {
                "HOME" => Icons.Material.Filled.Home,
                "ACTIVAR" => Icons.Material.Filled.VerifiedUser,
                "DESACTIVAR" => Icons.Material.Filled.Dangerous,
                "IMPORTAR" => Icons.Material.Filled.Upload,
                "EXPORTAR" => Icons.Material.Filled.Download,
                "ASIGNAR" => Icons.Material.Filled.Label,
                "DESASIGNAR" => Icons.Material.Outlined.LabelOff,
                "DISPONIBLE" => Icons.Material.Filled.DirectionsCarFilled,
                "NO DISPONIBLE" => Icons.Material.Filled.CarCrash,
                "GENERAR" => Icons.Material.Outlined.Task,
                "RECHAZAR" => Icons.Material.Filled.ThumbDown,
                "INVENTARIO" => Icons.Material.Filled.Inventory,
                "PROCESOS" => Icons.Material.Filled.Hardware,
                "RECEPCION" => Icons.Material.Filled.AddBusiness,
                "TRASLADO" => Icons.Material.Filled.MoveDown,
                "IMPRIMIR" => Icons.Material.Filled.Print,
                "DESPACHO" => Icons.Material.Filled.LocalShipping,
                "RECOLECCION" => Icons.Material.Filled.AddShoppingCart,
                "INACTIVAR" => Icons.Material.Filled.Dangerous,
                "PEDIDOS" => @Icons.Material.Filled.RequestPage,
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
