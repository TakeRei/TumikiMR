using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using UnityEngine;

public class AddObjectButton : MonoBehaviour
{
    int trackingcount;
    float resetTime;
    float trackingTime;
    public bool reset;
    public bool tracking;
    public GameObject addobjectbutton;
    Result sendresult;

    // Start is called before the first frame update
    void Start()
    {
        this.sendresult = FindObjectOfType<Result>(); // インスタンス化

        trackingcount = 0;
        addobjectbutton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (tracking)
        {
            trackingTime += Time.deltaTime;

            //右手の人差し指の指先の位置情報を取得
            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out MixedRealityPose pose))
            {
                addobjectbutton.transform.position = new Vector3(pose.Position.x, pose.Position.y + 0.2f, pose.Position.z - 0.1f); //座標を設定
                addobjectbutton.transform.rotation = pose.Rotation * Quaternion.Euler(-90, 180, 180);

                if (trackingTime >= 0.01f)
                {
                    tracking = false;
                    trackingTime = 0.0f;
                }
            }
        }

        if (reset)
        {
            resetTime += Time.deltaTime;

            if (resetTime >= 1.0f)
            {
                reset = false;
                resetTime = 0.0f;
                trackingcount = 0;
            }
        }
    }

    public void OnClickCloseMenuButton()
    {
        addobjectbutton.SetActive(false);
        trackingcount = 0;
        reset = true;
    }

    public void PlusCount()
    {
        if (trackingcount == 0 && sendresult.resultProperty == 0)
        {
            trackingcount = 1;
            addobjectbutton.SetActive(true);
            tracking = true;
        }
    }
}
