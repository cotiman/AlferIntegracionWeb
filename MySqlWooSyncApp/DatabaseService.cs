using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySqlWooSyncApp
{
    public class DatabaseService
    {
        private readonly Config _config;

        public DatabaseService(Config config)
        {
            _config = config;
        }

        public async Task<List<Producto>> ObtenerProductosAsync()
        {
            var productos = new List<Producto>();

            var connectionString = new MySqlConnectionStringBuilder
            {
                Server = _config.MySqlHost,
                Database = _config.MySqlDatabase,
                UserID = _config.MySqlUser,
                Password = _config.MySqlPassword,
                Port = (uint)_config.MySqlPort,
                SslMode = MySqlSslMode.Disabled
            }.ConnectionString;

            using (var conn = new MySqlConnection(connectionString))
            {
                await conn.OpenAsync();

                string sql = _config.MySqlQuery;

                using (var cmd = new MySqlCommand(sql, conn))
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var producto = new Producto
                        {
                            ArticuloID = reader["ArticuloID"] != DBNull.Value ? reader["ArticuloID"].ToString().Trim() : "",
                            Titulo = reader["ArticuloTitulo"] != DBNull.Value ? reader["ArticuloTitulo"].ToString() : "",
                            Nombre = reader["ArticuloNombre"] != DBNull.Value ? reader["ArticuloNombre"].ToString() : "",
                            Precio = reader["ArticuloStockPrecio"] != DBNull.Value ? reader.GetDecimal(reader.GetOrdinal("ArticuloStockPrecio")) : 0,
                            Stock = reader["ArticuloStockActual"] != DBNull.Value ? reader.GetDecimal(reader.GetOrdinal("ArticuloStockActual")) : 0
                        };

                        productos.Add(producto);
                    }
                }
            }

            return productos;
        }
    }
}