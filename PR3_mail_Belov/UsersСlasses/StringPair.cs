using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PR3_mail_Belov.UsersСlasses;

namespace PR3_mail_Belov.UsersСlasses
{
    public class StringPair
    {
        private string _emailAdress;
        private string _name;

        public string EmailAdress
        {
            get { return _emailAdress; }
            set
            {
                _emailAdress = String.IsNullOrWhiteSpace(value) ?
                    throw new ArgumentNullException(nameof(_emailAdress)) : value;
            }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = String.IsNullOrWhiteSpace(value) ?
                    throw new ArgumentNullException(nameof(_name)) : value;
            }
        }
        public StringPair(string emailAdress, string name)
        {
            EmailAdress = emailAdress;
            Name = name;    
        }
    }
}
