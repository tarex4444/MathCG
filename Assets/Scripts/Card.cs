using UnityEngine;

namespace MainGameNamespace
{
    [CreateAssetMenu(fileName = "New Card", menuName = "Card")]
    public class Card : ScriptableObject
    {
        public string cardName;
        public CardType cardType;
        public CardSubtype cardSubtype;
        public int value;
        public int energyCost;
        public string cardEffect;

        public enum CardType {Operation, Mark, Effect}
        public enum CardSubtype {Add, Substract, Multiply, Divide, Power, Mark, Effect}
    }
}

