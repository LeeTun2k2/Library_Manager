using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Library_Manager.Repository.Models
{
    public partial class Author
    {
        [Key]
        [Column("Author_id")]
        [StringLength(8)]
        public string AuthorId { get; set; }
        [Required]
        [Column("Author_name")]
        [StringLength(40)]
        public string AuthorName { get; set; }




        public static List<Author> GetAll()
        {
            MoDbContext db = new MoDbContext();
            return db.Authors.ToList();
        }

        public void Add()
        {
            MoDbContext context = new MoDbContext();
            context.Authors.Add(this);
            context.SaveChanges();
        }

        public void Update()
        {
            MoDbContext context = new MoDbContext();
            context.Authors.Update(this);
            context.SaveChanges();
        }

        public static void Delete(string id)
        {
            MoDbContext context = new MoDbContext();
            Author db = context.Authors.Where(p => p.AuthorId == id).FirstOrDefault();
                //  context.Students.Attach(db);
                context.Authors.Remove(db);
                context.SaveChanges();
        }

        public static List<Author> Search(
            string Author_id,
            string Author_name
            )
        {
            MoDbContext db = new MoDbContext();
            return db.Authors.Where(
                p =>
                (Author_id != "") ? (p.AuthorId.Trim() == Author_id) : (true) &&
                (Author_name != "") ? (p.AuthorName.Trim() == Author_name) : (true)
                ).ToList();
        }
    }
}
