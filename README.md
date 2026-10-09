# MySqlWooSyncApp

Aplicación Windows WinForms en C# .NET Framework 4.8 para sincronizar productos desde MySQL hacia WooCommerce.

## Qué hace

- Ejecuta una consulta SQL configurable contra MySQL.
- Lee estos campos del resultado:
  - `ArticuloID`
  - `ArticuloTitulo`
  - `ArticuloNombre`
  - `ArticuloStockPrecio`
- Usa `ArticuloID` como identificador externo del producto.
- En WooCommerce busca primero por SKU (`ArticuloID` convertido a texto).
- Si existe, actualiza.
- Si no existe, crea.
- Permite ejecución manual y automática con intervalo configurable.
- No maneja imágenes en esta versión.

## Mapeo de campos

La app arma el producto así:

- **SKU** = `ArticuloID`
- **Nombre** = `ArticuloNombre`
- **Descripción corta / descripción** = `ArticuloTitulo`
- **Precio regular** = `ArticuloStockPrecio`
- **Stock** = 0 por defecto en esta versión, porque la consulta enviada no trae stock.
- **manage_stock** = `false` por defecto.

> Si luego querés manejar stock real, agregá una columna a la consulta y mapeala en `DatabaseProductoDto`.

## Consulta SQL por defecto

```sql
select art.ArticuloID,
       cat.ArticuloCategoriaNombre as ArticuloTitulo,
       art.ArticuloNombre,
       stock.ArticuloStockPrecio
from articulo art
inner join articulostock stock on stock.ArticuloID = art.ArticuloID
inner join articulocategoria cat on cat.ArticuloCategoriaID = art.ArticuloCategoriaID
where sucursalid = 1
  and articulostockprecio <> 0
order by art.articuloid
```

## Configuración de WooCommerce

### 1. Habilitar REST API

En WordPress / WooCommerce:

- WooCommerce
- Ajustes
- Avanzado
- REST API
- Crear clave

Otorgar permisos de **Read/Write**.

Vas a obtener:

- Consumer Key (`ck_...`)
- Consumer Secret (`cs_...`)

### 2. URL del sitio

En el archivo `config.json`, usar solo la URL base del sitio, por ejemplo:

```json
"WooUrl": "https://tu-sitio.com"
```

No pongas `/wp-json/wc/v3/`, porque la app lo agrega sola.

### 3. Permalinks en WordPress

Asegurate de que WordPress tenga enlaces permanentes habilitados.

- Ajustes
- Enlaces permanentes
- Elegir cualquier estructura distinta de “Simple”

## Configuración de la aplicación

Editar `config.json`:

```json
{
  "MySqlHost": "127.0.0.1",
  "MySqlPort": 3306,
  "MySqlDatabase": "basedatos",
  "MySqlUser": "usuario",
  "MySqlPassword": "clave",
  "MySqlQuery": "select art.ArticuloID, cat.ArticuloCategoriaNombre as ArticuloTitulo, art.ArticuloNombre, stock.ArticuloStockPrecio from articulo art inner join articulostock stock on stock.ArticuloID = art.ArticuloID inner join articulocategoria cat on cat.ArticuloCategoriaID = art.ArticuloCategoriaID where sucursalid = 1 and articulostockprecio <> 0 order by art.articuloid",
  "SyncIntervalMinutes": 10,
  "WooUrl": "https://tu-sitio.com",
  "WooKey": "ck_xxxxxxxxxxxxxxxxx",
  "WooSecret": "cs_xxxxxxxxxxxxxxxxx",
  "RequestTimeoutSeconds": 120
}
```

## Cómo funciona la sincronización

1. Se conecta a MySQL.
2. Ejecuta la consulta.
3. Genera una lista en memoria.
4. Para cada registro:
   - Busca en WooCommerce por SKU = `ArticuloID`.
   - Si existe, actualiza.
   - Si no existe, crea.
5. Si un producto falla, la app lo registra en el log y sigue con el siguiente.

## Compilación

Abrir `MySqlWooSyncApp.sln` en Visual Studio 2017 o superior.

### Paquetes NuGet requeridos

- `MySql.Data`
- `Newtonsoft.Json`
- `WooCommerceNET`

Si NuGet no los restaura automáticamente:

- Click derecho en la solución
- Restore NuGet Packages

## Notas importantes

- Esta versión no carga imágenes.
- Esta versión no actualiza categorías.
- Esta versión usa SKU = `ArticuloID` para identificar productos externos.
- Si querés stock real, agregá el campo a la consulta y te lo puedo adaptar.

## Archivos principales

- `Config.cs`
- `AppConfigService.cs`
- `DatabaseService.cs`
- `WooCommerceSync.cs`
- `SyncOrchestrator.cs`
- `MainForm.cs`
- `config.json`

