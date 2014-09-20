using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BTL_CSDL.admin.dao
{
    public class tenkhac_DAO
    {
        public static DataTable getTenKhac_Macay(int macay)
        {
            String strCon = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {

                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "GET_TENKHAC_MACAY";
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

        public static DataTable getTenKhac_MaTEN(int maten)
        {
            String strCon = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {

                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "GET_TEN_MATEN";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter pMaCay = new SqlParameter("@MA_TEN", SqlDbType.Int);
                pMaCay.Value = maten;
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

        public static Boolean update_tenkhac(int maTen, string ten)
        {
            String strCon = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {

                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "UPDATE_TENKHAC";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                SqlParameter pMaTen = new SqlParameter("@MA_TEN", SqlDbType.Int);
                pMaTen.Value = maTen;
                cmd.Parameters.Add(pMaTen);
                SqlParameter pTen = new SqlParameter("@TEN", SqlDbType.NText);
                pTen.Value = ten;
                cmd.Parameters.Add(pTen);
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

        public static Boolean insert_tenkhac(int macay, string ten)
        {
            String strCon = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {

                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "INSERT_TENKHAC";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                SqlParameter pMaCay = new SqlParameter("@MA_CAY", SqlDbType.Int);
                pMaCay.Value = macay;
                cmd.Parameters.Add(pMaCay);
                SqlParameter pTen = new SqlParameter("@TEN", SqlDbType.NText);
                pTen.Value = ten;
                cmd.Parameters.Add(pTen);
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
        public static Boolean delete_tenkhac(int maten)
        {
            String strCon = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {

                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "DELETE_TENKHAC";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                SqlParameter pMaBT = new SqlParameter("@MA_TEN", SqlDbType.Int);
                pMaBT.Value = maten;
                cmd.Parameters.Add(pMaBT);
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
    }
}