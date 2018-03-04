using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class NotificationHandler
{
    private NotificationLink _notificationChain;

    [SerializeField]
    private Text _notificationText;

    public void Setup()
    {
        var noneLink = new NotificationLink(GameState.None, "...");
        var humanTurnLink = new NotificationLink(GameState.HumanTurn, "Waiting for player action");
        var computerTurnLink = new NotificationLink(GameState.ComputerTurn, "Computer turn");
        var humanWonLink = new NotificationLink(GameState.HumanWon, "Hand won by player");
        var computerWonLink = new NotificationLink(GameState.ComputerWon, "Hand won by computer");
        var drawLink = new NotificationLink(GameState.Draw, "Draw");

        noneLink.SetSuccessor(humanTurnLink);
        humanTurnLink.SetSuccessor(computerTurnLink);
        computerTurnLink.SetSuccessor(humanWonLink);
        humanWonLink.SetSuccessor(computerWonLink);
        computerWonLink.SetSuccessor(drawLink);
        drawLink.SetSuccessor(noneLink);

        _notificationChain = noneLink;
    }

    public void OnUpdateNotification(GameState state)
    {
        _notificationText.text = _notificationChain.GetNotification(state);
    }
}