using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountTumiki : MonoBehaviour
{
    public int foulcount2;
    public int tumikicount2;
    
    public int countProperty2 // ここでプロパティを使う。publicをつけます。
    {
        get { return tumikicount2; }  // これがgetter。他のスクリプトから呼び出した時、returnのあとに書いた変数を返す。
        set { tumikicount2 = value; } // これがsetter。valueには他のスクリプトで代入された値が格納されます。（そこまで気にしなくて大丈夫。）
    }

    public int foulProperty2 // ここでプロパティを使う。publicをつけます。
    {
        get { return foulcount2; }  // これがgetter。他のスクリプトから呼び出した時、returnのあとに書いた変数を返す。
        set { foulcount2 = value; } // これがsetter。valueには他のスクリプトで代入された値が格納されます。（そこまで気にしなくて大丈夫。）
    }

    void Start()
    {
        foulcount2 = 0;
        tumikicount2 = 0;   
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (tumikicount2 == 1)
        {
            if (other.gameObject.tag == "tumiki")
            {
                foulcount2 = 1;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "tumiki")
        {
            tumikicount2 = 1;
            other.gameObject.layer = LayerMask.NameToLayer("Destroy");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "tumiki")
        {
            tumikicount2 = 0;
            other.gameObject.layer = LayerMask.NameToLayer("Default");
        }
    }

}