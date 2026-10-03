using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorWindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Pengaturan Form
            this.Text = "Aplikasi Calculator";

            // Pengaturan ComboBox
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBox.Items.Add("Penambahan");
            comboBox.Items.Add("Pengurangan");
            comboBox.Items.Add("Perkalian");
            comboBox.Items.Add("Pembagian");

            // Pilihan awal
            comboBox.SelectedIndex = 0;

            // Hasil tidak dapat diedit
            //txtHasil.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Memastikan operasi sudah dipilih
            if (comboBox.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Silakan pilih operasi terlebih dahulu!",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            // Mengubah Nilai A menjadi angka
            if (!double.TryParse(txtNilaiA.Text, out double nilaiA))
            {
                MessageBox.Show(
                    "Nilai A harus berupa angka!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                txtNilaiA.Focus();
                return;
            }

            // Mengubah Nilai B menjadi angka
            if (!double.TryParse(txtNilaiB.Text, out double nilaiB))
            {
                MessageBox.Show(
                    "Nilai B harus berupa angka!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                txtNilaiB.Focus();
                return;
            }

            double hasil;

            // Menentukan operasi
            switch (comboBox.SelectedItem.ToString())
            {
                case "Penambahan":
                    hasil = nilaiA + nilaiB;
                    break;

                case "Pengurangan":
                    hasil = nilaiA - nilaiB;
                    break;

                case "Perkalian":
                    hasil = nilaiA * nilaiB;
                    break;

                case "Pembagian":

                    // Mengecek pembagian dengan nol
                    if (nilaiB == 0)
                    {
                        MessageBox.Show(
                            "Nilai B tidak boleh 0!",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );

                        txtNilaiB.Focus();
                        return;
                    }

                    hasil = nilaiA / nilaiB;
                    break;

                default:
                    MessageBox.Show("Operasi tidak valid!");
                    return;
            }

            // Menampilkan hasil
            txtHasil.Text = hasil.ToString();
        }
    }
}