using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Gm;
    

    public int coins;
    public int health;

    private void awake()
    {
        if (Gm != null && Gm != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Gm = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
