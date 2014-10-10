namespace ObjectDumperTests
{
    public class Test2Class
    {
        public class Test2Inner
        {
            public string Name { get; set; }
            public int Value { get; set; }
        }

        public Test2Inner InnerClass { get; private set; }

        public Test2Class()
        {
            InnerClass = new Test2Inner()
            {
                Name = "My inner class",
                Value = 42
            };
        }
    }
}