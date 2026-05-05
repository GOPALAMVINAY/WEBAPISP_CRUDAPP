using System;
using System.Collections.Generic;

namespace WEBAPISP_CRUDAPP.Models;

public partial class Aptest
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? Duration { get; set; }

    public string? Modules { get; set; }
}
