﻿using System.ComponentModel;

namespace Ardent.Payments.Enum {
    public enum RecurringType {
        [Description("daily")]
        Daily,
        [Description("weekly")]
        Weekly,
        [Description("biweekly")]
        BiWeekly,
        [Description("monthly")]
        Monthly,
        [Description("bimonthly")]
        BiMonthly,
        [Description("quarterly")]
        Quarterly,
        [Description("semiannually")]
        SemiAnnually,
        [Description("annually")]
        Annually
    }
}
