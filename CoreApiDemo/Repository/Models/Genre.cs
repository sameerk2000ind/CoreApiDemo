using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CoreApiDemo.Repository.Models
{
    [Table("Genre")]
    public partial class Genre
    {
        [Key]
        public int GenreId { get; set; }
        [StringLength(120)]
        public string Name { get; set; }
    }
}
