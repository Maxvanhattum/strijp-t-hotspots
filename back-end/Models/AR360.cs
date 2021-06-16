namespace Models
{
    public class AR360
    {
        public AR360()
        {
        }

        public AR360(string sourcePath)
        {
            SourcePath = sourcePath;
        }

        public AR360(int id, string sourcePath)
        {
            Id = id;
            SourcePath = sourcePath;
        }

        public int Id { get; set; }
        public string SourcePath { get; set; }
    }
}
