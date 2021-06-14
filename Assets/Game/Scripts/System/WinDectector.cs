using System.Collections;
using System.Collections.Generic;
using GameJam.Manager;
using TMPro;
using UnityEngine;

public class WinDectector : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI WinText;

    private void Start() {
        if(GameManager.GetInstance().GetPlayer1Score() > GameManager.GetInstance().GetPlayer2Score()){
            WinText.SetText("Player 1 Win!");
        }else if(GameManager.GetInstance().GetPlayer1Score() < GameManager.GetInstance().GetPlayer2Score()){
            WinText.SetText("Player 2 Win!");
        }else{
            WinText.SetText("Draw!");
        }
    }
}
