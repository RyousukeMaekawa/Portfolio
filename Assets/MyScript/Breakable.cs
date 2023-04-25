using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// --- 壊せるオブジェクトに付ける Breakable スクリプト -------------------------
public class Breakable : MonoBehaviour
{

    float force = 3000f;             // 壊れるときに（爆発的に）かかる力


    // --- 壊れる処理。子オブジェクトを取得してそれぞれ ExplodePart させる ------
    public void Break()
    {
        foreach (Transform part in GetComponentInChildren<Transform>())
        {
            ExplodePart(part, force);
        }
        Destroy(gameObject, 10f);
    }


    // --- 部品にばらしてRigidbodyを付けてふっとばす --------------------------
    private void ExplodePart(Transform part, float force)
    {
        part.transform.parent = null;
        Rigidbody rb = part.gameObject.AddComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity = true;
        rb.AddExplosionForce(force, Vector3.zero, 3f);
        Destroy(part.gameObject, 1f);
    }


    // --- 衝突検出 ----------------------------------------------------------
    public void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("PlayerCharacter"))
        {
            //Debug.Log("コリジョンIF内です");
            Break();
        }
    }
}