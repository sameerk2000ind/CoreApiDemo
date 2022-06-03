using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CoreApiDemo.Repository.Models
{
    [Table("InvoiceLine")]
    public partial class InvoiceLine
    {
        [Key]
        public int InvoiceLineId { get; set; }
        public int InvoiceId { get; set; }
        public int TrackId { get; set; }
        [Column(TypeName = "numeric(10, 2)")]
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
