using System;
using MainGameNamespace;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    
    private int playerHealth;

    public OptionsManager OptionsManager {get; private set;}
    public AudioManager AudioManager {get; private set;}
    public DeckManager DeckManager {get; private set;}
    public MapManager MapManager {get; private set;}

    private void Awake(){
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeManagers();
        }
        else if (Instance != this){
            Destroy(gameObject);
        }
    }
    void Start(){
    }
    private void InitializeManagers()
    {
        OptionsManager = GetComponentInChildren<OptionsManager>();
        AudioManager =GetComponentInChildren<AudioManager>();
        DeckManager = GetComponentInChildren<DeckManager>();
        MapManager = GetComponentInChildren<MapManager>();

        if(OptionsManager==null){
            GameObject prefab = Resources.Load<GameObject>("Prefabs/OptionsManager");
            if(prefab == null){
                Debug.Log($"OptionsManager prefab not found");
            } else {
                Instantiate(prefab, transform.position, Quaternion.identity, transform);
                OptionsManager = GetComponentInChildren<OptionsManager>();
            }
        }
        if(AudioManager==null){
            GameObject prefab = Resources.Load<GameObject>("Prefabs/AudioManager");
            if(prefab == null){
                Debug.Log($"AudioManager prefab not found");
            } else {
                Instantiate(prefab, transform.position, Quaternion.identity, transform);
                AudioManager = GetComponentInChildren<AudioManager>();
            }
        }
        if(DeckManager==null){
            GameObject prefab = Resources.Load<GameObject>("Prefabs/DeckManager");
            if(prefab == null){
                Debug.Log($"DeckManager prefab not found");
            } else {
                Instantiate(prefab, transform.position, Quaternion.identity, transform);
                DeckManager = GetComponentInChildren<DeckManager>();
            }
        }
        if(MapManager==null){
            GameObject prefab = Resources.Load<GameObject>("Prefabs/MapManager");
            if(prefab == null){
                Debug.Log($"MapManager prefab not found");
            } else {
                Instantiate(prefab, transform.position, Quaternion.identity, transform);
                MapManager = GetComponentInChildren<MapManager>();
            }
        }
    }

    public int PlayerHealth
    {
        get {return playerHealth;}
        set {playerHealth = value;}
    }
}
