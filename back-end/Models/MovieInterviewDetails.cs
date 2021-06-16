namespace Models
{
    public class MovieInterviewDetails
    {
        public MovieInterviewDetails()
        {
        }

        public MovieInterviewDetails(string source, string url, string title, string description, string uploader)
        {
            Source = source;
            Url = url;
            TitleInterview = title;
            DescriptionInterview = description;
            UploaderInterview = uploader;
        }

        public MovieInterviewDetails(int id, string source, string url, string title, string description, string uploader)
        {
            Id = id;
            Source = source;
            Url = url;
            TitleInterview = title;
            DescriptionInterview = description;
            UploaderInterview = uploader;
        }

        public int Id { get; set; }
        public string Source { get; set; }
        public string Url { get; set; }
        public string TitleInterview { get; set; }
        public string DescriptionInterview { get; set; }
        public string UploaderInterview { get; set; }
    }
}
