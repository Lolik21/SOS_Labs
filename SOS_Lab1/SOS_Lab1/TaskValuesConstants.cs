using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Documents;

namespace SOS_Lab1
{
    public static class TaskValuesConstants
    {
        public class Task2AValues
        {
            public double A = 10.0;
            public double f = 2.0;
            public List<double> Phis = new List<double> { 0.0, Math.PI / 6, Math.PI / 4, Math.PI / 2, Math.PI };
            public List<string> Legends = new List<string>
                { "phi = 0", "phi = PI / 6", "phi = PI / 4", "phi = PI / 2", "phi = PI" };
            public string Title = "A: 10.0 f: 2.0";
        }

        public class Task2BValues
        {
            public double A = 3.0;
            public double Phi = Math.PI / 2;
            public List<double> fs = new List<double> { 5.0, 4.0, 2.0, 6.0, 3.0 };
            public List<string> Legends = new List<string>
                { "f = 5.0", "f = 4.0", "f = 2.0", "f = 6.0", "f = 3.0", };
            public string Title = "A: 3.0 Phis: PI/2";
        }

        public class Task2CValues
        {
            public double Phi = Math.PI / 2;
            public double f = 1;
            public List<double> As = new List<double> { 2.0, 3.0, 6.0, 5.0, 1.0 };
            public List<string> Legends = new List<string>
                { "A = 2.0", "A = 3.0", "A = 6.0", "A = 5.0", "A = 1.0", };

            public string Title = "f: 1.0 Phis: PI/2";
        }

        public class Task3Values
        {
            public double JCount = 5;
            public List<double> Aj = new List<double> { 1.0, 1.0, 1.0, 1.0, 1.0 };
            public List<double> fj = new List<double>{ 1.0, 2.0, 3.0, 4.0, 5.0 };
            public List<List<double>> Phis = new List<List<double>>
            {
                new List<double>{ 0.0, Math.PI / 4, Math.PI / 6, Math.PI * 2, Math.PI },
                new List<double>{ Math.PI / 4, Math.PI / 6, Math.PI * 2, Math.PI,  0.0 },
                new List<double>{ Math.PI / 6, Math.PI * 2, Math.PI, 0.0, Math.PI / 4 },
                new List<double>{ Math.PI / 9, Math.PI / 4, Math.PI / 3, Math.PI / 6, 0.0}
            };
        }

        public class Task4Values
        {
            public double JCount = 5;
            public List<double> Aj = new List<double> { 1.0, 1.0, 1.0, 1.0, 1.0 };
            public List<double> fj = new List<double> { 1.0, 2.0, 3.0, 4.0, 5.0 };
            public List<double> Phis = new List<double> {0.0, Math.PI / 4, Math.PI / 6, Math.PI * 2, Math.PI};
        }
        
    }

}