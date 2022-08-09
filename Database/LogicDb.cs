using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database1
{
    public class LogicDb
    {
        string Conn = @"Data Source=.; Initial Catalog=GarmentsPro; Integrated Security=SSPI";

        public IEnumerable<Db> db
        {
            get
            {

                List<Db> db = new List<Db>();

                SqlConnection SqlCon = new SqlConnection(Conn);
               
                SqlCommand MyCmd = new SqlCommand("Select * from Admin",SqlCon);
               
                if (SqlCon.State == ConnectionState.Closed )
                {
                    SqlCon.Open();
                }
                SqlDataReader SqR = MyCmd.ExecuteReader ();

                while(SqR.Read())

                {
                    Db Admin = new Db();
                    Admin.ID = Convert.ToInt32(SqR["ID"]);
                    Admin.UserName =  SqR["UserName"].ToString();
                    Admin.Password = SqR["Password"].ToString();

                    db.Add(Admin);
                }
                 
                return db;
            }
        }

        public void AdminInsert (Db Admin)
        {
            SqlConnection SqlCon = new SqlConnection(Conn);
            SqlCommand MyCmd = new SqlCommand("insert into Admin(UserName , Password) values(@User , @Pass)", SqlCon);

            MyCmd.Parameters.AddWithValue("@User" , Admin.UserName);
            MyCmd.Parameters.AddWithValue("@Pass",Admin.Password );
            SqlCon.Open();
            MyCmd.ExecuteNonQuery();
        }
    }
}
