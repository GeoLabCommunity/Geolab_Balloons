using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{

    public enum GameStates
    {
        Playing,
        GameOver,
        GamePaused
    }

    public static GameStates GameState;
    float timer;
    float OldTimer;
    
    public List<GameObject> Blns;
    public List<GameObject> Btns;
    public List<int> RandomNums;
    public GameObject Gameover_Panel;
    public GameObject Level_Panel;
    public List<GameObject> LevelList;
    int[] BlnArr = { -7, -5, -3,  -1,  1,  3, 5,  7 };
    int BlnArrayIndex;
    void Start()
    {
        InitLevel();
        timer = GlobalParams.SpawnRate;
        OldTimer = timer;
        timer = 0;
        GameState = GameStates.Playing;

        BlnArr.Shuffle();

    }

    void InitLevel()
    {
        LevelList[0].gameObject.GetComponent<LevelScript>().ActivateLevel();
        
    }

    public void LoadNextLevel ()
    {
        print("asdasdas");
        Level_Panel.SetActive(false);
       GameController.GameState =  GameStates.Playing;
         LevelList[GlobalParams.CurranteLevel-1].gameObject.GetComponent<LevelScript>().ActivateLevel();
    }

    void GenerateBtnsNumbers()
    {

        List<int> numbers = new List<int>();

        // marto es shevcvalot diapazonistvis (11 is nacvlad unda chavcerot stagebis 6, 10 , 15 , 20)
        for (int i = GlobalParams.MinSum; i < GlobalParams.MaxSum; i++)
        {
            if (GlobalParams.CorrectAnsw != i)
            {
                numbers.Add(i);
            }

        }
        List<int> randomNumbers = new List<int>();

        for (int i = 0; i < 5; i++)
        {
            int thisNumber = Random.Range(0, numbers.Count);
            randomNumbers.Add(numbers[thisNumber]);
            numbers.RemoveAt(thisNumber);
        }
        randomNumbers.Add(GlobalParams.CorrectAnsw);
        randomNumbers.Shuffle();

        for (int i = 0; i < Btns.Count; i++)
        {
            Btns[i].transform.GetChild(0).GetComponent<Text>().text = randomNumbers[i].ToString();
        }
    }
    void Update()
    {
        print(GameState);
        if (GameState == GameStates.GameOver) return;
        if (GameState == GameStates.GamePaused) return;

        switch (GlobalParams.Score)
        {
            case 1:
                AskForNextLevel(2);
                break;
            case 3:
                AskForNextLevel(3);
                break;
            case 5:
                AskForNextLevel(4);
                break;
        }

        timer -= Time.deltaTime;
       
        if (timer <= 0)
        {

            //კლონს რომ მივწვდეთ, ვაქცევთ "GameObject"-ად.
            if (BlnArrayIndex == BlnArr.Length-1)
            {
                BlnArr.Shuffle();
                BlnArrayIndex = 0;
            }
            else
                BlnArrayIndex++;

            GameObject InstanceBln = Instantiate(Blns[Random.Range(0, Blns.Count)], new Vector2(BlnArr[BlnArrayIndex], -8), Quaternion.identity) as GameObject;

            if (!GlobalParams.WithExample)
            {
                //მაშინ გამოვიძახოთ მაგალითიანი ბუშტი.
                InstanceBln.GetComponent<BallScript>().ShowExample(Random.Range(0,2));
                GenerateBtnsNumbers();
                GlobalParams.BlnWithExample = InstanceBln;
                
            }
            timer = OldTimer;
        }

        if(GameState != GameStates.GameOver && GlobalParams.Passedblns >= GlobalParams.Maxpassedblns)
        {
            
            Gameover_Panel.gameObject.SetActive(true);
            GameState = GameStates.GameOver;
        }
        

    }

    private void AskForNextLevel(int level)
    {
        GlobalParams.Score++;
        GameState = GameStates.GamePaused;
        Level_Panel.SetActive(true);
        Level_Panel.transform.FindChild("LevelText").gameObject.GetComponent<Text>().text = "ტური: " + level;
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