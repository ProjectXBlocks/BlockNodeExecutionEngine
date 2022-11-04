using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XBlocks.Utils
{
    public enum TerminalType
    {
        Value,
        Continue,
        Break,
        Return,
        Exception
    }

    public class Terminal 
    {
        public static Terminal Void = new Terminal();

        public Node Location { get; internal set; } = null;
        public TerminalType Type { get; internal set; } = TerminalType.Value;
        public object ReturnValue { get; internal set; } = null;

        public Terminal()
        {
            ReturnValue = null;
        }

        public Terminal(object value)
        {
            ReturnValue = value;
        }

        public Terminal(object value, TerminalType type)
        {
            ReturnValue = value;
            Type = type;
        }

        public bool IsValue
        {
            get
            {
                return Type == TerminalType.Value;
            }
        }


    }
}
