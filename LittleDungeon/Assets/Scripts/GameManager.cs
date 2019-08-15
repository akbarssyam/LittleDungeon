using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float turnDelay = 0.1f;
    public static GameManager instance = null;
    [HideInInspector] public bool playersTurn = true;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);


    }

    // Update is called once per frame
    void Update()
    {
        if (playersTurn)
            return;

        StartCoroutine(MoveEnemies());
    }

    IEnumerator MoveEnemies()
    {
        yield return new WaitForSeconds(turnDelay);

        playersTurn = true;
    }
}
