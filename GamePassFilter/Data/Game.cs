using System;

namespace GamePassFilter.Data
{
    public class Game
    {
        public string siglId { get; set; }

        public string title { get; set; }

        public string description { get; set; }

        public string requiresShuffling { get; set; }

        public string imageUrl { get; set; }

        public string id { get; set; }

        public int score { get; set; }
    }
}
