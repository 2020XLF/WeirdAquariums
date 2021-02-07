using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public Transform leftDownPos;
    public Transform rightUpPos;

    // Start is called before the first frame update
    void Start()
    {
        GameStaticUtil.Instance.setSwimScope(leftDownPos,rightUpPos);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void checkClickEvent()
    {
        
    }
}
