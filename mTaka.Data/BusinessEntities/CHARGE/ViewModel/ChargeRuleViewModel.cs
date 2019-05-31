using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mTaka.Data.BusinessEntities.Charge.ViewModel
{
    public class ChargeRuleViewModel
    {
        public string ChargeRuleName { set; get; }

        public string RuleCategory { set; get; }

        public string RuleType { set; get; }

        public string RateMethod { set; get; }

        public string GLAccNumber { set; get; }
    }
}
