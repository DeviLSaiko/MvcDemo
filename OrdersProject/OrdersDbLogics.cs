using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersProject
{
    public class OrdersDbLogics
    {
        string Conn = @"Data Source=.; Initial Catalog=GarmentsPro; Integrated Security=SSPI";

        public IEnumerable<Orders> ordersList
        {
            get
            {

                List<Orders> listOrders = new List<Orders>();

                SqlConnection SqlCon = new SqlConnection(Conn);

                SqlCommand MyCmd = new SqlCommand("Select * from Orders", SqlCon);

                if (SqlCon.State == ConnectionState.Closed)
                {
                    SqlCon.Open();
                }
                SqlDataReader SqR = MyCmd.ExecuteReader();

                while (SqR.Read())

                {
                    Orders OrdersObj = new Orders();
                    OrdersObj.OID = Convert.ToInt32(SqR["OID"]);
                    OrdersObj.OrderID = SqR["OrderID"].ToString();
                    OrdersObj.ClientName = SqR["ClientName"].ToString();
                    OrdersObj.OrderType = SqR["OrderType"].ToString();
                    OrdersObj.Qty = Convert.ToInt32(SqR["Qty"]);
                    OrdersObj.Status = Convert.ToInt32(SqR["Status"]);
                    OrdersObj.ETA_Time = Convert.ToDateTime(SqR["ETA_Time"]);
                    OrdersObj.Created_Date = Convert.ToDateTime(SqR["Created_Date"]);

                    listOrders.Add(OrdersObj);
                }

                return listOrders;
            }
        }

        public void CreateOrder(Orders orders)
        {

            SqlConnection SqlCon = new SqlConnection(Conn);

            SqlCommand MyCmd = new SqlCommand("InsertOrder", SqlCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyCmd.Parameters.AddWithValue("@ClientName", orders.ClientName);
            MyCmd.Parameters.AddWithValue("@OrderType ", orders.OrderType);
            MyCmd.Parameters.AddWithValue("@Qty", orders.Qty);
            MyCmd.Parameters.AddWithValue("@ETA_Time", orders.ETA_Time);
            MyCmd.Parameters.AddWithValue("@Status", orders.Status);
            SqlCon.Open();
            MyCmd.ExecuteNonQuery();
        }

        public void UpdateOrder (Orders orders)
        {
            SqlConnection Mycon = new SqlConnection(Conn);
            SqlCommand MyCmd = new SqlCommand("UpdateOrder", Mycon );
            MyCmd.CommandType = CommandType.StoredProcedure;
            MyCmd.Parameters.AddWithValue("@OID",orders.OID);
            MyCmd.Parameters.AddWithValue("@ClientName", orders.ClientName);
            MyCmd.Parameters.AddWithValue("@OrderType ", orders.OrderType);
            MyCmd.Parameters.AddWithValue("@Qty", orders.Qty);
            MyCmd.Parameters.AddWithValue("@ETA_Time", orders.ETA_Time);
            MyCmd.Parameters.AddWithValue("@Status", orders.Status);
            MyCmd.Parameters.AddWithValue("@CD", orders.Created_Date);
            Mycon.Open();
            MyCmd.ExecuteNonQuery();


        }
        public void DeleteOrder(int id)
        {
            SqlConnection Mycon = new SqlConnection(Conn);
            SqlCommand MyCmd = new SqlCommand("Delete from Orders where OID=@ID", Mycon);
             
            MyCmd.Parameters.AddWithValue("@ID", id);
            
            Mycon.Open();
            MyCmd.ExecuteNonQuery();
        }

    }
}
