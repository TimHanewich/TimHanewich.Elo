Place the following statement at the top of your code file or namespace to import the necessary components:
~~~
using TimHanewich.Elo;
~~~

### Calculating new ELO ratings after a match
~~~
EloCalculator ec = new EloCalculator();
EloResult result = ec.CalculateNewElo(2200, 1700, GameResult.Player2Won, 500);
~~~
Parameters for the `CalculateNewElo`
1) Player 1 current ELO rating
2) Plaer 2 current ELO Rating
3) `GameResult`, the result of the matchup.  Either Player 1 wins, Player 2 wins, or there is a draw.
4) (optional) The K value used in the ELO calculation.  K defines how heavily this match should influence ratings.  This value is 50 by default.

The `EloResult` class contains the old and new ELO rating values based upon the results of the match up.
