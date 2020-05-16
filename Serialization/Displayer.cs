using RPGclasses;
using System;
using System.Collections.Generic;

namespace Serialization
{
    public class Displayer
    { 
        public void Dislplay(List<Hobo> hobos)
        {
            for (int i = 0; i < hobos.Count; i++)
            {
                Console.Write($"{i}) ");
                hobos[i].GetInf();
                Console.WriteLine();
            }
        }

        public void ShowHelp()
        {
            Console.WriteLine(" . => exit");
            Console.WriteLine(" dsp => Display classes");
            Console.WriteLine(" chg => Change object");
            Console.WriteLine(" add => Add object");
            Console.WriteLine(" del => Delete object");
            Console.WriteLine(" cls => Show all classes");
            Console.WriteLine(" dll => load dll");
            Console.WriteLine(" save => save file to xml");
            Console.WriteLine(" load => load xml file");
        }
    }
}
