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
    public partial class InitialForm : Form
    {
        private OleDbConnection cn;

        public InitialForm()
        {
            InitializeComponent();

            cn = new OleDbConnection();
            cn.ConnectionString = "Provider=SQLOLEDB;Data Source=LAPTOP-00Q6G4H6\\SQLEXPRESS;Persist Security Info=True;Password=sa;User ID=sa;Initial Catalog=demo_cinema";
            connect();
            suPostInit();
        }

        private void connect()
        {
            try
            {
                cn.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Connection failed!!", "Connection", MessageBoxButtons.OK);
                disconnect();
            }
        }

        public void disconnect()
        {
            try
            {
                cn.Close();
            }
            catch (Exception)
            { }
            Application.Exit();
        }

        public OleDbConnection getConnection()
        {
            return cn;
        }

        private void suPostInit()
        {
            OleDbDataReader rdr = new OleDbCommand("SELECT name FROM Post", cn).ExecuteReader();
            while (rdr.Read())
            {
                suPost.Items.Add(rdr["name"].ToString());
            }
            rdr.Close();
        }

        private void siButtonClick(object sender, EventArgs e)
        {
            String sql = "select person_id, post_id from Account join Person on Account.person_id = Person.id and login=? and password=?";
            OleDbCommand sel = new OleDbCommand(sql, cn);
            sel.Parameters.Add("@Login", OleDbType.VarChar, 50);
            sel.Parameters.Add("@Password", OleDbType.VarChar);

            sel.Parameters[0].Value = siLogin.Text;
            sel.Parameters[1].Value = EncrypterDecrypter.EncryptText(siPassword.Text);

            OleDbDataReader rdr = sel.ExecuteReader();
            if (rdr.Read())
            {
                int person_id = int.Parse(rdr["person_id"].ToString());
                int post_id = int.Parse(rdr["post_id"].ToString());

                siLogin.Text = "";
                siPassword.Text = "";
                Hide();
                switch (post_id)
                {
                    case 1:
                        new ProducerForm(this, person_id).Show();
                        break;
                    case 2:
                        new ActorForm(this, person_id).Show();
                        break;
                    case 3:
                        new DecoratorForm(this, person_id).Show();
                        break;
                }

                //TODO onclose event in new forms
            }
            else
            {
                MessageBox.Show("Login or Password incorrect", "Incorrect data", MessageBoxButtons.OK);
            }
            rdr.Close();
        }

        private void suButtonClick(object sender, EventArgs e)
        {
            bool ok = true;

            String name = suName.Text.Trim();
            if (name.Length == 0)
            {
                MessageBox.Show("Name is empty", "Incorrect data", MessageBoxButtons.OK);
                return;
            }

            String login = suLogin.Text.Trim();
            if (login.Length == 0)
            {
                MessageBox.Show("Login is empty", "Incorrect data", MessageBoxButtons.OK);
                return;
            }
            OleDbCommand login_id = new OleDbCommand("select login from Account where login = ?", cn);
            login_id.Parameters.Add("@Login", OleDbType.VarChar, 50);
            login_id.Parameters[0].Value = login;
            OleDbDataReader rdr = login_id.ExecuteReader();
            if (rdr.Read())
            {
                MessageBox.Show("This Login is exist", "Incorrect data", MessageBoxButtons.OK);
                return;
            }
            rdr.Close();

            String password1 = suPassword1.Text;
            String password2 = suPassword2.Text;
            if (password1.Length == 0)
            {
                MessageBox.Show("Password is empty", "Incorrect data", MessageBoxButtons.OK);
                return;
            }
            if (!password1.Equals(password2))
            {
                MessageBox.Show("Password and Confirm not equal", "Incorrect data", MessageBoxButtons.OK);
                return;
            }


            OleDbCommand post_id = new OleDbCommand("select id from Post where name = ?", cn);
            post_id.Parameters.Add("@Name", OleDbType.VarChar, 50);
            post_id.Parameters[0].Value = suPost.Text;
            rdr = post_id.ExecuteReader();
            int postID = 0;
            if (rdr.Read())
            {
                postID = int.Parse(rdr["id"].ToString());
            }
            else
            {
                MessageBox.Show("Post value incorrect", "Incorrect data", MessageBoxButtons.OK);
                return;
            }
            rdr.Close();

            OleDbCommand personAdd = new OleDbCommand("insert into Person (name, post_id) values (?, ?)", cn);
            personAdd.Parameters.Add("@Name", OleDbType.VarChar, 50);
            personAdd.Parameters.Add("@PostID", OleDbType.Integer);
            personAdd.Parameters[0].Value = name;
            personAdd.Parameters[1].Value = postID;
            ok = ok && (personAdd.ExecuteNonQuery() != 0);
            OleDbCommand person_id = new OleDbCommand("select max(id) from Person", cn);
            rdr = person_id.ExecuteReader();
            ok = ok && rdr.Read();
            int personID = int.Parse(rdr[0].ToString());
            rdr.Close();

            if (ok)
            {
                OleDbCommand accountAdd = new OleDbCommand("insert into Account (login, password, person_id) values (?, ?, ?)", cn);
                accountAdd.Parameters.Add("@Login", OleDbType.VarChar, 50);
                accountAdd.Parameters.Add("@Password", OleDbType.VarChar);
                accountAdd.Parameters.Add("@PersonID", OleDbType.Integer);
                accountAdd.Parameters[0].Value = login;
                accountAdd.Parameters[1].Value = EncrypterDecrypter.EncryptText(password1);
                accountAdd.Parameters[2].Value = personID;
                ok = ok && (accountAdd.ExecuteNonQuery() != 0);
            }

            if (ok)
            {
                suName.Text = "";
                suLogin.Text = "";
                suPassword1.Text = "";
                suPassword2.Text = "";
                suPost.SelectedIndex = -1;
                MessageBox.Show("Account created", "Success", MessageBoxButtons.OK);
                tabControl.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Something wrong", "Fail", MessageBoxButtons.OK);
            }    
        }
    }
}
