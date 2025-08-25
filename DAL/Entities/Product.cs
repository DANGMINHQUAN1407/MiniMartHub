using System;
using System.Collections.Generic;

namespace DAL.Entities;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Price { get; set; }

    public int? QuantityInStorage { get; set; }

    public string Status { get; set; } = null!;

    public string QrimageUrl { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
