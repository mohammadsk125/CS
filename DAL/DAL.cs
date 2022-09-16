
using DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL
    {
        SqlConnection sqlConObj;
     
        SqlCommand sqlCmdObj;
        SqlDataReader sqlDataReaderObj;

        public DAL()
        {
            sqlConObj = new SqlConnection();
            sqlCmdObj = new SqlCommand();
        }

        public int Insert(DTO.CourierShipment cs)
        {
            
            
            try
            {
                sqlConObj.ConnectionString = ConfigurationManager.ConnectionStrings["CourierShipment"].ConnectionString;
                string query = $"insert into courier(SenderName,senderphonenumber,fromaddress,trackingid,receivername,receiverphonenumber,toaddress,deliverydate) values('{cs.sendername}','{cs.senderphonenumber}','{cs.fromaddress}','{cs.trackingid}','{cs.ReceiverName}','{cs.Receivephonenumber}','{cs.ToAddress}','{cs.DeliveryDate}')";
                SqlCommand cmd = new SqlCommand(query, sqlConObj);
                sqlConObj.Open();
                int insertedRows = cmd.ExecuteNonQuery();
                sqlConObj.Close();
                if (insertedRows >= 1)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }

            }

            catch (Exception e) { throw e; }
        }
        public int Delete(DTO.CourierShipment cs)
        {
            try
            {
                sqlConObj.ConnectionString = ConfigurationManager.ConnectionStrings["CourierShipment"].ConnectionString;
                string query = $"DELETE FROM cart WHERE TrackingID='{cs.trackingid}'";
                SqlCommand cmd = new SqlCommand(query, sqlConObj);
                sqlConObj.Open();
                int DeleteRows = cmd.ExecuteNonQuery();
                sqlConObj.Close();
                if (DeleteRows >= 1)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }

            }

            catch (Exception e) { throw e; }
        }

        public int Update(DTO.CourierShipment cs)
        {
            try
            {
                sqlConObj.ConnectionString = ConfigurationManager.ConnectionStrings["CourierShipment"].ConnectionString;
                string query = $"Update  courier set SenderName='{cs.sendername}' ,senderphonenumber='{cs.senderphonenumber}',fromaddress='{cs.fromaddress}',trackingid='{cs.trackingid}',receivername='{cs.ReceiverName}',receiverphonenumber='{cs.Receivephonenumber}',toaddress='{cs.ToAddress}',deliverydate='{cs.DeliveryDate}' WHERE TrackingID='{cs.trackingid}'";
                SqlCommand cmd = new SqlCommand(query, sqlConObj);
                sqlConObj.Open();
                int DeleteRows = cmd.ExecuteNonQuery();
                sqlConObj.Close();
                if (DeleteRows >= 1)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }

            }

            catch (Exception e) { throw e; }
        }

        public List<CourierShipment> ListAll()
        {

            try
            {
                sqlConObj.ConnectionString = ConfigurationManager.ConnectionStrings["CourierShipment"].ConnectionString;
                sqlCmdObj.CommandText = @"SELECT SenderName,senderphonenumber,fromaddress,trackingid,receivername,receiverphonenumber,toaddress,deliverydate FROM  courier";
                sqlCmdObj.Connection = sqlConObj;
                sqlConObj.Open();
                sqlDataReaderObj = sqlCmdObj.ExecuteReader();
                List<CourierShipment> lstPro = new List<CourierShipment>();
                CourierShipment newepartObj = new CourierShipment();
                while (sqlDataReaderObj.Read())
                {
                    lstPro.Add(new CourierShipment()
                    {
                      sendername  = sqlDataReaderObj[0].ToString(),
                       senderphonenumber= (int)sqlDataReaderObj[1],
                        fromaddress = sqlDataReaderObj[2].ToString(),
                        trackingid = sqlDataReaderObj[3].ToString(),
                        ReceiverName = sqlDataReaderObj[4].ToString(),
                        Receivephonenumber = (int)sqlDataReaderObj[5],
                        ToAddress = sqlDataReaderObj[6].ToString(),
                        DeliveryDate= (DateTime)sqlDataReaderObj[7],
                        
                       
                    });

                }
                return lstPro;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                sqlConObj.Close();
            }

        }
    }
}
