using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField]private string prefabName;
    [SerializeField]private Transform parent;
    [SerializeField] private float BallSpawnDelay = 5;

    private bool hasBall = false;
    private void Start()
    {
        Debug.Log("Enabled SPawner");                
        BallScript.onBallGrab += ResetSpawnCountdown;
    }

    private void SpawnBall(){
        GameObject ball = ObjectPoolManager.Instance.Instantiate(prefabName,parent.position,parent.rotation);
        Debug.Log("Spawned");
        ball.gameObject.SetActive(true);
        ball.GetComponent<Rigidbody>().isKinematic = true;
    }

    void Update(){
        if(hasBall == false){
            SpawnBall();    
            hasBall = true;        
        }
    }

    public void ResetSpawnCountdown(){
        hasBall = false;
    }  
}
