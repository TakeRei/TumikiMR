using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FraudPreventionBox1 : MonoBehaviour
{
    public int foulcount4;

    AddTumiki tumikicount;

    public int foulProperty4 // ここでプロパティを使う。publicをつけます。
    {
        get { return foulcount4; }  // これがgetter。他のスクリプトから呼び出した時、returnのあとに書いた変数を返す。
        set { foulcount4 = value; } // これがsetter。valueには他のスクリプトで代入された値が格納されます。（そこまで気にしなくて大丈夫。）
    }

    // Start is called before the first frame update
    void Start()
    {
        foulcount4 = 0;
        this.tumikicount = FindObjectOfType<AddTumiki>(); // インスタンス化
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (tumikicount.countProperty == 1)
        {
            if (other.gameObject.tag == "tumiki")
            {
                foulcount4 = 1;
            }
        }
    }
}
