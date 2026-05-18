using UnityEngine;

public class CursorManager
{
    public static void SetCursor(bool visable)
    {
        Cursor.visible = visable;

        //turnery operator  if true do the first thing else do the second 
        Cursor.lockState = visable ? CursorLockMode.None : CursorLockMode.Locked; 
    }
}
