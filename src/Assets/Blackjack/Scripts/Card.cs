using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    [SerializeField]
    private Sprite _sprite;
    public Sprite Sprite {
        get {
            return _sprite;
        }
    }

    [SerializeField]
    [Range(1, 11)]
    private int _value;
    public int Value {
        get {
            return _value;
        }
    }

    [SerializeField]
    private bool _isAce;
    public bool IsAce {
        get {
            return _isAce;
        }
    }
}