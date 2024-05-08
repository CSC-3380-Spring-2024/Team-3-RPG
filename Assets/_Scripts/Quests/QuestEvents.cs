using System;

public static class QuestEvents
{
    // Define a custom event for Goblin death
    public static event Action<Goblin> OnGoblinDied;

    // Function to trigger the Goblin death event
    public static void TriggerGoblinDeath(Goblin goblin)
    {
        OnGoblinDied?.Invoke(goblin);
    }
}