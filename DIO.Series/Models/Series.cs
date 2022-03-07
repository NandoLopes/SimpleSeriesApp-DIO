namespace DIO.Series
{
    public class Series : BaseModel
    {
        // Attributes
        private GenreEnum Genre { get; set; }
        private string Title { get; set; }
        private string Synopsis { get; set; }
        private int Year { get; set; }
        private bool Deleted { get; set; }

        public Series(int Id, GenreEnum Genre, string Title, string Synopsis, int Year)
        {
            this.Id = Id;
            this.Genre = Genre;
            this.Title = Title;
            this.Synopsis = Synopsis;
            this.Year = Year;
            this.Deleted = false;
        }

        public override string ToString()
        {
            string returnString = Environment.NewLine;
            returnString += "Title: " + this.Title + Environment.NewLine;
            returnString += "Genre: " + this.Genre + Environment.NewLine;
            returnString += "Synopsis: " + this.Synopsis + Environment.NewLine;
            returnString += "First on air: " + this.Year + Environment.NewLine;
            if(Deleted == true)
                returnString += "[DELETED]" + Environment.NewLine;

            return returnString;
        }

        public string getTitle(){
            return Title;
        }

        public int getId(){
            return Id;
        }

        public int getYear(){
            return Year;
        }

        public void changeDeletion(bool state){
            this.Deleted = state;
        }

        public bool returnDeletionStatus(){
            return this.Deleted;
        }
    }
}