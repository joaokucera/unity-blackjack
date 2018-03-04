using UnityEngine;
using Random = System.Random;

public class Deck
{
    private Random _random;
    private Card[] _cards;

    public Deck()
    {
        _random = new Random();
        _cards = Resources.LoadAll<Card>("Cards");
    }

    public Card[] GetCards()
    {
        ShuffleCards();

        return _cards;
    }

    /// <summary>
    /// Fisher–Yates shuffle | O(n).
    /// </summary>
    private void ShuffleCards()
    {
        for (int i = _cards.Length - 1; i > 0; i--) {
            Card currentCard = _cards[i];
            int otherCard = _random.Next(i + 1);

            _cards[i] = _cards[otherCard];
            _cards[otherCard] = currentCard;
        }
    }
}
