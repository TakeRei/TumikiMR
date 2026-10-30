using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTumiki : MonoBehaviour
{
    public GameObject[] tumiki;//配列の宣言
    public int foulcount;
    public int tumikicount;
    CountTumiki tumikicount2;
    CountTumiki2 tumikicount3;

    public int foulProperty // ここでプロパティを使う。publicをつけます。
    {
        get { return foulcount; }  // これがgetter。他のスクリプトから呼び出した時、returnのあとに書いた変数を返す。
        set { foulcount = value; } // これがsetter。valueには他のスクリプトで代入された値が格納されます。（そこまで気にしなくて大丈夫。）
    }

    public int countProperty // ここでプロパティを使う。publicをつけます。
    {
        get { return tumikicount; }  // これがgetter。他のスクリプトから呼び出した時、returnのあとに書いた変数を返す。
        set { tumikicount = value; } // これがsetter。valueには他のスクリプトで代入された値が格納されます。（そこまで気にしなくて大丈夫。）
    }

    void Start()
    {
        this.tumikicount2 = FindObjectOfType<CountTumiki>(); // インスタンス化
        this.tumikicount3 = FindObjectOfType<CountTumiki2>(); // インスタンス化
        foulcount = 0;
        tumikicount = 0;
    }

    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(tumikicount == 1)
        {
            if (other.gameObject.tag == "tumiki")
            {
                foulcount = 1;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "tumiki")
        {
            tumikicount = 1;
            other.gameObject.layer = LayerMask.NameToLayer("Destroy");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "tumiki")
        {
            tumikicount = 0;
            other.gameObject.layer = LayerMask.NameToLayer("Default");
        }
    }

    public void OnClickAdd()
    {
        if (tumikicount == 0)
        {
            int number = Random.Range(0, tumiki.Length);// tumiki 配列からランダムにインデックスを選択,配列からランダムに要素を選択
            Vector3 addcube = GameObject.Find("AddPosition_1").transform.position;// "AddPosition" という名前のゲームオブジェクトを探し、その位置を取得
            Instantiate(tumiki[number], new Vector3(addcube.x, addcube.y, addcube.z), Quaternion.identity);//ランダムに選択された tumiki のプレハブを addcube の位置に生成
        }

        else if(tumikicount == 1 && tumikicount2.countProperty2 == 0)
        {
            int number = Random.Range(0, tumiki.Length);// tumiki 配列からランダムにインデックスを選択,配列からランダムに要素を選択
            Vector3 addcube = GameObject.Find("AddPosition_2").transform.position;// "AddPosition_2" という名前のゲームオブジェクトを探し、その位置を取得
            Instantiate(tumiki[number], new Vector3(addcube.x, addcube.y, addcube.z), Quaternion.identity);//ランダムに選択された tumiki のプレハブを addcube の位置に生成
        }

        else if (tumikicount == 1 && tumikicount2.countProperty2 == 1 && tumikicount3.countProperty3 == 0)
        {
            int number = Random.Range(0, tumiki.Length);// tumiki 配列からランダムにインデックスを選択,配列からランダムに要素を選択
            Vector3 addcube = GameObject.Find("AddPosition_3").transform.position;// "AddPosition_3" という名前のゲームオブジェクトを探し、その位置を取得
            Instantiate(tumiki[number], new Vector3(addcube.x, addcube.y, addcube.z), Quaternion.identity);//ランダムに選択された tumiki のプレハブを addcube の位置に生成
        }
    }

}