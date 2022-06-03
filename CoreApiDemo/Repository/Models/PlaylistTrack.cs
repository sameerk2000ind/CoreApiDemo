using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CoreApiDemo.Repository.Models
{
    [Table("PlaylistTrack")]
    public partial class PlaylistTrack
    {
        [Key]
        public int PlaylistId { get; set; }
        public int TrackId { get; set; }
        public virtual Playlist Playlist { get; set; }
        public virtual Track Track { get; set; }
    }
}
