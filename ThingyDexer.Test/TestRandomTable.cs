using ThingyDexer.Model.Table;

namespace ThingyDexer.Test
{
    [TestClass]
    public class TestRandomTable
    {
        private const int seed = 500;
        private Random? rnd;
        private readonly string[] testdata = { "a", "b", "3", "4", "5", "6", "7", "8", "9", "0" };
        private readonly Dictionary<int, int> testSet = [];
        private readonly List<int> sequence = [];

        private TextTable? table;

        [TestInitialize]
        public void TestInit()
        {
            if (testSet.Any() == false)
            {
                rnd = new Random(seed);
                int minValue = 1;
                int maxValue = 10;
                while (testSet.Keys.Count < maxValue)
                {
                    int a = rnd.Next(minValue, maxValue + 1);
                    sequence.Add(a);
                    if (!testSet.ContainsKey(a))
                    {
                        testSet.Add(a, 1);
                    }
                    else
                    {
                        testSet[a] = testSet[a]++;
                    }
                }
                rnd = new Random(seed);
                table = new TextTable(rnd, "test", testdata.ToList());
            }
        }


        [TestMethod]
        public void TestSequence()
        {
            int idx = 0;
            foreach (int entry in sequence)
            {
                TableRowBase<string>? x = table?.GetRandomItem();
                TableRowBase<string>? y = table?.GetRow(sequence[idx++]);
                Assert.AreEqual(y, x);
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            // Method intentionally left empty.
        }
    }
}