using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Diamonds_Queues
{
        //! QUEUES
        //* FIFO: First-In, First-Out
        private readonly Queue<Cards> _queueRepo = new Queue<Cards>();
        

        //! Add Card
        public bool AddCardToQueue(Cards card)
        {
                // Enqueue()
                // - Adds to the end of the Queue<T>

                if(card != null)
                {
                        _queueRepo.Enqueue(card);
                        return true;
                }

                return false;
        }

        public Queue<Cards> GetCards()
        {
                return _queueRepo;
        }

        //! View Card
        public Cards ViewNextCard()
        {
                // Peek();
                //      - We don't need an ID in order to view the next item in the queue due to the FIFO structure.

                if(_queueRepo.Count > 0)
                {
                        Cards card = _queueRepo.Peek();
                        return card;
                }

                return null;
                // The return is expecting a Card object. We either need to provide one or nothing in order for our ViewNextCard() method to function.
        }

        //! Delete Card
        public bool DiscardCard()
        {
                /*
                - Dequeue()
                        - Removes the next object in line.
                        - Doesn't need an ID to target due to the FIFO structure.
                */

                Cards card = ViewNextCard();

                if(card is null)
                {
                        return false;
                }

                _queueRepo.Dequeue();
                return true;
        }

}   
