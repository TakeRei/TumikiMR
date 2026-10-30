using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountScore : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI TumikiNumber;
    int score; //今回他のスクリプトからアクセス・変更したい変数
    float height;
    float addTime;
    public bool addscore;
    public GameObject scoreplane;

    public int countProperty // ここでプロパティを使う。publicをつけます。
    {
        get { return score; }  // これがgetter。他のスクリプトから呼び出した時、returnのあとに書いた変数を返す。
        set { score = value; } // これがsetter。valueには他のスクリプトで代入された値が格納されます。（そこまで気にしなくて大丈夫。）
    }

    void Start()
    {
        score = 0;
        height = -0.875f;
        addscore = false;
        addTime = 0.0f;
    }

    void Update()
    {
        // Debug.Log(addTime);
        TumikiNumber.text = score.ToString();
        float newY = height;

        Vector3 newPosition = transform.position;
        newPosition.y = newY;

        transform.position = newPosition;

        // 衝突相手との重なり続ける時間が5.0秒を超えたら、得点を加算し、addTimeをリセットする
        if (addscore)
        {

            addTime += Time.deltaTime;

            if (addTime >= 4.0f)
            {
                score += 5;
                height += 0.125f;
                addscore = false;
                addTime = 0.0f;
            }
        }
    }

    // 他のColliderと重なり続けているときに呼ばれる関数
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "tumiki")
        {
            addscore = true;
        }
    }

    // 他のColliderとの衝突が終了したときに呼ばれる関数
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "tumiki")
        {
            addscore = false;
            addTime = 0.0f;
        }
    }

    public void GrabObject()
    {
        scoreplane.SetActive(false);
    }

    public void ReleaseObject()
    {
        scoreplane.SetActive(true);
    }
}
