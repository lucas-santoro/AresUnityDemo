using System;

public interface IGameStarter
{
    bool IsStarted { get; }
    event Action OnGameStart;
}
