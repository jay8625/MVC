namespace CRUD_Practice.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserFName { get; set; }
        public string UserLName { get; set; }
        public int UserAge { get; set; }
        public string Gender { get; set; } 
        public string FavMovie { get; set; }
        public bool FavCharacter { get; set; }
        

    }    
    public class Filter
    {
        public int FilterAge { get; set; }
    }
}
