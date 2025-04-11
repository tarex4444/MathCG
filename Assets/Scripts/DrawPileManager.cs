using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using MainGameNamespace;
using TMPro;
using Unity.VisualScripting;

public class DrawPileManager : MonoBehaviour
{
    public List<Card> drawPile = new List<Card>();
    [SerializeField] private TMP_Text drawPileText;
    void Update(){
        drawPileText.text = drawPile.Count.ToString();
    }
    public void DrawHand(){
        HandManager handManager = FindAnyObjectByType<HandManager>();
        Card nextCard = drawPile.Last();
        handManager.AddCardToHand(nextCard);
        drawPile.Remove(nextCard);
    }
    public void AddToDrawPile(Card card){
        drawPile.Add(card);
    }
}
