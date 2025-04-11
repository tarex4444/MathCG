using UnityEngine;
using MainGameNamespace;
using System.Collections.Generic;
using System;
using JetBrains.Annotations;
public class HandManager : MonoBehaviour
{
    public GameObject cardPrefab; //assign in inspector
    public int startingHandCount = 5;
    public Transform handTransform; //Root of hand position
    public float fanSpread = 10f;
    public float cardSpacing = -180f;
    public float verticalSpacing = 80f;
    public int maxHandSize = 8;
    public List<GameObject> cardsInHand = new List<GameObject>();
    public DrawPileManager drawPileManager;
    public DiscardPileManager discardPile;

    void Start()
    {
        for(int i = 0; i < startingHandCount; i++){
            drawPileManager.DrawHand();
        }
        
    }

    void Update(){
        //UpdateHandVisuals();
    }

    public void AddCardToHand(Card cardData)
    {
        if(cardsInHand.Count == maxHandSize){
            return;
        }
        //Instantiate the card
        GameObject newCard = Instantiate(cardPrefab, handTransform.position, Quaternion.identity, handTransform);
        cardsInHand.Add(newCard);

        newCard.GetComponent<CardDisplay>().cardData = cardData;

        UpdateHandVisuals();
    }

    public void DiscardCardTest(){
        GameObject cardToRemove = cardsInHand[cardsInHand.Count-1];
        
        Destroy(cardToRemove);
        cardsInHand.RemoveAt(cardsInHand.Count - 1);

        UpdateHandVisuals();
    }
    
    private void UpdateHandVisuals()
    {
        int cardCount = cardsInHand.Count;

        if(cardCount == 1){
            cardsInHand[0].transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            cardsInHand[0].transform.localPosition = new Vector3(0f, 0f, 0f);
            return;
        }
        for(int i = 0; i < cardCount; i++){
            float rotationAngle = (fanSpread * (i - (cardCount -1)/2f));
            cardsInHand[i].transform.localRotation = Quaternion.Euler(0f, 0f, rotationAngle);

            float normalizedPosition = (2f * i/(cardCount-1)-1f);
            float horizontalOffset = (cardSpacing * (i - (cardCount -1)/2f));
            float verticalOffset = verticalSpacing * (1-normalizedPosition* normalizedPosition);

            //Set card position
            cardsInHand[i].transform.localPosition = new Vector3(horizontalOffset, verticalOffset, 0f);
        }
    }
    
}
