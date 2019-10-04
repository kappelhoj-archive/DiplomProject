﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    /// <summary>
    /// Describes products that are not deleted in the productcatalog. This is cached from Productcatalog usually
    /// </summary>
    public class AvailableProduct
    {
        public Guid ProductId { get; set; }

        public string Title { get; set; }

        public bool Discontinued { get; set; }
    }
}