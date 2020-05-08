using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace TeamMVVM.Model
{
    class PlayerModel
    {
        private string firstName;
        private string lastName;
        private ushort age;
        private double weight;

        public PlayerModel(string _firstName, string _lastName, ushort _age, double _weight)
        {
            this.firstName = _firstName;
            this.lastName = _lastName;
            this.age = _age;
            this.weight = _weight;
        }

        public PlayerModel(PlayerModel player)
        {
            this.firstName = player.firstName;
            this.lastName = player.lastName;
            this.age = player.age;
            this.weight = player.weight;
        }

        public PlayerModel() { }

        public override string ToString()
        {
            return String.Format($"{firstName} {lastName} {age}yo {weight}kg");
        }

        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public ushort Age { get { return age; } set { age = value; } }
        public double Weight { get { return weight; } set { weight = value; } }
    }
}
