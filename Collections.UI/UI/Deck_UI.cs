using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//ANCHOR: Top

public class Deck_UI
{
    private readonly Clubs_Lists _lRepo = new Clubs_Lists(); // list repository (db) creation.
    private readonly Diamonds_Queues _qRepo = new Diamonds_Queues();// queue repository (db) creation.
    private readonly Hearts_Stacks _sRepo = new Hearts_Stacks(); // stack repository (db) creation.
    public readonly Spades_Dictionaries _dRepo = new Spades_Dictionaries(); // dictionary repository (db) creation.

    public void Run()
    {
        SeedData();
        RunApplication();
    }

    private void RunApplication()
    {
        //ANCHOR: User Main Menu
        bool isRunning = true;
        while(isRunning)
        {
            Console.Clear();
            
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            System.Console.WriteLine(
                " \t=================================== \n" +
                " \tThe Purpose of this Console App:\n"  
            );

            Console.ForegroundColor = ConsoleColor.Cyan;
            System.Console.WriteLine(
                " \t- The Dictionary stores what cards \n" +
                " \tare currently available.\n" 
            );

            Console.ForegroundColor = ConsoleColor.Magenta;
            System.Console.WriteLine(
                " \t- The Queue will pull (Enqueue) from \n" +
                " \tthe Dictionary.\n"
            );

            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine(
                " \t- The List will draw (Add) from \n" +
                " \tthe Queue.\n"
            );

            Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.WriteLine(
                " \t- The Stack will accept (Push) from \n" +
                " \tthe Queue.\n"
            );

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            System.Console.WriteLine(
                " \tRemoving cards from the stack will \n" + 
                " \treturn back to the dictionary. \n" + 
                " \t=================================== \n" 
            );

            Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine(" \tDealer Shuffles...\n");
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(
                " \tPlease Select from the following: \n"
                );
            
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(
                " \t==== LISTS ==========="
                );
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(
                " \t1. Add Card to List\n" +
                " \t2. View All Cards in List\n" +
                " \t3. Delete Card in List\n" 
                );
            
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(
                " \t==== QUEUES =========="
                );
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(
                " \t4. Add Card to Queue\n" +
                " \t5. View Card in Queue\n" +
                " \t6. Remove Card in Queue\n"
                );
            
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(
                " \t==== STACKS =========="
                );
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(
                " \t7. Add Card to Stack\n" +
                " \t8. View Card in Stack\n" +
                " \t9. Remove Card in Stack\n"
                );
            
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(
                " \t==== DICTIONARIES ===="
                );
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(
                " \tD. View All in Dictionary\n"
                );
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(
                " \t========== \n" +
                " \tX. Exit"
                );

            Console.ResetColor();

            string userInput = Console.ReadLine().ToLower();
            switch(userInput)
            {
                case "1":
                    AddCardToList();
                    break;
                case "2":
                    ViewAllInList();
                    break;
                case "3":
                    DeleteCardInList();
                    break;
                case "4":
                    AddCardToQueue();
                    break;
                case "5":
                    ViewCardInQueue();
                    break;
                case "6":
                    RemoveCardInQueue();
                    break;
                case "7":
                    AddCardToStack();
                    break;
                case "8":
                    ViewCardInStack();
                    break;
                case "9":
                    RemoveCardInStack();
                    break;
                case "d":
                    ViewAllInDictionary();
                    break;
                case "x":
                    isRunning = CloseApplication();
                    break;
                default:
                    System.Console.WriteLine("Invalid Selection");
                    PressAnyKey();
                    break;
            }

        }

    }

