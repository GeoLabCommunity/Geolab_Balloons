using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

    public float Speed;
    

    // Tamashis gashvebisas pirveli eshveba punqcia Start (aseve arsebobs funcia Awake romelic Start amdeeshveba, sachiroebis shemtxvevashi iyeneben)
	void Start () {
	
    }	

    public void showExample()
    {
        gameObject.name = "withExample";
        GlobalParams.WithExample = true;
        int Jami = Random.Range(GlobalParams.minSum, GlobalParams.maxSum);
        GlobalParams.CorrectAnswer = Jami;
        int pirveli = Random.Range(0, Jami);
        int meore = Jami - pirveli;
        string magaliti = pirveli + "+" + meore;

        gameObject.transform.GetChild(0).gameObject.GetComponent<TextMesh>().text = magaliti;
    }
	
	//yovel Framze (kadrze) rac xdeba icereba update-Shi
	void Update () {
        // Translate - umatebs trasform.positions imdens ramdensac gadascemt parametrad 
        gameObject.transform.Translate(new Vector2(0, 1) * Speed);
	}

    // obieqtze mausit an tapit (telefonit) dajeris dapiqsireba - aucilebelia obieqtze idos raime tipis Collider i rom dapiqsirdes dachera
    void OnMouseDown()
    {
        print(gameObject.name);
    }

    void OnBecameInvisible()
    {
        if (gameObject.name == "withExample")
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
