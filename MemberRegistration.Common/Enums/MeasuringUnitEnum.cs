using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.Common
{
    /// <summary>
    /// Enum which determines that unit of measurement can be kom, usl, l, and kg.
    /// </summary>
    public enum MeasuringUnit
    {
        [Description("Komad")]
        kom = 1,
        [Description("Usluga")]
        usl = 2,
        [Description("Litra")]
        l = 3,
        [Description("Kilogram")]
        kg = 4
    }
}
