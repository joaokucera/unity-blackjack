using UnityEngine;

public class ComputerPlayer : Player
{
    public WaitForSeconds TurnWaitForSeconds { get; private set; }

    [SerializeField]
    private float _turnTime;

    private void Start()
    {
        TurnWaitForSeconds = new WaitForSeconds(_turnTime);
    }

    /// <summary>
    /// In order to have a better readable code, I divided it into statements following the AI logic.
    /// </summary>
    public void UpdateBehaviour(Hand humanHand)
    {
        int computerTotalValue = Hand.TotalValue;

        //if the AI's hand contains no Ace, or the AI's Aces count as 1 point.
        if (Hand.AcesCount == 0 || Hand.AcesTotalValue < 11) {
            //if the human player has an Ace or a card with 7 or more points, take a card if the AI has less than 17 points.
            if ((humanHand.AcesCount == 1 || humanHand.ContainsEqualOrHigher(7)) && computerTotalValue < 17) {
                IsHitting = true;
            }
            //if the human player has a 4, 5, or 6, take a card if the AI has less than 12 points.
            else if (humanHand.ContainsEqual(4, 5, 6) && computerTotalValue < 12) {
                IsHitting = true;
            }
            //if the human player has a 2 or 3, take a card if the AI has less than 13 points.
            else if (humanHand.ContainsEqual(2, 3) && computerTotalValue < 13) {
                IsHitting = true;
            }
            else {
                IsHitting = false;
            }
        }
        //if the AI's hand contains one Ace that is valued at 11 points. (NOT only one Ace | at least there is 1 Ace valued at 11 points).
        else {
            //don't take a card if the AI already has 19 or more points.
            if (computerTotalValue >= 19) {
                IsHitting = false;
            }
            //don't take a card if the AI has 18 points and 3 or more cards,...
            else if (computerTotalValue == 18 && Hand.Count >= 3) {
                //...unless the opponent has an Ace or a card with 9 or more points.
                if (humanHand.AcesCount > 0 || humanHand.ContainsEqualOrHigher(9)) {
                    IsHitting = true;
                }
                else {
                    IsHitting = false;
                }
            }
            else {
                IsHitting = true;
            }
        }
    }
}