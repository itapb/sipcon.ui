public class HubEventsService
{
    public event Func<Task>? OnSupplierChanged;
    public event Func<Task>? OnDealerChanged;
    public async Task NotifySupplierChangedAsync()
    {
        if (OnSupplierChanged is not null)
            await OnSupplierChanged.Invoke();
    }
    public async Task NotifyDealerChangedAsync()
    {
        if (OnDealerChanged is not null)
            await OnDealerChanged.Invoke();
    }
}