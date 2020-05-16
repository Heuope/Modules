using RPGclasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Serialization
{
    public class Serializer
    {
        private List<Hobo> hobos = new List<Hobo>();

        private delegate void AddCommand(string[] data);
        private delegate void MainCommands();

        private Dictionary<string, Type> types = new Dictionary<string, Type>();
        private readonly Dictionary<string, MainCommands> mainMenuCommands = new Dictionary<string, MainCommands>();

        public Serializer()
        {
            mainMenuCommands.Add("dsp", Display);
            mainMenuCommands.Add("chg", Change);
            mainMenuCommands.Add("add", Add);
            mainMenuCommands.Add("del", Delete);
            mainMenuCommands.Add("help", Help);
            mainMenuCommands.Add("cls", ShowAllClasses);
            mainMenuCommands.Add("dll", LoadNewClass);
            mainMenuCommands.Add("save", Save);
            mainMenuCommands.Add("load", Load);

            types.Add("warrior", typeof(Warrior));
            types.Add("mage", typeof(Mage));
            types.Add("archer", typeof(Archer));

            string answer;

            while (true)
            {
                Console.Write("\n|> ");
                answer = Console.ReadLine().ToLower().Trim();                
                if (answer == ".")
                    break;
                if (mainMenuCommands.ContainsKey(answer))
                    mainMenuCommands[answer].Invoke();
            }
        }

        private void Load()
        {
            var fileKeeper = new FileKeeper();
            hobos = fileKeeper.DeSerialize();
        }

        private void Save()
        {
            var fileKeeper = new FileKeeper();
            fileKeeper.Serialize(hobos);
        }

        private void ShowAllClasses()
        {
            foreach (var key in types.Keys)
            {
                Console.WriteLine($"--> {key}");
            }
        }

        private void LoadNewClass()
        {
            Console.WriteLine("Enter path to dll\n|> ");
            string dllName = Console.ReadLine();
            try
            {
                var assembly = Assembly.LoadFrom($"{dllName}");
                var classType = assembly.GetTypes().Single();

                types.Add(classType.Name.ToLower(), classType);
            } catch (Exception)
            {
                Console.WriteLine("Whoops something wrong :( ");
            }
        }

        private void Help()
        {
            var displayer = new Displayer();
            displayer.ShowHelp();
        }

        private void Change()
        {
            Console.WriteLine(" Choice for change:");
            Display();

            var change = int.Parse(Console.ReadLine());

            Console.WriteLine(" Example: [params, if default => _ ]");
            Console.Write("|> ");
            var toChg = Console.ReadLine();
            try
            {
                hobos[change].ChangeInf(toChg); 
            }
            catch (Exception)
            {
                Console.WriteLine(" Some data is missing.");
            }
        }

        private void Display()
        {
            var displayer = new Displayer();
            displayer.Dislplay(hobos);
        }

        private void Delete()
        {
            Display();
            Console.WriteLine(" Example: [Number in list]");
            Console.Write("|> ");
            var toDel = Console.ReadLine();
            try
            {
                hobos.RemoveAt(int.Parse(toDel));
            }
            catch (Exception)
            {
                Console.WriteLine(" Some data is missing.");
            }
        }        

        private void Add()
        {
            var displayer = new Displayer();

            Console.Write(" Enter class would you like to add: ");
            var className = Console.ReadLine();

            Console.Write(" Enter information: ");
            var toAdd = Console.ReadLine();

            try
            {
                var instance = Activator.CreateInstance(types[className]);
                var temp = instance as Hobo;
                temp.ChangeInf(toAdd);
                hobos.Add(temp);
            }
            catch (Exception e)
            {
                Console.WriteLine(" Some data is missing.");
                Console.WriteLine(e.Message);
            }            
        }
    }
}
