using UnityEngine;

namespace MainGameNamespace{
    [CreateAssetMenu(fileName="New Monster Ability", menuName="Monster Ability")]
    public class MonsterAbility : ScriptableObject
    {
        public enum Effect {
        Attack, 
        Heal,
        Shield,
        Buff,
        Debuff
    };
    public Effect abilityEffect;
    public int abilityEffectValue;
    }
}

