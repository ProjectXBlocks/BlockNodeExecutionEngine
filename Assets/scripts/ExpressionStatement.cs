using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XBlocks.Utils
{
    public class ExpressionStatement : Statement
    {
        public Expression Expression { get; set; }
        public override string ReturnType
        {
            get { return "boolean|number|string"; }
        }

        protected override Terminal ExecuteImpl(ExecutionEnvironment enviroment)
        {
            if (Expression == null)
                return Terminal.Void;
            return Expression.Execute(enviroment);

        }

        public override string Type
        {
            get
            {
                return "ExpressionStatement";
            }
        }

        public override bool IsClosing
        {
            get { return false; }
        }
    }
}
