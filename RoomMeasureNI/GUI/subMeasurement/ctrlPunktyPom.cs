﻿using System;
using System.Windows.Forms;

namespace RoomMeasureNI.GUI
{
    public partial class ctrlPunktyPom : UserControl
    {
        private Project proj = Project.Instance;
        ctrlMeasurement parent;

        public ctrlPunktyPom()
        {
            InitializeComponent();
            this.projektBindingSource.DataSource = proj;    //wiąże tabelę z plikiem projektu
            getActiveChannels();
        }

        public void setParent(ctrlMeasurement _parent)
        {
            parent=_parent;
        }

        //...........Metody.............
        //Odświeża powiazania - wywoływane gdy dane zmieniane są programowo
        public void Odswiez()
        {
            getActiveChannels();
            projektBindingSource.ResetBindings(false);
            punktyPomiaroweBindingSource.ResetBindings(false);
           
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                int card = proj.cardConfig.getNumActiveChannels();
                int pkt = proj.punktyPomiarowe.getNumActive();

                proj.punktyPomiarowe.disableIfChannelActive(e.RowIndex);
            }
            parent.Odswiez();
        }

        private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            parent.Odswiez();
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                proj.punktyPomiarowe.listaPunktow[e.RowIndex].Kanal = null;
            }
            else
            {
                MessageBox.Show("Wprowadzone dane są błędne!!!");
            }
        }
        private void getActiveChannels()
        {
            dataGridViewTextBoxColumn4.Items.Clear();
            dataGridViewTextBoxColumn4.Items.AddRange(proj.cardConfig.getActiveChannels());
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int card = proj.cardConfig.getNumActiveChannels();
            int pkt = proj.punktyPomiarowe.getNumActive();

            if (pkt > card)
            {
                proj.punktyPomiarowe.listaPunktow[proj.punktyPomiarowe.listaPunktow.Count-1].Aktywny = false;
            }
        }
    }
}