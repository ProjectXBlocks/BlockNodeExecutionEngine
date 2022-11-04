using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XBlocks.Utils
{
    public abstract class Statement : Node
    {
        public abstract string ReturnType { get; }

        public abstract string Type { get; }
        // 현재 구문 실행 끝나는지 아닌지 여부
        public abstract bool IsClosing { get; }
    }
}
