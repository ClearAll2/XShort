using System.Collections.Generic;

namespace XShort
{
    public class TimeSuggestions
    {
        private List<ListSuggestions> time;

        public TimeSuggestions()
        {
            Time = new List<ListSuggestions>();
            for (int i = 0; i < 24; i++)
            {
                Time.Add(new ListSuggestions());
            }
        }

        public List<ListSuggestions> Time { get => time; set => time = value; }
    }
}
