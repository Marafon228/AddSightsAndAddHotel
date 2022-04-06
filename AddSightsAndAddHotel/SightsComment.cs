namespace AddSightsAndAddHotel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SightsComment")]
    public partial class SightsComment
    {
        public int Id { get; set; }

        public int SightsId { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Text { get; set; }

        [Required]
        [StringLength(50)]
        public string Author { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual Sights Sights { get; set; }
    }
}
