using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionsString = "Data Source=SRV2\\PUPILS;Initial Catalog=214804460_Shop;Integrated Security=True";
            ProductsDataAccess cda = new ProductsDataAccess();
            cda.ReadData(connectionsString);
        }
    }
}
