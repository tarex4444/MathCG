using System;
using System.Collections.Generic;
using MainGameNamespace;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public List<Card> allCards = new List<Card>();
    public List<Card> playerDeck = new List<Card>();
    public int startingHandSize = 5;
    public int maxHandSize;
    public int currentHandSize;
    private int currentIndex = 0;
    private HandManager handManager;
    private DrawPileManager drawPileManager;

    void Start()
    {
        Card[] cards = Resources.LoadAll<Card>("Cards");

        allCards.AddRange(cards);
        AddCardsToDeckDebug();
        handManager = FindAnyObjectByType<HandManager>();
        drawPileManager = FindAnyObjectByType<DrawPileManager>();
        maxHandSize = handManager.maxHandSize;
        foreach(Card card in playerDeck){
            drawPileManager.AddToDrawPile(card);
        }

        /*for(int i = 0; i < startingHandSize; i++){
            DrawCard(handManager);
        }*/
    }
    void Update(){
        if(handManager != null){
            currentHandSize = handManager.cardsInHand.Count;
        }
    }
    public void DrawCard(HandManager handManager){
        if(allCards.Count == 0){
            return;
        }
        if(currentHandSize < maxHandSize){
            Card nextCard = allCards[currentIndex];
            handManager.AddCardToHand(nextCard);
            currentIndex = (currentIndex +1) %allCards.Count;
        }
        
    }
    public void DiscardCard(GameObject card){
        if(handManager.cardsInHand.Count == 0){
            return;
        } else {
            handManager.DiscardCardTest(card);
        }

    }
    public void AddCardsToDeckDebug(){
        for(int i = 0; i < 10; i++){
            playerDeck.Add(allCards.GetRandomItem());
        }
    }
    public void AddCardToDeck(Card card){
        throw new NotImplementedException();
    }
}
