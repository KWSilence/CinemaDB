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
            initStaff();
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

        private void initStaff()
        {
            sFilm.Items.Clear();
            sAccept.Enabled = false;
            sDeny.Enabled = false;
            sWait.Enabled = false;

            OleDbCommand film = new OleDbCommand("exec getProducerFilms ?", cn);
            film.Parameters.Add("@CreatorID", OleDbType.Integer);
            film.Parameters[0].Value = thisID;
            OleDbDataReader rdr = film.ExecuteReader();
            while (rdr.Read())
            {
                sFilm.Items.Add(rdr[0].ToString());
            }
            rdr.Close();

            dsCharacter.Tables["WorkSheet"].Clear();
            dsCharacter.Tables["Staff"].Clear();
            dsCharacter.Tables["StaffUse"].Clear();
        }

        private void initTask()
        {
            tFilm.Items.Clear();
            tScene.Items.Clear();
            tCharacter.Items.Clear();
            tTask.Items.Clear();

            dsCharacter.Tables["Tasks"].Clear();
            dsCharacter.Tables["TasksAdd"].Clear();

            dataTasksAdd.AllowUserToAddRows = false;

            tAddButton.Enabled = false;
            tResetButton.Enabled = false;
            tEditButton.Enabled = false;
            tTask.Enabled = false;

            OleDbCommand film = new OleDbCommand("exec getProducerFilms ?", cn);
            film.Parameters.Add("@CreatorID", OleDbType.Integer);
            film.Parameters[0].Value = thisID;
            OleDbDataReader rdr = film.ExecuteReader();
            while (rdr.Read())
            {
                tFilm.Items.Add(rdr[0].ToString());
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
            MessageBox.Show(dsCharacter.Tables["Scenario"].Rows[dataScenario.SelectedCells[0].RowIndex]["ScenarioInfo"].ToString(), "Success", MessageBoxButtons.OK);

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

        private void sFilmChange(object sender, EventArgs e)
        {
            if (sFilm.SelectedIndex == -1)
            {
                return;
            }
            sAccept.Enabled = true;
            sDeny.Enabled = true;
            sWait.Enabled = true;
            dsCharacter.Tables["WorkSheet"].Clear();
            dsCharacter.Tables["Staff"].Clear();
            dsCharacter.Tables["StaffUse"].Clear();

            OleDbDataAdapter du = new OleDbDataAdapter("exec getDecoratorAndActorWorkByFilm \'" + sFilm.SelectedItem.ToString() + "\'", cn);
            du.Fill(dsCharacter, "WorkSheet");

            du = new OleDbDataAdapter("exec getAllStaffByFilm \'" + sFilm.SelectedItem.ToString() + "\'", cn);
            du.Fill(dsCharacter, "Staff");

            du = new OleDbDataAdapter("exec getStaffByFilm \'" + sFilm.SelectedItem.ToString() + "\'", cn);
            du.Fill(dsCharacter, "StaffUse");
        }

        private void sAcceptEvent(object sender, EventArgs e)
        {
            int id = int.Parse(dsCharacter.Tables["WorkSheet"].Rows[dataWork.SelectedRows[0].Index]["id"].ToString());

            OleDbCommand d = new OleDbCommand("update WorkSheetInfo set state_id = 1 where id = "+id, cn);
            d.ExecuteNonQuery();

            dsCharacter.Tables["WorkSheet"].Clear();
            dsCharacter.Tables["Staff"].Clear();
            dsCharacter.Tables["StaffUse"].Clear();
            OleDbDataAdapter du = new OleDbDataAdapter("exec getDecoratorAndActorWorkByFilm \'" + sFilm.SelectedItem.ToString() + "\'", cn);
            du.Fill(dsCharacter, "WorkSheet");

            du = new OleDbDataAdapter("exec getAllStaffByFilm \'" + sFilm.SelectedItem.ToString() + "\'", cn);
            du.Fill(dsCharacter, "Staff");

            du = new OleDbDataAdapter("exec getStaffByFilm \'" + sFilm.SelectedItem.ToString() + "\'", cn);
            du.Fill(dsCharacter, "StaffUse");
        }

        private void sDenyEvent(object sender, EventArgs e)
        {
            int id = int.Parse(dsCharacter.Tables["WorkSheet"].Rows[dataWork.SelectedRows[0].Index]["id"].ToString());

            OleDbCommand d = new OleDbCommand("update WorkSheetInfo set state_id = 3 where id = " + id, cn);
            d.ExecuteNonQuery();

            dsCharacter.Tables["WorkSheet"].Clear();
            dsCharacter.Tables["Staff"].Clear();
            dsCharacter.Tables["StaffUse"].Clear();
            OleDbDataAdapter du = new OleDbDataAdapter("exec getDecoratorAndActorWorkByFilm \'" + sFilm.SelectedItem.ToString() + "\'", cn);
            du.Fill(dsCharacter, "WorkSheet");

            du = new OleDbDataAdapter("exec getAllStaffByFilm \'" + sFilm.SelectedItem.ToString() + "\'", cn);
            du.Fill(dsCharacter, "Staff");

            du = new OleDbDataAdapter("exec getStaffByFilm \'" + sFilm.SelectedItem.ToString() + "\'", cn);
            du.Fill(dsCharacter, "StaffUse");
        }

        private void sWaitEvent(object sender, EventArgs e)
        {
            int id = int.Parse(dsCharacter.Tables["WorkSheet"].Rows[dataWork.SelectedRows[0].Index]["id"].ToString());


            OleDbCommand d = new OleDbCommand("update WorkSheetInfo set state_id = 2 where id = " + id, cn);
            d.ExecuteNonQuery();

            dsCharacter.Tables["WorkSheet"].Clear();
            dsCharacter.Tables["Staff"].Clear();
            dsCharacter.Tables["StaffUse"].Clear();
            OleDbDataAdapter du = new OleDbDataAdapter("exec getDecoratorAndActorWorkByFilm \'" + sFilm.SelectedItem.ToString() + "\'", cn);
            du.Fill(dsCharacter, "WorkSheet");

            du = new OleDbDataAdapter("exec getAllStaffByFilm \'" + sFilm.SelectedItem.ToString() + "\'", cn);
            du.Fill(dsCharacter, "Staff");

            du = new OleDbDataAdapter("exec getStaffByFilm \'" + sFilm.SelectedItem.ToString() + "\'", cn);
            du.Fill(dsCharacter, "StaffUse");
        }

        private void tFilmChange(object sender, EventArgs e)
        {
            if (tFilm.SelectedIndex == -1)
            {
                return;
            }

            tScene.Items.Clear();
            tCharacter.Items.Clear();
            tTask.Items.Clear();
            tTask.Text = "";
            tTask.Enabled = false;
            tAddButton.Enabled = false;
            tResetButton.Enabled = false;
            tEditButton.Enabled = false;
            dataTasksAdd.AllowUserToAddRows = false;
            dsCharacter.Tables["Tasks"].Clear();
            dsCharacter.Tables["TasksAdd"].Clear();

            OleDbCommand scene = new OleDbCommand("select name from Scene where film_id = (select id from Film where name = ?)", cn);
            scene.Parameters.Add("@Name", OleDbType.VarChar, 50);
            scene.Parameters[0].Value = tFilm.SelectedItem.ToString();
            OleDbDataReader rdr = scene.ExecuteReader();
            while (rdr.Read())
            {
                tScene.Items.Add(rdr[0].ToString());
            }
            rdr.Close();
        }

        private void tSceneChange(object sender, EventArgs e)
        {
            if (tScene.SelectedIndex == -1)
            {
                return;
            }

            tCharacter.Items.Clear();
            tTask.Items.Clear();
            tTask.Text = "";
            tTask.Enabled = false;
            tAddButton.Enabled = false;
            tResetButton.Enabled = false;
            tEditButton.Enabled = false;
            dsCharacter.Tables["Tasks"].Clear();
            dsCharacter.Tables["TasksAdd"].Clear();

            dataTasksAdd.AllowUserToAddRows = false;

            OleDbCommand character = new OleDbCommand("select name from Character where film_id = (select id from Film where name = ?)", cn);
            character.Parameters.Add("@Name", OleDbType.VarChar, 50);
            character.Parameters[0].Value = tFilm.SelectedItem.ToString();
            OleDbDataReader rdr = character.ExecuteReader();
            while (rdr.Read())
            {
                tCharacter.Items.Add(rdr[0].ToString());
            }
            rdr.Close();
        }

        private void tCharChange(object sender, EventArgs e)
        {
            if (tCharacter.SelectedIndex == -1)
            {
                return;
            }
            tTask.Items.Clear();
            tTask.Text = "";
            tTask.Enabled = true;
            tAddButton.Enabled = true;
            tResetButton.Enabled = true;
            tEditButton.Enabled = true;
            dataTasksAdd.AllowUserToAddRows = true;
            dsCharacter.Tables["Tasks"].Clear();
            dsCharacter.Tables["TasksAdd"].Clear();

            OleDbCommand task = new OleDbCommand("exec getTasks ?, ?, ?", cn);
            task.Parameters.Add("@FName", OleDbType.VarChar, 50);
            task.Parameters.Add("@SName", OleDbType.VarChar, 50);
            task.Parameters.Add("@CName", OleDbType.VarChar, 50);
            task.Parameters[0].Value = tFilm.SelectedItem.ToString();
            task.Parameters[1].Value = tScene.SelectedItem.ToString();
            task.Parameters[2].Value = tCharacter.SelectedItem.ToString();
            OleDbDataReader rdr = task.ExecuteReader();
            while (rdr.Read())
            {
                tTask.Items.Add(rdr[0].ToString());
            }
            rdr.Close();

            OleDbDataAdapter taskInfo = new OleDbDataAdapter("exec getTasksInfo '"+ tFilm.SelectedItem.ToString() + "', '"+ tScene.SelectedItem.ToString() + "', '"+ tCharacter.SelectedItem.ToString() + "'", cn);
            taskInfo.Fill(dsCharacter, "Tasks");
        }

        private void addTask(object sender, EventArgs e)
        {
            String taskName = tTask.Text.Trim();
            if (taskName.Length == 0)
            {
                MessageBox.Show("Task name is empty", "Incorrect data", MessageBoxButtons.OK);
                return;
            }

            if (tTask.SelectedIndex == -1)
            {
                OleDbCommand d = new OleDbCommand("exec createTask ?, ?, ?, ?", cn);
                d.Parameters.Add("@FName", OleDbType.VarChar, 50);
                d.Parameters.Add("@SName", OleDbType.VarChar, 50);
                d.Parameters.Add("@CName", OleDbType.VarChar, 50);
                d.Parameters.Add("@TName", OleDbType.VarChar, 50);
                d.Parameters[0].Value = tFilm.SelectedItem.ToString();
                d.Parameters[1].Value = tScene.SelectedItem.ToString();
                d.Parameters[2].Value = tCharacter.SelectedItem.ToString();
                d.Parameters[3].Value = tTask.Text.Trim();
                d.ExecuteNonQuery();

                d = new OleDbCommand("select max(id) from Task", cn);
                OleDbDataReader r = d.ExecuteReader();
                r.Read();
                int taskID = int.Parse(r[0].ToString());
                r.Close();

                d = new OleDbCommand("insert into TaskItem (task_id, description, state_id) values (?, ?, 2)", cn);
                d.Parameters.Add("@TID", OleDbType.Integer);
                d.Parameters.Add("@Description", OleDbType.VarChar);
                d.Parameters[0].Value = taskID;

                foreach (DataRow el in dsCharacter.Tables["TasksAdd"].Rows)
                {
                    String s = el["description"].ToString();
                    d.Parameters[1].Value = s;
                    d.ExecuteNonQuery();
                }
            }
            else
            {
                OleDbCommand d = new OleDbCommand("select id from Task where name = '"+tTask.SelectedItem.ToString()+"' and scene_id = (select id from Scene where name = '"+tScene.SelectedItem.ToString()+"' and film_id = (select id from Film where name = '"+tFilm.SelectedItem.ToString()+"'))", cn);
                OleDbDataReader r = d.ExecuteReader();
                r.Read();
                int taskID = int.Parse(r[0].ToString());
                r.Close();

                d = new OleDbCommand("insert into TaskItem (task_id, description, state_id) values (?, ?, 2)", cn);
                d.Parameters.Add("@TID", OleDbType.Integer);
                d.Parameters.Add("@Description", OleDbType.VarChar);
                d.Parameters[0].Value = taskID;

                foreach (DataRow el in dsCharacter.Tables["TasksAdd"].Rows)
                {
                    String s = el["description"].ToString();
                    d.Parameters[1].Value = s;
                    d.ExecuteNonQuery();
                }
            }

            tTask.Items.Clear();
            tTask.Text = "";
            tTask.Enabled = true;
            tAddButton.Enabled = true;
            tResetButton.Enabled = true;
            tEditButton.Enabled = true;
            dataTasksAdd.AllowUserToAddRows = true;
            dsCharacter.Tables["Tasks"].Clear();
            dsCharacter.Tables["TasksAdd"].Clear();

            OleDbCommand task = new OleDbCommand("exec getTasks ?, ?, ?", cn);
            task.Parameters.Add("@FName", OleDbType.VarChar, 50);
            task.Parameters.Add("@SName", OleDbType.VarChar, 50);
            task.Parameters.Add("@CName", OleDbType.VarChar, 50);
            task.Parameters[0].Value = tFilm.SelectedItem.ToString();
            task.Parameters[1].Value = tScene.SelectedItem.ToString();
            task.Parameters[2].Value = tCharacter.SelectedItem.ToString();
            OleDbDataReader rdr = task.ExecuteReader();
            while (rdr.Read())
            {
                tTask.Items.Add(rdr[0].ToString());
            }
            rdr.Close();

            OleDbDataAdapter taskInfo = new OleDbDataAdapter("exec getTasksInfo '" + tFilm.SelectedItem.ToString() + "', '" + tScene.SelectedItem.ToString() + "', '" + tCharacter.SelectedItem.ToString() + "'", cn);
            taskInfo.Fill(dsCharacter, "Tasks");
        }

        private void editTask(object sender, EventArgs e)
        {

            OleDbCommand d = new OleDbCommand("update TaskItem set description = ? where id = ?", cn);
            d.Parameters.Add("@Description", OleDbType.VarChar);
            d.Parameters.Add("@ID", OleDbType.Integer);

            foreach (DataRow el in dsCharacter.Tables["Tasks"].Rows)
            {
                d.Parameters[0].Value = el["description"].ToString();
                d.Parameters[1].Value = el["id"].ToString();
                d.ExecuteNonQuery();
            }
        }

        private void resetTaskEdit(object sender, EventArgs e)
        {
            tTask.Enabled = true;
            tAddButton.Enabled = true;
            tResetButton.Enabled = true;
            tEditButton.Enabled = true;
            dataTasksAdd.AllowUserToAddRows = true;
            dsCharacter.Tables["Tasks"].Clear();
            dsCharacter.Tables["TasksAdd"].Clear();

            OleDbCommand task = new OleDbCommand("exec getTasks ?, ?, ?", cn);
            task.Parameters.Add("@FName", OleDbType.VarChar, 50);
            task.Parameters.Add("@SName", OleDbType.VarChar, 50);
            task.Parameters.Add("@CName", OleDbType.VarChar, 50);
            task.Parameters[0].Value = tFilm.SelectedItem.ToString();
            task.Parameters[1].Value = tScene.SelectedItem.ToString();
            task.Parameters[2].Value = tCharacter.SelectedItem.ToString();
            OleDbDataReader rdr = task.ExecuteReader();
            while (rdr.Read())
            {
                tTask.Items.Add(rdr[0].ToString());
            }
            rdr.Close();

            OleDbDataAdapter taskInfo = new OleDbDataAdapter("exec getTasksInfo '" + tFilm.SelectedItem.ToString() + "', '" + tScene.SelectedItem.ToString() + "', '" + tCharacter.SelectedItem.ToString() + "'", cn);
            taskInfo.Fill(dsCharacter, "Tasks");
        }
    }
}
