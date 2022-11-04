using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XBlocks.Utils
{
    public abstract class Statement : Node
    {
        public abstract string ReturnType { get; }

        public abstract string Type { get; }
        // ���� ���� ���� �������� �ƴ��� ����
        public abstract bool IsClosing { get; }
    }
}
