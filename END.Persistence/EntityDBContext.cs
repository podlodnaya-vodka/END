using END.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace END.Persistence
{
    public class EntityDBContext : DbContext
    {
        public EntityDBContext(DbContextOptions<EntityDBContext> options) : base(options) { }
        public DbSet<DocumentEntity> Documents { get; set; }
        public DbSet<DocumentLinkEntity> DocumentLinks { get; set; }
        public DbSet<DocumentTypeEntity> DocumentTypes { get; set; }
        public DbSet<AttributeTypeEntity> AttributeTypes { get; set; }
        public DbSet<AttributeValueEntity> AttributeValues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DocumentEntity>().HasData(
            new DocumentEntity
            {
                Id = new Guid("dc1f21fa-d389-4f70-b9a8-e24e253a40f3"),
                Name = "Инструкция закрывания двери",
                TypeId = new Guid("d0fb024e-7f8a-4fd9-9cf7-cf8f4259488f")
            },
            new DocumentEntity
            {
                Id = new Guid("76ddc547-f53f-42c4-8f65-a3beb462b571"),
                Name = "Указ рассказать анекдот",
                TypeId = new Guid("34daec0b-af9d-46ae-b19c-ac6cdfc962da")
            });

            // одного типа сущности нельзя вложить в другую
            modelBuilder.Entity<DocumentEntity>().HasMany(doc => doc.ParentDocuments).WithOne()
                        .HasForeignKey(link => link.ParentDocumentId).IsRequired();
            modelBuilder.Entity<DocumentEntity>().HasMany(doc => doc.ChildDocuments).WithOne()
                        .HasForeignKey(link => link.ChildDocumentId).IsRequired();

            modelBuilder.Entity<DocumentLinkEntity>().HasData(
            new DocumentLinkEntity
            {
                Id = new Guid("0fc55202-6098-419c-9fd3-1bae8d734089"),
                ParentDocumentId = new Guid("dc1f21fa-d389-4f70-b9a8-e24e253a40f3"),
                ChildDocumentId = new Guid("76ddc547-f53f-42c4-8f65-a3beb462b571")
            });

            modelBuilder.Entity<DocumentTypeEntity>().HasData(
            new DocumentTypeEntity
            {
                Id = new Guid("d0fb024e-7f8a-4fd9-9cf7-cf8f4259488f"),
                Name = "Инструкия"
            },
            new DocumentTypeEntity
            {
                Id = new Guid("34daec0b-af9d-46ae-b19c-ac6cdfc962da"),
                Name = "Указ"
            });

            modelBuilder.Entity<AttributeTypeEntity>().HasData(
            new AttributeTypeEntity
            {
                Id = new Guid("04215f96-7f97-4626-b6b1-0c60a466dd79"),
                TypeId = new Guid("d0fb024e-7f8a-4fd9-9cf7-cf8f4259488f"),
                Name = "Статус",
                DataType = "string"
            },
            new AttributeTypeEntity
            {
                Id = new Guid("b95e63a2-4119-45ca-bb4e-3ff6d2f1b031"),
                TypeId = new Guid("34daec0b-af9d-46ae-b19c-ac6cdfc962da"),
                Name = "Описание",
                DataType = "string"
            },
            new AttributeTypeEntity
            {
                Id = new Guid("cd8c3655-d190-481f-94af-4abba625dd15"),
                TypeId = new Guid("34daec0b-af9d-46ae-b19c-ac6cdfc962da"),
                Name = "Автор",
                DataType = "string"
            },
            new AttributeTypeEntity
            {
                Id = new Guid("7ef34cb3-5f61-4256-b8ae-b8df3abc9435"),
                TypeId = new Guid("34daec0b-af9d-46ae-b19c-ac6cdfc962da"),
                Name = "Номер",
                DataType = "int"
            });

            modelBuilder.Entity<AttributeValueEntity>().HasData(
            new AttributeValueEntity
            {
                Id = Guid.NewGuid(),
                DocumentId = new Guid("dc1f21fa-d389-4f70-b9a8-e24e253a40f3"),
                AttributeId = new Guid("7ef34cb3-5f61-4256-b8ae-b8df3abc9435"),
                Value = "1488"
            },
            new AttributeValueEntity
            {
                Id = Guid.NewGuid(),
                DocumentId = new Guid("dc1f21fa-d389-4f70-b9a8-e24e253a40f3"),
                AttributeId = new Guid("b95e63a2-4119-45ca-bb4e-3ff6d2f1b031"),
                Value = "Ручку дергать туда сюда"
            },
            new AttributeValueEntity
            {
                Id = Guid.NewGuid(),
                DocumentId = new Guid("dc1f21fa-d389-4f70-b9a8-e24e253a40f3"),
                AttributeId = new Guid("cd8c3655-d190-481f-94af-4abba625dd15"),
                Value = "Начальник двери"
            },
            new AttributeValueEntity
            {
                Id = Guid.NewGuid(),
                DocumentId = new Guid("76ddc547-f53f-42c4-8f65-a3beb462b571"),
                AttributeId = new Guid("04215f96-7f97-4626-b6b1-0c60a466dd79"),
                Value = "Действующий"
            },
            new AttributeValueEntity
            {
                Id = Guid.NewGuid(),
                DocumentId = new Guid("76ddc547-f53f-42c4-8f65-a3beb462b571"),
                AttributeId = new Guid("b95e63a2-4119-45ca-bb4e-3ff6d2f1b031"),
                Value = "Старый мельник"
            },
            new AttributeValueEntity
            {
                Id = Guid.NewGuid(),
                DocumentId = new Guid("76ddc547-f53f-42c4-8f65-a3beb462b571"),
                AttributeId = new Guid("cd8c3655-d190-481f-94af-4abba625dd15"),
                Value = "Начальник всего"
            });
        }
    }
}
