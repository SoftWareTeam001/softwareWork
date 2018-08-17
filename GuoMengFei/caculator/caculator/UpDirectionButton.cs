using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace caculator
{
    class UpDirectionButton:MyButton
    {
        public override string ResultChange()
        {
            Log log = new Log();
            string lastlog=log.ReadLastLog();
            return lastlog;
        }
        public override string formulaChange()
        {
            throw new NotImplementedException();
        }
    }
}
