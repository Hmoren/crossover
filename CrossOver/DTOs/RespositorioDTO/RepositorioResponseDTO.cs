namespace CrossOver.DTOs.RespositorioDTO
{
    public class RepositorioResponseDTO
    {
        public int id { get; set; }
        public string full_name { get; set; }        
        public string html_url { get; set; }
        public string description { get; set; }
        public string language { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string visibility { get; set; }
    }
}
