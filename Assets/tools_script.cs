using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tools_script : MonoBehaviour
{
    public tranformmode tranformmode;

    public void SetMoveMode()
    {
        tranformmode.SetMode(TransformMode.Move);
    }

    public void SetResizeMode()
    {
        tranformmode.SetMode(TransformMode.Resize);
    }

    public void SetRotateMode()
    {
        tranformmode.SetMode(TransformMode.Rotate);
      
           
            Debug.Log("Rotate Mode Set");
        
    }
}