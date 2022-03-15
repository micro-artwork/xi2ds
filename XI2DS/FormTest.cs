using System;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using Vortice.XInput;
using XI2DS.Xinput;

namespace XI2DS
{
    public partial class FormTest : Form
    {
        private readonly struct InputState
        {
            public readonly State state;
            public readonly bool updated;

            public InputState(bool updated, State? state = null)
            {
                if (state == null)
                {
                    this.state = new State();
                }
                else
                {
                    this.state = (State)state;
                }
                this.updated = updated;
            }
        }

        private readonly InputState[] inputStates = new[] { new InputState(false), new InputState(false), new InputState(false), new InputState(false) };

        public FormTest(XInputController controller)
        {
            InitializeComponent();

            for (int rowIndex = 0; rowIndex < 4; rowIndex++)
            {
                dataGridViewState.Rows.Add();
                dataGridViewState.Rows[rowIndex].Cells[0].Value = string.Format("{0}", rowIndex + 1);
            }

            controller.StateUpdated += Controller_StateUpdated;
        }

        private void Controller_StateUpdated(object sender, XInputStateEventArgs e)
        {
            bool updated = Utils.XInputStatesDiff(inputStates[e.UserIndex].state, e.State);
            inputStates[e.UserIndex] = new InputState(updated, e.State);

            if (updated)
            {
                var data = Utils.XInputStateToGridViewData(e.State);
                UpdateGridViewData(e.UserIndex, data);
            }
        }

        private void UpdateGridViewData(int rowIndex, float[] data)
        {
            for (int columnIndex = 0; columnIndex < data.Length; columnIndex++)
            {
                dataGridViewState.Rows[rowIndex].Cells[columnIndex + 1].Value = data[columnIndex];
                if (data[columnIndex] != 0f)
                {
                    dataGridViewState.Rows[rowIndex].Cells[columnIndex + 1].Style.BackColor = Color.LawnGreen;
                }
                else
                {
                    dataGridViewState.Rows[rowIndex].Cells[columnIndex + 1].Style.BackColor = Color.White;
                }
            }
        }

        private void FormTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            ((DataGridView)sender).ClearSelection();
        }
    }
}
