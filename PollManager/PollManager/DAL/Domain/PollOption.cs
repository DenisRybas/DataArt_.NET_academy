namespace PollManager.Models
{
    public class PollOption
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public int NumberOfVotes { get; set; }

        public PollOption(int id, string text, int numberOfVotes)
        {
            Id = id;
            Text = text;
            NumberOfVotes = numberOfVotes;
        }

        public override bool Equals(object? obj)
        {
            if ((obj == null) || GetType() != obj.GetType())
            {
                return false;
            }
            else
            {
                var o = (PollOption) obj;
                return o.Text == Text || o.Id == Id;
            }
        }
    }
}