using UnityEditor;
using System.Collections.Generic;
using UnityEngine.Events;

public class LevelEventService
{
    private static LevelEventService _instance;
    public static LevelEventService instance {
        get { 
            if (LevelEventService._instance == null) LevelEventService._instance = new LevelEventService();
            return LevelEventService._instance;
        }
    }

    public enum Channel { Red, Blue, Yellow }

    public Dictionary<Channel, int> dicoChannelStatus { get; private set; }
    public UnityEvent<Channel, int> onStatusChange { get; private set; }

    public LevelEventService()
    {
        this.dicoChannelStatus = new Dictionary<Channel, int>();
        this.onStatusChange = new UnityEvent<Channel, int>();
        this.dicoChannelStatus.Add(Channel.Red, 0);
        this.dicoChannelStatus.Add(Channel.Blue, 0);
        this.dicoChannelStatus.Add(Channel.Yellow, 0);
    }

    public void Activate(Channel channel)
    {
        this.dicoChannelStatus[channel]++;
        this.onStatusChange.Invoke(channel, this.dicoChannelStatus[channel]);
    }

    public void Deactivate(Channel channel)
    {
        this.dicoChannelStatus[channel]--;
        this.onStatusChange.Invoke(channel, this.dicoChannelStatus[channel]);
    }
}