using System;

namespace TimHanewich.Elo
{
    public class EloCalculator
        {
            private const int K = 50;

            public EloResult CalculateNewElo(int player1rating, int player2rating, GameResult result)
            {
                EloResult ReturnInstance = new EloResult();
                ReturnInstance.Player1OldRating = player1rating;
                ReturnInstance.Player2OldRating = player2rating;


                //Calculate probability of winning
                float WhiteProbability = GetPlayer1ProbabilityOfWinning(player1rating, player2rating);
                float BlackProbability = 1 - WhiteProbability;


                float WhiteResult = 0;
                float BlackResult = 0;
                if (result == GameResult.Player1Won)
                {
                    WhiteResult = 1;
                }
                else if (result == GameResult.Player2Won)
                {
                    BlackResult = 1;
                }
                else if (result == GameResult.Draw)
                {
                    WhiteResult = 0.5f;
                    BlackResult = 0.5f;
                }


                float p1newrating = player1rating + (K * (WhiteResult - WhiteProbability));
                float p2newrating = player2rating + (K * (BlackResult - BlackProbability));

                ReturnInstance.Player1NewRating = System.Convert.ToInt32(p1newrating);
                ReturnInstance.Player2NewRating = System.Convert.ToInt32(p2newrating);

                return ReturnInstance;
            }

            private float GetPlayer1ProbabilityOfWinning(int p1elo, int p2elo)
            {
                float diff = p2elo - p1elo;
                diff = diff / 400;
                float denominator = 1 + (float)Math.Pow(10, diff);
                float expectedwinprob = 1 / denominator;
                return expectedwinprob;
            }
        }
}