using UnityEngine;
using System.Collections.Generic;
using MainGameNamespace;
using TMPro;

public class DiscardPileManager : MonoBehaviour
{
    public List<Card>discardPile = new List<Card>();
    [SerializeField] private TMP_Text discardPileText;
    void Update(){
        discardPileText.text = discardPile.Count.ToString();
    }
    public void ShuffleToDrawPile(){
        DrawPileManager drawPileManager = FindAnyObjectByType<DrawPileManager>();
        discardPile.Shuffle();
        drawPileManager.drawPile.AddRange(discardPile);
        discardPile.Clear();
    }
    public void AddToDiscardPile(Card card){
        discardPile.Add(card);
    }
}
