using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.Common;
using Practice.Model;

namespace Practice.Controller
{
    public class LoginController
    {
        /// <summary>
        /// ログインチェック
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public UserDataModel CheckLogin(String UserId,String Password)
        {
            // ログイン照合
            SQL Sql = new SQL();
            UserDataModel Model = new UserDataModel();

            // 取得した値を返す
            return Model = (Sql.Login(UserId, Password));
        }
    }
}
