using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace MySqlWooSyncApp
{

    public partial class MainForm : Form
    {
        private enum ModoAutomatico
        {
            Ninguno,
            SincronizacionCompleta,
            SoloActualizacion
        }

        private Config _config;
        private SyncOrchestrator _syncOrchestrator;
        private System.Threading.Timer _timer;
        private bool _isRunning;
        private ModoAutomatico _modoAutomatico = ModoAutomatico.Ninguno;
        private CancellationTokenSource _cancelSource;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                CargarConfiguracion();
                InicializarServicios();
                ConfigurarTimer();
                Log("Aplicación lista.");
                btnSoloAct.Enabled = true;
                btnActAuto.Enabled = true;
                btnStartAuto.Enabled = false;
                btnSyncNow.Enabled = false;
            }
            catch (Exception ex)
            {
                Log($"Error inicializando la aplicación: {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarConfiguracion()
        {
            _config = AppConfigService.Load();
            txtHost.Text = _config.MySqlHost;
            txtPort.Text = _config.MySqlPort.ToString();
            txtDatabase.Text = _config.MySqlDatabase;
            txtUser.Text = _config.MySqlUser;
            txtPassword.Text = _config.MySqlPassword;
            txtWooUrl.Text = _config.WooUrl;
            txtWooKey.Text = _config.WooKey;
            txtWooSecret.Text = _config.WooSecret;
            txtInterval.Text = _config.SyncIntervalMinutes.ToString();
            txtTimeout.Text = _config.RequestTimeoutSeconds.ToString();
            txtQuery.Text = _config.MySqlQuery;
            Log($"Configuración cargada desde: {AppConfigService.ConfigPath}");
        }

        private void GuardarConfiguracionDesdePantalla()
        {
            _config.MySqlHost = txtHost.Text.Trim();
            _config.MySqlPort = int.TryParse(txtPort.Text, out var port) ? port : 3306;
            _config.MySqlDatabase = txtDatabase.Text.Trim();
            _config.MySqlUser = txtUser.Text.Trim();
            _config.MySqlPassword = txtPassword.Text;
            _config.WooUrl = txtWooUrl.Text.Trim();
            _config.WooKey = txtWooKey.Text.Trim();
            _config.WooSecret = txtWooSecret.Text.Trim();
            _config.SyncIntervalMinutes = int.TryParse(txtInterval.Text, out var interval) ? interval : 10;
            _config.RequestTimeoutSeconds = int.TryParse(txtTimeout.Text, out var timeout) ? timeout : 120;
            _config.MySqlQuery = txtQuery.Text;

            AppConfigService.Save(_config);
            Log("Configuración guardada.");
        }

        private void InicializarServicios()
        {
            var databaseService = new DatabaseService(_config);
            var wooCommerceSync = new WooCommerceSync(_config.WooUrl, _config.WooKey, _config.WooSecret, Log);
            _syncOrchestrator = new SyncOrchestrator(databaseService, wooCommerceSync, Log);
        }

        private void ConfigurarTimer()
        {
            _timer?.Dispose();

            _timer = new System.Threading.Timer(
                async _ => await EjecutarSincronizacionSeguraAsync(),
                null,
                System.Threading.Timeout.Infinite,
                System.Threading.Timeout.Infinite
            );
        }

        private void IniciarTimer()
        {
            var intervalo = Math.Max(1, _config.SyncIntervalMinutes);
            _timer.Change(TimeSpan.Zero, TimeSpan.FromMinutes(intervalo));
            Log($"Ejecución automática iniciada cada {intervalo} minuto(s).");
        }

        private void DetenerTimer()
        {
            try
            {
                _timer?.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
                _modoAutomatico = ModoAutomatico.Ninguno;

                _cancelSource?.Cancel();

                Log("Ejecución automática detenida.");
            }
            catch (Exception ex)
            {
                Log($"Error al detener automático: {ex.Message}");
            }
        }

        private async Task EjecutarSincronizacionSeguraAsync()
        {
            try
            {
                if (_syncOrchestrator == null)
                {
                    Log("Los servicios no están inicializados.");
                    return;
                }

                var token = _cancelSource?.Token ?? CancellationToken.None;

                switch (_modoAutomatico)
                {
                    case ModoAutomatico.SincronizacionCompleta:
                        Log("Iniciando ejecución automática de sincronización completa...");
                        await _syncOrchestrator.SincronizarAsync(token);
                        Log("Finalizó ejecución automática de sincronización completa.");
                        break;

                    case ModoAutomatico.SoloActualizacion:
                        Log("Iniciando ejecución automática de actualización de productos existentes...");
                        await _syncOrchestrator.ActualizarSoloExistentesAsync(token);
                        Log("Finalizó ejecución automática de actualización de productos existentes.");
                        break;

                    default:
                        Log("No hay modo automático seleccionado.");
                        break;
                }
            }
            catch (OperationCanceledException)
            {
                Log("La ejecución automática fue cancelada.");
            }
            catch (Exception ex)
            {
                Log($"Error en ejecución automática: {ex.Message}");
            }
        }

        private async void btnSyncNow_Click(object sender, EventArgs e)
        {
            await EjecutarSincronizacionSeguraAsync();
        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            try
            {
                GuardarConfiguracionDesdePantalla();
                InicializarServicios();
                ConfigurarTimer();
            }
            catch (Exception ex)
            {
                Log($"Error guardando configuración: {ex.Message}");
            }
        }

        private void btnStartAuto_Click(object sender, EventArgs e)
        {
            try
            {
                _cancelSource?.Cancel();
                _cancelSource?.Dispose();
                _cancelSource = new CancellationTokenSource();

                _modoAutomatico = ModoAutomatico.SincronizacionCompleta;

                int intervalo = Math.Max(1, _config.SyncIntervalMinutes);
                _timer.Change(TimeSpan.Zero, TimeSpan.FromMinutes(intervalo));

                Log($"Ejecución automática iniciada cada {intervalo} minuto(s) en modo sincronización completa.");
            }
            catch (Exception ex)
            {
                Log($"Error al iniciar automático completo: {ex.Message}");
            }
        }

        private void btnStopAuto_Click(object sender, EventArgs e)
        {
            DetenerTimer();
        }

        private void btnOpenConfig_Click(object sender, EventArgs e)
        {
            var path = AppConfigService.ConfigPath;
            if (File.Exists(path))
            {
                System.Diagnostics.Process.Start("notepad.exe", path);
            }
            else
            {
                Log("No se encontró config.json.");
            }
        }

        private void Log(string mensaje)
        {
            if (txtLog.InvokeRequired)
            {
                txtLog.Invoke(new Action(() => txtLog.AppendText($"{DateTime.Now:dd/MM/yyyy HH:mm:ss}: {mensaje}{Environment.NewLine}")));
            }
            else
            {
                txtLog.AppendText($"{DateTime.Now:dd/MM/yyyy HH:mm:ss}: {mensaje}{Environment.NewLine}");
            }
        }

        private async void btnSoloAct_Click(object sender, EventArgs e)
        {
            try
            {
                Log("Ejecutando actualización solo de productos existentes...");

                await _syncOrchestrator.ActualizarSoloExistentesAsync(CancellationToken.None);

                Log("Proceso de actualización de existentes finalizado.");
            }
            catch (Exception ex)
            {
                Log($"Error en actualización de existentes: {ex.Message}");
            }
        }

        private void rdbAct_CheckedChanged(object sender, EventArgs e)
        {
            if(rdbAct.Checked)
            {
                btnSoloAct.Enabled = true;
                btnActAuto.Enabled = true;
                btnStartAuto.Enabled = false;
                btnSyncNow.Enabled = false;
            }
            else if (rdbActCarg.Checked)
            {
                btnSoloAct.Enabled = false;
                btnActAuto.Enabled = false;
                btnStartAuto.Enabled = true;
                btnSyncNow.Enabled = true;
            }
        }

        private void btnActAuto_Click(object sender, EventArgs e)
        {
            try
            {
                _cancelSource?.Cancel();
                _cancelSource?.Dispose();
                _cancelSource = new CancellationTokenSource();

                _modoAutomatico = ModoAutomatico.SoloActualizacion;

                int intervalo = Math.Max(1, _config.SyncIntervalMinutes);
                _timer.Change(TimeSpan.Zero, TimeSpan.FromMinutes(intervalo));

                Log($"Ejecución automática iniciada cada {intervalo} minuto(s) en modo solo actualización.");
            }
            catch (Exception ex)
            {
                Log($"Error al iniciar automático solo actualización: {ex.Message}");
            }
        }
    }
}
