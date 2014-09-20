using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BTL_CSDL.admin.dao
{
    public class anh_caythuoc
    {
        public static DataTable getAnh_macay(int macay)
        {
            String strCon = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {

                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "GET_ANH_MACAY";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter pMaCay = new SqlParameter("@MA_CAY", SqlDbType.Int);
                pMaCay.Value = macay;
                cmd.Parameters.Add(pMaCay);
                cmd.Connection = con;

                da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (con != null)
                    con.Close();
            }
            return null;
        }

        public static Boolean insert_anh(int macay, String tenAnh,String url)
        {
            String strCon = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {

                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "INSERT_ANH";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                SqlParameter pMaCay = new SqlParameter("@MA_CAY", SqlDbType.Int);
                pMaCay.Value = macay;
                cmd.Parameters.Add(pMaCay);
                SqlParameter pTenAnh = new SqlParameter("@TEN_ANH", SqlDbType.NVarChar,50);
                pTenAnh.Value = tenAnh;
                cmd.Parameters.Add(pTenAnh);
                SqlParameter pUrl = new SqlParameter("@URL", SqlDbType.NVarChar,100);
                pUrl.Value = url;
                cmd.Parameters.Add(pUrl);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (con != null)
                    con.Close();
            }
            return false;
        }

        public static Boolean update_anh(int ma_anh,String tenAnh, String url)
        {
            String strCon = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {

                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "UPDATE_ANH";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                SqlParameter pmaAnh = new SqlParameter("@MA_ANH", SqlDbType.Int);
                pmaAnh.Value = ma_anh;
                cmd.Parameters.Add(pmaAnh);
                SqlParameter pTenAnh = new SqlParameter("@TEN_ANH", SqlDbType.NVarChar, 50);
                pTenAnh.Value = tenAnh;
                cmd.Parameters.Add(pTenAnh);
                SqlParameter pUrl = new SqlParameter("@URL", SqlDbType.NVarChar, 100);
                pUrl.Value = url;
                cmd.Parameters.Add(pUrl);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (con != null)
                    con.Close();
            }
            return false;
        }

        public static Boolean delete_anh(int maanh)
        {
            String strCon = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {

                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "DELETE_ANH";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                SqlParameter pMaAnh = new SqlParameter("@MA_ANH", SqlDbType.Int);
                pMaAnh.Value = maanh;
                cmd.Parameters.Add(pMaAnh);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (con != null)
                    con.Close();
            }
            return false;
        }

        public static DataTable getanh_maanh(int maten)
        {
            String strCon = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {

                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "GET_ANH_MAANH";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter pMaAnh = new SqlParameter("@MA_ANH", SqlDbType.Int);
                pMaAnh.Value = maten;
                cmd.Parameters.Add(pMaAnh);
                cmd.Connection = con;

                da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (con != null)
                    con.Close();
            }
            return null;
        }

        public static DataTable getAllAnh()
        {
            String strCon = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {

                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "GET_ALL_ANH";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (con != null)
                    con.Close();
            }
            return null;
        }
    }
}