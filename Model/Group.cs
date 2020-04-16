using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;



namespace FacultyOfPhysics.Model
{
    public class Group
    {
        [Key]
        public int GroupId { get; set; }

        [Required]
        public string NameGroup { get; set;}


        public virtual ICollection<Student> Students { get; set; }

        public Group()
        {
            Students = new List<Student>();
        }
    }
}
