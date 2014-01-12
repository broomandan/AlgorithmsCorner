using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmFun
{
    public class Tower
    {
        public readonly Stack<Disk> Rod = new Stack<Disk>();

        public Tower(int numberofDisks)
        {
            for (int i = numberofDisks; i > 0; i--)
            {
                Rod.Push(new Disk { Size = i });
                Console.WriteLine("Adding Disk Size: {0} .", i);
            }
            Console.WriteLine("Rod initialized with {0} Disks.", Rod.Count);
        }
    }
    public class Disk
    {
        public int Size { get; set; }
    }
    public class HanoiTowerSolver
    {
        private readonly Tower LeftTower;
        private readonly Tower MiddleTower;
        private readonly Tower RightTower;

        public HanoiTowerSolver(int numberofDisks)
        {
            LeftTower = new Tower(numberofDisks);
            MiddleTower = new Tower(0);
            RightTower = new Tower(0);
        }
        public void SolveSimple()
        {
            PrintStatus();
            Move(LeftTower, RightTower);
            PrintStatus();
            Move(LeftTower, MiddleTower);
            PrintStatus();
            Move(RightTower, MiddleTower);
            PrintStatus();
            Move(LeftTower, RightTower);
            PrintStatus();
            Move(MiddleTower, LeftTower);
            PrintStatus();
            Move(MiddleTower, RightTower);
            PrintStatus();
            Move(LeftTower, RightTower);
            PrintStatus();

        }

        private void PrintStatus()
        {
            Console.WriteLine("{0}\t\t{1}\t\t{2}", LeftTower.Rod.Count(), MiddleTower.Rod.Count(), RightTower.Rod.Count());
        }

        private void Move(Tower source, Tower target)
        {
            if (source.Rod.Count <= 0)
            {
                return;
            }

            if (CanMove(source, target))
            {
                target.Rod.Push(source.Rod.Pop());
            }
        }

        private static bool CanMove(Tower source, Tower target)
        {
            return target.Rod.Count == 0 || target.Rod.Peek().Size > source.Rod.Peek().Size;
        }
    }
}
