using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//ANCHOR: Top

    public class Clubs_Lists
    {
        //NOTE: Lists
        
        // Create a fake DB.
        private readonly List<Cards> _listRepo = new List<Cards>();

//ANCHOR: Add One
        public bool AddCardToList(Cards card)
        {
            //NOTE:Build
            // Using the Add() method.
            if(card != null)
            {
                _listRepo.Add(card);
                return true;
            }

            return false;
        }

//ANCHOR: Get All
        public List<Cards> GetAllCards()
        {
            return _listRepo;
        }

//ANCHOR: Delete One
        public bool DeleteCard(int id)
        {
            //NOTE: Build out
            System.Console.WriteLine(id);
            Cards cardToDelete = _listRepo.FirstOrDefault(c => c.ID == id);
            return _listRepo.Remove(cardToDelete);

            /* 
                -FirstOrDefault(): Iterates through the List<T> and targets the first item that matches the input provided (ID). 
                    - If there is none, provides a default response "No Element found".
                    - using a local variable (var) to handled any cases where null is returned.
                - Remove(): returns back a boolean value.
            */
        }

//ANCHOR: Delete All
        public bool ClearHand()
        {
            //NOTE: Build
            if(_listRepo.Count > 0)
            {
                _listRepo.Clear();
                return true;
            }
            return false;
        }
}
