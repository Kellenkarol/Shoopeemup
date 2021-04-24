using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject NaveInimiga, Asteroide;
	public GameObject[] NavesInimigaComRota;
	public float SpawnDelay;
	[Header("Chance de spawnar nave inimiga")]
	[Range(0.0f, 100.0f)]
	public float ChanceToSpawn;
    [Header("Chance de spawnar nave com rota")]
    [Range(0.0f, 100.0f)]
    public float ChanceToSpawnNaveRota;
    public Transform[] SpawnPoints;
    private float NumeroDeNavesNaRota=8, delayToSpawn=0.45f;
    float timeAux, countAux, randomNum;
    GameObject prefab, navePref;
    bool AlreadySpawnAll=true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeAux += Time.deltaTime;
        if(AlreadySpawnAll)
        {
            if(timeAux >= SpawnDelay)
            {
            	timeAux = 0;
                randomNum = UnityEngine.Random.Range(0,100);
                print(randomNum);
                if(randomNum >= ChanceToSpawnNaveRota)
                {
                	randomNum = UnityEngine.Random.Range(0,100);
                	if(randomNum <= ChanceToSpawn)
                	{
                        prefab = Instantiate(NaveInimiga) as GameObject;
                	}
                	else
                	{
                		prefab = Instantiate(Asteroide) as GameObject;
                	}
                    int randomOtherNum = UnityEngine.Random.Range(0, SpawnPoints.Length);
                	prefab.transform.position = SpawnPoints[randomOtherNum].position;
                    prefab.transform.rotation = SpawnPoints[randomOtherNum].rotation;
                }
                else
                {
                    AlreadySpawnAll = false;
                    timeAux = -3;
                    navePref = NavesInimigaComRota[UnityEngine.Random.Range(0,NavesInimigaComRota.Length)];
                }
            }
        }
        else if(timeAux >= delayToSpawn)
        {      
            timeAux = 0;
            countAux++;
            prefab = Instantiate(navePref) as GameObject;
            prefab.SetActive(true);
            if(countAux >= NumeroDeNavesNaRota)
            {
                countAux = 0;
                AlreadySpawnAll = true;
            }
        }
    }
}
