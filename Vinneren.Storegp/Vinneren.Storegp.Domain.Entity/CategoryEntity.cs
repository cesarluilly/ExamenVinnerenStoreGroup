using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vinneren.Storegp.Domain.Entity.ByTable;

//                                                          //AUTHOR:  (CLGA - Cesar Garcia).
//                                                          //DATE: January 22, 2022. 
namespace Vinneren.Storegp.Domain.Entity
{
    //==================================================================================================================
    [Table("Category")]
    public class CategoryEntity : ICategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Pk {get; set;}
        [Column("Name", TypeName = "nvarchar(50)")]
        public string? Name { get; set; }
        public int Id { get; set; }
    }
}
