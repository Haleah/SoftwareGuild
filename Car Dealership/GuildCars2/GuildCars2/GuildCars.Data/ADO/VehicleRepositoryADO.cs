using GuildCars.Data.Interface;
using GuildCars.Model.Queries;
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
    public class VehicleRepositoryADO : IVehicleRepository
    {
        public void CreateVehicle(Vehicles vehicle)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CreateVehicle", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Vin", vehicle.Vin);
                cmd.Parameters.AddWithValue("@year", vehicle.Year);
                cmd.Parameters.AddWithValue("@bodyStyle", vehicle.BodyStyle);
                cmd.Parameters.AddWithValue("@transmission", vehicle.Transmission);
                cmd.Parameters.AddWithValue("@type", vehicle.Type);
                cmd.Parameters.AddWithValue("@mileage", vehicle.Mileage);
                cmd.Parameters.AddWithValue("@color", vehicle.Color);
                cmd.Parameters.AddWithValue("@interior", vehicle.Interior);
                cmd.Parameters.AddWithValue("@description", vehicle.Description);
                cmd.Parameters.AddWithValue("@msrp", vehicle.Msrp);
                cmd.Parameters.AddWithValue("@salePrice", vehicle.SalePrice);
                cmd.Parameters.AddWithValue("@modelId", vehicle.ModelId);

                cn.Open();

                cmd.ExecuteNonQuery();

                cn.Close();
            }
        }

        public void DeleteVehicle(Vehicles vehicle)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DeleteVehicle", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@vehicleId", vehicle.VehicleId);

                cn.Open();

                cmd.ExecuteNonQuery();

                cn.Close();
            }
        }

        public List<Vehicles> ReadAllVehicle()
        {
            List<Vehicles> Vehicle = new List<Vehicles>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ReadAllVehicle", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicles currentVehicle = new Vehicles();
                        currentVehicle.VehicleId = (int)dr["VehicleId"];
                        currentVehicle.Vin = dr["Vin"].ToString();
                        currentVehicle.Year = dr["Year"].ToString();
                        currentVehicle.BodyStyle = dr["BodyStyle"].ToString();
                        currentVehicle.Transmission = dr["Transmission"].ToString();
                        currentVehicle.Type = dr["Type"].ToString() == "new";
                        currentVehicle.Mileage = (int)dr["Mileage"];
                        currentVehicle.Color = dr["Color"].ToString();
                        currentVehicle.Interior = dr["Interior"].ToString();
                        currentVehicle.Description = dr["Description"].ToString();
                        currentVehicle.Msrp = (decimal)dr["Msrp"];
                        currentVehicle.SalePrice = (decimal)dr["SalePrice"];
                        currentVehicle.MakeId = (int)dr["MakeId"];
                        currentVehicle.ModelId = (int)dr["ModelId"];
                        currentVehicle.Make = dr["Make"].ToString();
                        currentVehicle.Model = dr["Model"].ToString();


                        Vehicle.Add(currentVehicle);
                    }
                }
                cn.Close();
            }
            return Vehicle;
        }

        public Vehicles ReadByVehicleId(int vehicleId)
        {
            Vehicles Vehicle = new Vehicles();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ReadByVehicleId", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleId", vehicleId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicles currentVehicle = new Vehicles();
                        currentVehicle.VehicleId = (int)dr["VehicleId"];
                        currentVehicle.Vin = dr["Vin"].ToString();
                        currentVehicle.Year = dr["Year"].ToString();
                        currentVehicle.BodyStyle = dr["BodyStyle"].ToString();
                        currentVehicle.Transmission = dr["Transmission"].ToString();
                        currentVehicle.Type = dr["Type"].ToString()=="new";
                        currentVehicle.Mileage = (int)dr["Mileage"];
                        currentVehicle.Color = dr["Color"].ToString();
                        currentVehicle.Interior = dr["Interior"].ToString();
                        currentVehicle.Description = dr["Description"].ToString();
                        currentVehicle.Msrp = (decimal)dr["Msrp"];
                        currentVehicle.SalePrice = (decimal)dr["SalePrice"];
                        currentVehicle.MakeId = (int)dr["MakeId"];
                        currentVehicle.ModelId = (int)dr["ModelId"];
                        currentVehicle.Make =  dr["Make"].ToString();
                        currentVehicle.Model = dr["Model"].ToString();

                        Vehicle = currentVehicle;
                    }
                }
                cn.Close();
            }
            return Vehicle;
        }

        public void UpdateVehicle(Vehicles vehicle)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("UpdateVehicle", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@vehicleId", vehicle.VehicleId);
                cmd.Parameters.AddWithValue("@Vin", vehicle.Vin);
                cmd.Parameters.AddWithValue("@year", vehicle.Year);
                cmd.Parameters.AddWithValue("@bodyStyle", vehicle.BodyStyle);
                cmd.Parameters.AddWithValue("@transmission", vehicle.Transmission);
                cmd.Parameters.AddWithValue("@type", vehicle.Type);
                cmd.Parameters.AddWithValue("@mileage", vehicle.Mileage);
                cmd.Parameters.AddWithValue("@color", vehicle.Color);
                cmd.Parameters.AddWithValue("@interior", vehicle.Interior);
                cmd.Parameters.AddWithValue("@description", vehicle.Description);
                cmd.Parameters.AddWithValue("@msrp", vehicle.Msrp);
                cmd.Parameters.AddWithValue("@salePrice", vehicle.SalePrice);
                cmd.Parameters.AddWithValue("@modelId", vehicle.ModelId);

                cn.Open();

                cmd.ExecuteNonQuery();

                cn.Close();
            }
        }

        /// <summary>
        /// Search database for vehicles
        /// </summary>
        /// <param name="form">
        /// isNew = true - new
        /// isNew = false - used
        /// isNew = null - all
        /// </param>
        /// <param name="isNew"></param>
        /// <returns></returns>
        public List<Vehicles> Search(VehicleSearchCM form, bool? isNew = null)
        {

            List<Vehicles> result = new List<Vehicles>();

            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {
                var sql = @"	SELECT        Vehicle.vehicleId, Vehicle.vin, Vehicle.year, Vehicle.bodyStyle, Vehicle.transmission, Vehicle.type, Vehicle.mileage, Vehicle.color, Vehicle.interior, Vehicle.description, Vehicle.msrp, Vehicle.salePrice, Make.makeId, 
                         Model.modelId, Make.make, Model.model
                        FROM            Vehicle INNER JOIN
                         
                         Model ON Vehicle.modelId = Model.modelId INNER JOIN
						 Make ON Model.makeId = Make.makeId 
                            WHERE 1 = 1";
               
                switch (isNew)
                {
                    case null:
                        break;
                    case true:
                        sql += " AND type = 'new'";
                        break;
                    case false:
                        sql += " AND type = 'used'";
                        break;
                }
                SqlCommand cmd = new SqlCommand(sql, conn);
                if (!string.IsNullOrEmpty(form.Input))
                {
                    sql += " AND ( year LIKE @input";
                    sql += " OR model LIKE @input";
                    sql += " OR make LIKE @input )";
                    cmd.Parameters.AddWithValue("@input", form.Input);

                }
                if (form.YearMin.HasValue)
                {
                    sql += " AND year >= @yearMin";
                    cmd.Parameters.AddWithValue("@yearMin", form.YearMin);
                }
                if (form.YearMax.HasValue)
                {
                    sql += " AND year <= @yearMax";
                    cmd.Parameters.AddWithValue("@yearMax", form.YearMax);
                }
                if (form.PriceMin.HasValue)
                {
                    sql += " AND salePrice >= @priceMin";
                    cmd.Parameters.AddWithValue("@priceMin", form.PriceMin);
                }
                if (form.PriceMax.HasValue)
                {
                    sql += " AND salePrice <= @priceMax";
                    cmd.Parameters.AddWithValue("@priceMax", form.PriceMax);
                }
                cmd.CommandText = sql;

                conn.Open();
            
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        Vehicles currentVehicle = new Vehicles();

                        currentVehicle.VehicleId = (int)dr["VehicleId"];
                        currentVehicle.Vin = dr["Vin"].ToString();
                        currentVehicle.Year = dr["Year"].ToString();
                        currentVehicle.BodyStyle = dr["BodyStyle"].ToString();
                        currentVehicle.Transmission = dr["Transmission"].ToString();
                        currentVehicle.Mileage = (int)dr["Mileage"];
                        currentVehicle.Color = dr["Color"].ToString();
                        currentVehicle.Interior = dr["Interior"].ToString();
                        currentVehicle.Msrp = (decimal)dr["Msrp"];
                        currentVehicle.SalePrice = (decimal)dr["SalePrice"];
                        currentVehicle.MakeId = (int)dr["MakeId"];
                        currentVehicle.ModelId = (int)dr["ModelId"];

                        result.Add(currentVehicle);
                    }
                }
                conn.Close();
            }
            return result;

        }
    }
}
