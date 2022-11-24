using System;

namespace XShort
{
    class Suggestions
    {
        private string loc;
        private int amount;
        private DateTime lasttime;

        public string Loc { get => loc; set => loc = value; }
        public int Amount { get => amount; set => amount = value; }
        public DateTime Lasttime { get => lasttime; set => lasttime = value; }

        public Suggestions(string _loc, int _amount, DateTime _lastime)
        {
            Loc = _loc;
            Amount = _amount;
            Lasttime = _lastime;
        }
    }
}
