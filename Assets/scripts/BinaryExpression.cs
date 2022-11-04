using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using UnityEngine;

namespace XBlocks.Utils
{
    public class BinaryExpression : Expression
    {
        public Expression Left { get; set; }
        public Operator op { get; set; }
        public Expression Right { get; set; }

        public BinaryExpression()
        {
            op = Operator.Add;
        }

        public string ValueType { get; set; } = "any";

        public override string ReturnType
        {
            get
            {
                return ValueType;
            }
        }

        public override string Type
        {
            get { return "BinaryExpression"; }
        }

        bool IsLogicalOperator(Operator op)
        {
            if (op == Operator.And || op == Operator.Or)
                return true;
            return false;
        }

        Terminal ExecuteLogical(ExecutionEnvironment enviroment, object left, object right)
        {

            IConvertible cLeft = left as IConvertible;
            var l = cLeft.ToBoolean(null);
            IConvertible cRight = right as IConvertible;
            var r = cRight.ToBoolean(null);
            switch (op)
            {
                case Operator.And:
                    return new Terminal(l && r);
                case Operator.Or:
                    return new Terminal(l || r);
            }
            return new Terminal();
        }

        protected override Terminal ExecuteImpl(ExecutionEnvironment environment)
        {
            var left = Left.Execute(environment);
    
            if (left.Type != TerminalType.Value)
            {
                return left;
            }
            var right = Right.Execute(environment);
            if (right.Type != TerminalType.Value)
            {
                return right;
            }

            if(IsLogicalOperator(op))
            {
                return ExecuteLogical(environment, left.ReturnValue, right.ReturnValue);
            }

            return new Terminal();

        }

        public enum Operator
        {
            And,
            Or,
            Add
        }
    }
   }
