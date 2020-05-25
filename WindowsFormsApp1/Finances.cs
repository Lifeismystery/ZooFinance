using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Finances : Form
    {
        public void CreateTables()
        {
            DataSet ds = new DataSet();

            DataTable animalTypeTable = new DataTable("animalTable");
            DataTable foodPriceTable = new DataTable("foodTable");

            DataColumn foodTypeColumn = new DataColumn("Food Type", typeof(string));
            DataColumn foodPriceColumn = new DataColumn("Food Price", typeof(double));
            DataColumn animalTypeColumn = new DataColumn("Animal Type", typeof(string));
            DataColumn animalFoodTypeColumn = new DataColumn("Food Type", typeof(string));
            DataColumn foodRatePerDayColumn = new DataColumn("Food Rate Per Day", typeof(double));

            animalTypeTable.Columns.Add(animalTypeColumn);
            animalTypeTable.Columns.Add(animalFoodTypeColumn);
            animalTypeTable.Columns.Add(foodRatePerDayColumn);
            foodPriceTable.Columns.Add(foodTypeColumn);
            foodPriceTable.Columns.Add(foodPriceColumn);

            animalTypeTable.Rows.Add("Tiger", "Meat", 9.5);
            animalTypeTable.Rows.Add("Penguin", "Fish", 3.5);
            animalTypeTable.Rows.Add("Giraffe", "Plant", 5.0);

            foodPriceTable.Rows.Add("Meat", 10.3);
            foodPriceTable.Rows.Add("Fish", 7.5);
            foodPriceTable.Rows.Add("Plant", 4.0);

            ds.Tables.Add(animalTypeTable );
            ds.Tables.Add(foodPriceTable);

            dataGridView1.DataSource = animalTypeTable;
            dataGridView1.AutoSize = true;
            dataGridView2.DataSource = foodPriceTable;
            dataGridView2.AutoSize = true;
        }

        public void DemonstrateMergeTable()
        {
            DataTable table1 = new DataTable("Items");

            // Add columns
            DataColumn idColumn = new DataColumn("id", typeof(System.Int32));
            DataColumn itemColumn = new DataColumn("item", typeof(System.Int32));
            table1.Columns.Add(idColumn);
            table1.Columns.Add(itemColumn);

            // Set the primary key column.
            table1.PrimaryKey = new DataColumn[] { idColumn };

            // Add RowChanged event handler for the table.
            table1.RowChanged += new
                System.Data.DataRowChangeEventHandler(Row_Changed);

            // Add ten rows.
            DataRow row;
            for (int i = 0; i <= 9; i++)
            {
                row = table1.NewRow();
                row["id"] = i;
                row["item"] = i;
                table1.Rows.Add(row);
            }

            // Accept changes.
            table1.AcceptChanges();
            //PrintValues(table1, "Original values");

            // Create a second DataTable identical to the first.
            DataTable table2 = table1.Clone();

            // Add column to the second column, so that the
            // schemas no longer match.
            table2.Columns.Add("newColumn", typeof(System.String));

            // Add three rows. Note that the id column can't be the
            // same as existing rows in the original table.
            row = table2.NewRow();
            row["id"] = 14;
            row["item"] = 774;
            row["newColumn"] = "new column 1";
            table2.Rows.Add(row);

            row = table2.NewRow();
            row["id"] = 12;
            row["item"] = 555;
            row["newColumn"] = "new column 2";
            table2.Rows.Add(row);

            row = table2.NewRow();
            row["id"] = 13;
            row["item"] = 665;
            row["newColumn"] = "new column 3";
            table2.Rows.Add(row);

            // Merge table2 into the table1.
            Console.WriteLine("Merging");
            table1.Merge(table2, false, MissingSchemaAction.Add);
            //PrintValues(table1, "Merged With table1, schema added");

            dataGridView1.DataSource = table1;
        }

        private static void Row_Changed(object sender,
            DataRowChangeEventArgs e)
        {
            Console.WriteLine("Row changed {0}\t{1}", e.Action,
                e.Row.ItemArray[0]);
        }

        public Finances()
        {
            InitializeComponent();
            CreateTables();

            //DemonstrateMergeTable();
        }


        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void animalListMenuItem1_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
        }

        private void foodListMenuItem3_Click(object sender, EventArgs e)
        {
            dataGridView2.Visible = true;
            dataGridView1.Visible = false;
        }
    }
}