    //ANCHOR: List Methods
    private void AddCardToList()
    {
        Console.Clear();

        ViewCardInQueue();

        System.Console.WriteLine("Would you like to pull this card? y/n");

        string userResponse = Console.ReadLine().ToLower();

        if(userResponse == "y")
        {
            _lRepo.AddCardToList(_qRepo.ViewNextCard());

            if(_qRepo.DiscardCard())
            {
                ViewAllInList();
            }
            else
            {
                System.Console.WriteLine("Unable to pull card from Queue.");
            }

        }

    }
    private void ViewAllInList()
    {
        Console.Clear();

        if (_lRepo.GetAllCards().Count > 0)
        {
            List<Cards> cards = _lRepo.GetAllCards();
            foreach(Cards c in cards)
            {
                DisplayCard(c);
            }    
        } 
        else
        {
            System.Console.WriteLine("There are no cards in the list");
        }

        PressAnyKey();
    }
    private void DeleteCardInList()
    {
        Console.Clear();

        ViewAllInList();
        System.Console.Write(
            "Please enter a card ID: "
        );
        int input = int.Parse(Console.ReadLine());

        Console.ForegroundColor = ConsoleColor.DarkRed;
        System.Console.WriteLine("Are you sure? y/n");
        string confirm = Console.ReadLine().ToLower();
        Console.ResetColor();

        if(confirm == "y")
        {
            try
            {
                
                _lRepo.DeleteCard(input);

                Cards toDictionary = CardInList(input);
                _dRepo.AddCardToDictionary(toDictionary);

            }
            catch
            {
                System.Console.WriteLine("Unable to remove card.");
            }
        }

    }

    //ANCHOR: Queue Methods
    private void AddCardToQueue()
    {
        Console.Clear();

        ViewAllInDictionary();

        System.Console.WriteLine("Select a Card by ID: ");
        int idSelected = int.Parse(Console.ReadLine());

        Cards selectedCard = _dRepo.GetCardByKey(idSelected);
        
        if(_qRepo.AddCardToQueue(selectedCard) && _dRepo.DeleteCard(idSelected))
        {
            ViewCardInQueue();
        }
        else
        {
            System.Console.WriteLine("Unable to add card to list.");
        }
    }
    private void ViewCardInQueue()
    {
        Console.Clear();

        if(_qRepo.GetCards().Count > 0)
        {
            Cards nextCard = _qRepo.ViewNextCard();
            DisplayCard(nextCard);
        }
        else
        {
            System.Console.WriteLine("No cards in queue.");
        }

        System.Console.WriteLine("Total Queue Count: " + _qRepo.GetCards().Count);

        PressAnyKey();
    }
    private void RemoveCardInQueue()
    {
        Console.Clear();

        Cards nextCard = _qRepo.ViewNextCard();
        _qRepo.DiscardCard();

        _dRepo.AddCardToDictionary(nextCard);

        ViewCardInQueue();

    }
    
    //ANCHOR: Stack Methods
    private void AddCardToStack()
    {
        Console.Clear();

        ViewAllInList();
        System.Console.Write("Please select a card by ID: ");

        int userInput = int.Parse(Console.ReadLine());
        Cards getCard = CardInList(userInput);

        _lRepo.DeleteCard(userInput);
        _sRepo.AddCardToStack(getCard);

        System.Console.WriteLine("Added!");
    }
    private void ViewCardInStack()
    {
        Console.Clear();

        Cards card = _sRepo.GetCard();

        if(card != null)
        {
            DisplayCard(card);
        }
        else
        {
            System.Console.WriteLine("There are no cards in the stack");
        }

        PressAnyKey();

    }
    private void RemoveCardInStack()
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.DarkRed;
        System.Console.WriteLine("Are you sure? y/n");
        Console.ResetColor();
        string response = Console.ReadLine().ToLower();

        if(response == "y")
        {
            Cards card = _sRepo.GetCard();
            _sRepo.RemoveCard();
            _dRepo.AddCardToDictionary(card);
            System.Console.WriteLine($"The {card.CardValue.ToString().ToUpper()} of {card.Suit.ToString().ToUpper()} has been returned to the dictionary.");
        }
        else
        {
            System.Console.WriteLine("Unable to put back into the dictionary.");
        }

