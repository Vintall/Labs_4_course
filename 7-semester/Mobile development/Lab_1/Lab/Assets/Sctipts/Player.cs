using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HitCollider")
            OnGameOver();

        if (collision.gameObject.tag == "PassCollider")
            OnScoreAdd();
    }
    void OnGameOver()
    {
        GameController.Instance.GameOver();
    }
    void OnScoreAdd()
    {
        GameController.Instance.ScoreAdd();
    }
}
