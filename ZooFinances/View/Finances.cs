﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using ZooFinances.Preserver;
using System.Runtime.Remoting.Messaging;
using ZooFinances.Model;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

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

