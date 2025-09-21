using InventotyClass;
using Microsoft.AspNetCore.Components;

namespace InventoryBlazor.Representantes.Components
{
    public partial class RepresentantesModal : ComponentBase
    {
        [Parameter] public string TituloModal { get; set; } = string.Empty;
        [Parameter] public GetAllRepresentantes RepresentanteActual { get; set; } = new();
        [Parameter] public EventCallback OnCerrar { get; set; }
        [Parameter] public EventCallback<PostRepresentantes> OnGuardar { get; set; }
        [Parameter] public EventCallback OnElementoAgregado { get; set; }
    //crea una copia de RepresentanteActual
        PostRepresentantes representanteModal = new PostRepresentantes();
        protected override void OnInitialized()
        {
            if (RepresentanteActual != null)
            {
                representanteModal = new PostRepresentantes
                {
                    Nombre = RepresentanteActual.Nombre,
                    PremirApellido = RepresentanteActual.PremirApellido,
                    SegundoApellido = RepresentanteActual.SegundoApellido,
                    Telefono = RepresentanteActual.Telefono,
                    Correo = RepresentanteActual.Correo,
                    Cargo = RepresentanteActual.Cargo
                };
            }
        }


        protected async Task Cerrar()
        {
            await OnCerrar.InvokeAsync();
        }

        protected async Task Guardar()
        {
            await OnGuardar.InvokeAsync(representanteModal);
            await OnElementoAgregado.InvokeAsync();
        }
    }
}