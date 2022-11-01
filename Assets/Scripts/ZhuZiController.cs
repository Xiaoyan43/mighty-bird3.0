using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZhuZiController : MonoBehaviour
{
    public Transform ZhuZis;
    public GameObject ZhuZiPrefab;

    public GameMananger gm;

    public float SpawnTime = 1f;

    private List<GameObject> zhuzis = new List<GameObject>();

    public bool ZhuZiIsMove = true;

    public void Start()
    {
        StartCoroutine(SpawnZhuZi());
    }

    /// <summary>
    /// 开始所有柱子的移动
    /// </summary>
    public void StartMove()
    {
        ZhuZiIsMove = true;
        foreach (GameObject item in zhuzis)
        {
            item.GetComponent<ZhuZiScript>().canMove = true;
        }
    }

    /// <summary>
    /// 停止所有柱子的移动
    /// </summary>
    public void StopMove()
    {
        ZhuZiIsMove = false;
        foreach (GameObject item in zhuzis)
        {
            item.GetComponent<ZhuZiScript>().canMove = false;
        }
    }

    public void SpawnOneZhuZi()
    {
        GameObject zhuzi = GameObject.Instantiate(ZhuZiPrefab, ZhuZis);
        zhuzi.GetComponent<ZhuZiScript>().RandomHeight();

        zhuzis.Add(zhuzi);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            //SpawnOneZhuZi();
            StopMove();
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            //SpawnOneZhuZi();
            StartMove();
        }
    }

    IEnumerator SpawnZhuZi()
    {
        while (true)
        {
            yield return new WaitForSeconds(SpawnTime);
            if (!gm.isGameStart) continue;
            if (!ZhuZiIsMove) continue;
            SpawnOneZhuZi();
        }
        
    }
}
