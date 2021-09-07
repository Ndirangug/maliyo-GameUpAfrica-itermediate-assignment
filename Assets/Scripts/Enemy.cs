using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject rockPrefab;
    GameObject rock;
    
    [SerializeField] Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ThrowBall(){
       
        Debug.Log("ThrowBall");
        GameObject.FindObjectOfType<Rock>().Release();
    }

    public void CollectRock(){
        GameObject enemyHand = GameObject.FindGameObjectsWithTag("ThrowingHand")[0];
        Instantiate(rockPrefab, enemyHand.transform);
    }
}
