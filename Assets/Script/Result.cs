using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI ScoreNumber;

    [SerializeField]
    private TextMeshProUGUI TumikiNumber;

    [SerializeField]
    private TextMeshProUGUI Rank;

    [SerializeField]
    private TextMeshProUGUI Good;

    public GameObject scoreboard;
    public GameObject resetbutton;
    public GameObject resultboard;
    public GameObject AddObjectButton;

    public AudioSource audioSource;
    public AudioClip sound_ss;
    public AudioClip sound_s;
    public AudioClip sound_a;
    public AudioClip sound_b;
    public AudioClip sound_c;
    public AudioClip sound_d;

    Controller score;
    AddTumiki foulcount;
    CountTumiki foulcount2;
    CountTumiki2 foulcount3;
    FraudPreventionBox1 foulcount4;
    FraudPreventionBox2 foulcount5;
    FraudPreventionBox3 foulcount6;

    int sendresult;
    int resultcheck;
    int destroycount;

    public int resultProperty // ここでプロパティを使う。publicをつけます。
    {
        get { return sendresult; }  // これがgetter。他のスクリプトから呼び出した時、returnのあとに書いた変数を返す。
        set { sendresult = value; } // これがsetter。valueには他のスクリプトで代入された値が格納されます。（そこまで気にしなくて大丈夫。）
    }

    public int destroyProperty // ここでプロパティを使う。publicをつけます。
    {
        get { return destroycount; }  // これがgetter。他のスクリプトから呼び出した時、returnのあとに書いた変数を返す。
        set { destroycount = value; } // これがsetter。valueには他のスクリプトで代入された値が格納されます。（そこまで気にしなくて大丈夫。）
    }

    // Start is called before the first frame update
    void Start()
    {
        this.score = FindObjectOfType<Controller>(); // インスタンス化
        this.foulcount = FindObjectOfType<AddTumiki>(); // インスタンス化
        this.foulcount2 = FindObjectOfType<CountTumiki>(); // インスタンス化
        this.foulcount3 = FindObjectOfType<CountTumiki2>(); // インスタンス化
        this.foulcount4 = FindObjectOfType<FraudPreventionBox1>(); // インスタンス化
        this.foulcount5 = FindObjectOfType<FraudPreventionBox2>(); // インスタンス化
        this.foulcount6 = FindObjectOfType<FraudPreventionBox3>(); // インスタンス化

        TumikiNumber.enabled = true;
        scoreboard.SetActive(true);
        resetbutton.SetActive(false);
        resultboard.SetActive(false);
        ScoreNumber.enabled = false;
        Rank.enabled = false;
        Good.enabled = false;
        resultcheck = 0;
        destroycount = 0;

        audioSource = GetComponent<AudioSource>();

        //GameObject tumiki = GameObject.Find("tumiki");
        //Object Manipulator = tumiki.GetComponent<Object Manipulator>();

    }

    // Update is called once per frame
    void Update()
    {
        ScoreNumber.text = score.countProperty.ToString();

        if(foulcount.foulProperty == 1 || foulcount2.foulProperty2 == 1 || foulcount3.foulProperty3 == 1 || foulcount4.foulProperty4 == 1 || foulcount5.foulProperty5 == 1 || foulcount6.foulProperty6 == 1)
        {
            sendresult = 1;
            TumikiNumber.enabled = false;
            scoreboard.SetActive(false);
            resetbutton.SetActive(true);
            resultboard.SetActive(true);
            ScoreNumber.enabled = true;
            Rank.enabled = true;
            Good.enabled = true;
            audioSource.Play();
            resultcheck = 1;//"tumiki"のTagがついているオブジェクトが触れるたびに音が出るのを防止するため
            destroycount = 1;

            if (AddObjectButton.gameObject.activeSelf)
            {
                AddObjectButton.SetActive(false);//追加ボタンの非表示
            }

            GameObject[] objectsToDestroy = FindObjectsOfType<GameObject>();
            foreach (GameObject obj in objectsToDestroy)
            {
                if (obj.layer == LayerMask.NameToLayer("Destroy"))
                {
                    // レイヤーが "Destroy" のオブジェクトを破棄する
                    Destroy(obj);
                }
            }
            foulcount.foulProperty = 0;
            foulcount2.foulProperty2 = 0;
            foulcount3.foulProperty3 = 0;
            foulcount4.foulProperty4 = 0;
            foulcount5.foulProperty5 = 0;
            foulcount6.foulProperty6 = 0;
        }

        if (score.countProperty >= 55)
        {
            Rank.text = "SS+";
            Good.text = "God!";
            audioSource.clip = sound_ss;
        }
        else if (score.countProperty >= 50)
        {
            Rank.text = "SS";
            Good.text = "God!";
            audioSource.clip = sound_ss;
        }
        else if (score.countProperty >= 45)
        {
            Rank.text = "S+";
            Good.text = "Perfect!";
            audioSource.clip = sound_s;
        }
        else if (score.countProperty >= 40)
        {
            Rank.text = "S";
            Good.text = "Perfect!";
            audioSource.clip = sound_s;
        }
        else if (score.countProperty == 35)
        {
            Rank.text = "A+";
            Good.text = "Great!";
            audioSource.clip = sound_a;
        }
        else if (score.countProperty == 30)
        {
            Rank.text = "A";
            Good.text = "Great!";
            audioSource.clip = sound_a;
        }
        else if (score.countProperty == 25)
        {
            Rank.text = "B+";
            Good.text = "Good!";
            audioSource.clip = sound_b;
        }
        else if (score.countProperty == 20)
        {
            Rank.text = "B";
            Good.text = "Good!";
            audioSource.clip = sound_b;
        }
        else if (score.countProperty == 15)
        {
            Rank.text = "C+";
            Good.text = "OK!";
            audioSource.clip = sound_c;
        }
        else if (score.countProperty == 10)
        {
            Rank.text = "C";
            Good.text = "OK!";
            audioSource.clip = sound_c;
        }
        else if (score.countProperty == 5)
        {
            Rank.text = "D+";
            Good.text = "Retry!";
            audioSource.clip = sound_d;
        }
        else if (score.countProperty == 0)
        {
            Rank.text = "D";
            Good.text = "Retry!";
            audioSource.clip = sound_d;
        }

        // Planeを定義（原点を通り、上向き）
        Plane plane = new Plane(Vector3.up, Vector3.zero);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "tumiki" && resultcheck == 0)
        {
            sendresult = 1;
            TumikiNumber.enabled = false;
            scoreboard.SetActive(false);
            resetbutton.SetActive(true);
            resultboard.SetActive(true);
            ScoreNumber.enabled = true;
            Rank.enabled = true;
            Good.enabled = true;
            audioSource.Play();
            resultcheck = 1;//"tumiki"のTagがついているオブジェクトが触れるたびに音が出るのを防止するため
            destroycount = 1;

            if (AddObjectButton.gameObject.activeSelf)
            {
                AddObjectButton.SetActive(false);//追加ボタンの非表示
            }

            GameObject[] objectsToDestroy = FindObjectsOfType<GameObject>();
            foreach (GameObject obj in objectsToDestroy)
            {
                if (obj.layer == LayerMask.NameToLayer("Destroy"))
                {
                    // レイヤーが "Destroy" のオブジェクトを破棄する
                    Destroy(obj);
                }
            }

            //RightbodyやMeshClliderをTumikiから外して積み木を固定する
        }
    }
}
