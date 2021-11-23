namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class myShopContext : DbContext
    {
        public myShopContext()
            : base("name=myShopContext")
        {
        }

        public virtual DbSet<Bonus_card> Bonus_card { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Check> Checks { get; set; }
        public virtual DbSet<Line_of_check> Line_of_check { get; set; }
        public virtual DbSet<Line_of_postavka> Line_of_postavka { get; set; }
        public virtual DbSet<Postavka> Postavkas { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Stroka_check_and_postavka> Stroka_check_and_postavka { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bonus_card>()
                .Property(e => e.kolvo_bonusov)
                .HasPrecision(5, 3);

            modelBuilder.Entity<Bonus_card>()
                .HasMany(e => e.Checks)
                .WithOptional(e => e.Bonus_card)
                .HasForeignKey(e => e.number_of_card_FK);

            modelBuilder.Entity<Categoria>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Categoria>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Categoria)
                .HasForeignKey(e => e.id_categoria_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Check>()
                .Property(e => e.total_cost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Check>()
                .HasMany(e => e.Line_of_check)
                .WithRequired(e => e.Check)
                .HasForeignKey(e => e.number_of_check_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Line_of_check>()
                .Property(e => e.cost_for_buyer)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Line_of_check>()
                .HasMany(e => e.Stroka_check_and_postavka)
                .WithRequired(e => e.Line_of_check)
                .HasForeignKey(e => e.id_stroka_check)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Line_of_postavka>()
                .Property(e => e.own_cost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Line_of_postavka>()
                .HasMany(e => e.Stroka_check_and_postavka)
                .WithRequired(e => e.Line_of_postavka)
                .HasForeignKey(e => e.id_stroka_postavka)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Postavka>()
                .HasMany(e => e.Line_of_postavka)
                .WithRequired(e => e.Postavka)
                .HasForeignKey(e => e.number_of_postavka_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.now_cost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Line_of_check)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.code_of_product_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Line_of_postavka)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.code_of_product_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.login)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.password)
                .IsUnicode(false);
        }
    }
}
