using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNet.SignalR;
using NotificationTest.model;
using System.Web.Services;
using System.Configuration;

namespace NotificationTest
{
    public partial class test : System.Web.UI.Page
    {   //variable declaration
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<Object> getobjects()
        {
            List<Object> objectList = new List<Object>();

            //take note that select cannot include * and tablename needs [dbo] for sqldependency to work
            string sqlCommand = " SELECT abc,abc from[dbo].tablename'";
            SqlConnection con = yourdbConnection;
            SqlCommand cmd = new SqlCommand(sqlCommand, con);
            if (con.State != System.Data.ConnectionState.Open)
            {
                con.Open();
            }
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {  //generic object
                    var single = new
                    {

                        attr1 = rdr["databasecolumnname"].ToString(),
                        attr2 = rdr["databasecolumnname"].ToString(),
                        attr3 = rdr["databasecolumnname"].ToString(),

                    };
                    objectList.Add(single);

                }
            }

            return objectList;
        }//end get customerBalances;

    }
}