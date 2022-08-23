using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameExit : MonoBehaviour
{
    //ボタンが押されたときに実行
    public void Exit()
    {

#if UNITY_EDITOR //この書き方はプラットフォーム依存コンパイルというらしい、この場合はUnityエディタ上で実行されている場合を指す
        UnityEditor.EditorApplication.isPlaying = false;//エディタ終了
#else
    Application.Quit();//ゲーム終了
#endif

    }

}
