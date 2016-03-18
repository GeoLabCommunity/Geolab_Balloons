using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameController : MonoBehaviour {


    public float timer;
     float OldTimer;

    public List<GameObject> PosList;
    public List<GameObject> Blns;
    public List<GameObject> Btns;
    public List<int> RandomNums;

	void Start () {

        OldTimer = timer;
        
        }

    void GenerateBtnsNumbers ()
    {
        RandomNums.Clear();

        for (int i = 0; i < Btns.Count - 1; i++)
        {
            int randomToAdd = Random.Range(GlobalParams.MinSum, GlobalParams.MaxSum);
            if (randomToAdd != GlobalParams.CorrectAnsw)
            {
                RandomNums.Add(randomToAdd);
            }
            else
            {
                RandomNums.Add(randomToAdd + 1);
            }
        }
        RandomNums.Add(GlobalParams.CorrectAnsw);

        RandomNums.Shuffle();

        for (int i = 0; i < Btns.Count; i++)
        {
            Btns[i].transform.GetChild(0).GetComponent<Text>().text = RandomNums[i].ToString();
        }
    }
	void Update () {

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            //კლონს რომ მივწვდეთ, ვაქცევთ "GameObject"-ად.
            GameObject InstanceBln = Instantiate(Blns[Random.Range(0, Blns.Count)], PosList[Random.Range(0, PosList.Count)].transform.position, Quaternion.identity) as GameObject;
           
            if (!GlobalParams.WithExample)
            {
                //მაშინ გამოვიძახოთ მაგალითიანი ბუშტი.
                InstanceBln.GetComponent<BallScript>().showExample();
                GenerateBtnsNumbers();
               GlobalParams.BlnWithExample = InstanceBln;
            }
            timer = OldTimer;
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