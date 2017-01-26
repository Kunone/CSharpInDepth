using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructAndClass
{
    struct DemoStruct
    {
        string _address;
        public string Name { get; set; }

        public string GetInvalidName()
        {
            return Name ?? "DefaultName";
        }
    }
}
