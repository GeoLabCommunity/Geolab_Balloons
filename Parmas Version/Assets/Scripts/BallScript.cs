using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

    public float Speed;

    void Start() {
    }
       
        public void showExample()
    {
        gameObject.name = "WithExample";
        GlobalParams.WithExample = true;
        int jami = Random.Range(GlobalParams.MinSum, GlobalParams.MaxSum);
        GlobalParams.CorrectAnsw = jami;
        int pirveli = Random.Range(0, jami);
        int meore = jami - pirveli;
        string magaliti = pirveli + "+" + meore;

        gameObject.transform.GetChild(0).gameObject.GetComponent<TextMesh>().text = magaliti;
    }
   
	void Update () {

        gameObject.transform.Translate(new Vector2(0, 1) * Speed);
	
	}

   void OnBecameInvisible()
    {
        if(gameObject.name == "WithExample")
        GlobalParams.WithExample = false;
        Destroy(gameObject);
    }

    public void KillMe()
    {

        gameObject.GetComponent<Animator>().SetTrigger("TriggerBoom");


    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
