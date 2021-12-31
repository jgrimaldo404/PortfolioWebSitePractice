namespace WebApplicationMVC.Models
{
    // contains properties 
    /*
     * Joke Object 
     */
    public class Joke
    {
        //shortcut prop tab 
        // C# this is a getter and setter 
        public int Id { get; set; }

        public string JokeQuestion { get; set; }

        public string JokeAnswer { get; set; }


        //ctor tab
        public Joke()
        {

        }


    }
}
