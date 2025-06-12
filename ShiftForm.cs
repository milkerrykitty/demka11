using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace template
{
    public partial class ShiftForm : Form
    {
        private string connectionString = "server=localhost;database=zoo;uid=root;pwd=root;";
        public ShiftForm()
        {
            InitializeComponent();
            LoadEmployees();
            LoadShifts();
            InitializeStatusComboBox();
        }
        private void LoadEmployees()
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT userid, fullname FROM users WHERE status = 'Работает'", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cmbEmployee.Items.Add(new { Id = reader.GetInt32("userid"), Name = reader.GetString("fullname") });
                }
            }
            cmbEmployee.DisplayMember = "Name";
            cmbEmployee.ValueMember = "Id";
        }

        private void LoadShifts(string filterDate = "")
        {
            var dt = new DataTable();
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT s.shiftid, u.userid AS employee_id, u.fullname AS employee, 
                                s.date, s.start_time, s.end_time, s.status 
                         FROM shifts s
                         JOIN users u ON s.employee_id = u.userid";

                if (!string.IsNullOrEmpty(filterDate))
                {
                    query += $" WHERE s.date = '{filterDate}'";
                }

                var adapter = new MySqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }

            dataGridView.DataSource = dt;
        }

        private void InitializeStatusComboBox()
        {
            cmbStatus.Items.AddRange(new object[] { "Запланирована", "Выполнена" });
            cmbStatus.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbEmployee.SelectedItem == null)
            {
                MessageBox.Show("Выберите сотрудника");
                return;
            }

            var emp = cmbEmployee.SelectedItem;
            int employeeId = (int)emp.GetType().GetProperty("Id").GetValue(emp);
            string date = dtpDate.Value.ToString("yyyy-MM-dd");
            string start = txtStart.Text;
            string end = txtEnd.Text;
            string status = cmbStatus.SelectedItem?.ToString() ?? "Запланирована";

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new MySqlCommand(
                    "INSERT INTO shifts (employee_id, date, start_time, end_time, status) VALUES (@id, @date, @start, @end, @status)",
                    conn);
                cmd.Parameters.AddWithValue("@id", employeeId);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@start", start);
                cmd.Parameters.AddWithValue("@end", end);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.ExecuteNonQuery();
            }

            LoadShifts(dtpFilter.Value.ToString("yyyy-MM-dd"));
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите смену для редактирования");
                return;
            }

            int shiftId = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["shiftid"].Value);
            var emp = cmbEmployee.SelectedItem;
            int employeeId = (int)emp.GetType().GetProperty("Id").GetValue(emp);
            string date = dtpDate.Value.ToString("yyyy-MM-dd");
            string start = txtStart.Text;
            string end = txtEnd.Text;
            string status = cmbStatus.SelectedItem?.ToString() ?? "Запланирована";

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new MySqlCommand(
                    "UPDATE shifts SET employee_id = @id, date = @date, start_time = @start, end_time = @end, status = @status WHERE shiftid = @shiftid",
                    conn);
                cmd.Parameters.AddWithValue("@id", employeeId);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@start", start);
                cmd.Parameters.AddWithValue("@end", end);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@shiftid", shiftId);
                cmd.ExecuteNonQuery();
            }

            LoadShifts(dtpFilter.Value.ToString("yyyy-MM-dd"));
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0) return;
            int shiftId = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["shiftid"].Value);

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new MySqlCommand("DELETE FROM shifts WHERE shiftid = @id", conn);
                cmd.Parameters.AddWithValue("@id", shiftId);
                cmd.ExecuteNonQuery();
            }

            LoadShifts(dtpFilter.Value.ToString("yyyy-MM-dd"));
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadShifts(dtpFilter.Value.ToString("yyyy-MM-dd"));
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView.SelectedRows[0];
                int employeeId = Convert.ToInt32(row.Cells["employee_id"]?.Value ?? -1);
                var selectedEmp = cmbEmployee.Items.Cast<dynamic>().FirstOrDefault(x => x.Id == employeeId);
                if (selectedEmp != null)
                {
                    cmbEmployee.SelectedItem = selectedEmp;
                }

                dtpDate.Value = Convert.ToDateTime(row.Cells["date"].Value);
                txtStart.Text = row.Cells["start_time"].Value.ToString();
                txtEnd.Text = row.Cells["end_time"].Value.ToString();
                cmbStatus.SelectedItem = row.Cells["status"].Value?.ToString() ?? "Запланирована";
            }
        }
    }
}
