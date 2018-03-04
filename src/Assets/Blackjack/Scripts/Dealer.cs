using System.Collections.Generic;
using UnityEngine;

public class Dealer : MonoBehaviour
{
    private Deck _deck;
    private Queue<Card> _cardsQueue;

    [SerializeField]
    private PoolingSystem _poolingSystem;

    private void Awake()
    {
        _deck = new Deck();
    }

    public void Reset(params Player[] players)
    {
        for (int i = 0; i < players.Length; i++) {
            players[i].Reset(_poolingSystem);
        }

        _cardsQueue = new Queue<Card>();

        Card[] cards = _deck.GetCards();

        for (int i = 0; i < cards.Length; i++) {
            _cardsQueue.Enqueue(cards[i]);
        }
    }

    public void Deal(Player player, bool showFirstCard = true)
    {
        for (int i = 0; i < 2; i++) {
            GiveCard(player, showFirstCard);
            //Apply 'false' for the first card only.
            showFirstCard = true;
        }
    }

    public void GiveCard(Player player, bool showCard = true)
    {
        Card card = GetCard();

        CardDisplay display = GetDisplay(player.Transform);
        display.SetCard(card);

        player.Hand.AddCard(display);

        if (showCard) {
            display.FaceUp();
        }
    }

    private Card GetCard()
    {
        return _cardsQueue.Dequeue();
    }

    private CardDisplay GetDisplay(Transform parent)
    {
        Vector3 position = parent.position;
        position.x += parent.childCount * 1.5f;

        CardDisplay display = _poolingSystem.Dequeue(parent, position, parent.rotation);

        return display;
    }
}