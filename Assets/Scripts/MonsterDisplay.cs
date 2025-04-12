using System;
using MainGameNamespace;
using TMPro;
using UnityEngine;

public class MonsterDisplay : MonoBehaviour
{
    public Monster monsterData;
    [HideInInspector] public int currentHealth = 100;
    public TMP_Text monsterHealth;
    public TMP_Text monsterName;
    public SpriteRenderer monsterSprite;

    private void Awake(){
        monsterSprite = GetComponent<SpriteRenderer>();
    }
    void Update() 
    {
        UpdateMonsterHealth();
        if (currentHealth <= 0){
            Destroy(gameObject);
        }
    }

    private void UpdateMonsterHealth()
    {
        monsterHealth.text = currentHealth.ToString();
    }
    public void Initialize(Monster data){
        monsterData = data;
        currentHealth = data.monsterHealth;
        monsterHealth.text = currentHealth.ToString();
        monsterName.text = data.monsterName;
        if(monsterSprite != null && data.monsterSprite != null){
            monsterSprite.sprite = monsterData.monsterSprite;
        }
    }
    public void ApplyCardEffect(Card card){
        switch(card.cardSubtype){
            case Card.CardSubtype.Add:
                currentHealth += card.value;
                break;
            case Card.CardSubtype.Substract:
                currentHealth -= card.value;
                break;
            case Card.CardSubtype.Multiply:
                currentHealth *= card.value;
                break;
            case Card.CardSubtype.Divide:
                if(card.value != 0){
                    currentHealth /= card.value;
                }
                break;
            case Card.CardSubtype.Power:
                currentHealth = Mathf.RoundToInt(Mathf.Pow(currentHealth, card.value));
                break;
            case Card.CardSubtype.Mark:
                //TODO - mark
                break;
            case Card.CardSubtype.Effect:
                //TODO - effect
                break;
        }
        UpdateMonsterHealth();
        if (currentHealth <= 0){
            Destroy(gameObject);
        }
    }
}
