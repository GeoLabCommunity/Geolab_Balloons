using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public float Timer;
    float OldTimer;

    public List<GameObject> PosList;
    public List<GameObject> Blns;
    public List<GameObject> Btns;


	void Start () {
        // Timer shenaxva , shemdegi ganaxlebistvis
        OldTimer = Timer;

     

	}

	
	void Update () {

        Timer -= Time.deltaTime;

        if (Timer<=0)
        {
            Instantiate(Blns[Random.Range(0,Blns.Count)], PosList[Random.Range(0,PosList.Count)].transform.position, Quaternion.identity);
            Timer = OldTimer;
        }
	}

    //public void PrintName(Button btn)
    //{
    //    print(btn.transform.GetChild(0).gameObject.GetComponent<Text>().text);
    //}
}
