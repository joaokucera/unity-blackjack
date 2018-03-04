using System.Collections.Generic;
using System.Linq;

public class Hand
{
    private List<CardDisplay> _displays;

    private IEnumerable<Card> Cards {
        get {
            return _displays.Select(s => s.Card);
        }
    }

    private IEnumerable<Card> AcesCards {
        get {
            return _displays.Select(s => s.Card).Where(w => w.IsAce);
        }
    }

    public int Count {
        get {
            return _displays.Count;
        }
    }

    public int AcesCount {
        get {
            return AcesCards.Count();
        }
    }

    public int TotalValue {
        get {
            IEnumerable<Card> cards = Cards;

            int totalValue = cards.Sum(s => s.Value);
            int acesCount = cards.Count(c => c.IsAce);

            while (acesCount-- > 0 && totalValue > 21) {
                totalValue -= 10;
            }

            return totalValue;
        }
    }

    public int AcesTotalValue {
        get {
            IEnumerable<Card> cards = Cards;
            int totalValue = cards.Sum(s => s.Value);

            IEnumerable<Card> acesCards = AcesCards;
            int acesTotalValue = acesCards.Sum(s => s.Value);
            int acesCount = acesCards.Count();

            while (acesCount-- > 0 && totalValue > 21) {
                totalValue -= 10;
                acesTotalValue -= 10;
            }

            return acesTotalValue;
        }
    }

    public bool ContainsEqual(params int[] cardValues)
    {
        int count = Cards.Count(c => cardValues.Contains(c.Value));

        return count > 0;
    }

    public bool ContainsEqualOrHigher(int cardValue)
    {
        int count = Cards.Count(c => c.Value >= cardValue);

        return count > 0;
    }

    public void Reset(PoolingSystem poolingSystem)
    {
        if (_displays != null) {
            for (int i = 0; i < _displays.Count; i++) {
                _displays[i].Reset();

                poolingSystem.Enqueue(_displays[i]);
            }
        }

        _displays = new List<CardDisplay>();
    }

    public void AddCard(CardDisplay display)
    {
        _displays.Add(display);
    }

    public void Show()
    {
        for (int i = 0; i < _displays.Count; i++) {
            _displays[i].FaceUp();
        }
    }

    public override string ToString()
    {
        return string.Format("[Hand: Count={0}, AcesCount={1}, TotalValue={2}, AcesTotalValue={3}]", Count, AcesCount, TotalValue, AcesTotalValue);
    }
}