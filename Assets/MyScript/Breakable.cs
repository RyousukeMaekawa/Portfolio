using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// --- �󂹂�I�u�W�F�N�g�ɕt���� Breakable �X�N���v�g -------------------------
public class Breakable : MonoBehaviour
{

    float force = 3000f;             // ����Ƃ��Ɂi�����I�Ɂj�������


    // --- ���鏈���B�q�I�u�W�F�N�g���擾���Ă��ꂼ�� ExplodePart ������ ------
    public void Break()
    {
        foreach (Transform part in GetComponentInChildren<Transform>())
        {
            ExplodePart(part, force);
        }
        Destroy(gameObject, 10f);
    }


    // --- ���i�ɂ΂炵��Rigidbody��t���Ăӂ��Ƃ΂� --------------------------
    private void ExplodePart(Transform part, float force)
    {
        part.transform.parent = null;
        Rigidbody rb = part.gameObject.AddComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity = true;
        rb.AddExplosionForce(force, Vector3.zero, 3f);
        Destroy(part.gameObject, 1f);
    }


    // --- �Փˌ��o ----------------------------------------------------------
    public void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("PlayerCharacter"))
        {
            //Debug.Log("�R���W����IF���ł�");
            Break();
        }
    }
}