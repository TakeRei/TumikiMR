using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FraudPreventionBox2 : MonoBehaviour
{
    public int foulcount5;

    CountTumiki tumikicount2;

    public int foulProperty5 // ここでプロパティを使う。publicをつけます。
    {
        get { return foulcount5; }  // これがgetter。他のスクリプトから呼び出した時、returnのあとに書いた変数を返す。
        set { foulcount5 = value; } // これがsetter。valueには他のスクリプトで代入された値が格納されます。（そこまで気にしなくて大丈夫。）
    }

    // Start is called before the first frame update
    void Start()
    {
        foulcount5 = 0;
        this.tumikicount2 = FindObjectOfType<CountTumiki>(); // インスタンス化
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (tumikicount2.countProperty2 == 1)
        {
            if (other.gameObject.tag == "tumiki")
            {
                foulcount5 = 1;
            }
        }
    }
}
