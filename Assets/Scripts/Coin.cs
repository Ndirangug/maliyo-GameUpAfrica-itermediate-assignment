using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField]
    float turnSpeed = 90f;
    [SerializeField]
    private AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0, turnSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
            return;
        }

        //if we didn't collide with a player, we don't care
        if (other.gameObject.tag != "Player"){
            return;
        }

        // add to player's score
        GameManager.instance.Score++;

        AudioSource.PlayClipAtPoint(audioClip, transform.position);
        // destroy the coin
        Destroy(gameObject);
    }
}
