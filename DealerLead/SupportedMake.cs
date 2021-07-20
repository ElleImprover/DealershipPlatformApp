using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace DealerLead
{
  public  class SupportedMake
    {
        [Key]
        [Column("MakeId")]
        public int MakeID { get; set; }

        [Display(Name ="Name")]
        [Column("MakeName")]
        public string MakeName { get; set; }

        [ScaffoldColumn(false)]//hides values
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreateDate { get; set; }

        //hides values
        [ScaffoldColumn(false)]
        public DateTime? ModifyDate { get; set; }

        public List<SupportedModel> Models { get; set; }

    }

    // MakeId INT PRIMARY KEY IDENTITY,
    //MakeName NVARCHAR(30),
    //CreateDate DATETIME NOT NULL DEFAULT(getdate()),
    //ModifyDate DATETIME
}
