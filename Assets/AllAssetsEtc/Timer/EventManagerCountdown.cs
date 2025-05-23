// following https://www.youtube.com/watch?v=DH2ZxwRBwwg
// Jack Glenn-Kennedy


using UnityEngine.Events;
public static class EventManagerCountdown
{
    public static event UnityAction TimerStart;
    public static event UnityAction TimerStop;
    public static event UnityAction<float> TimerUpdate;


    public static void OnTimerStart() => TimerStart?.Invoke();
    public static void OnTimerStop() => TimerStop?.Invoke();
    public static void OnTimerUpdate(float value) => TimerUpdate?.Invoke(value);
}
