using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public string saveKey = "IsJumpscareKey";
    public Transform jumpscareCheckpoint;
    public Transform player;
    public TMP_Text gameOverText;
    public string gameOverMessage = "Game Over, Kamu Mati!";

    [Header("Debug")]
    public int isJumpscareSaved = 0;

    private void Awake()
    {
        isJumpscareSaved = PlayerPrefs.GetInt(saveKey);

        if (isJumpscareSaved == 1 )
        {
            player.position = jumpscareCheckpoint.position;
            player.rotation = jumpscareCheckpoint.rotation;
        }
    }

    public void StartJumpscare()
    {
        StartCoroutine(StartJumpscareDelay());
    }

    IEnumerator StartJumpscareDelay()
    {
        gameOverText.gameObject.SetActive(true);
        gameOverText.text = gameOverMessage;

        isJumpscareSaved = 1;
        PlayerPrefs.SetInt(saveKey, isJumpscareSaved);
        PlayerPrefs.Save();

        yield return new WaitForSeconds(2);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    [ContextMenu("Reset Jumpscare Save")]
    public void ResetJumpscareSave()
    {
        PlayerPrefs.DeleteKey(saveKey);
    }
}
