using Lab1_ASPMetConnectedMode.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Lab1_ASPMetConnectedMode.GUI
{
    public partial class WebFormTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConnectDB_Click(object sender, EventArgs e)
        {
            SqlConnection connDB = UtilityDB.ConnectDB();
            MessageBox.Show(Convert.ToString(connDB.State), "Database Connection");
        }
    }
}