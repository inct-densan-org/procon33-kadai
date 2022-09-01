using ExitGames.Client.Photon;
using Photon.Realtime;
using Unity;
using UnityEngine;
using Photon.Pun;
public static class customproperties//�v���C���[�ɂ���ĈႤ�ϐ����`���鏊
{
    private const string InfectionKey = "Infection";
    
    private static readonly Hashtable propsToSet = new Hashtable();

    // �v���C���[�̃X�R�A���擾����
    public static bool GetInfection( this Player player)
    {
       
        return (player.CustomProperties[InfectionKey] is bool isinfection) ? isinfection : false;
    }

    // �v���C���[�̃��b�Z�[�W���擾����
    
    // �v���C���[�̃X�R�A��ݒ肷��
    public static void SetInfection(this Player player, bool isinfection)
    {
        Debug.Log("1");
        var a = PhotonNetwork.LocalPlayer;
        propsToSet[InfectionKey] = isinfection;
        a.SetCustomProperties(propsToSet);
        propsToSet.Clear();
    }
     
    // �v���C���[�̃��b�Z�[�W��ݒ肷��
}