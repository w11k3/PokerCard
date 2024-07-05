public class Card
{
    private string face; // face of card ("Ace", "Deuce", ...)
    private string suit; // suit of card ("Hearts", "Diamonds", ...)

    // two-parameter constructor initializes card's face and suit
    public Card(string cardFace, string cardSuit)
    {
        face = cardFace; // initialize face of card
        suit = cardSuit; // initialize suit of card
    } // end two-parameter Card constructor

    // return string representation of Card
    public override string ToString()
    {
        return face + " of " + suit;
    } // end method ToString
} // end class Card

public class DeckOfCards
{
    private Card[] deck; // array of Card objects
    private int currentCard; // index of next Card to be dealt (0-51)
    private const int NUMBER_OF_CARDS = 52; // constant number of Cards
    private Random randomNumbers; // random-number generator

    // constructor fills deck of Cards
    public DeckOfCards()
    {
        string[] faces = { "Ace", "Deuce", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };
        string[] suits = { "Hearths", "Diamonds", "Clubs", "Spades" };

        deck = new Card[NUMBER_OF_CARDS]; // create array of Card objects
        currentCard = 0; // set currentCard so deck[0] is dealt first
        randomNumbers = new Random(); // create random-number generator

        // populate deck with Card objects
        for (int count = 0; count < deck.Length; ++count)
            deck[count] = new Card(faces[count % 13], suits[count / 13]);
    } // end DeckOfCards constructor

    // shuffle deck of Cards with one-pass algorithm
    public void Shuffle()
    {
        // after shuffling, dealing should start at deck[0] again
        currentCard = 0; // reinitialize currentCard

        // for each Card, pick another random Card and swap them
        for (int first = 0; first < deck.Length; ++first)
        {
            // select a random number between 0 and 51
            int second = randomNumbers.Next(NUMBER_OF_CARDS);

            // swap current Card with randomly selected Card
            Card temp = deck[first];
            deck[first] = deck[second];
            deck[second] = temp;
        } // end for
    } // end method Shuffle

    // deal one Card
    public Card DealCard()
    {
        // determine whether Cards remain to be dealt
        if (currentCard < deck.Length)
            return deck[currentCard++]; // return current Card in array
        else return null; // indicate that all Cards were dealt
    } // end method DealCard
} // end class DeckOfCards

public class DeckOfCardsTest
{
    // execute app
    public static void Main(string[] args)
    {
        DeckOfCards myDeckOfCards = new DeckOfCards();
        myDeckOfCards.Shuffle(); // place Cards in random order

        // display all 52 Cards in the order in which they are dealt
        for (int i = 0; i < 52; ++i)
        {
            Console.Write("{0,-19}", myDeckOfCards.DealCard());

            if ((i + 1) % 4 == 0)
                Console.WriteLine();
        } // end for
    } // end Main
} // end class DeckOfCardsTest