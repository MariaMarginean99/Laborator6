using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using LibrarieModele;
using NivelAccesDate;

namespace EvidentaAgenda_Form
{
    class Program
    {
        static void Main(string[] args)
        {
            Formular form1 = new Formular();
            form1.Show();
            Application.Run();
        }
    }
    public class Formular : Form
    {
        IStocareData adminPersoane = StocareFactory.GetAdministratorStocare();

        private Label lblNume;
        private Label lblPrenume;
        private Label lblNumar;
        private Label lblMail;
        private Label lblInfo;
        private TextBox txtNume;
        private TextBox txtPrenume;
        private TextBox txtNumar;
        private TextBox txtMail;
        private Button btnAdaugare;

        private const int LATIME_CONTROL = 150;
        private const int INALTIME_CONTROL = 40;
        private const int DIMENSIUNE_PAS_Y = 30;
        private const int DIMENSIUNE_PAS_X = 170;
        private const int LUNGIME_MAX = 35;


        public Formular()
        {

            //setare proprietati
            this.Size = new System.Drawing.Size(500, 300);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new System.Drawing.Point(100, 100);
            this.Font = new Font("Arial", 9, FontStyle.Bold);
            this.ForeColor = Color.Black;
            this.Text = "Adaugare persoane";

            lblNume = new Label();
            lblNume.Width = LATIME_CONTROL;
            lblNume.Text = "Nume: ";
            lblNume.BackColor = Color.Turquoise;
            this.Controls.Add(lblNume);

            lblPrenume = new Label();
            lblPrenume.Width = LATIME_CONTROL;
            lblPrenume.Text = "Prenume: ";
            lblPrenume.Top = DIMENSIUNE_PAS_Y;
            lblPrenume.BackColor = Color.Turquoise;
            this.Controls.Add(lblPrenume);

            lblNumar = new Label();
            lblNumar.Width = LATIME_CONTROL;
            lblNumar.Text = "Numar: ";
            lblNumar.Top = DIMENSIUNE_PAS_Y * 2;
            lblNumar.BackColor = Color.Turquoise;
            this.Controls.Add(lblNumar);


            lblMail = new Label();
            lblMail.Width = LATIME_CONTROL;
            lblMail.Text = "Mail: ";
            lblMail.Top = DIMENSIUNE_PAS_Y * 3;
            lblMail.BackColor = Color.Turquoise;
            this.Controls.Add(lblMail);


            lblInfo = new Label();
            lblInfo.Width = 3 * LATIME_CONTROL;
            lblInfo.Height = 2 * INALTIME_CONTROL;
            lblInfo.Text = string.Empty;
            lblInfo.Top = DIMENSIUNE_PAS_Y * 5;
            lblInfo.BackColor = Color.Turquoise;
            this.Controls.Add(lblInfo);


            txtNume = new TextBox();
            txtNume.Width = LATIME_CONTROL;
            txtNume.Left = DIMENSIUNE_PAS_X;
            this.Controls.Add(txtNume);

            txtPrenume = new TextBox();
            txtPrenume.Width = LATIME_CONTROL;
            txtPrenume.Location = new System.Drawing.Point(DIMENSIUNE_PAS_X, DIMENSIUNE_PAS_Y);
            this.Controls.Add(txtPrenume);

            txtNumar = new TextBox();
            txtNumar.Width = LATIME_CONTROL;
            txtNumar.Location = new System.Drawing.Point(DIMENSIUNE_PAS_X, DIMENSIUNE_PAS_Y * 2);
            this.Controls.Add(txtNumar);

            txtMail = new TextBox();
            txtMail.Width = LATIME_CONTROL;
            txtMail.Location = new System.Drawing.Point(DIMENSIUNE_PAS_X, DIMENSIUNE_PAS_Y * 3);
            this.Controls.Add(txtMail);

            btnAdaugare = new Button();
            btnAdaugare.Width = LATIME_CONTROL;
            btnAdaugare.Location = new System.Drawing.Point(DIMENSIUNE_PAS_X, 4 * DIMENSIUNE_PAS_Y);
            btnAdaugare.Text = "Adauga persoana: ";
            this.Controls.Add(btnAdaugare);

            btnAdaugare.Click += OnButtonAdaugaClicked;
            this.Controls.Add(btnAdaugare);

        }

        private void OnButtonAdaugaClicked(object sender, EventArgs e)
        {
            int validare = Validare();
            lblNume.ForeColor = Color.Black;
            lblPrenume.ForeColor = Color.Black;
            lblNumar.ForeColor = Color.Black;
            lblMail.ForeColor = Color.Black;

            if (validare == 0)
            {
                Persoana p = new Persoana(txtNume.Text, txtPrenume.Text, txtNumar.Text, txtMail.Text);
                lblInfo.Text = p.PrintInfo();
                adminPersoane.AddPersoane(p);
            }
            else
            {

                switch (validare)
                {
                    case 1:
                        lblNume.ForeColor = Color.Red;
                        MessageBox.Show("Nume invalid!");
                        break;
                    case 2:
                        lblPrenume.ForeColor = Color.Red;
                        MessageBox.Show("Prenume invalid!");
                        break;
                    case 3:
                        lblNumar.ForeColor = Color.Red;
                        MessageBox.Show("Numar invalid!");
                        break;
                    case 4:
                        lblMail.ForeColor = Color.Red;
                        MessageBox.Show("mail invalid!");
                        break;
                    default:
                        break;
                }

            }


        }
        private int Validare()
        {
            if (txtNume.Text == string.Empty || txtNume.Text.Length > LUNGIME_MAX)
                return 1;
            else if (txtPrenume.Text == string.Empty || txtPrenume.Text.Length > LUNGIME_MAX)
                return 2;
            else if (txtNumar.Text == string.Empty || txtNumar.Text.Length > LUNGIME_MAX)
                return 3;
            else if (txtMail.Text == string.Empty || txtMail.Text.Length > LUNGIME_MAX)
                return 4;
            return 0;

        }
    }

}
