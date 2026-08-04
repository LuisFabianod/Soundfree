using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;
using NAudio.Wave;

namespace Soundfree
{
 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        private void BtnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            
            dialog.Filter = "Arquivos de Áudio|*.mp3;*.wav";
            
            bool? resultado = dialog.ShowDialog();
            
            if (resultado == true)
            {
                Audio audio = new Audio(System.IO.Path.GetFileName(dialog.FileName), dialog.FileName);
                
                audios.Add(audio);

                ListaAudios.Items.Add(audio);
            }
        }

        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {
            if (ListaAudios.SelectedItem == null)
            {
                MessageBox.Show("Selecione um áudio.");
                return;
            }

            Audio audio = (Audio)ListaAudios.SelectedItem;

            player?.Stop();
            player?.Dispose();
            audioFile?.Dispose();

            audioFile = new AudioFileReader(audio.Caminho);

            player = new WaveOutEvent();
            player.Init(audioFile);
            player.Play();
        }

        private List<Audio> audios = new List<Audio>();

        private WaveOutEvent? player;
        private AudioFileReader? audioFile;
    }



}