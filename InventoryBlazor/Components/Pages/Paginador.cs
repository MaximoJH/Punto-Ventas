namespace Propiedades
{
    public class Paginadores<T>
    {
        public Paginadores(List<T> dataList)
        {
            DataList = dataList;
        }
        public List<T> DataList { get; set; } = new List<T>(); // Tu lista de datos
        public int PaginaActual { get; set; } = 1;
        public int ElementosPorPagina { get; set; } = 5;


        public IEnumerable<T> DataListPaginado =>
            DataList.Skip((PaginaActual - 1) * ElementosPorPagina).Take(ElementosPorPagina);

        public int TotalPaginas => (int)Math.Ceiling((double)DataList.Count / ElementosPorPagina);

        public void PaginaAnterior()
        {
            if (PaginaActual > 1)
                PaginaActual--;
        }

        public void PaginaSiguiente()
        {
            if (PaginaActual < TotalPaginas)
                PaginaActual++;
        }

        public void CambiarPaginas(int pagina)
        {
            // if (pagina >= 1 && pagina <= TotalPaginas)
            // {
                PaginaActual = pagina;
            // }

        }
        
        public void CambiarElementosPorPagina(int cantidad)
        {
            ElementosPorPagina = cantidad;
            PaginaActual = 1;
        }
    }
}