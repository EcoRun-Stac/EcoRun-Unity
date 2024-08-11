using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewSpawner : MonoBehaviour
{
    public GameObject CoinPrefab;
    public GameObject EnemyPrefab;
    public float timeBetSpawnMin = 0f;
    public float timeBetSpawnMax = 10f;
    private float timeBetSpawn; //������ġ������ �ð� ����
    private float xPos = 20f; // x ��ȯ ��ġ
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
            //��ϵ� ������ ��ġ ������ ���� �������� ����
            this.lastSpawnTime = Time.time;
            //���� ��ġ������ �ð� ������ ���̿��� ���� ����
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