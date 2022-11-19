using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XBlocks.Utils
{
    public class IfStatement : Statement
    {
        public IfStatement()
        {
            Consequent = new BlockStatement();
        }
        public Expression Test { get; set; }
        public BlockStatement Consequent
        {
            get;
            set;
        }
        BlockStatement _alternate;
        public BlockStatement Alternate
        {
            get
            {
                return _alternate;
            }
            set
            {
                _alternate = value;
            }
        }

        public override string ReturnType
        {
            get { return "void"; }
        }
        protected override Terminal ExecuteImpl(ExecutionEnvironment enviroment)
        {
           
            var t = Test.Execute(enviroment);
            

            if (t.Type != TerminalType.Value)
                return t;
            if (t.ReturnValue is bool)
            {
                if ((bool)t.ReturnValue)
                {
                    if (Consequent == null)
                        return Terminal.Void;
                    //ExecutionEnvironment current = new ExecutionEnvironment(enviroment);
                    return Consequent.Execute(enviroment);
                }
                else
                {
                    if (Alternate == null)
                        return Terminal.Void;
                    //ExecutionEnvironment current = new ExecutionEnvironment(enviroment);
                    return Alternate.Execute(enviroment);
                }
            }

            return new Terminal();
           
        }

        public override string Type
        {
            get
            {
                return "IfStatement";
            }
        }
        public override bool IsClosing
        {
            get { return false; }
        }
    }
}
