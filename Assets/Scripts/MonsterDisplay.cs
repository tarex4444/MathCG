using System;
using MainGameNamespace;
using TMPro;
using UnityEngine;

public class MonsterDisplay : MonoBehaviour
{
    public Monster monsterData;
    public TMP_Text monsterHealth;
    public TMP_Text monsterName;
    public Sprite monsterSprite;

    void Start() 
    {
        UpdateMonsterDisplay();
    }

    private void UpdateMonsterDisplay()
    {
        monsterHealth.text = monsterData.monsterHealth.ToString();
        monsterName.text = monsterData.monsterName;
        monsterSprite = monsterData.monsterSprite;
    }
}
