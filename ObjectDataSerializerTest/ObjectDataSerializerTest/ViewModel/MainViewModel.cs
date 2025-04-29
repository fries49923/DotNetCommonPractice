using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ObjectDataSerializerTest.Model;
using ObjectDataSerializerTest.Tool;

namespace ObjectDataSerializerTest.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly FileAccessor fileAccessor;

        [ObservableProperty]
        private string resultMsg;

        public MainViewModel()
        {
            fileAccessor = new();

            resultMsg = "";
        }

        #region Write String

        [RelayCommand]
        public void WriteStrToXml()
        {
            var model = new MainItem();
            model.TestData1();

            WriteStringToFile(
                new XmlDataSerializer(),
                model, "xml");
        }

        [RelayCommand]
        public void WriteStrToJson()
        {
            var model = new MainItem();
            model.TestData2();

            WriteStringToFile(
                new JsonDataSerializer(),
                model, "json");
        }

        [RelayCommand]
        public void WriteStrToYaml()
        {
            var model = new MainItem();
            model.TestData2();
            model.Ratio = 123.456;

            WriteStringToFile(
                new YamlDataSerializer(),
                model, "yaml");
        }

        private void WriteStringToFile<T>(
            IDataSerializer dataSerializer,
            T obj,
            string extension) where T : class
        {
            try
            {
                ResultMsg = "";

                var str = dataSerializer.SerializeToString(obj);
                fileAccessor.WriteText($"Test.{extension}", str);

                ResultMsg = "OK";
            }
            catch (Exception ex)
            {
                ResultMsg = ex.Message;
            }
        }

        #endregion

        #region Read String

        [RelayCommand]
        public void ReadStrFromXml()
        {
            var model = ReadStringFromFile<MainItem>(
                new XmlDataSerializer(),
                "xml");
        }

        [RelayCommand]
        public void ReadStrFromJson()
        {
            var model = ReadStringFromFile<MainItem>(
                new JsonDataSerializer(),
                "json");
        }

        [RelayCommand]
        public void ReadStrFromYaml()
        {
            var model = ReadStringFromFile<MainItem>(
                new YamlDataSerializer(),
                "yaml");
        }

        private T ReadStringFromFile<T>(
            IDataSerializer dataSerializer,
            string extension) where T : class
        {
            try
            {
                var str = fileAccessor.ReadText($"Test.{extension}");
                var result = dataSerializer.DeserializeFromString<T>(str);
                ResultMsg = "OK";

                return result;
            }
            catch (Exception ex)
            {
                ResultMsg = ex.Message;

                return default!;
            }
        }

        #endregion

        #region Write ByteAry

        private void WriteByteAryToByteAry<T>(
            IDataSerializer dataSerializer,
            T obj,
            string extension) where T : class
        {
            try
            {
                ResultMsg = "";

                var byteAry = dataSerializer.SerializeToByteAry(obj);

                // (可選) 此處可加上加密處理後再寫入檔案

                fileAccessor.WriteBytes($"Test.{extension}", byteAry);

                ResultMsg = "OK";
            }
            catch (Exception ex)
            {
                ResultMsg = ex.Message;
            }
        }

        #endregion

        #region Read ByteAry

        private T ReadByteAryFromFile<T>(
            IDataSerializer dataSerializer,
            string extension) where T : class
        {
            try
            {
                var byteAry = fileAccessor.ReadBytes($"Test.{extension}");

                // (可選) 此處可加上解密處理後再反序列化

                var result = dataSerializer.DeserializeFromByteAry<T>(byteAry);
                ResultMsg = "OK";

                return result;
            }
            catch (Exception ex)
            {
                ResultMsg = ex.Message;

                return default!;
            }
        }

        #endregion
    }
}
