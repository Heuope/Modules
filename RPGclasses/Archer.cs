using System;

namespace RPGclasses
{
    [Serializable]
    public sealed class Archer : Hobo
    { 
        public float Accuracy { get; set; }
        public float Dps { get; set; }        

        public Archer()
        {
            Name = "";
            Health = 0;
            Accuracy = 0;
            Dps = 0;
        }

        public override void GetInf()
        {
            Console.WriteLine(" Gunner: Name Health Accuracy DPS");

            Console.WriteLine($"\tName: {Name}");
            Console.WriteLine($"\t\tHealth: {Health}");
            Console.WriteLine($"\t\tAccuracy: {Accuracy}");
            Console.WriteLine($"\t\tDps: {Dps}");
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
                    Accuracy = float.Parse(change[2]);
                if (change[3] != "_")
                    Dps = float.Parse(change[3]);
            }
            catch (Exception) { }
        }
    }
}
