using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{

    public Text scoreText;
    public GameObject targetObject;

    int hits=0;

    // Start is called before the first frame update
         private void OnCollisionEnter(Collision collision) {
         if (collision.gameObject != targetObject)
        {
            hits++;
            scoreText.text = hits.ToString();
        }
    }
}
