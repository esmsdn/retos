using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectDumperTests
{
    class Test1Class
    {
        private string _bar;
        public string Foo { get; set; }
        public string Bar { set { _bar = value; }}

        public Test1Class()
        {
            Bar = "bar";
            Foo = "foo";
        }
    }
}
