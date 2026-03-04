using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Obuv.Model;

namespace Obuv.Context;

public partial class DataBase : DbContext
{
    public DataBase()
    {
    }

    public DataBase(DbContextOptions<DataBase> options)
        : base(options)
    {
    }

    public virtual DbSet<Заказы> Заказыs { get; set; }

    public virtual DbSet<Пользователи> Пользователиs { get; set; }

    public virtual DbSet<ПунктыВыдачи> ПунктыВыдачиs { get; set; }

    public virtual DbSet<СодержимоеЗаказа> СодержимоеЗаказаs { get; set; }

    public virtual DbSet<Товары> Товарыs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=Тест1;User Id=sa;Password=SQLServer123;TrustServerCertificate=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Заказы>(entity =>
        {
            entity.HasKey(e => e.Номер);

            entity.ToTable("Заказы");

            entity.Property(e => e.Дата_доставки).HasColumnName("Дата доставки");
            entity.Property(e => e.Дата_заказа).HasColumnName("Дата заказа");
            entity.Property(e => e.КодДляПолучения)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Статус)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");

            entity.HasOne(d => d.КодПользователяNavigation).WithMany(p => p.Заказыs)
                .HasForeignKey(d => d.КодПользователя)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Заказы_Пользователи");

            entity.HasOne(d => d.КодПунктаВыдачиNavigation).WithMany(p => p.Заказыs)
                .HasForeignKey(d => d.КодПунктаВыдачи)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Заказы_ПунктыВыдачи");
        });

        modelBuilder.Entity<Пользователи>(entity =>
        {
            entity.HasKey(e => e.Код);

            entity.ToTable("Пользователи");

            entity.Property(e => e.Логин)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Пароль)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Роль_сотрудника)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("Роль сотрудника");
            entity.Property(e => e.ФИО)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<ПунктыВыдачи>(entity =>
        {
            entity.HasKey(e => e.Код);

            entity.ToTable("ПунктыВыдачи");

            entity.Property(e => e.Адрес)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<СодержимоеЗаказа>(entity =>
        {
            entity.HasKey(e => e.Код).HasName("PK_СодержимоеЗаказа.xlsx");

            entity.ToTable("СодержимоеЗаказа");

            entity.Property(e => e.Артикул_заказа)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("Артикул заказа");

            entity.HasOne(d => d.Артикул_заказаNavigation).WithMany(p => p.СодержимоеЗаказаs)
                .HasForeignKey(d => d.Артикул_заказа)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_СодержимоеЗаказа.xlsx_Товары");

            entity.HasOne(d => d.НомерЗаказаNavigation).WithMany(p => p.СодержимоеЗаказаs)
                .HasForeignKey(d => d.НомерЗаказа)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_СодержимоеЗаказа.xlsx_Заказы");
        });

        modelBuilder.Entity<Товары>(entity =>
        {
            entity.HasKey(e => e.Артикул);

            entity.ToTable("Товары");

            entity.Property(e => e.Артикул)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.ЕдиницаИзмерения)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Категория)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Наименование)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Описание)
                .HasMaxLength(500)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Поставщик)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Производитель)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Фото)
                .HasMaxLength(500)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Цена).HasColumnType("decimal(10, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
