using DAO;
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

namespace NSFW_ProxyGUI {
    public partial class BlacklistForm : Form {

        private readonly string selectStatement = "SELECT * FROM Blacklist";
        private readonly DBContext dbContext;
        private readonly SqlDataAdapter sqlDa;
        private DataTable dt;
        private readonly SqlCommandBuilder cb;

        public BlacklistForm() {
            InitializeComponent();
            this.dbContext = new DBContext();
            this.sqlDa = new SqlDataAdapter();
            this.dt = new System.Data.DataTable();
            sqlDa.SelectCommand = new SqlCommand(selectStatement, dbContext.connection);
            this.cb = new SqlCommandBuilder(sqlDa);
            sqlDa.Fill(dt);
            dt.Columns[0].ReadOnly = true;
            BlacklistDataTable.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e) {
            sqlDa.UpdateCommand = cb.GetUpdateCommand();
            sqlDa.Update(dt);
        }
    }
}
