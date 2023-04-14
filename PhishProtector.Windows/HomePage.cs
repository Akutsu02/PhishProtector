namespace PhishProtector.Windows
{
    public partial class HomePage : Form
    {
        private Label titleLabel;
        private Label descriptionLabel;
        private Label protectionStatusLabel;
        private DataGridView threatsGridView;

        public HomePage()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Anti-Phishing App";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Load += HomePage_Load;
            this.Resize += HomePage_Resize;

            titleLabel = new Label
            {
                Text = "Bienvenue dans l'application Anti-Phishing",
                Font = new Font("Arial", 24, FontStyle.Bold),
                AutoSize = true
            };
            titleLabel.Location = new Point((ClientSize.Width - titleLabel.Width) / 2, 50);
            this.Controls.Add(titleLabel);

            descriptionLabel = new Label
            {
                Text = "Prot�gez-vous contre les attaques de phishing avec notre solution intelligente et efficace.",
                Font = new Font("Arial", 14, FontStyle.Regular),
                AutoSize = true
            };
            descriptionLabel.Location = new Point((ClientSize.Width - descriptionLabel.Width) / 2, 120);
            this.Controls.Add(descriptionLabel);

            protectionStatusLabel = new Label
            {
                Text = "�tat: Protection activ�e",
                Font = new Font("Arial", 14, FontStyle.Bold),
                AutoSize = true
            };
            protectionStatusLabel.Location = new Point((ClientSize.Width - protectionStatusLabel.Width) / 2, 200);
            this.Controls.Add(protectionStatusLabel);

            threatsGridView = new DataGridView
            {
                Location = new Point(50, 250),
                Size = new Size(700, 300),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                ColumnCount = 3,
                AllowUserToAddRows = false
            };

            threatsGridView.Columns[0].Name = "Date";
            threatsGridView.Columns[1].Name = "Menace";
            threatsGridView.Columns[2].Name = "Signal�e";

            this.Controls.Add(threatsGridView);

            // Ajouter des donn�es de test pour le tableau
            AddThreat(DateTime.Now, "Phishing URL", true);
            AddThreat(DateTime.Now.AddDays(-1), "Phishing Email", false);
        }

        private void AddThreat(DateTime date, string threat, bool reported)
        {
            int rowIndex = threatsGridView.Rows.Add();
            threatsGridView.Rows[rowIndex].Cells[0].Value = date.ToString("yyyy-MM-dd HH:mm:ss");
            threatsGridView.Rows[rowIndex].Cells[1].Value = threat;
            threatsGridView.Rows[rowIndex].Cells[2].Value = reported ? "Oui" : "Non";
        }

        private void HomePage_Resize(object sender, EventArgs e)
        {
            CenterLabels();
            threatsGridView.Size = new Size(ClientSize.Width - 100, ClientSize.Height - threatsGridView.Location.Y - 50);
        }
        private void HomePage_Load(object sender, EventArgs e)
        {
            CenterLabels();
        }

        private void CenterLabels()
        {
            titleLabel.Location = new Point((ClientSize.Width - titleLabel.Width) / 2, 50);
            descriptionLabel.Location = new Point((ClientSize.Width - descriptionLabel.Width) / 2, 120);
            protectionStatusLabel.Location = new Point((ClientSize.Width - protectionStatusLabel.Width) / 2, 200);
        }

    }
}