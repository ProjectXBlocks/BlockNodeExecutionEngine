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
        // 탬플릿 매소드 패턴
        protected abstract Terminal ExecuteImpl(ExecutionEnvironment enviroment);

        public Terminal Execute(ExecutionEnvironment environment)
        {
            // 혹은 사용자가  멈춤 버튼 눌렀는지 아닌지 활용하는 용도
             // 스택 개수 초과되는 거 막을 때 사용  재귀 잘못짰을 때 stack exceed error 같은 거 많이 보셨을 겁니다.
            //ExecutionEnterEventArgs args = new ExecutionEnterEventArgs(this);
            //environment.FireEnterNode(args);
           
             var c = this.ExecuteImpl(environment);
            
            //environment.FireLeaveNode(new ExecutionLeaveEventArgs(this, c));
          
             return c;
            
           
        }
    }
}
