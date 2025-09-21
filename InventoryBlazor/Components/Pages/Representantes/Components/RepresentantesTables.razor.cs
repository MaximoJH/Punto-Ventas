using Microsoft.AspNetCore.Components;
using InventotyClass;
namespace InventoryBlazor.Representantes.Components
{
    public partial class RepresentantesTables : ComponentBase
    {
        [Parameter] public IEnumerable<GetAllRepresentantes> RepresentanteList { get; set; } = new List<GetAllRepresentantes>();
        [Parameter] public EventCallback<GetAllRepresentantes> OnEditar { get; set; }
        [Parameter] public EventCallback<UpdateRepresentanteEstado> OnEliminar { get; set; }
        private async Task Eliminar(UpdateRepresentanteEstado entity)
        {
            await OnEliminar.InvokeAsync(entity);

            // * (() => MostrarConfirmacion(new UpdateRepresentanteEstado { SuplidorId = suplidor.SuplidorId, Estado = "Inactivo" }))" *@
        }
    }
}