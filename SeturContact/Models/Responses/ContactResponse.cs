namespace SeturContact.Models
{
    public class ContactResponse
    {
        public ResponseType Type { get; set; }

        public string? ErrorMessage { get; set; }

        public List<string> Errors { get; set; } = new List<string>();

        public List<Contact> Result { get; set; } = new List<Contact>();
    }
}