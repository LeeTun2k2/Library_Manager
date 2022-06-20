using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Windows;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Library_Manager.Repository.Models
{
    public partial class Reader
    {
        [Key]
        [Column("Reader_id")]
        [StringLength(8)]
        public string ReaderId { get; set; }
        [Required]
        [Column("Reader_name")]
        [StringLength(50)]
        public string ReaderName { get; set; }
        [Column(TypeName = "date")]
        public DateTime Birthday { get; set; }
        [Required]
        [StringLength(5)]
        public string Sex { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [Column("Phone_no")]
        [StringLength(11)]
        public string PhoneNo { get; set; }
        [StringLength(60)]
        public string Addr { get; set; }



        public static List<Reader> GetAll()
        {
            MoDbContext db = new MoDbContext();
            return db.Readers.ToList();
        }

        public void Add()
        {
            MoDbContext context = new MoDbContext();
            context.Readers.Add(this);
            context.SaveChanges();
        }

        public void Update()
        {
            MoDbContext context = new MoDbContext();
            context.Readers.Update(this);
            context.SaveChanges();
        }

        public static void Delete(string id)
        {
            MoDbContext context = new MoDbContext();
            Reader db = context.Readers.Where(p => p.ReaderId == id).FirstOrDefault();
                //  context.Students.Attach(db);
                context.Readers.Remove(db);
                context.SaveChanges();
        }

        public static List<Reader> Search(
            string Reader_id,
            string Reader_name,
            string Birthday,
            string Sex,
            string Email,
            string Phone_no,
            string Addr
            )
        {
            MoDbContext db = new MoDbContext();
            return db.Readers.Where(
                p =>
                (Reader_id != "") ? (p.ReaderId.Trim() == Reader_id) : (true) &&
                (Reader_name != "") ? (p.ReaderName.Trim() == Reader_name) : (true) &&
                (Birthday != "") ? (p.Birthday.ToShortDateString() == DateTime.Parse(Birthday.Trim()).ToShortDateString()) : (true) &&
                (Sex != "") ? (p.Sex.Trim() == Sex) : (true) &&
                (Email != "") ? (p.Email.Trim() == Email) : (true) &&
                (Phone_no != "") ? (p.PhoneNo.ToString().Trim() == Phone_no) : (true) &&
                (Addr != "") ? (p.Addr.ToString().Trim() == Addr) : (true)
                ).ToList();
        }
    }
}
