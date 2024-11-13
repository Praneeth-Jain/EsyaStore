namespace EsyaStore.Model
{
    public class ReviewViewModel
    {
        public int Stars { get; set; }

        public string ReviewDescription { get; set; }

        public DateTime ReviewDate { get; set; } = DateTime.Now;

        public string Username { get; set; }

        public string UserEmail { get; set; }
    }
}
