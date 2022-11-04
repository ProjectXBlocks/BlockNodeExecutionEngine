using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XBlocks.Utils
{
    public class BlockStatement : Node
    {
        ObservableCollection<Statement> _body = new ObservableCollection<Statement>();

        public ObservableCollection<Statement> Body
        {
            get { return _body; }
            set
            {
                _body = value;
            }
        }
        protected override Terminal ExecuteImpl(ExecutionEnvironment enviroment)
        {
            if (Body == null || Body.Count == 0)
                return Terminal.Void;
            Terminal c = Terminal.Void;
            for (int i = 0; i < Body.Count; i++)
            {
                Statement stat = Body[i];
                c = stat.Execute(enviroment);
                if (c.Type != TerminalType.Value)
                {
                    return c;
                }
            }
            return c;
        }
    }
}
