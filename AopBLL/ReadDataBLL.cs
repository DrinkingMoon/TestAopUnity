using Command;
using IAopBLL;
using IAopDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AopBLL
{
    public class ReadDataBLL:IReadDataBLL
    {
        IReadData bllServer = new UnityContainerHelp().GetServer<IReadData>();
        public string ReadDataStr(string Name)
        {
            return bllServer.ReadDataStr(Name);
        }
    }
}
