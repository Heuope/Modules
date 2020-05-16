using System;
using RPGclasses;

namespace NewClassModule
{
    public class Berserk : Hobo
    {
        public float Rage { get; set; }
        public float Speed { get; set; }

        public Berserk()
        {
            Name = "";
            Health = 0;
            Rage = 0;
            Speed = 0;
        }

        public override void ChangeInf(string argv)
        {
            var change = argv.Trim().Split(' ');
            if (change.Length != 4)
                return;

            try
            {
                if (change[0] != "_")
                    Name = change[0];
                if (change[1] != "_")
                    Health = int.Parse(change[1]);
                if (change[2] != "_")
                    Rage = float.Parse(change[2]);
                if (change[3] != "_")
                    Speed = float.Parse(change[3]);
            }
            catch (Exception) { }
        }

        public override void GetInf()
        {
            Console.WriteLine(" Berserk: Name Health Rage Speed");

            Console.WriteLine($"\tName: {Name}");
            Console.WriteLine($"\t\tHealth: {Health}");
            Console.WriteLine($"\t\tRage: {Rage}");
            Console.WriteLine($"\t\tSpeed: {Speed}");
        }
    }
}
