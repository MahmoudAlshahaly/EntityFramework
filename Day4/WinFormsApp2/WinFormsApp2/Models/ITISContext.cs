using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WinFormsApp2.Models
{
    public partial class ITISContext : DbContext
    {
        public ITISContext()
        {
        }

        public ITISContext(DbContextOptions<ITISContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Daily> Dailies { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<InsCourse> InsCourses { get; set; }
        public virtual DbSet<Instructor> Instructors { get; set; }
        public virtual DbSet<InstructorNameWithTopic> InstructorNameWithTopics { get; set; }
        public virtual DbSet<InstructorWithDeprtment> InstructorWithDeprtments { get; set; }
        public virtual DbSet<Last> Lasts { get; set; }
        public virtual DbSet<StuFullName> StuFullNames { get; set; }
        public virtual DbSet<StudCourse> StudCourses { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentDatum> StudentData { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-476FTDE\\SQLEXPRESS;Database=ITIS;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.CrsId);

                entity.ToTable("Course");

                entity.Property(e => e.CrsId).HasColumnName("Crs_Id");

                entity.Property(e => e.CrsDuration).HasColumnName("Crs_Duration");

                entity.Property(e => e.CrsName)
                    .HasMaxLength(50)
                    .HasColumnName("Crs_Name");

                entity.Property(e => e.TopId).HasColumnName("Top_Id");
            });

            modelBuilder.Entity<Daily>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Daily");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DeptId);

                entity.ToTable("Department");

                entity.Property(e => e.DeptId)
                    .ValueGeneratedNever()
                    .HasColumnName("Dept_Id");

                entity.Property(e => e.DeptDesc)
                    .HasMaxLength(100)
                    .HasColumnName("Dept_Desc");

                entity.Property(e => e.DeptLocation)
                    .HasMaxLength(50)
                    .HasColumnName("Dept_Location");

                entity.Property(e => e.DeptManager).HasColumnName("Dept_Manager");

                entity.Property(e => e.DeptName)
                    .HasMaxLength(50)
                    .HasColumnName("Dept_Name");

                entity.Property(e => e.ManagerHiredate)
                    .HasColumnType("date")
                    .HasColumnName("Manager_hiredate");

                entity.HasOne(d => d.DeptManagerNavigation)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.DeptManager)
                    .HasConstraintName("FK_Department_Instructor");
            });

            modelBuilder.Entity<InsCourse>(entity =>
            {
                entity.HasKey(e => new { e.InsId, e.CrsId });

                entity.ToTable("Ins_Course");

                entity.Property(e => e.InsId).HasColumnName("Ins_Id");

                entity.Property(e => e.CrsId).HasColumnName("Crs_Id");

                entity.Property(e => e.Evaluation).HasMaxLength(50);

                entity.HasOne(d => d.Ins)
                    .WithMany(p => p.InsCourses)
                    .HasForeignKey(d => d.InsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ins_Course_Instructor");
            });

            modelBuilder.Entity<Instructor>(entity =>
            {
                entity.HasKey(e => e.InsId);

                entity.ToTable("Instructor");

                entity.Property(e => e.InsId)
                    .ValueGeneratedNever()
                    .HasColumnName("Ins_Id");

                entity.Property(e => e.DeptId).HasColumnName("Dept_Id");

                entity.Property(e => e.InsDegree)
                    .HasMaxLength(50)
                    .HasColumnName("Ins_Degree");

                entity.Property(e => e.InsName)
                    .HasMaxLength(50)
                    .HasColumnName("Ins_Name");

                entity.Property(e => e.Salary).HasColumnType("money");

                entity.HasOne(d => d.Dept)
                    .WithMany(p => p.Instructors)
                    .HasForeignKey(d => d.DeptId)
                    .HasConstraintName("FK_Instructor_Department");
            });

            modelBuilder.Entity<InstructorNameWithTopic>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("InstructorNameWithTopic");

                entity.Property(e => e.InsName)
                    .HasMaxLength(50)
                    .HasColumnName("Ins_Name");

                entity.Property(e => e.TopName)
                    .HasMaxLength(50)
                    .HasColumnName("Top_Name");
            });

            modelBuilder.Entity<InstructorWithDeprtment>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("InstructorWithDeprtment");

                entity.Property(e => e.DeptName)
                    .HasMaxLength(50)
                    .HasColumnName("Dept_Name");

                entity.Property(e => e.InsName)
                    .HasMaxLength(50)
                    .HasColumnName("Ins_Name");
            });

            modelBuilder.Entity<Last>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Last");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<StuFullName>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("StuFullName");

                entity.Property(e => e.FullName)
                    .HasMaxLength(61)
                    .HasColumnName("Full Name");
            });

            modelBuilder.Entity<StudCourse>(entity =>
            {
                entity.HasKey(e => new { e.CrsId, e.StId });

                entity.ToTable("Stud_Course");

                entity.Property(e => e.CrsId).HasColumnName("Crs_Id");

                entity.Property(e => e.StId).HasColumnName("St_Id");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.StId);

                entity.ToTable("Student");

                entity.Property(e => e.StId)
                    .ValueGeneratedNever()
                    .HasColumnName("St_Id");

                entity.Property(e => e.DeptId).HasColumnName("Dept_Id");

                entity.Property(e => e.StAddress)
                    .HasMaxLength(100)
                    .HasColumnName("St_Address");

                entity.Property(e => e.StAge).HasColumnName("St_Age");

                entity.Property(e => e.StFname)
                    .HasMaxLength(50)
                    .HasColumnName("St_Fname");

                entity.Property(e => e.StLname)
                    .HasMaxLength(10)
                    .HasColumnName("St_Lname")
                    .IsFixedLength(true);

                entity.Property(e => e.StSuper).HasColumnName("St_super");
            });

            modelBuilder.Entity<StudentDatum>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("studentData");

                entity.Property(e => e.DeptId).HasColumnName("Dept_Id");

                entity.Property(e => e.StAddress)
                    .HasMaxLength(100)
                    .HasColumnName("St_Address");

                entity.Property(e => e.StAge).HasColumnName("St_Age");

                entity.Property(e => e.StFname)
                    .HasMaxLength(50)
                    .HasColumnName("St_Fname");

                entity.Property(e => e.StId).HasColumnName("St_Id");

                entity.Property(e => e.StLname)
                    .HasMaxLength(10)
                    .HasColumnName("St_Lname")
                    .IsFixedLength(true);

                entity.Property(e => e.StSuper).HasColumnName("St_super");
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.HasKey(e => e.TopId);

                entity.ToTable("Topic");

                entity.Property(e => e.TopId)
                    .ValueGeneratedNever()
                    .HasColumnName("Top_Id");

                entity.Property(e => e.TopName)
                    .HasMaxLength(50)
                    .HasColumnName("Top_Name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
