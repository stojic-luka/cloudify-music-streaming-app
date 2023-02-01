using IniParser;
using IniParser.Model;
using System;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace C1oudify {
    public partial class login_form : Form {
        string HOSTNAME = "127.0.0.1";
        int PORT = 31536;
        int SEGMENT_SIZE = 1024;
        int MESSAGE_LENGTH_SEGMENT = 15;
        NetworkStream stream;
        TcpClient client;

        public login_form() {
            InitializeComponent();
            this.BackColor = Color.FromArgb(25, 25, 25);
        }

        #region . DON'T CHANGE .

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void top_panel_MouseDown(object sender, MouseEventArgs e) {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void exit_application() {
            if (client != null) client.Close();
            if (stream != null) stream.Close();
            this.Close();
            Environment.Exit(0);
        }

        private void red_button_exit_Click(object sender, EventArgs e) {
            exit_application();
        }

        private void yellow_button_minimize_Click(object sender, EventArgs e) {
            if (this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            else
                this.WindowState = FormWindowState.Maximized;
        }

        private void green_button_tray_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
        }

        private void go_to_main_form(bool online_or_offline = false) {
            this.Hide();
            main_form f2 = new main_form(stream, client, online_or_offline);
            f2.ShowDialog();
            exit_application();
        }

        #endregion

        private void login_form_Load(object sender, EventArgs e) {
            this.TransparencyKey = Color.Transparent;
            try {
                client = new TcpClient(HOSTNAME, PORT);
                if (send_and_listen_to_server_messages("('c0nnect_to_srv')") != "a11ow_c0nnection")
                    throw new ArgumentException("Server return value is not true");
            } catch (System.Net.Sockets.SocketException) {
                if (!File.Exists("info")) {
                    MessageBox.Show("You need internet connection for first login!");
                    this.Close();
                    Environment.Exit(0);
                }
                MessageBox.Show("Connection failed!");
                go_to_main_form();
                this.Close();
            } catch (System.ArgumentException) {
                MessageBox.Show("Can't connect to server!");
                go_to_main_form();
                this.Close();
            }
            login_password_textbox.PasswordChar = '*';
            string path = Directory.GetCurrentDirectory();
            string file = @"\info";
            if (File.Exists(path + file)) {
                try {
                    var parser = new FileIniDataParser();
                    IniData data = parser.ReadFile("info");

                    string login_tuple = "('login', '" + data["login"]["username"] + "', '" + data["login"]["pass"] + "')";
                    if (send_and_listen_to_server_messages(login_tuple) == "log1n_successful")
                        go_to_main_form(true);
                    else
                        throw new ArgumentException("Server return value is not true");
                } catch (System.NullReferenceException) {
                    MessageBox.Show("Failed to initialise the connection");
                    go_to_main_form();
                    this.Close();
                } catch (System.ArgumentException) {
                    this.Opacity = 100;
                }
            } else
                this.Opacity = 100;
        }

        #region . LOGIN PAGE .
         
        private void goto_signin_page_Click(object sender, EventArgs e) {
            startup_login_pages.SetPage(1);
        }

        private void click_to_search_login(object sender, EventArgs e) {
            if (username_textbox.Text.Length > 0 && login_password_textbox.Text.Length > 0)
                check_input_and_login();
            else
                bad_input_login_label.Visible = true;
        }

        private void enter_to_search_login(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                if (username_textbox.Text.Length > 0 && login_password_textbox.Text.Length > 0)
                    check_input_and_login();
                else
                    bad_input_login_label.Visible = true;
            }
        }

        private void check_input_and_login() {
            SHA256 sha256_algorythm = SHA256.Create();
            var hash = sha256_algorythm.ComputeHash(Encoding.UTF8.GetBytes(login_password_textbox.Text));
            string password_hash = BitConverter.ToString(hash).Replace("-", "").ToLower();
            string login_tuple = "('login', '" + username_textbox.Text + "', '" + password_hash + "')";
            if (send_and_listen_to_server_messages(login_tuple) == "log1n_successful") {
                if (!File.Exists("info")) {
                    using (StreamWriter outputFile = new StreamWriter("info"))
                        outputFile.WriteLine("[login]" + "\nusername = " + username_textbox.Text + "\npass = " + password_hash + "\n\n[settings]\nshuffle = 0\nrepeat = 0\naccent_color = purple\nartwork_size = 0\nsong_slider_and_buttons = 0\nmusic_volume = 0.75\nlast_played_song = null\nlast_song_time = 0");
                } else {
                    var parser = new FileIniDataParser();
                    IniData data = parser.ReadFile("info");
                    data["login"]["username"] = username_textbox.Text;
                    data["login"]["pass"] = password_hash;
                    parser.WriteFile("info", data);
                }
                go_to_main_form(true);
            } else
                bad_input_login_label.Visible = true;
        }

        int show_password_flag1 = -1;
        int show_password_flag2 = -1;
        int show_password_flag3 = -1;
        private void show_hide_password_Click(object sender, EventArgs e) {
            Button box = sender as Button;
            switch (box.Name) {
                case "show_hide_password":
                    show_password_flag1 *= -1;
                    if (show_password_flag1 == 1) {
                        show_hide_password.BackgroundImage = C1oudify.Properties.Resources.open_eye;
                        login_password_textbox.PasswordChar = '\0';
                    } else {
                        show_hide_password.BackgroundImage = C1oudify.Properties.Resources.close_eye;
                        login_password_textbox.PasswordChar = '*';
                    }
                    break;
                case "show_hide_signin_password":
                    show_password_flag2 *= -1;
                    if (show_password_flag2 == 1) {
                        show_hide_signin_password.BackgroundImage = C1oudify.Properties.Resources.open_eye;
                        pass_textbox_singin.PasswordChar = '\0';
                    } else {
                        show_hide_signin_password.BackgroundImage = C1oudify.Properties.Resources.close_eye;
                        pass_textbox_singin.PasswordChar = '*';
                    }
                    break;
                case "show_hide_signin_confirm_password":
                    show_password_flag3 *= -1;
                    if (show_password_flag3 == 1) {
                        show_hide_signin_confirm_password.BackgroundImage = C1oudify.Properties.Resources.open_eye;
                        pass_confirm_textbox_singin.PasswordChar = '\0';
                    } else {
                        show_hide_signin_confirm_password.BackgroundImage = C1oudify.Properties.Resources.close_eye;
                        pass_confirm_textbox_singin.PasswordChar = '*';
                    }
                    break;
            }
        }

        #endregion

        #region . SIGN IN PAGE .

        private void goto_login_page_Click(object sender, EventArgs e) {
            startup_login_pages.SetPage(0);
        }

        private void click_to_search_singin(object sender, EventArgs e) {
            if (username_textbox_signin.Text.Length != 0 || email_textbox_signin.Text.Length != 0 || pass_textbox_singin.Text.Length != 0 || pass_confirm_textbox_singin.Text.Length != 0) {
                if (check_if_username_is_available(username_textbox_signin.Text)) {
                    if (pass_textbox_singin.Text == pass_confirm_textbox_singin.Text) {
                        if (send_and_listen_to_server_messages("('conf1rm_email', '" + email_textbox_signin.Text + "', '" + username_textbox_signin.Text + "')") == "email_sent")
                            startup_login_pages.SetPage(2);
                    } else
                        passwords_not_match_labes.Visible = true;
                } else {
                    username_already_exist_label.Visible = true;
                    login_check_indicator.BackgroundImage = C1oudify.Properties.Resources.red_x;
                }
            } else
                bad_input_signin_label.Visible = true;
        }

        private void enter_to_search_signin(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter)
                click_to_search_singin(sender, e);
        }

        private void check_if_username_is_available_button_Click(object sender, EventArgs e) {
            if (check_if_username_is_available(username_textbox_signin.Text))
                login_check_indicator.BackgroundImage = C1oudify.Properties.Resources.green_check;
            else
                login_check_indicator.BackgroundImage = C1oudify.Properties.Resources.red_x;
        }

        private void username_textbox_signin_TextChanged(object sender, EventArgs e) {
            check_if_username_is_available_button_Click(sender, e);
        }

        private bool check_if_username_is_available(string username) {
            string check_username_tuple = "('check_username', '" + username + "')";
            if (send_and_listen_to_server_messages(check_username_tuple) == "username_available")
                return true;
            else
                return false;
        }

        #endregion

        #region . CONFIRM EMAIL .

        private void check_email_confirm_code_button_button_Click(object sender, EventArgs e) {
            string code_tuple = "('" + confirmation_code_textbox.Text + "')";
            if (send_and_listen_to_server_messages(code_tuple) == "correct_code")
                startup_login_pages.SetPage(3);
            else
                wrong_code_label.Visible = true;
        }

        #endregion

        #region . PHONE AND BDAY .

        private void month_dropdown_SelectedValueChanged(object sender, EventArgs e) {
            int max_days = 0;
            switch (month_dropdown.SelectedIndex) {
                case 0: max_days = 31; break;
                case 1:
                    if (Convert.ToInt16(DateTime.Now.Year) % 4 == 0)
                        max_days = 29;
                    else
                        max_days = 28;
                    break;
                case 2: max_days = 31; break;
                case 3: max_days = 30; break;
                case 4: max_days = 31; break;
                case 5: max_days = 30; break;
                case 6: max_days = 31; break;
                case 7: max_days = 31; break;
                case 8: max_days = 30; break;
                case 9: max_days = 31; break;
                case 10: max_days = 30; break;
                case 11: max_days = 31; break;
            }
            object[] days = new object[max_days];
            for (int i = 0; i < max_days; i++)
                days[i] = i + 1;
            day_dropdown.Items.Clear();
            day_dropdown.Items.AddRange(days);
        }

        private void startup_login_pages_SelectedIndexChanged(object sender, EventArgs e) {
            switch (startup_login_pages.PageIndex) {
                case 3:
                    object[] years = new object[100];
                    for (int i = 0; i < 100; i++) {
                        years[i] = i + DateTime.Now.Year - 100;
                    }
                    Array.Reverse(years);
                    year_dropdown.Items.Clear();
                    year_dropdown.Items.AddRange(years);
                    break;
            }
        }

        public void send_sign_in_info(object sender, EventArgs e) {
            SHA256 sha256_algorythm = SHA256.Create();
            var hash = sha256_algorythm.ComputeHash(Encoding.UTF8.GetBytes(pass_textbox_singin.Text));
            string password_hash = BitConverter.ToString(hash).Replace("-", "").ToLower(), sign_in_tuple;
            Button btn = sender as Button;
            if (btn.Name == "phone_and_bday_finish")
                sign_in_tuple = "('sign_in', '" + email_textbox_signin.Text + "', '" + username_textbox_signin.Text + "', '" + password_hash + "', '" + day_dropdown.SelectedItem + "/" + month_dropdown.SelectedItem + "/" + year_dropdown.SelectedItem + "', '" + phone_num_textbox.Text + "')";
            else
                sign_in_tuple = "('sign_in', '" + email_textbox_signin.Text + "', '" + username_textbox_signin.Text + "', '" + password_hash + "')";
            send_and_listen_to_server_messages(sign_in_tuple);
            startup_login_pages.SetPage(4);
        }

        #endregion

        #region . SOCKET AND ENCRYPTION (DON'T CHANGE).

        private string send_and_listen_to_server_messages(string tuple, string message = null) {
            if (message != null)
                send_message_to_server(tuple, message);
            else
                send_message_to_server(tuple);
            string b = null;
            Thread listen_to_massages_thread = new Thread(() => {
                Byte[] a = new Byte[client.ReceiveBufferSize];
                int read = stream.Read(a, 0, a.Length);
                if (read > 0) {
                    Byte[] buffer = new Byte[read];
                    for (int i = 0; i < read; i++)
                        buffer[i] = a[i];
                    b = aes256_decrypt(buffer);
                }
            });
            listen_to_massages_thread.Start();
            listen_to_massages_thread.Join();
            return b;
        }

        private void send_message_to_server(string header_json_str, string message = "") {
            Byte[] header_len = Encoding.UTF8.GetBytes((message.Length).ToString()), header_json = Encoding.UTF8.GetBytes(header_json_str), header = new Byte[SEGMENT_SIZE];
            if (header_json.Length > (SEGMENT_SIZE - MESSAGE_LENGTH_SEGMENT)) {
                MessageBox.Show("Json too big for header");
                this.Close();
            }
            for (int i = 0; i < SEGMENT_SIZE; i++) {
                if (i < header_len.Length)
                    header[i] = header_len[i];
                if (i >= MESSAGE_LENGTH_SEGMENT && i < (header_json.Length + MESSAGE_LENGTH_SEGMENT))
                    header[i] = header_json[i - MESSAGE_LENGTH_SEGMENT];
            }
            int message_byte_count = Encoding.UTF8.GetByteCount(message);
            Byte[] message_byte = Encoding.UTF8.GetBytes(message), send_data = new Byte[SEGMENT_SIZE + message_byte_count];
            for (int i = 0; i < SEGMENT_SIZE + message_byte_count; i++)
                send_data[i] = (byte)'\x01';
            for (int i = 0; i < SEGMENT_SIZE + message_byte_count; i++) {
                if (i < header.Length)
                    send_data[i] = header[i];
                if (i >= SEGMENT_SIZE)
                    send_data[i] = message_byte[i - SEGMENT_SIZE];
            }
            send_data = aes256_encrypt(send_data);
            stream = client.GetStream();
            stream.Write(send_data, 0, send_data.Length);
        }

        private static Byte[] aes256_encrypt(Byte[] plainText) {
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            using (RijndaelManaged cipher = new RijndaelManaged()) {
                cipher.Key = Convert.FromBase64String("Pu8TlKZ8yjKagitvsI41w9rIpunlGFYJbiMnyays7I0=");
                cipher.Mode = CipherMode.ECB;
                cipher.BlockSize = 128;
                Byte[] cipherTextBytes = null;
                using (MemoryStream memStream = new MemoryStream())
                using (CryptoStream cryptoStream = new CryptoStream(memStream, cipher.CreateEncryptor(cipher.Key, null), CryptoStreamMode.Write)) {
                    cryptoStream.Write(plainText, 0, plainText.Length);
                    cryptoStream.Flush();
                    cryptoStream.FlushFinalBlock();
                    cryptoStream.Flush();
                    cryptoStream.Close();
                    cipherTextBytes = memStream.ToArray();
                    memStream.Close();
                }
                return cipherTextBytes;
            }
        }

        private static string aes256_decrypt(Byte[] cipherText) {
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            using (RijndaelManaged cipher = new RijndaelManaged()) {
                cipher.Key = Convert.FromBase64String("Pu8TlKZ8yjKagitvsI41w9rIpunlGFYJbiMnyays7I0=");
                cipher.Mode = CipherMode.ECB;
                cipher.BlockSize = 128;
                using (MemoryStream memStream = new MemoryStream(cipherText))
                using (CryptoStream cryptoStream = new CryptoStream(memStream, cipher.CreateDecryptor(cipher.Key, null), CryptoStreamMode.Read))
                using (StreamReader streamReader = new StreamReader(cryptoStream)) {
                    return streamReader.ReadToEnd().Trim('\x01');
                }
            }
        }

        #endregion

        private void button3_Click(object sender, EventArgs e) {
            startup_login_pages.SetPage(3);
        }
    }
}
