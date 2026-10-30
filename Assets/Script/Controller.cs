using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Controller : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI TumikiNumber;
    int score; //今回他のスクリプトからアクセス・変更したい変数
    public bool morepoint;
    public bool morepoint2;
    public bool releasecount;  
    float height;
    float addTime;
    float morepointTime;
    float morepointTime2;
    public GameObject scoreplane;

    ScorePlane addscore;

    public int countProperty // ここでプロパティを使う。publicをつけます。
    {
        get { return score; }  // これがgetter。他のスクリプトから呼び出した時、returnのあとに書いた変数を返す。
        set { score = value; } // これがsetter。valueには他のスクリプトで代入された値が格納されます。（そこまで気にしなくて大丈夫。）
    }

    void Start()
    {
        score = 0;
        morepoint = false;
        morepoint2 = false;
        releasecount = false;
        height = -0.875f;
        addTime = 0.0f;
        morepointTime = 0.0f;
        morepointTime2 = 0.0f;
        this.addscore = FindObjectOfType<ScorePlane>(); // インスタンス化
        scoreplane.SetActive(false);
    }

    void Update()
    {
        TumikiNumber.text = score.ToString();
        float newY = height;

        Vector3 newPosition = scoreplane.transform.position;
        newPosition.y = newY;

        scoreplane.transform.position = newPosition;

        if (releasecount)
        {
            addTime += Time.deltaTime;

            if (addTime >= 2.4f)
            {
                scoreplane.SetActive(true);

                if (addTime >= 2.5f)
                {
                    if (addscore.addscoreProperty == 1)
                    {
                        score += 5;
                        height += 0.125f;
                        releasecount = false;
                        addTime = 0.0f;
                        addscore.addscoreProperty = 0;
                        morepoint = true;
                    }
                    else if (addscore.addscoreProperty == 0)
                    {
                        releasecount = false;
                        scoreplane.SetActive(false);
                        addTime = 0.0f;
                        addscore.addscoreProperty = 0;
                    }
                }
            }
        }

        if (morepoint)
        {
            morepointTime += Time.deltaTime;

            if (morepointTime >= 0.25f)
            {
                if (addscore.addscoreProperty == 1)
                {
                    score += 5;
                    height += 0.125f;
                    morepoint = false;
                    morepointTime = 0.0f;
                    addscore.addscoreProperty = 0;
                    morepoint2 = true;
                }
                else if (addscore.addscoreProperty == 0)
                {
                    morepoint = false;
                    scoreplane.SetActive(false);
                    morepointTime = 0.0f;
                    addscore.addscoreProperty = 0;
                    
                }
            }
        }

        if (morepoint2)
        {
            morepointTime2 += Time.deltaTime;

            if (morepointTime2 >= 0.25f)
            {
                if (addscore.addscoreProperty == 1)
                {
                    score += 5;
                    height += 0.125f;
                    morepoint2 = false;
                    scoreplane.SetActive(false);
                    morepointTime2 = 0.0f;
                    addscore.addscoreProperty = 0;
                }
                else if (addscore.addscoreProperty == 0)
                {
                    morepoint2 = false;
                    scoreplane.SetActive(false);
                    morepointTime2 = 0.0f;
                    addscore.addscoreProperty = 0;

                }
            }
        }
    }


    public void GrabObject()
    {
        addTime = 0.0f;
        releasecount = false;
    }

    public void ReleaseObject()
    {
        addTime = 0.0f;
        releasecount = true;
    }
}
