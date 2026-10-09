using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WooCommerceNET;
using WooCommerceNET.WooCommerce.v3;

namespace MySqlWooSyncApp
{
    public class WooCommerceSync
    {
        private readonly WCObject _wc;
        private readonly Action<string> _logger;

        public WooCommerceSync(string baseUrl, string consumerKey, string consumerSecret, Action<string> logger)
        {
            _logger = logger;

            var rest = new RestAPI(
                $"{baseUrl.TrimEnd('/')}/wp-json/wc/v3/",
                consumerKey,
                consumerSecret
            );

            _wc = new WCObject(rest);
        }

        private void Log(string mensaje)
        {
            _logger?.Invoke(mensaje);
        }

        public async Task ActualizarSoloExistentesAsync(List<Producto> productos, CancellationToken cancellationToken)
        {
            foreach (var producto in productos)
            {
                cancellationToken.ThrowIfCancellationRequested();

                try
                {
                    Log($"Verificando existente para actualizar SKU: {producto.Sku}");

                    var existentes = await _wc.Product.GetAll(new Dictionary<string, string> {{ "sku", producto.Sku },{ "status", "any" }});

                    int stockEntero = Convert.ToInt32(Math.Truncate(producto.Stock));
                    string estadoStock = stockEntero > 0 ? "instock" : "outofstock";

                    if (existentes != null && existentes.Count > 0)
                    {
                        var existente = existentes.First();

                        // Crear un objeto mínimo para no pisar descripción,
                        // imágenes, categorías u otros campos editados manualmente.
                        var actualizar = new Product
                        {
                            sku = producto.Sku,
                            regular_price = producto.Precio,
                            manage_stock = true,
                            stock_quantity = stockEntero,
                            stock_status = estadoStock
                        };

                        await _wc.Product.Update((ulong)existente.id.Value, actualizar);

                        Log(
                            $"Producto actualizado: {producto.Sku} | " +
                            $"Precio: {producto.Precio} | Stock: {stockEntero}"
                        );
                    }
                }
                catch (Exception ex)
                {
                    Log($"Error actualizando producto {producto.Sku}: {ex.Message}");
                }
            }
        }

        public async Task SincronizarProductosAsync(List<Producto> productos, CancellationToken cancellationToken)
        {
            foreach (var producto in productos)
            {
                cancellationToken.ThrowIfCancellationRequested();

                try
                {
                    Log($"Verificando si existe SKU: {producto.Sku}");

                    var existentes = await _wc.Product.GetAll(new Dictionary<string, string>
            {
                { "sku", producto.Sku },
                { "status", "any" }
            });

                    int stockEntero = Convert.ToInt32(Math.Truncate(producto.Stock));
                    string estadoStock = stockEntero > 0 ? "instock" : "outofstock";

                    if (existentes != null && existentes.Count > 0)
                    {
                        var existente = existentes.First();

                        existente.sku = producto.Sku;
                        existente.regular_price = producto.Precio;
                        existente.manage_stock = true;
                        existente.stock_quantity = stockEntero;
                        existente.stock_status = estadoStock;

                        await _wc.Product.Update((ulong)existente.id.Value, existente);

                        Log($"Producto actualizado: {producto.Sku} | Precio: {producto.Precio} | Stock: {stockEntero}");
                    }
                    else
                    {
                        var nuevo = new Product
                        {
                            name = producto.Nombre,
                            description = producto.Descripcion,
                            sku = producto.Sku,
                            regular_price = producto.Precio,
                            manage_stock = true,
                            stock_quantity = stockEntero,
                            stock_status = estadoStock
                        };

                        await _wc.Product.Add(nuevo);

                        Log($"Producto creado: {producto.Sku} | Precio: {producto.Precio} | Stock: {stockEntero}");
                    }
                }
                catch (Exception ex)
                {
                    Log($"Error con producto {producto.Sku}: {ex.Message}");
                }
            }
        }
    }
}