using System.Collections.Generic;
using MainGameNamespace;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public List<Card> allCards = new List<Card>();
    public int startingHandSize = 5;
    public int maxHandSize;
    public int currentHandSize;
    private int currentIndex = 0;
    private HandManager handManager;

    void Start()
    {
        Card[] cards = Resources.LoadAll<Card>("Cards");

        allCards.AddRange(cards);

        handManager = FindAnyObjectByType<HandManager>();
        maxHandSize = handManager.maxHandSize;
        for(int i = 0; i < startingHandSize; i++){
            DrawCard(handManager);
        }
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
}
