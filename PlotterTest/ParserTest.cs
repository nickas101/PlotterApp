using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlotterTest
{
    [TestClass]
    public class ParserTest
    {
        private string[] lines = { "BATCH : 01 ",
                "CHAMBER H POSn 1:1  RUN = 1738 on 24 Oct 2018 at 08:13:01",
                "SPEC = U7366   Issue No. = 0",
                "TEMP. TABLE = WLZ  Init Stab = 180 mins, Sub Stab = 25 mins",
                "TEMP'C   FREQ. (MHz)   NOM (ppm)  OVERBAND  SPEC    SLOPE       SLOPE",
                "                                   (ppm)    LIMIT  (ppm/'C)     LIMIT",
                "+26   20.000004828     +.2414    +.0056 <   .005    +0.0000   100.0000    FAIL",
                "+50   20.000004833     +.2417    +.0059 <   .005    +0.0000   100.0000    FAIL",
                "Worst deviation from -40 to  85`C =        .0076 ppm at  87`C"};
        private Parser.Plots plots;

        [TestInitialize]
        public void SetupContext()
        {
            plots = Parser.Parser.Parse(lines);
        }

        [TestMethod]
        public void ProductNumberTest()
        {
            Assert.AreEqual("U7366", plots.Spc[1]);
        }

        [TestMethod]
        public void TemperatureTest()
        {
            Assert.AreEqual("26", plots.Temp[1,0]);
        }
    }
}
