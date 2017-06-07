using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sample06
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().Run();
        }
        public void Run()
        {
            Console.WriteLine("Start Run");
            const int iAmount = 100000;

            // sequenziell
            int[] iValuesSeq = new int[iAmount];
            iValuesSeq[0] = 1;
            for (int i = 1; i < iAmount; i++)
            {
                iValuesSeq[i] = iValuesSeq[i - 1] + 1;
            }

            // parallel
            int[] iValuesPar = new int[iAmount];
            iValuesPar[0] = 1;
            Parallel.For(1, iAmount, i =>
                {
                    iValuesPar[i] = iValuesPar[i - 1] + 1;
                });

            // Test
            long lSumSeq = 0;
            long lSumPar = 0;
            for (int i = 0; i < iAmount; i++)
            {
                lSumSeq += iValuesSeq[i];
                lSumPar += iValuesPar[i];
            }
            Console.WriteLine("Seq: {0}  Par: {1}", lSumSeq, lSumPar);

            Console.WriteLine("End Run");
            Console.ReadLine();
        }

    }
}
