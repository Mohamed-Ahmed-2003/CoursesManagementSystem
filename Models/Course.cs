using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CoursesManagementSystem.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public int CategoryId { get; set; }
        public int Rating {  get; set; }

        public string Promises { get; set; }
        public string Topics { get; set; }
        public string Prerequests { get; set; }

        public int TrainerId { get; set; }
        private string imageUrl;
        
        public string ImageUrl
        {
            get
            {
                return imageUrl;
            }
            set
            {
                imageUrl = (value == null) ? "no-image.png" : value;
            }
        }
        
        [DefaultValue(0)]
        public int TraineesCount { get; set; }

        [ForeignKey("TrainerId")]
        public virtual Trainer  trainer { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category category { get; set; }

        public virtual ICollection<Section> Sections { get; set; }
        public virtual ICollection<Trainee> Trainees{ get; set; }

    }
}