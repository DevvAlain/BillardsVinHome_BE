using System;
using System.Collections.Generic;

namespace BilliardManagement.Entities;

public partial class Brand
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreateAt { get; set; }

    public virtual ICollection<Table> Tables { get; set; } = new List<Table>();
}
