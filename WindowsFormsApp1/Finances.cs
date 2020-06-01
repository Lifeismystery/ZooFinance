using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Finances : Form
    {
        private SqlConnection sqlConnection = null;

        private SqlCommandBuilder sqlBuilder = null;

        private SqlDataAdapter sqlDataAdapter1 = null;
        private SqlDataAdapter sqlDataAdapter2 = null;
        private SqlDataAdapter sqlDataAdapter3 = null;

        private DataSet dataSet = null;

        private bool newRowAdding = false;

        private string animalsTable = "AnimalsTable";

        private string animalTypeTable = "AnimalTypeTable";

        private string foodPriceTable = "FoodPriceTable";

        private int newColomnIndext = 0;

        private bool IsChanging = false;

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
            sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lifei\source\repos\Lifeismystery\ZooFinance\WindowsFormsApp1\ZooDatabase.mdf;Integrated Security=True");
            sqlConnection.Open();

            sqlDataAdapter1 = new SqlDataAdapter($"SELECT * FROM {animalsTable}", sqlConnection);
            sqlDataAdapter2 = new SqlDataAdapter($"SELECT * FROM {animalTypeTable}", sqlConnection);
            sqlDataAdapter3 = new SqlDataAdapter($"SELECT * FROM {foodPriceTable}", sqlConnection);

            dataSet = new DataSet();

            dataGridView_CellValueChanged_State(false);

            LoadData(animalTypeTable, dataSet, sqlDataAdapter2, animalTypeTableBindingSource, dataGridView2);
            LoadData(foodPriceTable, dataSet, sqlDataAdapter3, foodPriceTableBindingSource, dataGridView3);
            LoadData(animalsTable, dataSet, sqlDataAdapter1, animalsTableBindingSource, dataGridView1);

            dataGridView_CellValueChanged_State(true);

            ZooFinances();
        }

        private void ZooFinances()
        {

            var result = GetAnimalByType("Tiger") * GetFoodPrice("Meat") * GetFoodRatePerDay("Tiger")
                + (GetAnimalByType("Pinguin") * GetFoodPrice("Fish") * GetFoodRatePerDay("Pinguin"))
                + (GetAnimalByType("Giraffe") * GetFoodPrice("Plant") * GetFoodRatePerDay("Giraffe"));
            textBox2.Text = string.Format($"Tigers: {GetAnimalByType("Tiger")}, Pinguins: {GetAnimalByType("Tiger")}, Giraffe: {GetAnimalByType("Tiger")}");
            textBox1.Text = string.Format(result + "$");
        }

        private double GetFoodPrice(string foodType)
        {
            DataTable foodPriceDateTable = dataSet.Tables[foodPriceTable];
            return (double)foodPriceDateTable.AsEnumerable().Where(p => p.Field<string>("Food_Type") == foodType).Select(p => p.Field<decimal>("Food_Price")).FirstOrDefault();
        }

        private int GetAnimalByType(string animalType)
        {
            DataTable animalsDateTable = dataSet.Tables[animalsTable];
            return animalsDateTable.AsEnumerable().Where(p => p.Field<string>("Animal_Type") == animalType).Count();
        }

        private double GetFoodRatePerDay(string animalType)
        {
            DataTable animalTypeDateTable = dataSet.Tables[animalTypeTable];
            return animalTypeDateTable.AsEnumerable().Where(p => p.Field<string>("Animal_Type") == animalType).Select(p => p.Field<double>("Food_Rate_Per_Day")).FirstOrDefault();
        }

        private void UpdateDataGridViewButtonColumnValue(DataGridView dataGridView)
        {
            try
            {
                newColomnIndext = dataGridView.Columns.Count - 1;

                for (int i = 0; i < (dataGridView.Rows.Count - 1); i++)
                {
                    if (dataGridView.Columns[newColomnIndext].HeaderText == "Command")
                    {
                        dataGridView.Rows[i].Cells[newColomnIndext].Value = "Delete";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "UpdateDataGridViewButtonColumnValueError!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData(string tableName, DataSet dataSet, SqlDataAdapter sqlDataAdapter, BindingSource bindingSource, DataGridView dataGridView)
        {
            try
            {
                sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);
                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetUpdateCommand();
                sqlBuilder.GetDeleteCommand();
                

                sqlDataAdapter.Fill(dataSet, tableName);

                dataSet.Tables[tableName].TableName = tableName;

                bindingSource.DataSource = dataSet.Tables[tableName];

                UpdateDataGridViewButtonColumnValue(dataGridView);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadDataError!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReloadData(string tableName, DataGridView dataGridView, SqlDataAdapter sqlDataAdapter)
        {
            try
            {
                dataGridView_CellValueChanged_State(false);

                DataTable table = dataSet.Tables[tableName];

                sqlDataAdapter.Update(table.Select(null, null, DataViewRowState.Deleted));
                sqlDataAdapter.Update(table.Select(null, null, DataViewRowState.ModifiedCurrent));
                sqlDataAdapter.Update(table.Select(null, null, DataViewRowState.Added));

                dataGridView.DataSource = dataSet.Tables[tableName];

                UpdateDataGridViewButtonColumnValue(dataGridView);

                dataGridView_CellValueChanged_State(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ReloadDataError!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_CellValueChanged_State(bool attach)
        {
            if (attach == true)
            {
                this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
                this.dataGridView2.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
                this.dataGridView3.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellValueChanged);
            }
            else
            {
                this.dataGridView1.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
                this.dataGridView2.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
                this.dataGridView3.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellValueChanged);
            }    
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                ReloadData(animalsTable, dataGridView1, sqlDataAdapter1);
                ReloadData(animalTypeTable, dataGridView2, sqlDataAdapter2);
                ReloadData(foodPriceTable, dataGridView3, sqlDataAdapter3);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateRow(object sender, DataGridViewCellEventArgs e, string tableName, DataGridView dataGridView, SqlDataAdapter sqlDataAdapter)
        {
            try
            {
                var senderGrid = (DataGridView)sender;
                newColomnIndext = senderGrid.Columns.Count - 1;

                for (int i = 0; i < newColomnIndext; i++)
                {
                    dataSet.Tables[tableName].Rows[e.RowIndex][i] = dataGridView.Rows[e.RowIndex].Cells[i].Value;
                }

                sqlDataAdapter.Update(dataSet.Tables[tableName].Select(null, null, DataViewRowState.CurrentRows));

                if (senderGrid.Columns[newColomnIndext] is DataGridViewButtonColumn && e.RowIndex >= 0)
                {
                    senderGrid.Rows[e.RowIndex].Cells[newColomnIndext].Value = "Delete";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "UserAddRowError!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UserAddRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                var senderGrid = (DataGridView)sender;
                newColomnIndext = senderGrid.Columns.Count - 1;
                if (newRowAdding == false && senderGrid.Columns[newColomnIndext].HeaderText == "Command")
                {
                    newRowAdding = true;
                    int lastRow = senderGrid.Rows.Count - 2;
                    senderGrid.Rows[lastRow].Cells[newColomnIndext].Value = "Insert";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "UserAddRowError!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CellContentClick(object sender, DataGridViewCellEventArgs e, string tableName, DataGridView dataGridView, SqlDataAdapter sqlDataAdapter, BindingSource bindingSource)
        {
            try
            {
                if (dataGridView.Columns[e.ColumnIndex].HeaderText == "Command")
                {
                    string task = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    MessageBox.Show(task);
                    switch (task)
                    {
                        case "Delete":
                                if (MessageBox.Show("Delete this row?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    bindingSource.RemoveCurrent();
                                }
                                break;
                        case "Insert":
                            bindingSource.AddNew();
                            newRowAdding = false;
                            break;
                        case "Update":
                            UpdateRow(sender, e, tableName, dataGridView, sqlDataAdapter);
                            break;
                        default:
                            MessageBox.Show("CellContentClickError!");
                            break;
                    }
                    ReloadData(tableName, dataGridView, sqlDataAdapter);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "CellContentClickError!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            IsChanging = true;
            try
            {
                var senderGrid = (DataGridView)sender;
                newColomnIndext = senderGrid.Columns.Count - 1;
                if (newRowAdding == false && senderGrid.Columns[newColomnIndext].HeaderText == "Command" && e.RowIndex >= 0)
                {
                    int rowIndex = senderGrid.SelectedCells[0].RowIndex;
                    senderGrid.Rows[rowIndex].Cells[newColomnIndext].Value = "Update";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "CellValueChangedError!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                IsChanging = false;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CellContentClick(sender, e, animalsTable, dataGridView1, sqlDataAdapter1, animalsTableBindingSource);
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            UserAddRow(sender, e);
        }       

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (IsChanging)
                return;
            CellValueChanged(sender, e);
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(ColomnKeyPress);

            if (dataGridView1.CurrentCell.ColumnIndex == 2)
            {
                TextBox txtBox = e.Control as TextBox;

                if (txtBox != null)
                {
                    txtBox.KeyPress += new KeyPressEventHandler(ColomnKeyPress);
                }
            }
        }

        private void ColomnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CellContentClick(sender, e, animalTypeTable, dataGridView2, sqlDataAdapter2, animalTypeTableBindingSource);
        }

        private void dataGridView2_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            UserAddRow(sender, e);
        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (IsChanging)
                return;
            CellValueChanged(sender, e);
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CellContentClick(sender, e, foodPriceTable, dataGridView3, sqlDataAdapter3, foodPriceTableBindingSource);
        }

        private void dataGridView3_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            UserAddRow(sender, e);
        }

        private void dataGridView3_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (IsChanging)
                return;
            CellValueChanged(sender, e);
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            try
            {
                switch (e.TabPageIndex)
                {
                    case 0:
                        ReloadData(animalsTable, dataGridView1, sqlDataAdapter1);
                        break;
                    case 1:
                        ReloadData(animalTypeTable, dataGridView2, sqlDataAdapter2);
                        break;
                    case 2:
                        ReloadData(foodPriceTable, dataGridView3, sqlDataAdapter3);
                        break;
                    case 3:
                        break;
                    default:
                        MessageBox.Show("Шойтан, как ты суда попал?");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "tabControl1_SelectedError!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                ReloadData(animalsTable, dataGridView1, sqlDataAdapter1);
                ReloadData(animalTypeTable, dataGridView2, sqlDataAdapter2);
                ReloadData(foodPriceTable, dataGridView3, sqlDataAdapter3);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

