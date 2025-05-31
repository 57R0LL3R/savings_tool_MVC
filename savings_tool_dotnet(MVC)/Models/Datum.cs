using System;
using System.Collections.Generic;

namespace savings_tool_dotnet_MVC_.Models;

public partial class Datum
{
    public Guid IdData { get; set; }

    public string? Name { get; set; }

    public int? MaxValue { get; set; }
}
