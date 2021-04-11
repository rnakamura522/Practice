using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Model
{
    public class UserDataModel:CommonModel
    {
        // テーブルID
        public int TableID { get; set; }

        // ユーザID
        public String UserID { get; set; }

        // ユーザ名
        public String UserName { get; set; }

        // パスワード
        public String Password { get; set; }
    }
}
