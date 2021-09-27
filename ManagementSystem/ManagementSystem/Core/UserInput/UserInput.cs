using ManagementSystem.Core.Providers;
using System.Collections.Generic;

namespace ManagementSystem.Core.UserInput
{
    public abstract class UserInput : IUserInput
    {
        public const string delimeter = "###";

        public UserInput()
        {
            this.InstanceHolder = Providers.InstanceHolder.GetInstance();
            this.Parameters = new List<string>();
        }

        public virtual IInstanceHolder InstanceHolder { get;}
        public virtual List<string> Parameters { get; set; }
    }
}
