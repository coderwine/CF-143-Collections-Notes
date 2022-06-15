using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Hearts_Stacks
{
    //! STACKS
        //* LIFO: Last-in, First-Out
        // within the System.Collections.Generic namespace. 
    private readonly Stack<Cards> _stackRepo = new Stack<Cards>();

    //! Add Card
    public bool AddCardToStack(Cards card)
    {
            // Push()
            //  - Inserts an object to the top of the stack.

            if(card != null)
            {
                _stackRepo.Push(card);
                return true;
            }

            return false;
    }

    //! View Card
    public Cards GetCard()
    {
            // Peek()
            //  - Returns the object on top without removing it.

            if(_stackRepo.Count() > 0)
            {
                Cards card = _stackRepo.Peek();
                return card;
            }

            return null;
    }

    //! Delete Card
    public bool RemoveCard()
    {
            // Pop();
            //  - Removes the object on top of the stack.

            if(_stackRepo.Count() > 0)
            {
                _stackRepo.Pop();
                return true;
            }

            return false;
    }

    //! Delete all Cards
    public bool ClearStack()
    {
            // Clear()
            //  - Removes all objects from the stack.

            _stackRepo.Clear();

            if(_stackRepo.Count() != 0)
            {
                return false;
            }

            return true;
    }
}
