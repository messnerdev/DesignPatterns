using System;
using System.Collections.Generic;
using System.Text;
using State.Manual;
using State.StatelessLibrary;
using State.Switch;
using Stateless;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            ManualStateMachineExample();
            SwitchBasedStateMachineExample();
            StatelessLibraryExample();
        }

        private static void ManualStateMachineExample()
        {
            Dictionary<Manual.State, List<(Trigger, Manual.State)>> rules
                = new Dictionary<Manual.State, List<(Trigger, Manual.State)>>
                {
                    [Manual.State.OffHook] = new List<(Trigger, Manual.State)>
                    {
                        (Trigger.CallDialed, Manual.State.Connecting)
                    },
                    [Manual.State.Connecting] = new List<(Trigger, Manual.State)>
                    {
                        (Trigger.HungUp, Manual.State.OffHook),
                        (Trigger.CallConnected, Manual.State.Connected)
                    },
                    [Manual.State.Connected] = new List<(Trigger, Manual.State)>
                    {
                        (Trigger.LeftMessage, Manual.State.OffHook),
                        (Trigger.HungUp, Manual.State.OffHook),
                        (Trigger.PlacedOnHold, Manual.State.OnHold)
                    },
                    [Manual.State.OnHold] = new List<(Trigger, Manual.State)>
                    {
                        (Trigger.TakenOffHold, Manual.State.Connected),
                        (Trigger.HungUp, Manual.State.OffHook)
                    }
                };

            var state = Manual.State.OffHook;
            while (true)
            {
                Console.WriteLine($"The phone is currently {state}");
                Console.WriteLine($"Select a trigger");
                for (var index = 0; index < rules[state].Count; index++)
                {
                    var rule = rules[state][index];
                    Console.WriteLine($"{index}. {rule.Item1}");
                }

                var input = int.Parse(Console.ReadLine());
                if (input > rules[state].Count - 1)
                    break;
                var (_, s) = rules[state][input];
                state = s;
            }
        }

        private static void SwitchBasedStateMachineExample()
        {
            string code = "1234";
            var state = PadlockState.Locked;
            var entry = new StringBuilder();

            Console.WriteLine("Enter 4 digit codes to attempt to unlock padlock");
            while (true)
            {
                switch (state)
                {
                    case PadlockState.Locked:
                        entry.Append(Console.ReadKey().KeyChar);
                        if (entry.ToString() == code)
                        {
                            state = PadlockState.Unlocked;
                            break;
                        }

                        if (!code.StartsWith(entry.ToString()))
                            state = PadlockState.Failed;
                            //goto case PadlockState.Failed;
                        break;
                    case PadlockState.Failed:
                        Console.CursorLeft = 0;
                        Console.WriteLine("FAILED");
                        entry.Clear();
                        state = PadlockState.Locked;
                        break;
                    case PadlockState.Unlocked:
                        Console.CursorLeft = 0;
                        Console.WriteLine("UNLOCKED");
                        return;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

        }

        private static void StatelessLibraryExample()
        {
            bool ParentsNotWatching()
            {
                var rand = new Random();
                return rand.Next(0, 2) == 0;
            }

            var stateMachine = new StateMachine<Health, Activity>(Health.NonReproductive);
            stateMachine.Configure(Health.NonReproductive)
                .Permit(Activity.ReachPuberty, Health.Reproductive);
            stateMachine.Configure(Health.Reproductive)
                .Permit(Activity.Historectomy, Health.NonReproductive)
                .PermitIf(Activity.UnprotectedSex, Health.Pregnant, ParentsNotWatching);
            stateMachine.Configure(Health.Pregnant)
                .Permit(Activity.GiveBirth, Health.Reproductive)
                .Permit(Activity.HaveAbortion, Health.Reproductive);
        }
    }
}
