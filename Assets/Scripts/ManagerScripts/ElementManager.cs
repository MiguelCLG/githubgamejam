using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementManager : MonoBehaviour {

                                                                        //Este componente e para estar no player - e apenas para organisar os 
                                                                        //elementos que ele tem e tornar mais facil o 
                                                                        //manuseamento entre eles.. por eg. mudar de elemento ou juntar elementos

    public Element[] elements;

    public static ElementManager instance;

    public bool combinationStance = false; 

    // Use this for initialization
    void Start () {
        foreach (Element e in elements)
        {
            if (PlayerPrefs.HasKey("_ActiveElement"))
            {
                if (e.name == PlayerPrefs.GetString("_ActiveElement"))
                {
                    e.eyeMaterial.color = e.color;
                    foreach (Element element in elements)
                    {
                        element.active = false;
                    }
                    e.active = true;
                }
            }
            else if (e.active)
            {
                e.eyeMaterial.color = e.color;
                foreach (Element element in elements)
                {
                    element.active = false;
                }
                e.active = true;
            }
        }
    }

    // Update is called once per frame
    void Update () {
  
        if (Input.GetKeyDown(KeyCode.C))
        {
            combinationStance = !combinationStance;
        }
        foreach (Element element in elements)                           //Usar isto para percorrer os elementos
        {

            if (Input.GetKeyDown(element.hotkey) && !element.active) {

                foreach (Element e in elements)
                {
                    e.active = false;
                }
                element.active = true;
                element.eyeMaterial.color = element.color;
                PlayerPrefs.SetString("_ActiveElement", element.name);
            }
        }
    }
}
