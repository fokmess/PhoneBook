using System;
using System.Collections.Generic;
using System.Text;

namespace Book2
{
    [Serializable]
    public class Note
    {
       public string name, adress, phone, email;

        public Note () {  }

       public Note (string name,string adress, string phone,string email)
        {
            this.name = name;
            this.adress = adress;
            this.phone = phone;
            this.email = email;
        }
        public string[] InRow (Note note)
        {
            string []row = {name,adress,phone,email };
            return row;
        }
        public bool IsEmpty()
        {
            if (name == "" && adress == "" && phone == "" && email == "")
                return true;

            return false;
        }
    }
}
