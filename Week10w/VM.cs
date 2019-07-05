using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;

namespace Week10w
{
    public class VM
    {
        //get a reference to the database object that we can use repeatedly
        DB db = DB.GetInstance();

        #region properties

        //the list to show on the main page
        public BindingList<Employee> Employee
        {
            get { return new BindingList<Employee>(db.Get(search)); }
        }

        string search;
        public string Search
        {
            get { return search; }
            set { search = value; }
        }
        #endregion

    }
}
