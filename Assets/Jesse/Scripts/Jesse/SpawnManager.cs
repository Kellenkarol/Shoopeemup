using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject NaveInimiga, Asteroide, chuvaDeAsteroides;
    public GameObject[] NavesInimigaComRota;
    public float[] delayToSpawnEachNave;
	private Transform[] _chuvaDeAsteroides;
	public float SpawnDelay;
	
    [Header("Chance de spawnar nave inimiga")]
	[Range(0.0f, 100.0f)]
	public float ChanceToSpawn;
    
    [Header("Chance de spawnar nave com rota")]
    [Range(0.0f, 100.0f)]
    public float ChanceToSpawnNaveRota;
    
    public Transform[] SpawnPoints;
    private float NumeroDeNavesNaRota=10, delayToSpawn=0.45f;

    float timeAux, countAux, randomNum;
    GameObject prefab, navePref;
    bool AlreadySpawnAll=true, spawnNaveComRota, canSpawn=true;


    // Start is called before the first frame update
    void Start()
    {
        _chuvaDeAsteroides = new Transform[chuvaDeAsteroides.transform.childCount];
        for(int c=0; c<chuvaDeAsteroides.transform.childCount; c++)
        {
            _chuvaDeAsteroides[c] = chuvaDeAsteroides.transform.GetChild(c);
        }
        // StartCoroutine(SpawnNaveComRota(10f));
    }


    // Update is called once per frame
    void Update()
    {
        if(canSpawn)
        {
            canSpawn = false;
            float r = UnityEngine.Random.Range(0,100);
            if(r < 15) //15%
            {
                StartCoroutine(ChuvaDeAsteroides(UnityEngine.Random.Range(0.4f,0.9f)));
            }
            else if(r < 45) //30%
            {
                StartCoroutine(SpawnNaveComRota(UnityEngine.Random.Range(2,6)));
            }
            else //55%
            {
                StartCoroutine(SpawnRandom(UnityEngine.Random.Range(5,15), UnityEngine.Random.Range(1,3)));
            }

        }

    }


    private IEnumerator SpawnNaveComRota(float delay)
    {
        yield return new WaitForSeconds(delay);
        randomNum = UnityEngine.Random.Range(0,100);
        if(randomNum < ChanceToSpawnNaveRota)
        {
            // navePref = NavesInimigaComRota[3];
            int num = UnityEngine.Random.Range(0,NavesInimigaComRota.Length);
            navePref = NavesInimigaComRota[num];
            for(int c=0; c<NumeroDeNavesNaRota; c++)
            {
                yield return new WaitForSeconds(delayToSpawnEachNave[num]);
                prefab = Instantiate(navePref);
                prefab.SetActive(true);
            }
        }
        yield return new WaitForSeconds(4);
        canSpawn = true;

        // StartCoroutine(SpawnNaveComRota(delay));

    }


    private IEnumerator ChuvaDeAsteroides(float delay)
    {
        foreach(Transform t in _chuvaDeAsteroides)
        {
            yield return new WaitForSeconds(delay);
    		prefab = Instantiate(Asteroide) as GameObject;
        	prefab.transform.position = t.position;
            prefab.transform.rotation = t.rotation;
        }
        canSpawn = true;
    }


    private IEnumerator SpawnRandom(int objects, float delay)
    {
        for(int c=0; c<objects; c++)
        {
            yield return new WaitForSeconds(delay);
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
        canSpawn = true;
    }
}














