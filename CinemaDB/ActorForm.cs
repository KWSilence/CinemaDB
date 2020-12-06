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
    }
}
