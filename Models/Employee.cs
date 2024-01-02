using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bai1.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age {  get; set; }
        public bool Gender { get; set; }
        public int CompanyID {  get; set; }
        [ForeignKey("CompanyID")]
        public Company Company { get; set; }
    }
}
