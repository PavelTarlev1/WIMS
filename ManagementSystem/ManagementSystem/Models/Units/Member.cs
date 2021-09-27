using ManagementSystem.Core.Providers;
using ManagementSystem.Models.Abstract;
using ManagementSystem.Models.Contracts;
using ManagementSystem.Models.Units;
using System;

namespace ManagementSystem.Models
{
    public class Member : Unit, IMember
    {
        private string name;
        public Member(string name) : base(name)
        {
            
        }
        public override string Name
        {
            get => this.name;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(ValidationMessages.MemberNameLenght);
                }
                else if (value.Length < 5 || value.Length > 15)
                {
                    throw new ArgumentOutOfRangeException(ValidationMessages.MemberNameLenght);
                }
                else
                {
                    this.name = value;
                }
            }
        }
    }
}  
    
