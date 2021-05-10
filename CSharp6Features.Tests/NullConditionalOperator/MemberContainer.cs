using System.Collections.Generic;

namespace CSharp6Features.Tests.NullConditionalOperator
{
    public class MemberContainer
    {
        private readonly List<int> _values;

        public MemberContainer(IEnumerable<int> values)
        {
            _values = new List<int>(values);
        }

        public string Property { get; set; }

        public int this[int index]
        {
            get
            {
                return _values[index];
            }
            set
            {
                _values[index] = value;
            }
        }

        public string Echo(string value)
        {
            return value;
        }



    }
}
