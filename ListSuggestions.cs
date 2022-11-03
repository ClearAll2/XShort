using System.Collections.Generic;

namespace XShort
{

    public class ListSuggestions
    {
        private List<Suggestions> list;

        public ListSuggestions()
        {
            List = new List<Suggestions>();
        }

        internal List<Suggestions> List { get => list; set => list = value; }
    }
}
