using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using com.taptap.license.v2;
using UnityEngine.UI;

public class Login : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(Idel());

    }

    IEnumerator Idel()
    {
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(LoadSoleUpload());
    }

    // 单个物体：使用协程异步加载
    IEnumerator LoadSoleUpload()
    {
        ResourceRequest rr = Resources.LoadAsync<GameObject>("Prefabs/Main");
        yield return rr;
        GameObject _obj = Instantiate(rr.asset) as GameObject;
        _obj.name = rr.asset.name;
        _obj.AddComponent<Main>();

        Destroy(gameObject);
    }

}