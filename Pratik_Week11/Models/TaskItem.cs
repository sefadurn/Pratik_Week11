using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Pratik_Week11.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Job alanı zorunludur.")]
        [MinLength(5, ErrorMessage = "Job en az 5 karakter olmalıdır.")]
        public string Job { get; set; }

        [StringLength(200, ErrorMessage = "FunFeature en fazla 200 karakter olabilir.")]
        public string FunFeature { get; set; }

    }
}
