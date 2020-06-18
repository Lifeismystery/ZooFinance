using System;
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

        //private void ReloadData(string tableName, DataGridView dataGridView, SqlDataAdapter sqlDataAdapter)
        //{
        //    try
        //    {
        //        //dataGridView_CellValueChanged_State(false);

        //        //presenter.Insert();
        //        //DataTable table = dataSet.Tables[tableName];

        //        //sqlDataAdapter.Update(table.Select(null, null, DataViewRowState.Deleted));
        //        //sqlDataAdapter.Update(table.Select(null, null, DataViewRowState.ModifiedCurrent));
        //        //sqlDataAdapter.Update(table.Select(null, null, DataViewRowState.Added));

        //        //dataGridView.DataSource = dataSet.Tables[tableName];

        //        UpdateDataGridViewButtonColumnValue(dataGridView);

        //        //dataGridView_CellValueChanged_State(true);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "ReloadDataError!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void dataGridView_CellValueChanged_State(bool attach)
        //{
        //    if (attach == true)
        //    {
        //        this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
        //        this.dataGridView2.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
        //        this.dataGridView3.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellValueChanged);
        //    }
        //    else
        //    {
        //        this.dataGridView1.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
        //        this.dataGridView2.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
        //        this.dataGridView3.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellValueChanged);
        //    }    
        //}

        //private void toolStripButton1_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ReloadData(animalsTable, dataGridView1, sqlDataAdapter1);
        //        ReloadData(animalTypeTable, dataGridView2, sqlDataAdapter2);
        //        ReloadData(foodPriceTable, dataGridView3, sqlDataAdapter3);

        //        presenter.Spending();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void UpdateRow(object sender, DataGridViewCellEventArgs e, string tableName, DataGridView dataGridView, SqlDataAdapter sqlDataAdapter)
        //{
        //    try
        //    {
        //        var senderGrid = (DataGridView)sender;
        //        newColomnIndext = senderGrid.Columns.Count - 1;
        //        //MessageBox.Show(dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
        //        //presenter.Insert(e.RowIndex, dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);

        //        for (int i = 0; i < newColomnIndext; i++)
        //        {
        //            //dataSet.Tables[tableName].Rows[e.RowIndex][i] = dataGridView.Rows[e.RowIndex].Cells[i].Value;
        //            //presenter.Insert(e.RowIndex, dataGridView.Rows[e.RowIndex].Cells[i].Value);
        //        }

        //        sqlDataAdapter.Update(dataSet.Tables[tableName].Select(null, null, DataViewRowState.CurrentRows));

        //        if (senderGrid.Columns[newColomnIndext] is DataGridViewButtonColumn && e.RowIndex >= 0)
        //        {
        //            senderGrid.Rows[e.RowIndex].Cells[newColomnIndext].Value = "Delete";
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "UserAddRowError!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void UserAddRow(object sender, DataGridViewRowEventArgs e)
        //{
        //    try
        //    {
        //        var senderGrid = (DataGridView)sender;
        //        newColomnIndext = senderGrid.Columns.Count - 1;
        //        if (newRowAdding == false && senderGrid.Columns[newColomnIndext].HeaderText == "Command")
        //        {
        //            newRowAdding = true;
        //            int lastRow = senderGrid.Rows.Count - 2;
        //            senderGrid.Rows[lastRow].Cells[newColomnIndext].Value = "Insert";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "UserAddRowError!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void CellContentClick(object sender, DataGridViewCellEventArgs e, string tableName, DataGridView dataGridView, SqlDataAdapter sqlDataAdapter, BindingSource bindingSource)
        //{
        //    try
        //    {
        //        if (dataGridView.Columns[e.ColumnIndex].HeaderText == "Command")
        //        {
        //            string task = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
        //            MessageBox.Show(task);
        //            switch (task)
        //            {
        //                case "Delete":
        //                        if (MessageBox.Show("Delete this row?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //                        {
        //                            bindingSource.RemoveCurrent();
        //                        }
        //                        break;
        //                case "Insert":
        //                    bindingSource.AddNew();
        //                    newRowAdding = false;
        //                    break;
        //                case "Update":
        //                    UpdateRow(sender, e, tableName, dataGridView, sqlDataAdapter);
        //                    break;
        //                default:
        //                    MessageBox.Show("CellContentClickError!");
        //                    break;
        //            }
        //            ReloadData(tableName, dataGridView, sqlDataAdapter);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "CellContentClickError!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    IsChanging = true;
        //    try
        //    {
        //        var senderGrid = (DataGridView)sender;
        //        newColomnIndext = senderGrid.Columns.Count - 1;
        //        if (newRowAdding == false && senderGrid.Columns[newColomnIndext].HeaderText == "Command" && e.RowIndex >= 0)
        //        {
        //            int rowIndex = senderGrid.SelectedCells[0].RowIndex;
        //            senderGrid.Rows[rowIndex].Cells[newColomnIndext].Value = "Update";
        //        }
        //        MessageBox.Show(senderGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
        //        presenter.Insert(e.RowIndex, senderGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "CellValueChangedError!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        IsChanging = false;
        //    }
        //}

        //private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    CellContentClick(sender, e, animalsTable, dataGridView1, sqlDataAdapter1, animalsTableBindingSource);
        //}

        //private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        //{
        //    UserAddRow(sender, e);
        //}       

        //private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (IsChanging)
        //        return;
        //    CellValueChanged(sender, e);
        //}

        //private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        //{
        //    e.Control.KeyPress -= new KeyPressEventHandler(ColomnKeyPress);

        //    if (dataGridView1.CurrentCell.ColumnIndex == 2)
        //    {
        //        TextBox txtBox = e.Control as TextBox;

        //        if (txtBox != null)
        //        {
        //            txtBox.KeyPress += new KeyPressEventHandler(ColomnKeyPress);
        //        }
        //    }
        //}

        //private void ColomnKeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
        //    {
        //        e.Handled = true;
        //    }
        //}

        //private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    CellContentClick(sender, e, animalTypeTable, dataGridView2, sqlDataAdapter2, animalTypeTableBindingSource);
        //}

        //private void dataGridView2_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        //{
        //    UserAddRow(sender, e);
        //}

        //private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (IsChanging)
        //        return;
        //    CellValueChanged(sender, e);
        //}

        //private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    CellContentClick(sender, e, foodPriceTable, dataGridView3, sqlDataAdapter3, foodPriceTableBindingSource);
        //}

        //private void dataGridView3_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        //{
        //    UserAddRow(sender, e);
        //}

        //private void dataGridView3_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (IsChanging)
        //        return;
        //    CellValueChanged(sender, e);
        //}

        //private void tabControl1_Selected(object sender, TabControlEventArgs e)
        //{
        //    try
        //    {
        //        switch (e.TabPageIndex)
        //        {
        //            case 0:
        //                ReloadData(animalsTable, dataGridView1, sqlDataAdapter1);
        //                break;
        //            case 1:
        //                ReloadData(animalTypeTable, dataGridView2, sqlDataAdapter2);
        //                break;
        //            case 2:
        //                ReloadData(foodPriceTable, dataGridView3, sqlDataAdapter3);
        //                break;
        //            case 3:
        //                break;
        //            default:
        //                MessageBox.Show("Шойтан, как ты суда попал?");
        //                break;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "tabControl1_SelectedError!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void toolStripMenuItem1_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ReloadData(animalsTable, dataGridView1, sqlDataAdapter1);
        //        ReloadData(animalTypeTable, dataGridView2, sqlDataAdapter2);
        //        ReloadData(foodPriceTable, dataGridView3, sqlDataAdapter3);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
    }
}

