using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarDef_To_Enum
{
    public class EnumCollect
    {
        private string Name;
        List<string> Values;

        private EnumCollect()
        {

        }
        public EnumCollect(string _name)
        {
            Name = _name;
            Values = new List<string>();
        }

        public void AddValue(string _value)
        {
            this.Values.Add(_value);
        }

        public void PrintMe()
        {
            
            Console.WriteLine();
            Console.WriteLine(string.Format("public enum {0}", this.Name));
            Console.WriteLine("{");
            int end = Values.Count - 1;
            for (int ii = 0; ii < end; ii++)
            {
                Console.WriteLine(string.Format("    {0},", Values[ii]));
            }
            Console.WriteLine(string.Format("    {0}", Values[end]));
            Console.WriteLine("};");
        }


    }//class
}//namespace
