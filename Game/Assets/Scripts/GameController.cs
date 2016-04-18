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

	public enum GameLevels
	{
		Level_1 =1,
		Level_2 =2,
		Level_3 =3,
		Level_4 =4,
		Level_5 =5
	}
	public static GameLevels GameLevel;
    public static GameStates GameState;
    float timer;
    float OldTimer;
    
    public List<GameObject> Blns;
    public List<GameObject> Btns;
    public List<int> RandomNums;
    public GameObject Gameover_Panel;
    public GameObject Level_Panel;
    public List<GameObject> LevelList;
	public GameObject LifeGo;
	public static GameController instance = null;
    
    int[] BlnArr = { -7, -5, -3,  -1,  1,  3, 5,  7 };
    int BlnArrayIndex;
    void Start()
    {
		print (GameLevel);

			instance = this;
		GlobalParams.Passedblns = 0;
		GameState = GameStates.Playing;

		
        InitLevel();
        timer = GlobalParams.SpawnRate;
        OldTimer = timer;
        timer = 0;

        BlnArr.Shuffle();
    }

    void InitLevel()
    {
        LevelList[0].gameObject.GetComponent<LevelScript>().ActivateLevel();
        
    }

    public void LoadNextLevel ()
    {
        Level_Panel.SetActive(false);
        GameState =  GameStates.Playing;
        LevelList[GlobalParams.CurranteLevel].gameObject.GetComponent<LevelScript>().ActivateLevel();
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
        if (GameState == GameStates.GameOver) return;
        if (GameState == GameStates.GamePaused) return;

        switch (GlobalParams.Score)
        {
            case 1:
			if (GameLevel !=GameLevels.Level_1)
                AskForNextLevel(2);
                break;
            case 2:
			if (GameLevel !=GameLevels.Level_2)
                AskForNextLevel(3);
                break;
            case 15:
			if (GameLevel !=GameLevels.Level_3)
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
		//GameLevel= level;
        GlobalParams.Score++;
        GameState = GameStates.GamePaused;
        Level_Panel.SetActive(true);
        Level_Panel.transform.FindChild("LevelText").gameObject. GetComponent<Text>().text = "ტური: " + level;
    }


    public  void KillLife()
    {
       // if (LifesGO.transform.childCount == 0) return;
		Destroy(GameController.instance.LifeGo.transform.GetChild(0).gameObject);

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