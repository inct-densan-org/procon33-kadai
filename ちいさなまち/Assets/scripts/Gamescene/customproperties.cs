using ExitGames.Client.Photon;
using Photon.Realtime;

public static class customproperties//プレイヤーによって違う変数を定義する所
{
    private const string InfectionKey = "Infection";
    

    private static readonly Hashtable propsToSet = new Hashtable();

    // プレイヤーのスコアを取得する
    public static bool GetInfection(this Player player)
    {
        return (player.CustomProperties[InfectionKey] is bool isinfection) ? isinfection : false;
    }

    // プレイヤーのメッセージを取得する
   

    // プレイヤーのスコアを設定する
    public static void SetInfection(this Player player, bool isinfection)
    {
        propsToSet[InfectionKey] = isinfection;
        player.SetCustomProperties(propsToSet);
        propsToSet.Clear();
    }

    // プレイヤーのメッセージを設定する
    
}