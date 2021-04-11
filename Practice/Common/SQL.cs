using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using Practice.Model;

namespace Practice.Common
{
    public class SQL
    {
        /// <summary>
        /// DB接続
        /// </summary>
        /// <returns></returns>
        public Boolean ConnectionOpen(SqlConnection Connection)
        {
            Boolean flg = false;
            try
            {
                Connection.Open();
                flg = true;
            }
            catch (Exception ex)
            {

            }
            return flg;
        }

        /// <summary>
        /// DB切断
        /// </summary>
        /// <returns></returns>
        public Boolean ConnectionClose(SqlConnection Connection)
        {
            Boolean flg = false;

            try
            {
                Connection.Close();
                Connection.Dispose();
                flg = true;
            }
            catch (Exception ex)
            {

            }
            return flg;

        }

        /// <summary>
        /// ログイン認証
        /// </summary>
        /// <returns></returns>
        public UserDataModel Login(String UserId,String Password)
        {
            // 取得内容格納先
            UserDataModel Model = new UserDataModel();

            // Sql実施結果フラグ
            Model.flg = false;

            // Sql接続
            SqlConnection Connection = new SqlConnection(Pramater.ConStr);
            if (ConnectionOpen(Connection))
            {
                // ユーザID,パスワード照合
                try
                {
                    StringBuilder Sql = new StringBuilder();
                    Sql.Append("SELECT");
                    Sql.Append("    UserID");
                    Sql.Append("  , UserName ");
                    Sql.Append("FROM");
                    Sql.Append(" UserData ");
                    Sql.Append("WHERE");
                    Sql.Append(" UserID =   @UserID");
                    Sql.Append(" AND Password = @Password");

                    // Sqlコマンド作成
                    SqlCommand Command = new SqlCommand(Sql.ToString(), Connection);

                    // パラメータ設定
                    Command.Parameters.AddWithValue("@UserID" ,UserId);
                    Command.Parameters.AddWithValue("@Password",Password);

                    // Sql実行
                    SqlDataReader Reader = Command.ExecuteReader();

                    // 取得内容を格納
                    while (Reader.Read())
                    {
                        Model.UserID = Reader.GetString(0);
                        Model.UserName = Reader.GetString(1);
                    }
                    Model.flg = true;
                }
                catch (Exception ex)
                {

                }
            }

            // Sql切断
            if (ConnectionClose(Connection))
            {
                // 値を返す
                return Model;
            }
            return Model;
        }
    }
}
