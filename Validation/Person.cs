﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation
{
    internal class Person : IDataErrorInfo
    {
        private string name;
        public string Name
        {
            get { return name; }
            set 
            {
                if (value.All(x => Char.IsLetter(x)))
                    name = value;
                else
                    throw new Exception("Bitte nur Buchstaben eingeben");
            }
        }

        public int Alter { get; set; }


        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case (nameof(Alter)):
                        if (Alter < 0) return "Dein Alter muss mindestens 0 sein";
                        if (Alter > 150) return "Du sollst nicht lügen";
                        break;
                }

                return null;
            }
        }
    }
}