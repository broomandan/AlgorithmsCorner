using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmFun
{
    class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("Hanoi Tower");
            (new HanoiTowerSolver(3)).SolveSimple();

            Console.WriteLine("Sentence Spacer");
            SentenceSpacerSolver.Solve();

            Console.ReadKey();

        }
    }
}
