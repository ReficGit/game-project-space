using UnityEngine;
using System.Collections;

public class CreateAndManageMobs : MonoBehaviour
{
    float k;

    Transform spawnPoint;
    public GameObject MobSphere;
    GameMode gameModeScript;

    // Use this for initialization


    // number of different types mobs per in current wave.	
    public int currentWaveTanksNumber;
    public int currentWaveHealerNumber;
	public int currentWaveFastNumber;


    void Start()
    {
        k = 0;
        currentWaveTanksNumber = 5;
        spawnPoint = GameObject.Find("SpawnPoint").GetComponent<Transform>();
        gameModeScript = GameObject.Find("ManagerScripts").GetComponent<GameMode>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameModeScript.gameModePause && !gameModeScript.gameModeGameOver) // if game is countinue than we spawn mobs.
        {
            if (k <= 0f && currentWaveTanksNumber > 0)
            {
                //GameObject go;		// -- commented because in current situation we do not need to control objects from separate script.	
                Instantiate(MobSphere, spawnPoint.position, spawnPoint.rotation);
                k = 1f;
                --currentWaveTanksNumber;
            }
            k -= Time.deltaTime;
        }		
    }
}
