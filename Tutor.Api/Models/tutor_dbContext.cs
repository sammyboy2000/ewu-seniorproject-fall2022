﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Tutor.Api.Models
{
    public partial class tutor_dbContext : IdentityDbContext<AppUser>
    {
        public tutor_dbContext()
        {
        }

        public tutor_dbContext(DbContextOptions<tutor_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<AnsweredQuestion> AnsweredQuestions { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<Tutor> Tutors { get; set; }
        public virtual DbSet<ApiUser> ApiUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<AnsweredQuestion>(entity =>
            {
                entity.HasKey(e => e.QuestionId);

                entity.ToTable("Answered_Questions");

                entity.Property(e => e.QuestionId)
                    .ValueGeneratedNever()
                    .HasColumnName("question_id");

                entity.Property(e => e.ClassId).HasColumnName("class_id");

                entity.Property(e => e.Question)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("question");

                entity.Property(e => e.Response)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("response");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.Property(e => e.TopicId).HasColumnName("topic_id");

                entity.Property(e => e.TutorId).HasColumnName("tutor_id");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("Class");

                entity.HasIndex(e => e.ClassCode, "IX_Class")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClassCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("class_code");

                entity.Property(e => e.ClassDesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("class_desc");

                entity.Property(e => e.ClassName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("class_name");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.QuestionId)
                    .ValueGeneratedNever()
                    .HasColumnName("question_id");

                entity.Property(e => e.ClassId).HasColumnName("class_id");

                entity.Property(e => e.Question1)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("question");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.Property(e => e.TopicId).HasColumnName("topic_id");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.ToTable("Topic");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClassId).HasColumnName("class_id");

                entity.Property(e => e.Topic1)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("topic");
            });

            modelBuilder.Entity<Tutor>(entity =>
            {
                entity.ToTable("Tutor");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<ApiUser>(entity =>
            {
                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("user_id");

                entity.Property(e => e.ExternalId)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("external_id")
                    .IsFixedLength();

                entity.Property(e => e.IsAdmin).HasColumnName("is_admin");

                entity.Property(e => e.IsStudent).HasColumnName("is_student");

                entity.Property(e => e.IsTutor).HasColumnName("is_tutor");
            });

            OnModelCreatingPartial(modelBuilder);
        }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}