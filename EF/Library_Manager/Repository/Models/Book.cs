using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows;

#nullable disable

namespace Library_Manager.Repository.Models
{
    public partial class Book
    {
        [Key]
        [Column("Book_id")]
        [StringLength(8)]
        public string BookId { get; set; }
        [Required]
        [StringLength(60)]
        public string Title { get; set; }
        [Required]
        [StringLength(20)]
        public string Category { get; set; }
        [Column("Author_id")]
        [StringLength(8)]
        public string AuthorId { get; set; }
        [Column("Publisher_id")]
        [StringLength(8)]
        public string PublisherId { get; set; }
        public int YearOfPublication { get; set; }
        [Required]
        [StringLength(7)]
        public string Price { get; set; }
        public int Quantity { get; set; }


        public static List<Book> GetAll()
        {
            MoDbContext db = new MoDbContext();
            return db.Books.ToList();
        }

        public void Add()
        {
            MoDbContext context = new MoDbContext();
            context.Books.Add(this);
            context.SaveChanges();
        }

        public void Update()
        {
            MoDbContext context = new MoDbContext();
            context.Books.Update(this);
            context.SaveChanges();
        }

        public static void Delete(string id)
        {
            MoDbContext context = new MoDbContext();
            Book db = context.Books.Where(p => p.BookId == id).FirstOrDefault();

                //  context.Students.Attach(db);
                context.Books.Remove(db);
                context.SaveChanges();
        }

        

        public static List<Book> Search(
            string BookID, 
            string Title,
            string Category,
            string AuthorId,
            string PublisherId,
            string YearOfPublication,
            string Price,
            string Quantity)
        {
            MoDbContext db = new MoDbContext();
            return db.Books.Where(
                p => 
                (BookID != "")?(p.BookId.Trim() == BookID):(true) &&
                (Title != "") ? (p.Title.Trim() == Title) : (true) &&
                (Category != "") ? (p.Category.Trim() == Category) : (true) &&
                (AuthorId != "") ? (p.AuthorId.Trim() == AuthorId) : (true) &&
                (PublisherId != "") ? (p.PublisherId.Trim() == PublisherId) : (true) &&
                (YearOfPublication != "") ? (p.YearOfPublication.ToString().Trim() == YearOfPublication) : (true) &&
                (Price != "") ? (p.Price.ToString().Trim() == Price) : (true) &&
                (Quantity != "") ? (p.Quantity.ToString().Trim() == Title) : (true)
                ).ToList();
        }
    }
}
