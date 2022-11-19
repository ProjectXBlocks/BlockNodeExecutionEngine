using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XBlocks.Utils
{
    public class LoopStatement : Statement
    {
        public LoopStatement()
        {
            Body = new BlockStatement();
        }
        public Expression Loop { get; set; }
        public BlockStatement Body
        {
            get;
            set;
        }
        public override string ReturnType
        {
            get { return "void"; }
        }
        protected override Terminal ExecuteImpl(ExecutionEnvironment enviroment)
        {
            if (Loop == null || Body == null || Body.Body.Count == 0)
                return Terminal.Void;
            var c = Loop.Execute(enviroment);
            if (c.Type == TerminalType.Value)
            {

                int cycle = 0;
                    cycle = TypeConverters.GetValue<int>(c.ReturnValue);
     
                for (int i = 0; i < cycle; i++)
                {
                    //ExecutionEnvironment current = new ExecutionEnvironment(enviroment);
                    var cx = Body.Execute(enviroment);
                   
                    if (cx.Type == TerminalType.Break)
                    {
                        return Terminal.Void;
                    }
                    if (cx.Type == TerminalType.Return)
                        return cx;
                }
            }
            return c;
        }

        public override string Type
        {
            get
            {
                return "WhileStatement";
            }
        }
        public override bool IsClosing
        {
            get { return false; }
        }
    }
}
