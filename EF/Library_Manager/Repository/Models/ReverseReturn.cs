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
    [Table("Reverse_Return")]
    public partial class ReverseReturn
    {
        [Key]
        [Column("Reg_id")]
        [StringLength(8)]
        public string RegId { get; set; }
        [Column("Reader_id")]
        [StringLength(8)]
        public string ReaderId { get; set; }
        [Column("Book_id")]
        [StringLength(8)]
        public string BookId { get; set; }
        [Column(TypeName = "date")]
        public DateTime ReserveDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime DueDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime ReturnDate { get; set; }
        [Column("ReserveStaff_id")]
        [StringLength(8)]
        public string ReserveStaffId { get; set; }
        [Column("ReturnStaff_id")]
        [StringLength(8)]
        public string ReturnStaffId { get; set; }




        public static List<ReverseReturn> GetAll()
        {
            MoDbContext db = new MoDbContext();
            return db.ReverseReturns.ToList();
        }

        public void Add()
        {
            MoDbContext context = new MoDbContext();
            context.ReverseReturns.Add(this);
            context.SaveChanges();
        }

        public void Update()
        {
            MoDbContext context = new MoDbContext();
            context.ReverseReturns.Update(this);
            context.SaveChanges();
        }

        public static void Delete(string id)
        {
            MoDbContext context = new MoDbContext();
            ReverseReturn db = context.ReverseReturns.Where(p => p.RegId == id).FirstOrDefault();
            if (db != null)
            {
                //  context.Students.Attach(db);
                context.ReverseReturns.Remove(db);
                context.SaveChanges();
            }
            else
                MessageBox.Show("Không tồn tại ID");
        }

        public static List<ReverseReturn> Search(
            string Reg_id,
            string Reader_id,
            string Book_id,
            string ReserveDate,
            string DueDate,
            string ReturnDate,
            string ReserveStaff_id,
            string ReturnStaff_id)
        {
            MoDbContext db = new MoDbContext();
            return db.ReverseReturns.Where(
                p =>
                (Reg_id != "") ? (p.RegId.Trim() == Reg_id) : (true) &&
                (Reader_id != "") ? (p.ReaderId.Trim() == Reader_id) : (true) &&
                (Book_id != "") ? (p.BookId.Trim() == Book_id) : (true) &&
                (ReserveDate != "") ? (p.ReserveDate.ToShortDateString() == DateTime.Parse(ReserveDate).ToShortDateString()) : (true) &&
                (DueDate != "") ? (p.DueDate.ToShortDateString() == DateTime.Parse(DueDate).ToShortDateString()) : (true) &&
                (ReturnDate != "") ? (p.ReturnDate.ToShortDateString() == DateTime.Parse(ReturnDate).ToShortDateString()) : (true) &&
                (ReserveStaff_id != "") ? (p.ReserveStaffId.ToString().Trim() == ReserveStaff_id) : (true) &&
                (ReturnStaff_id != "") ? (p.ReturnStaffId.ToString().Trim() == ReturnStaff_id) : (true)
                ).ToList();
        }
    }
}
