using Microsoft.Extensions.DependencyInjection;
using MotorShop_Project.Logic.Interfaces;
using MotorShop_Project.Model.Classes;
using Spectre.Console;

namespace MotorShop_Project.Classes
{
    enum Entites
    {
        Brand = 1,
        Model = 2,
        Etras = 3,
        Orders = 4
    }
    public static class Menu
    {
        private static readonly Dictionary<(Entites, string), Action> actionMap = new();
        public static void StartMenu(IServiceScope scope)
        {
            InitializeActionMap(scope.ServiceProvider);
            bool running = true;

            while (running)
            {
                var mainSelection = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[yellow]Főmenü - Válassz egy opciót:[/]")
                        .AddChoices(new[]
                        {
                        "Brand", "Model", "Extras", "Order", "Instructions", "Exit"
                        }));

                switch (mainSelection)
                {
                    case "Brand":
                        HandleEntityMenu(Entites.Brand);
                        break;
                    case "Model":
                        HandleEntityMenu(Entites.Model);
                        break;
                    case "Extras":
                        HandleEntityMenu(Entites.Etras);
                        break;
                    case "Order":
                        HandleEntityMenu(Entites.Orders);
                        break;
                    case "Instructions":
                        ShowInstructions();
                        break;
                    case "Exit":
                        running = false;
                        break;
                }
            }

            AnsiConsole.MarkupLine("[green]Kilépés...[/]");
        }

