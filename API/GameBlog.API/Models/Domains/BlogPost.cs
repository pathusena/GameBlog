namespace GameBlog.API.Models.Domains
{
    public class BlogPost
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string DescriptionShort { get; set; }
        public string Content { get; set; }
        public string UrlHandle { get; set; }
        public string FeaturedImageUrl { get; set; }
        public DateTime PublishedDate { get; set; }
        public bool IsVisible { get; set; }
    }
}
