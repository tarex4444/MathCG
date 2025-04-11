using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
[CustomEditor(typeof(DeckManager))]
public class DeckManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DeckManager deckManager = (DeckManager)target;
        if (GUILayout.Button("Draw Next Card")){
            HandManager handManager = FindAnyObjectByType<HandManager>();
            if (handManager != null){
                deckManager.DrawCard(handManager);
            }
        }
        if (GUILayout.Button("Discard Card")){
            HandManager handManager = FindAnyObjectByType<HandManager>();
            if (handManager != null){
                deckManager.DiscardCard(handManager);
            }
        }
    }
}
#endif

