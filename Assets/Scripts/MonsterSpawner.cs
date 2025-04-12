using MainGameNamespace;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public MonsterGridManager monsterManager;
    public Monster monsterData;
    public GameObject monsterPrefab;

    private void Awake(){
        monsterManager = FindAnyObjectByType<MonsterGridManager>();
    }

    void Start(){
        GameObject monster = Instantiate(monsterPrefab, monsterManager.transform.position, Quaternion.identity, monsterManager.transform);
        monster.GetComponent<MonsterDisplay>().monsterData = monsterData;
        if(monsterManager.AddMonsterToGrid(monster, 2)){
            return;
        }
    }
}
