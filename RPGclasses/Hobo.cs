using System;

namespace RPGclasses
{
    [Serializable]
    public abstract class Hobo
    {
        public string Name { get; set; }
        public int Health { get; set; }

        public Hobo()
        { }

        public Hobo(string name, int health)
        {
            Name = name;
            Health = health;
        }

        public abstract void GetInf();

        public abstract void ChangeInf(string argv);
    }
}
