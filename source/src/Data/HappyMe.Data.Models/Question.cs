﻿namespace HappyMe.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using HappyMe.Common.Constants;
    using HappyMe.Common.Models;
    using HappyMe.Data.Contracts;
    using HappyMe.Data.Contracts.Models;

    public class Question : DeletableEntity, IIdentifiable<int>
    {
        private ICollection<Answer> answers;
        private ICollection<QuestionInModule> questionsInModules;

        public Question()
        {
            this.answers = new HashSet<Answer>();
            this.questionsInModules = new HashSet<QuestionInModule>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(GlobalConstants.QuestionTextMinLength)]
        [MaxLength(GlobalConstants.QuestionTextMaxLength)]
        public string Text { get; set; }

        public QuestionType Type { get; set; }

        public bool IsPublic { get; set; }

        public int? ImageId { get; set; }

        public virtual Image Image { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public virtual ICollection<Answer> Answers
        {
            get => this.answers;
            set => this.answers = value;
        }

        public virtual ICollection<QuestionInModule> QuestionsInModules
        {
            get => this.questionsInModules;
            set => this.questionsInModules = value;
        }
    }
}
