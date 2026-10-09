using System;
using System.IO;
using Newtonsoft.Json;

namespace MySqlWooSyncApp
{
    public static class AppConfigService
    {
        private const string AppFolderName = "SincroAlferWeb";
        private const string FileName = "config.json";

        // Ruta editable por el usuario: carpeta con permisos de escritura
        // (%AppData%\SincroAlferWeb\config.json). Evita el "Acceso denegado"
        // cuando la app está instalada en C:\Program Files, que Windows
        // protege contra escritura para usuarios sin privilegios de admin.
        public static string ConfigPath
        {
            get
            {
                string dir = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    AppFolderName
                );

                return Path.Combine(dir, FileName);
            }
        }

        // Config que viene junto al ejecutable. Solo se usa como semilla
        // inicial (solo lectura): no se escribe ahí nunca.
        private static string InstallConfigPath
        {
            get
            {
                return Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    FileName
                );
            }
        }

        public static Config Load()
        {
            string path = ConfigPath;

            // Primera ejecución: si todavía no existe el config de usuario,
            // lo creamos a partir del que vino junto al ejecutable.
            if (!File.Exists(path) && File.Exists(InstallConfigPath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
                File.Copy(InstallConfigPath, path);
            }

            if (!File.Exists(path))
            {
                throw new FileNotFoundException(
                    $"No se encontró el archivo de configuración en: {path}",
                    path
                );
            }

            string json = File.ReadAllText(path);

            var config = JsonConvert.DeserializeObject<Config>(json);

            if (config == null)
            {
                throw new Exception(
                    $"El archivo config.json existe pero no se pudo deserializar. Ruta: {path}"
                );
            }

            return config;
        }

        public static void Save(Config config)
        {
            string path = ConfigPath;

            Directory.CreateDirectory(Path.GetDirectoryName(path));

            string json = JsonConvert.SerializeObject(
                config,
                Formatting.Indented
            );

            File.WriteAllText(path, json);
        }
    }
}
