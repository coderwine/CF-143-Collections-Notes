using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//ANCHOR: Top

    public class Diamonds_Queues
    {
        //NOTE: Queues
        private readonly Queue<Cards> _queueRepo = new Queue<Cards>();
        private int _count = 0;

        //ANCHOR: Enqueue
        public bool AddCardToQueue(Cards card)
        {
            if(card != null)
            {
                // _count++;
                // card.ID = _count;
                _queueRepo.Enqueue(card);
                return true;
            }
            return false;
        }

        public Queue<Cards> GetCards()
        {
            return _queueRepo;
        }

        //ANCHOR: Peek()
        public Cards ViewNextCard()
        {
            if(_queueRepo.Count > 0)
            {
                Cards card = _queueRepo.Peek();
                return card; 
                //NOTE: We don't need an ID in order to view the next item in queue. (FIFO)
            }
            return null;
        }

        //ANCHOR: Dequeue()
        public bool DiscardCard()
        {
            Cards card = ViewNextCard();

            if(card is null)
            {
                return false;
            }

            _queueRepo.Dequeue();
            return true;
        }




    }
