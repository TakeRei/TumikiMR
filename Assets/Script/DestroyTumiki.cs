using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyTumiki : MonoBehaviour
{
    Result destroycount;

    // Start is called before the first frame update
    void Start()
    {
        this.destroycount = FindObjectOfType<Result>(); // インスタンス化
    }

    // Update is called once per frame
    void Update()
    {
        if (destroycount.destroyProperty == 1)
        {
            ObjectManipulator objectManipulator = this.gameObject.GetComponent<ObjectManipulator>();

            // もし "Object Manipulator" コンポーネントが存在すれば削除
            if (objectManipulator != null)
            {
                Destroy(objectManipulator);
            }
        }
    }
}
