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
    public class ProductRepository
    {
        private SqlConnection con;
        //To Handle connection related activities    
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);

        }
        //To Add Product details    
        public bool AddProduct(Product obj)
        {

            connection();
            SqlCommand com = new SqlCommand("AddProduct", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@pname", obj.ProductName);
            com.Parameters.AddWithValue("@bname", obj.BrandName);
            com.Parameters.AddWithValue("@price", obj.Price);

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
        //To view Product details with generic list     
        public List<Product> AllProduct()
        {
            connection();
            List<Product> products = new List<Product>();


            SqlCommand com = new SqlCommand("AllProduct", con);
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

                    new Product
                    {

                        ProductID = Convert.ToInt32(dr["ProductID"]),
                        ProductName = Convert.ToString(dr["ProductName"]),
                        BrandName = Convert.ToString(dr["BrandName"]),
                        Price = Convert.ToString(dr["Price"])

                    }
                    );
            }

            return products;
        }

        //To Update Seller details    
        public bool UpdateProduct(Product obj)
        {

            connection();
            SqlCommand com = new SqlCommand("UpdateProduct", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@pid", obj.ProductID);
            com.Parameters.AddWithValue("@pname", obj.ProductName);
            com.Parameters.AddWithValue("@bname", obj.BrandName);
            com.Parameters.AddWithValue("@price", obj.Price);
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
        //To delete Product details    
        public bool DeleteProduct(int ProductID)
        {

            connection();
            SqlCommand com = new SqlCommand("DeleteProduct", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@pid",ProductID );

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