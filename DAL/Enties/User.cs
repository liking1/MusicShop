using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Enties
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Login { get; set; }
        [Required]
        [MaxLength(2000)]
        public string Password { get; set; }
        [MaxLength(200)]
        public string Email { get; set; }
    }
}
