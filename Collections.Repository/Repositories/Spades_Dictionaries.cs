using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Spades_Dictionaries
{
    //! DICTIONARY
        /*
            - Dictionary<TKey, TValue>
                - TKey must be unique
                    - Can be whatever datatype.
                    - Cannot be a null value.
                - TValue doesn't need to be unique.
                    - Can be whatever datatype.
                    - Can be null.
        */
    private readonly Dictionary<int, Cards> _dictionaryRepo = new Dictionary<int, Cards>();

    private int _count = 0; // Assigning those keys.
    
    //! Add to Dictionary
    public bool AddCardToDictionary(Cards card)
    {
            // Add(TKey, TValue)
            //  - Requires a key and value as arguments

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

    //! Find One 
    public Cards GetCardByKey(int keyInput)
    {
            /*
                Dictionary structure is:
                    - KeyValuePair<TKey, TValue> 
            */

            foreach(KeyValuePair<int, Cards> card in _dictionaryRepo)
            {
                if(card.Key == keyInput)
                {
                    return card.Value; //Returns the Card object that is stored in the Value of the key/value pair. 
                }
            }

            return null;
    }

    //! Update
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

    //! Delete
    public bool DeleteCard(int keyInput)
    {
            var oldCard = GetCardByKey(keyInput); // Target card within the dictionary.

            if(oldCard is null)
            {
                return false;
            }

            _dictionaryRepo.Remove(oldCard.ID); // using the key of the object to target and remove the object.
            return true;
    }
}
