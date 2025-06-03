using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Sipcon.WebApp.Client.Models;


namespace Sipcon.WebApp.Client.Interfaces
{
    public interface IMasterComp<T> where T : Record
    {
        Task OnSearch(string text);
        Task OpenForm(int? mId);
        Task ClickAdd(MouseEventArgs ev);
        Task ClickEdit(T item);
        Task OnInputFileChange(InputFileChangeEventArgs e);
        Task ClickRefresh(MouseEventArgs ev);
        Task AfterAsyncAllCheck();
        Task ClickMenu(string? actionName);
        Task FillModules();
    }
}