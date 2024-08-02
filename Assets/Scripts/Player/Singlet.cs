using UnityEngine;

public class Singlet : MonoBehaviour
{
    public static Singlet instance;

    private void Awake()
    {
        if (instance == null)
        {
            // Если нет других экземпляров, сделать этот экземпляр Singleton
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            // Если есть другие экземпляры, уничтожить этот
            Destroy(gameObject);
        }
    }
}
