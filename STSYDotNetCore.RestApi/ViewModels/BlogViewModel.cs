namespace STSYDotNetCore.RestApi.ViewModels
{
    public class BlogViewModel
    {
        public int Id { get; set; } // int, bool ka allow null pyy syr m lo, default value ty shi lo

        public string? Title { get; set; }

        public string? Author { get; set; }

        public string? Content { get; set; }

        public bool DeleteFlag { get; set; }
    }
}
