namespace CRUD_API_with_Database.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }= string.Empty;
        public string Email { get; set; } = string.Empty;
        public Double Password { get; set; }
       
    }
}
