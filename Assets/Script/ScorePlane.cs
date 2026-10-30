using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePlane : MonoBehaviour
{
    public int addscore;

    public int addscoreProperty // ここでプロパティを使う。publicをつけます。
    {
        get { return addscore; }  // これがgetter。他のスクリプトから呼び出した時、returnのあとに書いた変数を返す。
        set { addscore = value; } // これがsetter。valueには他のスクリプトで代入された値が格納されます。（そこまで気にしなくて大丈夫。）
    }

    // Start is called before the first frame update
    void Start()
    {
        addscore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "tumiki")
        {
            addscore = 1;
        }
    }

    // 他のColliderとの衝突が終了したときに呼ばれる関数
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "tumiki")
        {
            addscore = 0;
        }
    }

}
