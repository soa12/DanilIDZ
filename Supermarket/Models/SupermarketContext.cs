namespace Supermarket.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SupermarketContext : DbContext
    {
        public SupermarketContext()
            : base("name=SupermarketContext")
        {
        }

        public virtual DbSet<Дисконтные_карты> Дисконтные_карты { get; set; }
        public virtual DbSet<История_изменения_цен> История_изменения_цен { get; set; }
        public virtual DbSet<Кассиры> Кассиры { get; set; }
        public virtual DbSet<Кассы> Кассы { get; set; }
        public virtual DbSet<Категории_товаров> Категории_товаров { get; set; }
        public virtual DbSet<Смены> Смены { get; set; }
        public virtual DbSet<Строка_в_чеке> Строка_в_чеке { get; set; }
        public virtual DbSet<Товары> Товары { get; set; }
        public virtual DbSet<Чеки> Чеки { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Дисконтные_карты>()
                .HasMany(e => e.Чеки)
                .WithRequired(e => e.Дисконтные_карты)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Кассиры>()
                .Property(e => e.Фамилия)
                .IsUnicode(false);

            modelBuilder.Entity<Кассиры>()
                .Property(e => e.Имя)
                .IsUnicode(false);

            modelBuilder.Entity<Кассиры>()
                .Property(e => e.Отчество)
                .IsUnicode(false);

            modelBuilder.Entity<Кассиры>()
                .HasMany(e => e.Чеки)
                .WithRequired(e => e.Кассиры)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Кассиры>()
                .HasMany(e => e.Смены)
                .WithRequired(e => e.Кассиры)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Кассы>()
                .HasMany(e => e.Смены)
                .WithRequired(e => e.Кассы)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Категории_товаров>()
                .Property(e => e.Наименование)
                .IsUnicode(false);

            modelBuilder.Entity<Категории_товаров>()
                .HasMany(e => e.Товары)
                .WithRequired(e => e.Категории_товаров)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Смены>()
                .HasMany(e => e.Чеки)
                .WithRequired(e => e.Смены)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Товары>()
                .Property(e => e.Наименование)
                .IsUnicode(false);

            modelBuilder.Entity<Товары>()
                .HasMany(e => e.История_изменения_цен)
                .WithRequired(e => e.Товары)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Товары>()
                .HasMany(e => e.Строка_в_чеке)
                .WithRequired(e => e.Товары)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Чеки>()
                .HasMany(e => e.Строка_в_чеке)
                .WithRequired(e => e.Чеки)
                .WillCascadeOnDelete(false);
           
        }
    }
}
