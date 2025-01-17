using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    public class Travel:BaseEntity
    {
        [Required]
        [Display(Prompt = "Title")]
        public string Title { get; set; }
        [Required]
        [Display(Prompt = "Description")]
        public string Description { get; set; }
        
        public string? ImageUrl { get; set; }
        [NotMapped]
        public IFormFile? TravelPhoto { get; set; }
        [Required]
        [Display(Prompt = "Rating")]
        public float Rating { get; set; }
        [Required]
        [Display(Prompt = "RatingCount")]
        public int RatingCount { get; set; }
        [Required]
        [Display(Prompt = "Minimum Price")]
        public decimal MinimumPrice { get; set; }
        [Required]
        [Display(Prompt = "Maximum Price")]
        public decimal MaximumPrice { get; set; }
       
        public Category? category  { get; set; }
        [Required]
        [Display(Prompt = "CategoryId")]
        public int CategoryId { get; set; }

    }
}
