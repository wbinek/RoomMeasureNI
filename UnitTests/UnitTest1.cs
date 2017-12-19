using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Numerics;
using RoomMeasureNI.Sources.Dependencies.ButterworthFilterDesign;

namespace UnitTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void coefficientsEQTest()
        {
            int filterOrder = 8;
            double overallGain = 12.0;
            const double EPSILON = 1.0e-4;

            Biquad[] coeffs = new Biquad[0];
            //Butterworth butterworth = new Butterworth();

            bool designedCorrectly = Butterworth.coefficientsEQ(FILTER_TYPE.kParametric,
                                                                40000,      // fs
                                                                3500,       // freq1
                                                                6500,       // freq2   Df = 3kHz
                                                                filterOrder,
                                                                ref coeffs,
                                                                overallGain);

            Assert.IsTrue(designedCorrectly == true);

            //******************************************************************************
            //  MATLAB coefficients: first section
            //******************************************************************************

            double b0 = 1.0356;
            double b1 = -2.6699;
            double b2 = 3.4403;
            double b3 = -2.3905;
            double b4 = 0.8435;
            // double a0 = 1.0;
            double a1 = -2.6478 * (-1);
            double a2 = 3.4810 * (-1);
            double a3 = -2.4127 * (-1);
            double a4 = 0.8384 * (-1);

            int i = 0;

            Assert.IsTrue(Math.Abs(b0 - coeffs[i].b0) <= EPSILON);
            Assert.IsTrue(Math.Abs(b1 - coeffs[i].b1) <= EPSILON);
            Assert.IsTrue(Math.Abs(b2 - coeffs[i].b2) <= EPSILON);
            Assert.IsTrue(Math.Abs(b3 - coeffs[i].b3) <= EPSILON);
            Assert.IsTrue(Math.Abs(b4 - coeffs[i].b4) <= EPSILON);
            Assert.IsTrue(Math.Abs(a1 - coeffs[i].a1) <= EPSILON);
            Assert.IsTrue(Math.Abs(a2 - coeffs[i].a2) <= EPSILON);
            Assert.IsTrue(Math.Abs(a3 - coeffs[i].a3) <= EPSILON);
            Assert.IsTrue(Math.Abs(a4 - coeffs[i].a4) <= EPSILON);

            //******************************************************************************
            //  MATLAB coefficients: second section
            //******************************************************************************

            b0 = 1.0555;
            b1 = -2.5476;
            b2 = 2.9933;
            b3 = -1.8553;
            b4 = 0.5794;
            //  a0 = 1.0;
            a1 = -2.4927 * (-1);
            a2 = 3.0287 * (-1);
            a3 = -1.9102 * (-1);
            a4 = 0.5995 * (-1);

            i = 1;
            Assert.IsTrue(Math.Abs(b0 - coeffs[i].b0) <= EPSILON);
            Assert.IsTrue(Math.Abs(b1 - coeffs[i].b1) <= EPSILON);
            Assert.IsTrue(Math.Abs(b2 - coeffs[i].b2) <= EPSILON);
            Assert.IsTrue(Math.Abs(b3 - coeffs[i].b3) <= EPSILON);
            Assert.IsTrue(Math.Abs(b4 - coeffs[i].b4) <= EPSILON);
            Assert.IsTrue(Math.Abs(a1 - coeffs[i].a1) <= EPSILON);
            Assert.IsTrue(Math.Abs(a2 - coeffs[i].a2) <= EPSILON);
            Assert.IsTrue(Math.Abs(a3 - coeffs[i].a3) <= EPSILON);
            Assert.IsTrue(Math.Abs(a4 - coeffs[i].a4) <= EPSILON);
        }

        [TestMethod]
        public void AnalogueLowpasProtorype()
        {
            int filterOrder = 8;

            List<Complex> poles = new List<Complex>();
            //poles.resize(filterOrder);
            Complex[] baseline_poles = new Complex[8];

            // Butterworth butter;
           List<Complex> tempPoleStorage = Butterworth.prototypeAnalogLowPass(filterOrder);

            // copy tmppole into poles
            poles = tempPoleStorage;

            baseline_poles[0] = new Complex(-0.19509032201613, 0.98078528040323);
            baseline_poles[1] = new Complex(-0.19509032201613, -0.98078528040323);
            baseline_poles[2] = new Complex(-0.55557023301960, 0.83146961230255);
            baseline_poles[3] = new Complex(-0.55557023301960, -0.83146961230255);
            baseline_poles[4] = new Complex(-0.83146961230255, 0.55557023301960);
            baseline_poles[5] = new Complex(-0.83146961230255, -0.55557023301960);
            baseline_poles[6] = new Complex(-0.98078528040323, 0.19509032201613);
            baseline_poles[7] = new Complex(-0.98078528040323, -0.19509032201613);

            // Tolerance
            const double EPSILON = 1.0e-14;

            // Test
            for (int i = 0; i < filterOrder; i++)
            {
                Assert.IsTrue(Math.Abs(baseline_poles[i].Real - poles[i].Real) <= EPSILON);
            }
        }
        [TestMethod]
        public void AnalogueLowpas()
        {
            //******************************************************************************
            // MATLAB (vR14) coefficients generated with the following code:
            //
            // [z, p, k] = butter(8, 500, 's');
            // [Zd, Pd, Kd] = bilinear(z, p, k, 44100);
            // [sos, g] = zpk2sos(Zd, Pd, Kd)
            //******************************************************************************

            int filterOrder = 8;
            double overallGain = 1.0;

            Biquad[] coeffs = new Biquad[0];  // second-order sections (sos)

            bool designedCorrectly = Butterworth.loPass(44100,  // fs
                                                        500,    // freq1
                                                        0,      // freq2. N/A for lowpass
                                                        filterOrder,
                                                        ref coeffs,
                                                        overallGain);
            Assert.IsTrue(designedCorrectly == true);

            //******************************************************************************
            // MATLAB coefficients: first section
            //******************************************************************************

            double b0 = 1.0;
            double b1 = 2.0;
            double b2 = 1.0;
            // double a0 = 1.0;
            double a1 = -1.96762058043629 * (-1); // to convert to DF2T (direct form II transpose)
            double a2 = 0.97261960500367 * (-1); // to convert to DF2T (direct form II transpose)

            int i = 0;

            const double EPSILON = 1.0e-4;
            Assert.IsTrue(Math.Abs(b0 - coeffs[i].b0) <= EPSILON);
            Assert.IsTrue(Math.Abs(b1 - coeffs[i].b1) <= EPSILON);
            Assert.IsTrue(Math.Abs(b2 - coeffs[i].b2) <= EPSILON);
            Assert.IsTrue(Math.Abs(a1 - coeffs[i].a1) <= EPSILON);
            Assert.IsTrue(Math.Abs(a2 - coeffs[i].a2) <= EPSILON);

            //******************************************************************************
            //  MATLAB coefficients: second section
            //******************************************************************************

            b0 = 1.0;
            b1 = 2.0;
            b2 = 1.0;
            // a0 = 1.0;
            a1 = -1.91907529383978 * (-1);
            a2 = 0.92395098208778 * (-1);

            i = 1;
            Assert.IsTrue(Math.Abs(b0 - coeffs[i].b0) <= EPSILON);
            Assert.IsTrue(Math.Abs(b1 - coeffs[i].b1) <= EPSILON);
            Assert.IsTrue(Math.Abs(b2 - coeffs[i].b2) <= EPSILON);
            Assert.IsTrue(Math.Abs(a1 - coeffs[i].a1) <= EPSILON);
            Assert.IsTrue(Math.Abs(a2 - coeffs[i].a2) <= EPSILON);

            //******************************************************************************
            //  MATLAB coefficients: third section
            //******************************************************************************

            b0 = 1.0;
            b1 = 2.0;
            b2 = 1.0;
            // a0 = 1.0;
            a1 = -1.88350864178159 * (-1);
            a2 = 0.88829396780773 * (-1);

            i = 2;
            Assert.IsTrue(Math.Abs(b0 - coeffs[i].b0) <= EPSILON);
            Assert.IsTrue(Math.Abs(b1 - coeffs[i].b1) <= EPSILON);
            Assert.IsTrue(Math.Abs(b2 - coeffs[i].b2) <= EPSILON);
            Assert.IsTrue(Math.Abs(a1 - coeffs[i].a1) <= EPSILON);
            Assert.IsTrue(Math.Abs(a2 - coeffs[i].a2) <= EPSILON);

            //******************************************************************************
            //  MATLAB coefficients: fourth section
            //******************************************************************************

            b0 = 1.0;
            b1 = 2.0;
            b2 = 1.0;
            // a0 = 1.0;
            a1 = -1.86480445083537 * (-1);
            a2 = 0.86954225616013 * (-1);

            i = 3;
            Assert.IsTrue(Math.Abs(b0 - coeffs[i].b0) <= EPSILON);
            Assert.IsTrue(Math.Abs(b1 - coeffs[i].b1) <= EPSILON);
            Assert.IsTrue(Math.Abs(b2 - coeffs[i].b2) <= EPSILON);
            Assert.IsTrue(Math.Abs(a1 - coeffs[i].a1) <= EPSILON);
            Assert.IsTrue(Math.Abs(a2 - coeffs[i].a2) <= EPSILON);
        }

        [TestMethod]
        public void AnalogueHipas()
        {

            //******************************************************************************
            // MATLAB (vR14) coefficients generated with the following code:
            //
            // [z, p, k] = butter(8, 500, 'high', 's');
            // [Zd, Pd, Kd] = bilinear(z, p, k, 44100);
            // [sos, g] = zpk2sos(Zd, Pd, Kd)
            //******************************************************************************

            int filterOrder = 8;
            double overallGain = 1.0;
            const double EPSILON = 1.0e-4;

            Biquad[] coeffs = new Biquad[0];  // second-order sections (sos)

            bool designedCorrectly = Butterworth.hiPass(44100,  // fs
                                                        500,    // freq1
                                                        0,      // freq2
                                                        filterOrder,
                                                        ref coeffs,
                                                        overallGain);
            Assert.IsTrue(designedCorrectly == true);

            //******************************************************************************
            //  MATLAB coefficients: first section
            //******************************************************************************

            double b0 = 1.0;
            double b1 = -2.0;
            double b2 = 1.0;
            // double a0 = 1.0;
            double a1 = -1.96762058043629 * (-1);
            double a2 = 0.97261960500367 * (-1);

            int i = 0;

            Assert.IsTrue(Math.Abs(b0 - coeffs[i].b0) <= EPSILON);
            Assert.IsTrue(Math.Abs(b1 - coeffs[i].b1) <= EPSILON);
            Assert.IsTrue(Math.Abs(b2 - coeffs[i].b2) <= EPSILON);
            Assert.IsTrue(Math.Abs(a1 - coeffs[i].a1) <= EPSILON);
            Assert.IsTrue(Math.Abs(a2 - coeffs[i].a2) <= EPSILON);

            //******************************************************************************
            //  MATLAB coefficients: second section
            //******************************************************************************

            b0 = 1.0;
            b1 = -2.0;
            b2 = 1.0;
            // a0 = 1.0;
            a1 = -1.91907529383978 * (-1);
            a2 = 0.92395098208778 * (-1);

            i = 1;
            Assert.IsTrue(Math.Abs(b0 - coeffs[i].b0) <= EPSILON);
            Assert.IsTrue(Math.Abs(b1 - coeffs[i].b1) <= EPSILON);
            Assert.IsTrue(Math.Abs(b2 - coeffs[i].b2) <= EPSILON);
            Assert.IsTrue(Math.Abs(a1 - coeffs[i].a1) <= EPSILON);
            Assert.IsTrue(Math.Abs(a2 - coeffs[i].a2) <= EPSILON);

            //******************************************************************************
            //  MATLAB coefficients: third section
            //******************************************************************************

            b0 = 1.0;
            b1 = -2.0;
            b2 = 1.0;
            // a0 = 1.0;
            a1 = -1.88350864178159 * (-1);
            a2 = 0.88829396780773 * (-1);

            i = 2;
            Assert.IsTrue(Math.Abs(b0 - coeffs[i].b0) <= EPSILON);
            Assert.IsTrue(Math.Abs(b1 - coeffs[i].b1) <= EPSILON);
            Assert.IsTrue(Math.Abs(b2 - coeffs[i].b2) <= EPSILON);
            Assert.IsTrue(Math.Abs(a1 - coeffs[i].a1) <= EPSILON);
            Assert.IsTrue(Math.Abs(a2 - coeffs[i].a2) <= EPSILON);

            //******************************************************************************
            //  MATLAB coefficients:  fourth section
            //******************************************************************************

            b0 = 1.0;
            b1 = -2.0;
            b2 = 1.0;
            // a0 = 1.0;
            a1 = -1.86480445083537 * (-1);
            a2 = 0.86954225616013 * (-1);

            i = 3;
            Assert.IsTrue(Math.Abs(b0 - coeffs[i].b0) <= EPSILON);
            Assert.IsTrue(Math.Abs(b1 - coeffs[i].b1) <= EPSILON);
            Assert.IsTrue(Math.Abs(b2 - coeffs[i].b2) <= EPSILON);
            Assert.IsTrue(Math.Abs(a1 - coeffs[i].a1) <= EPSILON);
            Assert.IsTrue(Math.Abs(a2 - coeffs[i].a2) <= EPSILON);
        }

    }
}
