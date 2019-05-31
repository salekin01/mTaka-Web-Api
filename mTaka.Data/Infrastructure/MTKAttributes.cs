using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mTaka.Data.Infrastructure
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MTKAttributes : Attribute
    {
        private bool _isNftLog = true;

        public bool isNftLog
        {
            get
            { return _isNftLog; }
            set
            {
                if (value != _isNftLog)
                {
                    _isNftLog = value;
                }
            }
        }
    }
}
