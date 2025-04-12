using UnityEngine;
using MainGameNamespace;
using System.Collections.Generic;
using Unity.VisualScripting;
using System;
public class MonsterGridManager : MonoBehaviour
{
    public GameObject gridCellPrefab;
    
    [SerializeField] private int gridLength = 3;
    List<GameObject> gridObjects = new List<GameObject>();
    public GameObject[] gridCells;

    void Awake(){
        CreateGrid();
    }

    private void CreateGrid()
    {
        gridCells = new GameObject[gridLength];
        Vector2 centerOffset = new Vector2(gridLength / 2.0f - 0.5f, 0);

        for(int x = 0; x < gridLength; x++){
            int gridPosition = x;
            Vector2 spawnPosition = new Vector2(gridPosition, 0)-centerOffset;
            GameObject gridCell = Instantiate(gridCellPrefab, spawnPosition, Quaternion.identity);

            gridCell.transform.SetParent(transform);

            gridCell.GetComponent<GridCell>().gridIndex = gridPosition;

            gridCells[x] = gridCell;

        }
    }
    public bool AddMonsterToGrid(GameObject monster, int position){
        if(position >= 0 && position < gridLength){
            GridCell cell = gridCells[position].GetComponent<GridCell>();
            if(cell.isFull) return false;
            else{
                GameObject newMonster = Instantiate(monster, cell.GetComponent<Transform>().position, Quaternion.identity);
                gridObjects.Add(newMonster);
                cell.monsterInCell = newMonster;
                cell.isFull = true;
                return true;
            }
        }
        else return false;
    }
}