using System;

namespace RPGclasses
{
    [Serializable]
    public sealed class Mage : Hobo
    {
        public float Mana { get; set; }

        public Mage()
        {
            Name = "";
            Health = 0;
            Mana = 0;
        }

        public override void GetInf()
        {
            Console.WriteLine(" Mage: Name Health Mana");

            Console.WriteLine($"\tName: {Name}");
            Console.WriteLine($"\t\tHealth: {Health}");
            Console.WriteLine($"\t\tMana: {Mana}");
        }

        public override void ChangeInf(string argv)
        {
            var change = argv.Trim().Split(' ');
            if (change.Length != 3)
                return;

            try
            {
                if (change[0] != "_")
                    Name = change[0];
                if (change[1] != "_")
                    Health = int.Parse(change[1]);
                if (change[2] != "_")
                    Mana = float.Parse(change[2]);
            }
            catch (Exception) { }
        }
    }
}
