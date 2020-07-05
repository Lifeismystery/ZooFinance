using System;
using System.Windows.Forms;
using ZooFinances.Preserver;

namespace ZooFinances
{
    public partial class Finances : Form
    {

        public new void Show()
        {
            Application.Run(this);
        }

        public Finances()
        {
            InitializeComponent();
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Finances_Load(object sender, EventArgs e)
        {
            presenter.LoadData();
            textBox1.Text = string.Format(presenter.Spending() + "$");
            //textBox2.Text = string.Format(presenter.Spending() + "$");
            label5.Text = Tiger.count.ToString();
            label6.Text = Penguin.count.ToString();
            label7.Text = Giraffe.count.ToString();
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            presenter.InsertData();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            presenter.DeleteData();
        }

        private void Update_Click(object sender, EventArgs e)
        {
            presenter.UpdateData();
        }
    }
}

