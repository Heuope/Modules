using System;

namespace RPGclasses
{
    [Serializable]
    public sealed class Warrior : Hobo
    {
        public float Defence { get; set; }
        public float RegenHp { get; set; }
        public float Rage { get; set; }

        public Warrior()
        {
            Name = "";
            Health = 0;
            Defence = 0;
            RegenHp = 0;
            Rage = 0;
        }

        public override void GetInf()
        {
            Console.WriteLine(" Warrior: Name Health Defence Regen Rage");

            Console.WriteLine($"\tName: {Name}");
            Console.WriteLine($"\t\tHealth: {Health}");
            Console.WriteLine($"\t\tDefence: {Defence}");
            Console.WriteLine($"\t\tHealth regeneration: {RegenHp}");
            Console.WriteLine($"\t\tRage: {Rage}");
        }

        public override void ChangeInf(string argv)
        {
            var change = argv.Trim().Split(' ');
            if (change.Length != 5)
                return;

            try
            {
                if (change[0] != "_")
                    Name = change[0];
                if (change[1] != "_")
                    Health = int.Parse(change[1]);
                if (change[2] != "_")
                    Defence = float.Parse(change[2]);
                if (change[3] != "_")
                    RegenHp = float.Parse(change[3]);
                if (change[4] != "_")
                    Rage = float.Parse(change[4]);
            }
            catch (Exception) { }
        }
    }
}
