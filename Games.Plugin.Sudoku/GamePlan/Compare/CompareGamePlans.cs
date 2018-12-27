using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Plugin.Sudoku.GamePlan.Compare
{
    //ToDo watch this: https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.sequenceequal?redirectedfrom=MSDN&view=netframework-4.7.2#System_Linq_Enumerable_SequenceEqual__1_System_Collections_Generic_IEnumerable___0__System_Collections_Generic_IEnumerable___0__
    public class CompareGamePlans : ICompareGamePlans
    {
        public bool CheckEquality(IGamePlanViewModel gamePlanViewModel1, IGamePlanViewModel gamePlanViewModel2)
        {
            if (CompareArrays<int>(gamePlanViewModel1.GamePlan, gamePlanViewModel2.GamePlan) &&
                CompareArrays<int>(gamePlanViewModel1.GameStartView, gamePlanViewModel2.GameStartView) &&
                CompareIds(gamePlanViewModel1.PlanId, gamePlanViewModel2.PlanId))
            {
                return true;
            }

            return false;
        }
        public bool CompareArrays<T>(T[,] array1, T[,] array2)
        {
            try
            {
                if (array1.GetLength(0) == array2.GetLength(0) && array1.GetLength(1) == array2.GetLength(1))
                {
                    for (int i = 0; i < array1.GetLength(0); i++)
                    {
                        for (int k = 0; k < array1.GetLength(1); i++)
                        {
                            if (!array1[i, k].Equals(array2[i, k]))
                            {
                                return false;
                            }
                        }
                    }
                    return true;
                }
                else
                {
                    throw new Exception("CompareArrays: Wrong Array Length");
                    //ToDo Text for debugging and logging
                }
            }
            catch
            {
                return false;
            }

        }
        public bool CompareIds(string iD1, string iD2)
        {
            if (iD1 != iD2)
            {
                return false;
            }

            return true;
        }
    }
}
