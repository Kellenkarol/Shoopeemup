using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject NaveInimiga, Asteroide, chuvaDeAsteroides;
    public GameObject[] NavesInimigaComRota;
    public float[] delayToSpawnEachNave; //cada elemento é respectivo aos elementos das NavesInimigaComRota
	private Transform[] _chuvaDeAsteroides;
	
    [Header("Chance de spawnar nave inimiga")]
	[Range(0.0f, 100.0f)]
	public float ChanceToSpawn;
    
    [Header("Chance de spawnar nave com rota")]
    [Range(0.0f, 100.0f)]
    public float ChanceToSpawnNaveRota;
    
    public Transform[] SpawnPoints;
    private int MinNumeroDeNavesNaRota=10;

    float randomNum;
    GameObject prefab, navePref;
    bool canSpawn=true;


    // Start is called before the first frame update
    void Start()
    {
        _chuvaDeAsteroides = new Transform[chuvaDeAsteroides.transform.childCount];
        for(int c=0; c<chuvaDeAsteroides.transform.childCount; c++)
        {
            _chuvaDeAsteroides[c] = chuvaDeAsteroides.transform.GetChild(c);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(canSpawn)
        {
            canSpawn = false;
            float r = UnityEngine.Random.Range(0,100);
            if(r < 0) //15%
            {
                StartCoroutine(ChuvaDeAsteroides(UnityEngine.Random.Range(0.35f,0.8f)));
            }
            else if(r < 100) //30%
            {
                StartCoroutine(SpawnNaveComRota(UnityEngine.Random.Range(2,6), UnityEngine.Random.Range(MinNumeroDeNavesNaRota,15)));
            }
            else //55%
            {
                StartCoroutine(SpawnRandom(UnityEngine.Random.Range(5,15), UnityEngine.Random.Range(1,3)));
            }

        }

    }


    private IEnumerator SpawnNaveComRota(float delay, int quant)
    {
        yield return new WaitForSeconds(delay);
        randomNum = UnityEngine.Random.Range(0,100);
        if(randomNum < ChanceToSpawnNaveRota)
        {
            int num = UnityEngine.Random.Range(0,NavesInimigaComRota.Length);
            navePref = NavesInimigaComRota[num];
            for(int c=0; c<quant; c++)
            {
                yield return new WaitForSeconds(delayToSpawnEachNave[num]);
                prefab = Instantiate(navePref);
                prefab.SetActive(true);
            }
        }
        yield return new WaitForSeconds(3);
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














