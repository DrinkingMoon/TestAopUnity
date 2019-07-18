using IAopDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AopOracelDAL
{
    public class ReadDataDAL : IReadData
    {
        public string ReadDataStr(string Name)
        {
            return string.Format("把{0}写入Oracel数据库成功", Name);
        }
    }
}
