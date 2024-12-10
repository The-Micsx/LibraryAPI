using System;
using System.Collections.Generic;

namespace LibraryAPI.Models;

public partial class Fine
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public long LoanId { get; set; }

    public double Amount { get; set; }

    public bool? Paid { get; set; }

    public string Name { get; set; } = null!;

    public virtual Loan Loan { get; set; } = null!;
}
