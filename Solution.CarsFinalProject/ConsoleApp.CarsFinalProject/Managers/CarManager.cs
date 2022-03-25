using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.CarsFinalProject.Managers
{
    internal class CarManager
    {
        Cars[] data = new Cars[0];

        public void Add(Cars entity)
        {
            int len = data.Length;
            Array.Resize(ref data, len + 1);
            data[len] = entity;
        }
        public void EditCarModel(int value)
        {
            for(int i = 0; i < data.Length; i++)
            {
                if (data[i].CarId == value)
                {
                    Console.WriteLine("Avtomobil Modelini dəyişin...!");
                    int newId = ScanerManager.ReadInteger("Model daxil edin");
                    data[i].CarId = newId;
                    break;
                }
            }
        }
        public void EditYear(int value)
        {
            for(int i = 0; i < data.Length; i++)
            {
                if(data[i].CarId == value)
                {
                    Console.WriteLine("Buraxiliş ilini dəyişin...!");
                    DateTime newData = ScanerManager.ReadDate("Il daxil edil..! ");
                    data[i].Year = newData;
                }
            }
        }
        public void EditPrice(int value)
        {
            for(int i = 0; i < data.Length; i++)
            {
                if(data[i].CarId == value)
                {
                    Console.WriteLine("Qiyməti dəyişin...!");
                    double newPrice = ScanerManager.ReadDouble("Qiymət daxil edin..!");
                    data[i].Price=newPrice;
                    break;
                }
            }
        }
        public void EditColor(int value)
        {
            for(int i = 0; i < data.Length; i++)
            {
                if(data[i].CarId == value)
                {
                    Console.WriteLine("Rəngi dəyişin...!");
                    string newColor = ScanerManager.ReadString("Rəng daxil edin..! ");
                    data[i].Color = data[i].Color.Replace(data[i].Color, newColor);
                    break;
                }
            }
        }
        public void EditEngine(int value)
        {
            for(int i = 0; i < data.Length; i++)
            {
                if(data[i].CarId == value)
                {
                    Console.WriteLine("Mühərrik həcmini dəyişin...!");
                    double newEngine = ScanerManager.ReadDouble("Mühərrik həcmi daxil edin..! ");
                    data[i].Engine = newEngine;
                    break;
                }
            }
        }
        public void EditFuel(int value)
        {
            for (int i = 0; i < data.Length; i++)
            {
                FuelTypes numFuel = ScanerManager.ReadFuel("Yanacaq növünü seçin...!");

                if (data[i].CarId == value)
                {
                    switch (numFuel)
                    {
                        case FuelTypes.Benzin:
                            data[i].FuelTypes = nameof(FuelTypes.Benzin);
                            break;
                        case FuelTypes.Gas:
                            data[i].FuelTypes = nameof(FuelTypes.Gas);
                            break;
                        case FuelTypes.Diesel:
                            data[i].FuelTypes = nameof(FuelTypes.Diesel);
                            break;
                        case FuelTypes.Hybrid:
                            data[i].FuelTypes = nameof(FuelTypes.Hybrid);
                            break;
                        case FuelTypes.Electric:
                            data[i].FuelTypes = nameof(FuelTypes.Electric);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        public void SingleCar(int value)
        {
            string singleCar = "";
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].CarId == value)
                {
                    singleCar = $"Avtomobil Nº: {data[i].CarId} | Avtomobil Ili: {data[i].Year} | Avtomobil Qiyməti: {data[i].Price}₼ | " +
                        $"Avtomobil Rəngi: {data[i].Color} | Avtomobil Mühərrik həcmi: {data[i].Engine} | Avtomobil Yanacaq növü: {data[i].FuelTypes}";
                    break;
                }
            }
            Console.WriteLine(singleCar);
        }
        public void RemoveCar(Cars entity)
        {
            int index = Array.IndexOf(data, entity);
            if(index == -1)
            {
                return;
            }
            for(int i = index; i < data.Length - 1; i++)
            {
                data[i] = data[i + 1];
            }
            if(data.Length > 0)
            {
                Array.Resize(ref data, data.Length - 1);
            }
        }
        public Cars[] GetAll()
        {
            return data;
        }
    }
}
