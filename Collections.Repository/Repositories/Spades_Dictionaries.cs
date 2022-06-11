using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//ANCHOR: Top

public class Spades_Dictionaries
{
    //NOTE: Dictionary
    private readonly Dictionary<int, Cards> _dictionaryRepo = new Dictionary<int, Cards>();

    private int _count = 0;
    
    //ANCHOR: Add()
    public bool AddCardToDictionary(Cards card)
    {
        if(card is null)
        {
            return false;
        }
        
        _count++;
        card.ID = _count;
        _dictionaryRepo.Add(card.ID, card);

        return true;
    }

    public Dictionary<int, Cards> GetCard()
    {
        return _dictionaryRepo;
    }

    //ANCHOR: KeyValuePair()
    public Cards GetCardByKey(int keyInput)
    {
        foreach(KeyValuePair<int, Cards> card in _dictionaryRepo)
        {
            if (card.Key == keyInput)
            {
                return card.Value;
            }
        }

        return null;
    }

    //ANCHOR: Update
    public bool UpdateCardData(int keyInput, Cards newCard)
    {
        var oldCardData = GetCardByKey(keyInput);

        if(oldCardData is null)
        {
            return false;
        }
            oldCardData.CardValue = newCard.CardValue;
            oldCardData.Suit = newCard.Suit;
            return true;
    }

    //ANCHOR: Remove()
    public bool DeleteCard(int keyInput)
    {
        var oldCard = GetCardByKey(keyInput);

        if(oldCard is null)
        {
            return false;
        }

        _dictionaryRepo.Remove(oldCard.ID);
        return true;
    }
}
