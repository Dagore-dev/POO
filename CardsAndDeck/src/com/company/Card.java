package com.company;

public class Card {

    //ATTRIBUTES
    private final int _number;
    private final Suit _suit;

    //CONSTRUCTORS
    public Card (int number, Suit suit) throws Exception {
        if (CheckNumber(number)) {
            _number = number;
        }
        else {
            throw new Exception("Spanish decks don't contain that number.");
        }
        _suit = suit;
    }
    public Card (int id) throws Exception {
        if (id > 0 && id < 41) {
            _number = GetNumberById(id);
            _suit = GetSuitById(id);
        }
        else {
            throw new Exception("Id for cards in spanish deck goes from 1 to 40.");
        }
    }

    //GETTERS
    public int CardNumber () {
        return _number;
    }
    public Suit CardSuit () {
        return _suit;
    }
    public String CardNumberName () {
        String name;

        switch (CardNumber()) {
            case 1 -> name = "as";
            case 2 -> name = "dos";
            case 3 -> name = "tres";
            case 4 -> name = "cuatro";
            case 5 -> name = "cinco";
            case 6 -> name = "seis";
            case 7 -> name = "siete";
            case 10 -> name = "sota";
            case 11 -> name = "caballo";
            case 12 -> name = "rey";
            default -> name = Integer.toString(CardNumber());
        }

        return name;
    }
    public String CardName () {
        return String.format("%s de %s", CardNumberName(), CardSuit());
    }
    public int TuteValue () {
        int tuteValue;

        switch (CardNumber()) {
            case 1 -> tuteValue = 11;
            case 3 -> tuteValue = 10;
            case 12 -> tuteValue = 4;
            case 11 -> tuteValue = 3;
            case 10 -> tuteValue = 2;
            default -> tuteValue = 0;
        }

        return tuteValue;
    }
    public int MusValue () {
        int musValue;

        switch (CardNumber()) {
            case 2 -> musValue = 1;
            case 10, 12, 11 -> musValue = 10;
            default -> musValue = CardNumber();
        }

        return musValue;
    }
    public double SevenAndAHalfValue () {
        double sevenAndAHalfValue;
        int number = CardNumber();

        if (number < 8) {
            sevenAndAHalfValue = number;
        }
        else {
            sevenAndAHalfValue = 0.5;
        }

        return sevenAndAHalfValue;
    }

    //OVERRIDE
    @Override
    public String toString() {
        return CardName();
    }

    //HELPERS
    private boolean CheckNumber (int number) {
        return number >= 1 && number <= 12 && number != 8 && number != 9;
    }
    private int GetNumberById (int id) {

        while (id > 10) {
            id -= 10;
        }

        if (id > 7) {
            id += 2;
        }

        return id;

    }
    private Suit GetSuitById (int id) {
        Suit suit;

        if (id < 11) {
            suit = Suit.oros;
        }
        else if (id < 21) {
            suit = Suit.copas;
        }
        else if (id < 31) {
            suit = Suit.espadas;
        }
        else {
            suit = Suit.bastos;
        }

        return suit;
    }

}
