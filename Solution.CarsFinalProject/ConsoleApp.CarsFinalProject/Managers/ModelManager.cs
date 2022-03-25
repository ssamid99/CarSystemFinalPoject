using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.CarsFinalProject.Managers
{
    internal class ModelManager
    {
        Models[] data = new Models[0];

        public void Add(Models entity)
        {
            int len = data.Length;
            Array.Resize(ref data, len + 1);
            data[len] = entity;
        }
        public bool CheckModelName(string name)
        {
            name = name.ToLower();
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] != null)
                {
                    if (data[i].ModelName.ToLower().Trim() == name.Trim())
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public void EditName(int value)
        {
            for(int i = 0; i < data.Length; i++)
            {
                if(data[i].ModelId == value)
                {
                    Console.WriteLine("Model adini dəyişin...! ");
                    againedit1:
                    string newName = ScanerManager.ReadString("Ad daxil edin...");
                    CheckModelName(newName);
                    if(CheckModelName(newName) == false)
                    {
                        ScanerManager.PrintError("Bu ad artıq istifadə olunub");
                        goto againedit1;
                    }
                    else
                    {
                        data[i].ModelName = data[i].ModelName.Replace(data[i].ModelName, newName);
                        break;
                    }
                    
                }
            }
        }
        public void EditModelBrand(int value, int value2)
        {
            for(int i = 0; i < data.Length; i++)
            {
                if(data[i].ModelId == value)
                {
                    Console.WriteLine("Modelin Markasini dəyişin");
                    
                    data[i].ModelId = value2;
                    break;
                }
            }
        }
        public void SingleModel(int value)
        {
          string singleModel = "";
          for (int i = 0; i < data.Length; i++)
          {
              if (data[i].ModelId == value)
              {
                  singleModel = $"Model Nº: {data[i].ModelId} | Model Adi: {data[i].ModelName}";
                  break;
              }
          }
          Console.WriteLine(singleModel);  
        }
        public void RemoveModel(Models entity)
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
        public Models[] GetAll()
        {
            return data;
        }
    }
}
