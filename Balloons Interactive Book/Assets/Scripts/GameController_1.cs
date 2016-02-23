using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameController_1 : MonoBehaviour
{

    public float Timer;
    float OldTimer;

    public List<GameObject> PosList;
    public List<GameObject> Blns;
    public List<GameObject> Btns;
    int counter = 3;

	void Start () {
        // Timer shenaxva , shemdegi ganaxlebistvis
        OldTimer = Timer;

        //int Jami = Random.Range(1, 10);
        //int pirveli = Random.Range(0, Jami);
        //int meore = Jami - pirveli;

        //print(pirveli + " + " + meore + " = " + Jami);

	}

	
	void Update () {

        if (counter <= 0) return;

        Timer -= Time.deltaTime;
        if (Timer<=0)
        {
            counter--;
            Instantiate(Blns[Random.Range(0,Blns.Count)], PosList[Random.Range(0,PosList.Count)].transform.position, Quaternion.identity);
            Timer = OldTimer;
        }
	}

    //public void PrintName(Button btn)
    //{
    //    print(btn.transform.GetChild(0).gameObject.GetComponent<Text>().text);
    //}
}
