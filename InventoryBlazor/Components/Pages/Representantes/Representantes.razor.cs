
using Microsoft.AspNetCore.Components;
using InventoryBlazor.Pagianador;
using System.Net.Http;
using Propiedades;
using InventotyClass;
using Microsoft.VisualBasic;

namespace Pages.Representantes
{

    public partial class Representantes : ComponentBase
    {
        [Inject]
        private HttpClient Http { get; set; } = default!;
        protected List<GetAllRepresentantes> RepresentanteList = new List<GetAllRepresentantes>();
        protected Paginadores<GetAllRepresentantes> paginadores = new Paginadores<GetAllRepresentantes>(new List<GetAllRepresentantes>());
        protected GetAllRepresentantes RepresentanteActual = new GetAllRepresentantes();
        protected bool modalVisible = false;
        protected bool modalConfirmacion = false;
        protected UpdateRepresentanteEstado nuevoEstado = new UpdateRepresentanteEstado();
        protected void CerrarModal() => modalVisible = false;

        protected override async Task OnInitializedAsync()
        {
            RepresentanteList = await Http.GetFromJsonAsync<List<GetAllRepresentantes>>("http://localhost:5137/api/Representantes") ?? new List<GetAllRepresentantes>();
            paginadores = new Paginadores<GetAllRepresentantes>(RepresentanteList ?? new List<GetAllRepresentantes>());
        }
        private void HandleCambiarPagina(int pagina)
        {
            paginadores.CambiarPaginas(pagina);
            StateHasChanged();
        }
        protected void EditarRepresentante(GetAllRepresentantes representante)
        {
            Console.WriteLine(representante);
            RepresentanteActual = representante; // Cargar datos existentes
            modalVisible = true;
        }
        void MostrarConfirmacion(UpdateRepresentanteEstado entity)
        {
            nuevoEstado = entity;
            modalConfirmacion = true;
        }
        void MostrarModalCrear()
        {
            RepresentanteActual = new();
            modalVisible = true;
        }
        private async Task GuardarRepresentante(PostRepresentantes representante)
        {
             Console.WriteLine(representante);
             Console.WriteLine(RepresentanteActual);

            if (RepresentanteActual?.RepresentanteId <= 0)
            {
                // Crear nuevo Representante
                var response = await Http.PostAsJsonAsync("http://localhost:5137/api/Representantes", representante);
                if (response.IsSuccessStatusCode)
                {
                    var nuevo = await response.Content.ReadFromJsonAsync<GetAllRepresentantes>();
                    if (nuevo != null)
                    {
                        paginadores.DataList.Add(nuevo);
                        Console.WriteLine(paginadores.DataListPaginado);
                        // paginadores.DataList.Insert(0, nuevo);
                        // paginadores.CambiarPaginas(2);
                        // StateHasChanged();
                    }

                }
            }
            else
            {
                if (RepresentanteActual is not null)
                {
                    RepresentanteActual.Nombre = representante.Nombre;
                    RepresentanteActual.PremirApellido = representante.PremirApellido;
                    RepresentanteActual.SegundoApellido = representante.SegundoApellido;
                    RepresentanteActual.Telefono = representante.Telefono;
                    RepresentanteActual.Correo = representante.Correo;
                    RepresentanteActual.Cargo = representante.Cargo;

                    var response = await Http.PutAsJsonAsync("http://localhost:5137/api/Representantes", RepresentanteActual);
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine(response.Content.ReadFromJsonAsync<string>());
                        // Buscar y actualizar el suplidor en la lista
                        var index = paginadores.DataList.FindIndex(s => s.RepresentanteId == RepresentanteActual.RepresentanteId);
                        if (index != -1)
                        {
                            // @* paginadores.DataList[index] = RepresentanteActual; *@
                        }
                    }
                }
                StateHasChanged();
            }
            Console.WriteLine(representante);
            StateHasChanged();
            CerrarModal();
        }
        private void ActualizarTabla()
        {
             paginadores.CambiarPaginas(1);
            StateHasChanged(); // 🔄 fuerza el renderizado
        }

    }
}