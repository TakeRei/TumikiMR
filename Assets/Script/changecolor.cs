using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changecolor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //アタッチするオブジェクトのRendererのComponentを取得する
        Renderer coloring = this.GetComponent<Renderer>();

        //RendererのMaterialにランダムな色を入れる
        coloring.material.color = new Color(Random.value, Random.value, Random.value, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
