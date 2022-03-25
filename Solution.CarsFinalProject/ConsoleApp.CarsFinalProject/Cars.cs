using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.CarsFinalProject
{
    internal class Cars
    {
        static int counter = 0;
        public Cars()
        {
            CarId = ++ counter;
        }
        public int CarId { get; set; }
        public int ModId { get; set; }
        public DateTime Year { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }
        public double Engine { get; set; }
        public string FuelTypes { get; set; }
        public override string ToString()
        {
            return $"Model Nº: {ModId} " +
                $"Avtomobil Nº: {CarId} " +
                $"Buraxiliş Ili: {Year: yyyy} " +
                $"Qiyməti: {Price}₼ " +
                $"Mühərrik həcmi: {Engine} " +
                $"Yanacaq növü: {FuelTypes} ";
        }
    }
    enum FuelTypes : byte
    {
        Benzin = 1,
        Gas,
        Diesel,
        Hybrid,
        Electric
    }
}
