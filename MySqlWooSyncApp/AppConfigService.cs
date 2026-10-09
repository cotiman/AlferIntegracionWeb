using System;
using System.IO;
using Newtonsoft.Json;

namespace MySqlWooSyncApp
{
    public static class AppConfigService
    {
        public static string ConfigPath
        {
            get
            {
                return Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "config.json"
                );
            }
        }

        public static Config Load()
        {
            if (!File.Exists(ConfigPath))
            {
                throw new FileNotFoundException(
                    $"No se encontró el archivo de configuración en: {ConfigPath}",
                    ConfigPath
                );
            }

            string json = File.ReadAllText(ConfigPath);

            var config = JsonConvert.DeserializeObject<Config>(json);

            if (config == null)
            {
                throw new Exception(
                    $"El archivo config.json existe pero no se pudo deserializar. Ruta: {ConfigPath}"
                );
            }

            return config;
        }

        public static void Save(Config config)
        {
            string json = JsonConvert.SerializeObject(
                config,
                Formatting.Indented
            );

            File.WriteAllText(ConfigPath, json);
        }
    }
}