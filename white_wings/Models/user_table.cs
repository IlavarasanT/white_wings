using System.ComponentModel.DataAnnotations;

namespace white_wings.Models
{
    public class user_table
    {
        [Key]
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        //public List<user_table> user_Tables { get; set; }
    }
    public class list<user_table>
    {

        [Key]
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }    

}
