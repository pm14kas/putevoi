using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace putevoi
{
    class ComboItem
    {
        public long id { get; set; }
        public string value { get; set; }

        public ComboItem(long _id, string _text)
        {
            id = _id;
            value = _text;
        }
    }
}
