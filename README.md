# Collections Main Lesson
## Topics

- System.Collections.Generic.Classes
  - Lists
    - ```List<T>```
  - Queues
    - ```Queue<T>```
    - FIFO (First in First Out)
  - Stack
    - ```Stack<T>```
    - LIFO (Last in First Out)
  - Dictionaries
    - ```Dictionary<TKey,TValue>```

[Commonly used Collection Types Resource](https://docs.microsoft.com/en-us/dotnet/standard/collections/commonly-used-collection-types)

## Concept:

The Code-along will detail the various methods within these 4 different Collections. Base structure and provide resources for them to explore later.

The Application will resemble a **deck of cards**. The Repository names, although having suits within the names, will the focus is on the collection itself. Having **Clubs** with **Lists** doesn't reflect the fact that clubs will only be available to Lists. The same goes for all other files within the Repo Folder.

### The Flow:
| Collection | Pulls from | Source | Like a | 
| ------------ | ---------- | --------- | ----- |
| QUEUES | --> | DICTIONARY | Pack of Cards |
| LIST | --> | QUEUES | Draw Deck |
| STACK | --> | LIST | Discard Pile |
| DICTIONARY | --> | STACK | Return to Pack |

**Clubs - LIST**:
  - **List** will display a collection of cards obtained by available cards within the **Queue**. Think of this link a "players hand".
  - Methods Built:
  ``` 
  AddCardToList() - Add
  GetAllCards()
  DeleteCard() - Remove
  ClearHand() - Clear
  ```

**Diamonds - QUEUE**:
  - **Queue** will represent a "draw deck" for a **List**.
  - Methods Built:
  ``` 
  AddCardToQueue() - Enqueue
  GetCards()
  ViewNextCard() - Peek
  DiscardCard() - Dequeue
  ```
**Hearts - STACK**:
  - **Stack** will represent a "discard pile" of cards that is obtained from the **List**.
  - Methods Built:
  ``` 
  AddCardToStack() - Push
  GetCard() - Peek
  RemoveCard() - Pop
  ClearStack() - Clear
  ```
**Spades - DICTIONARY**:
  - **Dictionaries** will provide access to view all cards availble with the "box".
  - Methods Built:
  ``` 
  AddCardToDictionary() - Add
  GetCard()
  GetCardByKey() - KeyValuePair<Tkey,T>
  UpdateCardData()
  DeleteCard() - Remove
  ```

---
## Collection Notes:
### Array:
  - Namespace: **System**
    - Provides methods for creating, manipulating, searching, and sorting arrays.
    - Not part of the **System.Collections** namespaces; however, considered a collection because it is based on the **IList** interface.
  - The Array class is the base class for arrays. Each item within the array is considered an element.
  - [Array Docs](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-6.0)

### Lists:
- ```List<T>```
- Namespace: **System.Collections.Generic**
- Strongly typed list of objects that canbe accessed by index. 
- [List Methods](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=net-6.0)

### Queues:
- Namespace: **System.Collections**
- Represents a First-In, First-Out collection of objects (FIFO).
  - Considered a circular array.
  - Objects stored in a Queue are inserted at one end and removed from the other.
  - Great for temporary storage.
- [Queue Methods](https://docs.microsoft.com/en-us/dotnet/api/system.collections.queue?view=net-6.0)

### Stacks:
- Namespace: **System.Collections**
- Represents a simple Last-In-First-Out (LIFO).
- [Stack Methods](https://docs.microsoft.com/en-us/dotnet/api/system.collections.stack?view=net-6.0#methods)

### Dictionaries:
- Namespace: **System.Collections.Generic**
  - Parameters:
    - ```TKey```: The type of the keys in the dictionary.
      - Keys provide a mapping for our values within the dictionary.
      - Must be unique
      - Cannot be null.
    - ```TValue```: The type of the values in the dictionary.
      - Doesn't need to be unique
      - Can be null
  - Details:
    - Each items in the dictionary is treated as a ```KeyValuePair<TKey,TValue>``` structure.
- [Dictionary Methods](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2?view=net-6.0#methods)

### Other Collections to Research:
```
Based on IList or directly on ICollection:
- ArrayList
- ConcurrentQueue<T>
- ConcurrentStack<T>
- LinkedList<T>

Based on the IDictionary interface. Every element contains both KEY and a VALUE.
- Hashtable
- SortedList
- SortedList<TKey,TValue>
- ConcurrentDictionary<TKey, TValue>
- KeyedCollection<TKey,TItem>
```
---
# Additional Challenges!

- Track the Code within the UI and Data folders. Where do things point? How are some aspects of code responding? *Put in some ```Console.WriteLine()``` to view various items of interest.* 
- This isn't the cleanest that this application can be. Feel free to figure out ways to source the methods currently built within the UI.
- There are other methods that can be used within the **Dictionary** Repo class. How can you incorporate that into the UI?
- Try making new cards. How can that be done? What about a new suit or alternate deck that you may be familiar with? Some card games only allow for various cards to be used. What about classes for those games and isolate unused cards?

Get creative with how this application can be manipulated. Use this as a sort of sandbox to toy around with varous collection methods and build out new methods for your specific classes.

Enjoy!

## Helpful Commands
```
dotnet run --project [FILE PATH]

// Reference a file from source folder
dotnet add [Need Reference File Path] refrence [Path to Target]

ex: 
dotnet add .\Collections.UI reference .\Collections.Data
```