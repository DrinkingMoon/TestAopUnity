using Command;
using IAopBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AopUnity
{
    class Program
    {
        static void Main(string[] args)
        {
            IReadDataBLL bllServer = new UnityContainerHelp().GetServer<IReadDataBLL>();
            Console.WriteLine(bllServer.ReadDataStr("踏浪帅"));
        }
    }
}
