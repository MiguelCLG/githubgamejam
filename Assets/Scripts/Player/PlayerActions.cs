using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour {

    public GameObject firePoint;

    private ElementManager elementManager;


    //tornar private
    public Element activeElement;
    public int numElements;

	// Use this for initialization
	void Start () {
        elementManager = GetComponent<ElementManager>();
        foreach (Element e in elementManager.elements)
        {
            if (e.active)
            {
                activeElement = e;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (elementManager.combinationStance)
        {
            CombineElements();
        }
        if (Input.GetButtonDown("Fire1")) {
            /*TODO
               Se o numElements > 1
                  Verificar que elementos estao activos
                  Encontrar as combinacoes
                    Chama MixAction() e ataca ou defende dependendo do tipo
               Senao
                   Chama Action() e ataca ou defende dependendo do tipo

            */
        }
    }

    void Action(Element e) {
           Instantiate(e.prefab, firePoint.transform.position, e.prefab.transform.rotation); //Depois o prefab e que vai ter o script que diz o que tem de fazer.
    }

    void MixAction() {
        
    }

    //TODO
    //Adicionar combinacoes para cada objecto

    void CombineElements()
    {
        foreach (Element e in elementManager.elements)
        {
            if (Input.GetKeyDown(e.hotkey))
            {
                string combineName = GetCombine(e, activeElement.name);
                if (combineName != "")
                {
                    foreach (Element element in elementManager.elements)
                    {
                        if (element.name == combineName)
                        {
                            activeElement = element;
                            element.active = true;
                            elementManager.combinationStance = false;
                        }
                    }
                }
            }
        }
    }

    string GetCombine(Element elementChosen, string elementActive)
    {
        string resultName = "";
        foreach (Element.PossibleCombinations comb in elementChosen.combinations)
        {
            if (comb.name == elementActive) {
                resultName = comb.combinationName;
            }
        }
        return resultName;
    }
    void RemoveElements() {
        //remover por key input? ou ui button action?
    }
}
