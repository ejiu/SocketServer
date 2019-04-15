using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Room
{
    public enum RoomState
    {
        Await,  //等待
        Gaming  //对局开始
    }

    //房间ID
    public int RoomId = 0;
    //房间棋盘信息
    public GamePlay gamePlay;
    //房间状态
    public RoomState State = RoomState.Await;

    //最大玩家数量
    public const int MAX_PLAYER_AMOUNT = 2;
    //最大观察者数量
    public const int MAX_OBSERVER_AMOUNT = 2;

    public List<Player> playerList = new List<Player>(); //玩家集合
    public List<Player> OBs = new List<Player>();     //观察者集合

    public Room(int roomId)                           //构造
    {
        RoomId = roomId;
        gamePlay = new GamePlay();
    }

    /// <summary>
    /// 关闭房间:从房间字典中移除并且所有房间中的玩家清除
    /// </summary>
    public void Close()
    {
        //所有玩家跟观战者退出房间
        foreach (var each in playerList)
        {
            each.ExitRoom();
        }
        foreach (var each in OBs)
        {
            each.ExitRoom();
        }
        Server.roomDict.Remove(RoomId);
    }
}
