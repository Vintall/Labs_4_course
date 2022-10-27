using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    static UIController instance;
    public static UIController Instance => instance;
    [SerializeField] UnityEngine.UI.Text score_field;
    [SerializeField] UnityEngine.UI.Button pause_button;
    [SerializeField] Sprite pause_sprite;
    [SerializeField] Sprite play_sprite;

    bool is_paused = false;

    public void OnPauseButtonPressed()
    {
        is_paused = !is_paused;

        if (is_paused)
            OnStartPause();
        else
            OnEndPause();
    }
    void OnStartPause()
    {
        pause_button.GetComponent<UnityEngine.UI.Image>().sprite = play_sprite;
        Time.timeScale = 0;
    }
    void OnEndPause()
    {
        pause_button.GetComponent<UnityEngine.UI.Image>().sprite = pause_sprite;
        Time.timeScale = 1;
    }



    public void OnLeftButtonPressed()
    {
        GameController.Instance.OnLeftButtonPressed();
    }
    public void OnRightButtonPressed()
    {
        GameController.Instance.OnRightButtonPressed();
    }

    public int Score
    { 
        get
        {
            return int.Parse(score_field.text);
        }
        set
        {
            score_field.text = "Score: " + value.ToString();
        }
    }
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
}
