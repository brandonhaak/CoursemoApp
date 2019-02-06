using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoursemoApp
{
    public partial class Form1 : Form
    {
        public static readonly string dbfilename = "Coursemo.mdf";

        public Form1()
        {
            InitializeComponent();
        }

        private CoursemoEntities db;

        public string connectioninfo = String.Format(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\{0};Integrated Security=True;",
        dbfilename);

        private void Form1_Load(object sender, EventArgs e)
        {
            //
            // As app starts up, ping SQL Server to start it running:
            //

            DataAccessTier.Data datatier = new DataAccessTier.Data(dbfilename);

            try
            {
                datatier.TestConnection();
            }
            catch
            {
                // ignore since just pinging to start:
            }
            //
            //Create Linq to SQL object context
            //

            db = new CoursemoEntities();

            
        }

        //Functions
        //updateLstStuCourses1

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdLoadCourses_Click(object sender, EventArgs e)
        {
            this.lstCourses.Items.Clear();
            this.txtSemYear.Clear();
            this.txtDayTime.Clear();
            this.txtClassSize.ResetText();
            this.lstEnrolled.Items.Clear();
            this.lstWaitlist.Items.Clear();
            this.txtNumEnrolled.ResetText();
            this.txtNumWaitlisted.ResetText();
            //MessageBox.Show(Convert.ToString(db.Courses.Count<Course>()));

            int retries = 0;
            while (retries < 3)
            {
                try
                {
                    using (var tx = db.Database.BeginTransaction())
                    {
                        foreach (Course c in db.Courses)
                        {
                            this.lstCourses.Items.Add(c);
                        }
                        tx.Commit();
                        break;
                    }// end tx
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 1205)
                    {
                        retries++;
                    }
                    else
                    {
                        MessageBox.Show(ex.Message);
                        break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    break;
                }
                finally
                {

                }
            }
        }

        private void lstCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstEnrolled.Items.Clear();
            lstWaitlist.Items.Clear();
            txtNumEnrolled.ResetText();
            txtNumWaitlisted.ResetText();

            try
            {

                if (lstCourses.SelectedIndex > -1)
                {
                    //Course cur = db.Courses.Local.ElementAt<Course>(lstCourses.SelectedIndex);

                    Course selectedCourse = lstCourses.SelectedItem as Course;
                    txtSemYear.Text = selectedCourse.printSemYear();
                    txtDayTime.Text = selectedCourse.printDayTime();
                    txtClassSize.Text = Convert.ToString(selectedCourse.ClassSize);

                    var enrolled = db.StudentCourses.Where<StudentCourse>(sc => sc.CRN == selectedCourse.CRN);
                    this.txtNumEnrolled.Text = Convert.ToString(selectedCourse.NumEnrolled);
                    foreach (var stu in enrolled)
                    {
                        Student selectedStudent = db.Students.Single(s => s.NetID == stu.NetID);
                        this.lstEnrolled.Items.Add(selectedStudent);
                    }

                    var wList = db.Waitlists.Where<Waitlist>(w => w.CRN == selectedCourse.CRN);
                    this.txtNumWaitlisted.Text = Convert.ToString(wList.Count());
                    foreach (var stu in wList)
                    {
                        Student selectedStudent = db.Students.Single(s => s.NetID == stu.NetID);
                        this.lstWaitlist.Items.Add(selectedStudent);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void cmdLoadStudents_Click(object sender, EventArgs e)
        {
            this.lstStudents1.Items.Clear();
            this.lstStudents2.Items.Clear();
            this.lstStuCourses1.Items.Clear();
            this.lstStuCourses2.Items.Clear();

            int retries = 0;
            while (retries < 3)
            {
                try
                {
                    using (var tx = db.Database.BeginTransaction())
                    {
                        foreach (Student s in db.Students)
                        {
                            this.lstStudents1.Items.Add(s);
                            this.lstStudents2.Items.Add(s);
                        }
                        tx.Commit();
                        break;
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 1205)
                    {
                        retries++;
                    }
                    else
                    {
                        MessageBox.Show(ex.Message);
                        break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    break;
                }
                finally
                {

                }
            }
        }

        private void cmdEnroll1_Click(object sender, EventArgs e)
        {
            if (lstCourses.SelectedIndex > -1)
            {

                //Code for Delay
                int timeInMS;
                if (System.Int32.TryParse(this.txtDelay.Text, out timeInMS) == true) ;
                else
                    timeInMS = 0;
                System.Threading.Thread.Sleep(timeInMS);

                int retries = 0;
                while (retries < 3)
                {
                    try
                    {
                        using (var transaction = db.Database.BeginTransaction())
                        {
                            //db = new SampleContext();
                            Course cur = lstCourses.SelectedItem as Course;
                            Student stu = lstStudents1.SelectedItem as Student;
                            if (db.StudentCourses.Any<StudentCourse>(sc => sc.NetID == stu.NetID && sc.CRN == cur.CRN))
                            {
                                MessageBox.Show("Student is already enrolled in this course!");
                            }
                            else if (cur.NumEnrolled == cur.ClassSize)
                            {
                                //Add student to the waitlist
                                var waitlistObj = new Waitlist { CRN = cur.CRN, NetID = stu.NetID };
                                db.Waitlists.Add(waitlistObj);
                                db.SaveChanges();
                                MessageBox.Show("This course is currently at capacity, you have been added to the Waitlist");
                            }
                            else
                            {
                                //Add student to the course enrollments.
                                string num = Convert.ToString(cur.CourseNum);
                                var stuCourseObj = new StudentCourse { CRN = cur.CRN, NetID = stu.NetID };
                                db.StudentCourses.Add(stuCourseObj);
                                var c = db.Courses.Find(cur.CRN);
                                c.NumEnrolled++;
                                db.SaveChanges();
                                MessageBox.Show("You have been added to the course " + cur.Department + " " + num + "!");
                            }
                            transaction.Commit();
                            break;
                        }//end transaction

                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 1205)
                        {
                            retries++;
                        }
                        else
                        {
                            MessageBox.Show(ex.Message);
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        break;
                    }
                    finally
                    {
                        cmdLoadCourses_Click(sender, e);
                        cmdLoadStudents_Click(sender, e);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a course to add from the list at the left");
            }
        }

        private void cmdDrop1_Click(object sender, EventArgs e)
        {
            if (lstStuCourses1.SelectedIndex > -1)
            {

                //Code for Delay
                int timeInMS;
                if (System.Int32.TryParse(this.txtDelay.Text, out timeInMS) == true) ;
                else
                    timeInMS = 0;
                System.Threading.Thread.Sleep(timeInMS);

                int retries = 0;
                while (retries < 3)
                {
                    try
                    {
                        using (var transaction = db.Database.BeginTransaction())
                        {
                            Student stu = lstStudents1.SelectedItem as Student;
                            Course toDrop = lstStuCourses1.SelectedItem as Course;

                            if (toDrop == null)
                            {
                                string courseString = lstStuCourses1.SelectedItem as String;
                                string[] val = courseString.Split(' ');
                                //MessageBox.Show(val[2]);
                                int crnLookup = Convert.ToInt32(val[2]);
                                toDrop = db.Courses.Single<Course>(c => c.CRN == crnLookup);
                            }

                            if (db.StudentCourses.Any<StudentCourse>(sc => sc.NetID == stu.NetID && sc.CRN == toDrop.CRN))
                            {
                                var c = db.Courses.Find(toDrop.CRN);
                                c.NumEnrolled--;
                                db.StudentCourses.Remove(db.StudentCourses.Single<StudentCourse>(sc => sc.CRN == toDrop.CRN && stu.NetID == sc.NetID));
                                db.SaveChanges();
                                MessageBox.Show(stu.NetID + " has successfully dropped " + toDrop.Department + " " + toDrop.CourseNum + "!");
                                if (db.Waitlists.Any<Waitlist>(w => w.CRN == toDrop.CRN))
                                {
                                    Waitlist nextStudent = db.Waitlists.First<Waitlist>(w => w.CRN == toDrop.CRN);
                                    var stuCourseObj = new StudentCourse { CRN = nextStudent.CRN, NetID = nextStudent.NetID };
                                    db.StudentCourses.Add(stuCourseObj);
                                    c.NumEnrolled++;
                                    db.Waitlists.Remove(nextStudent);
                                    db.SaveChanges();
                                    MessageBox.Show(nextStudent.NetID + " has been enrolled in " + toDrop.Department + " " + toDrop.CourseNum + " from the waitlist!");
                                }
                            }

                            else if (db.Waitlists.Any<Waitlist>(w => w.NetID == stu.NetID && w.CRN == toDrop.CRN))
                            {
                                db.Waitlists.Remove(db.Waitlists.First<Waitlist>(w => w.CRN == toDrop.CRN && stu.NetID == w.NetID));
                                db.SaveChanges();
                                MessageBox.Show(stu.NetID + " has successfully ben removed from the waitlist for " + toDrop.Department + " " + Convert.ToString(toDrop.CourseNum) + "!");
                            }

                            else
                            {
                                MessageBox.Show("Error student is neither enrolled, nor on the waitlist for this course!");
                            }

                            transaction.Commit();
                            break;
                        }//end transaction

                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 1205)
                        {
                            retries++;
                        }
                        else
                        {
                            MessageBox.Show(ex.Message);
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        break;
                    }
                    finally
                    {
                        cmdLoadCourses_Click(sender, e);
                        cmdLoadStudents_Click(sender, e);
                    }
                }
            }
            else if (lstStuCourses1.Items.Count == 0)
            {
                MessageBox.Show("You currently have no courses to drop!");
            }
            else
            {
                MessageBox.Show("Please select a course to add from the respective list of student courses.");
            }
        }

        private void resetDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
            // Reset the database, i.e. delete all the rentals and
            // set all bikes to *not* rented:
            //

            int retries = 0;
            SqlConnection db = null;
            SqlTransaction tx = null;

            while (retries < 3)
            {
                try
                {

                    db = new SqlConnection(connectioninfo);
                    db.Open();

                    tx = db.BeginTransaction(IsolationLevel.Serializable);

                    string sql = string.Format(@"
DELETE FROM StudentCourses;  -- delete all StudentCourses:

DELETE FROM Waitlist;  -- now delete all Waitlist items:

UPDATE Courses

Set NumEnrolled = 0;
");

                    //MessageBox.Show(sql);

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = db;
                    cmd.CommandText = sql;
                    cmd.Transaction = tx;

                    //MessageBox.Show(sql);

                    int rowsModified = cmd.ExecuteNonQuery();

                    //Commit Transactions
                    tx.Commit();

                    //
                    // reset the GUI:
                    //
                    cmdLoadCourses_Click(sender, e);
                    cmdLoadStudents_Click(sender, e);
                    break;
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 1205)
                    {
                        retries++;
                    }
                    else
                    {
                        MessageBox.Show(ex.Message);
                        break;
                    }
                }

                catch (Exception ex)
                {
                    if (tx != null)
                        tx.Rollback();
                    MessageBox.Show(ex.Message);
                    break;
                }
                finally
                {
                    //MessageBox.Show("This is the Finally Satement");
                    if (db != null)
                        db.Close();
                }
            }


        }

        private void lstStuCourses1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstStudents1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstStuCourses1.Items.Clear();
            try
            {   
                Student s = lstStudents1.SelectedItem as Student;

                var enrolledCourses = db.StudentCourses.Where<StudentCourse>(sc => sc.NetID == s.NetID);
                foreach (var cour in enrolledCourses)
                {
                    Course selected = db.Courses.Single(c => c.CRN == cour.CRN);
                    this.lstStuCourses1.Items.Add(selected);
                }

                var waitlistCourses = db.Waitlists.Where<Waitlist>(sc => sc.NetID == s.NetID);
                foreach (var wait in waitlistCourses)
                {
                    Course selected = db.Courses.Single(c => c.CRN == wait.CRN);
                    this.lstStuCourses1.Items.Add(selected.waitlistToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void cmdEnroll2_Click(object sender, EventArgs e)
        {
            if (lstCourses.SelectedIndex > -1)
            {

                //Code for Delay
                int timeInMS;
                if (System.Int32.TryParse(this.txtDelay.Text, out timeInMS) == true) ;
                else
                    timeInMS = 0;
                System.Threading.Thread.Sleep(timeInMS);

                int retries = 0;
                while (retries < 3)
                {
                    try
                    {
                        using (var transaction = db.Database.BeginTransaction())
                        {
                            //db = new SampleContext();
                            Course cur = lstCourses.SelectedItem as Course;
                            Student stu = lstStudents2.SelectedItem as Student;
                            if (db.StudentCourses.Any<StudentCourse>(sc => sc.NetID == stu.NetID && sc.CRN == cur.CRN))
                            {
                                MessageBox.Show("Student is already enrolled in this course!");
                            }
                            else if (cur.NumEnrolled == cur.ClassSize)
                            {
                                //Add student to the waitlist
                                var waitlistObj = new Waitlist { CRN = cur.CRN, NetID = stu.NetID };
                                db.Waitlists.Add(waitlistObj);
                                db.SaveChanges();
                                MessageBox.Show("This course is currently at capacity, you have been added to the Waitlist");
                            }
                            else
                            {
                                //Add student to the course enrollments.
                                string num = Convert.ToString(cur.CourseNum);
                                var stuCourseObj = new StudentCourse { CRN = cur.CRN, NetID = stu.NetID };
                                db.StudentCourses.Add(stuCourseObj);
                                var c = db.Courses.Find(cur.CRN);
                                c.NumEnrolled++;
                                db.SaveChanges();
                                MessageBox.Show("You have been added to the course " + cur.Department + " " + num + "!");
                            }
                            transaction.Commit();
                            break;
                        }//end transaction

                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 1205)
                        {
                            retries++;
                        }
                        else
                        {
                            MessageBox.Show(ex.Message);
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        break;
                    }
                    finally
                    {
                        cmdLoadCourses_Click(sender, e);
                        cmdLoadStudents_Click(sender, e);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a course to add from the list at the left");
            }
        }

        private void cmdDrop2_Click(object sender, EventArgs e)
        {
            if (lstStuCourses2.SelectedIndex > -1)
            {

                //Code for Delay
                int timeInMS;
                if (System.Int32.TryParse(this.txtDelay.Text, out timeInMS) == true) ;
                else
                    timeInMS = 0;
                System.Threading.Thread.Sleep(timeInMS);

                int retries = 0;
                while (retries < 3)
                {
                    try
                    {
                        using (var transaction = db.Database.BeginTransaction())
                        {
                            Student stu = lstStudents2.SelectedItem as Student;
                            Course toDrop = lstStuCourses2.SelectedItem as Course;

                            if (toDrop == null)
                            {
                                string courseString = lstStuCourses2.SelectedItem as String;
                                string[] val = courseString.Split(' ');
                                //MessageBox.Show(val[2]);
                                int crnLookup = Convert.ToInt32(val[2]);
                                toDrop = db.Courses.Single<Course>(c => c.CRN == crnLookup);
                            }

                            if (db.StudentCourses.Any<StudentCourse>(sc => sc.NetID == stu.NetID && sc.CRN == toDrop.CRN))
                            {
                                var c = db.Courses.Find(toDrop.CRN);
                                c.NumEnrolled--;
                                db.StudentCourses.Remove(db.StudentCourses.Single<StudentCourse>(sc => sc.CRN == toDrop.CRN && stu.NetID == sc.NetID));
                                db.SaveChanges();
                                MessageBox.Show(stu.NetID + " has successfully dropped " + toDrop.Department + " " + toDrop.CourseNum + "!");
                                if (db.Waitlists.Any<Waitlist>(w => w.CRN == toDrop.CRN))
                                {
                                    Waitlist nextStudent = db.Waitlists.First<Waitlist>(w => w.CRN == toDrop.CRN);
                                    var stuCourseObj = new StudentCourse { CRN = nextStudent.CRN, NetID = nextStudent.NetID };
                                    db.StudentCourses.Add(stuCourseObj);
                                    c.NumEnrolled++;
                                    db.Waitlists.Remove(nextStudent);
                                    db.SaveChanges();
                                    MessageBox.Show(nextStudent.NetID + " has been enrolled in " + toDrop.Department + " " + toDrop.CourseNum + " from the waitlist!");
                                }
                            }

                            else if (db.Waitlists.Any<Waitlist>(w => w.NetID == stu.NetID && w.CRN == toDrop.CRN))
                            {
                                db.Waitlists.Remove(db.Waitlists.First<Waitlist>(w => w.CRN == toDrop.CRN && stu.NetID == w.NetID));
                                db.SaveChanges();
                                MessageBox.Show(stu.NetID + " has successfully ben removed from the waitlist for " + toDrop.Department + " " + Convert.ToString(toDrop.CourseNum) + "!");
                            }

                            else
                            {
                                MessageBox.Show("Error student is neither enrolled, nor on the waitlist for this course!");
                            }

                            transaction.Commit();
                            break;
                        }//end transaction

                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 1205)
                        {
                            retries++;
                        }
                        else
                        {
                            MessageBox.Show(ex.Message);
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        break;
                    }
                    finally
                    {
                        cmdLoadCourses_Click(sender, e);
                        cmdLoadStudents_Click(sender, e);
                    }
                }
            }
            else if (lstStuCourses2.Items.Count == 0)
            {
                MessageBox.Show("You currently have no courses to drop!");
            }
            else
            {
                MessageBox.Show("Please select a course to add from the respective list of student courses.");
            }
        }

        private void lstStuCourses2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstStudents2_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstStuCourses2.Items.Clear();
            try
            {
                Student s = lstStudents2.SelectedItem as Student;

                var enrolledCourses = db.StudentCourses.Where<StudentCourse>(sc => sc.NetID == s.NetID);
                foreach (var cour in enrolledCourses)
                {
                    Course selected = db.Courses.Single(c => c.CRN == cour.CRN);
                    this.lstStuCourses2.Items.Add(selected);
                }

                var waitlistCourses = db.Waitlists.Where<Waitlist>(sc => sc.NetID == s.NetID);
                foreach (var wait in waitlistCourses)
                {
                    Course selected = db.Courses.Single(c => c.CRN == wait.CRN);
                    this.lstStuCourses2.Items.Add(selected.waitlistToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void cmdSwap_Click(object sender, EventArgs e)
        {
            if (lstStuCourses1.SelectedIndex > -1 && lstStuCourses2.SelectedIndex > -1 &&
                lstStudents1.SelectedIndex > -1 && lstStudents2.SelectedIndex > -1)
            {
                int retries = 0;
                while (retries < 3)
                {
                    try
                    {
                        using (var transaction = db.Database.BeginTransaction())
                        {
                            Student student1 = lstStudents1.SelectedItem as Student;
                            Student student2 = lstStudents2.SelectedItem as Student;
                            Course studentCourse1 = lstStuCourses1.SelectedItem as Course;
                            Course studentCourse2 = lstStuCourses2.SelectedItem as Course;

                            if (studentCourse1 == null || studentCourse2 == null)
                            {
                                MessageBox.Show("You cannot swap waitlist positions!");
                                break;
                            }

                            if (db.StudentCourses.Any<StudentCourse>(sc => sc.NetID == student1.NetID && sc.CRN == studentCourse2.CRN) ||
                                db.StudentCourses.Any<StudentCourse>(sc => sc.NetID == student2.NetID && sc.CRN == studentCourse1.CRN))
                            {
                                MessageBox.Show("One of these students is already enrolled in a course involved in the swap. Please try again.");
                                break;
                            }

                            db.StudentCourses.Remove(db.StudentCourses.Single<StudentCourse>(sc => sc.CRN == studentCourse1.CRN && student1.NetID == sc.NetID));
                            db.StudentCourses.Remove(db.StudentCourses.Single<StudentCourse>(sc => sc.CRN == studentCourse2.CRN && student2.NetID == sc.NetID));

                            var stuCourseObj = new StudentCourse { CRN = studentCourse1.CRN, NetID = student2.NetID };
                            db.StudentCourses.Add(stuCourseObj);

                            stuCourseObj = new StudentCourse { CRN = studentCourse2.CRN, NetID = student1.NetID };
                            db.StudentCourses.Add(stuCourseObj);

                            if (db.Waitlists.Any<Waitlist>(w => w.NetID == student2.NetID && w.CRN == studentCourse1.CRN))
                            {
                                db.Waitlists.Remove(db.Waitlists.Single<Waitlist>(w => w.NetID == student2.NetID && w.CRN == studentCourse1.CRN));
                            }

                            if (db.Waitlists.Any<Waitlist>(w => w.NetID == student1.NetID && w.CRN == studentCourse2.CRN))
                            {
                                db.Waitlists.Remove(db.Waitlists.Single<Waitlist>(w => w.NetID == student1.NetID && w.CRN == studentCourse2.CRN));
                            }

                            MessageBox.Show("Swap Successful!");

                            db.SaveChanges();

                            transaction.Commit();
                            break;
                        }//end transaction

                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 1205)
                        {
                            retries++;
                        }
                        else
                        {
                            MessageBox.Show(ex.Message);
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        break;
                    }
                    finally
                    {
                        cmdLoadCourses_Click(sender, e);
                        cmdLoadStudents_Click(sender, e);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a student from each student list and a single course in each of their enrollment lists!");
            }
        

        }

        private void txtDelay_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
