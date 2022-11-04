using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace XBlocks.Utils
{
    public class Test : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            ExecutionEnvironment e = new ExecutionEnvironment(null);
            e.RegisterValue("a", true);
            e.RegisterValue("b", false);
            e.RegisterValue("c", 5);
            e.RegisterValue("d", 6);
            IfStatement s = new IfStatement();
            s.Test = new BinaryExpression() { Left = new Identifier() { Variable = "a" }, Right = new Identifier() { Variable = "b" }, op = BinaryExpression.Operator.And };
            s.Consequent = new BlockStatement();
            s.Consequent.Body.Add(new ExpressionStatement() { Expression = new AssignmentExpression() { Left = new Identifier() { Variable = "c" }, Right = new Identifier() { Variable = "d" } } });
            s.Alternate = new BlockStatement();
            s.Alternate.Body.Add(new ExpressionStatement() { Expression = new Identifier() { Variable = "d" } });

            IConvertible value = s.Execute(e).ReturnValue as IConvertible;
            Debug.Log(value);
            var v = value.ToInt32(null);
            Debug.Assert(v == 6);

            e.SetValue("b", true);

            IConvertible newV = s.Execute(e).ReturnValue as IConvertible;
            var V = newV.ToInt32(null);
            Debug.Assert(V == 6);
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
