using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.CarsFinalProject
{
    internal class Models
    {
        static int counter = 0;
        public Models()
        {
            ModelId = ++counter;
        }
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public int BrId { get; set; }
        public override string ToString()
        {
            return $"Model Nº: {ModelId} | Model Adı: {ModelName} | Marka Nº: {BrId}";
        }
    }
}
