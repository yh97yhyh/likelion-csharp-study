using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPGRefact
{
    class Character
    {
        public string Name { get; set; }
        public int Attack { get; set; }
        public int Hp { get; set; }

        public Character()
        {

        }

        public Character(string name, int attack, int hp)
        {
            Name = name;
            Attack = attack;
            Hp = hp;
        }

        public void TakeDamage(int attack)
        {
            Hp -= attack;
        }

        public virtual void ShowInfo()
        {
            
        }
    }
}
