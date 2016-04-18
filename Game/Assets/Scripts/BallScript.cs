using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

     float Speed;
	bool isPassable = true;
    void Start() {

        Speed = Random.Range(GlobalParams.minSpeed, GlobalParams.maxSpeed);
    }
       
    // tu a == 1 mashin gaakete jami, tu a ==  0 mashin gaakete gamokleba
        public void ShowExample(int a = 1)
       {

        gameObject.name = "WithExample";
        GlobalParams.WithExample = true;


        int jami = Random.Range(GlobalParams.MinSum, GlobalParams.MaxSum);
        GlobalParams.CorrectAnsw = jami;
        int pirveli = Random.Range(0, jami);
        int meore = jami - pirveli;
        string magaliti = "umagalitoa";
        if (a == 1)
        {
            magaliti = pirveli + "+" + meore;
        }
        else if (a==0)
        {
            magaliti = jami + " - " + pirveli;
            GlobalParams.CorrectAnsw = meore;
        }


        gameObject.transform.GetChild(0).gameObject.GetComponent<TextMesh>().text = magaliti;

    }

    
   
	void Update () {
        gameObject.transform.Translate(new Vector2(0, 1) * Speed);
	
	}

   void OnBecameInvisible()
    {
		if(gameObject.name == "WithExample" && isPassable)
        {
          GlobalParams.WithExample = false;
          GlobalParams.Passedblns++;
			GameController.instance.KillLife ();

        }
        
        Destroy(gameObject);
    }

    public void KillMe()
    {
		isPassable = false;

        GetComponent<AudioSource>().Play();
        GlobalParams.Score++;
        gameObject.GetComponent<Animator>().SetTrigger("TriggerBoom");
		GlobalParams.WithExample = false;

    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
