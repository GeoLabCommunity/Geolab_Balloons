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
  

        List<int> numbers = new List<int>();

        // marto es shevcvalot diapazonistvis (11 is nacvlad unda chavcerot stagebis 6, 10 , 15 , 20)
        for (int i = 0; i < 11; i++) {
            if (GlobalParams.CorrectAnsw!=i)
            {
                numbers.Add(i);
            }
            
        }
        List<int> randomNumbers = new List<int>();
        
        for (int i = 0; i < 5; i++) {
            int  thisNumber = Random.Range(0, numbers.Count);
            randomNumbers.Add(numbers[thisNumber]);
            numbers.RemoveAt(thisNumber);
        }
        randomNumbers.Add(GlobalParams.CorrectAnsw);
        
        for (int i = 0; i < randomNumbers.Count; i++)
        {
            print(randomNumbers[i]);
        }
        







        for (int i = 0; i < Btns.Count; i++)
        {
            Btns[i].transform.GetChild(0).GetComponent<Text>().text = randomNumbers[i].ToString();
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