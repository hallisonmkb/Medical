using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Configuration;

namespace BO
{
    public sealed class Connection
    {
        public static string ConnectionString
        {
            get 
            {
                return @"Data Source=HALLISON-PC;Initial Catalog=Medical;User ID=sa;Pwd=Sql2k5server"; 
            }
        }
    }
}
