using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using MudBlazor;
using Sipcon.WebApp.Client.Helper;
using Sipcon.WebApp.Client.Interfaces;
using Sipcon.WebApp.Client.Models;
using System.Net.Http.Json;


namespace Sipcon.WebApp.Client.Services
{
    public class MasterComp<TModel,TCompoment>(IDialogService dialogservice, HttpClient http, IJSRuntime JSRuntime) : IMasterComp<TModel> 
        where TModel : Record 
        where TCompoment: class, Microsoft.AspNetCore.Components.IComponent
    {
        private string clsModelName = typeof(TModel).Name;
        private readonly IDialogService DialogService = dialogservice;
        public readonly HttpClient Http = http;
        public MudDataGrid<TModel>? EntityMudDataGrid { get; set; }
        public string? searchString { get; set; }
        public bool loading { get; set; } = true;
        public int CurrentPage { get; set; } = 0;
        public List<Module>? Modules { get; set; }
        public bool IsAllCheckBoxSelected { get; set; } = false;


        public async Task ClickAdd(MouseEventArgs ev) => await OpenForm(0);
        public async Task ClickEdit(TModel item) => await OpenForm(item.Id);
        public async Task OpenForm(int? mId) => await DialogService.OpenForm<TCompoment, TModel>(mId, EntityMudDataGrid);        
        public async Task ClickRefresh(MouseEventArgs ev) => await EntityMudDataGrid!.ReloadServerData();       
        public async Task OnInputFileChange(InputFileChangeEventArgs e)
        {
            if (e.FileCount == 1)
            {
                var file = e.File;
                const long maxAllowedSize = 10 * 1024 * 1024; // 10MB
                if (file.Size == 0)
                {
                    await DialogService.ShowDialog("Archivo esta vacio", "Error de Archivo", "OK", Color.Error, Icons.Material.Filled.Error);
                }
                else if (file.Size > maxAllowedSize)
                {
                    await DialogService.ShowDialog("Tamaño del archivo excede el limite maximo permitido de 10MB.", "Error de Archivo", "OK", Color.Error, Icons.Material.Filled.Error);
                }
                else
                {
                    using var stream = file.OpenReadStream(maxAllowedSize: maxAllowedSize);

                    var content = new StreamContent(stream);
                    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);

                    // Create a multipart form data content
                    var formData = new MultipartFormDataContent();
                    formData.Add(content, "file", file.Name);
                    loading = true;

                    var response = await Http.PostAsync($"api/{clsModelName}/Import?userId={Useful.userId}", formData);
                    if (response.IsSuccessStatusCode)
                    {
                        await DialogService.ShowDialog("Archivo cargado con exito!.", "Importar", "OK", Color.Info, Icons.Material.Filled.Commit);
                        await EntityMudDataGrid!.ReloadServerData();
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
                    {
                        var conflictContent = await response.Content.ReadFromJsonAsync<WebApiResponse<Object?>>();                        
                        await DialogService.ShowDialog(conflictContent?.message, "Error al cargar", "OK", Color.Error, Icons.Material.Filled.Error);
                    }
                    else
                    {
                        await DialogService.ShowDialog("Carga de archivo fallo!", "Error al cargar", "OK", Color.Error, Icons.Material.Filled.Error);                       
                    }
                    loading = false;
                }
            }
            await Task.CompletedTask;
        }

        public async Task OnSearch(string text)
        {
            if (text.Length == 0 || text.Length >= 3)
            {
                loading = true;
                searchString = text;
                await EntityMudDataGrid!.ReloadServerData();
            }
        }

        public async Task AfterAsyncAllCheck()
        {  
            EntityMudDataGrid?.FilteredItems.ToList().ForEach(item => item.IsSelected = IsAllCheckBoxSelected);
            await Task.CompletedTask;
        }

        public async Task ClickMenu(string? actionName)
        {
            if (actionName == "EXPORT")
            {
                loading = true;
                var ResultZonas = await Http.GetAsync($"api/{clsModelName}/Export?filter={searchString}&userId={Useful.userId}");
                if (ResultZonas.IsSuccessStatusCode)
                {
                    var fileContent = await ResultZonas.Content.ReadAsByteArrayAsync();
                    var base64File = Convert.ToBase64String(fileContent);
                    var fileUrl = $"data:application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;base64,{base64File}";
                    await JSRuntime.InvokeVoidAsync("downloadFile", fileUrl, $"{clsModelName.GetTitle()}.xlsx");
                }
                loading = false;
                return;
            }
            else if (actionName == "IMPORT")
            {
                await JSRuntime.InvokeVoidAsync("eval", "document.querySelector('[type=file]').click()");
                return;
            }
            var SelectedActions = (EntityMudDataGrid != null && ("ACTIVATE,DEACTIVATE".IndexOf(actionName!) > -1)) ?
                                (EntityMudDataGrid.FilteredItems.Where(item => item.IsSelected)
                                                                 .Select(item => new Client.Models.Action
                                                                 {
                                                                     UserId = Useful.userId,
                                                                     RecordId = item.Id,
                                                                     ModuleId = Modules!.FirstOrDefault()?.Id,
                                                                     actionName = actionName,
                                                                     ActionComment = "",
                                                                     RelatedId = 0
                                                                 }).ToList()
                                 ) : null;

            var result_Post_Actions = (SelectedActions is not null && SelectedActions.Count > 0) ? await Http.PostAsync($"api/{clsModelName}/PostActions?userId={Useful.userId}", new StringContent(System.Text.Json.JsonSerializer.Serialize(SelectedActions), null, "application/json")) : null;
            if (result_Post_Actions is not null && result_Post_Actions.IsSuccessStatusCode)
            {
                var resultAction = await result_Post_Actions.Content.ReadFromJsonAsync<WebApiResponse<List<PostResponse>>>();
                if (resultAction?.data![0].updatedRows > 0)
                {
                    var result = await DialogService.ShowDialog("Registro(s) Actualizados!", clsModelName.GetTitle(), "OK", Color.Info, Icons.Material.Filled.Commit);
                    await EntityMudDataGrid!.ReloadServerData();
                }
            }
            await Task.CompletedTask;
        }

        public async Task FillModules()
        {
            Modules?.Clear();
            Modules = await Http.GetFromJsonAsync<List<Module>>($"api/Module/GetAll?moduleName={clsModelName.GetmoduleName()}&userId={Useful.userId}");           
        }
       
    }
}
