using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caculator
{
    abstract class MyButton
    {
        public string Content;
        public string ShowContent;
        abstract public string ResultChange();
        abstract public string formulaChange();
    }
}
