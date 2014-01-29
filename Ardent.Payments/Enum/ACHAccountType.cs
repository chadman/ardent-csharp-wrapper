using System.ComponentModel;

namespace Ardent.Payments.Enum {
    public enum ACHAccountType {
        [Description("C")]
        Checking,
        [Description("S")]
        Savings
    }
}
