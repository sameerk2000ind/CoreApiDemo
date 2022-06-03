using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CoreApiDemo.Repository.Models
{
    [Table("Artist")]
    public partial class Artist
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }        
    }
}
