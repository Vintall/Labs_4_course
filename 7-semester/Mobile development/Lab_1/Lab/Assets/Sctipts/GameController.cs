using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] float runway_speed = 2;
    [SerializeField] float generation_delay; // in seconds
    [SerializeField] Transform player;
    [SerializeField] Transform game_over;
    [SerializeField] UnityEngine.UI.Text game_over_score;

    [SerializeField] GameObject brick_asset;
    [SerializeField] Transform bricks_holder;
    [SerializeField] ObstructionGenerator obstruction_generator;

    public Transform BricksHolder => bricks_holder;
    public GameObject BrickAsset => brick_asset;


    public float GenerationDelay => generation_delay;
    public float RunwaySpeed => runway_speed;

    static GameController instance;
    public static GameController Instance => instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }


    int score = 0;


    int player_pos = 0;

    public void OnLeftButtonPressed()
    {
        if (player_pos == -1)
            return;

        player_pos --;

        player.position = new Vector3(player_pos * 1.5f, player.position.y, player.position.z);
    }
    public void OnRightButtonPressed()
    {
        if (player_pos == 1)
            return;

        player_pos++;

        player.position = new Vector3(player_pos * 1.5f, player.position.y, player.position.z);
    }



    bool is_game_over = false;
    public void GameOver()
    {
        is_game_over = true;
        Time.timeScale = 0;

        game_over.gameObject.SetActive(true);
        obstruction_generator.ClearObstructions();
        game_over_score.text = "Score: " + score.ToString();
        UIController.Instance.Score = 0;
        score = 0;
    }
    public void RestartGame()
    {
        is_game_over = false;
        Time.timeScale = 1;

        
        game_over.gameObject.SetActive(false);
    }
    public void ScoreAdd()
    {
        score++;
        UIController.Instance.Score = score;
    }
}
