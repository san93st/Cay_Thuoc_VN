using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BTL_CSDL.admin.dao
{
    public class baithuoc_DAO
    {
        public static DataTable getBaiThuoc_MaCay(int macay)
        {
            String strCon = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {

                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "GET_BAITHUOC_MACAY";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter pMaCay = new SqlParameter("@MACAY", SqlDbType.Int);
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

        public static DataTable getBaiThuoc_MaBT(int mabt)
        {
            String strCon = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {

                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "GET_BAITHUOC_MABAITHUOC";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter pMaCay = new SqlParameter("@MA_BAI_THUOC", SqlDbType.Int);
                pMaCay.Value = mabt;
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

        
        public static Boolean update_baithuoc(int mabaithuoc,string nd)
        {
            String strCon = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {

                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "UPDATE_BAITHUOC";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                SqlParameter pMaBT = new SqlParameter("@MA_BAI_THUOC", SqlDbType.Int);
                pMaBT.Value = mabaithuoc;
                cmd.Parameters.Add(pMaBT);
                SqlParameter pND = new SqlParameter("@NOI_DUNG", SqlDbType.NText);
                pND.Value = nd;
                cmd.Parameters.Add(pND);
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

        public static Boolean insert_baithuoc(int macay, string nd)
        {
            String strCon = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {

                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "INSERT_BAITHUOC";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                SqlParameter pMaCay = new SqlParameter("@MA_CAY", SqlDbType.Int);
                pMaCay.Value = macay;
                cmd.Parameters.Add(pMaCay);
                SqlParameter pND = new SqlParameter("@NOI_DUNG", SqlDbType.NText);
                pND.Value = nd;
                cmd.Parameters.Add(pND);
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
        public static Boolean delete_baithuoc(int mabt)
        {
            String strCon = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            try
            {

                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "DELETE_BAITHUOC";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                SqlParameter pMaBT = new SqlParameter("@MA_BAI_THUOC", SqlDbType.Int);
                pMaBT.Value = mabt;
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