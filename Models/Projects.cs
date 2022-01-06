namespace WebApplicationMVC.Models
{
    public class Projects
    {

        public int Id { get; set; }

        public string ProjectName { get; set; }

        public string Description { get; set; }

        public string URL { get; set; }

        //Needs to be emtpy since it will be used by other pieces of code 
        public Projects()
        {

        }


    }
}
