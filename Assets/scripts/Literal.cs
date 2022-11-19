using System.Collections;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace XBlocks.Utils
{
    public class Literal : Expression
    {
        public Literal() { }
        public Literal(string raw) { Raw = raw; }
        public override string ReturnType
        {
            get { return ""; }
        }
        public static string GetStringLateral(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < text.Length;)
            {
                char c = text[i];
                if (c == '\\')
                {
                    i += 1;
                    char n = text[i];
                    switch (n)
                    {
                        //case 'u':
                        //case 'x':
                        //    break;
                        case 'n':
                            sb.Append("\n");
                            break;
                        case 'r':
                            sb.Append("\r");
                            break;
                        case 't':
                            sb.Append("\t");
                            break;
                        case 'b':
                            sb.Append("\b");
                            break;
                        case 'f':
                            sb.Append("\f");
                            break;
                        case 'v':
                            sb.Append("\x0B");
                            break;
                        case '\\':
                            sb.Append('\\');
                            break;
                        case '\"':
                            sb.Append('\"');
                            break;
                        default:
                            // exception
                            break;
                    }
                }
                else if (c == '\"')
                    // exceptioon
                    break;
                else
                    sb.Append(c);
                i += 1;
            }
            return sb.ToString();
        }
        protected override Terminal ExecuteImpl(ExecutionEnvironment enviroment)
        {
            if (Raw == null)
                return new Terminal(null);
            int intValue;
            float floatValue;
            double doubleValue;
            bool b;
            if (Raw.StartsWith("\"") && Raw.EndsWith("\""))
            {
                string str = GetStringLateral(Raw.Substring(1, Raw.Length - 2));
                return new Terminal(str);
            }
            if (Raw.StartsWith("'") && Raw.EndsWith("'") && Raw.Length == 3)
                return new Terminal(Raw[1]);
            if (Raw.StartsWith("0x", StringComparison.CurrentCultureIgnoreCase) ||
                Raw.StartsWith("&H", StringComparison.CurrentCultureIgnoreCase))
            {
                string hex = Raw.Substring(2);
                uint uintValue;
                if (uint.TryParse(hex, System.Globalization.NumberStyles.HexNumber, CultureInfo.CurrentCulture, out uintValue))
                    return new Terminal(uintValue);
            }
            if (Raw.Equals("true", StringComparison.CurrentCultureIgnoreCase))
                return new Terminal(true);
            if (Raw.Equals("false", StringComparison.CurrentCultureIgnoreCase))
                return new Terminal(false);
            if (Raw.Equals("null", StringComparison.CurrentCultureIgnoreCase))
                return new Terminal(null);
            if (int.TryParse(Raw, out intValue))
                return new Terminal(intValue);
            if (float.TryParse(Raw, out floatValue))
                return new Terminal(floatValue);
            if (double.TryParse(Raw, out doubleValue))
                return new Terminal(doubleValue);
            if (Boolean.TryParse(Raw, out b))
                return new Terminal(b);
            //if (enviroment.HasValue(Raw))
            //    return new Terminal(enviroment.GetValue(Raw));
            return null;
            //return Terminal.Exception(string.Format(Properties.Language.InvalidFormat, Raw), this);
        }

        public Terminal Assign(ExecutionEnvironment environment, object value)
        {
            if (environment.Has(Raw))
                environment.SetValue(Raw, value);
            return null;
            //return Terminal.Exception(string.Format(Properties.Language.VariableNotDefined, Raw), this);
        }

        public override string Type
        {
            get { return "Literal"; }
        }

        public string Raw
        {
            get;
            set;
        }
    }
}
