using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;
namespace WpfApp5_2ADO
{
    [Table(Name ="UsersData")]
   public class UserEmail
    {
        [Column (IsPrimaryKey =true,IsDbGenerated =true)]
        public int Id { get; set; }
        [Column (Name ="name")]
        public string Name { get; set; }
        [Column(Name ="email")]
        public string Email { get; set; }
    }
}
