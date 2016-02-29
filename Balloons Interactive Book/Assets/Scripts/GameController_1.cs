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
    public List<int> RandomNums;

	void Start () {
        // Timer shenaxva , shemdegi ganaxlebistvis
        OldTimer = Timer;

	}


    void GenerateBtnNumbers ()
    {

        for (int i = 0; i < Btns.Count - 1; i++)
        {
            int randomToAdd = Random.Range(GlobalParams.minSum, GlobalParams.maxSum);
            if (randomToAdd != GlobalParams.CorrectAnswer)
            {
                RandomNums.Add(randomToAdd);
            }
            else
            {
                RandomNums.Add(randomToAdd+1);
            }
        }
        RandomNums.Add(GlobalParams.CorrectAnswer);
        RandomNums.Shuffle();

        for (int i = 0; i < Btns.Count; i++)
        {
            Btns[i].transform.GetChild(0).GetComponent<Text>().text = RandomNums[i].ToString();
        }


    }
	
	void Update () {

        Timer -= Time.deltaTime;
        if (Timer<=0)
        {
            // klons rom mivcdet vaqcevt gameObject ad 
            GameObject InstanceBln = Instantiate(Blns[Random.Range(0,Blns.Count)], PosList[Random.Range(0,PosList.Count)].transform.position, Quaternion.identity) as GameObject;
            

            if (!GlobalParams.WithExample)
            {
                // mashi gamovidzaxot  magalitiani bushti.
                InstanceBln.GetComponent<BallScript>().showExample();
                GenerateBtnNumbers();
                GlobalParams.BlnWithExample = InstanceBln;
            }
            Timer = OldTimer;
        }
	}



}


static class MyExtensions
{
    public static void Shuffle<T>(this IList<T> list)
    {
        System.Random rng = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
