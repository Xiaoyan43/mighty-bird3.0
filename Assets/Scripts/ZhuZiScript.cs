using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZhuZiScript : MonoBehaviour
{
    public float speed = 0.05f;

    public bool canMove = true;

    public void FixedUpdate()
    {
        if (!canMove) return;
        transform.Translate(-speed, 0, 0);
    }

    public void RandomHeight()
    {
        //2.07
        //-1.58
        float r = Random.Range(-1.58f, 2.07f);

        transform.SetPositionAndRotation(new Vector3(transform.position.x, r, transform.position.z), transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("撞到柱子了");
        if (GameContainer.Instance.resurrectionCoin > 0)
        {
            GameContainer.Instance.resurrectionCoin--;
            return;
        }
        GameObject.Find("GameMananger").GetComponent<GameMananger>().GameOver();
    }
}
