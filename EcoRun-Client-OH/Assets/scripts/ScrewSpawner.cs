using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewSpawner : MonoBehaviour
{
    public GameObject CoinPrefab;
    public GameObject EnemyPrefab;
    public float timeBetSpawnMin = 0f;
    public float timeBetSpawnMax = 10f;
    private float timeBetSpawn; //다음배치까지의 시간 간격
    private float xPos = 20f; // x 소환 위치
    private float lastSpawnTime;
    public int time = 0;
    // Start is called before the first frame update
    void Start()
    {
        this.timeBetSpawn = 0;
        this.lastSpawnTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time++;
        if (Time.time >= lastSpawnTime + timeBetSpawn)
        {
            //기록된 마지막 배치 시점을 현재 시점으로 갱신
            this.lastSpawnTime = Time.time;
            //다음 배치까지의 시간 간격을 사이에서 랜덤 설정
            this.timeBetSpawn = 0.2f;
            //
            newObject();
        }
    }
    public void newObject()
    {
        if (time%10 == 3)
        {
            Instantiate(EnemyPrefab, new Vector3(14.23f, -1.415f, 0), Quaternion.identity);
        }
        else
        {
            Instantiate(CoinPrefab, new Vector3(14.23f, -1.415f, 0), Quaternion.identity);
        }
    }
}