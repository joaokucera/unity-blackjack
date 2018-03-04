using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class CardDisplay : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Sprite _backCardSprite;

    public Card Card { get; private set; }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _backCardSprite = _spriteRenderer.sprite;
    }

    public void Reset()
    {
        _spriteRenderer.sprite = _backCardSprite;

        Card = null;
    }

    public void SetCard(Card card)
    {
        Card = card;
    }

    public void FaceUp()
    {
        if (Card == null) {
            throw new Exception("The card was not defined!");
        }

        if (_spriteRenderer.sprite.GetInstanceID() == _backCardSprite.GetInstanceID()) {
            _spriteRenderer.sprite = Card.Sprite;
        }
    }
}