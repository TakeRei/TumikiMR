using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountTumiki2 : MonoBehaviour
{
    public int foulcount3;
    public int tumikicount3;

    public int countProperty3 // ここでプロパティを使う。publicをつけます。
    {
        get { return tumikicount3; }  // これがgetter。他のスクリプトから呼び出した時、returnのあとに書いた変数を返す。
        set { tumikicount3 = value; } // これがsetter。valueには他のスクリプトで代入された値が格納されます。（そこまで気にしなくて大丈夫。）
    }

    public int foulProperty3 // ここでプロパティを使う。publicをつけます。
    {
        get { return foulcount3; }  // これがgetter。他のスクリプトから呼び出した時、returnのあとに書いた変数を返す。
        set { foulcount3 = value; } // これがsetter。valueには他のスクリプトで代入された値が格納されます。（そこまで気にしなくて大丈夫。）
    }

    void Start()
    {
        foulcount3 = 0;
        tumikicount3 = 0;
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (tumikicount3 == 1)
        {
            if (other.gameObject.tag == "tumiki")
            {
                foulcount3 = 1;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "tumiki")
        {
            tumikicount3 = 1;
            other.gameObject.layer = LayerMask.NameToLayer("Destroy");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "tumiki")
        {
            tumikicount3 = 0;
            other.gameObject.layer = LayerMask.NameToLayer("Default");
        }
    }

}