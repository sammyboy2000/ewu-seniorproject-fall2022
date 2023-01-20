﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tutor.Api.Models
{
    public partial class Tutor
    {
        public Tutor()
        {
            AnsweredQuestions = new HashSet<AnsweredQuestion>();
        }
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ApiUser User { get; set; }
        public virtual ICollection<AnsweredQuestion> AnsweredQuestions { get; set; }
    }
}