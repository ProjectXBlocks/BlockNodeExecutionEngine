using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XBlocks.Utils
{
    public abstract class Expression : Node
    {
        public abstract string ReturnType { get; }

        //ID used to store and load
        public abstract string Type { get; }
    }
}
