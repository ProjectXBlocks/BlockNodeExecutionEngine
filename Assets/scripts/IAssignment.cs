using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XBlocks.Utils
{
    public interface IAssignment 
    {
        Terminal Assign(ExecutionEnvironment environment, object value);
    }
}
