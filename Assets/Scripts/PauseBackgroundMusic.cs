using UnityEngine;

public class PauseBackgroundMusic : MonoBehaviour
{
    void Start()
    {
       BackgroundMusic.instance.gameObject.GetComponent<AudioSource>().Pause(); 
    }

}
