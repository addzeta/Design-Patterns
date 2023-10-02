//using System;
//using System.Threading;

//namespace ConsoleApp1.State
//{
//    // State interface
//    interface IDiceState
//    {
//        void Roll(Dice dice);
//    }

//    // Concrete state - Idle
//    class IdleState : IDiceState
//    {
//        public void Roll(Dice dice)
//        {
//            Console.WriteLine("Rolling the dice...");
//            dice.SetState(new RollingState(dice)); // Pass the dice reference to RollingState
//        }
//    }

//    // Concrete state - Rolling
//    class RollingState : IDiceState
//    {
//        private Dice dice;

//        public RollingState(Dice dice)
//        {
//            this.dice = dice;
//            // Start a timer to stop rolling after 3 seconds
//            Timer timer = new Timer(StopRolling, null, 3000, Timeout.Infinite);
//        }

//        public void Roll(Dice dice)
//        {
//            Console.WriteLine("The dice is already rolling.");
//        }

//        private void StopRolling(object state)
//        {
//            dice.SetState(new IdleState());
//            Console.WriteLine("Dice has stopped rolling.");
//        }
//    }

//    // Context - Dice
//    class Dice
//    {
//        private IDiceState currentState;

//        public Dice()
//        {
//            currentState = new IdleState();
//        }

//        public void SetState(IDiceState state)
//        {
//            currentState = state;
//        }

//        public void Roll()
//        {
//            currentState.Roll(this);
//        }
//    }

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Dice dice = new Dice();

//            Console.WriteLine("Dice is idle.");
//            dice.Roll(); // Rolling the dice

//            // Simulate rolling for a few seconds
//            Thread.Sleep(2000);

//            dice.Roll(); // The dice is already rolling

//            // Wait for the dice to stop rolling
//            Thread.Sleep(3000);

//            dice.Roll(); // Rolling the dice

//            Console.ReadKey();
//        }
//    }
//}
