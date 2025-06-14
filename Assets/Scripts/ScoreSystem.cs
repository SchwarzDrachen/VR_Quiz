using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField]public UnityEvent onScoreUpdate;
    [SerializeField]private TextMeshProUGUI ScoreText;
    private int score;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ball")){
            score++;
            ScoreText.text = score.ToString();
        }
    }

    public void ResetScore(){
        score = 0;
        ScoreText.text = score.ToString();
    }
}
