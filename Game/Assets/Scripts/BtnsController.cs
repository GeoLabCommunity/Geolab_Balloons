using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BtnsController : MonoBehaviour {

	public void KillBalloon(Text BtnText)
    {
        if (BtnText.text == GlobalParams.CorrectAnsw.ToString())
        {
            if (GlobalParams.BlnWithExample!=null)
                GlobalParams.BlnWithExample.GetComponent<BallScript>().KillMe();

        }
        else
        {
            GameController.instance.KillLife();
        }
            
    }
}
