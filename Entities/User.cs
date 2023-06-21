using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace core7_postgre_angular14.Entities
{
    [Table("users")]
    public class User {

        [Key]
        [Column("id")]
        public int Id {get; set;}

        [Column("lastname", TypeName ="varchar")]
        public string LastName {get; set;}

        [Column("firstname", TypeName ="varchar")]
        public string FirstName {get; set;}

        [Column("username", TypeName ="varchar")]
        public string UserName {get; set;}

        [Column("password", TypeName ="varchar")]
        public string Password {get; set;}

        [Column("email", TypeName ="varchar")]
        public string Email { get; set; }

        [Column("mobile", TypeName ="varchar")]
        public string Mobile { get; set; }

        [Column("roles", TypeName ="varchar")]        
        public string Roles { get; set; }

        [Column("isactivated")]
        public int Isactivated {get; set;}

        [Column("isblocked")]
        public int Isblocked {get; set;}

        [Column("mailtoken")]
        public int Mailtoken {get; set;}

        [Column("qrcodeurl", TypeName ="varchar")]
        public string Qrcodeurl {get; set;}

        [Column("profilepic", TypeName ="varchar")]
        public string Profilepic {get; set;}

        [Column("secretkey")]
        public string Secretkey  {get; set;}

        [Column("created_at", TypeName ="timestamp")]
        public DateTime Created_at { get; set; }

        [Column("updated_at", TypeName ="timestamp")]
        public DateTime Updated_at { get; set; }

    }
}