using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.CarsFinalProject
{
    public class Brands
    {
        static int counter = 0;
        public Brands()
        {
            BrandId = ++ counter;
        }
        public int BrandId { get; private set; }
        public string BrandName { get; set; }

        public override string ToString()
        {
            return $"Marka Nº: {BrandId} | Marka adı: {BrandName}";
        }

        
    }
}
