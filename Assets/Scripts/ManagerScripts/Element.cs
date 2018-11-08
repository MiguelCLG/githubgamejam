using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Element {

    [System.Serializable]
    public struct PossibleCombinations
    {
        public string name;
        public string combinationName;
    }
    public PossibleCombinations[] combinations;

    public Material eyeMaterial; //Depois dependendo do Player Mesh ou Textura que tivermos vai ter de ser ajustado
    public Color color;
    public KeyCode hotkey;
    public GameObject prefab; //Objecto fisico guardado como prefab - basicamente um gameobject que se arrasta para as pastas

    public string name;
    public string effect;
    public string type; //Attack or Defense
    

    public float value;
    public float velocity;

    public bool active = false;

    
}
