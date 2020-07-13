using GuildCars.Data.Interface;
using GuildCars.Model.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.ADO
{
    public class PurchaseRepositoryADO : IPurchaseRepository
    {
        public void CreatePurchase(Purchases purchase)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CreatePurchase", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@name", purchase.Name);
                cmd.Parameters.AddWithValue("@email", purchase.Email);
                cmd.Parameters.AddWithValue("@streetOne", purchase.StreetOne);
                cmd.Parameters.AddWithValue("@streetTwo", purchase.StreetTwo);
                cmd.Parameters.AddWithValue("@city", purchase.City);
                cmd.Parameters.AddWithValue("@zipCode", purchase.ZipCode);
                cmd.Parameters.AddWithValue("@phone", purchase.Phone);
                cmd.Parameters.AddWithValue("@purchasePrice", purchase.PurchasePrice);
                cmd.Parameters.AddWithValue("@purchaseType", purchase.PurchaseType);
                cmd.Parameters.AddWithValue("@purchaseDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@salePrice", purchase.SalePrice);
                cmd.Parameters.AddWithValue("@vehicleId", purchase.VehicleId);
                cmd.Parameters.AddWithValue("@employeeId", purchase.EmployeeId);
                
                cn.Open();

                cmd.ExecuteNonQuery();

                cn.Close();
            }
        }

        public void DeletePurchase(Purchases purchase)
        {
            // I don't think a delete is needed
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DeletePurchase", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@purchaseIdId", purchase.PurchaseId);

                cn.Open();

                cmd.ExecuteNonQuery();

                cn.Close();
            }
        }

        public List<Purchases> ReadAllPurchases()
        {
            List<Purchases> Purchase = new List<Purchases>();
            
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ReadAllPurchase", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Purchases currentPurchase = new Purchases();
                        currentPurchase.PurchaseId = (int)dr["PurchaseId"];
                        currentPurchase.Name = dr["Name"].ToString();
                        currentPurchase.Email = dr["Email"].ToString();
                        currentPurchase.StreetOne = dr["StreetOne"].ToString();
                        currentPurchase.StreetTwo = dr["StreetTwo"].ToString();
                        currentPurchase.City = dr["City"].ToString();
                        currentPurchase.ZipCode = dr["ZipCode"].ToString();
                        currentPurchase.Phone = dr["Phone"].ToString();
                        currentPurchase.PurchasePrice = (decimal)dr["PurchasePrice"];
                        currentPurchase.PurchaseType = dr["PurchaseType"].ToString();
                        currentPurchase.PurchaseDate = (DateTime)dr["PurchaseDate"];
                        currentPurchase.SalePrice = (decimal)dr["SalePrice"];
                        currentPurchase.VehicleId = (int)dr["VehicleId"];
                        currentPurchase.EmployeeId = (int)dr["EmployeeId"];


                        Purchase.Add(currentPurchase);
                    }
                }
                cn.Close();
            }
            return Purchase;
        }

        public Purchases ReadByPurchaseId(int purchaseId)
        {
            Purchases Purchase = new Purchases();
            
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ReadByPurchaseId", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@purchaseId", purchaseId);
                
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Purchases currentPurchase = new Purchases();
                        currentPurchase.PurchaseId = (int)dr["PurchaseId"];
                        currentPurchase.Name = dr["Name"].ToString();
                        currentPurchase.Email = dr["Email"].ToString();
                        currentPurchase.StreetOne = dr["StreetOne"].ToString();
                        currentPurchase.StreetTwo = dr["StreetTwo"].ToString();
                        currentPurchase.City = dr["City"].ToString();
                        currentPurchase.ZipCode = dr["ZipCode"].ToString();
                        currentPurchase.Phone = dr["Phone"].ToString();
                        currentPurchase.PurchasePrice = (decimal)dr["PurchasePrice"];
                        currentPurchase.PurchaseType = dr["PurchaseType"].ToString();
                        currentPurchase.PurchaseDate = (DateTime)dr["PurchaseDate"];
                        currentPurchase.SalePrice = (decimal)dr["SalePrice"];
                        currentPurchase.VehicleId = (int)dr["VehicleId"];
                        currentPurchase.EmployeeId = (int)dr["EmployeeId"];

                        Purchase = currentPurchase;
                    }
                }
                cn.Close();
            }
            return Purchase;
        }

        public void UpdatePurchase(Purchases purchase)
        {
            //I don't think this is needed
            // what feilds should be editable?
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("UpdatePurchase", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@purchaseId", purchase.PurchaseId);
                cmd.Parameters.AddWithValue("@name", purchase.Name);
                cmd.Parameters.AddWithValue("@email", purchase.Email);
                cmd.Parameters.AddWithValue("@streetOne", purchase.StreetOne);
                cmd.Parameters.AddWithValue("@streetTwo", purchase.StreetTwo);
                cmd.Parameters.AddWithValue("@city", purchase.City);
                cmd.Parameters.AddWithValue("@zipCode", purchase.ZipCode);
                cmd.Parameters.AddWithValue("@phone", purchase.Phone);
                cmd.Parameters.AddWithValue("@purchasePrice", purchase.PurchasePrice);
                cmd.Parameters.AddWithValue("@purchaseType", purchase.PurchaseType);
                cmd.Parameters.AddWithValue("@purchaseDate", purchase.PurchaseDate);
                cmd.Parameters.AddWithValue("@salePrice", purchase.SalePrice);
                cmd.Parameters.AddWithValue("@vehicleId", purchase.VehicleId);
                cmd.Parameters.AddWithValue("@employeeId", purchase.EmployeeId);

                cn.Open();

                cmd.ExecuteNonQuery();

                cn.Close();
            }
        }
    }
}
