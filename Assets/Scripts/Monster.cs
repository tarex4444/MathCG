using System.Collections.Generic;
using UnityEngine;
namespace MainGameNamespace{
    [CreateAssetMenu(fileName = "New Monster", menuName = "Monster")]
    public class Monster : ScriptableObject
    {
        public string monsterName;
        public int monsterHealth;
        public bool shielded;
        public Sprite monsterSprite;
        private List<MonsterAbility> abilities;
    }
}

