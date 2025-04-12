using MainGameNamespace;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public MonsterGridManager monsterManager;
    public Monster[] monstersData;
    public GameObject monsterPrefab;

    void Start(){
        GameObject monster = Instantiate(monsterPrefab, monsterManager.transform.position, Quaternion.identity, monsterManager.transform);
        monster.GetComponent<MonsterDisplay>().monsterData = monstersData[0];
        if(monsterManager.AddMonsterToGrid(monster, 0)){
            return;
        }
    }
}
