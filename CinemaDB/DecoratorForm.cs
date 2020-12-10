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
    public partial class DecoratorForm : Form
    {
        private OleDbConnection cn;
        private InitialForm previous;
        private int thisID;

        private bool exit = true;

        public DecoratorForm(InitialForm previous, int thisID)
        {
            InitializeComponent();
            this.previous = previous;
            this.cn = previous.getConnection();
            this.thisID = thisID;

            initProfile();
            initScene();
            initDecor();
            initPlace();
        }

        private void initProfile()
        {
            profileName.ReadOnly = true;
            profileContact.ReadOnly = true;
            profileAbout.ReadOnly = true;

            profileEditClose.Visible = false;
            profileEdit.Text = "Edit";

            OleDbCommand init = new OleDbCommand("exec getPersonInfo ?", cn);
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

        private void initScene()
        {
            dsCharacter.Tables["Scene"].Clear();
            sFilm.Items.Clear();
            sName.Text = "";
            sDesc.Text = "";
            sBudget.Text = "";

            OleDbDataReader d = new OleDbCommand("exec getFilmByDecorator " + thisID, cn).ExecuteReader();
            while(d.Read())
            {
                sFilm.Items.Add(d[0].ToString());
            }
            d.Close();

            OleDbDataAdapter dd = new OleDbDataAdapter("exec getSceneByDecorator " + thisID, cn);
            dd.Fill(dsCharacter, "Scene");
        }

        private void initDecor()
        {
            decorTypes.Items.Clear();
            budgetLabel.Text = "Budget:";
            decorCount.Text = "";
            dsCharacter.Tables["Decor"].Clear();
            dsCharacter.Tables["Scene"].Clear();
            dsCharacter.Tables["SceneDecor"].Clear();

            OleDbDataReader dd = new OleDbCommand("select name from DecorType", cn).ExecuteReader();
            while(dd.Read())
            {
                decorTypes.Items.Add(dd[0].ToString());
            }

            OleDbDataAdapter d = new OleDbDataAdapter("exec getSceneByDecorator "+thisID, cn);
            d.Fill(dsCharacter, "Scene");

            d = new OleDbDataAdapter("exec getDecorList", cn);
            d.Fill(dsCharacter, "Decor");
        }

        private void initPlace()
        {
            dsCharacter.Tables["Scene"].Clear();
            dsCharacter.Tables["ScenePlace"].Clear();
            dsCharacter.Tables["Place"].Clear();

            rentDuration.Text = "";
            pBudget.Text = "Budget:";

            OleDbDataAdapter dd = new OleDbDataAdapter("exec getSceneByDecorator " + thisID, cn);
            dd.Fill(dsCharacter, "Scene");

            dd = new OleDbDataAdapter("select id, name, description, address, rent from Place", cn);
            dd.Fill(dsCharacter, "Place");
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

            OleDbCommand updateProfile = new OleDbCommand("exec updatePersonInfo ?, ?, ?, ?", cn);
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

        private void createScene(object sender, EventArgs e)
        {
            if (sFilm.SelectedIndex == -1)
            {
                MessageBox.Show("Film field is empty", "Incorrect data", MessageBoxButtons.OK);
                return;
            }
            String film = sFilm.SelectedItem.ToString();
            String name = sName.Text.Trim();
            if (name.Length == 0)
            {
                MessageBox.Show("Name field is empty", "Incorrect data", MessageBoxButtons.OK);
                return;
            }
            OleDbDataReader r = new OleDbCommand("select Film.name from Scene join Film on Scene.film_id = Film.id where Scene.name = '"+name+"' and Scene.film_id = (select id from Film where name = '"+film+"')", cn).ExecuteReader();
            if (r.Read())
            {
                MessageBox.Show("This scene name is exist", "Incorrect data", MessageBoxButtons.OK);
                return;
            }
            r.Close();
            String desc = sDesc.Text.Trim();
            Double budget;
            if (!double.TryParse(sBudget.Text.Trim(), out budget))
            {
                MessageBox.Show("Budget is not double", "Incorrect data", MessageBoxButtons.OK);
                return;
            }
            if (budget < 0)
            {
                MessageBox.Show("Budget is negative", "Incorrect data", MessageBoxButtons.OK);
                return;
            }

            OleDbCommand d = new OleDbCommand("exec createScene '"+film+"', '"+name+"', '"+desc+"', "+budget, cn);
            d.ExecuteNonQuery();
            initScene();
        }

        private void editScene(object sender, EventArgs e)
        {
            foreach (DataRow el in dsCharacter.Tables["Scene"].Rows)
            {
                String name = el["name"].ToString();
                if (name.Length == 0)
                {
                    MessageBox.Show("Name field is empty", "Incorrect data", MessageBoxButtons.OK);
                    return;
                }
                String film = el["film"].ToString();
                int id = int.Parse(el["id"].ToString());
                OleDbDataReader r = new OleDbCommand("select Film.name from Scene join Film on Scene.film_id = Film.id where Scene.name = '" + name + "' and Scene.film_id = (select id from Film where name = '" + film + "') and Scene.id!="+id, cn).ExecuteReader();
                if (r.Read())
                {
                    MessageBox.Show("This scene name is exist", "Incorrect data", MessageBoxButtons.OK);
                    return;
                }
                r.Close();
                String desc = el["description"].ToString();
                String budget = el["budget"].ToString();
                OleDbCommand d = new OleDbCommand("update Scene set name = '"+name+"' where id = "+id, cn);
                d.ExecuteNonQuery();

                d = new OleDbCommand("update SceneInfo set description = '" + desc + "', budget = " + budget + " where id = (select info_id from Scene where id = " + id + ")", cn);
                d.ExecuteNonQuery();
            }
        }

        private void resetSceneEdit(object sender, EventArgs e)
        {
            initScene();
        }

        private void getSceneDecor(object sender, DataGridViewCellEventArgs e)
        {
            dsCharacter.Tables["SceneDecor"].Clear();
            int id = int.Parse(dataScene.SelectedRows[0].Cells[0].Value.ToString());

            OleDbDataAdapter d = new OleDbDataAdapter("exec getDecorByScene " + id, cn);
            d.Fill(dsCharacter, "SceneDecor");

            OleDbDataReader r = new OleDbCommand("select budget from SceneInfo, Scene where Scene.id="+id+" and Scene.info_id=SceneInfo.id", cn).ExecuteReader();
            r.Read();
            double budget = double.Parse(r[0].ToString());
            r.Close();

            r = new OleDbCommand("exec getSceneBudgetRemains "+id, cn).ExecuteReader();
            r.Read();
            double budgetRemains = double.Parse(r[0].ToString());
            r.Close();

            budgetLabel.Text = "Budget: "+budget+"(Rem "+budgetRemains+")";
        }

        private void editSceneDecor(object sender, EventArgs e)
        {
            foreach (DataRow el in dsCharacter.Tables["SceneDecor"].Rows)
            {
                int id = int.Parse(el["id"].ToString());
                int q;

                if (!int.TryParse(el["quantity"].ToString(), out q))
                {
                    MessageBox.Show("quantity is not int", "Incorrect data", MessageBoxButtons.OK);
                    return;
                }
                if (q < 1)
                {
                    MessageBox.Show("quantity is negative", "Incorrect data", MessageBoxButtons.OK);
                    return;
                }

                OleDbCommand d = new OleDbCommand("update SceneDecor set quantity = "+q+" where id = " + id, cn);
                d.ExecuteNonQuery();
            }
        }

        private void resetSceneDecorEdit(object sender, EventArgs e)
        {
            initDecor();
        }

        private void addDecor(object sender, EventArgs e)
        {
            int decID = int.Parse(dataDecorList.SelectedRows[0].Cells[0].Value.ToString());
            int sceneID = int.Parse(dataScene.SelectedRows[0].Cells[0].Value.ToString());
            int q;

            if (!int.TryParse(decorCount.Text, out q))
            {
                MessageBox.Show("quantity is not int", "Incorrect data", MessageBoxButtons.OK);
                return;
            }
            if (q < 1)
            {
                MessageBox.Show("quantity is negative", "Incorrect data", MessageBoxButtons.OK);
                return;
            }

            OleDbCommand d = new OleDbCommand("insert into SceneDecor (scene_id, decor_id, quantity) values("+sceneID+", "+decID+", "+q+")", cn);
            d.ExecuteNonQuery();
            initDecor();
        }

        private void deleteDecor(object sender, EventArgs e)
        {
            if (dataSceneDecor.SelectedRows.Count == 0)
            {
                return;
            }

            int id = int.Parse(dataSceneDecor.SelectedRows[0].Cells[0].Value.ToString());

            OleDbCommand d = new OleDbCommand("delete from SceneDecor where id=" + id, cn);
            d.ExecuteNonQuery();
            initDecor();
        }

        private void filter(object sender, EventArgs e)
        {
            if (decorTypes.SelectedIndex == -1)
            {
                MessageBox.Show("Type not selected", "Incorrect data", MessageBoxButtons.OK);
                return;
            }
            String type = decorTypes.Text;
            double min, max;
            if (!double.TryParse(minCost.Text, out min) || !double.TryParse(maxCost.Text, out max))
            {
                MessageBox.Show("From or To not correct", "Incorrect data", MessageBoxButtons.OK);
                return;
            }
            if (min > max || min < 0 || max < 0)
            {
                MessageBox.Show("From or To not correct", "Incorrect data", MessageBoxButtons.OK);
                return;
            }

            dsCharacter.Tables["Decor"].Clear();
            
            OleDbDataAdapter d = new OleDbDataAdapter("exec getDecor '"+type+"', "+min+", "+max, cn);
            d.Fill(dsCharacter, "Decor");
        }

        private void getPlaceByScene(object sender, DataGridViewCellEventArgs e)
        {
            dsCharacter.Tables["ScenePlace"].Clear();
            int id = int.Parse(dataScenePlace.SelectedRows[0].Cells[0].Value.ToString());

            OleDbDataAdapter d = new OleDbDataAdapter("exec getPalceByScene "+id, cn);
            d.Fill(dsCharacter, "ScenePlace");

            OleDbDataReader r = new OleDbCommand("select budget from SceneInfo, Scene where Scene.id=" + id + " and Scene.info_id=SceneInfo.id", cn).ExecuteReader();
            r.Read();
            double budget = double.Parse(r[0].ToString());
            r.Close();

            r = new OleDbCommand("exec getSceneBudgetRemains " + id, cn).ExecuteReader();
            r.Read();
            double budgetRemains = double.Parse(r[0].ToString());
            r.Close();

            pBudget.Text = "Budget: " + budget + "(Rem " + budgetRemains + ")";
        }

        private void resetPlace(object sender, EventArgs e)
        {
            initPlace();
        }

        private void setScenePlace(object sender, EventArgs e)
        {
            int sceneID = int.Parse(dataScenePlace.SelectedRows[0].Cells[0].Value.ToString());
            int dur;

            if (!int.TryParse(rentDuration.Text, out dur))
            {
                MessageBox.Show("duration is not int", "Incorrect data", MessageBoxButtons.OK);
                return;
            }
            if (dur < 1)
            {
                MessageBox.Show("duration is negative", "Incorrect data", MessageBoxButtons.OK);
                return;
            }

            int placeID = int.Parse(dataPalce.SelectedRows[0].Cells[0].Value.ToString());

            OleDbCommand d = new OleDbCommand("update SceneInfo set place_id = "+placeID+", duration = "+dur+" where id = (select info_id from Scene where id ="+sceneID+")", cn);
            d.ExecuteNonQuery();
            initPlace();

        }

        private void palceFilter(object sender, EventArgs e)
        {
            double min, max;
            if (!double.TryParse(minPlace.Text, out min) || !double.TryParse(maxPlace.Text, out max))
            {
                MessageBox.Show("From or To not correct", "Incorrect data", MessageBoxButtons.OK);
                return;
            }
            if (min > max || min < 0 || max < 0)
            {
                MessageBox.Show("From or To not correct", "Incorrect data", MessageBoxButtons.OK);
                return;
            }

            dsCharacter.Tables["Place"].Clear();

            OleDbDataAdapter d = new OleDbDataAdapter("select id, name, description, address, rent from Place where rent>="+min+" and rent <="+max, cn);
            d.Fill(dsCharacter, "Place");
        }
    }
}