        static void HandleEntityMenu(Entites entityName)
        {
            while (true)
            {
                var subSelection = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title($"[blue]{entityName} menü - válassz egy műveletet:[/]")
                        .AddChoices(new[]
                        {
                        "ReadAll","Create", "Read", "Update", "Delete",
                        "NonCrud1", "NonCrud2", "NonCrud3",
                        "Back"
                }));

                if (subSelection == "Back")
                    break;
                SelectSubSelection(entityName, subSelection);
                AnsiConsole.MarkupLine($"[green]{entityName} - {subSelection} végrehajtva. [/]");
            }
        }
        private static void SelectSubSelection(Entites entite, string command)
        {
            if (actionMap.TryGetValue((entite, command), out var action))
            {
                action();
            }
            else
            {
                AnsiConsole.MarkupLine($"[red]A(z) {entite} - {command} kombináció még nincs implementálva.[/]");
            }
        }


        public static void InitializeActionMap(IServiceProvider provider)
        {
            var brandLogic = provider.GetRequiredService<IBrandLogic>();

            actionMap[(Entites.Brand, "ReadAll")] = () => HandleReadAll<Brand>("Brand",brandLogic);

            actionMap[(Entites.Brand, "Create")] = () => HandleCreateBrand(brandLogic);
            actionMap[(Entites.Brand, "Read")] = () =>
            {
                Console.Write("ID: ");
                int id = int.Parse(Console.ReadLine());
                HandleReadBrand(brandLogic, id);
            };
            actionMap[(Entites.Brand, "Update")] = () =>
            {
                Console.Write("ID: ");
                int id = int.Parse(Console.ReadLine());
                var brand = brandLogic.Read(id);
                HandleUpdateBrand(brandLogic, brand);
            };
            actionMap[(Entites.Brand, "Delete")] = () =>
            {
                Console.Write("ID: ");
                int id = int.Parse(Console.ReadLine());
                var brand = brandLogic.Read(id);
                HandleDeleteBrand(brandLogic, brand);
            };
        }

        private static void HandleReadAll<T>(string entityName, ILogic<T> logic) where T :class
        {
            Console.Clear();
            var items = logic.ReadAll();
            if (items != null && items.Count() == 0)
            {
                Console.WriteLine($"Ninc eleme a {entityName} táblának");
            }
            else if (items == null)
            {
                throw new NullReferenceException($"Nem létezik a {entityName} nevű tábla");
            }
            Console.WriteLine($"{entityName} tábla összes eleme:");
            foreach (var item in items)
            {
                if (item != null)
                    Console.WriteLine(item.ToString());
            }
        }

        private static void HandleCreateBrand(ILogic<Brand> logic)
        {

            Console.WriteLine("=== Brand létrehozás ===");
            Console.Write("Név: ");
            string name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Név nem lehet üres");
                Console.ReadLine();
                return;
            }
            else
            {

                Console.Write("Alt szöveg: ");
                string alt = Console.ReadLine();
                if (string.IsNullOrEmpty(alt))
                    alt = null;

                var newBrand = new Brand(name, alt, null);

                logic.Create(newBrand);
            }

            Console.WriteLine();
            Console.WriteLine("Sikeresen létrehozva!");
            Console.WriteLine();
            Console.WriteLine("Nyomj ENTER-t a visszatéréshez...");
            Console.ReadLine();
            Console.Clear();
        }
        private static void HandleReadBrand(ILogic<Brand> logic, int id)
        {
            Brand brand = logic.Read(id);
            Console.WriteLine(brand.ToString());
            Console.WriteLine();
            Console.WriteLine("Sikeresen létrehozva!");
            Console.WriteLine();
            Console.WriteLine("Nyomj ENTER-t a visszatéréshez...");
            Console.ReadLine();
            Console.Clear();

        }
        private static void HandleDeleteBrand(ILogic<Brand> logic, Brand brand)
        {
            Console.WriteLine("Következő elem lett törölve");
            Console.WriteLine(brand.ToString());
            logic.Delete(brand);
            Console.WriteLine();
            Console.WriteLine("Sikeresen Törölve!");
            Console.WriteLine();
            Console.WriteLine("Nyomj ENTER-t a visszatéréshez...");
            Console.ReadLine();
            Console.Clear();
        }
        private static void HandleUpdateBrand(ILogic<Brand> logic, Brand brand)
        {
            Console.WriteLine("=== Brand Modosítása ===");
            Console.Write("Név: ");
            string name = Console.ReadLine();
            if (name == "")
            {
                Console.WriteLine("Név nem lehet üres");
                Console.ReadLine();
                return;
            }
            else
            {

                brand.Name = name;
                brand.Image = null;

                Console.Write("Alt szöveg: ");
                string alt = Console.ReadLine();
                if (alt == "")
                    alt = null;
                brand.Alt = alt;

                logic.Update(brand);
            }

            Console.WriteLine();
            Console.WriteLine("Sikeresen létrehozva!");
            Console.WriteLine();
            Console.WriteLine("Nyomj ENTER-t a visszatéréshez...");
            Console.ReadLine();
            Console.Clear();
        }

        #region NotDone
        // TODO:
        // Vázak meg vannak kéőbb belyezni.
        private static void HandleCreateModel(ILogic<BrandModel> logic)
        {
            Console.WriteLine("=== Model létrehozás ===");
            Console.Write("Név: ");
            string name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Név nem lehet üres");
                Console.ReadLine();
                return;
            }

            var newModel = new BrandModel
            {
                Name = name
            };

            logic.Create(newModel);
            Console.WriteLine();
            Console.WriteLine("Sikeresen létrehozva!");
            Console.ReadLine();
            Console.Clear();
        }

        private static void HandleReadModel(ILogic<BrandModel> logic, int id)
        {
            BrandModel model = logic.Read(id);
            Console.WriteLine(model.ToString());
            Console.ReadLine();
            Console.Clear();
        }

        private static void HandleDeleteModel(ILogic<BrandModel> logic, BrandModel model)
        {
            Console.WriteLine("Következő elem lett törölve");
            Console.WriteLine(model.ToString());
            logic.Delete(model);
            Console.WriteLine("Sikeresen törölve!");
            Console.ReadLine();
            Console.Clear();
        }

        private static void HandleUpdateModel(ILogic<BrandModel> logic, BrandModel model)
        {
            Console.WriteLine("=== Model módosítása ===");
            Console.Write("Név: ");
            string name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name))
                model.Name = name;

            logic.Update(model);

            Console.WriteLine("Sikeresen frissítve!");
            Console.ReadLine();
            Console.Clear();
        }
        private static void HandleCreateExtras(ILogic<Extras> logic)
        {
            Console.WriteLine("=== Extras létrehozás ===");
            Console.Write("Név: ");
            string name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Név nem lehet üres");
                Console.ReadLine();
                return;
            }

            var newExtras = new Extras
            {
                Name = name
            };

            logic.Create(newExtras);
            Console.WriteLine("Sikeresen létrehozva!");
            Console.ReadLine();
            Console.Clear();
        }

        private static void HandleReadExtras(ILogic<Extras> logic, int id)
        {
            var extras = logic.Read(id);
            Console.WriteLine(extras.ToString());
            Console.ReadLine();
            Console.Clear();
        }

        private static void HandleDeleteExtras(ILogic<Extras> logic, Extras extras)
        {
            Console.WriteLine("Következő elem lett törölve");
            Console.WriteLine(extras.ToString());
            logic.Delete(extras);
            Console.WriteLine("Sikeresen törölve!");
            Console.ReadLine();
            Console.Clear();
        }

        private static void HandleUpdateExtras(ILogic<Extras> logic, Extras extras)
        {
            Console.WriteLine("=== Extras módosítása ===");
            Console.Write("Név: ");
            string name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name))
                extras.Name = name;

            logic.Update(extras);

            Console.WriteLine("Sikeresen frissítve!");
            Console.ReadLine();
            Console.Clear();
        }

        private static void HandleCreateOrder(ILogic<Order> logic)
        {
            Console.WriteLine("=== Order létrehozás ===");

            var newOrder = new Order
            {
            };

            logic.Create(newOrder);
            Console.WriteLine("Sikeresen létrehozva!");
            Console.ReadLine();
            Console.Clear();
        }

        private static void HandleReadOrder(ILogic<Order> logic, int id)
        {
            var order = logic.Read(id);
            Console.WriteLine(order.ToString());
            Console.ReadLine();
            Console.Clear();
        }

        private static void HandleDeleteOrder(ILogic<Order> logic, Order order)
        {
            Console.WriteLine("Következő elem lett törölve");
            Console.WriteLine(order.ToString());
            logic.Delete(order);
            Console.WriteLine("Sikeresen törölve!");
            Console.ReadLine();
            Console.Clear();
        }

        private static void HandleUpdateOrder(ILogic<Order> logic, Order order)
        {
            Console.WriteLine("=== Order módosítása ===");

            logic.Update(order);

            Console.WriteLine("Sikeresen frissítve!");
            Console.ReadLine();
            Console.Clear();
        }

        #endregion
        private static void ShowInstructions()
        {
            AnsiConsole.MarkupLine("[bold yellow]Használati útmutató:[/]");
            AnsiConsole.MarkupLine("- Válassz entitást a főmenüből (Brand, Model, Extras, Order)");
            AnsiConsole.MarkupLine("- Ezután válassz egy CRUD vagy Non-CRUD műveletet");
            AnsiConsole.MarkupLine("- A Back menüponttal visszatérhetsz a főmenübe\n");
        }

    }
}
