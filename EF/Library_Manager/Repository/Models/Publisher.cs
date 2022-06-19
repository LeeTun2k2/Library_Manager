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
    public partial class Publisher
    {
        [Key]
        [Column("Publisher_id")]
        [StringLength(8)]
        public string PublisherId { get; set; }
        [Required]
        [Column("Publisher_name")]
        [StringLength(40)]
        public string PublisherName { get; set; }
        [StringLength(40)]
        public string Email { get; set; }
        [Required]
        [Column("Phone_no")]
        [StringLength(11)]
        public string PhoneNo { get; set; }
        [StringLength(60)]
        public string Addr { get; set; }

        public static List<Publisher> GetAll()
        {
            MoDbContext db = new MoDbContext();
            return db.Publishers.ToList();
        }

        public void Add()
        {
            MoDbContext context = new MoDbContext();
            context.Publishers.Add(this);
            context.SaveChanges();
        }

        public void Update()
        {
            MoDbContext context = new MoDbContext();
            context.Publishers.Update(this);
            context.SaveChanges();
        }

        public static void Delete(string id)
        {
            MoDbContext context = new MoDbContext();
            Publisher db = context.Publishers.Where(p => p.PublisherId == id).FirstOrDefault();
            if (db != null)
            {
                //  context.Students.Attach(db);
                context.Publishers.Remove(db);
                context.SaveChanges();
            }
            else
                MessageBox.Show("Không tồn tại ID");
        }

        public static List<Publisher> Search(
            string Publisher_id,
            string Publisher_name,
            string Email,
            string Phone_no,
            string Addr
            )
        {
            MoDbContext db = new MoDbContext();
            return db.Publishers.Where(
                p =>
                (Publisher_id != "") ? (p.PublisherId.Trim() == Publisher_id) : (true) &&
                (Publisher_name != "") ? (p.PublisherName.Trim() == Publisher_name) : (true) &&
                (Email != "") ? (p.Email.Trim() == Email) : (true) &&
                (Phone_no != "") ? (p.PhoneNo.Trim() == Phone_no) : (true) &&
                (Addr != "") ? (p.Addr.Trim() == Addr) : (true)
                ).ToList();
        }
    }
}
