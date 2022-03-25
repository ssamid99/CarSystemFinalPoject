using ConsoleApp.CarsFinalProject.Infracture;
using ConsoleApp.CarsFinalProject.Managers;
using System;
using System.Linq;
using System.Text;

namespace ConsoleApp.CarsFinalProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            Console.Title = "CarSystem v1.1";

            var brandMgr = new BrandManager();
            var modelMgr = new ModelManager();
            var carMgr = new CarManager();

         readMenu:
             PrintMenu();
            
            Menu carsys = ScanerManager.ReadMenu("Menyudan seçin: ");


            switch (carsys)
            {
                #region BrandAdd
                case Menu.BrandAdd:
                    Console.Clear();
                checkagain:
                    string nameBr = ScanerManager.ReadString("Marka Adini Daxil Edin: ");
                    brandMgr.CheckBrandName(nameBr);
                    if(brandMgr.CheckBrandName(nameBr) == false)
                    {
                        ScanerManager.PrintError("Bu ad artıq istifadə olunub. Yenidən yoxlamaq üçün sıxın <Boşluq> | Menyuya qayitmaq üçün sixin <ESC>");
                        ConsoleKeyInfo click = Console.ReadKey();
                        if(click.Key == ConsoleKey.Spacebar)
                        {
                            goto checkagain;    
                        }
                        else if(click.Key == ConsoleKey.Escape)
                        {
                            goto readMenu;
                        }
                    }
                    else
                    {
                        Brands b = new Brands();
                        b.BrandName = nameBr;
                       brandMgr.Add(b);
                    }
                    
                    goto case Menu.BrandAll;
                #endregion
                #region BrandEdit
                case Menu.BrandEdit:
                    tryEdit:
                    Console.Clear();
                    ShowAllBrands(brandMgr);
                    Console.WriteLine("-------------------------------------------------");
                    Console.WriteLine("Siz Marka adini dəyişirsiniz...");
                    int value = ScanerManager.ReadInteger("Secilmiş Markanin Nº daxil edin: ");
                    var checkBrandEdit = brandMgr.GetAll().FirstOrDefault(x => x.BrandId == value);
                    if (checkBrandEdit == null)
                    {
                        ScanerManager.PrintError("Yanlish Nº!");
                    d1:
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("Yenidən yoxlamaq üçün sıxın <Boşluq> | Menyuya qayitmaq üçün sixin <ESC>");
                        Console.ResetColor();

                        ConsoleKeyInfo d1 = Console.ReadKey();
                        if (d1.Key == ConsoleKey.Spacebar)
                        {
                            goto tryEdit; 
                        }
                        else if (d1.Key == ConsoleKey.Escape)
                        {
                            goto readMenu;
                        }
                        else
                        {
                            goto d1;
                        }
                    }
                    brandMgr.EditName(value);
                    goto case Menu.BrandAll;
                #endregion
                #region BrandRemove
                case Menu.BrandRemove:
                    Console.Clear();
                    ShowAllBrands(brandMgr);
                    Console.WriteLine("----------------------------------------------------------");
                    int value7 = ScanerManager.ReadInteger("Silmək isdədiyiniz Markanin Nº daxil edin: ");
                    Brands b1 = brandMgr.GetAll().FirstOrDefault(item => item.BrandId == value7);
                    brandMgr.RemoveBrand(b1);
                    goto case Menu.BrandAll;
                #endregion
                #region BrandSingle
                case Menu.BrandSingle:
                    trySingle:
                    Console.Clear();
                    ShowAllBrands(brandMgr);
                    Console.WriteLine("----------------------------------------------------------");
                    int value6 = ScanerManager.ReadInteger("Secilmish Markanin Nº daxil edin: ");
                    var checkBrandSingle = brandMgr.GetAll().FirstOrDefault(x => x.BrandId == value6);
                    if (checkBrandSingle == null)
                    {
                        ScanerManager.PrintError("Yanlish Nº!");
                    d2:
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("Yenidən yoxlamaq üçün sıxın <Boşluq> | Menyuya qayitmaq üçün sixin <ESC>");
                        Console.ResetColor();

                        ConsoleKeyInfo d1 = Console.ReadKey();
                        if (d1.Key == ConsoleKey.Spacebar)
                        {
                            goto trySingle;
                        }
                        else if (d1.Key == ConsoleKey.Escape)
                        {
                            goto readMenu;
                        }
                        else
                        {
                            goto d2;
                        }
                    }
                    Console.Clear();
                    brandMgr.SingleBrand(value6);
                    goto readMenu;
                #endregion
                #region BrandAll
                case Menu.BrandAll:
                    Console.Clear();
                    ShowAllBrands(brandMgr);
                    goto readMenu;
                #endregion
                #region ModelAdd
                case Menu.ModelAdd:
                    Console.Clear();
                    Models m = new Models();
                checkagain2:
                    string nameMod = ScanerManager.ReadString("Model Adini Daxil Edin: ");
                    modelMgr.CheckModelName(nameMod);
                    if (modelMgr.CheckModelName(nameMod) == false)
                    {
                        ScanerManager.PrintError("Bu ad artıq istifadə olunub. Yenidən yoxlamaq üçün sıxın <Boşluq> | Menyuya qayitmaq üçün sixin <ESC>");
                        ConsoleKeyInfo click = Console.ReadKey();
                        if (click.Key == ConsoleKey.Spacebar)
                        {
                            goto checkagain2;
                        }
                        else if (click.Key == ConsoleKey.Escape)
                        {
                            goto readMenu;
                        }
                    }
                    else
                    {
                        m.ModelName = nameMod;
                    addmod:
                        ShowAllBrands(brandMgr);
                        Console.WriteLine("---------------------------------------");
                        m.BrId = ScanerManager.ReadInteger("Marka Nº daxil edin: ");
                        var checkBrandId = brandMgr.GetAll().FirstOrDefault(x => x.BrandId == m.BrId);
                        if (checkBrandId == null)
                        {
                            ScanerManager.PrintError("Yanlish Nº!");
                        d3:
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("Yenidən yoxlamaq üçün sıxın <Boşluq> | Menyuya qayitmaq üçün sixin <ESC>");
                            Console.ResetColor();

                            ConsoleKeyInfo d1 = Console.ReadKey();
                            if (d1.Key == ConsoleKey.Spacebar)
                            {
                                goto addmod;
                            }
                            else if (d1.Key == ConsoleKey.Escape)
                            {
                                goto readMenu;
                            }
                            else
                            {
                                goto d3;
                            }
                        }
                        modelMgr.Add(m);
                    }
                    goto case Menu.ModelAll;
                #endregion
                #region ModelEdit
                case Menu.ModelEdit:
                    editmod:
                    Console.Clear();
                    ShowAllModels(modelMgr);
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine(" Model adini deyishmek ucun => 1 | Model id deyishmek ucun => 2");
                    bool success = int.TryParse(Console.ReadLine(), out int menuNumber);
                    if (success && menuNumber == 1)
                    {
                        int value2 = ScanerManager.ReadInteger("Secilmish Modelin Nº daxil edin: ");
                        var checkModelEdit = modelMgr.GetAll().FirstOrDefault(x => x.ModelId == value2);
                        if (checkModelEdit == null)
                        {
                            ScanerManager.PrintError("Yanlish Nº!");
                        d4:
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("Yenidən yoxlamaq üçün sıxın <Boşluq> | Menyuya qayitmaq üçün sixin <ESC>");
                            Console.ResetColor();

                            ConsoleKeyInfo d1 = Console.ReadKey();
                            if (d1.Key == ConsoleKey.Spacebar)
                            {
                                goto editmod;
                            }
                            else if (d1.Key == ConsoleKey.Escape)
                            {
                                goto readMenu;
                            }
                            else
                            {
                                goto d4;
                            }
                        }
                        modelMgr.EditName(value2);
                      
                    }
                    if (success && menuNumber == 2)
                    {
                        int value2 = ScanerManager.ReadInteger("Secilmish Modelin Nº daxil edin: ");
                        var checkModelEdit = modelMgr.GetAll().FirstOrDefault(x => x.ModelId == value2);
                        if (checkModelEdit == null)
                        {
                            ScanerManager.PrintError("Yanlish Nº!");
                        d5:
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("Yenidən yoxlamaq üçün sıxın <Boşluq> | Menyuya qayitmaq üçün sixin <ESC>");
                            Console.ResetColor();

                            ConsoleKeyInfo d1 = Console.ReadKey();
                            if (d1.Key == ConsoleKey.Spacebar)
                            {
                                goto editmod;
                            }
                            else if (d1.Key == ConsoleKey.Escape)
                            {
                                goto readMenu;
                            }
                            else
                            {
                                goto d5;
                            }
                        }
                        ShowAllBrands(brandMgr);
                        Console.WriteLine("-------------------------------------------------");
                        int newBrand = ScanerManager.ReadInteger("Yeni Marka Daxil Edin..");
                        var checBrandEdit = brandMgr.GetAll().FirstOrDefault(x => x.BrandId == newBrand);
                        if (checBrandEdit == null)
                        {
                            ScanerManager.PrintError("Yanlish Nº!");
                        d5:
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("Yenidən yoxlamaq üçün sıxın <Boşluq> | Menyuya qayitmaq üçün sixin <ESC>");
                            Console.ResetColor();

                            ConsoleKeyInfo d1 = Console.ReadKey();
                            if (d1.Key == ConsoleKey.Spacebar)
                            {
                                goto editmod;
                            }
                            else if (d1.Key == ConsoleKey.Escape)
                            {
                                goto readMenu;
                            }
                            else
                            {
                                goto d5;
                            }
                        }
                        modelMgr.EditModelBrand(value2, newBrand);
                    }
                    goto case Menu.ModelAll;
                #endregion
                #region ModelRemove
                case Menu.ModelRemove:
                    Console.Clear();
                    ShowAllModels(modelMgr);
                    int value8 = ScanerManager.ReadInteger("Silmək isdədiyiniz Modelin Nº daxil edin: ");
                    Models m1 = modelMgr.GetAll().FirstOrDefault(item => item.ModelId == value8);
                    modelMgr.RemoveModel(m1);
                    goto case Menu.ModelAll;
                #endregion
                #region ModelSingle
                case Menu.ModelSingle:
                    singlemod:
                    Console.Clear();
                    ShowAllModels(modelMgr);
                    Console.WriteLine("-------------------------------------------------");
                    int value5 = ScanerManager.ReadInteger("Secilmish Modelin Nº daxil edin: ");
                    var checkModelSingle = modelMgr.GetAll().FirstOrDefault(x => x.ModelId == value5);
                    if (checkModelSingle == null)
                    {
                        ScanerManager.PrintError("Yanlish Nº!");

                    clickerSingle:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Yenidən yoxlamaq üçün sıxın <Boşluq> | Menyuya qayitmaq üçün sixin <ESC>");
                        Console.ResetColor();

                        ConsoleKeyInfo click = Console.ReadKey();
                        if (click.Key == ConsoleKey.Spacebar)
                        {
                            goto singlemod;
                        }
                        else if (click.Key == ConsoleKey.Escape)
                        {
                            goto readMenu;
                        }
                        else
                        {
                            goto clickerSingle;
                        }
                    }
                    Console.Clear();
                    modelMgr.SingleModel(value5);
                    goto readMenu;
                #endregion
                #region ModelAll
                case Menu.ModelAll:
                    Console.Clear();
                    ShowAllModels(modelMgr);
                    goto readMenu;
                #endregion
                #region CarAdd
                case Menu.CarAdd:
                    Console.Clear();
                    Cars c = new Cars();
                    c.Year = ScanerManager.ReadDate("Avtomobil İlini Daxil Edin:");
                    c.Price = ScanerManager.ReadDouble("Avtomobil Qiymətini Daxil Edin:");
                    c.Color = ScanerManager.ReadString("Avtomobil Rəngili Daxil Edin:");
                    c.Engine = ScanerManager.ReadDouble("Avtomobil Mühərrikini Daxil Edin:");
                    f1:
                    PrintFuelMenu();
                    FuelTypes numFuel = ScanerManager.ReadFuel("Yanacaq növünü seçin...!");
                    
                    switch (numFuel)
                    {
                        case FuelTypes.Benzin:
                            c.FuelTypes = nameof(FuelTypes.Benzin);
                            break;
                        case FuelTypes.Gas:
                            c.FuelTypes = nameof(FuelTypes.Gas);
                            break;
                        case FuelTypes.Diesel:
                            c.FuelTypes = nameof(FuelTypes.Diesel);
                            break;
                        case FuelTypes.Hybrid:
                            c.FuelTypes = nameof(FuelTypes.Hybrid);
                            break;
                        case FuelTypes.Electric:
                            c.FuelTypes = nameof(FuelTypes.Electric);
                            break;
                        default:
                            Console.Clear();
                            ScanerManager.PrintError("Seçim yanlışdır. Yenidən cəhd edin!");
                            goto f1;
                    }
                tryAdd:
                    ShowAllModels(modelMgr);
                    Console.WriteLine("-----------------------------------------------");
                    c.ModId = ScanerManager.ReadInteger("Model Nº daxil edin: ");
                    var checkModelId = modelMgr.GetAll().FirstOrDefault(x => x.ModelId == c.ModId);
                    if (checkModelId == null)
                    {
                        ScanerManager.PrintError("Seçim yanlışdır. Yenidən cəhd edin!");

                    clickAdd:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Yenidən yoxlamaq üçün sıxın <Boşluq> | Menyuya qayitmaq üçün sixin <ESC>");
                        Console.ResetColor();

                        ConsoleKeyInfo click = Console.ReadKey();
                        if (click.Key == ConsoleKey.Spacebar)
                        {
                            goto tryAdd;
                        }
                        else if (click.Key == ConsoleKey.Escape)
                        {
                            goto readMenu;
                        }
                        else
                        {
                            goto clickAdd;
                        }
                    }
                    carMgr.Add(c);
                    goto case Menu.CarAll;
                #endregion
                #region CarEdit
                case Menu.CarEdit:
                    trycaredit:
                    Console.Clear();
                    ShowAllCars(carMgr);
                    Console.WriteLine("-------------------------------------------------");
                    Console.WriteLine("Avtomobil Nº deyishmek ucun => 1 | Ilini deyishmek ucun => 2 | Qiyməti dəyişmək ucun => 3 | " +
                        "Rəngini dəyişmək üçün => 4 | Mühərrik həcmini dəyişmək üçün => 5 | Yanacaq növünü dəyişmək üçün => 6");
                    bool s1 = int.TryParse(Console.ReadLine(), out int menuNums);
                    if (s1 && menuNums == 1)
                    {
                        int value3 = ScanerManager.ReadInteger("Secilmish Avtomobilin Nº daxil edin: ");
                        ShowAllModels(modelMgr);
                        var checkCarEdit = carMgr.GetAll().FirstOrDefault(x => x.CarId == value3);
                        if (checkCarEdit == null)
                        {
                            ScanerManager.PrintError("Seçim yanlışdır. Yenidən cəhd edin!");

                        clickedit1:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Yenidən yoxlamaq üçün sıxın <Boşluq> | Menyuya qayitmaq üçün sixin <ESC>");
                            Console.ResetColor();

                            ConsoleKeyInfo click = Console.ReadKey();
                            if (click.Key == ConsoleKey.Spacebar)
                            {
                                goto trycaredit;
                            }
                            else if (click.Key == ConsoleKey.Escape)
                            {
                                goto readMenu;
                            }
                            else
                            {
                                goto clickedit1;
                            }
                        }
                        carMgr.EditCarModel(value3);
                    }
                    if (s1 && menuNums == 2)
                    {
                        int value3 = ScanerManager.ReadInteger("Secilmish Avtomobilin Nº daxil edin: ");
                        var checkCarEdit = carMgr.GetAll().FirstOrDefault(x => x.CarId == value3);
                        if (checkCarEdit == null)
                        {
                            ScanerManager.PrintError("Seçim yanlışdır. Yenidən cəhd edin!");

                        clickedit2:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Yenidən yoxlamaq üçün sıxın <Boşluq> | Menyuya qayitmaq üçün sixin <ESC>");
                            Console.ResetColor();

                            ConsoleKeyInfo click = Console.ReadKey();
                            if (click.Key == ConsoleKey.Spacebar)
                            {
                                goto trycaredit;
                            }
                            else if (click.Key == ConsoleKey.Escape)
                            {
                                goto readMenu;
                            }
                            else
                            {
                                goto clickedit2;
                            }
                        }
                        carMgr.EditYear(value3);
                    }
                    if (s1 && menuNums == 3)
                    {
                        int value3 = ScanerManager.ReadInteger("Secilmish Avtomobilin Nº daxil edin: ");
                        var checkCarEdit = carMgr.GetAll().FirstOrDefault(x => x.CarId == value3);
                        if (checkCarEdit == null)
                        {
                            ScanerManager.PrintError("Seçim yanlışdır. Yenidən cəhd edin!");

                        clickedit3:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Yenidən yoxlamaq üçün sıxın <Boşluq> | Menyuya qayitmaq üçün sixin <ESC>");
                            Console.ResetColor();

                            ConsoleKeyInfo click = Console.ReadKey();
                            if (click.Key == ConsoleKey.Spacebar)
                            {
                                goto trycaredit;
                            }
                            else if (click.Key == ConsoleKey.Escape)
                            {
                                goto readMenu;
                            }
                            else
                            {
                                goto clickedit3;
                            }
                        }
                        carMgr.EditPrice(value3);
                    }
                    if (s1 && menuNums == 4)
                    {
                        int value3 = ScanerManager.ReadInteger("Secilmish Avtomobilin Nº daxil edin: ");
                        var checkCarEdit = carMgr.GetAll().FirstOrDefault(x => x.CarId == value3);
                        if (checkCarEdit == null)
                        {
                            ScanerManager.PrintError("Seçim yanlışdır. Yenidən cəhd edin!");

                        clickedit4:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Yenidən yoxlamaq üçün sıxın <Boşluq> | Menyuya qayitmaq üçün sixin <ESC>");
                            Console.ResetColor();

                            ConsoleKeyInfo click = Console.ReadKey();
                            if (click.Key == ConsoleKey.Spacebar)
                            {
                                goto trycaredit;
                            }
                            else if (click.Key == ConsoleKey.Escape)
                            {
                                goto readMenu;
                            }
                            else
                            {
                                goto clickedit4;
                            }
                        }
                        carMgr.EditColor(value3);
                    }
                    if (s1 && menuNums == 5)
                    {
                        int value3 = ScanerManager.ReadInteger("Secilmish Avtomobilin Nº daxil edin: ");
                        var checkCarEdit = carMgr.GetAll().FirstOrDefault(x => x.CarId == value3);
                        if (checkCarEdit == null)
                        {
                            ScanerManager.PrintError("Seçim yanlışdır. Yenidən cəhd edin!");

                        clickedit5:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Yenidən yoxlamaq üçün sıxın <Boşluq> | Menyuya qayitmaq üçün sixin <ESC>");
                            Console.ResetColor();

                            ConsoleKeyInfo click = Console.ReadKey();
                            if (click.Key == ConsoleKey.Spacebar)
                            {
                                goto trycaredit;
                            }
                            else if (click.Key == ConsoleKey.Escape)
                            {
                                goto readMenu;
                            }
                            else
                            {
                                goto clickedit5;
                            }
                        }
                        carMgr.EditEngine(value3);
                    }
                    if(s1 && menuNums == 6)
                    {
                        
                        int value3 = ScanerManager.ReadInteger("Secilmish Avtomobilin Nº daxil edin: ");
                      
                        var checkCarEdit = carMgr.GetAll().FirstOrDefault(x => x.CarId == value3);
                        if (checkCarEdit == null)
                        {
                            ScanerManager.PrintError("Seçim yanlışdır. Yenidən cəhd edin!");

                        clickedit6:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Yenidən yoxlamaq üçün sıxın <Boşluq> | Menyuya qayitmaq üçün sixin <ESC>");
                            Console.ResetColor();

                            ConsoleKeyInfo click = Console.ReadKey();
                            if (click.Key == ConsoleKey.Spacebar)
                            {
                                goto trycaredit;
                            }
                            else if (click.Key == ConsoleKey.Escape)
                            {
                                goto readMenu;
                            }
                            else
                            {
                                goto clickedit6;
                            }
                        }
                        Console.Clear();
                        PrintFuelMenu();
                        carMgr.EditFuel(value3);
                    }
                    goto case Menu.CarAll;
                #endregion
                #region CarRemove
                case Menu.CarRemove:
                    Console.Clear();
                    ShowAllCars(carMgr);
                    int value9 = ScanerManager.ReadInteger("Secilmish Avtomobilin Nº daxil edin: ");
                    Cars c1 = carMgr.GetAll().FirstOrDefault(item => item.CarId == value9);
                    carMgr.RemoveCar(c1);
                    goto case Menu.CarAll;
                #endregion
                #region CarSingle
                case Menu.CarSingle:
                    carsingle:
                    Console.Clear();
                    ShowAllCars(carMgr);
                    Console.WriteLine("----------------------------------------------------");
                    int value4 = ScanerManager.ReadInteger("Secilmish Avtomobilin Nº daxil edin: ");
                    var checkCarSingle = carMgr.GetAll().FirstOrDefault(x => x.CarId == value4);
                    if (checkCarSingle == null)
                    {
                        ScanerManager.PrintError("Seçim yanlışdır. Yenidən cəhd edin!");

                    csingle:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Yenidən yoxlamaq üçün sıxın <Boşluq> | Menyuya qayitmaq üçün sixin <ESC>");
                        Console.ResetColor();

                        ConsoleKeyInfo click = Console.ReadKey();
                        if (click.Key == ConsoleKey.Spacebar)
                        {
                            goto carsingle;
                        }
                        else if (click.Key == ConsoleKey.Escape)
                        {
                            goto readMenu;
                        }
                        else
                        {
                            goto csingle;
                        }
                    }
                    Console.Clear();
                    carMgr.SingleCar(value4);
                    goto readMenu;
                #endregion
                #region CarAll
                case Menu.CarAll:
                    Console.Clear();
                    ShowAllCars(carMgr);
                    goto readMenu;
                #endregion
                #region All
                case Menu.All:
                    ShowAll(carMgr, modelMgr, brandMgr);
                    goto readMenu;
                #endregion
                #region Exit
                case Menu.Exit:
                    goto lEnd;
                #endregion
                #region default
                default:
                    Console.Clear();
                    ScanerManager.PrintError("Seçim yanlışdır. Yenidən cəhd edin!");
                    goto readMenu;
                    #endregion
            }
        lEnd:
            Console.WriteLine("SON...");
            Console.WriteLine("Çıxmaq Üçün Hər Hansi Bir Düyməni Sıxın");
            Console.ReadKey();
        }
        static void PrintFuelMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(new string('-', Console.WindowWidth));

            foreach (var item in Enum.GetNames(typeof(FuelTypes)))
            {
                FuelTypes numFuel = (FuelTypes)Enum.Parse(typeof(FuelTypes), item);
                Console.WriteLine($"{((byte)numFuel).ToString().PadLeft(2)}. {item}");
            }
            Console.WriteLine($"{new string('-', Console.WindowWidth)}");
            Console.ResetColor();
        }

        static void PrintMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(new string('-', Console.WindowWidth));

            foreach (var item in Enum.GetNames(typeof(Menu)))
            {
                Menu carsys = (Menu)Enum.Parse(typeof(Menu), item);
                Console.WriteLine($"{((byte)carsys).ToString().PadLeft(2)}. {item}");
            }
            Console.WriteLine($"{new string('-', Console.WindowWidth)}");
            Console.ResetColor();
        }
        static void ShowAllBrands(BrandManager brandMgr)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.WriteLine("**********Brands**********");
            foreach (var item in brandMgr.GetAll())
            {
                Console.WriteLine(item);
            }
            Console.ResetColor();
        }
        static void ShowAllModels(ModelManager modelMgr)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.WriteLine("**********Models**********");
            foreach (var item in modelMgr.GetAll())
            {
                Console.WriteLine(item);
            }
            Console.ResetColor();
        }
        static void ShowAllCars(CarManager carMgr)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.WriteLine($"**********Cars**********");
            foreach (var item in carMgr.GetAll())
            {
                Console.WriteLine(item);
            }
            Console.ResetColor();
        }

        static void ShowAll(CarManager carMgr,ModelManager modelMgr, BrandManager brandMgr)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.WriteLine("**********Brands**********");
            foreach (var item in brandMgr.GetAll())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("**********Models**********");
            foreach (var item in modelMgr.GetAll())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"**********Cars**********");
            foreach (var item in carMgr.GetAll())
            {
                Console.WriteLine(item);
            }
            Console.ResetColor();
        }

    }
}