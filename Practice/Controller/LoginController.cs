using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Practice.Model;
using System.Data;
using Dapper;

namespace Practice.Controller
{
    public class LoginController
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
        public Boolean Login(String UserId, String Password)
        {
            // 取得内容格納先
            UserDataModel Model = new UserDataModel();

            // Sql実施結果フラグ
            Boolean flg = false;

            // Sql接続
            SqlConnection Connection = new SqlConnection(Constant.ConStr);
            if (ConnectionOpen(Connection))
            {
                // ユーザID,パスワード照合
                try
                {
                    // Sqlコマンド作成
                    StringBuilder Sql = new StringBuilder();
                    Sql.Append("SELECT");
                    Sql.Append("    UserID");
                    Sql.Append("  , UserName ");
                    Sql.Append("FROM");
                    Sql.Append(" UserData ");
                    Sql.Append("WHERE");
                    Sql.Append(" UserID =   @UserID");
                    Sql.Append(" AND Password = @Password");

                    // パラメータ設定,Sql実行
                    IEnumerable<UserDataModel> Result = Connection.Query<UserDataModel>(Sql.ToString(),new { @UserID = UserId , @Password = Password });

                    if (Result.Count() == 1) 
                    {
                        // 取得内容を格納
                        foreach (var Data in Result)
                        {
                            Model.UserID = Data.UserID;
                            Model.UserName = Data.UserName;
                        }
                        flg = true;
                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    // sql切断
                    if (ConnectionClose(Connection))
                    {
                        if (flg) 
                        {
                            // メニュー画面へ遷移
                            Menu menu = new Menu();
                            menu.Model = Model;
                            menu.ShowDialog();
                        }
                    }
                }
            }
            return flg;
        }
    }
}
