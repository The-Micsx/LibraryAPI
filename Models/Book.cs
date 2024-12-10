using System;
using System.Collections.Generic;

namespace LibraryAPI.Models;

public partial class Book
{
    public long Id { get; set; }

    public string Title { get; set; } = null!;

    public string Author { get; set; } = null!;

    public string Isbn { get; set; } = null!;

    public string Publisher { get; set; } = null!;

    public int YearPublished { get; set; }

    public string Genre { get; set; } = null!;

    public int CopiesAvailable { get; set; }

    public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();
}
