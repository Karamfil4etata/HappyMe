﻿namespace HappyMe.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using HappyMe.Data.Contracts;
    using HappyMe.Data.Contracts.Models;

    public class Module : DeletableEntity, IIdentifiable<int>
    {
        private ICollection<Question> questions;
        private ICollection<UserInModule> usersInModule; 

        public Module()
        {
            this.questions = new HashSet<Question>();  
            this.usersInModule = new HashSet<UserInModule>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(5), MaxLength(100)]
        public string Name { get; set; }

        [MinLength(10), MaxLength(5000)]
        public string Description { get; set; }

        public bool IsActive { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public bool IsPublic { get; set; }

        public virtual ICollection<Question> Questions
        {
            get { return this.questions; }
            set { this.questions = value; }
        }

        public virtual ICollection<UserInModule> UsersInModule
        {
            get { return this.usersInModule; }
            set { this.usersInModule = value; }
        }
    }
}