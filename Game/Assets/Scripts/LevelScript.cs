using UnityEngine;
using System.Collections;

public class LevelScript : MonoBehaviour {

    public int LevelN = 0;
    public int Min = 0;
    public int Max = 6;
    public float minSpeed = 1;
    public float maxSpeed = 5;
    public float SpawnRate = 0.5f;
    public int MaxScore = 10;
	
	void Start () {
	
	}
	
	public void ActivateLevel()
    {
        GlobalParams.CurranteLevel = LevelN;
        GlobalParams.MinSum = Min;
        GlobalParams.MaxSum = Max;
        GlobalParams.minSpeed = minSpeed;
        GlobalParams.maxSpeed = maxSpeed;
        GlobalParams.SpawnRate = SpawnRate;
		GlobalParams.MaxLevelScore = MaxScore;
        print("Levl is : " + LevelN);
    }

	void Update () {
	
	}
}
