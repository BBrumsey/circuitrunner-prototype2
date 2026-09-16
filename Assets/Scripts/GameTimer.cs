using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public TMP_Text timerText;
    private float elaspedTime;
    private bool timerRunning = true;




    // Update is called once per frame
    void Update()
    {
        if (timerRunning)
        {
            elaspedTime += Time.deltaTime;

            int minutes = Mathf.FloorToInt(elaspedTime / 60);
            int seconds = Mathf.FloorToInt(elaspedTime % 60);

            timerText.text = minutes + ":" + seconds.ToString("00");

        }
    }

    public void StopTimer()
    {
        timerRunning = false;
    }
}
