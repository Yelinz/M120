using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M120Projekt.Data
{
    public class Todos
    {
        #region Databaselayer
        [Key]
        public Int64 TodoId { get; set; }
        [Required]
        public String Description { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public Boolean Done { get; set; }
        public String Colour { get; set; }
        public Int32 Priority { get; set; }
        #endregion
        #region Applicationlayer
        public Todos() { }

        [NotMapped]
        public String PriorityName
        {
            get
            {
                switch (Priority)
                {
                    case 1:
                        return "Hoch";
                    case 2:
                        return "Mittel";
                    case 3:
                        return "Tief";
                    default:
                        return "";
                }
            }
        }

        [NotMapped]
        public String FormattedExpiryDate
        {
            get
            {
                return ExpiryDate.HasValue ? ExpiryDate?.ToString("dd.MM.yyyy") : "";
            }
        }

        public static List<Todos> ReadAll()
        {
            using (var db = new Context())
            {
                return (from record in db.Todos select record).ToList();
            }
        }
        public static Todos ReadId(Int64 id)
        {
            using (var db = new Context())
            {
                return (from record in db.Todos where record.TodoId == id select record).FirstOrDefault();
            }
        }
        public static List<Todos> ReadSameAttribute(String search)
        {
            using (var db = new Context())
            {
                return (from record in db.Todos where record.Description == search select record).ToList();
            }
        }
        public static List<Todos> ReadAttributeLike(String search)
        {
            using (var db = new Context())
            {
                return (from record in db.Todos where record.Description.Contains(search) select record).ToList();
            }
        }
        public Int64 Create()
        {
            if (this.Description == null || this.Description == "") this.Description = "leer";
            if (this.ExpiryDate == null) this.ExpiryDate = DateTime.MinValue;
            using (var db = new Context())
            {
                db.Todos.Add(this);
                db.SaveChanges();
                return this.TodoId;
            }
        }
        public Int64 Update()
        {
            using (var db = new Context())
            {
                db.Entry(this).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return this.TodoId;
            }
        }
        public void Delete()
        {
            using (var db = new Context())
            {
                db.Entry(this).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
        public override string ToString()
        {
            return TodoId.ToString(); // Für bessere Coded UI Test Erkennung
        }
        #endregion
    }
}
