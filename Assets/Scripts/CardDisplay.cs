using UnityEngine;
using UnityEngine.UI;
using TMPro;
using MainGameNamespace;
using UnityEngine.U2D;
public class CardDisplay : MonoBehaviour
{
    public Card cardData;
    public Image effectImage;
    public Image typeImage;
    public TMP_Text effectText;
    public TMP_Text typeName;
    public TMP_Text energyNumber;
    public Sprite[] typeSpriteList;
    public Sprite[] effectSpriteList;
    void Start()
    {
        UpdateCardDisplay();
    }

    public void UpdateCardDisplay()
    {
        effectText.text = cardData.cardEffect.ToString();
        typeName.text = cardData.cardSubtype.ToString();
        energyNumber.text = cardData.energyCost.ToString();
        switch(cardData.cardType.ToString()){
            case "Operation":{
                typeImage.sprite = typeSpriteList[0];
                break;
            }
            case "Mark":{
                typeImage.sprite = typeSpriteList[1];
                break;
            }
            case "Effect":{
                break;
            }
        }
        switch(cardData.cardSubtype.ToString()){
            case "Addition":{
                effectImage.sprite = effectSpriteList[0];
                break;
            }
            case "Substraction":{
                effectImage.sprite = effectSpriteList[1];
                break;
            }
            case "Multiplication":{
                effectImage.sprite = effectSpriteList[2];
                break;
            }
            case "Division":{
                effectImage.sprite = effectSpriteList[3];
                break;
            }
        }
    }
        
        
}
