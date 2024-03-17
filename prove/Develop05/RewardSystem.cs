using System;
using System.Collections.Generic;

class RewardSystem
{
    private Dictionary<string, bool> _rewards = new Dictionary<string, bool>();

    public RewardSystem()
    {
        InitializeRewards();
    }

    private void InitializeRewards()
    {
        // set Rewards to initially unearned
        _rewards.Add("Early Bird", false);
        _rewards.Add("Completionist", false);
        // Add more rewards ...
    }

    public void CheckForRewards(List<Goal> goals)
    {
        CheckEarlyBirdReward(goals);
        CheckCompletionistReward(goals);
        //add more here
    }

    private void CheckEarlyBirdReward(List<Goal> goals)
    {
        // Give "Early Bird" reward if a certain goal is completed early (not implemented)
        foreach (Goal goal in goals)
        {
            if (goal is Simple simpleGoal && simpleGoal._completed && simpleGoal._value >= 10)
            {
                UnlockReward("Early Bird");
                break;
            }
        }
    }

    private void CheckCompletionistReward(List<Goal> goals)
    {
        //Gives "Completionist" reward if all goals are completed
        bool allGoalsCompleted = true;
        foreach (Goal goal in goals)
        {
            if (!goal._completed)
            {
                allGoalsCompleted = false;
                break;
            }
        }

        if (allGoalsCompleted)
        {
            UnlockReward("Completionist");
        }
    }

    private void UnlockReward(string rewardName)
    {
        //Unlocks the specified reward or achievement
        if (_rewards.ContainsKey(rewardName))
        {
            _rewards[rewardName] = true;
            Console.WriteLine($"Congratulations! You've earned the \"{rewardName}\" reward!");
        }
    }

    public void DisplayRewards()
    {
        Console.WriteLine("\nEarned Rewards:");
        foreach (var reward in _rewards)
        {
            if (reward.Value)
            {
                Console.WriteLine(reward.Key);
            }
        }
    }
}
