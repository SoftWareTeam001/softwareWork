using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caculator
{
    class DownDirectionButton:MyButton
    {
        public override string ResultChange()
        {
            Log log = new Log();
            string nextlog = log.ReadNextLog();
            return nextlog;
        }
        public override string formulaChange()
        {
            throw new NotImplementedException();
        }
    }
}
