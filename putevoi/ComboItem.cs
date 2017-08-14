using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace putevoi
{
    class ComboItem
    {
        public int id { get; set; }
        public string value { get; set; }

        public ComboItem(int _id, string _text)
        {
            id = _id;
            value = _text;
        }
    }
}
