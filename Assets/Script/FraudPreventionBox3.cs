using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FraudPreventionBox3 : MonoBehaviour
{
    public int foulcount6;

    CountTumiki2 tumikicount3;

    public int foulProperty6 // ここでプロパティを使う。publicをつけます。
    {
        get { return foulcount6; }  // これがgetter。他のスクリプトから呼び出した時、returnのあとに書いた変数を返す。
        set { foulcount6 = value; } // これがsetter。valueには他のスクリプトで代入された値が格納されます。（そこまで気にしなくて大丈夫。）
    }

    // Start is called before the first frame update
    void Start()
    {
        foulcount6 = 0;
        this.tumikicount3 = FindObjectOfType<CountTumiki2>(); // インスタンス化
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (tumikicount3.countProperty3 == 1)
        {
            if (other.gameObject.tag == "tumiki")
            {
                foulcount6 = 1;
            }
        }
    }
}
