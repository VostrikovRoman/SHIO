using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using LiveCharts;
using LiveCharts.Wpf;
using System.IO;

namespace SHIO
{
    public partial class KA6 : Form
    {
        public KA6()
        {
            InitializeComponent();
            saveFileDialog1.Filter = "TXT files(*.txt)|*.png|RTF files(*.rtf)|*.rtf";
        }

        private SqlDataAdapter dataAdapter = null;
        private DataSet dataSet = null;
        private DataTable table = null;
        private void KA6_Load(object sender, EventArgs e)
        {
            
            this.buyersTableAdapter2.Fill(this.kA6DataSet2.Buyers);
            this.goodsTableAdapter2.Fill(this.kA6DataSet2.Goods);
            this.tradesTableAdapter2.Fill(this.kA6DataSet2.Trades);
            this.good_listsTableAdapter2.Fill(this.kA6DataSet2.Good_lists);

            SqlDataReader dataReader = null;
            listView_buyers.Items.Clear();
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Buyers", connection);
                    dataReader = command.ExecuteReader();
                    ListViewItem item = null;
                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["name"]),
                            Convert.ToString(dataReader["phone"]),
                            Convert.ToString(dataReader["adress"]) });
                        listView_buyers.Items.Add(item);
                    }

                }

            }
            catch (Exception a)
            {
                MessageBox.Show("Ошибка" + a);
            }
            finally
            {
                if (dataReader != null && !dataReader.IsClosed)
                {
                    dataReader.Close();
                }
            }
        }

        ////////////////////CHOICE_BUTTONS////////////////////////

        private void buyers_table_button_Click(object sender, EventArgs e)
        {
            buyers_panel.Visible = true;
            trades_panel.Visible = false;
            goods_panel.Visible = false;
            good_lists_panel.Visible = false;

            goods_edit_panel.Visible = false;
            buyers_edit_panel.Visible = true;
            good_lists_edit_panel.Visible = false;
            trades_edit_panel.Visible = false;

            chart_buyers.Visible = true;
            chart_goods.Visible = false;
            chart_good_lists.Visible = false;
            chart_trades.Visible = false;

            report_buyers.Visible = true;
            report_trades.Visible = false;
            report_goods.Visible = false;
            report_good_lists.Visible = false;

            buyers_filter_panel.Visible = true;
            trades_filter_panel.Visible = false;
            goods_filter_panel.Visible = false;
            good_lists_filter_panel.Visible = false;

            SqlDataReader dataReader = null;
            listView_buyers.Items.Clear();
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Buyers", connection);
                    dataReader = command.ExecuteReader();
                    ListViewItem item = null;
                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["name"]),
                            Convert.ToString(dataReader["phone"]),
                            Convert.ToString(dataReader["adress"]) });
                        listView_buyers.Items.Add(item);
                    }

                }

            }
            catch (Exception a)
            {
                MessageBox.Show("Ошибка" + a);
            }
            finally
            {
                if (dataReader != null && !dataReader.IsClosed)
                {
                    dataReader.Close();
                }
            }
        }

        private void goods_table_button_Click(object sender, EventArgs e)
        {
            buyers_panel.Visible = false;
            trades_panel.Visible = false;
            goods_panel.Visible = true;
            good_lists_panel.Visible = false;

            goods_edit_panel.Visible = true;
            buyers_edit_panel.Visible = false;
            good_lists_edit_panel.Visible = false;
            trades_edit_panel.Visible = false;

            chart_buyers.Visible = false;
            chart_goods.Visible = true;
            chart_good_lists.Visible = false;
            chart_trades.Visible = false;

            report_buyers.Visible = false;
            report_trades.Visible = false;
            report_goods.Visible = true;
            report_good_lists.Visible = false;

            buyers_filter_panel.Visible = false;
            trades_filter_panel.Visible = false;
            goods_filter_panel.Visible = true;
            good_lists_filter_panel.Visible = false;

            SqlDataReader dataReader = null;
            listView_goods.Items.Clear();
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Goods", connection);
                    dataReader = command.ExecuteReader();
                    ListViewItem item = null;
                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["name"]),
                            Convert.ToString(dataReader["wholesale_price"]),
                            Convert.ToString(dataReader["retail_price"]),
                            Convert.ToString(dataReader["description"]) });
                        listView_goods.Items.Add(item);
                    }

                }

            }
            catch (Exception a)
            {
                MessageBox.Show("Ошибка" + a);
            }
            finally
            {
                if (dataReader != null && !dataReader.IsClosed)
                {
                    dataReader.Close();
                }
            }
        }

        private void trades_table_button_Click(object sender, EventArgs e)
        {
            buyers_panel.Visible = false;
            trades_panel.Visible = true;
            goods_panel.Visible = false;
            good_lists_panel.Visible = false;

            goods_edit_panel.Visible = false;
            buyers_edit_panel.Visible = false;
            good_lists_edit_panel.Visible = false;
            trades_edit_panel.Visible = true;

            chart_buyers.Visible = false;
            chart_goods.Visible = false;
            chart_good_lists.Visible = false;
            chart_trades.Visible = true;

            report_buyers.Visible = false;
            report_trades.Visible = true;
            report_goods.Visible = false;
            report_good_lists.Visible = false;

            buyers_filter_panel.Visible = false;
            trades_filter_panel.Visible = true;
            goods_filter_panel.Visible = false;
            good_lists_filter_panel.Visible = false;

            SqlDataReader dataReader = null;
            listView_trades.Items.Clear();
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Trades", connection);
                    dataReader = command.ExecuteReader();
                    ListViewItem item = null;
                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["trade_date"]),
                            Convert.ToString(dataReader["good_list_id"]),
                            Convert.ToString(dataReader["buyer_id"]),
                            Convert.ToString(dataReader["total_cost"]),
                            Convert.ToString(dataReader["discount"]) });
                        listView_trades.Items.Add(item);
                    }

                }

            }
            catch (Exception a)
            {
                MessageBox.Show("Ошибка" + a);
            }
            finally
            {
                if (dataReader != null && !dataReader.IsClosed)
                {
                    dataReader.Close();
                }
            }

        }

        private void good_lists_table_button_Click(object sender, EventArgs e)
        {
            buyers_panel.Visible = false;
            trades_panel.Visible = false;
            goods_panel.Visible = false;
            good_lists_panel.Visible = true;

            goods_edit_panel.Visible = false;
            buyers_edit_panel.Visible = false;
            good_lists_edit_panel.Visible = true;
            trades_edit_panel.Visible = false;

            chart_buyers.Visible = false;
            chart_goods.Visible = false;
            chart_good_lists.Visible = true;
            chart_trades.Visible = false;

            report_buyers.Visible = false;
            report_trades.Visible = false;
            report_goods.Visible = false;
            report_good_lists.Visible = true;

            buyers_filter_panel.Visible = false;
            trades_filter_panel.Visible = false;
            goods_filter_panel.Visible = false;
            good_lists_filter_panel.Visible = true;

            SqlDataReader dataReader = null;
            listView_good_lists.Items.Clear();
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Good_lists", connection);
                    dataReader = command.ExecuteReader();
                    ListViewItem item = null;
                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["good_id"]),
                            Convert.ToString(dataReader["count"]),
                            Convert.ToString(dataReader["trade_type"]) });
                        listView_good_lists.Items.Add(item);
                    }

                }

            }
            catch (Exception a)
            {
                MessageBox.Show("Ошибка" + a);
            }
            finally
            {
                if (dataReader != null && !dataReader.IsClosed)
                {
                    dataReader.Close();
                }
            }
        }


        
        ///////////////////FUNCTIONS/////////////////////////////////
        

        private void show_button_Click(object sender, EventArgs e)
        {
            string[] row_buyers = null;
            string[] row_goods = null;
            string[] row_good_lists = null;
            string[] row_trades = null; 

            show_panel.Visible = true;
            edit_panel.Visible = false;
            sql_panel.Visible = false;
            filter_panel.Visible = false;
            chart_panel.Visible = false;
            report_panel.Visible = false;
            sort_panel.Visible = false;
            show_button.BackColor = Color.LightGray;
            sql_button.BackColor = Color.Transparent;
            filter_button.BackColor = Color.Transparent;
            sort_button.BackColor = Color.Transparent;
            report_button.BackColor = Color.Transparent;
            chart_button.BackColor = Color.Transparent;
            edit_button.BackColor = Color.Transparent;

            SqlDataReader dataReader = null;
            listView_good_lists.Items.Clear();
            listView_goods.Items.Clear();
            listView_buyers.Items.Clear();
            listView_trades.Items.Clear();
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Good_lists", connection);
                    dataReader = command.ExecuteReader();
                    ListViewItem item = null;
                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["good_id"]),
                            Convert.ToString(dataReader["count"]),
                            Convert.ToString(dataReader["trade_type"]) });
                        listView_good_lists.Items.Add(item);
                    }

                }
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Buyers", connection);
                    dataReader = command.ExecuteReader();
                    ListViewItem item = null;
                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["name"]),
                            Convert.ToString(dataReader["phone"]),
                            Convert.ToString(dataReader["adress"]) });
                        listView_buyers.Items.Add(item);
                    }

                }
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Trades", connection);
                    dataReader = command.ExecuteReader();
                    ListViewItem item = null;
                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["trade_date"]),
                            Convert.ToString(dataReader["good_list_id"]),
                            Convert.ToString(dataReader["buyer_id"]),
                            Convert.ToString(dataReader["total_cost"]),
                            Convert.ToString(dataReader["discount"]) });
                        listView_trades.Items.Add(item);
                    }

                }
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Goods", connection);
                    dataReader = command.ExecuteReader();
                    ListViewItem item = null;
                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["name"]),
                            Convert.ToString(dataReader["wholesale_price"]),
                            Convert.ToString(dataReader["retail_price"]),
                            Convert.ToString(dataReader["description"]) });
                        listView_goods.Items.Add(item);
                    }

                }

            }
            catch (Exception a)
            {
                MessageBox.Show("Ошибка" + a);
            }
            finally
            {
                if (dataReader != null && !dataReader.IsClosed)
                {
                    dataReader.Close();
                }
            }

        }
        private void sql_button_Click(object sender, EventArgs e)
        {
            string[] row_buyers = null;
            string[] row_goods = null;
            string[] row_good_lists = null;
            string[] row_trades = null;

            show_panel.Visible = false;
            edit_panel.Visible = false;
            sql_panel.Visible = true;
            filter_panel.Visible = false;
            chart_panel.Visible = false;
            report_panel.Visible = false;
            sort_panel.Visible = false;
            show_button.BackColor = Color.Transparent;
            sql_button.BackColor = Color.LightGray;
            filter_button.BackColor = Color.Transparent;
            sort_button.BackColor = Color.Transparent;
            report_button.BackColor = Color.Transparent;
            chart_button.BackColor = Color.Transparent;
            edit_button.BackColor = Color.Transparent;

            SqlDataReader dataReader = null;
            listView_good_lists.Items.Clear();
            listView_goods.Items.Clear();
            listView_buyers.Items.Clear();
            listView_trades.Items.Clear();
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Good_lists", connection);
                    dataReader = command.ExecuteReader();
                    ListViewItem item = null;
                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["good_id"]),
                            Convert.ToString(dataReader["count"]),
                            Convert.ToString(dataReader["trade_type"]) });
                        listView_good_lists.Items.Add(item);
                    }

                }
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Buyers", connection);
                    dataReader = command.ExecuteReader();
                    ListViewItem item = null;
                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["name"]),
                            Convert.ToString(dataReader["phone"]),
                            Convert.ToString(dataReader["adress"]) });
                        listView_buyers.Items.Add(item);
                    }

                }
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Trades", connection);
                    dataReader = command.ExecuteReader();
                    ListViewItem item = null;
                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["trade_date"]),
                            Convert.ToString(dataReader["good_list_id"]),
                            Convert.ToString(dataReader["buyer_id"]),
                            Convert.ToString(dataReader["total_cost"]),
                            Convert.ToString(dataReader["discount"]) });
                        listView_trades.Items.Add(item);
                    }

                }
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Goods", connection);
                    dataReader = command.ExecuteReader();
                    ListViewItem item = null;
                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["name"]),
                            Convert.ToString(dataReader["wholesale_price"]),
                            Convert.ToString(dataReader["retail_price"]),
                            Convert.ToString(dataReader["description"]) });
                        listView_goods.Items.Add(item);
                    }

                }

            }
            catch (Exception a)
            {
                MessageBox.Show("Ошибка" + a);
            }
            finally
            {
                if (dataReader != null && !dataReader.IsClosed)
                {
                    dataReader.Close();
                }
            }
        }
        private void filter_button_Click(object sender, EventArgs e)
        {
            show_panel.Visible = false;
            edit_panel.Visible = false;
            sql_panel.Visible = false;
            filter_panel.Visible = true;
            chart_panel.Visible = false;
            report_panel.Visible = false;
            sort_panel.Visible = false;
            show_button.BackColor = Color.Transparent;
            sql_button.BackColor = Color.Transparent;
            filter_button.BackColor = Color.LightGray;
            sort_button.BackColor = Color.Transparent;
            report_button.BackColor = Color.Transparent;
            chart_button.BackColor = Color.Transparent;
            edit_button.BackColor = Color.Transparent;

            SqlDataReader dataReader = null;
            listView_good_lists.Items.Clear();
            listView_goods.Items.Clear();
            listView_buyers.Items.Clear();
            listView_trades.Items.Clear();

            string[] row_buyers = null;
            string[] row_goods = null;
            string[] row_good_lists = null;
            string[] row_trades = null;

            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Good_lists", connection);
                    dataReader = command.ExecuteReader();
                    ListViewItem item = null;
                    rows_good_lists.Clear();
                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["good_id"]),
                            Convert.ToString(dataReader["count"]),
                            Convert.ToString(dataReader["trade_type"]) });
                        listView_good_lists.Items.Add(item);
                        row_good_lists = new string[]
                        {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["good_id"]),
                            Convert.ToString(dataReader["count"]),
                            Convert.ToString(dataReader["trade_type"])
                        };
                        rows_good_lists.Add(row_good_lists);
                    }
                    

                }
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Buyers", connection);
                    dataReader = command.ExecuteReader();
                    ListViewItem item = null;
                    rows_buyers.Clear();
                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["name"]),
                            Convert.ToString(dataReader["phone"]),
                            Convert.ToString(dataReader["adress"]) });
                        listView_buyers.Items.Add(item);
                        row_buyers = new string[]
                        {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["name"]),
                            Convert.ToString(dataReader["phone"]),
                            Convert.ToString(dataReader["adress"])
                        };
                        rows_buyers.Add(row_buyers);
                    }

                }
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Trades", connection);
                    dataReader = command.ExecuteReader();
                    ListViewItem item = null;
                    rows_trades.Clear();
                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["trade_date"]),
                            Convert.ToString(dataReader["good_list_id"]),
                            Convert.ToString(dataReader["buyer_id"]),
                            Convert.ToString(dataReader["total_cost"]),
                            Convert.ToString(dataReader["discount"]) });
                        listView_trades.Items.Add(item);
                        row_trades = new string[]
                        {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["trade_date"]),
                            Convert.ToString(dataReader["good_list_id"]),
                            Convert.ToString(dataReader["buyer_id"]),
                            Convert.ToString(dataReader["total_cost"]),
                            Convert.ToString(dataReader["discount"])
                        };
                        rows_trades.Add(row_trades);
                    }

                }
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Goods", connection);
                    dataReader = command.ExecuteReader();
                    ListViewItem item = null;
                    rows_goods.Clear();
                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["name"]),
                            Convert.ToString(dataReader["wholesale_price"]),
                            Convert.ToString(dataReader["retail_price"]),
                            Convert.ToString(dataReader["description"]) });
                        listView_goods.Items.Add(item);
                        row_goods = new string[]
                        {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["name"]),
                            Convert.ToString(dataReader["wholesale_price"]),
                            Convert.ToString(dataReader["retail_price"]),
                            Convert.ToString(dataReader["description"])
                        };
                        rows_goods.Add(row_goods);
                    }

                }

            }
            catch (Exception a)
            {
                MessageBox.Show("Ошибка" + a);
            }
            finally
            {
                if (dataReader != null && !dataReader.IsClosed)
                {
                    dataReader.Close();
                }
            }
        }
        private void sort_button_Click(object sender, EventArgs e)
        {
            string[] row_buyers = null;
            string[] row_goods = null;
            string[] row_good_lists = null;
            string[] row_trades = null;

            MessageBox.Show("Упс...Эта функция не работает в данное время");

            SqlDataReader dataReader = null;
            listView_good_lists.Items.Clear();
            listView_goods.Items.Clear();
            listView_buyers.Items.Clear();
            listView_trades.Items.Clear();
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Good_lists", connection);
                    dataReader = command.ExecuteReader();
                    ListViewItem item = null;
                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["good_id"]),
                            Convert.ToString(dataReader["count"]),
                            Convert.ToString(dataReader["trade_type"]) });
                        listView_good_lists.Items.Add(item);
                    }

                }
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Buyers", connection);
                    dataReader = command.ExecuteReader();
                    ListViewItem item = null;
                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["name"]),
                            Convert.ToString(dataReader["phone"]),
                            Convert.ToString(dataReader["adress"]) });
                        listView_buyers.Items.Add(item);
                    }

                }
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Trades", connection);
                    dataReader = command.ExecuteReader();
                    ListViewItem item = null;
                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["trade_date"]),
                            Convert.ToString(dataReader["good_list_id"]),
                            Convert.ToString(dataReader["buyer_id"]),
                            Convert.ToString(dataReader["total_cost"]),
                            Convert.ToString(dataReader["discount"]) });
                        listView_trades.Items.Add(item);
                    }

                }
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Goods", connection);
                    dataReader = command.ExecuteReader();
                    ListViewItem item = null;
                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["name"]),
                            Convert.ToString(dataReader["wholesale_price"]),
                            Convert.ToString(dataReader["retail_price"]),
                            Convert.ToString(dataReader["description"]) });
                        listView_goods.Items.Add(item);
                    }

                }

            }
            catch (Exception a)
            {
                MessageBox.Show("Ошибка" + a);
            }
            finally
            {
                if (dataReader != null && !dataReader.IsClosed)
                {
                    dataReader.Close();
                }
            }
        }
        private void report_button_Click(object sender, EventArgs e)
        {
            string[] row_buyers = null;
            string[] row_goods = null;
            string[] row_good_lists = null;
            string[] row_trades = null;

            show_panel.Visible = false;
            edit_panel.Visible = false;
            sql_panel.Visible = false;
            filter_panel.Visible = false;
            chart_panel.Visible = false;
            report_panel.Visible = true;
            sort_panel.Visible = false;
            show_button.BackColor = Color.Transparent;
            sql_button.BackColor = Color.Transparent;
            filter_button.BackColor = Color.Transparent;
            sort_button.BackColor = Color.Transparent;
            report_button.BackColor = Color.LightGray;
            chart_button.BackColor = Color.Transparent;
            edit_button.BackColor = Color.Transparent;

            SqlDataReader dataReader = null;
            listView_good_lists.Items.Clear();
            listView_goods.Items.Clear();
            listView_buyers.Items.Clear();
            listView_trades.Items.Clear();
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Good_lists", connection);
                    dataReader = command.ExecuteReader();
                    ListViewItem item = null;
                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["good_id"]),
                            Convert.ToString(dataReader["count"]),
                            Convert.ToString(dataReader["trade_type"]) });
                        listView_good_lists.Items.Add(item);
                    }

                }
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Buyers", connection);
                    dataReader = command.ExecuteReader();
                    ListViewItem item = null;
                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["name"]),
                            Convert.ToString(dataReader["phone"]),
                            Convert.ToString(dataReader["adress"]) });
                        listView_buyers.Items.Add(item);
                    }

                }
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Trades", connection);
                    dataReader = command.ExecuteReader();
                    ListViewItem item = null;
                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["trade_date"]),
                            Convert.ToString(dataReader["good_list_id"]),
                            Convert.ToString(dataReader["buyer_id"]),
                            Convert.ToString(dataReader["total_cost"]),
                            Convert.ToString(dataReader["discount"]) });
                        listView_trades.Items.Add(item);
                    }

                }
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Goods", connection);
                    dataReader = command.ExecuteReader();
                    ListViewItem item = null;
                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["name"]),
                            Convert.ToString(dataReader["wholesale_price"]),
                            Convert.ToString(dataReader["retail_price"]),
                            Convert.ToString(dataReader["description"]) });
                        listView_goods.Items.Add(item);
                    }

                }

            }
            catch (Exception a)
            {
                MessageBox.Show("Ошибка" + a);
            }
            finally
            {
                if (dataReader != null && !dataReader.IsClosed)
                {
                    dataReader.Close();
                }
            }
        }
        private void chart_button_Click(object sender, EventArgs e)
        {
            string[] row_buyers = null;
            string[] row_goods = null;
            string[] row_good_lists = null;
            string[] row_trades = null;

            show_panel.Visible = false;
            edit_panel.Visible = false;
            sql_panel.Visible = false;
            filter_panel.Visible = false;
            chart_panel.Visible = true;
            report_panel.Visible = false;
            sort_panel.Visible = false;
            show_button.BackColor = Color.Transparent;
            sql_button.BackColor = Color.Transparent;
            filter_button.BackColor = Color.Transparent;
            sort_button.BackColor = Color.Transparent;
            report_button.BackColor = Color.Transparent;
            chart_button.BackColor = Color.LightGray;
            edit_button.BackColor = Color.Transparent;

            //////
            using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
            {
                connection.Open();
                dataAdapter = new SqlDataAdapter("SELECT * FROM Trades", connection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "Trades");
                table = dataSet.Tables["Trades"];
                cartesianChart1.LegendLocation = LegendLocation.Bottom;

                SeriesCollection series_trades = new SeriesCollection();
                ChartValues<decimal> total_cost = new ChartValues<decimal>();
                List<string> id = new List<string>();
                foreach (DataRow row in table.Rows)
                {
                    total_cost.Add(Convert.ToInt32(row["total_cost"]));
                    id.Add(Convert.ToString(row["discount"]));
                }
                cartesianChart1.AxisX.Clear();
                cartesianChart1.AxisX.Add(new Axis()
                {
                    Title = "",
                    Labels = id
                });
                LineSeries line_trades = new LineSeries();
                line_trades.Title = "Соотношение общей стоимости и скидки";
                line_trades.Values = total_cost;
                series_trades.Add(line_trades);
                cartesianChart1.Series = series_trades;
            }
            //////
            using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
            {
                connection.Open();
                dataAdapter = new SqlDataAdapter("SELECT * FROM Goods", connection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "Goods");
                table = dataSet.Tables["Goods"];
                cartesianChart3.LegendLocation = LegendLocation.Bottom;

                SeriesCollection series_goods = new SeriesCollection();
                ChartValues<decimal> wholesale_price = new ChartValues<decimal>();
                List<string> retail_price = new List<string>();
                foreach (DataRow row in table.Rows)
                {
                    wholesale_price.Add(Convert.ToInt32(row["wholesale_price"]));
                    retail_price.Add(Convert.ToString(row["retail_price"]));
                }
                cartesianChart3.AxisX.Clear();
                cartesianChart3.AxisX.Add(new Axis()
                {
                    Title = "",
                    Labels = retail_price
                });
                LineSeries line_goods = new LineSeries();
                line_goods.Title = "Соотношение оптовой и розничной цены товара";
                line_goods.Values = wholesale_price;
                series_goods.Add(line_goods);
                cartesianChart3.Series = series_goods;
            }
            //////
            using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
            {
                connection.Open();
                dataAdapter = new SqlDataAdapter("SELECT * FROM Good_lists", connection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "Good_lists");
                table = dataSet.Tables["Good_lists"];
                cartesianChart4.LegendLocation = LegendLocation.Bottom;

                SeriesCollection series_good_lists = new SeriesCollection();
                ChartValues<int> count = new ChartValues<int>();
                List<string> id = new List<string>();
                foreach (DataRow row in table.Rows)
                {
                    count.Add(Convert.ToInt32(row["count"]));
                    id.Add(Convert.ToString(row["id"]));
                }
                cartesianChart4.AxisX.Clear();
                cartesianChart4.AxisX.Add(new Axis()
                {
                    Title = "",
                    Labels = id
                });
                LineSeries line_good_lists = new LineSeries();
                line_good_lists.Title = "Количество товара";
                line_good_lists.Values = count;
                series_good_lists.Add(line_good_lists);
                cartesianChart4.Series = series_good_lists;
            }
            //////
            ///
            SqlDataReader dataReader = null;
            listView_good_lists.Items.Clear();
            listView_goods.Items.Clear();
            listView_buyers.Items.Clear();
            listView_trades.Items.Clear();
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Good_lists", connection);
                    dataReader = command.ExecuteReader();
                    ListViewItem item = null;
                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["good_id"]),
                            Convert.ToString(dataReader["count"]),
                            Convert.ToString(dataReader["trade_type"]) });
                        listView_good_lists.Items.Add(item);
                    }

                }
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Buyers", connection);
                    dataReader = command.ExecuteReader();
                    ListViewItem item = null;
                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["name"]),
                            Convert.ToString(dataReader["phone"]),
                            Convert.ToString(dataReader["adress"]) });
                        listView_buyers.Items.Add(item);
                    }

                }
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Trades", connection);
                    dataReader = command.ExecuteReader();
                    ListViewItem item = null;
                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["trade_date"]),
                            Convert.ToString(dataReader["good_list_id"]),
                            Convert.ToString(dataReader["buyer_id"]),
                            Convert.ToString(dataReader["total_cost"]),
                            Convert.ToString(dataReader["discount"]) });
                        listView_trades.Items.Add(item);
                    }

                }
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Goods", connection);
                    dataReader = command.ExecuteReader();
                    ListViewItem item = null;
                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["name"]),
                            Convert.ToString(dataReader["wholesale_price"]),
                            Convert.ToString(dataReader["retail_price"]),
                            Convert.ToString(dataReader["description"]) });
                        listView_goods.Items.Add(item);
                    }

                }

            }
            catch (Exception a)
            {
                MessageBox.Show("Ошибка" + a);
            }
            finally
            {
                if (dataReader != null && !dataReader.IsClosed)
                {
                    dataReader.Close();
                }
            }
        }
        private void edit_button_Click(object sender, EventArgs e)
        {
            string[] row_buyers = null;
            string[] row_goods = null;
            string[] row_good_lists = null;
            string[] row_trades = null;

            show_panel.Visible = false;
            edit_panel.Visible = true;
            sql_panel.Visible = false;
            filter_panel.Visible = false;
            chart_panel.Visible = false;
            report_panel.Visible = false;
            sort_panel.Visible = false;
            show_button.BackColor = Color.Transparent;
            sql_button.BackColor = Color.Transparent;
            filter_button.BackColor = Color.Transparent;
            sort_button.BackColor = Color.Transparent;
            report_button.BackColor = Color.Transparent;
            chart_button.BackColor = Color.Transparent;
            edit_button.BackColor = Color.LightGray;

            SqlDataReader dataReader = null;
            listView_good_lists.Items.Clear();
            listView_goods.Items.Clear();
            listView_buyers.Items.Clear();
            listView_trades.Items.Clear();
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Good_lists", connection);
                    dataReader = command.ExecuteReader();
                    ListViewItem item = null;
                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["good_id"]),
                            Convert.ToString(dataReader["count"]),
                            Convert.ToString(dataReader["trade_type"]) });
                        listView_good_lists.Items.Add(item);
                    }

                }
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Buyers", connection);
                    dataReader = command.ExecuteReader();
                    ListViewItem item = null;
                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["name"]),
                            Convert.ToString(dataReader["phone"]),
                            Convert.ToString(dataReader["adress"]) });
                        listView_buyers.Items.Add(item);
                    }

                }
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Trades", connection);
                    dataReader = command.ExecuteReader();
                    ListViewItem item = null;
                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["trade_date"]),
                            Convert.ToString(dataReader["good_list_id"]),
                            Convert.ToString(dataReader["buyer_id"]),
                            Convert.ToString(dataReader["total_cost"]),
                            Convert.ToString(dataReader["discount"]) });
                        listView_trades.Items.Add(item);
                    }

                }
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Goods", connection);
                    dataReader = command.ExecuteReader();
                    ListViewItem item = null;
                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["name"]),
                            Convert.ToString(dataReader["wholesale_price"]),
                            Convert.ToString(dataReader["retail_price"]),
                            Convert.ToString(dataReader["description"]) });
                        listView_goods.Items.Add(item);
                    }

                }

            }
            catch (Exception a)
            {
                MessageBox.Show("Ошибка" + a);
            }
            finally
            {
                if (dataReader != null && !dataReader.IsClosed)
                {
                    dataReader.Close();
                }
            }
        }
        private void about_button_Click(object sender, EventArgs e)
        {
            KA6.ActiveForm.Hide();
            About_6KA NewForm = new About_6KA();
            NewForm.ShowDialog();
            Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            KA6.ActiveForm.Hide();
            SHIO_app NewForm = new SHIO_app();
            NewForm.ShowDialog();
            Close();
        }

         //////////////////////EDIT_BUTTONS///////////////////////////////////
        private void add_good_lists_Click(object sender, EventArgs e)
        {
            int id = (int)good_lists_id_box.Value;
            int good_id = (int)good_lists_good_id_box.Value;
            int count = (int)good_lists_count_box.Value;
            string trade_type = (string)good_lists_trade_type_box.Text;

            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand add = new SqlCommand("INSERT INTO Good_lists VALUES (@id, @good_id, @count, @trade_type) ", connection);
                    SqlParameter p1 = new SqlParameter("@id", id);
                    add.Parameters.Add(p1);
                    SqlParameter p2 = new SqlParameter("@good_id", good_id);
                    add.Parameters.Add(p2);
                    SqlParameter p3 = new SqlParameter("@count", count);
                    add.Parameters.Add(p3);
                    SqlParameter p4 = new SqlParameter("@trade_type", trade_type);
                    add.Parameters.Add(p4);
                    add.ExecuteNonQuery();
                }
            }
            catch (FormatException a)
            {
                MessageBox.Show("Ошибка!");
            }
            catch (SqlException a)
            {
                MessageBox.Show("Ошибка!"+a);
            }
            catch (OverflowException a)
            {
                MessageBox.Show("Ошибка!");
            }

            this.buyersTableAdapter2.Fill(this.kA6DataSet2.Buyers);
            this.goodsTableAdapter2.Fill(this.kA6DataSet2.Goods);
            this.tradesTableAdapter2.Fill(this.kA6DataSet2.Trades);
            this.good_listsTableAdapter2.Fill(this.kA6DataSet2.Good_lists);

            SqlDataReader dataReader = null;
            listView_good_lists.Items.Clear();
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Good_lists", connection);
                    dataReader = command.ExecuteReader();
                    ListViewItem item = null;
                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["good_id"]),
                            Convert.ToString(dataReader["count"]),
                            Convert.ToString(dataReader["trade_type"]) });
                        listView_good_lists.Items.Add(item);
                    }

                }

            }
            catch (Exception a)
            {
                MessageBox.Show("Ошибка" + a);
            }
            finally
            {
                if (dataReader != null && !dataReader.IsClosed)
                {
                    dataReader.Close();
                }
            }
        }
        private void delete_good_lists_Click(object sender, EventArgs e)
        {
            int id = (int)good_lists_id_box.Value;
            int good_id = (int)good_lists_good_id_box.Value;
            int count = (int)good_lists_count_box.Value;
            string trade_type = (string)good_lists_trade_type_box.Text;

            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand delete = new SqlCommand("DELETE FROM Good_lists WHERE id = @id AND good_id = @good_id AND count = @count AND trade_type = @trade_type", connection);
                    SqlParameter p1 = new SqlParameter("@id", id);
                    delete.Parameters.Add(p1);
                    SqlParameter p2 = new SqlParameter("@good_id", good_id);
                    delete.Parameters.Add(p2);
                    SqlParameter p3 = new SqlParameter("@count", count);
                    delete.Parameters.Add(p3);
                    SqlParameter p4 = new SqlParameter("@trade_type", trade_type);
                    delete.Parameters.Add(p4);
                    delete.ExecuteNonQuery();
                }
            }
            catch (FormatException a)
            {
                MessageBox.Show("Ошибка!");
            }
            catch (SqlException a)
            {
                MessageBox.Show("Ошибка!" + a);
            }
            catch (OverflowException a)
            {
                MessageBox.Show("Ошибка!");
            }

            this.buyersTableAdapter2.Fill(this.kA6DataSet2.Buyers);
            this.goodsTableAdapter2.Fill(this.kA6DataSet2.Goods);
            this.tradesTableAdapter2.Fill(this.kA6DataSet2.Trades);
            this.good_listsTableAdapter2.Fill(this.kA6DataSet2.Good_lists);

            SqlDataReader dataReader = null;
            listView_good_lists.Items.Clear();
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Good_lists", connection);
                    dataReader = command.ExecuteReader();
                    ListViewItem item = null;
                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["good_id"]),
                            Convert.ToString(dataReader["count"]),
                            Convert.ToString(dataReader["trade_type"]) });
                        listView_good_lists.Items.Add(item);
                    }

                }

            }
            catch (Exception a)
            {
                MessageBox.Show("Ошибка" + a);
            }
            finally
            {
                if (dataReader != null && !dataReader.IsClosed)
                {
                    dataReader.Close();
                }
            }
        }
        private void clean_good_lists_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand clean = new SqlCommand("DELETE FROM Good_lists", connection);
                    clean.ExecuteNonQuery();
                }
            }
            catch (FormatException a)
            {
                MessageBox.Show("Ошибка!");
            }
            catch (SqlException a)
            {
                MessageBox.Show("Ошибка!" + a);
            }
            catch (OverflowException a)
            {
                MessageBox.Show("Ошибка!");
            }

            this.buyersTableAdapter2.Fill(this.kA6DataSet2.Buyers);
            this.goodsTableAdapter2.Fill(this.kA6DataSet2.Goods);
            this.tradesTableAdapter2.Fill(this.kA6DataSet2.Trades);
            this.good_listsTableAdapter2.Fill(this.kA6DataSet2.Good_lists);

            SqlDataReader dataReader = null;
            listView_good_lists.Items.Clear();
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Good_lists", connection);
                    dataReader = command.ExecuteReader();
                    ListViewItem item = null;
                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["good_id"]),
                            Convert.ToString(dataReader["count"]),
                            Convert.ToString(dataReader["trade_type"]) });
                        listView_good_lists.Items.Add(item);
                    }

                }

            }
            catch (Exception a)
            {
                MessageBox.Show("Ошибка" + a);
            }
            finally
            {
                if (dataReader != null && !dataReader.IsClosed)
                {
                    dataReader.Close();
                }
            }
        }
        private void edit_good_lists_Click(object sender, EventArgs e)
        {
            good_lists_new_box.Value = good_lists_id_box.Value;
            edit_good_lists.Visible = false;
            add_good_lists.Visible = false;
            delete_good_lists.Visible = false;
            clean_good_lists.Visible = false;
            save_good_lists.Visible = true;
        }




        private void add_goods_Click(object sender, EventArgs e)
        {
            int id = (int)goods_id_box.Value;
            int wholesale_price = (int)goods_wholesale_price_box.Value;
            int retail_price = (int)goods_retail_price_box.Value;
            string name = (string)goods_name_box.Text;
            string description = (string)goods_description_box.Text;

            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand add = new SqlCommand("INSERT INTO Goods VALUES (@id, @name, @wholesale_price, @retail_price, @description) ", connection);
                    SqlParameter p1 = new SqlParameter("@id", id);
                    add.Parameters.Add(p1);
                    SqlParameter p2 = new SqlParameter("@name", name);
                    add.Parameters.Add(p2);
                    SqlParameter p3 = new SqlParameter("@wholesale_price", wholesale_price);
                    add.Parameters.Add(p3);
                    SqlParameter p4 = new SqlParameter("@retail_price", retail_price);
                    add.Parameters.Add(p4);
                    SqlParameter p5 = new SqlParameter("@description", description);
                    add.Parameters.Add(p5);
                    add.ExecuteNonQuery();
                }
            }
            catch (FormatException a)
            {
                MessageBox.Show("Ошибка!");
            }
            catch (SqlException a)
            {
                MessageBox.Show("Ошибка!"+a);
            }
            catch (OverflowException a)
            {
                MessageBox.Show("Ошибка!");
            }

            this.buyersTableAdapter2.Fill(this.kA6DataSet2.Buyers);
            this.goodsTableAdapter2.Fill(this.kA6DataSet2.Goods);
            this.tradesTableAdapter2.Fill(this.kA6DataSet2.Trades);
            this.good_listsTableAdapter2.Fill(this.kA6DataSet2.Good_lists);

            SqlDataReader dataReader = null;
            listView_goods.Items.Clear();
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Goods", connection);
                    dataReader = command.ExecuteReader();
                    ListViewItem item = null;
                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["name"]),
                            Convert.ToString(dataReader["wholesale_price"]),
                            Convert.ToString(dataReader["retail_price"]),
                            Convert.ToString(dataReader["description"]) });
                        listView_goods.Items.Add(item);
                    }

                }

            }
            catch (Exception a)
            {
                MessageBox.Show("Ошибка" + a);
            }
            finally
            {
                if (dataReader != null && !dataReader.IsClosed)
                {
                    dataReader.Close();
                }
            }
        }
        private void delete_goods_Click(object sender, EventArgs e)
        {
            int id = (int)goods_id_box.Value;
            int wholesale_price = (int)goods_wholesale_price_box.Value;
            int retail_price = (int)goods_retail_price_box.Value;
            string name = (string)goods_name_box.Text;
            string description = (string)goods_description_box.Text;

            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand delete = new SqlCommand("DELETE FROM Goods WHERE id = @id AND name = @name AND wholesale_price = @wholesale_price AND retail_price = @retail_price AND description = @description", connection);
                    SqlParameter p1 = new SqlParameter("@id", id);
                    delete.Parameters.Add(p1);
                    SqlParameter p2 = new SqlParameter("@name", name);
                    delete.Parameters.Add(p2);
                    SqlParameter p3 = new SqlParameter("@wholesale_price", wholesale_price);
                    delete.Parameters.Add(p3);
                    SqlParameter p4 = new SqlParameter("@retail_price", retail_price);
                    delete.Parameters.Add(p4);
                    SqlParameter p5 = new SqlParameter("@description", description);
                    delete.Parameters.Add(p5);
                    delete.ExecuteNonQuery();
                }
            }
            catch (FormatException a)
            {
                MessageBox.Show("Ошибка!");
            }
            catch (SqlException a)
            {
                MessageBox.Show("Ошибка!" + a);
            }
            catch (OverflowException a)
            {
                MessageBox.Show("Ошибка!");
            }

            this.buyersTableAdapter2.Fill(this.kA6DataSet2.Buyers);
            this.goodsTableAdapter2.Fill(this.kA6DataSet2.Goods);
            this.tradesTableAdapter2.Fill(this.kA6DataSet2.Trades);
            this.good_listsTableAdapter2.Fill(this.kA6DataSet2.Good_lists);

            SqlDataReader dataReader = null;
            listView_goods.Items.Clear();
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Goods", connection);
                    dataReader = command.ExecuteReader();
                    ListViewItem item = null;
                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["name"]),
                            Convert.ToString(dataReader["wholesale_price"]),
                            Convert.ToString(dataReader["retail_price"]),
                            Convert.ToString(dataReader["description"]) });
                        listView_goods.Items.Add(item);
                    }

                }

            }
            catch (Exception a)
            {
                MessageBox.Show("Ошибка" + a);
            }
            finally
            {
                if (dataReader != null && !dataReader.IsClosed)
                {
                    dataReader.Close();
                }
            }
        }
        private void clean_goods_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand clean = new SqlCommand("DELETE FROM Goods", connection);
                    clean.ExecuteNonQuery();
                }
            }
            catch (FormatException a)
            {
                MessageBox.Show("Ошибка!");
            }
            catch (SqlException a)
            {
                MessageBox.Show("Ошибка!" + a);
            }
            catch (OverflowException a)
            {
                MessageBox.Show("Ошибка!");
            }

            this.buyersTableAdapter2.Fill(this.kA6DataSet2.Buyers);
            this.goodsTableAdapter2.Fill(this.kA6DataSet2.Goods);
            this.tradesTableAdapter2.Fill(this.kA6DataSet2.Trades);
            this.good_listsTableAdapter2.Fill(this.kA6DataSet2.Good_lists);

            SqlDataReader dataReader = null;
            listView_goods.Items.Clear();
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Goods", connection);
                    dataReader = command.ExecuteReader();
                    ListViewItem item = null;
                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["name"]),
                            Convert.ToString(dataReader["wholesale_price"]),
                            Convert.ToString(dataReader["retail_price"]),
                            Convert.ToString(dataReader["description"]) });
                        listView_goods.Items.Add(item);
                    }

                }

            }
            catch (Exception a)
            {
                MessageBox.Show("Ошибка" + a);
            }
            finally
            {
                if (dataReader != null && !dataReader.IsClosed)
                {
                    dataReader.Close();
                }
            }
        }
        private void edit_goods_Click(object sender, EventArgs e)
        {
            goods_new_box.Value = goods_id_box.Value;
            edit_goods.Visible = false;
            add_goods.Visible = false;
            delete_goods.Visible = false;
            clean_goods.Visible = false;
            save_goods.Visible = true;
        }




        private void add_trades_Click(object sender, EventArgs e)
        {
            int id = (int)trades_id_box.Value;
            int good_list_id = (int)trades_good_list_id_box.Value;
            int buyer_id = (int)trades_buyer_id_box.Value;
            int total_cost = (int)trades_total_cost_box.Value;
            int discount = (int)trades_discount_box.Value;
            DateTime trade_date = (DateTime)trades_trade_date_box.Value;

            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand add = new SqlCommand("INSERT INTO Trades VALUES (@id, @trade_date, @good_list_id, @buyer_id, @total_cost, @discount) ", connection);
                    SqlParameter p1 = new SqlParameter("@id", id);
                    add.Parameters.Add(p1);
                    SqlParameter p2 = new SqlParameter("@trade_date", trade_date);
                    add.Parameters.Add(p2);
                    SqlParameter p3 = new SqlParameter("@good_list_id", good_list_id);
                    add.Parameters.Add(p3);
                    SqlParameter p4 = new SqlParameter("@buyer_id", buyer_id);
                    add.Parameters.Add(p4);
                    SqlParameter p5 = new SqlParameter("@total_cost", total_cost);
                    add.Parameters.Add(p5);
                    SqlParameter p6 = new SqlParameter("@discount", discount);
                    add.Parameters.Add(p6);
                    add.ExecuteNonQuery();
                }
            }
            catch (FormatException a)
            {
                MessageBox.Show("Ошибка!");
            }
            catch (SqlException a)
            {
                MessageBox.Show("Ошибка!"+a);
            }
            catch (OverflowException a)
            {
                MessageBox.Show("Ошибка!");
            }

            this.buyersTableAdapter2.Fill(this.kA6DataSet2.Buyers);
            this.goodsTableAdapter2.Fill(this.kA6DataSet2.Goods);
            this.tradesTableAdapter2.Fill(this.kA6DataSet2.Trades);
            this.good_listsTableAdapter2.Fill(this.kA6DataSet2.Good_lists);

            SqlDataReader dataReader = null;
            listView_trades.Items.Clear();
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Trades", connection);
                    dataReader = command.ExecuteReader();
                    ListViewItem item = null;
                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["trade_date"]),
                            Convert.ToString(dataReader["good_list_id"]),
                            Convert.ToString(dataReader["buyer_id"]),
                            Convert.ToString(dataReader["total_cost"]),
                            Convert.ToString(dataReader["discount"]) });
                        listView_trades.Items.Add(item);
                    }

                }

            }
            catch (Exception a)
            {
                MessageBox.Show("Ошибка" + a);
            }
            finally
            {
                if (dataReader != null && !dataReader.IsClosed)
                {
                    dataReader.Close();
                }
            }
        }
        private void delete_trades_Click(object sender, EventArgs e)
        {
            int id = (int)trades_id_box.Value;
            int good_list_id = (int)trades_good_list_id_box.Value;
            int buyer_id = (int)trades_buyer_id_box.Value;
            int total_cost = (int)trades_total_cost_box.Value;
            int discount = (int)trades_discount_box.Value;
            DateTime trade_date = (DateTime)trades_trade_date_box.Value;

            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand delete = new SqlCommand("DELETE FROM Trades WHERE id = @id AND trade_date = @trade_date AND good_list_id = @good_list_id AND buyer_id = @buyer_id AND total_cost = @total_cost AND discount = @discount", connection);
                    SqlParameter p1 = new SqlParameter("@id", id);
                    delete.Parameters.Add(p1);
                    SqlParameter p2 = new SqlParameter("@trade_date", trade_date);
                    delete.Parameters.Add(p2);
                    SqlParameter p3 = new SqlParameter("@good_list_id", good_list_id);
                    delete.Parameters.Add(p3);
                    SqlParameter p4 = new SqlParameter("@buyer_id", buyer_id);
                    delete.Parameters.Add(p4);
                    SqlParameter p5 = new SqlParameter("@total_cost", total_cost);
                    delete.Parameters.Add(p5);
                    SqlParameter p6 = new SqlParameter("@discount", discount);
                    delete.Parameters.Add(p6);
                    delete.ExecuteNonQuery();
                }
            }
            catch (FormatException a)
            {
                MessageBox.Show("Ошибка!");
            }
            catch (SqlException a)
            {
                MessageBox.Show("Ошибка!" + a);
            }
            catch (OverflowException a)
            {
                MessageBox.Show("Ошибка!");
            }

            this.buyersTableAdapter2.Fill(this.kA6DataSet2.Buyers);
            this.goodsTableAdapter2.Fill(this.kA6DataSet2.Goods);
            this.tradesTableAdapter2.Fill(this.kA6DataSet2.Trades);
            this.good_listsTableAdapter2.Fill(this.kA6DataSet2.Good_lists);

            SqlDataReader dataReader = null;
            listView_trades.Items.Clear();
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Trades", connection);
                    dataReader = command.ExecuteReader();
                    ListViewItem item = null;
                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["trade_date"]),
                            Convert.ToString(dataReader["good_list_id"]),
                            Convert.ToString(dataReader["buyer_id"]),
                            Convert.ToString(dataReader["total_cost"]),
                            Convert.ToString(dataReader["discount"]) });
                        listView_trades.Items.Add(item);
                    }

                }

            }
            catch (Exception a)
            {
                MessageBox.Show("Ошибка" + a);
            }
            finally
            {
                if (dataReader != null && !dataReader.IsClosed)
                {
                    dataReader.Close();
                }
            }
        }
        private void clean_trades_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand clean = new SqlCommand("DELETE FROM Trades", connection);
                    clean.ExecuteNonQuery();
                }
            }
            catch (FormatException a)
            {
                MessageBox.Show("Ошибка!");
            }
            catch (SqlException a)
            {
                MessageBox.Show("Ошибка!" + a);
            }
            catch (OverflowException a)
            {
                MessageBox.Show("Ошибка!");
            }

            this.buyersTableAdapter2.Fill(this.kA6DataSet2.Buyers);
            this.goodsTableAdapter2.Fill(this.kA6DataSet2.Goods);
            this.tradesTableAdapter2.Fill(this.kA6DataSet2.Trades);
            this.good_listsTableAdapter2.Fill(this.kA6DataSet2.Good_lists);

            SqlDataReader dataReader = null;
            listView_trades.Items.Clear();
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Trades", connection);
                    dataReader = command.ExecuteReader();
                    ListViewItem item = null;
                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["trade_date"]),
                            Convert.ToString(dataReader["good_list_id"]),
                            Convert.ToString(dataReader["buyer_id"]),
                            Convert.ToString(dataReader["total_cost"]),
                            Convert.ToString(dataReader["discount"]) });
                        listView_trades.Items.Add(item);
                    }

                }

            }
            catch (Exception a)
            {
                MessageBox.Show("Ошибка" + a);
            }
            finally
            {
                if (dataReader != null && !dataReader.IsClosed)
                {
                    dataReader.Close();
                }
            }
        }
        private void edit_trades_Click(object sender, EventArgs e)
        {
            trades_new_box.Value = trades_id_box.Value;
            edit_trades.Visible = false;
            add_trades.Visible = false;
            delete_trades.Visible = false;
            clean_trades.Visible = false;
            save_trades.Visible = true;
        }




        private void add_buyers_Click(object sender, EventArgs e)
        {
            int id = (int)buyers_id_box.Value;
            string name = (string)buyers_name_box.Text;
            string phone = (string)buyers_phone_box.Text;
            string adress = (string)buyers_adress_box.Text;

            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    conn.Open();
                    SqlCommand add_buyer = new SqlCommand("INSERT INTO Buyers VALUES (@id, @name, @phone, @adress) ", conn);
                    SqlParameter n1 = new SqlParameter("@id", id);
                    add_buyer.Parameters.Add(n1);
                    SqlParameter n2 = new SqlParameter("@name", name);
                    add_buyer.Parameters.Add(n2);
                    SqlParameter n3 = new SqlParameter("@phone", phone);
                    add_buyer.Parameters.Add(n3);
                    SqlParameter n4 = new SqlParameter("@adress", adress);
                    add_buyer.Parameters.Add(n4);
                    add_buyer.ExecuteNonQuery();
                }
            }
            catch (FormatException a)
            {
                MessageBox.Show("Ошибка!");
            }
            catch (SqlException a)
            {
                MessageBox.Show("Ошибка!"+a);
            }
            catch (OverflowException a)
            {
                MessageBox.Show("Ошибка!");
            }

            this.buyersTableAdapter2.Fill(this.kA6DataSet2.Buyers);
            this.goodsTableAdapter2.Fill(this.kA6DataSet2.Goods);
            this.tradesTableAdapter2.Fill(this.kA6DataSet2.Trades);
            this.good_listsTableAdapter2.Fill(this.kA6DataSet2.Good_lists);

            SqlDataReader dataReader = null;
            listView_buyers.Items.Clear();
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Buyers", connection);
                    dataReader = command.ExecuteReader();
                    ListViewItem item = null;
                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["name"]),
                            Convert.ToString(dataReader["phone"]),
                            Convert.ToString(dataReader["adress"]) });
                        listView_buyers.Items.Add(item);
                    }

                }

            }
            catch (Exception a)
            {
                MessageBox.Show("Ошибка" + a);
            }
            finally
            {
                if (dataReader != null && !dataReader.IsClosed)
                {
                    dataReader.Close();
                }
            }
        }
        private void delete_buyers_Click(object sender, EventArgs e)
        {
            int id = (int)buyers_id_box.Value;
            string name = (string)buyers_name_box.Text;
            string phone = (string)buyers_phone_box.Text;
            string adress = (string)buyers_adress_box.Text;

            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand delete = new SqlCommand("DELETE FROM Buyers WHERE id = @id AND name = @name AND phone = @phone AND adress = @adress", connection);
                    SqlParameter n1 = new SqlParameter("@id", id);
                    delete.Parameters.Add(n1);
                    SqlParameter n2 = new SqlParameter("@name", name);
                    delete.Parameters.Add(n2);
                    SqlParameter n3 = new SqlParameter("@phone", phone);
                    delete.Parameters.Add(n3);
                    SqlParameter n4 = new SqlParameter("@adress", adress);
                    delete.Parameters.Add(n4);
                    delete.ExecuteNonQuery();
                }
            }
            catch (FormatException a)
            {
                MessageBox.Show("Ошибка!");
            }
            catch (SqlException a)
            {
                MessageBox.Show("Ошибка!" + a);
            }
            catch (OverflowException a)
            {
                MessageBox.Show("Ошибка!");
            }

            this.buyersTableAdapter2.Fill(this.kA6DataSet2.Buyers);
            this.goodsTableAdapter2.Fill(this.kA6DataSet2.Goods);
            this.tradesTableAdapter2.Fill(this.kA6DataSet2.Trades);
            this.good_listsTableAdapter2.Fill(this.kA6DataSet2.Good_lists);

            SqlDataReader dataReader = null;
            listView_buyers.Items.Clear();
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Buyers", connection);
                    dataReader = command.ExecuteReader();
                    ListViewItem item = null;
                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["name"]),
                            Convert.ToString(dataReader["phone"]),
                            Convert.ToString(dataReader["adress"]) });
                        listView_buyers.Items.Add(item);
                    }

                }

            }
            catch (Exception a)
            {
                MessageBox.Show("Ошибка" + a);
            }
            finally
            {
                if (dataReader != null && !dataReader.IsClosed)
                {
                    dataReader.Close();
                }
            }
        }
        private void clean_buyers_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand clean = new SqlCommand("DELETE FROM Buyers", connection);
                    clean.ExecuteNonQuery();
                }
            }
            catch (FormatException a)
            {
                MessageBox.Show("Ошибка!");
            }
            catch (SqlException a)
            {
                MessageBox.Show("Ошибка!" + a);
            }
            catch (OverflowException a)
            {
                MessageBox.Show("Ошибка!");
            }

            this.buyersTableAdapter2.Fill(this.kA6DataSet2.Buyers);
            this.goodsTableAdapter2.Fill(this.kA6DataSet2.Goods);
            this.tradesTableAdapter2.Fill(this.kA6DataSet2.Trades);
            this.good_listsTableAdapter2.Fill(this.kA6DataSet2.Good_lists);

            SqlDataReader dataReader = null;
            listView_buyers.Items.Clear();
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Buyers", connection);
                    dataReader = command.ExecuteReader();
                    ListViewItem item = null;
                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["name"]),
                            Convert.ToString(dataReader["phone"]),
                            Convert.ToString(dataReader["adress"]) });
                        listView_buyers.Items.Add(item);
                    }

                }

            }
            catch (Exception a)
            {
                MessageBox.Show("Ошибка" + a);
            }
            finally
            {
                if (dataReader != null && !dataReader.IsClosed)
                {
                    dataReader.Close();
                }
            }
        }
        private void edit_buyers_Click(object sender, EventArgs e)
        {
            buyers_new_box.Value = buyers_id_box.Value;
            edit_buyers.Visible = false;
            add_buyers.Visible = false;
            delete_buyers.Visible = false;
            clean_buyers.Visible = false;
            save_buyers.Visible = true;
        }



        private void save_good_lists_Click(object sender, EventArgs e)
        {
            try
            {
                edit_good_lists.Visible = true;
                add_good_lists.Visible = true;
                delete_good_lists.Visible = true;
                clean_good_lists.Visible = true;
                save_good_lists.Visible = false;
                int old_id = (int)good_lists_new_box.Value;
                int id = (int)good_lists_id_box.Value;
                int good_id = (int)good_lists_good_id_box.Value;
                int count = (int)good_lists_count_box.Value;
                string trade_type = (string)good_lists_trade_type_box.Text;
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand edit = new SqlCommand("UPDATE Good_lists SET id=@id, good_id=@good_id, count=@count, trade_type=@trade_type WHERE id = @old_id", connection);
                    SqlParameter p1 = new SqlParameter("@id", id);
                    edit.Parameters.Add(p1);
                    SqlParameter p2 = new SqlParameter("@good_id", good_id);
                    edit.Parameters.Add(p2);
                    SqlParameter p3 = new SqlParameter("@count", count);
                    edit.Parameters.Add(p3);
                    SqlParameter p4 = new SqlParameter("@trade_type", trade_type);
                    edit.Parameters.Add(p4);
                    SqlParameter p5 = new SqlParameter("@old_id", old_id);
                    edit.Parameters.Add(p5);
                    edit.ExecuteNonQuery();
                }
                this.buyersTableAdapter2.Fill(this.kA6DataSet2.Buyers);
                this.goodsTableAdapter2.Fill(this.kA6DataSet2.Goods);
                this.tradesTableAdapter2.Fill(this.kA6DataSet2.Trades);
                this.good_listsTableAdapter2.Fill(this.kA6DataSet2.Good_lists);

                SqlDataReader dataReader = null;
                listView_good_lists.Items.Clear();
                try
                {
                    using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand("SELECT * FROM Good_lists", connection);
                        dataReader = command.ExecuteReader();
                        ListViewItem item = null;
                        while (dataReader.Read())
                        {
                            item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["good_id"]),
                            Convert.ToString(dataReader["count"]),
                            Convert.ToString(dataReader["trade_type"]) });
                            listView_good_lists.Items.Add(item);
                        }

                    }

                }
                catch (Exception a)
                {
                    MessageBox.Show("Ошибка" + a);
                }
                finally
                {
                    if (dataReader != null && !dataReader.IsClosed)
                    {
                        dataReader.Close();
                    }
                }
            }
            catch (FormatException a)
            {
                MessageBox.Show("Ошибка!"+a);
            }
            catch (SqlException a)
            {
                MessageBox.Show("Ошибка!"+a);
            }
            catch (OverflowException a)
            {
                MessageBox.Show("Ошибка!"+a);
            }
            
        }
        private void save_buyers_Click(object sender, EventArgs e)
        {
            try
            {
                edit_buyers.Visible = true;
                add_buyers.Visible = true;
                delete_buyers.Visible = true;
                clean_buyers.Visible = true;
                save_buyers.Visible = false;
                int old_id = (int)buyers_new_box.Value;
                int id = (int)buyers_id_box.Value;
                string name = (string)buyers_name_box.Text;
                string phone = (string)buyers_phone_box.Text;
                string adress = (string)buyers_adress_box.Text;
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand edit = new SqlCommand("UPDATE Buyers SET id=@id, name=@name, phone=@phone, adress=@adress WHERE id = @old_id", connection);
                    SqlParameter p1 = new SqlParameter("@id", id);
                    edit.Parameters.Add(p1);
                    SqlParameter p2 = new SqlParameter("@name", name);
                    edit.Parameters.Add(p2);
                    SqlParameter p3 = new SqlParameter("@phone", phone);
                    edit.Parameters.Add(p3);
                    SqlParameter p4 = new SqlParameter("@adress", adress);
                    edit.Parameters.Add(p4);
                    SqlParameter p5 = new SqlParameter("@old_id", old_id);
                    edit.Parameters.Add(p5);
                    edit.ExecuteNonQuery();
                }
                this.buyersTableAdapter2.Fill(this.kA6DataSet2.Buyers);
                this.goodsTableAdapter2.Fill(this.kA6DataSet2.Goods);
                this.tradesTableAdapter2.Fill(this.kA6DataSet2.Trades);
                this.good_listsTableAdapter2.Fill(this.kA6DataSet2.Good_lists);

                SqlDataReader dataReader = null;
                listView_buyers.Items.Clear();
                try
                {
                    using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand("SELECT * FROM Buyers", connection);
                        dataReader = command.ExecuteReader();
                        ListViewItem item = null;
                        while (dataReader.Read())
                        {
                            item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["name"]),
                            Convert.ToString(dataReader["phone"]),
                            Convert.ToString(dataReader["adress"]) });
                            listView_buyers.Items.Add(item);
                        }

                    }

                }
                catch (Exception a)
                {
                    MessageBox.Show("Ошибка" + a);
                }
                finally
                {
                    if (dataReader != null && !dataReader.IsClosed)
                    {
                        dataReader.Close();
                    }
                }
            }
            catch (FormatException a)
            {
                MessageBox.Show("Ошибка!" + a);
            }
            catch (SqlException a)
            {
                MessageBox.Show("Ошибка!" + a);
            }
            catch (OverflowException a)
            {
                MessageBox.Show("Ошибка!" + a);
            }
        }
        private void save_trades_Click(object sender, EventArgs e)
        {
            try
            {
                edit_trades.Visible = true;
                add_trades.Visible = true;
                delete_trades.Visible = true;
                clean_trades.Visible = true;
                save_trades.Visible = false;
                int old_id = (int)trades_new_box.Value;
                int id = (int)trades_id_box.Value;
                int good_list_id = (int)trades_good_list_id_box.Value;
                int buyer_id = (int)trades_buyer_id_box.Value;
                int total_cost = (int)trades_total_cost_box.Value;
                int discount = (int)trades_discount_box.Value;
                DateTime trade_date = (DateTime)trades_trade_date_box.Value;
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand edit = new SqlCommand("UPDATE Trades SET id=@id, good_list_id=@good_list_id, buyer_id=@buyer_id, total_cost=@total_cost, discount=@discount, trade_date=@trade_date WHERE id = @old_id", connection);
                    SqlParameter p1 = new SqlParameter("@id", id);
                    edit.Parameters.Add(p1);
                    SqlParameter p2 = new SqlParameter("@good_list_id", good_list_id);
                    edit.Parameters.Add(p2);
                    SqlParameter p3 = new SqlParameter("@buyer_id", buyer_id);
                    edit.Parameters.Add(p3);
                    SqlParameter p4 = new SqlParameter("@total_cost", total_cost);
                    edit.Parameters.Add(p4);
                    SqlParameter p5 = new SqlParameter("@old_id", old_id);
                    edit.Parameters.Add(p5);
                    SqlParameter p6 = new SqlParameter("@discount", discount);
                    edit.Parameters.Add(p6);
                    SqlParameter p7 = new SqlParameter("@trade_date", trade_date);
                    edit.Parameters.Add(p7);
                    edit.ExecuteNonQuery();
                }
                this.buyersTableAdapter2.Fill(this.kA6DataSet2.Buyers);
                this.goodsTableAdapter2.Fill(this.kA6DataSet2.Goods);
                this.tradesTableAdapter2.Fill(this.kA6DataSet2.Trades);
                this.good_listsTableAdapter2.Fill(this.kA6DataSet2.Good_lists);

                SqlDataReader dataReader = null;
                listView_trades.Items.Clear();
                try
                {
                    using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand("SELECT * FROM Trades", connection);
                        dataReader = command.ExecuteReader();
                        ListViewItem item = null;
                        while (dataReader.Read())
                        {
                            item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["trade_date"]),
                            Convert.ToString(dataReader["good_list_id"]),
                            Convert.ToString(dataReader["buyer_id"]),
                            Convert.ToString(dataReader["total_cost"]),
                            Convert.ToString(dataReader["discount"]) });
                            listView_trades.Items.Add(item);
                        }

                    }

                }
                catch (Exception a)
                {
                    MessageBox.Show("Ошибка" + a);
                }
                finally
                {
                    if (dataReader != null && !dataReader.IsClosed)
                    {
                        dataReader.Close();
                    }
                }
            }
            catch (FormatException a)
            {
                MessageBox.Show("Ошибка!" + a);
            }
            catch (SqlException a)
            {
                MessageBox.Show("Ошибка!" + a);
            }
            catch (OverflowException a)
            {
                MessageBox.Show("Ошибка!" + a);
            }
        }
        private void save_goods_Click(object sender, EventArgs e)
        {
            try
            {
                edit_goods.Visible = true;
                add_goods.Visible = true;
                delete_goods.Visible = true;
                clean_goods.Visible = true;
                save_goods.Visible = false;
                int old_id = (int)goods_new_box.Value;
                int id = (int)goods_id_box.Value;
                int wholesale_price = (int)goods_wholesale_price_box.Value;
                int retail_price = (int)goods_retail_price_box.Value;
                string name = (string)goods_name_box.Text;
                string description = (string)goods_description_box.Text;
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand edit = new SqlCommand("UPDATE Goods SET id=@id, wholesale_price=@wholesale_price, retail_price=@retail_price, name=@name, description=@description WHERE id = @old_id", connection);
                    SqlParameter p1 = new SqlParameter("@id", id);
                    edit.Parameters.Add(p1);
                    SqlParameter p2 = new SqlParameter("@wholesale_price", wholesale_price);
                    edit.Parameters.Add(p2);
                    SqlParameter p3 = new SqlParameter("@retail_price", retail_price);
                    edit.Parameters.Add(p3);
                    SqlParameter p4 = new SqlParameter("@name", name);
                    edit.Parameters.Add(p4);
                    SqlParameter p5 = new SqlParameter("@old_id", old_id);
                    edit.Parameters.Add(p5);
                    SqlParameter p6 = new SqlParameter("@description", description);
                    edit.Parameters.Add(p6);
                    edit.ExecuteNonQuery();
                }
                this.buyersTableAdapter2.Fill(this.kA6DataSet2.Buyers);
                this.goodsTableAdapter2.Fill(this.kA6DataSet2.Goods);
                this.tradesTableAdapter2.Fill(this.kA6DataSet2.Trades);
                this.good_listsTableAdapter2.Fill(this.kA6DataSet2.Good_lists);

                SqlDataReader dataReader = null;
                listView_goods.Items.Clear();
                try
                {
                    using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand("SELECT * FROM Goods", connection);
                        dataReader = command.ExecuteReader();
                        ListViewItem item = null;
                        while (dataReader.Read())
                        {
                            item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["name"]),
                            Convert.ToString(dataReader["wholesale_price"]),
                            Convert.ToString(dataReader["retail_price"]),
                            Convert.ToString(dataReader["description"]) });
                            listView_goods.Items.Add(item);
                        }

                    }

                }
                catch (Exception a)
                {
                    MessageBox.Show("Ошибка" + a);
                }
                finally
                {
                    if (dataReader != null && !dataReader.IsClosed)
                    {
                        dataReader.Close();
                    }
                }
            }
            catch (FormatException a)
            {
                MessageBox.Show("Ошибка!" + a);
            }
            catch (SqlException a)
            {
                MessageBox.Show("Ошибка!" + a);
            }
            catch (OverflowException a)
            {
                MessageBox.Show("Ошибка!" + a);
            }
        }



        /////////////////////////////SQL_PANEL//////////////////////////////////
        private void sql_finding_button_Click(object sender, EventArgs e)
        {
            string request = (string)sql_request_box.Text;
            
            try
            {
                string error_string = "DROP";
                string error_string2 = "drop";
                int count_errors = request.IndexOf(error_string);
                int count_errors2 = request.IndexOf(error_string2);
                if (count_errors == -1)
                {
                    if (count_errors2 == -1)
                    {
                        try
                        {
                            using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                            {
                                connection.Open();
                                SqlCommand sql = new SqlCommand(@request, connection);
                                SqlParameter n1 = new SqlParameter("@request", request);
                                sql.Parameters.Add(n1);
                                sql_finding_box.Text = ("" + sql.ExecuteScalar());
                                sql.ExecuteNonQuery();
                            }
                        }
                        catch (FormatException a)
                        {
                            MessageBox.Show("Ошибка!" + a);
                        }
                        catch (SqlException a)
                        {
                            MessageBox.Show("Ошибка!" + a);
                        }
                        catch (OverflowException a)
                        {
                            MessageBox.Show("Ошибка!" + a);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ошибка!");
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка!");
                }
                
            }
            catch (FormatException a)
            {
                MessageBox.Show("Ошибка!"+a);
            }
            catch (SqlException a)
            {
                MessageBox.Show("Ошибка!" + a);
            }
            catch (OverflowException a)
            {
                MessageBox.Show("Ошибка!"+a);
            }

            this.buyersTableAdapter2.Fill(this.kA6DataSet2.Buyers);
            this.goodsTableAdapter2.Fill(this.kA6DataSet2.Goods);
            this.tradesTableAdapter2.Fill(this.kA6DataSet2.Trades);
            this.good_listsTableAdapter2.Fill(this.kA6DataSet2.Good_lists);

            SqlDataReader dataReader = null;
            listView_good_lists.Items.Clear();
            listView_goods.Items.Clear();
            listView_buyers.Items.Clear();
            listView_trades.Items.Clear();
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Good_lists", connection);
                    dataReader = command.ExecuteReader();
                    ListViewItem item = null;
                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["good_id"]),
                            Convert.ToString(dataReader["count"]),
                            Convert.ToString(dataReader["trade_type"]) });
                        listView_good_lists.Items.Add(item);
                    }

                }
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Buyers", connection);
                    dataReader = command.ExecuteReader();
                    ListViewItem item = null;
                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["name"]),
                            Convert.ToString(dataReader["phone"]),
                            Convert.ToString(dataReader["adress"]) });
                        listView_buyers.Items.Add(item);
                    }

                }
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Trades", connection);
                    dataReader = command.ExecuteReader();
                    ListViewItem item = null;
                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["trade_date"]),
                            Convert.ToString(dataReader["good_list_id"]),
                            Convert.ToString(dataReader["buyer_id"]),
                            Convert.ToString(dataReader["total_cost"]),
                            Convert.ToString(dataReader["discount"]) });
                        listView_trades.Items.Add(item);
                    }

                }
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Goods", connection);
                    dataReader = command.ExecuteReader();
                    ListViewItem item = null;
                    while (dataReader.Read())
                    {
                        item = new ListViewItem(new string[] {
                            Convert.ToString(dataReader["id"]),
                            Convert.ToString(dataReader["name"]),
                            Convert.ToString(dataReader["wholesale_price"]),
                            Convert.ToString(dataReader["retail_price"]),
                            Convert.ToString(dataReader["description"]) });
                        listView_goods.Items.Add(item);
                    }

                }

            }
            catch (Exception a)
            {
                MessageBox.Show("Ошибка" + a);
            }
            finally
            {
                if (dataReader != null && !dataReader.IsClosed)
                {
                    dataReader.Close();
                }
            }
        }

        ///////////////////////////Report_panel////////////////////////

        void SaveFile(string a, string b)
        {
            if (a.Count() > 1)
            {
                if (File.Exists(b))
                    File.Create(b).Close();
                File.WriteAllText(b, a);
            }
        }

        private void report_buyers_button_Click(object sender, EventArgs e)
        {
            SqlDataReader dataReader = null;
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Buyers", connection);
                    dataReader = command.ExecuteReader();
                    string print = "Отчёт по базе данных 6KA\n\n";
                    print += "Таблица Покупатели\n\n\n";
                    print += "id    name    phone    adress\n\n";
                    while (dataReader.Read())
                    {
                        print = print + Convert.ToString(dataReader["id"]) + "     " + Convert.ToString(dataReader["name"]) + "     " + Convert.ToString(dataReader["phone"]) + "     " + Convert.ToString(dataReader["adress"]) + "\n";
                    }
                    if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                        return;
                    SaveFile(print, saveFileDialog1.FileName);
                }

            }
            catch (Exception a)
            {
                MessageBox.Show("Error" + a);
            }
            finally
            {
                if (dataReader != null && !dataReader.IsClosed)
                {
                    dataReader.Close();
                }
            }
        }

        private void report_made_buyers_button_Click(object sender, EventArgs e)
        {
            SqlDataReader dataReader = null;
            using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Buyers", connection);
                dataReader = command.ExecuteReader();
                string print = "Отчёт по базе данных 6KA\n\n";
                print += "Таблица Покупатели\n\n\n";
                print += "id    name    phone    adress\n\n";
                while (dataReader.Read())
                {
                    print = print + Convert.ToString(dataReader["id"]) + "     " + Convert.ToString(dataReader["name"]) + "     " + Convert.ToString(dataReader["phone"]) + "     " + Convert.ToString(dataReader["adress"]) + "\n";
                }
                report_buyers_box.Text = print;
            }
        }

        private void report_made_good_lists_button_Click(object sender, EventArgs e)
        {
            SqlDataReader dataReader = null;
            using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Good_lists", connection);
                dataReader = command.ExecuteReader();
                string print = "Отчёт по базе данных 6KA\n\n";
                print += "Таблица Списки товаров\n\n\n";
                print += "id    good_id    count    trade_type\n\n";
                while (dataReader.Read())
                {
                    print = print + Convert.ToString(dataReader["id"]) + "     " + Convert.ToString(dataReader["good_id"]) + "     " + Convert.ToString(dataReader["count"]) + "     " + Convert.ToString(dataReader["trade_type"]) + "\n";
                }
                report_good_lists_box.Text = print;
            }
        }

        private void report_good_lists_button_Click(object sender, EventArgs e)
        {
            SqlDataReader dataReader = null;
            using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Good_lists", connection);
                dataReader = command.ExecuteReader();
                string print = "Отчёт по базе данных 6KA\n\n";
                print += "Таблица Списки товаров\n\n\n";
                print += "id    good_id    count    trade_type\n\n";
                while (dataReader.Read())
                {
                    print = print + Convert.ToString(dataReader["id"]) + "     " + Convert.ToString(dataReader["good_id"]) + "     " + Convert.ToString(dataReader["count"]) + "     " + Convert.ToString(dataReader["trade_type"]) + "\n";
                }
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                SaveFile(print, saveFileDialog1.FileName);
            }
        }

        private void report_made_goods_button_Click(object sender, EventArgs e)
        {
            SqlDataReader dataReader = null;
            using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Goods", connection);
                dataReader = command.ExecuteReader();
                string print = "Отчёт по базе данных 6KA\n\n";
                print += "Таблица Товары\n\n\n";
                print += "id    name    wholesale_price    retail_price    description\n\n";
                while (dataReader.Read())
                {
                    print = print + Convert.ToString(dataReader["id"]) + "     " + Convert.ToString(dataReader["name"]) + "     " + Convert.ToString(dataReader["wholesale_price"]) + "     " + Convert.ToString(dataReader["retail_price"]) + "     " + Convert.ToString(dataReader["description"])  + "\n";
                }
                report_goods_box.Text = print;
            }
        }

        private void report_goods_button_Click(object sender, EventArgs e)
        {
            SqlDataReader dataReader = null;
            using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Goods", connection);
                dataReader = command.ExecuteReader();
                string print = "Отчёт по базе данных 6KA\n\n";
                print += "Таблица Товары\n\n\n";
                print += "id    name    wholesale_price    retail_price    description\n\n";
                while (dataReader.Read())
                {
                    print = print + Convert.ToString(dataReader["id"]) + "     " + Convert.ToString(dataReader["name"]) + "     " + Convert.ToString(dataReader["wholesale_price"]) + "     " + Convert.ToString(dataReader["retail_price"]) + "     " + Convert.ToString(dataReader["description"]) + "\n";
                }
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                SaveFile(print, saveFileDialog1.FileName);
            }
        }

        private void report_made_trades_button_Click(object sender, EventArgs e)
        {
            SqlDataReader dataReader = null;
            using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Trades", connection);
                dataReader = command.ExecuteReader();
                string print = "Отчёт по базе данных 6KA\n\n";
                print += "Таблица Сделки\n\n\n";
                print += "id    trade_date    good_list_id    buyer_id    total_cost    discount\n\n";
                while (dataReader.Read())
                {
                    print = print + Convert.ToString(dataReader["id"]) + "     " + Convert.ToString(dataReader["trade_date"]) + "     " + Convert.ToString(dataReader["good_list_id"]) + "     " + Convert.ToString(dataReader["buyer_id"]) + "     " + Convert.ToString(dataReader["total_cost"]) + "     "  + Convert.ToString(dataReader["discount"])  + "\n";
                }
                report_trades_box.Text = print;
            }
        }

        private void report_trades_button_Click(object sender, EventArgs e)
        {
            SqlDataReader dataReader = null;
            using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KA6.mdf;Integrated Security=True; Connect Timeout=30"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Trades", connection);
                dataReader = command.ExecuteReader();
                string print = "Отчёт по базе данных 6KA\n\n";
                print += "Таблица Сделки\n\n\n";
                print += "id    trade_date    good_list_id    buyer_id    total_cost    discount\n\n";
                while (dataReader.Read())
                {
                    print = print + Convert.ToString(dataReader["id"]) + "     " + Convert.ToString(dataReader["trade_date"]) + "     " + Convert.ToString(dataReader["good_list_id"]) + "     " + Convert.ToString(dataReader["buyer_id"]) + "     " + Convert.ToString(dataReader["total_cost"]) + "     "  + Convert.ToString(dataReader["discount"]) + "\n";
                }
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                SaveFile(print, saveFileDialog1.FileName);
            }
        }

        ////////////////////////FILTER_PANEL////////////////
        private List<string[]> rows_good_lists = new List<string[]>();
        private List<string[]> rows_goods = new List<string[]>();
        private List<string[]> rows_buyers = new List<string[]>();
        private List<string[]> rows_trades = new List<string[]>();

        private List<string[]> new_rows_buyers = null;
        private List<string[]> new_rows_goods = null;
        private List<string[]> new_rows_good_lists = null;
        private List<string[]> new_rows_trades = null;

        private void filterList_buyers(List<string[]> list_buyers)
        {
            listView_buyers.Items.Clear();
            foreach (string[] s in list_buyers)
            {
                listView_buyers.Items.Add(new ListViewItem(s));
            }
        }
        private void filterList_goods(List<string[]> list_goods)
        {
            listView_goods.Items.Clear();
            foreach (string[] s in list_goods)
            {
                listView_goods.Items.Add(new ListViewItem(s));
            }
        }
        private void filterList_good_lists(List<string[]> list_good_lists)
        {
            listView_good_lists.Items.Clear();
            foreach (string[] s in list_good_lists)
            {
                listView_good_lists.Items.Add(new ListViewItem(s));
            }
        }
        private void filterList_trades(List<string[]> list_trades)
        {
            listView_trades.Items.Clear();
            foreach (string[] s in list_trades)
            {
                listView_trades.Items.Add(new ListViewItem(s));
            }
        }


        private void buyers_find_text_box_TextChanged(object sender, EventArgs e)
        {
            if (buyers_filter_about.Text == "id")
            {
                new_rows_buyers = rows_buyers.Where((x) => x[0].ToLower().Contains(buyers_find_text_box.Text.ToLower())).ToList();
                filterList_buyers(new_rows_buyers);
            }
            else if (buyers_filter_about.Text == "name")
            {
                new_rows_buyers = rows_buyers.Where((x) => x[1].ToLower().Contains(buyers_find_text_box.Text.ToLower())).ToList();
                filterList_buyers(new_rows_buyers);
            }
            else if (buyers_filter_about.Text == "adress")
            {
                new_rows_buyers = rows_buyers.Where((x) => x[3].ToLower().Contains(buyers_find_text_box.Text.ToLower())).ToList();
                filterList_buyers(new_rows_buyers);
            }
            else if (buyers_filter_about.Text == "phone")
            {
                new_rows_buyers = rows_buyers.Where((x) => x[2].ToLower().Contains(buyers_find_text_box.Text.ToLower())).ToList();
                filterList_buyers(new_rows_buyers);
            }

        }
        private void trades_find_text_box_TextChanged(object sender, EventArgs e)
        {
            if (trades_filter_about.Text == "id")
            {
                new_rows_trades = rows_trades.Where((x) => x[0].ToLower().Contains(trades_find_text_box.Text.ToLower())).ToList();
                filterList_trades(new_rows_trades);
            }
            else if (trades_filter_about.Text == "trade_date")
            {
                new_rows_trades = rows_trades.Where((x) => x[1].ToLower().Contains(trades_find_text_box.Text.ToLower())).ToList();
                filterList_trades(new_rows_trades);
            }
            else if (trades_filter_about.Text == "good_list_id")
            {
                new_rows_trades = rows_trades.Where((x) => x[2].ToLower().Contains(trades_find_text_box.Text.ToLower())).ToList();
                filterList_trades(new_rows_trades);
            }
            else if (trades_filter_about.Text == "buyer_id")
            {
                new_rows_trades = rows_trades.Where((x) => x[3].ToLower().Contains(trades_find_text_box.Text.ToLower())).ToList();
                filterList_trades(new_rows_trades);
            }
            else if (trades_filter_about.Text == "total_cost")
            {
                new_rows_trades = rows_trades.Where((x) => x[4].ToLower().Contains(trades_find_text_box.Text.ToLower())).ToList();
                filterList_trades(new_rows_trades);
            }
            else if (trades_filter_about.Text == "discount")
            {
                new_rows_trades = rows_trades.Where((x) => x[5].ToLower().Contains(trades_find_text_box.Text.ToLower())).ToList();
                filterList_trades(new_rows_trades);
            }

        }
        private void good_lists_find_text_box_TextChanged(object sender, EventArgs e)
        {
            if (good_lists_filter_about.Text == "id")
            {
                new_rows_good_lists = rows_good_lists.Where((x) => x[0].ToLower().Contains(good_lists_find_text_box.Text.ToLower())).ToList();
                filterList_good_lists(new_rows_good_lists);
            }
            else if (good_lists_filter_about.Text == "good_id")
            {
                new_rows_good_lists = rows_good_lists.Where((x) => x[1].ToLower().Contains(good_lists_find_text_box.Text.ToLower())).ToList();
                filterList_good_lists(new_rows_good_lists);
            }
            else if (good_lists_filter_about.Text == "count")
            {
                new_rows_good_lists = rows_good_lists.Where((x) => x[2].ToLower().Contains(good_lists_find_text_box.Text.ToLower())).ToList();
                filterList_good_lists(new_rows_good_lists);
            }
            else if (good_lists_filter_about.Text == "trade_type")
            {
                new_rows_good_lists = rows_good_lists.Where((x) => x[3].ToLower().Contains(good_lists_find_text_box.Text.ToLower())).ToList();
                filterList_good_lists(new_rows_good_lists);
            }

        }
        private void goods_find_text_box_TextChanged(object sender, EventArgs e)
        {
            if (goods_filter_about.Text == "id")
            {
                new_rows_goods = rows_goods.Where((x) => x[0].ToLower().Contains(goods_find_text_box.Text.ToLower())).ToList();
                filterList_goods(new_rows_goods);
            }
            else if (goods_filter_about.Text == "name")
            {
                new_rows_goods = rows_goods.Where((x) => x[1].ToLower().Contains(goods_find_text_box.Text.ToLower())).ToList();
                filterList_goods(new_rows_goods);
            }
            else if (goods_filter_about.Text == "wholesale_price")
            {
                new_rows_goods = rows_goods.Where((x) => x[2].ToLower().Contains(goods_find_text_box.Text.ToLower())).ToList();
                filterList_goods(new_rows_goods);
            }
            else if (goods_filter_about.Text == "retail_price")
            {
                new_rows_goods = rows_goods.Where((x) => x[3].ToLower().Contains(goods_find_text_box.Text.ToLower())).ToList();
                filterList_goods(new_rows_goods);
            }
            else if (goods_filter_about.Text == "description")
            {
                new_rows_goods = rows_goods.Where((x) => x[4].ToLower().Contains(goods_find_text_box.Text.ToLower())).ToList();
                filterList_goods(new_rows_goods);
            }
        }





        ///////////////////////////////////////////////////

    }
}
