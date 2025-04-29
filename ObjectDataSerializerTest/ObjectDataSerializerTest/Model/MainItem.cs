namespace ObjectDataSerializerTest.Model
{
    public class MainItem
    {
        public bool IsEnabled { get; set; }
        public int Count { get; set; }
        public double Ratio { get; set; }
        public List<string> Tags { get; set; }
        public SubItem Detail { get; set; }

        public MainItem()
        {
            IsEnabled = false;
            Count = 0;
            Ratio = 0.0;
            Tags = [];
            Detail = new SubItem();
        }

        public void TestData1()
        {
            IsEnabled = true;
            Count = 5;
            Ratio = 3.14;
            Tags = ["alpha", "beta", "gamma"];
            Detail = new SubItem
            {
                Name = "ItemA",
                Value = 42
            };
        }

        public void TestData2()
        {
            IsEnabled = false;
            Count = 99;
            Ratio = 2.718;
            Tags = ["x", "y"];
            Detail = new SubItem
            {
                Name = "ItemB",
                Value = -1
            };
        }

        public void Copy(MainItem obj)
        {
            IsEnabled = obj.IsEnabled;
            Count = obj.Count;
            Ratio = obj.Ratio;
            Tags = [.. obj.Tags];

            Detail = new SubItem();
            Detail.Copy(obj.Detail);
        }
    }

    public class SubItem
    {
        public string Name { get; set; }
        public int Value { get; set; }

        public SubItem()
        {
            Name = string.Empty;
            Value = 0;
        }

        public void Copy(SubItem obj)
        {

            Name = obj.Name;
            Value = obj.Value;
        }
    }
}
