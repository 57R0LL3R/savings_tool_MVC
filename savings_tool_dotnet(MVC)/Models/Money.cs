using System;
using System.Collections.Generic;

namespace savings_tool_dotnet_MVC_.Models;

public partial class Money
{
    public Guid IdMoney { get; set; }

    public int? QuantityMoney { get; set; }

    public double? ValueMoney { get; set; }

    public int? Days { get; set; }

    public int? TotalValue { get; set; }
}
