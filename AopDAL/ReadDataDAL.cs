using IAopDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AopDAL
{
    public class ReadDataDAL : IReadData
    {
        public string ReadDataStr(string Name)
        {
            return string.Format("把{0}写入MSSQL数据库成功", Name);
        }
    }
}
