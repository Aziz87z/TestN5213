using UnityEngine;

public class PlaySoundOnClick : MonoBehaviour
{
    public AudioSource soundSource; // Поле для хранения ссылки на AudioSource

    private void Start()
    {
        // Найти AudioSource в иерархии, если не привязан вручную
        if (soundSource == null)
        {
            soundSource = GetComponent<AudioSource>();
        }
    }

    public void PlaySound()
    {
        // Проверка, что есть AudioSource и звук готов к воспроизведению
        if (soundSource != null && soundSource.clip != null)
        {
            soundSource.Play(); // Воспроизвести звук
        }
    }
}
