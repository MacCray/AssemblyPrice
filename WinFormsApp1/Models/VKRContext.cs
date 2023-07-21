using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AssemblyPrice.Models
{
    public partial class VKRContext : DbContext
    {
        public VKRContext()
        {
        }

        public VKRContext(DbContextOptions<VKRContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<ProductCompany> ProductCompanies { get; set; }
        public virtual DbSet<SpcProduct> SpcProducts { get; set; }
        public virtual DbSet<Specification> Specifications { get; set; }
        public virtual DbSet<StandartProduct> StandartProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["VKR_DB"].ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.Наименование);

                entity.HasIndex(e => e.Адрес, "IX_Companies")
                    .IsUnique();

                entity.HasIndex(e => e.Телефон, "IX_Companies_1")
                    .IsUnique();

                entity.Property(e => e.Наименование).HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Адрес)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Логотип)
                    .IsRequired()
                    .HasColumnType("image");

                entity.Property(e => e.Сайт)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Телефон)
                    .IsRequired()
                    .HasMaxLength(12);
            });

            modelBuilder.Entity<ProductCompany>(entity =>
            {
                entity.HasKey(e => new { e.ОбозначениеИзделия, e.НаименованиеКомпании });

                entity.ToTable("ProductCompany");

                entity.Property(e => e.ОбозначениеИзделия)
                    .HasMaxLength(100)
                    .HasColumnName("Обозначение изделия");

                entity.Property(e => e.НаименованиеКомпании)
                    .HasMaxLength(50)
                    .HasColumnName("Наименование компании");

                entity.Property(e => e.Скидка).HasColumnType("decimal(5, 4)");

                entity.Property(e => e.Стоимость).HasColumnType("decimal(17, 2)");

                entity.HasOne(d => d.НаименованиеКомпанииNavigation)
                    .WithMany(p => p.ProductCompanies)
                    .HasForeignKey(d => d.НаименованиеКомпании)
                    .HasConstraintName("FK_ProductCompany_Company");

                entity.HasOne(d => d.ОбозначениеИзделияNavigation)
                    .WithMany(p => p.ProductCompanies)
                    .HasForeignKey(d => d.ОбозначениеИзделия)
                    .HasConstraintName("FK_ProductCompany_Product");
            });

            modelBuilder.Entity<SpcProduct>(entity =>
            {
                entity.HasKey(e => new { e.НаименованиеСпецификации, e.ОбозначениеИзделия });

                entity.Property(e => e.НаименованиеСпецификации)
                    .HasMaxLength(50)
                    .HasColumnName("Наименование спецификации");

                entity.Property(e => e.ОбозначениеИзделия)
                    .HasMaxLength(100)
                    .HasColumnName("Обозначение изделия");

                entity.Property(e => e.КоличествоИзделий).HasColumnName("Количество изделий");

                entity.HasOne(d => d.НаименованиеСпецификацииNavigation)
                    .WithMany(p => p.SpcProducts)
                    .HasForeignKey(d => d.НаименованиеСпецификации)
                    .HasConstraintName("FK_SpcProducts_Specifications");

                entity.HasOne(d => d.ОбозначениеИзделияNavigation)
                    .WithMany(p => p.SpcProducts)
                    .HasForeignKey(d => d.ОбозначениеИзделия)
                    .HasConstraintName("FK_SpcProducts_StandartProducts");
            });

            modelBuilder.Entity<Specification>(entity =>
            {
                entity.HasKey(e => e.НаименованиеФайлаСпецификации);

                entity.Property(e => e.НаименованиеФайлаСпецификации)
                    .HasMaxLength(50)
                    .HasColumnName("Наименование файла спецификации");

                entity.Property(e => e.Изображение).HasColumnType("image");

                entity.Property(e => e.НаименованиеСборкиЧертежа)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Наименование сборки/чертежа");
            });

            modelBuilder.Entity<StandartProduct>(entity =>
            {
                entity.HasKey(e => e.Обозначение);

                entity.Property(e => e.Обозначение).HasMaxLength(100);

                entity.Property(e => e.НаименованиеМатериала)
                    .HasMaxLength(50)
                    .HasColumnName("Наименование материала");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
