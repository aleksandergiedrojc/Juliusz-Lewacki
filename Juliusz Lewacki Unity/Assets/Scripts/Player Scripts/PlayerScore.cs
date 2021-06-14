using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{

    [SerializeField]
    
    private CameraScript cameraScript;

    private Vector3 previousPosition;
    private bool countScore; 

    public static int scoreCount;

    void Awake() {
        cameraScript = Camera.main.GetComponent<CameraScript> ();
    }
    // Start is called before the first frame update
    void Start()
    {
        previousPosition = transform.position;
        countScore = true;
    }

    // Update is called once per frame
    void Update()
    {
        CountScore ();
    }

    void CountScore() {
        if (countScore ) {
            if(transform.position.y < previousPosition.y) {
                scoreCount++;
            }
            previousPosition = transform.position;
            GameplayController.instance.SetScore(scoreCount);
        }

    } 

    void OnTriggerEnter2D(Collider2D target) {


        if (target.tag == "Bounds") {
            cameraScript.moveCamera = false;
            countScore = false;


            transform.position = new Vector3(500, 500, 0);
            GameManager.instance.CheckGameStatus(scoreCount);
        }

        if (target.tag == "Deadly") {
           cameraScript.moveCamera = false;
           countScore = false;


           transform.position = new Vector3(500, 500, 0);
           GameManager.instance.CheckGameStatus(scoreCount);
        
        }
    }
}


