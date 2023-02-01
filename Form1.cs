using IniParser;
using IniParser.Model;
using Ionic.Zip;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace C1oudify {
    public partial class main_form : Form {
        private static int SEGMENT_SIZE = 1024;
        private static int MESSAGE_LENGTH_SEGMENT = 15;
        private NetworkStream stream;
        private TcpClient client;

        private bool global_offline_indicator = false;

        private Color default_chosen_color;

        private float music_volume;
        private string current_song_id = "";

        private int song_slider_segments_len = 200;

        private static int border_size = 2;
        private Size formSize;

        public main_form(NetworkStream stream1, TcpClient client1, bool online_or_offline) {
            InitializeComponent();
            stream = stream1;
            client = client1;

            global_offline_indicator = online_or_offline;

            if (!online_or_offline) {
                offline_indicator_label.Visible = true;
            }
        }

        private void main_form_Load(object sender, EventArgs e) {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("info");

            accent_color_combobox.Items.Clear();
            accent_color_combobox.Items.AddRange(new object[] { "red", "orange", "yellow", "lime", "green", "cyan", "blue", "purple", "magenta", "pink" });
            accent_color_combobox.SelectedItem = data["settings"]["accent_color"];

            artwork_size_toggle_switch.Value = Convert.ToBoolean(int.Parse(data["settings"]["artwork_size"]));
            song_slider_playback_buttons_toggle_switch.Value = Convert.ToBoolean(int.Parse(data["settings"]["song_slider_and_buttons"]));
            music_volume = float.Parse(data["settings"]["music_volume"]);
            song_volume_slider.Value = (int)(music_volume * 100);
            song_slider.Maximum = song_slider_segments_len;

            if (!Convert.ToBoolean(int.Parse(data["settings"]["shuffle"])))
                shuffle_button_flag *= -1;
            shuffle_button_Click(sender, e);

            repeat_song_button_counter = int.Parse(data["settings"]["repeat"]);
            repeat_song_button_Click(sender, e);

            Thread last_song_preload = new Thread(() => {
                using (var zipFile = ZipFile.Read("lpsi"))
                using (var memstream = new MemoryStream()) {
                    zipFile.Password = @"$3PuDn:&ug=AFiA";
                    foreach (var zip1 in zipFile.Entries) {
                        zip1.Extract(memstream);
                        switch (zip1.FileName) {
                            case "artwork": song_album_image.BackgroundImage = new Bitmap(memstream); memstream.SetLength(0); break;
                            case "json":
                                var json_dynamic = JsonConvert.DeserializeObject<dynamic>(Encoding.UTF8.GetString(memstream.GetBuffer(), 0, (int)memstream.Length));
                                this.Invoke((Action)delegate
                                {
                                    song_title.Text = json_dynamic.title;
                                    song_artist.Text = json_dynamic.artist;
                                    this.Refresh();
                                });
                                memstream.SetLength(0);
                                break;
                            case "lyrics":
                                lyrics_box.Items.Clear();
                                lyrics_box.Items.AddRange(Encoding.UTF8.GetString(memstream.ToArray()).Split('\n'));
                                memstream.SetLength(0);
                                break;
                        }
                    }
                }
            });
            last_song_preload.Start();

            vlc_player.SetMedia(new Uri("https://3nzzmix3erxakzto4dl6hq-on.drv.tw/website/song/" + data["settings"]["last_played_song"] + "_song"));

            if (artwork_size_toggle_switch.Value)
                artwork_size_toggle_switch_CheckedChanged(sender, new Bunifu.UI.WinForms.BunifuToggleSwitch.CheckedChangedEventArgs(true));
            else
                artwork_size_toggle_switch_CheckedChanged(sender, new Bunifu.UI.WinForms.BunifuToggleSwitch.CheckedChangedEventArgs(false));

            if (song_slider_playback_buttons_toggle_switch.Value)
                song_slider_playback_buttons_toggle_switch_CheckedChanged(sender, new Bunifu.UI.WinForms.BunifuToggleSwitch.CheckedChangedEventArgs(true));
            else
                song_slider_playback_buttons_toggle_switch_CheckedChanged(sender, new Bunifu.UI.WinForms.BunifuToggleSwitch.CheckedChangedEventArgs(false));

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.FlatStyle = FlatStyle.Popup;
            btn.DefaultCellStyle.ForeColor = Color.FromArgb(255, 66, 66, 66);

        }

        #region . DON'T CHANGE .

        #region . ENABLE WINDOW MOVING .
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void top_panel_MouseDown(object sender, MouseEventArgs e) {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        protected override void WndProc(ref Message m) {
            const int WM_NCCALCSIZE = 0x0083;
            if (m.Msg == WM_NCCALCSIZE && m.WParam.ToInt32() == 1)
                return;
            base.WndProc(ref m);
        }

        private void main_form_Resize(object sender, EventArgs e) {
            switch (this.WindowState) {
                case FormWindowState.Maximized:
                    this.Padding = new Padding(0, 8, 8, 0);
                    break;
                case FormWindowState.Normal:
                    if (this.Padding.Top != border_size)
                        this.Padding = new Padding(border_size);
                    break;
            }
        }
        #endregion

        private void exit_application() {
            vlc_player.Stop();
            vlc_player.Dispose();
            if (global_offline_indicator) {
                try { client.Close(); } catch { }
                try { stream.Close(); } catch { }
            }
            this.Close();
        }

        #region . TOP BUTTONS .

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

        #endregion

        #endregion

        #region . SEARCH .

        private void main_search_button_Click(object sender, EventArgs e) {
            add_songs_to_search_datagridview(send_and_listen_to_server_messages("('search_song', '" + main_search_box.Text + "')"));
        }

        private void main_search_box_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter)
                add_songs_to_search_datagridview(send_and_listen_to_server_messages("('search_song', '" + main_search_box.Text + "')"));
        }

        private void add_songs_to_search_datagridview(string search_info) {
            string[] raw_info = search_info.Split(',');
            string[] song_seperated_info = raw_info[0].Split('"'), artist_seperated_info = raw_info[1].Split('"');

            search_song_display.Rows.Clear();
            search_artist_display.Rows.Clear();

            string song_seperated_str;
            string[] song_seperated;
            Thread add_items_to_dataview = new Thread(() => {
                try {
                    for (int i = 0; i < song_seperated_info.Length; i++) {
                        song_seperated_str = base64_convert(song_seperated_info[i]);
                        song_seperated = song_seperated_str.Split(';');
                        if (song_seperated[0].ToString().Length < 1)
                            break;
                        Console.WriteLine(song_seperated[0].ToString());
                        Bitmap song_search_artwork = new Bitmap(WebRequest.Create("https://3nzzmix3erxakzto4dl6hq-on.drv.tw/website/artwork/" + song_seperated[0].ToString() + "_artwork").GetResponse().GetResponseStream());
                        this.Invoke((Action)delegate
                        {
                            search_song_display.Rows.Add(song_search_artwork, song_seperated[1], song_seperated[0]);
                        });
                    }
                    for (int i = 0; i < artist_seperated_info.Length; i++) {
                        if (base64_convert(artist_seperated_info[i]).Length < 1)
                            break;
                        this.Invoke((Action)delegate
                        {
                            search_artist_display.Rows.Add(null, base64_convert(artist_seperated_info[i]));
                        });
                    }
                } catch { }
            });
            add_items_to_dataview.Start();

            string base64_convert(string base64_str) {
                return Encoding.UTF8.GetString(System.Convert.FromBase64String(base64_str));
            }
        }

        private void search_song_display_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (e.ColumnIndex == 3) 
                play_song_function(search_song_display.Rows[e.RowIndex].Cells[2].Value.ToString());
        }

        #endregion

        #region . MEDIA PLAYER, BUTTONS AND SLIDERS .

        private void song_volume_slider_ValueChanged(object sender, Utilities.BunifuSlider.BunifuHScrollBar.ValueChangedEventArgs e) {
            vlc_player.Audio.Volume = song_volume_slider.Value;

            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("info");
            data["settings"]["music_volume"] = Convert.ToString((float)song_volume_slider.Value / 100);
            parser.WriteFile("info", data);

            if (song_volume_slider.Value > 100)
                song_volume_button.BackgroundImage = new Bitmap(C1oudify.Properties.Resources.speaker_99);
            else if (song_volume_slider.Value <= 100 && song_volume_slider.Value >= 50)
                song_volume_button.BackgroundImage = new Bitmap(C1oudify.Properties.Resources.speaker_66);
            else if (song_volume_slider.Value <= 50 && song_volume_slider.Value > 0)
                song_volume_button.BackgroundImage = new Bitmap(C1oudify.Properties.Resources.speaker_33);
            else
                song_volume_button.BackgroundImage = new Bitmap(C1oudify.Properties.Resources.mute);
        }

        bool set_time_bar = true;
        private void song_slider_MouseDown(object sender, MouseEventArgs e) {
            set_time_bar = false;
        }

        private void song_slider_MouseUp(object sender, MouseEventArgs e) {
            vlc_player.Time = (int)((vlc_player.Length * song_slider.Value) / song_slider_segments_len);
            set_time_bar = true;
        }

        private void vlc_player_LengthChanged(object sender, Vlc.DotNet.Core.VlcMediaPlayerLengthChangedEventArgs e) {
            int minute = ((int)vlc_player.Length / 1000) / 60;
            int second = ((int)vlc_player.Length / 1000) - (minute * 60);
            this.Invoke((Action)delegate
            {
                if (second < 10)
                    song_length_label.Text = minute.ToString() + ":0" + second.ToString();
                else
                    song_length_label.Text = minute.ToString() + ":" + second.ToString();
            });
        }

        private void vlc_player_TimeChanged(object sender, Vlc.DotNet.Core.VlcMediaPlayerTimeChangedEventArgs e) {
            if (set_time_bar) {
                song_slider.Value = (int)((e.NewTime * song_slider_segments_len) / vlc_player.Length);
                int minute = ((int)vlc_player.Time / 1000) / 60;
                int second = ((int)vlc_player.Time / 1000) - (minute * 60);
                this.Invoke((Action)delegate
                {
                    if (second < 10)
                        song_passed_seconds_label.Text = minute.ToString() + ":0" + second.ToString();
                    else
                        song_passed_seconds_label.Text = minute.ToString() + ":" + second.ToString();
                });
                var parser = new FileIniDataParser();
                IniData data = parser.ReadFile("info");
                data["settings"]["last_song_time"] = Convert.ToString((int)vlc_player.Time / 1000);
                parser.WriteFile("info", data);
            }
        }

        private void previous_song_button_Click(object sender, EventArgs e) {
            string song_before = send_and_listen_to_server_messages("('previous_song', '" + current_song_id + "')");
        }

        private void next_song_button_Click(object sender, EventArgs e) {
            string song_after = send_and_listen_to_server_messages("('next_song', '" + current_song_id + "')");
        }

        int music_play_pause_button_flag = 1;
        private void music_play_pause_button_Click(object sender, EventArgs e) {
            if (music_play_pause_button_flag == 1) {
                Bitmap bmp = new Bitmap(C1oudify.Properties.Resources.pause);
                music_play_pause_button.BackgroundImage = bmp;
                vlc_player.Play();
            } else {
                Bitmap bmp = new Bitmap(C1oudify.Properties.Resources.play);
                music_play_pause_button.BackgroundImage = bmp;
                vlc_player.Pause();
            }
            this.Refresh();
            music_play_pause_button_flag *= -1;
        }

        int shuffle_button_flag = -1;
        private void shuffle_button_Click(object sender, EventArgs e) {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("info");
            shuffle_button_flag *= -1;
            if (shuffle_button_flag == -1) {
                Bitmap bmp = new Bitmap(C1oudify.Properties.Resources.shuffle);
                shuffle_button.BackgroundImage = bmp;
                data["settings"]["shuffle"] = "0";
            } else {
                Bitmap bmp = new Bitmap(C1oudify.Properties.Resources.shuffle);
                for (int i = 0; i < bmp.Width; i++)
                    for (int j = 0; j < bmp.Height; j++)
                        bmp.SetPixel(i, j, Color.FromArgb(bmp.GetPixel(i, j).A, default_chosen_color.R, default_chosen_color.G, default_chosen_color.B));
                shuffle_button.BackgroundImage = bmp;
                data["settings"]["shuffle"] = "1";
            }
            this.Refresh();
            parser.WriteFile("info", data);
        }

        int repeat_song_button_counter = 1;
        private void repeat_song_button_Click(object sender, EventArgs e) {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("info");
            switch (repeat_song_button_counter) {
                case 0:
                    repeat_song_button_counter++;
                    repeat_song_button.BackgroundImage = new Bitmap(C1oudify.Properties.Resources.repeat);
                    data["settings"]["repeat"] = "0";
                    break;
                case 1:
                    repeat_song_button_counter++;
                    Bitmap bmp2 = new Bitmap(C1oudify.Properties.Resources.repeat);
                    for (int i = 0; i < bmp2.Width; i++)
                        for (int j = 0; j < bmp2.Height; j++)
                            bmp2.SetPixel(i, j, Color.FromArgb(bmp2.GetPixel(i, j).A, default_chosen_color.R, default_chosen_color.G, default_chosen_color.B));
                    repeat_song_button.BackgroundImage = bmp2;
                    data["settings"]["repeat"] = "1";
                    break;
                case 2:
                    repeat_song_button_counter = 0;
                    Bitmap bmp3 = new Bitmap(C1oudify.Properties.Resources.repeat_one);
                    for (int i = 0; i < bmp3.Width; i++)
                        for (int j = 0; j < bmp3.Height; j++)
                            bmp3.SetPixel(i, j, Color.FromArgb(bmp3.GetPixel(i, j).A, default_chosen_color.R, default_chosen_color.G, default_chosen_color.B));
                    repeat_song_button.BackgroundImage = bmp3;
                    data["settings"]["repeat"] = "1";
                    break;
            }
            this.Refresh();
            parser.WriteFile("info", data);
        }

        private void play_song_function(string id) {
            vlc_player.Play(new Uri("https://3nzzmix3erxakzto4dl6hq-on.drv.tw/website/song/" + id + "_song"));
            vlc_player.Audio.Volume = song_volume_slider.Value;
            if (music_play_pause_button.BackgroundImage != C1oudify.Properties.Resources.pause) {
                music_play_pause_button_flag *= -1;
                music_play_pause_button.BackgroundImage = C1oudify.Properties.Resources.pause;
            }

            Bitmap artwork_data = new Bitmap(WebRequest.Create("https://3nzzmix3erxakzto4dl6hq-on.drv.tw/website/artwork/" + id + "_artwork").GetResponse().GetResponseStream());
            song_album_image.BackgroundImage = artwork_data;
            var json = new WebClient().DownloadString("https://3nzzmix3erxakzto4dl6hq-on.drv.tw/website/json/" + id + "_json");
            var json_dynamic = JsonConvert.DeserializeObject<dynamic>(json);
            song_title.Text = json_dynamic.title;
            song_artist.Text = json_dynamic.artist;
            string lyrics_box_data = new WebClient().DownloadString("https://3nzzmix3erxakzto4dl6hq-on.drv.tw/website/lyrics/" + id + "_lyrics");
            lyrics_box.Items.Clear();
            lyrics_box.Items.AddRange(lyrics_box_data.Split('\n'));

            Thread save_last_played_song_info = new Thread(() => {
                if (File.Exists("lpsi"))
                    File.Delete("lpsi");
                using (var zip = new ZipFile()) {
                    zip.Encryption = EncryptionAlgorithm.WinZipAes128;
                    zip.Password = @"$3PuDn:&ug=AFiA";
                    var memstream = new MemoryStream();
                    artwork_data.Save(memstream, ImageFormat.Jpeg);
                    memstream.Seek(0, SeekOrigin.Begin);
                    zip.AddEntry("artwork", memstream);
                    memstream = new MemoryStream(Encoding.UTF8.GetBytes(json));
                    memstream.Seek(0, SeekOrigin.Begin);
                    zip.AddEntry("json", memstream);
                    memstream = new MemoryStream(Encoding.UTF8.GetBytes(lyrics_box_data));
                    memstream.Seek(0, SeekOrigin.Begin);
                    zip.AddEntry("lyrics", memstream);
                    zip.Save(Directory.GetCurrentDirectory() + "\\lpsi");
                }
            });
            save_last_played_song_info.Start();

            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("info");
            data["settings"]["last_played_song"] = id;
            parser.WriteFile("info", data);
        }

        #endregion

        #region . PLAYLIST AND CREATE PLAYLIST .

        private void playlist_song_search_TextChanged(object sender, EventArgs e) {

        }

        private void found_songs_playlist_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (e.ColumnIndex == 2)
                songs_added_to_playlist.Rows.Add(found_songs_playlist.Rows[e.RowIndex].Cells[0].Value, found_songs_playlist.Rows[e.RowIndex].Cells[1].Value, null, found_songs_playlist.Rows[e.RowIndex].Cells[3].Value);
            if (found_songs_playlist.Rows.Count == 0)
                search_a_song_playlist_lable.Visible = true;
            else
                search_a_song_playlist_lable.Visible = false;
        }

        private void songs_added_to_playlist_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (e.ColumnIndex == 2) {
                songs_added_to_playlist.Rows.RemoveAt(e.RowIndex);
            }
        }

        #endregion

        #region . DOWNLOADER .

        private void autofill_button_Click(object sender, EventArgs e) {
            Button autofill_btn = sender as Button;
            string autofill_resp;
            if (autofill_btn.Name == "autofill_song_button")
                autofill_resp = send_and_listen_to_server_messages("('autofill', 'from_song', '" + song_link_textbox.Text + "')");
            else
                autofill_resp = send_and_listen_to_server_messages("('autofill', 'from_lyrics', '" + song_lyrics_link_textbox.Text + "')");
            if (autofill_resp != "wr0ng_1!nk_!nputed") {
                string[] split_result = autofill_resp.Split(new string[] { "@image@" }, StringSplitOptions.None);

                using (var image_bytes_data = new MemoryStream(System.Convert.FromBase64String(split_result[1]))) {
                    song_download_artwork.BackgroundImage = new Bitmap(image_bytes_data);
                }

                string[] autofill_resp_arr = split_result[0].Split('"');
                song_artist_textbox.Text = Encoding.UTF8.GetString(System.Convert.FromBase64String(autofill_resp_arr[0]));
                song_title_textbox.Text = Encoding.UTF8.GetString(System.Convert.FromBase64String(autofill_resp_arr[1]));
                if (Encoding.UTF8.GetString(System.Convert.FromBase64String(autofill_resp_arr[2])) == "the_s0ng_has_n0_album_1ts_s!ngle") {
                    album_single_checkbox.Checked = true;
                    song_album_textbox.Text = "";
                } else {
                    album_single_checkbox.Checked = false;
                    song_album_textbox.Text = Encoding.UTF8.GetString(System.Convert.FromBase64String(autofill_resp_arr[2]));
                }
                song_download_artwork.Tag = Encoding.UTF8.GetString(System.Convert.FromBase64String(autofill_resp_arr[3]));
            }
        }

        private bool check_if_link_is_valid(string url) {
            try {
                Uri outUri = new Uri(url);
                if (Uri.TryCreate(url, UriKind.Absolute, out outUri) && (outUri.Scheme == Uri.UriSchemeHttp || outUri.Scheme == Uri.UriSchemeHttps))
                    return true;
                else
                    return false;
            } catch { return false; }
        }

        private void song_link_textbox_TextChanged(object sender, EventArgs e) {
            if (check_if_link_is_valid(song_link_textbox.Text) && (song_link_textbox.Text.IndexOf("www.youtube.com") != -1 || song_link_textbox.Text.IndexOf("youtu.be") != -1 || song_link_textbox.Text.IndexOf("spotify.com/track/") != -1))
                song_link_textbox.BackColor = Color.FromArgb(192, 255, 192);
            else
                song_link_textbox.BackColor = Color.FromArgb(255, 128, 128);
        }

        private void song_lyrics_link_textbox_TextChanged(object sender, EventArgs e) {
            if (check_if_link_is_valid(song_lyrics_link_textbox.Text) && song_lyrics_link_textbox.Text.IndexOf("genius.com") != -1) {
                song_lyrics_link_textbox.BackColor = Color.FromArgb(192, 255, 192);
                autofill_lyrics_button.ForeColor = System.Drawing.Color.WhiteSmoke;
                autofill_lyrics_button.Enabled = true;
            } else {
                song_lyrics_link_textbox.BackColor = Color.FromArgb(255, 128, 128);
                autofill_lyrics_button.ForeColor = System.Drawing.Color.DimGray;
                autofill_lyrics_button.Enabled = false;
            }
        }

        private void album_single_checkbox_CheckedChanged(object sender, EventArgs e) {
            if (album_single_checkbox.Checked) {
                song_album_textbox.Enabled = false;
                song_album_textbox.BackColor = System.Drawing.Color.Gray;
            } else {
                song_album_textbox.Enabled = true;
                song_album_textbox.BackColor = System.Drawing.Color.LightGray;
            }
        }

        private void send_download_data_button_Click(object sender, EventArgs e) {
            if (song_link_textbox.Text.Length > 0 && song_lyrics_link_textbox.Text.Length > 0 && song_title_textbox.Text.Length > 0 && song_artist_textbox.Text.Length > 0 && (song_album_textbox.Text.Length > 0 || album_single_checkbox.Checked)) {
                string song_downloaded_or_not;
                if (album_single_checkbox.Checked)
                    song_downloaded_or_not = send_and_listen_to_server_messages("('download_song', '" + song_link_textbox.Text + "', '" + song_lyrics_link_textbox.Text + "', '" + song_title_textbox.Text + "', '" + song_artist_textbox.Text + "', '" + song_title_textbox.Text + "', '" + song_download_artwork.Tag + "')");
                else
                    song_downloaded_or_not = send_and_listen_to_server_messages("('download_song', '" + song_link_textbox.Text + "', '" + song_lyrics_link_textbox.Text + "', '" + song_title_textbox.Text + "', '" + song_artist_textbox.Text + "', '" + song_album_textbox.Text + "', '" + song_download_artwork.Tag + "')");
            } else {
                input_valid_supported_link_label.Visible = true;
            }
        }

        #endregion
        // add proper fix for spotify links and add check on download button
        // spotify.com/track/ not supported by request

        #region . SIDE BUTTONS AND PAGES .

        private void page_changer_button_Click(object sender, EventArgs e) {
            Button someButton = sender as Button;
            Color color75 = Color.FromArgb(250, 75, 75, 75);
            switch (someButton.Name) {
                case "home_page_button": bunifu_pages_main.SetPage(0); home_page_button.BackColor = color75; break;
                case "search_page_button": bunifu_pages_main.SetPage(4); search_page_button.BackColor = color75; break;
                case "your_playlist_button": bunifu_pages_main.SetPage(6); your_playlist_button.BackColor = color75; break;
                case "create_playlist_button": bunifu_pages_main.SetPage(5); create_playlist_button.BackColor = color75; break;
                case "liked_songs_button": bunifu_pages_main.SetPage(1); liked_songs_button.BackColor = color75; break;
                case "suggested_songs_button": bunifu_pages_main.SetPage(2); suggested_songs_button.BackColor = color75; break;
                case "settings_page_button": bunifu_pages_main.SetPage(3); break;
                case "download_page_button": bunifu_pages_main.SetPage(8); break;
                case "lyrics_page_button": bunifu_pages_main.SetPage(7); break;
            }
        }

        private void bunifu_pages_main_SelectedIndexChanged(object sender, EventArgs e) {
            Color color44 = Color.FromArgb(250, 44, 44, 44);
            if (bunifu_pages_main.PageIndex != 0) home_page_button.BackColor = color44;
            if (bunifu_pages_main.PageIndex != 4) search_page_button.BackColor = color44;
            if (bunifu_pages_main.PageIndex != 6) your_playlist_button.BackColor = color44;
            if (bunifu_pages_main.PageIndex != 5) create_playlist_button.BackColor = color44;
            if (bunifu_pages_main.PageIndex != 1) liked_songs_button.BackColor = color44;
            if (bunifu_pages_main.PageIndex != 2) suggested_songs_button.BackColor = color44;

            if (bunifu_pages_main.PageIndex == 4) {
                main_search_box.Visible = true;
                main_search_button.Visible = true;
            } else {
                main_search_box.Visible = false;
                main_search_button.Visible = false;
            }
        }

        #endregion

        #region . SETTINGS .

        private void accent_color_combobox_SelectedValueChanged(object sender, EventArgs e) {
            ComboBox box = sender as ComboBox;
            change_accent_color(box.SelectedItem.ToString());

            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("info");
            data["settings"]["accent_color"] = box.SelectedItem.ToString();
            parser.WriteFile("info", data);
        }

        private void artwork_size_toggle_switch_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuToggleSwitch.CheckedChangedEventArgs e) {
            if (artwork_size_toggle_switch.Value == true) {
                song_album_image.Location = new System.Drawing.Point(29, 34);
                song_album_image.Size = new System.Drawing.Size(129, 114);

                song_title.Location = new System.Drawing.Point(155, 49);
                song_title.Size = new System.Drawing.Size(175, 64);

                song_artist.Location = new System.Drawing.Point(155, 111);
                song_artist.Size = new System.Drawing.Size(175, 20);

                song_slider_playback_buttons_toggle_switch_CheckedChanged(sender, e);
            } else {
                song_album_image.Location = new System.Drawing.Point(76, 33);
                song_album_image.Size = new System.Drawing.Size(180, 165);

                song_title.Location = new System.Drawing.Point(20, 204);
                song_title.Size = new System.Drawing.Size(298, 25);

                song_artist.Location = new System.Drawing.Point(23, 229);
                song_artist.Size = new System.Drawing.Size(291, 20);

                song_slider_playback_buttons_toggle_switch_CheckedChanged(sender, e);
            }
            this.Refresh();

            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("info");
            data["settings"]["artwork_size"] = Convert.ToString(artwork_size_toggle_switch.Value ? 1 : 0);
            parser.WriteFile("info", data);
        }

        private void song_slider_playback_buttons_toggle_switch_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuToggleSwitch.CheckedChangedEventArgs e) {
            if (!artwork_size_toggle_switch.Value) {
                if (song_slider_playback_buttons_toggle_switch.Value == true) {
                    shuffle_button.Location = new System.Drawing.Point(27, 264);
                    repeat_song_button.Location = new System.Drawing.Point(287, 264);
                    previous_song_button.Location = new System.Drawing.Point(111, 266);
                    next_song_button.Location = new System.Drawing.Point(204, 266);
                    music_play_pause_button.Location = new System.Drawing.Point(152, 259);

                    song_slider.Location = new System.Drawing.Point(38, 300);
                    song_length_label.Location = new System.Drawing.Point(297, 303);
                    song_passed_seconds_label.Location = new System.Drawing.Point(-3, 304);
                } else {
                    shuffle_button.Location = new System.Drawing.Point(27, 289);
                    repeat_song_button.Location = new System.Drawing.Point(287, 289);
                    previous_song_button.Location = new System.Drawing.Point(111, 291);
                    next_song_button.Location = new System.Drawing.Point(204, 291);
                    music_play_pause_button.Location = new System.Drawing.Point(152, 284);

                    song_slider.Location = new System.Drawing.Point(38, 254);
                    song_length_label.Location = new System.Drawing.Point(297, 257);
                    song_passed_seconds_label.Location = new System.Drawing.Point(-3, 258);
                }
            } else {
                if (song_slider_playback_buttons_toggle_switch.Value == true) {
                    shuffle_button.Location = new System.Drawing.Point(27, 171);
                    repeat_song_button.Location = new System.Drawing.Point(287, 171);
                    previous_song_button.Location = new System.Drawing.Point(111, 173);
                    next_song_button.Location = new System.Drawing.Point(204, 173);
                    music_play_pause_button.Location = new System.Drawing.Point(152, 166);

                    song_slider.Location = new System.Drawing.Point(38, 206);
                    song_length_label.Location = new System.Drawing.Point(297, 209);
                    song_passed_seconds_label.Location = new System.Drawing.Point(-3, 210);
                } else {
                    shuffle_button.Location = new System.Drawing.Point(27, 199);
                    repeat_song_button.Location = new System.Drawing.Point(287, 199);
                    previous_song_button.Location = new System.Drawing.Point(111, 201);
                    next_song_button.Location = new System.Drawing.Point(204, 201);
                    music_play_pause_button.Location = new System.Drawing.Point(152, 194);

                    song_slider.Location = new System.Drawing.Point(38, 165);
                    song_length_label.Location = new System.Drawing.Point(297, 168);
                    song_passed_seconds_label.Location = new System.Drawing.Point(-3, 169);
                }
            }
            this.Refresh();

            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("info");
            data["settings"]["song_slider_and_buttons"] = Convert.ToString(song_slider_playback_buttons_toggle_switch.Value ? 1 : 0);
            parser.WriteFile("info", data);
        }

        private void change_accent_color(string clr) {
            switch (clr) {
                case "red": default_chosen_color = ColorTranslator.FromHtml("#ff0000"); break;
                case "orange": default_chosen_color = ColorTranslator.FromHtml("#ff8600"); break;
                case "yellow": default_chosen_color = ColorTranslator.FromHtml("#e6e600"); break;
                case "lime": default_chosen_color = ColorTranslator.FromHtml("#00ff00"); break;
                case "green": default_chosen_color = ColorTranslator.FromHtml("#00b300"); break;
                case "cyan": default_chosen_color = ColorTranslator.FromHtml("#00e3ec"); break;
                case "blue": default_chosen_color = ColorTranslator.FromHtml("#0083ec"); break;
                case "purple": default_chosen_color = ColorTranslator.FromHtml("#7235ff"); break;
                case "magenta": default_chosen_color = ColorTranslator.FromHtml("#ff18af"); break;
                case "pink": default_chosen_color = ColorTranslator.FromHtml("#ed5bed"); break;
                default: default_chosen_color = ColorTranslator.FromHtml("#7235ff"); break; //purple
            }

            song_slider.ElapsedColor = default_chosen_color;
            song_slider.ThumbFillColor = default_chosen_color;

            song_volume_slider.ElapsedColor = default_chosen_color;
            song_volume_slider.ThumbFillColor = default_chosen_color;

            artwork_size_toggle_switch.ToggleStateOn.BackColor = default_chosen_color;
            artwork_size_toggle_switch.ToggleStateOn.BorderColor = default_chosen_color;
            artwork_size_toggle_switch.ToggleStateOn.BorderColorInner = default_chosen_color;
            artwork_size_toggle_switch.ToggleStateOn.BorderColorInner = default_chosen_color;

            song_slider_playback_buttons_toggle_switch.ToggleStateOn.BackColor = default_chosen_color;
            song_slider_playback_buttons_toggle_switch.ToggleStateOn.BorderColor = default_chosen_color;
            song_slider_playback_buttons_toggle_switch.ToggleStateOn.BorderColorInner = default_chosen_color;
            song_slider_playback_buttons_toggle_switch.ToggleStateOn.BorderColorInner = default_chosen_color;

            if (shuffle_button_flag == 1) {
                Bitmap bmp = new Bitmap(C1oudify.Properties.Resources.shuffle);
                for (int i = 0; i < bmp.Width; i++)
                    for (int j = 0; j < bmp.Height; j++)
                        bmp.SetPixel(i, j, Color.FromArgb(bmp.GetPixel(i, j).A, default_chosen_color.R, default_chosen_color.G, default_chosen_color.B));
                shuffle_button.BackgroundImage = bmp;
            }
            if (repeat_song_button_counter == 2) {
                Bitmap bmp = new Bitmap(C1oudify.Properties.Resources.repeat);
                for (int i = 0; i < bmp.Width; i++)
                    for (int j = 0; j < bmp.Height; j++)
                        bmp.SetPixel(i, j, Color.FromArgb(bmp.GetPixel(i, j).A, default_chosen_color.R, default_chosen_color.G, default_chosen_color.B));
                repeat_song_button.BackgroundImage = bmp;
            }
            if (repeat_song_button_counter == 0) {
                Bitmap bmp = new Bitmap(C1oudify.Properties.Resources.repeat_one);
                for (int i = 0; i < bmp.Width; i++)
                    for (int j = 0; j < bmp.Height; j++)
                        bmp.SetPixel(i, j, Color.FromArgb(bmp.GetPixel(i, j).A, default_chosen_color.R, default_chosen_color.G, default_chosen_color.B));
                repeat_song_button.BackgroundImage = bmp;
            }
            this.Refresh();
        }

        private void logout_button_Click(object sender, EventArgs e) {
            File.Delete("info");
            this.Close();
        }

        #endregion

        #region . SOCKET AND ENCRYPTION (DON'T CHANGE).

        private string send_and_listen_to_server_messages(string tuple, string message = null) {
            if (!global_offline_indicator) {
                MessageBox.Show("You are not connected to the server!\nServer might be down.");
                return null;
            } else {
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
        }

        private void send_message_to_server(string header_json_str, string message = "") {
            Byte[] header_len = Encoding.UTF8.GetBytes((message.Length).ToString());
            Byte[] header_json = Encoding.UTF8.GetBytes(header_json_str);
            Byte[] header = new Byte[SEGMENT_SIZE];
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
            Byte[] message_byte = Encoding.UTF8.GetBytes(message);
            Byte[] send_data = new Byte[SEGMENT_SIZE + message_byte_count];
            for (int i = 0; i < SEGMENT_SIZE + message_byte_count; i++)
                send_data[i] = (byte)'\x01';
            for (int i = 0; i < SEGMENT_SIZE + message_byte_count; i++) {
                if (i < header.Length)
                    send_data[i] = header[i];
                if (i >= SEGMENT_SIZE)
                    send_data[i] = message_byte[i - SEGMENT_SIZE];
            }
            send_data = aes256_encrypt(send_data);
            if (global_offline_indicator) {
                stream = client.GetStream();
                stream.Write(send_data, 0, send_data.Length);
            } else {
                MessageBox.Show("You are not connected to the server! Server might be down.");
            }
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

        private void easter_egg(object sender, EventArgs e) {

        }
    }
}
