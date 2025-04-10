using UnityEngine;

namespace MainGameNamespace
{
    [CreateAssetMenu(fileName = "New Card", menuName = "Card")]
    public class Card : ScriptableObject
    {
        public string cardName;
        public CardType cardType;
        public Sprite cardSprite;
        public int value;
        public int energyCost;

        public enum CardType { Add, Substract, Multiply, Divide, Power, Mark, Effect}
    }
}

