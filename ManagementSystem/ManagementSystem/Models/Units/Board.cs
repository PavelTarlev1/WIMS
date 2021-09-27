using ManagementSystem.Core.Providers;
using ManagementSystem.Models.Abstract;
using ManagementSystem.Models.Contracts;
using System;
using System.Linq;

namespace ManagementSystem.Models.Units
{
    public class Board : Unit, IBoard
    {
        private string name;
        public Board(string name) : base(name)
        {
            //this.Name = name;
        }

        public override string Print()
        {
            return $"Name:{this.Name}";
        }
        public override string Name
        {
            get => this.name;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(ValidationMessages.BoardNameLength);
                }
                else if (value.Length < 5 || value.Length > 10)
                {
                    throw new ArgumentOutOfRangeException(ValidationMessages.BoardNameLength);
                }
               
                else
                {
                    this.name = value;
                }
            }
        }
    }
}
