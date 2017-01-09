namespace DXSample10
{
    public class RowObject
    {
        public int Id { get; }

        public string Name { get; set; }

        public object Data { get; set; }

        public RowObject(string name = null, object data = null)
        {
            Id = _counter++;
            Name = name;
            Data = data;
        }

        private static int _counter = 0;
    }
}