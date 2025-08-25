using System;
using System.Collections.Generic;

namespace DAL.Entities;

public partial class Order
{
    public int Id { get; set; }

    public int TotalPrice { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedBy { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
