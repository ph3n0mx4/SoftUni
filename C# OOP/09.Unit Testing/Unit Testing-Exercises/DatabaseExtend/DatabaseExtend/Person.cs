using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseExtend
{
    public class Person
    {
        private string username;
        private long id;

        public Person(string username, long id)
        {
            this.Username = username;
            this.Id = id;
        }

        public string Username
        {
            get=>this.username;
            set
            {
                this.username = value;
            }
        }

        public long Id
        {
            get=>this.id;
            set
            {
                this.id = value;
            }
        }
    }
}
