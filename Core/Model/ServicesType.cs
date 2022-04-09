using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class ServicesType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = String.Empty;

        public double Price { get; set; }
    }
}