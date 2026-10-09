using System;
using System.Threading;
using System.Threading.Tasks;

namespace MySqlWooSyncApp
{
    public class SyncOrchestrator
    {
        private readonly DatabaseService _databaseService;
        private readonly WooCommerceSync _wooCommerceSync;
        private readonly Action<string> _logger;

        public SyncOrchestrator(DatabaseService databaseService, WooCommerceSync wooCommerceSync, Action<string> logger)
        {
            _databaseService = databaseService;
            _wooCommerceSync = wooCommerceSync;
            _logger = logger;
        }

        public async Task SincronizarAsync(CancellationToken cancellationToken)
        {
            Log("Iniciando sincronización...");
            cancellationToken.ThrowIfCancellationRequested();

            var productos = await _databaseService.ObtenerProductosAsync();
            Log($"Productos preparados en memoria: {productos.Count}");

            cancellationToken.ThrowIfCancellationRequested();
            await _wooCommerceSync.SincronizarProductosAsync(productos, cancellationToken);

            Log("Sincronización finalizada.");
        }

        private void Log(string mensaje)
        {
            _logger?.Invoke(mensaje);
        }

        public async Task ActualizarSoloExistentesAsync(CancellationToken cancellationToken)
        {
            _logger?.Invoke("Iniciando actualización solo de productos existentes...");

            cancellationToken.ThrowIfCancellationRequested();

            var productos = await _databaseService.ObtenerProductosAsync();
            _logger?.Invoke($"Productos obtenidos desde MySQL: {productos.Count}");

            cancellationToken.ThrowIfCancellationRequested();

            await _wooCommerceSync.ActualizarSoloExistentesAsync(productos, cancellationToken);

            _logger?.Invoke("Finalizó actualización solo de productos existentes.");
        }
    }
}
