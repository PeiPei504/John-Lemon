using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndTrigger : MonoBehaviour
{
    public GameObject player;
    bool isPlayerEscaped;
    float timer;
    public CanvasGroup escapedUI;
    float fadeDuration = 1f;
    public CanvasGroup getCaughtUI;
    bool IsPlayerCaught;

    void Update()
    {
        if (isPlayerEscaped)
            GameEnd(escapedUI, false);

        else if (IsPlayerCaught)
            GameEnd(getCaughtUI, true);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
            isPlayerEscaped = true;
    }

    public void CaughtPlayer()
    {
        IsPlayerCaught = true;
    }

    void GameEnd(CanvasGroup ui, bool restart)
    {
        timer += Time.deltaTime;

        ui.alpha = timer / fadeDuration;

        if (timer > fadeDuration + 1f)
        {
            if (restart)
                SceneManager.LoadScene(0);
            else
                Application.Quit();
        }
    }
}