        PressAnyKey();
    }

    //ANCHOR: Dictionary Methods
    private void ViewAllInDictionary()
    {
        Console.Clear();

        Dictionary<int, Cards> cards = _dRepo.GetCard();

        foreach (KeyValuePair<int,Cards> c in cards)
        {
            DisplayCard(c.Value);
        }

        PressAnyKey();
    }

    //ANCHOR: Helper Methods
    private Cards CardInList(int id)
    {
        List<Cards> cards = _lRepo.GetAllCards();
        foreach(Cards c in cards)
        {
            if(c.ID == id)
            {
                return c;
            }
        }
        return null;
    }
    private void DisplayCard(Cards c)
    {

        if(c.Color == "red")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine(
                $"ID: {c.ID.ToString().ToUpper()}\n" +
                $"{c.CardValue.ToString().ToUpper()} of {c.Suit.ToString().ToUpper()}\n" +
                "---------------- \n"
                );
            Console.ResetColor(); 
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.WriteLine(
                    $"ID: {c.ID.ToString().ToUpper()}\n" +
                    $"{c.CardValue.ToString().ToUpper()} of {c.Suit.ToString().ToUpper()}\n" +
                    "---------------- \n"
                    );
            Console.ResetColor(); 

        }

    }
    
    //ANCHOR: UI Methods
    private void PressAnyKey()
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        System.Console.WriteLine("\tPress Any Key to Continue...");
        Console.ResetColor();
        Console.ReadKey();
    }
    private bool CloseApplication()
    {
        Console.Clear();
        System.Console.Write(
            " \n\n\n\tDealer gathers the cards and begins shuffling,"
            );
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        System.Console.WriteLine("\"Have a good day.\"");
        Console.ResetColor();
        PressAnyKey();
        return false;
    }
    private void SeedData()
    {
        //NOTE: Dictionary
        //! SPADES
        Cards sTwo = new Cards(Values.two, Suits.Spades);
        Cards sThree = new Cards(Values.three, Suits.Spades);
        Cards sFour = new Cards(Values.four, Suits.Spades);
        Cards sFive = new Cards(Values.five, Suits.Spades);
        Cards sSix = new Cards(Values.six, Suits.Spades);
        Cards sSeven = new Cards(Values.seven, Suits.Spades);
        Cards sEight = new Cards(Values.eight, Suits.Spades);
        Cards sNine = new Cards(Values.nine, Suits.Spades);
        Cards sTen = new Cards(Values.ten, Suits.Spades);
        Cards sJack = new Cards(Values.jack, Suits.Spades);
        Cards sQueen = new Cards(Values.queen, Suits.Spades);
        Cards sKing = new Cards(Values.king, Suits.Spades);
        Cards sAce = new Cards(Values.ace, Suits.Spades);

        _dRepo.AddCardToDictionary(sTwo);
        _dRepo.AddCardToDictionary(sThree);
        _dRepo.AddCardToDictionary(sFour);
        _dRepo.AddCardToDictionary(sFive);
        _dRepo.AddCardToDictionary(sSix);
        _dRepo.AddCardToDictionary(sSeven);
        _dRepo.AddCardToDictionary(sEight);
        _dRepo.AddCardToDictionary(sNine);
        _dRepo.AddCardToDictionary(sTen);
        _dRepo.AddCardToDictionary(sJack);
        _dRepo.AddCardToDictionary(sQueen);
        _dRepo.AddCardToDictionary(sKing);
        _dRepo.AddCardToDictionary(sAce);

        //! CLUBS
        Cards cTwo = new Cards(Values.two, Suits.Clubs);
        Cards cThree = new Cards(Values.three, Suits.Clubs);
        Cards cFour = new Cards(Values.four, Suits.Clubs);
        Cards cFive = new Cards(Values.five, Suits.Clubs);
        Cards cSix = new Cards(Values.six, Suits.Clubs);
        Cards cSeven = new Cards(Values.seven, Suits.Clubs);
        Cards cEight = new Cards(Values.eight, Suits.Clubs);
        Cards cNine = new Cards(Values.nine, Suits.Clubs);
        Cards cTen = new Cards(Values.ten, Suits.Clubs);
        Cards cJack = new Cards(Values.jack, Suits.Clubs);
        Cards cQueen = new Cards(Values.queen, Suits.Clubs);
        Cards cKing = new Cards(Values.king, Suits.Clubs);
        Cards cAce = new Cards(Values.ace, Suits.Clubs);

        _dRepo.AddCardToDictionary(cTwo);
        _dRepo.AddCardToDictionary(cThree);
        _dRepo.AddCardToDictionary(cFour);
        _dRepo.AddCardToDictionary(cFive);
        _dRepo.AddCardToDictionary(cSix);
        _dRepo.AddCardToDictionary(cSeven);
        _dRepo.AddCardToDictionary(cEight);
        _dRepo.AddCardToDictionary(cNine);
        _dRepo.AddCardToDictionary(cTen);
        _dRepo.AddCardToDictionary(cJack);
        _dRepo.AddCardToDictionary(cQueen);
        _dRepo.AddCardToDictionary(cKing);
        _dRepo.AddCardToDictionary(cAce);

        //! DIAMONDS
        Cards dTwo = new Cards(Values.two, Suits.Diamonds);
        Cards dThree = new Cards(Values.three, Suits.Diamonds);
        Cards dFour = new Cards(Values.four, Suits.Diamonds);
        Cards dFive = new Cards(Values.five, Suits.Diamonds);
        Cards dSix = new Cards(Values.six, Suits.Diamonds);
        Cards dSeven = new Cards(Values.seven, Suits.Diamonds);
        Cards dEight = new Cards(Values.eight, Suits.Diamonds);
        Cards dNine = new Cards(Values.nine, Suits.Diamonds);
        Cards dTen = new Cards(Values.ten, Suits.Diamonds);
        Cards dJack = new Cards(Values.jack, Suits.Diamonds);
        Cards dQueen = new Cards(Values.queen, Suits.Diamonds);
        Cards dKing = new Cards(Values.king, Suits.Diamonds);
        Cards dAce = new Cards(Values.ace, Suits.Diamonds);

        _dRepo.AddCardToDictionary(dTwo);
        _dRepo.AddCardToDictionary(dThree);
        _dRepo.AddCardToDictionary(dFour);
        _dRepo.AddCardToDictionary(dFive);
        _dRepo.AddCardToDictionary(dSix);
        _dRepo.AddCardToDictionary(dSeven);
        _dRepo.AddCardToDictionary(dEight);
        _dRepo.AddCardToDictionary(dNine);
        _dRepo.AddCardToDictionary(dTen);
        _dRepo.AddCardToDictionary(dJack);
        _dRepo.AddCardToDictionary(dQueen);
        _dRepo.AddCardToDictionary(dKing);
        _dRepo.AddCardToDictionary(dAce);

        //! HEARTS
        Cards hTwo = new Cards(Values.two, Suits.Hearts);
        Cards hThree = new Cards(Values.three, Suits.Hearts);
        Cards hFour = new Cards(Values.four, Suits.Hearts);
        Cards hFive = new Cards(Values.five, Suits.Hearts);
        Cards hSix = new Cards(Values.six, Suits.Hearts);
        Cards hSeven = new Cards(Values.seven, Suits.Hearts);
        Cards hEight = new Cards(Values.eight, Suits.Hearts);
        Cards hNine = new Cards(Values.nine, Suits.Hearts);
        Cards hTen = new Cards(Values.ten, Suits.Hearts);
        Cards hJack = new Cards(Values.jack, Suits.Hearts);
        Cards hQueen = new Cards(Values.queen, Suits.Hearts);
        Cards hKing = new Cards(Values.king, Suits.Hearts);
        Cards hAce = new Cards(Values.ace, Suits.Hearts);

        _dRepo.AddCardToDictionary(hTwo);
        _dRepo.AddCardToDictionary(hThree);
        _dRepo.AddCardToDictionary(hFour);
        _dRepo.AddCardToDictionary(hFive);
        _dRepo.AddCardToDictionary(hSix);
        _dRepo.AddCardToDictionary(hSeven);
        _dRepo.AddCardToDictionary(hEight);
        _dRepo.AddCardToDictionary(hNine);
        _dRepo.AddCardToDictionary(hTen);
        _dRepo.AddCardToDictionary(hJack);
        _dRepo.AddCardToDictionary(hQueen);
        _dRepo.AddCardToDictionary(hKing);
        _dRepo.AddCardToDictionary(hAce);

    }

}
