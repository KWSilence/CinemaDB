using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaDB
{
    public partial class ActorForm : Form
    {
        private OleDbConnection cn;
        private InitialForm previous;
        private int thisID;

        private bool exit = true;

        public ActorForm(InitialForm previous, int thisID)
        {
            InitializeComponent();
            this.previous = previous;
            this.cn = previous.getConnection();
            this.thisID = thisID;

            initProfile();
            initWork();
            initCharacter();
            initTask();
        }

        private void initProfile()
        {
            profileName.ReadOnly = true;
            profileContact.ReadOnly = true;
            profileAbout.ReadOnly = true;

            profileEditClose.Visible = false;
            profileEdit.Text = "Edit";

            OleDbCommand init = new OleDbCommand("select Post.name, Person.name, contacts, about from Person join Post on Person.id = ? and Person.post_id = Post.id", cn);
            init.Parameters.Add("@PersonID", OleDbType.Integer);
            init.Parameters[0].Value = thisID;
            OleDbDataReader rdr = init.ExecuteReader();
            rdr.Read();
            labelPost.Text = "Post: " + rdr[0].ToString();
            profileName.Text = rdr[1].ToString();
            profileContact.Text = rdr[2].ToString();
            profileAbout.Text = rdr[3].ToString();
            rdr.Close();
        }

        private void initWork()
        {
            dsCharacter.Tables["ActorForms"].Clear();
            dsCharacter.Tables["FreeCharacter"].Clear();
            wInfoEdit.Text = "";
            wInfoSend.Text = "";

            wEdit.Enabled = true;
            wWithdraw.Enabled = true;
            wSend.Enabled = true;
            wInfoSend.Enabled = true;
            wInfoEdit.Enabled = true;

            OleDbDataAdapter need = new OleDbDataAdapter("exec getNeedStaff " + thisID, cn);
            need.Fill(dsCharacter, "FreeCharacter");

            OleDbDataAdapter current = new OleDbDataAdapter("exec getCurrentStaff " + thisID, cn);
            current.Fill(dsCharacter, "ActorForms");

            if (dsCharacter.Tables["ActorForms"].Rows.Count == 0)
            {
                wEdit.Enabled = false;
                wWithdraw.Enabled = false;
                wInfoEdit.Enabled = false;

            }

            if (dsCharacter.Tables["FreeCharacter"].Rows.Count == 0)
            {
                wSend.Enabled = false;
                wInfoSend.Enabled = false;
            }
        }

        private void initCharacter()
        {
            dsCharacter.Tables["AcceptedCharacter"].Clear();
            dsCharacter.Tables["ActorScenario"].Clear();

            OleDbDataAdapter d = new OleDbDataAdapter("exec getCurrentStaff1 " + thisID, cn);
            d.Fill(dsCharacter, "AcceptedCharacter");
        }

        private void initTask()
        {
            dsCharacter.Tables["AcceptedCharacter"].Clear();
            dsCharacter.Tables["Scene"].Clear();
            dsCharacter.Tables["Tasks"].Clear();

            OleDbDataAdapter d = new OleDbDataAdapter("exec getCurrentStaff1 " + thisID, cn);
            d.Fill(dsCharacter, "AcceptedCharacter");
        }

        private void onClose(object sender, FormClosedEventArgs e)
        {
            if (exit)
            {
                previous.disconnect();
            }
        }

        private void exitToInitial(object sender, EventArgs e)
        {
            previous.Show();
            exit = false;
            Close();
        }

        private void editProfile(object sender, EventArgs e)
        {
            if (profileEdit.Text != "Save")
            {
                profileName.ReadOnly = false;
                profileContact.ReadOnly = false;
                profileAbout.ReadOnly = false;

                profileEditClose.Visible = true;
                profileEdit.Text = "Save";
                return;
            }

            String name = profileName.Text.Trim();
            if (name.Length == 0)
            {
                MessageBox.Show("Name field is empty", "Incorrect data", MessageBoxButtons.OK);
                return;
            }

            String contacts = profileContact.Text.Trim();
            String about = profileAbout.Text.Trim();

            OleDbCommand updateProfile = new OleDbCommand("update Person set name = ?, contacts = ?, about = ? where id = ?", cn);
            updateProfile.Parameters.Add("@Name", OleDbType.VarChar, 50);
            updateProfile.Parameters.Add("@Contacts", OleDbType.VarChar);
            updateProfile.Parameters.Add("@About", OleDbType.VarChar);
            updateProfile.Parameters.Add("@ID", OleDbType.Integer);
            updateProfile.Parameters[0].Value = name;
            updateProfile.Parameters[1].Value = contacts;
            updateProfile.Parameters[2].Value = about;
            updateProfile.Parameters[3].Value = thisID;
            if (updateProfile.ExecuteNonQuery() <= 0)
            {
                MessageBox.Show("Something wrong", "Fail", MessageBoxButtons.OK);
            }

            initProfile();
        }

        private void closeProfileEdit(object sender, EventArgs e)
        {
            initProfile();
        }

        private void sendForm(object sender, EventArgs e)
        {
            String info = wInfoSend.Text;

            OleDbCommand d = new OleDbCommand("exec sendForm " + thisID + ", " + dataFree.SelectedRows[0].Cells[0].Value.ToString() + ", '" + info + "'", cn);
            d.ExecuteNonQuery();
            initWork();
        }

        private void editForm(object sender, EventArgs e)
        {
            String info = wInfoEdit.Text;
            OleDbCommand d = new OleDbCommand("update WorksheetInfo set info = '"+info+"' where id = (select Worksheet.info_id from Worksheet where staff_id="+dataForms.SelectedRows[0].Cells[0].Value.ToString()+" and person_id="+thisID+")", cn);
            d.ExecuteNonQuery();
            initWork();
        }

        private void withdrawForm(object sender, EventArgs e)
        {
            int staffID = int.Parse(dataForms.SelectedRows[0].Cells[0].Value.ToString());
            String state = dataForms.SelectedRows[0].Cells[6].Value.ToString();
            if (state == "withdraw")
            {
                OleDbCommand d = new OleDbCommand("update WorksheetInfo set state_id = " + 2 + " where id = (select Worksheet.info_id from Worksheet where staff_id=" + staffID + " and person_id=" + thisID + ")", cn);
                d.ExecuteNonQuery();
                initWork();
            }
            if (state == "wait")
            {
                OleDbCommand d = new OleDbCommand("update WorksheetInfo set state_id = " + 5 + " where id = (select Worksheet.info_id from Worksheet where staff_id=" + staffID + " and person_id=" + thisID + ")", cn);
                d.ExecuteNonQuery();
                initWork();
            }
        }

        private void dataFormsSelect(object sender, EventArgs e)
        {
            wInfoEdit.Text = dataForms.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void getScenario(object sender, DataGridViewCellEventArgs e)
        {
            OleDbDataAdapter d = new OleDbDataAdapter("exec getScenarioByStaff " + dataAccepted.SelectedRows[0].Cells[0].Value.ToString(), cn);
            d.Fill(dsCharacter, "ActorScenario");
        }

        private void resetCharacters(object sender, EventArgs e)
        {
            initCharacter();
        }

        private void selectCharForScene(object sender, DataGridViewCellEventArgs e)
        {
            dsCharacter.Tables["Scene"].Clear();
            dsCharacter.Tables["Tasks"].Clear();
            int staffID = int.Parse(dataTCharacter.SelectedRows[0].Cells[0].Value.ToString());

            OleDbDataAdapter d = new OleDbDataAdapter("exec getSceneByStaff " + staffID, cn);
            d.Fill(dsCharacter, "Scene");
        }

        private void selectSceneForTask(object sender, DataGridViewCellEventArgs e)
        {
            dsCharacter.Tables["Tasks"].Clear();
            int staffID = int.Parse(dataTCharacter.SelectedRows[0].Cells[0].Value.ToString());
            int sceneID = int.Parse(dataTScene.SelectedRows[0].Cells[0].Value.ToString());

            OleDbDataAdapter d = new OleDbDataAdapter("exec getTasks1 " + staffID + ", " + sceneID, cn);
            d.Fill(dsCharacter, "Tasks");
        }

        private void resetTasks(object sender, EventArgs e)
        {
            initTask();
        }

        private void setTaskDone(object sender, EventArgs e)
        {
            int staffID = int.Parse(dataTCharacter.SelectedRows[0].Cells[0].Value.ToString());
            int sceneID = int.Parse(dataTScene.SelectedRows[0].Cells[0].Value.ToString());
            int taskID = int.Parse(dataTTask.SelectedRows[0].Cells[0].Value.ToString());
            String state = dataTTask.SelectedRows[0].Cells[3].Value.ToString();

            if (state == "done")
            {
                OleDbCommand du = new OleDbCommand("update TaskItem set state_id = 2 where id=" + taskID, cn);
                du.ExecuteNonQuery();
            }
            if (state == "wait")
            {
                OleDbCommand du = new OleDbCommand("update TaskItem set state_id = 4 where id=" + taskID, cn);
                du.ExecuteNonQuery();
            }

            dsCharacter.Tables["Tasks"].Clear();
            OleDbDataAdapter d = new OleDbDataAdapter("exec getTasks1 " + staffID + ", " + sceneID, cn);
            d.Fill(dsCharacter, "Tasks");
        }
    }
}
