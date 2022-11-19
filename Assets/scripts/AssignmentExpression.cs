using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XBlocks.Utils
{
    public class AssignmentExpression : Expression
    {
        public enum AssignmentOperator
        {
            AddEqual,
            MinusEqual,
            MulitiplyEqual,
            DivideEqual,
            ModEqual,
            Equal
        }

        public Expression Left { get; set; }
        public Expression Right { get; set; }
        public AssignmentOperator Operator { get; set; } = AssignmentOperator.Equal;
        public override string ReturnType
        {
            get { return "number|string|boolean"; }
        }

        protected override Terminal ExecuteImpl(ExecutionEnvironment enviroment)
        {
            var right = Right.Execute(enviroment);

            if (Left is IAssignment)
            {
                if (Operator == AssignmentOperator.Equal)
                {
                    
                    return (Left as IAssignment).Assign(enviroment, right.ReturnValue);
                }
            }

            return new Terminal();
        }

        public override string Type
        {
            get { return "VariableAssignmentExpression"; }
        }

    }
}
