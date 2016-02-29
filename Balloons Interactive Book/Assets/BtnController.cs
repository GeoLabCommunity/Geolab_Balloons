using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BtnController : MonoBehaviour {

    public void KillBalloon(Text btnText)
    {
        if (btnText.text == GlobalParams.CorrectAnswer.ToString())
        {
            print("Gaxetqe bushti");
            GlobalParams.BlnWithExample.GetComponent<BallScript>().KillMe();
        }
    }
}
