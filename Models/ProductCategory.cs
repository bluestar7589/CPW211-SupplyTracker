using System;
using System.Collections.Generic;

namespace SupplyTracker.Models;

public partial class ProductCategory
{
    /// <summary>
    /// The unique identifier for the product category.
    /// </summary>
    public int ProductCategoryCode { get; set; }

    /// <summary>
    /// The name of the product category.
    /// </summary>
    public string? CategoryName { get; set; }

    /// <summary>
    /// The purpose of the product category.
    /// </summary>
    public string? Purpose { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
