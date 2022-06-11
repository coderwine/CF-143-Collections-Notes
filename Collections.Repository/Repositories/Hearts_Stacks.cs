using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//ANCHOR: Top

public class Hearts_Stacks
{
    //NOTE: Stacks (LIFO: Last-In-First-Out)
    private readonly Stack<Cards> _stackRepo = new Stack<Cards>();
    private int _count = 0;

    //ANCHOR: Push()
    public bool AddCardToStack(Cards card)
    {
        if(card != null)
        {
            _count++;
            card.ID = _count;
            _stackRepo.Push(card);
            return true;
        }
        return false;
    }

    //ANCHOR: Peek()
    public Cards GetCard()
    {
        if(_stackRepo.Count() > 0)
        {
            Cards card = _stackRepo.Peek();
            return card;
        }
        return null;
    }

    //ANCHOR: Pop()
    public bool RemoveCard()
    {
        if(_stackRepo.Count() > 0)
        {
            _stackRepo.Pop();
            return true;
        }
        return false;
    }

    //ANCHOR: Clear()
    public bool ClearStack()
    {
        _stackRepo.Clear();

        if(_stackRepo.Count() != 0)
        {
            return false;
        }

        return true;
    }
}
