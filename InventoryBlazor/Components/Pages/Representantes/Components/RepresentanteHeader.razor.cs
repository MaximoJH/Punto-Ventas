using Microsoft.AspNetCore.Components;

namespace InventoryBlazor.Representantes.Components
{
    public partial class RepresentanteHeader : ComponentBase
    {
        [Parameter] public int ElementosPorPagina { get; set; }
        [Parameter] public EventCallback<int> OnCambiarElementosPorPagina { get; set; }
        [Parameter] public EventCallback OnCrear { get; set; }
    
        protected async Task Crear()
        {
            await OnCrear.InvokeAsync();
        }
    }
}