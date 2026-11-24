using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Menu_Manager : MonoBehaviour
{
    public static Menu_Manager Instance;
    public bool 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    
    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleMute (bool mute)
    {
        AudioListener.volume = mute ? 0 : 1;

        isMuted = mute;
    }

    public void SetVolume (float desiredVolume)
    {
        if (isMuted) return;
        AudioListener.volume = desiredVolume;
        ProbeVolumeTextureMemoryBudget.text = $"Volume: {{ desiredVolume * 100).ToString("F0")}%";
    }
}
