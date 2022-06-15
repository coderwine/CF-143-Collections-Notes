using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

        public class Clubs_Lists
        {
        //! LISTS
        /*
                -List<T>
                        - Indicates a data type of "Lists" within the System.Collections.Generic namespace.
                        - <T> denotes what type of data type will be stored in this particular list.
                                - In our case, it is "Cards"
        */
        
        private readonly List<Cards> _listRepo = new List<Cards>(); // Create a fake DB

//! Add Card
        public bool AddCardToList(Cards card)
        {
                // Add()
                /*
                        - Add(T)
                                - Adds our object to the end of the List
                */

                if(card != null)
                {
                        _listRepo.Add(card);
                        return true;
                }

                return false;
        }

//! Get All
        public List<Cards> GetAllCards()
        {
                return _listRepo;
        }

//! Delete One
        public bool DeleteCard(int id)
        {
                // FirstOrDefault() & Remove()
                /*
                        - FirstOrDefault(): Iterates through the List<T> and targets the first item that matches the input provided (ID).
                                - If there is none, provides a default response "No element found".
                                - use a local variable (var) to handle any cases where null is returned.
                        - Remove(): returns back a boolean value.
                */

                System.Console.WriteLine(id);
                Cards cardToDelete = _listRepo.FirstOrDefault(c => c.ID == id);
                return _listRepo.Remove(cardToDelete);
        }

//! Delete All
        public bool ClearHand()
        {
                // Clear()
                /*
                        - An action method that will remove all objects currently in the list.
                */

                if(_listRepo.Count > 0)
                {
                        _listRepo.Clear();
                        return true;
                }

                return false;
        }
}
