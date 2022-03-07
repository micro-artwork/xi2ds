using System;
using System.Windows.Forms;
using System.Drawing;
using Vortice.XInput;

namespace XI2DS
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();

            for (int rowIndex = 0; rowIndex < 4; rowIndex++)
            {
                dataGridViewState.Rows.Add();
                dataGridViewState.Rows[rowIndex].Cells[0].Value = string.Format("{0}", rowIndex + 1);
            }

            //dataGridViewState.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.Transparent;
        }

        private void FormLog_Load(object sender, EventArgs e)
        {

        }

        private void UpdateGridViewData(int rowIndex, float[] data)
        {
            int columnStart = 2;
            for (int columnIndex = 0; columnIndex < data.Length; columnIndex++)
            {
                int gridIndex = columnIndex + columnStart;
                dataGridViewState.Rows[rowIndex].Cells[gridIndex].Value = data[columnIndex];
                if (data[columnIndex] != 0f)
                {
                    dataGridViewState.Rows[rowIndex].Cells[gridIndex].Style.BackColor = Color.LawnGreen;
                }
                else
                {
                    dataGridViewState.Rows[rowIndex].Cells[gridIndex].Style.BackColor = Color.White;
                }
            }
        }

        private void FormLog_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            ((DataGridView)sender).ClearSelection();
        }

        private void timerFPS_Tick(object sender, EventArgs e)
        {
            for (int rowIndex = 0; rowIndex < 4; ++rowIndex)
            {
                dataGridViewState.Rows[rowIndex].Cells[1].Value = Utils.FPS[rowIndex];
            }            
        }

        private void timerStateUpdate_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; ++i)
            {
                var state = Utils.State[i];
                var stateStr = Utils.XInputStateToText(state);
                if (stateStr != "")
                {
                    var log = string.Format("Controller {0} - {1}" + Environment.NewLine, i + 1, stateStr);
                    this.uiTextLog.AppendText(log);
                }

                var data = Utils.XInputStateToGridViewData(state);
                UpdateGridViewData(i, data);
            }
        }

        private void FormTest_VisibleChanged(object sender, EventArgs e)
        {
            timerFPS.Enabled = Visible;
            timerStateUpdate.Enabled = Visible;
        }
    }
}
