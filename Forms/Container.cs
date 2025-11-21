using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using _4RTools.Model;
using _4RTools.Utils;
using System.Collections.Generic;

namespace _4RTools.Forms
{
    public partial class Container : Form, IObserver
    {

        private Subject subject = new Subject();
        private string currentProfile;
        List<ClientDTO> clients = new List<ClientDTO>();
        private ToggleApplicationStateForm frmToggleApplication = new ToggleApplicationStateForm();

        public Container()
        {
            this.subject.Attach(this);

            InitializeComponent();
            this.Text = AppConfig.Name + " - " + AppConfig.Version; // Window title

            clients.AddRange(LocalServerManager.GetLocalClients()); //Load Local Servers First
            LoadServers(clients);
            GlobalVariablesHelper.CityList = LocalServerManager.GetListCities();
            //Container Configuration
            this.IsMdiContainer = true;
            SetBackGroundColorOfMDIForm();

            //Paint Children Forms 
            frmToggleApplication = SetToggleApplicationStateWindow();
            SetAutopotWindow();
            SetAutopotYggWindow();
            SetSkillTimerWindow();
            SetCustomButtonsWindow();
            SetAHKWindow();
            SetAutoBuffStatusWindow();
            SetProfileWindow();
            SetAutobuffStuffWindow();
            SetAutobuffSkillWindow();
            SetSongMacroWindow();
            SetATKDEFWindow();
            SetMacroSwitchWindow();
            SetAutoSwitchWindow();
            SetAutoSwitchHealWindow();
            SetConfigWindow();

            // Aplicar cores após carregar todos os controles
            this.Load += (sender, e) => {
                SetBackGroundColorOfMDIForm();
                SetTabControlColors(this);
            };

            //TrackerSingleton.Instance().SendEvent("desktop_login", "page_view", "desktop_container_load");
        }

        public void addform(TabPage tp, Form f)
        {

            if (!tp.Controls.Contains(f))
            {
                tp.Controls.Add(f);
                f.Dock = DockStyle.Fill;
                f.Show();
                Refresh();
            }
            Refresh();
        }

        private void SetBackGroundColorOfMDIForm()
        {
            foreach (Control ctl in this.Controls)
            {
                if ((ctl) is MdiClient)
                {
                    ctl.BackColor = System.Drawing.Color.Black; // Mudança: usar Color.Black
                }

                // Aplicar cor preta nos TabControls diretos
                if (ctl is TabControl)
                {
                    TabControl tabControl = (TabControl)ctl;
                    tabControl.BackColor = System.Drawing.Color.Black;
                    tabControl.ForeColor = System.Drawing.Color.White;

                    // Aplicar cor preta em todas as abas
                    foreach (TabPage tabPage in tabControl.TabPages)
                    {
                        tabPage.BackColor = System.Drawing.Color.Black;
                        tabPage.ForeColor = System.Drawing.Color.White;
                    }
                }
            }

            // Aplicar cores recursivamente em todos os controles aninhados
            SetTabControlColors(this);
        }

        // Método para aplicar cores pretas em todos os TabControls recursivamente
        private void SetTabControlColors(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is TabControl)
                {
                    TabControl tabControl = (TabControl)control;
                    tabControl.BackColor = System.Drawing.Color.Black;
                    tabControl.ForeColor = System.Drawing.Color.White;

                    foreach (TabPage tabPage in tabControl.TabPages)
                    {
                        tabPage.BackColor = System.Drawing.Color.Black;
                        tabPage.ForeColor = System.Drawing.Color.White;
                    }
                }

