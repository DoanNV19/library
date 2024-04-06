using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.Application.Models.Requests
{
    public class CreateBookReq
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }
        
        [Required]
        public Guid AuthorId { get; set; }
        
        public int Page { get; set; }
        public int Price { get; set; }
    }
}
