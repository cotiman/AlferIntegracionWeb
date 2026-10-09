namespace MySqlWooSyncApp
{
    public class Producto
    {
        public string ArticuloID { get; set; }
        public string Titulo { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public decimal Stock { get; set; }
        public string Sku
        {
            get { return ArticuloID; }
        }
        public string Descripcion
        {
            get { return Nombre; }
        }
    }
}