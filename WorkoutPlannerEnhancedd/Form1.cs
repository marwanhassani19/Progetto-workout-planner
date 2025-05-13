using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WorkoutPlannerEnhancedd
{
    public partial class Form1 : Form
    {
        private readonly HttpClient client = new HttpClient();
        private const string apiKey = "69262b6612msh96245c3a2f4f45fp1fa928jsn07e641dcf290";
        private const string apiHost = "exercisedb.p.rapidapi.com";

        private Dictionary<int, List<Exercise>> savedWorkout = new Dictionary<int, List<Exercise>>();
        private List<string> bodyParts;

        public Form1()
        {
            InitializeComponent();
            this.btnStats.Click += new System.EventHandler(this.btnStats_Click);


            LoadComboBox();
            LoadBodyPartsAndSavedWorkoutAsync();

            if (File.Exists("saved_workout.json"))
            {
                string json = File.ReadAllText("saved_workout.json");
                savedWorkout = JsonConvert.DeserializeObject<Dictionary<int, List<Exercise>>>(json);
            }

            if (File.Exists(bodyPartsFile))
            {
                bodyParts = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(bodyPartsFile));
            }

            UpdateSavedTab();
        }
        private const string bodyPartsFile = "bodyparts.json";

        private void LoadComboBox()
        {
            cmbDays.Items.Clear();
            for (int i = 1; i <= 7; i++)
                cmbDays.Items.Add(i);
            cmbDays.SelectedIndex = 2;

            cmbSavedDays.Items.Clear();
            for (int i = 1; i <= 7; i++)
                cmbSavedDays.Items.Add($"Giorno {i}");
            cmbSavedDays.SelectedIndex = 0;
        }

        private async void btnGenerate_Click(object sender, EventArgs e)
        {
            panelPlan.Controls.Clear();
            int days = (int)cmbDays.SelectedItem;

            bodyParts = await GetBodyPartsAsync();

            for (int i = 0; i < days; i++)
            {
                Label lblDay = new Label
                {
                    Text = $"\ud83d\udcc5 Giorno {i + 1} - {bodyParts[i % bodyParts.Count].ToUpper()}",
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    AutoSize = true,
                    Margin = new Padding(5)
                };

                panelPlan.Controls.Add(lblDay);

                var exercises = await GetExercisesByBodyPartAsync(bodyParts[i % bodyParts.Count]);
                var selected = exercises.Count > 3 ? exercises.GetRange(0, 3) : exercises;

                FlowLayoutPanel flw = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.LeftToRight,
                    AutoSize = true
                };

                foreach (var ex in selected)
                {
                    Panel exercisePanel = new Panel
                    {
                        Width = 300,
                        Height = 120
                    };

                    PictureBox pic = new PictureBox
                    {
                        Width = 100,
                        Height = 100,
                        ImageLocation = ex.GifUrl,
                        SizeMode = PictureBoxSizeMode.Zoom
                    };

                    Label lbl = new Label
                    {
                        Text = $"{ex.Name} ({ex.Equipment})",
                        Width = 180,
                        AutoSize = true,
                        Location = new Point(110, 40)
                    };

                    exercisePanel.Controls.Add(pic);
                    exercisePanel.Controls.Add(lbl);

                    flw.Controls.Add(exercisePanel);
                }

                panelPlan.Controls.Add(flw);
            }

            btnConfirm.Enabled = true;
            tabControl.SelectedTab = tabSaved;

        }

        private async Task<List<string>> GetBodyPartsAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://exercisedb.p.rapidapi.com/exercises/bodyPartList");
            request.Headers.Add("x-rapidapi-key", apiKey);
            request.Headers.Add("x-rapidapi-host", apiHost);
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<string>>(json);
        }

        private async Task<List<Exercise>> GetExercisesByBodyPartAsync(string bodyPart)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"https://exercisedb.p.rapidapi.com/exercises/bodyPart/{bodyPart}");
            request.Headers.Add("x-rapidapi-key", apiKey);
            request.Headers.Add("x-rapidapi-host", apiHost);
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Exercise>>(json);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            savedWorkout.Clear();

            int giorno = 0;
            foreach (Control control in panelPlan.Controls)
            {
                if (control is FlowLayoutPanel flow)
                {
                    var exercises = new List<Exercise>();
                    foreach (Control p in flow.Controls)
                    {
                        var panel = p as Panel;
                        var lbl = panel?.Controls[1] as Label;
                        var pic = panel?.Controls[0] as PictureBox;

                        if (lbl != null && pic != null)
                        {
                            string[] parts = lbl.Text.Split('(');
                            string name = parts[0].Trim();
                            string equipment = parts[1].Replace(")", "").Trim();

                            exercises.Add(new Exercise
                            {
                                Name = name,
                                Equipment = equipment,
                                GifUrl = pic.ImageLocation
                            });
                        }
                    }

                    savedWorkout[giorno++] = exercises;
                }
            }

            UpdateSavedTab();
            PopulateSavedList();

            MessageBox.Show("Scheda confermata.");
            string json = JsonConvert.SerializeObject(savedWorkout, Formatting.Indented);
            File.WriteAllText("saved_workout.json", json);

            // Salva anche i bodyParts per evitare errori all'avvio successivo
            File.WriteAllText(bodyPartsFile, JsonConvert.SerializeObject(bodyParts));


        }
        private void PopulateSavedList()
        {
            lstSaved.Items.Clear();

            if (savedWorkout.Count == 0)
            {
                lstSaved.Items.Add("❌ Nessuna scheda salvata.");
                return;
            }

            foreach (var kv in savedWorkout)
            {
                string day = $"Giorno {kv.Key + 1}";
                foreach (var ex in kv.Value)
                {
                    lstSaved.Items.Add($"{day} - {ex.Name} ({ex.Equipment})");
                }
            }
        }

        private void UpdateSavedTab()
        {
            panelSavedPlan.Controls.Clear();
            cmbSavedDays.Items.Clear();

            foreach (var kv in savedWorkout)
            {
                string label = bodyParts != null && bodyParts.Count > 0
                    ? $"Giorno {kv.Key + 1} - {bodyParts[kv.Key % bodyParts.Count]}"
                    : $"Giorno {kv.Key + 1}";

                cmbSavedDays.Items.Add(label);
            }

            if (cmbSavedDays.Items.Count > 0)
            {
                cmbSavedDays.SelectedIndex = 0;
                ShowSavedDay(cmbSavedDays.SelectedIndex);
            }
        }

        private async void LoadBodyPartsAndSavedWorkoutAsync()
        {
            bodyParts = await GetBodyPartsAsync(); // Assicurati che bodyParts sia inizializzato

            if (File.Exists("saved_workout.json"))
            {
                string json = File.ReadAllText("saved_workout.json");
                savedWorkout = JsonConvert.DeserializeObject<Dictionary<int, List<Exercise>>>(json);
                UpdateSavedTab(); // Ora bodyParts è sicuro da usare
            }
        }


        private void cmbSavedDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowSavedDay(cmbSavedDays.SelectedIndex);
        }

        private void ShowSavedDay(int dayIndex)
        {
            panelSavedPlan.Controls.Clear();

            if (savedWorkout.ContainsKey(dayIndex))
            {
                foreach (var ex in savedWorkout[dayIndex])
                {
                    Panel panel = new Panel
                    {
                        Width = 300,
                        Height = 120
                    };

                    PictureBox pic = new PictureBox
                    {
                        Width = 100,
                        Height = 100,
                        ImageLocation = ex.GifUrl,
                        SizeMode = PictureBoxSizeMode.Zoom
                    };

                    CheckBox chk = new CheckBox
                    {
                        Text = $"{ex.Name} ({ex.Equipment})",
                        Width = 180,
                        Tag = ex,
                        AutoSize = true,
                        Location = new Point(110, 40)
                    };
                    chk.CheckedChanged += Exercise_Checked;

                    panel.Controls.Add(pic);
                    panel.Controls.Add(chk);

                    panelSavedPlan.Controls.Add(panel);
                }
            }
        }

        private void Exercise_Checked(object sender, EventArgs e)
        {
            var chk = sender as CheckBox;
            if (chk.Checked)
            {
                var ex = (Exercise)chk.Tag;
                string log = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {ex.Name} ({ex.Equipment})";
                File.AppendAllLines("stats.txt", new[] { log });
            }
        }

        private void btnStats_Click(object sender, EventArgs e)
        {
            if (File.Exists("stats.txt"))
            {
                string[] lines = File.ReadAllLines("stats.txt");
                txtStats.Text = string.Join(Environment.NewLine, lines);
            }
            else
            {
                txtStats.Text = "Nessuna statistica trovata.";
            }
        }

        private void btnShowSaved_Click(object sender, EventArgs e)
        {
            PopulateSavedList();
        }

        public class Exercise
        {
            public string BodyPart { get; set; }
            public string Equipment { get; set; }
            public string Name { get; set; }
            public string Target { get; set; }
            public string GifUrl { get; set; }
        }
    }


}