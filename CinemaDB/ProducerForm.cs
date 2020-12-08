using System;
using System.Collections;
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
    public partial class ProducerForm : Form
    {
        private OleDbConnection cn;
        private InitialForm previous;
        private int thisID;

        private bool exit = true;

        public ProducerForm(InitialForm previous, int thisID)
        {
            InitializeComponent();
            this.previous = previous;
            this.cn = previous.getConnection();
            this.thisID = thisID;

            initProfile();
            initCreateFilm();
            initFilms();
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

        private void initCreateFilm()
        {
            cfName.Text = "";
            cfOrigin.Text = "";
            cfDescription.Text = "";
            cfGenresList.Items.Clear();

            OleDbDataReader rdr = new OleDbCommand("select name from Genre", cn).ExecuteReader();
            while (rdr.Read())
            {
                cfGenresList.Items.Add(rdr[0].ToString());
            }
            rdr.Close();
        }

        private void initFilms()
        {
            fSelect.Items.Clear();
            fName.Text = "";
            fDescription.Text = "";
            fOrigin.Text = "";

            fEdit.Enabled = false;
            fClose.Enabled = false;

            OleDbCommand film = new OleDbCommand("exec getProducerFilms ?", cn);
            film.Parameters.Add("@CreatorID", OleDbType.Integer);
            film.Parameters[0].Value = thisID;
            OleDbDataReader rdr = film.ExecuteReader();
            while (rdr.Read())
            {
                fSelect.Items.Add(rdr[0].ToString());
            }
            rdr.Close();
            initCharacters();
        }

        private void initCharacters(bool force = true)
        {
            cCreate.Text = "Create";
            cSelect.SelectedIndex = -1;
            dataChar.AllowUserToAddRows = false;
            dataScenario.AllowUserToAddRows = false;
            dataScenarioAdd.AllowUserToAddRows = false;
            dsCharacter.Tables["Character"].Clear();
            dsCharacter.Tables["Scenario"].Clear();
            dsCharacter.Tables["ScenarioAdd"].Clear();
            cCreate.Enabled = fSelect.SelectedIndex != -1;
            cSelect.Items.Clear();
            if (fSelect.SelectedIndex == -1 || force)
            {
                cAdd.Enabled = false;
                cEdit.Enabled = false;
                cReset.Enabled = false;
                return;
            }
            OleDbCommand character = new OleDbCommand("exec getCharsByFilm ?", cn);
            character.Parameters.Add("@Name", OleDbType.VarChar, 50);
            character.Parameters[0].Value = fSelect.SelectedItem.ToString();
            OleDbDataReader rdr = character.ExecuteReader();
            while (rdr.Read())
            {
                cSelect.Items.Add(rdr[0].ToString());
            }
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

        private void createFilm(object sender, EventArgs e)
        {
            String name = cfName.Text.Trim();
            if (name.Length == 0)
            {
                MessageBox.Show("Name field is empty", "Incorrect data", MessageBoxButtons.OK);
                return;
            }
            OleDbCommand film_name = new OleDbCommand("select id from Film where name = ?", cn);
            film_name.Parameters.Add("@FilmName", OleDbType.VarChar, 50);
            film_name.Parameters[0].Value = name;
            OleDbDataReader rdr = film_name.ExecuteReader();
            if (rdr.Read())
            {
                MessageBox.Show("This Name already exist", "Incorrect data", MessageBoxButtons.OK);
                return;
            }
            rdr.Close();

            String origin = cfOrigin.Text;
            String description = cfDescription.Text;

            List<String> genres = new List<string>();
            foreach (var el in cfGenresList.SelectedItems)
            {
                genres.Add(el.ToString());
            }
            if (genres.Count == 0)
            {
                MessageBox.Show("Genre field is empty (should be > 0)", "Incorrect data", MessageBoxButtons.OK);
                return;
            }

            OleDbCommand create = new OleDbCommand("exec createFilm ?, ?, ?, ?", cn);
            create.Parameters.Add("@CreatorID", OleDbType.Integer);
            create.Parameters.Add("@Name", OleDbType.VarChar, 50);
            create.Parameters.Add("@Description", OleDbType.VarChar);
            create.Parameters.Add("@Origin", OleDbType.VarChar, 50);
            create.Parameters[0].Value = thisID;
            create.Parameters[1].Value = name;
            create.Parameters[2].Value = description;
            create.Parameters[3].Value = origin;
            create.ExecuteNonQuery();

            OleDbDataReader film_id = new OleDbCommand("select max(id) from Film", cn).ExecuteReader();
            film_id.Read();
            int filmID = int.Parse(film_id[0].ToString());
            film_id.Close();

            OleDbCommand linkGenre = new OleDbCommand("insert into FilmGenre (film_id, genre_id) values (?, (select id from Genre where name = ?))", cn);
            linkGenre.Parameters.Add("@FilmID", OleDbType.Integer);
            linkGenre.Parameters.Add("@GenreName", OleDbType.VarChar, 50);
            linkGenre.Parameters[0].Value = filmID;

            foreach (String genre in genres)
            {
                linkGenre.Parameters[1].Value = genre;
                linkGenre.ExecuteNonQuery();
            }

            initCreateFilm();
            MessageBox.Show("Film created", "Success", MessageBoxButtons.OK);       
        }

        private void fChange(object sender, EventArgs e)
        {
            fEdit.Enabled = true;
            OleDbCommand film = new OleDbCommand("select Film.name, Film.origin, Film.description from Film where name =\'" + fSelect.SelectedItem.ToString() + "\'", cn);
            OleDbDataReader rdr = film.ExecuteReader();
            if (rdr.Read())
            {
                fName.Text = rdr[0].ToString();
                fOrigin.Text = rdr[1].ToString();
                fDescription.Text = rdr[2].ToString();
            }
            rdr.Close();
            initCharacters(false);
        }

        private void cChange(object sender, EventArgs e)
        {
            cCreate.Text = "Create";
            dataChar.AllowUserToAddRows = false;
            dataScenario.AllowUserToAddRows = false;
            dataScenarioAdd.AllowUserToAddRows = cSelect.SelectedIndex != -1;
            dsCharacter.Tables["Character"].Clear();
            dsCharacter.Tables["Scenario"].Clear();
            dsCharacter.Tables["ScenarioAdd"].Clear();
            cAdd.Enabled = true;
            cEdit.Enabled = true;
            cReset.Enabled = true;
            cCreate.Enabled = true;

            if (cSelect.SelectedIndex != -1)
            {
                OleDbDataAdapter d = new OleDbDataAdapter("exec getCharsByFilmAndName \'" + fSelect.SelectedItem.ToString() + "\', \'" + cSelect.SelectedItem.ToString() + "\'", cn);
                d.Fill(dsCharacter, "Character");

                d = new OleDbDataAdapter("exec getScenarioByFilmAndChar \'" + fSelect.SelectedItem.ToString() + "\', \'" + cSelect.SelectedItem.ToString() + "\'", cn);
                d.Fill(dsCharacter, "Scenario");
            }
        }

        private void editFilm(object sender, EventArgs e)
        {
            if (fEdit.Text == "Edit")
            {
                fEdit.Text = "Save";
                fName.ReadOnly = false;
                fOrigin.ReadOnly = false;
                fDescription.ReadOnly = false;
                fClose.Enabled = true;
                return;
            }

            String name = fName.Text.Trim();
            if (name.Length == 0)
            {
                MessageBox.Show("Name field is empty", "Incorrect data", MessageBoxButtons.OK);
                return;
            }
            String prevName = fSelect.SelectedItem.ToString();
            if (prevName != name)
            {
                OleDbCommand film_name = new OleDbCommand("select id from Film where name = ?", cn);
                film_name.Parameters.Add("@FilmName", OleDbType.VarChar, 50);
                film_name.Parameters[0].Value = name;
                OleDbDataReader rdr = film_name.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("This Name already exist", "Incorrect data", MessageBoxButtons.OK);
                    return;
                }
                rdr.Close();
            }

            OleDbCommand edit = new OleDbCommand("update Film set name=?, origin=?, description=? where name=?", cn);
            edit.Parameters.Add("@Name", OleDbType.VarChar, 50);
            edit.Parameters.Add("@Origin", OleDbType.VarChar, 50);
            edit.Parameters.Add("@Description", OleDbType.VarChar);
            edit.Parameters.Add("@PrevName", OleDbType.VarChar, 50);
            edit.Parameters[0].Value = name;
            edit.Parameters[1].Value = fOrigin.Text.Trim();
            edit.Parameters[2].Value = fDescription.Text.Trim();
            edit.Parameters[3].Value = prevName;
            edit.ExecuteNonQuery();

            fEdit.Text = "Edit";
            fName.ReadOnly = true;
            fOrigin.ReadOnly = true;
            fDescription.ReadOnly = true;
            fClose.Enabled = false;

            initFilms();
        }

        private void closeFilmEdit(object sender, EventArgs e)
        {
            OleDbCommand film = new OleDbCommand("select Film.name, Film.origin, Film.description from Film where name =\'" + fSelect.SelectedItem.ToString() + "\'", cn);
            OleDbDataReader rdr = film.ExecuteReader();
            if (rdr.Read())
            {
                fName.Text = rdr[0].ToString();
                fOrigin.Text = rdr[1].ToString();
                fDescription.Text = rdr[2].ToString();
            }
            rdr.Close();
            fEdit.Text = "Edit";
            fName.ReadOnly = true;
            fOrigin.ReadOnly = true;
            fDescription.ReadOnly = true;
            fClose.Enabled = false;
        }

        private void addScenario(object sender, EventArgs e)
        {
            OleDbCommand add = new OleDbCommand("exec addScenario ?, ?, ?, ?", cn);
            add.Parameters.Add("@FName", OleDbType.VarChar, 50);
            add.Parameters.Add("@CName", OleDbType.VarChar, 50);
            add.Parameters.Add("@SInfo", OleDbType.VarChar);
            add.Parameters.Add("@SDoc", OleDbType.VarChar, 50);
            add.Parameters[0].Value = fSelect.SelectedItem.ToString();
            add.Parameters[1].Value = cSelect.SelectedItem.ToString();
            

            foreach (DataRow el in dsCharacter.Tables["ScenarioAdd"].Rows)
            {
                String info = el["SInfo"].ToString().Trim();
                if (info.Length == 0)
                {
                    MessageBox.Show("SInfo field is empty", "Incorrect data", MessageBoxButtons.OK);
                    return;
                }

                String doc = el["SDoc"].ToString().Trim();
                if (doc.Length == 0)
                {
                    MessageBox.Show("SDoc field is empty", "Incorrect data", MessageBoxButtons.OK);
                    return;
                }

                add.Parameters[2].Value = info;
                add.Parameters[3].Value = doc;
                add.ExecuteNonQuery();
            }
            dsCharacter.Tables["ScenarioAdd"].Clear();
            dsCharacter.Tables["Scenario"].Clear();
            OleDbDataAdapter d = new OleDbDataAdapter("exec getScenarioByFilmAndChar \'" + fSelect.SelectedItem.ToString() + "\', \'" + cSelect.SelectedItem.ToString() + "\'", cn);
            d.Fill(dsCharacter, "Scenario");
        }

        private void resetEdited(object sender, EventArgs e)
        {
            cCreate.Text = "Create";
            dsCharacter.Tables["Character"].Clear();
            dsCharacter.Tables["Scenario"].Clear();
            dsCharacter.Tables["ScenarioAdd"].Clear();

            OleDbDataAdapter d = new OleDbDataAdapter("exec getCharsByFilmAndName \'" + fSelect.SelectedItem.ToString() + "\', \'" + cSelect.SelectedItem.ToString() + "\'", cn);
            d.Fill(dsCharacter, "Character");

            d = new OleDbDataAdapter("exec getScenarioByFilmAndChar \'" + fSelect.SelectedItem.ToString() + "\', \'" + cSelect.SelectedItem.ToString() + "\'", cn);
            d.Fill(dsCharacter, "Scenario");
            
        }

        private void EditCharacter(object sender, EventArgs e)
        {
            OleDbCommand uC = new OleDbCommand("update Character set name = ?, description = ? where id = ?", cn);
            uC.Parameters.Add("@CName", OleDbType.VarChar, 50);
            uC.Parameters.Add("@Description", OleDbType.VarChar);
            uC.Parameters.Add("@ID", OleDbType.Integer);
            uC.Parameters[0].Value = dsCharacter.Tables["Character"].Rows[0]["name"];
            uC.Parameters[1].Value = dsCharacter.Tables["Character"].Rows[0]["description"];
            uC.Parameters[2].Value = dsCharacter.Tables["Character"].Rows[0]["id"];
            uC.ExecuteNonQuery();

            uC = new OleDbCommand("update Staff set requirements = ? where Staff.id = (select staff_id from Character where id = ?)", cn);
            uC.Parameters.Add("@Req", OleDbType.VarChar, 50);
            uC.Parameters.Add("@ID", OleDbType.Integer);
            uC.Parameters[0].Value = dsCharacter.Tables["Character"].Rows[0]["requirements"];
            uC.Parameters[1].Value = dsCharacter.Tables["Character"].Rows[0]["id"];
            uC.ExecuteNonQuery();


            uC = new OleDbCommand("update Scenario set info = ?, doc = ? where id = ?", cn);
            uC.Parameters.Add("@SInfo", OleDbType.VarChar);
            uC.Parameters.Add("@SDoc", OleDbType.VarChar, 50);
            uC.Parameters.Add("@ID", OleDbType.Integer);

            foreach (DataRow el in dsCharacter.Tables["Scenario"].Rows)
            {
                uC.Parameters[0].Value = el["ScenarioInfo"];
                uC.Parameters[1].Value = el["ScenarioDoc"];
                uC.Parameters[2].Value = el["id"];
                uC.ExecuteNonQuery();
            }
            initCharacters(false);
        }

        private void createCharacter(object sender, EventArgs e)
        {
            if (cCreate.Text == "Create")
            {
                cSelect.SelectedIndex = -1;
                cCreate.Text = "Add";
                cEdit.Enabled = false;
                cAdd.Enabled = false;
                cReset.Enabled = false;
                dataScenario.Enabled = false;
                dataScenarioAdd.Enabled = false;
                dataChar.AllowUserToAddRows = true;
                return;
            }

            OleDbCommand uC = new OleDbCommand("exec createCharacter ?, ?, ?, ?", cn);
            uC.Parameters.Add("@FName", OleDbType.VarChar, 50);
            uC.Parameters.Add("@CName", OleDbType.VarChar, 50);
            uC.Parameters.Add("@Description", OleDbType.VarChar);
            uC.Parameters.Add("@Req", OleDbType.VarChar);
            uC.Parameters[0].Value = fSelect.SelectedItem.ToString();
            

            foreach (DataRow el in dsCharacter.Tables["Character"].Rows)
            {
                uC.Parameters[1].Value = el["name"];
                uC.Parameters[2].Value = el["description"];
                uC.Parameters[3].Value = el["requirements"];
                uC.ExecuteNonQuery();
            }

            initFilms();
        }
    }
}
