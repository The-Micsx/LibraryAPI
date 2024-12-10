using System;
using System.Collections.Generic;

namespace LibraryAPI.Models;

public partial class Loan
{
    public long Id { get; set; }

    public long BookId { get; set; }

    public long UserId { get; set; }

    public DateOnly LoanDate { get; set; }

    public DateOnly? DueDate { get; set; }

    public DateOnly? ReturnDate { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual ICollection<Fine> Fines { get; set; } = new List<Fine>();

    public virtual User User { get; set; } = null!;
}
