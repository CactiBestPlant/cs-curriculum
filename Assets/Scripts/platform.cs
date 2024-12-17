using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformScript : MonoBehaviour
{


    private Vector3 direction;
    private GameManager gameManager;
    private PlatScript playerController;
    private float changetime;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        playerController = GetComponent<PlatScript>();
        gameManager = GetComponent<GameManager>();
        changetime = 2000;
        direction = new Vector3(20, 0, 0);



    }

    // Update is called once per frame
    void Update()
    {

        changetime -= 1;
        if (changetime < 1 && direction.x == -20)//((playerController.playerX < current.x) && (changetime<1))
        {
            direction = new Vector3(20, 0, 0);
            changetime = 2000;
        }
        if (changetime < 1 && direction.x == 20)//((playerController.playerX > current.x) && (changetime < 1))
        {
            direction = new Vector3(-20, 0, 0);
            changetime = 2000;
        }

        transform.position += ((direction * Time.deltaTime) * 0.06f);


    }




}