using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureService.Domain
{
    public class User : IComparable, IEquatable<User>
    {
        public User()
        {
            Roles = new List<Role>();
        }
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Role> Roles { get; set; }
        
        //Careful here... if you change a mutable object already in the dictionary, it wont work (these values should not change though)
        public override int GetHashCode()
        {
            return this.Email.GetHashCode() * 17 + this.Id.GetHashCode(); //17 is prime and reduces risk of hash collision
        }

        public int CompareTo(object obj)
        {
            User that = obj as User;
            if (that == null) throw new ArgumentException("You can only compare Users");
            if (this.Id == that.Id)
            {
                return 0;
            }
            else if (this.Id > that.Id)
            {
                return 1;
            }
            else if (this.Id < that.Id)
            {
                return -1;
            }
            else
            {
                return 1;
            }

        }

        public bool Equals(User other)
        {
            User that = other as User;
            if (that == null) throw new ArgumentException("You can only compare Users");
            return this.Email == other.Email && this.Id == other.Id;
        }
    }
}