                // Recursivamente verificar controles filhos
                if (control.HasChildren)
                {
                    SetTabControlColors(control);
                }
            }
        }

        // Override do método OnPaint para garantir que as cores sejam mantidas
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Aplicar cores após cada repaint se necessário
            if (this.Created && !this.IsDisposed)
            {
                SetTabControlColors(this);
            }
        }

        private void processCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            Client client = new Client(this.processCB.SelectedItem.ToString());
            ClientSingleton.Instance(client);
            characterName.Text = client.ReadCharacterName();
            subject.Notify(new Utils.Message(Utils.MessageCode.PROCESS_CHANGED, null));
        }

        private void Container_Load(object sender, EventArgs e)
        {
            ProfileSingleton.Create("Default");
            this.refreshProcessList();
            this.refreshProfileList();
            this.profileCB.SelectedItem = "Default";

            // Conexão automática com ragnatales.bin
            AutoConnectToRagnaTales();

            // Aplicar cores após o carregamento completo
            SetBackGroundColorOfMDIForm();
            SetTabControlColors(this);
        }

        private void AutoConnectToRagnaTales()
        {
            try
            {
                // Procura pelo processo rtales.bin na lista de processos
                foreach (Process p in Process.GetProcesses())
                {
                    if (p.MainWindowTitle != "" && (p.ProcessName.ToLower() == "rtales" || p.ProcessName.ToLower() == "rtales.bin"))
                    {
                        // Verifica se o cliente está na lista de clientes suportados
                        if (!ClientListSingleton.ExistsByProcessName(p.ProcessName))
                        {
                            continue; // Pula se não estiver na lista de clientes suportados
                        }

                        // Encontrou o processo rtales.bin, conecta automaticamente
                        string processString = string.Format("{0}.exe - {1}", p.ProcessName, p.Id);

                        // Verifica se o processo existe na lista da ComboBox
                        bool processExists = false;
                        foreach (var item in this.processCB.Items)
                        {
                            if (item.ToString() == processString)
                            {
                                processExists = true;
                                break;
                            }
                        }

                        if (processExists)
                        {
                            // Seleciona automaticamente o processo
                            this.processCB.SelectedItem = processString;

                            // Conecta ao cliente
                            Client client = new Client(processString);
                            ClientSingleton.Instance(client);

                            // Lê o nome do personagem e atualiza a interface
                            string charName = client.ReadCharacterName();
                            characterName.Text = charName;

                            // Notifica sobre a mudança de processo
                            subject.Notify(new Utils.Message(Utils.MessageCode.PROCESS_CHANGED, null));

                            // Opcional: Mostrar mensagem de sucesso (comentado para não ser intrusivo)
                            // MessageBox.Show($"Conectado automaticamente ao RagnaTales!\nPersonagem: {charName}", 
                            //                "TalesTools - Conexão Automática", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            break; // Para após encontrar e conectar o primeiro processo
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Em caso de erro, falha silenciosamente para não interromper o carregamento do aplicativo
                // Opcional: Log do erro para debug
                System.Diagnostics.Debug.WriteLine($"Erro na conexão automática: {ex.Message}");
            }
        }

        public void refreshProfileList()
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                this.profileCB.Items.Clear();
            });
            foreach (string p in Profile.ListAll())
            {
                this.profileCB.Items.Add(p);
            }
        }

        private void refreshProcessList()
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                this.processCB.Items.Clear();
            });

            foreach (Process p in Process.GetProcesses())
            {
                if (p.MainWindowTitle != "" && ClientListSingleton.ExistsByProcessName(p.ProcessName))
                {
                    string processString = string.Format("{0}.exe - {1}", p.ProcessName, p.Id);
                    this.processCB.Items.Add(processString);

                    // Verifica se é o RagnaTales e se ainda não está conectado
                    if ((p.ProcessName.ToLower() == "rtales" || p.ProcessName.ToLower() == "rtales.bin") &&
                        (ClientSingleton.GetClient() == null || this.processCB.SelectedItem == null))
                    {
                        try
                        {
                            // Conecta automaticamente
                            this.processCB.SelectedItem = processString;
                            Client client = new Client(processString);
                            ClientSingleton.Instance(client);
                            characterName.Text = client.ReadCharacterName();
                            subject.Notify(new Utils.Message(Utils.MessageCode.PROCESS_CHANGED, null));
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine($"Erro na conexão automática durante refresh: {ex.Message}");
                        }
                    }
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.refreshProcessList();
        }

        protected override void OnClosed(EventArgs e)
        {
            ShutdownApplication();
            base.OnClosed(e);
        }

        private void ShutdownApplication()
        {
            KeyboardHook.Disable();
            subject.Notify(new Utils.Message(MessageCode.TURN_OFF, null));
            Environment.Exit(0);
        }

        private void lblLinkGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(AppConfig.GithubLink);
        }

        private void lblLinkDiscord_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(AppConfig.DiscordLink);
        }

        private void websiteLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(AppConfig.Website);
        }

        private void livepixLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(AppConfig.Livepix);
        }

        private void profileCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.profileCB.Text != currentProfile)
            {
                try
                {
                    if (currentProfile != null)
                    {
                        this.frmToggleApplication.TurnOFF();
                    }
                    ProfileSingleton.ClearProfile(this.profileCB.Text);
                    ProfileSingleton.Load(this.profileCB.Text); //LOAD PROFILE
                    subject.Notify(new Utils.Message(MessageCode.PROFILE_CHANGED, null));
                    currentProfile = this.profileCB.Text.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void Update(ISubject subject)
        {
            switch ((subject as Subject).Message.code)
            {
                case MessageCode.TURN_ON:
                case MessageCode.PROFILE_CHANGED:
                    Client client = ClientSingleton.GetClient();
                    if (client != null)
                    {
                        characterName.Text = ClientSingleton.GetClient().ReadCharacterName();
                    }
                    break;
                case MessageCode.SERVER_LIST_CHANGED:
                    this.refreshProcessList();
                    break;
                case MessageCode.CLICK_ICON_TRAY:
                    this.Show();
                    this.WindowState = FormWindowState.Normal;
                    break;
                case MessageCode.SHUTDOWN_APPLICATION:
                    this.ShutdownApplication();
                    break;
            }
        }

        private void containerResize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) { this.Hide(); }
        }

        private void LoadServers(List<ClientDTO> clients)
        {
            foreach (ClientDTO clientDTO in clients)
            {
                try
                {
                    ClientListSingleton.AddClient(new Client(clientDTO));
                }
                catch { }

            }
        }

        #region Frames

        public ToggleApplicationStateForm SetToggleApplicationStateWindow()
        {
            ToggleApplicationStateForm frm = new ToggleApplicationStateForm(subject);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Location = new Point(360, 80);
            frm.MdiParent = this;
            frm.Show();
            return frm;
        }

        public void SetAutopotWindow()
        {
            AutopotForm frm = new AutopotForm(subject, false);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.MdiParent = this;
            frm.Show();
            addform(this.tabPageAutopot, frm);
        }

        public void SetAutoSwitchHealWindow()
        {
            AutoSwitchHealForm frm = new AutoSwitchHealForm(subject, false);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.MdiParent = this;
            frm.Show();
            addform(this.tabPageAutoSwitchHeal, frm);
        }

        private void SetAutoBuffStatusWindow()
        {
            AutoBuffStatusForm frm = new AutoBuffStatusForm(subject);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Location = new Point(0, 65);
            frm.MdiParent = this;
            frm.Show();
            addform(this.tabPageDebuffs, frm);
        }

        public void SetAutopotYggWindow()
        {
            AutopotForm frm = new AutopotForm(subject, true);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.MdiParent = this;
            frm.Show();
            addform(this.tabPageYggAutopot, frm);
        }

        public void SetSkillTimerWindow()
        {
            SkillTimerForm frm = new SkillTimerForm(subject);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.MdiParent = this;
            frm.Show();
            addform(this.tabPageSkillTimer, frm);

        }

        public void SetCustomButtonsWindow()
        {
            CustomButtonForm form = new CustomButtonForm(subject);
            form.FormBorderStyle = FormBorderStyle.None;
            form.Location = new Point(360, 210);
            form.MdiParent = this;
            form.Show();
        }

        public void SetAHKWindow()
        {
            AHKForm frm = new AHKForm(subject);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Location = new Point(0, 65);
            frm.MdiParent = this;
            frm.Show();
            addform(this.tabPageSpammer, frm);
        }

        public void SetProfileWindow()
        {
            ProfileForm frm = new ProfileForm(this);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Location = new Point(0, 65);
            frm.MdiParent = this;
            frm.Show();
            addform(this.tabPageProfiles, frm);
        }

        public void SetAutobuffStuffWindow()
        {
            StuffAutoBuffForm frm = new StuffAutoBuffForm(subject);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Location = new Point(0, 65);
            frm.MdiParent = this;
            frm.Show();
            addform(this.tabPageAutobuffStuff, frm);
        }

        public void SetAutobuffSkillWindow()
        {
            SkillAutoBuffForm frm = new SkillAutoBuffForm(subject);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Location = new Point(0, 65);
            frm.MdiParent = this;
            addform(this.tabPageAutobuffSkill, frm);
            frm.Show();
        }

        public void SetSongMacroWindow()
        {
            MacroSongForm frm = new MacroSongForm(subject);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Location = new Point(0, 65);
            frm.MdiParent = this;
            addform(this.tabPageMacroSongs, frm);
            frm.Show();
        }

        public void SetATKDEFWindow()
        {
            ATKDEFForm frm = new ATKDEFForm(subject);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Location = new Point(0, 65);
            frm.MdiParent = this;
            addform(this.atkDef, frm);
            frm.Show();
        }

        public void SetMacroSwitchWindow()
        {
            MacroSwitchForm frm = new MacroSwitchForm(subject);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Location = new Point(0, 65);
            frm.MdiParent = this;
            addform(this.tabMacroSwitch, frm);
            frm.Show();
        }

        public void SetAutoSwitchWindow()
        {
            AutoSwitchForm frm = new AutoSwitchForm(subject);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.MdiParent = this;
            frm.Show();
            addform(this.tabPageAutoSwitch, frm);

        }

        public void SetConfigWindow()
        {
            ConfigForm frm = new ConfigForm(subject);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Location = new Point(0, 65);
            frm.MdiParent = this;
            addform(this.tabConfig, frm);
            frm.Show();
        }

        #endregion

        private void tabPageProfiles_Click(object sender, EventArgs e)
        {

        }
    }
}