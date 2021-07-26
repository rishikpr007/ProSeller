using ProSeller.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProSeller.Repository
{
    public class SellerRepository
    {

        private SqlConnection con;
        //To Handle connection related activities    
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);

        }
        //To Add Seller details    
        public bool AddSeller(Seller obj)
        {

            connection();
            SqlCommand com = new SqlCommand("AddSeller", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@sname", obj.SellerName);
            com.Parameters.AddWithValue("@oname", obj.OwnerName);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }


        }
        //To view Seller details with generic list     
        public List<Seller> AllSeller()
        {
            connection();
            List<Seller> products = new List<Seller>();


            SqlCommand com = new SqlCommand("AllSeller", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind EmpModel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {

                products.Add(

                    new Seller
                    {

                        SellerID = Convert.ToInt32(dr["SellerID"]),
                        SellerName = Convert.ToString(dr["SellerName"]),
                        OwnerName = Convert.ToString(dr["OwnerName"]),

                    }
                    );
            }

            return products;
        }
         
        //To Update Seller details    
        public bool UpdateSeller(Seller obj)
        {

            connection();
            SqlCommand com = new SqlCommand("UpdateSeller", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@sid", obj.SellerID);
            com.Parameters.AddWithValue("@sname", obj.SellerName);
            com.Parameters.AddWithValue("@oname", obj.OwnerName);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;
            }
            else
            {
                return false;
            }
        }
        //To delete Seller details    
        public bool DeleteSeller(int SellerID)
        {

            connection();
            SqlCommand com = new SqlCommand("DeleteSeller", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@sid", SellerID);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {

                return false;
            }


        }
    }
}