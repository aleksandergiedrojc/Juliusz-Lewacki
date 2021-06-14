using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGCollector : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D target) {
        if(target.tag == "Background") {
            target.gameObject.SetActive(false);

    }

        
    }
}
