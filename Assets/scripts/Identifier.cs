using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XBlocks.Utils
{
    public class Identifier: Expression, IAssignment
    {
        public Identifier()
        {

        }
        public Identifier(string variable)
        {
            Variable = variable;
        }
        public String Variable { get; set; }
        public string VarType { get; set; }
        public override string ReturnType
        {
            get { return VarType; }
        }

        protected override Terminal ExecuteImpl(ExecutionEnvironment enviroment)
        {
             var value = enviroment.GetValue(Variable);
              return new Terminal(value);
        }

        public Terminal Assign(ExecutionEnvironment environment, object value)
        {   
            environment.SetValue(Variable, value);
            return new Terminal(value);
        }

        public override string Type
        {
            get { return VarType; }
        }
    }
}
