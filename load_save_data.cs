using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace C1oudify {
    public class user_data {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
    }

    [System.Serializable]
    public static class user_data_system {
        public static user_data load_data() {
            if (File.Exists(Directory.GetCurrentDirectory() + "info.usr")) {
                BinaryFormatter formatter = new BinaryFormatter();
                user_data data;
                using (var stream = new FileStream(Directory.GetCurrentDirectory() + "info.usr", FileMode.Open))
                    data = formatter.Deserialize(stream) as user_data;
                return data;
            } else
                return null;
        }

        public static void save_data() {
            BinaryFormatter formatter = new BinaryFormatter();
            user_data data = new user_data();
            using (var stream = new FileStream(Directory.GetCurrentDirectory() + "info.usr", FileMode.Create))
                formatter.Serialize(stream, data);
        }
    }
}
