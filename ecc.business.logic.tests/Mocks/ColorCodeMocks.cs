using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ecc.business.logic.tests.Mocks
{
    public static class MockColorCodes
    {
        internal static double? GetMockMultipliers(string color)
        {
            double result = 0d;
            (new Dictionary<string, double>
            {
                {"Pink", 0.001d},
                {"Silver", 0.01d},
                {"Gold", 0.1d},
                {"Black", 1d},
                {"Brown", 10d},
                {"Red", 100d},
                {"Orange", 1000d},
                {"Yellow", 10000d},
                {"Green", 100000d},
                {"Blue", 1000000d},
                {"Violet", 10000000d},
                {"Gray", 100000000d},
                {"White", 1000000000d}

            }).TryGetValue(color, out result);
            return result;
        }

        internal static double? GetMockTolerance(string color)
        {
            double result = 0d;
            (new Dictionary<string, double>
            {
                {"None", 20d},
                {"Silver", 20d},
                {"Gold", 5d},
                {"Brown", 1d},
                {"Red", 2d},
                {"Yellow", 5d},
                {"Green", 0.5d},
                {"Blue", 0.25d},
                {"Violet", 0.1d},
                {"Gray", 0.05d},
            }).TryGetValue(color, out result);
            return result;
        }

    }
}
