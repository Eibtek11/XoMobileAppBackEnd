using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Domains;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Newtonsoft.Json;

#nullable disable

namespace BL
{
    public  class TbQuestionsMCQLast
    {
       

        public Guid QuestionId { get; set; }
        public string QestionSyntax { get; set; }
        public string QuestionAnswer { get; set; }
        public Guid? LevelId { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }

        public virtual TbLevel Level { get; set; }
        // Other properties are not displayed
        internal string _Tags { get; set; }

        
        // Other properties are not displayed

        [NotMapped]
        public string[] Tags
        {
            get { return _Tags == null ? null : JsonConvert.DeserializeObject<string[]>(_Tags); }
            set { _Tags = JsonConvert.SerializeObject(value); }
        }

      
    }
    public class Person
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }
    }
    public class Blog
    {
        public int BlogId { get; set; }

        public string Url { get; set; }

        public List<Post> Posts { get; set; }
        // Other properties are not displayed
        internal string _Tags { get; set; }

        internal string _Owner { get; set; }
        // Other properties are not displayed

        [NotMapped]
        public string[] Tags
        {
            get { return _Tags == null ? null : JsonConvert.DeserializeObject<string[]>(_Tags); }
            set { _Tags = JsonConvert.SerializeObject(value); }
        }

        [NotMapped]
        public Person Owner
        {
            get { return _Owner == null ? null : JsonConvert.DeserializeObject<Person>(_Owner); }
            set { _Owner = JsonConvert.SerializeObject(value); }
        }
    }

    public class Post
    {
        public int PostId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int BlogId { get; set; }

        public Blog Blog { get; set; }


    }
    public partial class MobileAppDbContext : IdentityDbContext<ApplicationUser>
    {
        public MobileAppDbContext()
        {
        }

        public MobileAppDbContext(DbContextOptions<MobileAppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbClaim> TbClaims { get; set; }
        public virtual DbSet<TbComment> TbComments { get; set; }
        public virtual DbSet<TbCountry> TbCountries { get; set; }
        public virtual DbSet<TbLaw> TbLaws { get; set; }
        public virtual DbSet<TbLevel> TbLevels { get; set; }
        public virtual DbSet<TbLoginHistory> TbLoginHistories { get; set; }
        public virtual DbSet<TbQuestion> TbQuestions { get; set; }
        public virtual DbSet<TbReplyToComment> TbReplyToComments { get; set; }
        public virtual DbSet<TbTask> TbTasks { get; set; }
        public virtual DbSet<TbTrUserCountryLaw> TbTrUserCountryLaws { get; set; }
        public virtual DbSet<TbUserQestionAnswer> TbUserQestionAnswers { get; set; }
        public virtual DbSet<TbQuestionsMCQ> TbQuestionsMCQS { get; set; }
        public virtual DbSet<TbQuestionsMcqAnswers> TbQuestionsMcqAnswerss { get; set; }
        public virtual DbSet<VwLevelsAndLaws> VwLevelsAndLawss { get; set; }
        public virtual DbSet<VwLevelsAndLawsAndQuestions> VwLevelsAndLawsAndQuestionss { get; set; }
        public virtual DbSet<VwTasksAndUsers> VwTasksAndUserss { get; set; }


        public virtual DbSet<VwStatYear> VwStatYears { get; set; }
        public virtual DbSet<VwStatMonth> VwStatMonths { get; set; }
        public virtual DbSet<VwStatMonthUser> VwStatMonthUsers { get; set; }
        public virtual DbSet<VwStatYearUser> VwStatYearUsers { get; set; }
        public virtual DbSet<VwLevelsAndLawsAndQuestionMCQ> VwLevelsAndLawsAndQuestionMCQs { get; set; }

        public virtual DbSet<Blog> Blogs { get; set; }

        public virtual DbSet<TbQuestionsMCQLast> TbQuestionsMCQLasts { get; set; }

        public virtual DbSet<VwOneApiCollectQuestions> VwOneApiCollectQuestions { get; set; }


        public virtual DbSet<CalculateUserGrade> CalculateUserGrades { get; set; }

        public virtual DbSet<TbLawLevelOne> TbLawLevelOnes { get; set; }


        public virtual DbSet<TbLawLevelTwo> TbLawLevelTwos { get; set; }

        public virtual DbSet<TbClaimLeveOne> TbClaimLeveOnes { get; set; }


        public virtual DbSet<TbClaimLevelTwo> TbClaimLevelTwos { get; set; }




        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //                optionsBuilder.UseSqlServer("Server=DESKTOP-ABVI0A5;Database=MobileAppDb;Trusted_Connection=True;");
        //            }
        //        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TbQuestionsMCQLast>()
       .Property(b => b._Tags).HasColumnName("Tags");

            modelBuilder.Entity<TbQuestionsMCQLast>(entity =>
            {
                entity.HasKey(e => e.QuestionId);

                
            });


            modelBuilder.Entity<Blog>()
        .Property(b => b._Tags).HasColumnName("Tags");

            modelBuilder.Entity<Blog>()
                .Property(b => b._Owner).HasColumnName("Owner");
            
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");



            modelBuilder.Entity<TbClaim>(entity =>
            {
                entity.HasKey(e => e.ClaimId);

                entity.Property(e => e.ClaimId).ValueGeneratedNever();

                entity.Property(e => e.ClaimPdf).HasMaxLength(200);

                entity.Property(e => e.ClaimSyntax).HasMaxLength(200);

                entity.Property(e => e.ClainImage).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.TbClaims)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_TbClaims_TbCountry");
            });



            modelBuilder.Entity<TbClaimLeveOne>(entity =>
            {
                entity.HasKey(e => e.ClaimLeveOneId);

                entity.Property(e => e.ClaimLeveOneId).ValueGeneratedNever();

                entity.Property(e => e.ClaimId).HasMaxLength(200);

                entity.Property(e => e.ClaimLeveOneSyntax).HasMaxLength(200);

                entity.Property(e => e.ClaimLevelOneDescription).HasMaxLength(200);

                entity.Property(e => e.ClainLeveOneImage).HasMaxLength(200);

                entity.Property(e => e.ClaimLeveOnePdf).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.claim)
                    .WithMany(p => p.TbClaimLeveOnes)
                    .HasForeignKey(d => d.ClaimId)
                    .HasConstraintName("FK_TbClaimLeveOnes_TbClaims");
            });






            modelBuilder.Entity<TbClaimLevelTwo>(entity =>
            {
                entity.HasKey(e => e.ClaimLevelTwoId);

                entity.Property(e => e.ClaimLevelTwoId).ValueGeneratedNever();

                entity.Property(e => e.ClaimLeveOneId).HasMaxLength(200);

                entity.Property(e => e.ClaimLevelTwoSyntax).HasMaxLength(200);

                entity.Property(e => e.ClaimLevelTwoSyntax).HasMaxLength(200);

                entity.Property(e => e.ClainLevelTwoImage).HasMaxLength(200);

                entity.Property(e => e.ClaimLevelTwoPdf).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.claimOne)
                    .WithMany(p => p.TbClaimLevelTwos)
                    .HasForeignKey(d => d.ClaimLeveOneId)
                    .HasConstraintName("FK_TbClaimLevelTwos_TbClaimLeveOnes");
            });

            modelBuilder.Entity<TbComment>(entity =>
            {
                entity.HasKey(e => e.CommentId);

                entity.Property(e => e.CommentId).ValueGeneratedNever();

                entity.Property(e => e.CommentSyntax).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });
            modelBuilder.Entity<VwLevelsAndLaws>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwLevelsAndLaws");


            });

            modelBuilder.Entity<VwStatYear>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwStatYear");


            });
            modelBuilder.Entity<CalculateUserGrade>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("CalculateUserGrade");


            });

            
            modelBuilder.Entity<VwOneApiCollectQuestions>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwOneApiCollectQuestions");


            });


            
            modelBuilder.Entity<VwStatMonth>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwStatMonth");


            });





            modelBuilder.Entity<VwStatMonthUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwStatMonthUser");


            });





            modelBuilder.Entity<VwStatYearUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwStatYearUser");


            });









            modelBuilder.Entity<VwTasksAndUsers>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwTasksAndUsers");


            });
            modelBuilder.Entity<VwLevelsAndLawsAndQuestionMCQ>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwLevelsAndLawsAndQuestionMCQ");


            });



            


            modelBuilder.Entity<VwLevelsAndLawsAndQuestions>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwLevelsAndLawsAndQuestions");


            });

            modelBuilder.Entity<TbCountry>(entity =>
            {
                entity.HasKey(e => e.CountryId);

                entity.ToTable("TbCountry");

                entity.Property(e => e.CountryId).ValueGeneratedNever();

                entity.Property(e => e.CountryImageName).HasMaxLength(200);

                entity.Property(e => e.CountryName).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbLaw>(entity =>
            {
                entity.HasKey(e => e.LawId);

                entity.ToTable("TbLaw");

                entity.Property(e => e.LawId).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LawDescription).HasMaxLength(200);

                entity.Property(e => e.LawName).HasMaxLength(200);

                entity.Property(e => e.LawPdf).HasMaxLength(200);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.TbLaws)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_TbLaw_TbCountry");
            });


            modelBuilder.Entity<TbLawLevelOne>(entity =>
            {
                entity.HasKey(e => e.LawLevelOneId);

                entity.ToTable("TbLawLevelOne");

                entity.Property(e => e.LawLevelOneId).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LawLevelOneDescription).HasMaxLength(200);

                entity.Property(e => e.LawLevelOneName).HasMaxLength(200);

                entity.Property(e => e.LawLevelOnePdf).HasMaxLength(200);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.law)
                    .WithMany(p => p.TbLawLevelOnes)
                    .HasForeignKey(d => d.LawId)
                    .HasConstraintName("FK_TbLawLevelOne_TbLaw");
            });
            
            modelBuilder.Entity<TbLawLevelTwo>(entity =>
            {
                entity.HasKey(e => e.LawLevelTwoId);

                entity.ToTable("TbLawLevelTwo");

                entity.Property(e => e.LawLevelTwoId).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LawLevelTwoDescription).HasMaxLength(200);

                entity.Property(e => e.LawLevelTwoName).HasMaxLength(200);

                entity.Property(e => e.LawLevelTwoPdf).HasMaxLength(200);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.lawOne)
                    .WithMany(p => p.TbLawLevelTwos)
                    .HasForeignKey(d => d.LawLevelOneId)
                    .HasConstraintName("FK_TbLawLevelTwo_TbLawLevelOne");
            });

            modelBuilder.Entity<TbLevel>(entity =>
            {
                entity.HasKey(e => e.LevelId);

                entity.Property(e => e.LevelId).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LevelName).HasMaxLength(450);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Law)
                    .WithMany(p => p.TbLevels)
                    .HasForeignKey(d => d.LawId)
                    .HasConstraintName("FK_TbLevels_TbLaw");
            });






            modelBuilder.Entity<TbQuestionsMcqAnswers>(entity =>
            {
                entity.HasKey(e => e.QuestionsMcqAnswerId);

                entity.Property(e => e.QuestionsMcqAnswerId).ValueGeneratedNever();

                entity.Property(e => e.QuestionAnswer).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.QuestionsMcqAnswerSytntax).HasMaxLength(450);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.QuestionsMCQ)
                    .WithMany(p => p.TbUserQestionAnswers)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK_TbQuestionsMcqAnswers_TbQuestionsMCQ");
            });

            modelBuilder.Entity<TbLoginHistory>(entity =>
            {
                entity.HasKey(e => e.LogInId);

                entity.ToTable("TbLoginHistory");

                entity.Property(e => e.LogInId).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Id).HasMaxLength(450);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbQuestion>(entity =>
            {
                entity.HasKey(e => e.QuestionId);

                entity.Property(e => e.QuestionId).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.QestionSyntax).HasMaxLength(200);

                entity.Property(e => e.QuestionAnswer).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Level)
                    .WithMany(p => p.TbQuestions)
                    .HasForeignKey(d => d.LevelId)
                    .HasConstraintName("FK_TbQuestions_TbLevels");
            });








            modelBuilder.Entity<TbQuestionsMCQ>(entity =>
            {
                entity.HasKey(e => e.QuestionId);

                entity.Property(e => e.QuestionId).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.QestionSyntax).HasMaxLength(200);

                entity.Property(e => e.QuestionAnswer).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Level)
                    .WithMany(p => p.TbQuestionsMCQ)
                    .HasForeignKey(d => d.LevelId)
                    .HasConstraintName("FK_TbQuestionsMCQS_TbLevels");
            });

            modelBuilder.Entity<TbReplyToComment>(entity =>
            {
                entity.HasKey(e => e.CommentReplyId);

                entity.Property(e => e.CommentReplyId).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.ReplySyntax).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.TbReplyToComments)
                    .HasForeignKey(d => d.CommentId)
                    .HasConstraintName("FK_TbReplyToComments_TbComments");
            });

            modelBuilder.Entity<TbTask>(entity =>
            {
                entity.HasKey(e => e.TaskId);

                entity.Property(e => e.TaskId).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.TaskDescription).HasMaxLength(200);

                entity.Property(e => e.TaskPoints).HasMaxLength(200);

                entity.Property(e => e.TaskSyntax).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbTrUserCountryLaw>(entity =>
            {
                entity.HasKey(e => e.UserCountryLawId);

                entity.ToTable("TbTrUserCountryLaw");

                entity.Property(e => e.UserCountryLawId).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Id).HasMaxLength(450);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbUserQestionAnswer>(entity =>
            {
                entity.HasKey(e => e.UserQuestionAnswerId);

                entity.Property(e => e.UserQuestionAnswerId).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Id).HasMaxLength(450);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserAnswer).HasMaxLength(450);

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.TbUserQestionAnswers)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK_TbUserQestionAnswers_TbQuestions");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
