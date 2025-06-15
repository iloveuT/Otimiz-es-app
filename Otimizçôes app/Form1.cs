using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otimizçôes_app
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Add any initialization logic here
        }

        private void btOtimizarTudo_Click(object sender, EventArgs e)
        {
            // Define o nome do arquivo .reg a ser executado
            string regFileName = "1.reg";

            string appDataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "app_data");
            // Obtém o caminho completo para o arquivo de lote dentro da pasta "app_data"
            string regFilePath = Path.Combine(appDataPath, regFileName);

            // Verifica se o arquivo .reg existe
            if (!File.Exists(regFilePath))
            {
                MessageBox.Show($"O arquivo '{regFileName}' não foi encontrado na pasta do aplicativo.\nPor favor, reinstale o app.", "Arquivo Não Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Cria um novo processo para executar o arquivo .reg via regedit
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "regedit.exe"; // O executável para manipular arquivos .reg
                startInfo.Arguments = $"/s \"{regFilePath}\""; // O argumento /s para execução silenciosa e o caminho do arquivo
                startInfo.Verb = "runas"; // Solicita privilégios administrativos ("Executar como administrador")
                startInfo.UseShellExecute = true; // Necessário para 'runas'
                startInfo.WindowStyle = ProcessWindowStyle.Hidden; // Oculta a janela do regedit, se possível

                // Inicia o processo
                Process.Start(startInfo);
                MessageBox.Show($"O arquivo '{regFileName}' não foi encontrado na pasta do aplicativo.\nPor favor, reinstale o app.", "Arquivo Não Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                // Captura a exceção se o usuário cancelar a solicitação de UAC (User Account Control)
                if (ex.NativeErrorCode == 1223) // Erro 1223: The operation was canceled by the user.
                {
                    MessageBox.Show("A execução do arquivo .reg foi cancelada pelo usuário (UAC).", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Outros erros de sistema
                    MessageBox.Show($"Ocorreu um erro ao tentar executar o arquivo .reg: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Captura outras exceções gerais
                MessageBox.Show($"Ocorreu um erro inesperado: {ex.Message}", "Erro Inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btUltimoRecurso_Click(object sender, EventArgs e)
        {
            // Define o nome do arquivo .reg a ser executado
            string regFileName = "2.reg";

            string appDataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "app_data");
            // Obtém o caminho completo para o arquivo de lote dentro da pasta "app_data"
            string regFilePath = Path.Combine(appDataPath, regFileName);

            // Verifica se o arquivo .reg existe
            if (!File.Exists(regFilePath))
            {
                MessageBox.Show($"O arquivo '{regFileName}' não foi encontrado na pasta do aplicativo.\nPor favor, reinstale o app.", "Arquivo Não Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Cria um novo processo para executar o arquivo .reg via regedit
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "regedit.exe"; // O executável para manipular arquivos .reg
                startInfo.Arguments = $"/s \"{regFilePath}\""; // O argumento /s para execução silenciosa e o caminho do arquivo
                startInfo.Verb = "runas"; // Solicita privilégios administrativos ("Executar como administrador")
                startInfo.UseShellExecute = true; // Necessário para 'runas'
                startInfo.WindowStyle = ProcessWindowStyle.Hidden; // Oculta a janela do regedit, se possível

                // Inicia o processo
                Process.Start(startInfo);
                MessageBox.Show("O arquivo .reg foi iniciado com sucesso (solicitando privilégios de administrador).", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                // Captura a exceção se o usuário cancelar a solicitação de UAC (User Account Control)
                if (ex.NativeErrorCode == 1223) // Erro 1223: The operation was canceled by the user.
                {
                    MessageBox.Show("A execução do arquivo .reg foi cancelada pelo usuário (UAC).", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Outros erros de sistema
                    MessageBox.Show($"Ocorreu um erro ao tentar executar o arquivo .reg: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Captura outras exceções gerais
                MessageBox.Show($"Ocorreu um erro inesperado: {ex.Message}", "Erro Inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btOtimizarKeep_Click(object sender, EventArgs e)
        {
            // Define o nome do arquivo de lote a ser executado
            string batchFileName = "3.bat";

            string appDataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "app_data");
            // Obtém o caminho completo para o arquivo de lote dentro da pasta "app_data"
            string batchFilePath = Path.Combine(appDataPath, batchFileName);

            // Verifica se o arquivo de lote existe
            if (!File.Exists(batchFilePath))
            {
                MessageBox.Show($"O arquivo '{batchFileName}' não foi encontrado na pasta do aplicativo.\nPor favor, reinstale o app.", "Arquivo Não Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Cria um novo processo para executar o arquivo de lote
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = batchFilePath; // Define o arquivo a ser executado
                startInfo.Verb = "runas"; // Solicita privilégios administrativos ("Executar como administrador")
                startInfo.UseShellExecute = true; // Necessário para 'runas'
                startInfo.WindowStyle = ProcessWindowStyle.Hidden; // Oculta a janela do console do batch

                // Inicia o processo
                Process.Start(startInfo);
                MessageBox.Show("O arquivo de lote foi iniciado com sucesso (solicitando privilégios de administrador).\nReinicie o dispositivo para aplicar as otimizações.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                // Captura a exceção se o usuário cancelar a solicitação de UAC (User Account Control)
                if (ex.NativeErrorCode == 1223) // Erro 1223: The operation was canceled by the user.
                {
                    MessageBox.Show("A execução do arquivo de lote foi cancelada pelo usuário (UAC).", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Outros erros de sistema
                    MessageBox.Show($"Ocorreu um erro ao tentar executar o arquivo de lote: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Captura outras exceções gerais
                MessageBox.Show($"Ocorreu um erro inesperado: {ex.Message}", "Erro Inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btGpedit_Click(object sender, EventArgs e)
        {
            // Define o nome do arquivo de lote a ser executado
            string batchFileName = "4.bat";

            string appDataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "app_data");
            // Obtém o caminho completo para o arquivo de lote dentro da pasta "app_data"
            string batchFilePath = Path.Combine(appDataPath, batchFileName);

            // Verifica se o arquivo de lote existe
            if (!File.Exists(batchFilePath))
            {
                MessageBox.Show($"O arquivo '{batchFileName}' não foi encontrado na pasta do aplicativo.\nPor favor, reinstale o app.", "Arquivo Não Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Cria um novo processo para executar o arquivo de lote
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = batchFilePath; // Define o arquivo a ser executado
                startInfo.Verb = "runas"; // Solicita privilégios administrativos ("Executar como administrador")
                startInfo.UseShellExecute = true; // Necessário para 'runas'
                startInfo.WindowStyle = ProcessWindowStyle.Hidden; // Oculta a janela do console do batch

                // Inicia o processo
                Process.Start(startInfo);
                MessageBox.Show("O arquivo de lote foi iniciado com sucesso (solicitando privilégios de administrador).", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                // Captura a exceção se o usuário cancelar a solicitação de UAC (User Account Control)
                if (ex.NativeErrorCode == 1223) // Erro 1223: The operation was canceled by the user.
                {
                    MessageBox.Show("A execução do arquivo de lote foi cancelada pelo usuário (UAC).", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Outros erros de sistema
                    MessageBox.Show($"Ocorreu um erro ao tentar executar o arquivo de lote: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Captura outras exceções gerais
                MessageBox.Show($"Ocorreu um erro inesperado: {ex.Message}", "Erro Inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btTelemetryOffWS_Click(object sender, EventArgs e)
        {
            // Define o nome do arquivo de lote a ser executado
            string batchFileName = "5.bat";

            string appDataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "app_data");
            // Obtém o caminho completo para o arquivo de lote dentro da pasta "app_data"
            string batchFilePath = Path.Combine(appDataPath, batchFileName);

            // Verifica se o arquivo de lote existe
            if (!File.Exists(batchFilePath))
            {
                MessageBox.Show($"O arquivo '{batchFileName}' não foi encontrado na pasta do aplicativo.\nPor favor, reinstale o app.", "Arquivo Não Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Cria um novo processo para executar o arquivo de lote
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = batchFilePath; // Define o arquivo a ser executado
                startInfo.Verb = "runas"; // Solicita privilégios administrativos ("Executar como administrador")
                startInfo.UseShellExecute = true; // Necessário para 'runas'
                startInfo.WindowStyle = ProcessWindowStyle.Hidden; // Oculta a janela do console do batch

                // Inicia o processo
                Process.Start(startInfo);
                MessageBox.Show("O arquivo de lote foi iniciado com sucesso (solicitando privilégios de administrador).", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                // Captura a exceção se o usuário cancelar a solicitação de UAC (User Account Control)
                if (ex.NativeErrorCode == 1223) // Erro 1223: The operation was canceled by the user.
                {
                    MessageBox.Show("A execução do arquivo de lote foi cancelada pelo usuário (UAC).", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Outros erros de sistema
                    MessageBox.Show($"Ocorreu um erro ao tentar executar o arquivo de lote: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Captura outras exceções gerais
                MessageBox.Show($"Ocorreu um erro inesperado: {ex.Message}", "Erro Inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btNetOptimizer_Click(object sender, EventArgs e)
        {
            // Define o nome do arquivo de lote a ser executado
            string batchFileName = "6.bat";

            string appDataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "app_data");
            // Obtém o caminho completo para o arquivo de lote dentro da pasta "app_data"
            string batchFilePath = Path.Combine(appDataPath, batchFileName);

            // Verifica se o arquivo de lote existe
            if (!File.Exists(batchFilePath))
            {
                MessageBox.Show($"O arquivo '{batchFileName}' não foi encontrado na pasta do aplicativo.\nPor favor, reinstale o app.", "Arquivo Não Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Cria um novo processo para executar o arquivo de lote
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = batchFilePath; // Define o arquivo a ser executado
                startInfo.Verb = "runas"; // Solicita privilégios administrativos ("Executar como administrador")
                startInfo.UseShellExecute = true; // Necessário para 'runas'
                startInfo.WindowStyle = ProcessWindowStyle.Hidden; // Oculta a janela do console do batch

                // Inicia o processo
                Process.Start(startInfo);
                MessageBox.Show("O arquivo de lote foi iniciado com sucesso (solicitando privilégios de administrador).", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                // Captura a exceção se o usuário cancelar a solicitação de UAC (User Account Control)
                if (ex.NativeErrorCode == 1223) // Erro 1223: The operation was canceled by the user.
                {
                    MessageBox.Show("O arquivo de lote foi iniciado com sucesso (solicitando privilégios de administrador).\nReinicie o dispositivo para aplicar as otimizações.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Outros erros de sistema
                    MessageBox.Show($"Ocorreu um erro ao tentar executar o arquivo de lote: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Captura outras exceções gerais
                MessageBox.Show($"Ocorreu um erro inesperado: {ex.Message}", "Erro Inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btDarkTheme_Click(object sender, EventArgs e)
        {
            // Define o nome do arquivo .deskthemepack a ser executado
            string themeFileName = "dark.deskthemepack";

            string appDataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "app_data");
            // Obtém o caminho completo para o arquivo de lote dentro da pasta "app_data"
            string themeFilePath = Path.Combine(appDataPath, themeFileName);

            // Verifica se o arquivo .deskthemepack existe
            if (!File.Exists(themeFilePath))
            {
                MessageBox.Show($"O arquivo '{themeFileName}' não foi encontrado na pasta do aplicativo.\nPor favor, reinstale o app.", "Arquivo Não Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Cria um novo processo para executar o arquivo .deskthemepack
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = themeFilePath; // O próprio arquivo .deskthemepack
                startInfo.Verb = "runas"; // Solicita privilégios administrativos
                startInfo.UseShellExecute = true; // Necessário para 'runas'

                // Inicia o processo
                Process.Start(startInfo);
                MessageBox.Show("O arquivo dar.deskthemepack foi iniciado com sucesso (solicitando privilégios de administrador).", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                // Captura a exceção se o usuário cancelar a solicitação de UAC (User Account Control)
                if (ex.NativeErrorCode == 1223) // Erro 1223: The operation was canceled by the user.
                {
                    MessageBox.Show("A execução do arquivo .deskthemepack foi cancelada pelo usuário (UAC).", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Outros erros de sistema
                    MessageBox.Show($"Ocorreu um erro ao tentar executar o arquivo .deskthemepack: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Captura outras exceções gerais
                MessageBox.Show($"Ocorreu um erro inesperado: {ex.Message}", "Erro Inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btInstallOffice_Click(object sender, EventArgs e)
        {
            // Define o nome do arquivo executável a ser executado
            string executableFileName = "OfficeSetup.exe";

            string appDataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "app_data");
            // Obtém o caminho completo para o arquivo de lote dentro da pasta "app_data"
            string executableFilePath = Path.Combine(appDataPath, executableFileName);

            // Verifica se o arquivo executável existe
            if (!File.Exists(executableFilePath))
            {
                MessageBox.Show($"O arquivo '{executableFileName}' não foi encontrado na pasta do aplicativo.\nPor favor, reinstale o app.", "Arquivo Não Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Cria um novo processo para executar o arquivo executável
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = executableFilePath; // O próprio arquivo .exe
                startInfo.Verb = "runas"; // Solicita privilégios administrativos
                startInfo.UseShellExecute = true; // Necessário para 'runas'

                // Inicia o processo
                Process.Start(startInfo);
                MessageBox.Show("O arquivo executável foi iniciado com sucesso (solicitando privilégios de administrador).", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                // Captura a exceção se o usuário cancelar a solicitação de UAC (User Account Control)
                if (ex.NativeErrorCode == 1223) // Erro 1223: The operation was canceled by the user.
                {
                    MessageBox.Show("A execução do arquivo executável foi cancelada pelo usuário (UAC).", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Outros erros de sistema
                    MessageBox.Show($"Ocorreu um erro ao tentar executar o arquivo executável: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Captura outras exceções gerais
                MessageBox.Show($"Ocorreu um erro inesperado: {ex.Message}", "Erro Inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btRestart_Click(object sender, EventArgs e)
        {
            // Pergunta ao usuário se ele realmente deseja reiniciar o computador
            DialogResult result = MessageBox.Show(
                "Você tem certeza que deseja reiniciar o computador agora?\nTodos os programas abertos serão fechados.\nSe você iniciou uma instalação do Office certifique-se de concluí-la antes de reiniciar o seu computador.",
                "Confirmar Reinicialização",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Cria um novo processo para executar o comando de reinicialização
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.FileName = "shutdown.exe";
                    startInfo.Arguments = "/r /t 0"; // /r para reiniciar, /t 0 para reiniciar imediatamente
                    startInfo.Verb = "runas"; // Solicita privilégios administrativos
                    startInfo.UseShellExecute = true; // Necessário para 'runas'
                    startInfo.CreateNoWindow = true; // Não cria uma janela do console
                    startInfo.WindowStyle = ProcessWindowStyle.Hidden; // Oculta a janela do processo

                    // Inicia o processo
                    Process.Start(startInfo);
                }
                catch (System.ComponentModel.Win32Exception ex)
                {
                    // Captura a exceção se o usuário cancelar a solicitação de UAC
                    if (ex.NativeErrorCode == 1223) // Erro 1223: A operação foi cancelada pelo usuário.
                    {
                        MessageBox.Show("A reinicialização foi cancelada pelo usuário (UAC).", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Outros erros de sistema
                        MessageBox.Show($"Ocorreu um erro ao tentar reiniciar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    // Captura outras exceções gerais
                    MessageBox.Show($"Ocorreu um erro inesperado ao tentar reiniciar: {ex.Message}", "Erro Inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("A reinicialização foi cancelada.", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
