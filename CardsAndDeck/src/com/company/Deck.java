package com.company;

import java.util.ArrayList;
import java.util.LinkedList;
import java.util.Random;

public class Deck {

    //ATTRIBUTES
    private LinkedList<Card> _cardList;

    //CONSTRUCTORS
    public Deck () {
        _cardList = new LinkedList<>();
    }
    public Deck (boolean shuffle) throws Exception {
        Card newCard;
        _cardList = new LinkedList<>();

        for (int i = 1; i < 41; i++) {
            newCard = new Card(i);
            _cardList.addLast(newCard);
        }

        if (shuffle) Shuffle();
    }

    //Getters
    public int NumberOfCards() {
        return _cardList.size();
    }
    public boolean HasCards() {
        return !_cardList.isEmpty();
    }

    //Setters
    public void AddLast (Card card) {
        _cardList.addFirst(card);
    }
    public void AddLast (int id) throws Exception {
        Card card = new Card(id);
        AddLast(card);
    }
    public void AddFirst (Card card) {
        _cardList.addFirst(card);
    }
    public void AddFirst (int id) throws Exception{
        Card card = new Card(id);
        AddFirst(card);
    }

    //METHODS
    public void Shuffle () {
        Random r = new Random();
        LinkedList<Card> temp = new LinkedList<>();
        Card card;
        int randomIndex;

        while (HasCards()) {
            randomIndex = r.nextInt(NumberOfCards());
            card = _cardList.get(randomIndex);
            _cardList.remove(randomIndex);

            temp.addLast(card);
        }

        _cardList = temp;
    }
    public Card Draw () throws Exception{
        if (HasCards()) {
            return _cardList.remove(0);
        }
        else {
            throw new Exception("Not enough cards in deck");
        }
    }
    public void Cut (int position) throws Exception {
        LinkedList<Card> temp = new LinkedList<>();
        Card card;
        
        if (PositionExists(position)){

            for (int i = 0; i < position; i++) {
                card = _cardList.remove(0);
                temp.addLast(card);
            }

            _cardList.addAll(temp);
        }
        else {
            throw new Exception("The given position doesn't exists in the deck");
        }
    }

    //OVERRIDE
    @Override
    public String toString() {
        return CardList();
    }

    //HELPERS
    private boolean PositionExists (int position) {
        return position >= 0 && position < _cardList.size();
    }
    private String CardList() {
        StringBuilder sb = new StringBuilder();

        for (Card card : _cardList) {
            sb.append("\n").append(card);
        }

        return sb.toString();
    }
}
