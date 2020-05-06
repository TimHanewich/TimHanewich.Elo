using System;

namespace TimHanewich.Elo
{
    public class EloResult
        {
            public int Player1OldRating { get; set; }
            public int Player2OldRating { get; set; }
            public int Player1NewRating { get; set; }
            public int Player2NewRating { get; set; }
        }
}