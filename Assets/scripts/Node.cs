using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace XBlocks.Utils
{
    public abstract class Node
    {
        protected abstract Terminal ExecuteImpl(ExecutionEnvironment enviroment);
        public Terminal Execute(ExecutionEnvironment environment)
        {
            //ExecutionEnterEventArgs args = new ExecutionEnterEventArgs(this);
            //environment.FireEnterNode(args);
           
             var c = this.ExecuteImpl(environment);
            
            //environment.FireLeaveNode(new ExecutionLeaveEventArgs(this, c));
          
             return c;
            
           
        }
    }
}
