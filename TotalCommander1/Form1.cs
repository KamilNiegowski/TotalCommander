using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace TotalCommander1
{
    public partial class Form1 : Form
    {
        private bool Hidden = true;
        private DriveInfo[] drives;
        private DirectoryInfo currentLeft;
        private DirectoryInfo currentRight;
        private int sortColumn = -1;
        private void Load_Directory(DirectoryInfo dirs, ListView listView, TextBox tb, bool Hidden)   //LOAD THE DIRECTORY INTO LISTVIEW
        {
            listView.View = View.Details;
            listView.Items.Clear();
            var dirList = dirs.GetDirectories();
            var fileList = dirs.GetFiles();

            foreach (var dir in dirList)
            {
                if (Hidden == true)
                {
                    if (dir.Attributes.ToString().Contains("Ukryty"))
                        continue;
                }

                ListViewItem list = new ListViewItem();
                list.Text = dir.Name;
                list.SubItems.Add("Folder");
                list.SubItems.Add(dir.CreationTime.ToString("yyyy/MM/dd HH:mm:ss"));
                list.SubItems.Add("");
                list.Tag = dir;
                list.ImageIndex = 0;
                listView.Items.Add(list);
            }
            foreach (var file in fileList)
            {
                if (Hidden == true)
                {
                    if (file.Attributes.ToString().Contains("Ukryty"))
                        continue;
                }

                ListViewItem list = new ListViewItem();
                list.Text = file.Name;
                list.SubItems.Add("Plik");
                list.SubItems.Add(file.CreationTime.ToString("yyyy/MM/dd HH:mm:ss"));
                list.Tag = file;
                listView.Items.Add(list);
            }
            tb.Text = dirs.FullName;
        }
        private void Delete_files(DirectoryInfo dirs, ListView list, TextBox tb) // DELETE FILE OR FOLDER OUT OF FILE EXPLORER AND LISTVIEW
        {
            foreach (ListViewItem listtemp in list.SelectedItems)
            {
                if (listtemp.Tag is true)
                    MessageBox.Show("Folder nie znaleziony !!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    if (listtemp.Tag is DirectoryInfo)
                    {
                        DirectoryInfo temp = (DirectoryInfo)listtemp.Tag;
                        if (temp.Exists)
                        {
                            if (temp.GetDirectories().Length != 0 || temp.GetFiles().Length != 0)
                            {
                                DialogResult answer = MessageBox.Show($"{temp.Name} zawiera podfoldery lub pliki. Napewno chcesz usunąć?", "UWAGA", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (answer == DialogResult.Yes)
                                    temp.Delete(true);
                                else
                                    continue;
                            }
                            else
                            {
                                temp.Delete(true);
                            }
                        }
                    }
                    else
                    {
                        FileInfo temp = (FileInfo)listtemp.Tag;
                        if (temp.Exists)
                            temp.Delete();
                    }
                }
            }
            Load_Directory(currentRight, listViewRight, tbright, Hidden);
            Load_Directory(currentLeft, listViewLeft, tbleft, Hidden);
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs s)
        {
            listViewRight.View = View.Details;
            drives = DriveInfo.GetDrives();
            foreach (var drive in drives)
            {
                cbleft.Items.Add(drive);
                cbright.Items.Add(drive);
            }
        }       //LOAD FORM
        private void cbleft_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbleft.SelectedIndex >= 0)
            {
                Load_Directory((DirectoryInfo)drives[cbleft.SelectedIndex].RootDirectory, listViewLeft, tbleft, Hidden);
                currentLeft = (DirectoryInfo)drives[cbleft.SelectedIndex].RootDirectory;
            }
        }  //CHANGE DRIVE LEFT WINDOW       
        private void cbright_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbright.SelectedIndex >= 0)
            {
                Load_Directory((DirectoryInfo)drives[cbright.SelectedIndex].RootDirectory, listViewRight, tbright, Hidden);
                currentRight = (DirectoryInfo)drives[cbright.SelectedIndex].RootDirectory;
            }
        } //CHANGE DRIVE RIGHT WINDOW
        private void listViewRight_MouseDoubleClick(object sender, MouseEventArgs e) //DOUBLE CLICK ON ITEM OF WINDOW LEFT
        {
            foreach (ListViewItem list in listViewRight.SelectedItems)
            {
                if (list.Tag is DirectoryInfo)
                {
                    Load_Directory((DirectoryInfo)list.Tag, listViewRight, tbright, Hidden);
                    currentRight = (DirectoryInfo)list.Tag;
                }
            }
        }
        private void listViewLeft_MouseDoubleClick(object sender, MouseEventArgs e) //DOUBLE CLICK ON ITEM OF WINDOW LEFT
        {
            foreach (ListViewItem list in listViewLeft.SelectedItems)
            {
                if (list.Tag is DirectoryInfo)
                {
                    Load_Directory((DirectoryInfo)list.Tag, listViewLeft, tbleft, Hidden);
                    currentLeft = (DirectoryInfo)list.Tag;
                }
            }
        }
        private void listViewRight_AfterLabelEdit(object sender, LabelEditEventArgs e)    //EVENT AFTER EDIT LIST VIEW RIGHT
        {
            if (string.IsNullOrWhiteSpace(e.Label))
            {
                e.CancelEdit = true;
                MessageBox.Show("Błędna nazwa !!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
            else
            {
                ListViewItem temp = listViewLeft.SelectedItems[0];
                if (temp.Tag is DirectoryInfo)
                {
                    DirectoryInfo dir = (DirectoryInfo)temp.Tag;
                    Directory.Move(dir.FullName, dir.FullName.Replace(dir.Name, e.Label));
                }
                else
                {
                    FileInfo file = (FileInfo)temp.Tag;
                    File.Move(file.FullName, file.FullName.Replace(file.Name, e.Label));
                }
                Load_Directory(currentRight, listViewRight, tbright, Hidden);
            }
        }
        private void listViewLeft_AfterLabelEdit(object sender, LabelEditEventArgs e)    //EVENT AFTER EDIT LIST VIEW RIGHT
        {
            if (string.IsNullOrWhiteSpace(e.Label))
            {
                e.CancelEdit = true;
                MessageBox.Show("Błędna nazwa !!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);               
            }
            else
            {
                ListViewItem temp = listViewLeft.SelectedItems[0];
                if (temp.Tag is DirectoryInfo)
                {
                    DirectoryInfo dir = (DirectoryInfo)temp.Tag;
                    Directory.Move(dir.FullName, dir.FullName.Replace(dir.Name, e.Label));
                }
                else
                {
                    FileInfo file = (FileInfo)temp.Tag;
                    File.Move(file.FullName, file.FullName.Replace(file.Name, e.Label));
                }
                Load_Directory(currentLeft, listViewLeft, tbleft, Hidden);
            }
        }
        private void tbleft_KeyPress(object sender, KeyPressEventArgs e)    //ENTER AN PATH IN A TEXTBOX LEFT 
        {
            if (e.KeyChar == 13)
            {
                string path = tbleft.Text;
                DirectoryInfo temp = new DirectoryInfo(path);
                if (temp.Exists == true)
                {
                    currentLeft = temp;
                    Load_Directory(currentLeft, listViewLeft, tbright, Hidden);
                }
                else
                    MessageBox.Show("Katalog nie istnieje !!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tbright_KeyPress(object sender, KeyPressEventArgs e) //ENTER AN PATH IN A TEXTBOX RIGHT
        {
            if (e.KeyChar == 13)
            {
                string path = tbright.Text;
                DirectoryInfo temp = new DirectoryInfo(path);
                if (temp.Exists == true)
                {
                    currentRight = temp;
                    Load_Directory(currentRight, listViewRight, tbright, Hidden);
                }
                else
                    MessageBox.Show("Katalog nie istnieje !!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void listViewLeft_KeyUp(object sender, KeyEventArgs e) //HOT KEYS FOR LISTVIEW LEFT
        {
            if (listViewLeft.SelectedItems.Count != 0)
            {
                switch (e.KeyCode)
                {
                    case Keys.F8:
                        {
                            DialogResult answer = MessageBox.Show("Czy napewno chcesz usunąć?", "UWAGA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (answer == DialogResult.Yes)
                            {
                                Delete_files(currentLeft, listViewLeft, tbleft);
                            }; break;
                        }
                    case Keys.F7:
                        {
                            string name = "Nowy folder";
                            int pos = 1;
                            while (listViewLeft.FindItemWithText(name) != null)
                            {
                                name = "Nowy folder " + $"({pos})";
                                pos++;
                            }
                            currentLeft.CreateSubdirectory(name);
                            Load_Directory(currentLeft, listViewLeft, tbleft, Hidden);
                            Load_Directory(currentRight, listViewRight, tbright, Hidden);
                            break;
                        }
                }
            }
        }
        private void listViewRight_KeyUp(object sender, KeyEventArgs e) //HOT KEYS FOR LISTVIEW RIGHT
        {
            if (listViewRight.SelectedItems.Count != 0)
            {
                switch (e.KeyCode)
                {
                    case Keys.F8:
                        {
                            DialogResult answer = MessageBox.Show("Czy napewno chcesz usunąć?", "UWAGA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (answer == DialogResult.Yes)
                            {
                                Delete_files(currentRight, listViewRight, tbright);
                            }; break;
                        }
                    case Keys.F7:
                        {
                            string name = "Nowy folder";
                            int pos = 1;
                            while (listViewRight.FindItemWithText(name) != null)
                            {
                                name = "Nowy folder " + $"({pos})";
                                pos++;
                            }
                            currentRight.CreateSubdirectory(name);
                            Load_Directory(currentRight, listViewRight, tbright, Hidden);
                            Load_Directory(currentLeft, listViewLeft, tbleft, Hidden);
                            break;
                        }
                }
            }
        }
        private void listViewRight_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column != sortColumn)
            {
                sortColumn = e.Column;
                listViewRight.Sorting = SortOrder.Ascending;
            }
            else
            {
                if (listViewRight.Sorting == SortOrder.Descending)
                    listViewRight.Sorting = SortOrder.Ascending;
                else
                    listViewRight.Sorting = SortOrder.Descending;
            }
            listViewRight.Sort();
            this.listViewRight.ListViewItemSorter = new ListViewItemComparer(e.Column, listViewRight.Sorting);
        }
        private void listViewLeft_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column != sortColumn)
            {
                sortColumn = e.Column;
                listViewLeft.Sorting = SortOrder.Ascending;
            }
            else
            {
                if (listViewLeft.Sorting == SortOrder.Descending)
                    listViewLeft.Sorting = SortOrder.Ascending;
                else
                    listViewLeft.Sorting = SortOrder.Descending;
            }
            listViewLeft.Sort();
            this.listViewLeft.ListViewItemSorter = new ListViewItemComparer(e.Column, listViewLeft.Sorting);
        }
        public class ListViewItemComparer : IComparer
        {
            private int col;
            private SortOrder order;
            public ListViewItemComparer()
            {
                col = 0;
                order = SortOrder.Ascending;
            }
            public ListViewItemComparer(int column, SortOrder order)
            {
                col = column;
                this.order = order;
            }
            public int Compare(object x, object y)
            {
                int returnVal = -1;
                returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);

                if (order == SortOrder.Descending)
                    returnVal *= -1;
                return returnVal;
            }
        }
        private void buttonRight_Click(object sender, EventArgs e)
        {
            if (currentRight != null && currentRight.Parent != null)
            {
                Load_Directory((DirectoryInfo)currentRight.Parent, listViewRight, tbright, Hidden);
                currentRight = (DirectoryInfo)currentRight.Parent;
            }
        }
        private void buttonLeft_Click(object sender, EventArgs e)
        {
            if (currentLeft != null && currentLeft.Parent != null)
            {
                Load_Directory((DirectoryInfo)currentLeft.Parent, listViewLeft, tbleft, Hidden);
                currentLeft = (DirectoryInfo)currentLeft.Parent;
            }
        }
        private void Copy_Folder(DirectoryInfo source, DirectoryInfo target) // COPY FOLDER TO THE OTHER FOLDER
        {
            if (Directory.Exists(target.FullName))
            {
                CopyFilesRecursively(source, target);
            }
            else
            {
                target = Directory.CreateDirectory(target.FullName);
                CopyFilesRecursively(source, target);
            }
        }
        private void Copy_file(string src, string dst) // COPY FILE TO A SPECIFIC DESTINATION
        {
            if (src != dst)
                if (File.Exists(dst))
                {
                    File.Copy(src, dst, true);
                }
                else
                {
                    FileStream s = new FileStream(dst, FileMode.Create);
                    s.Close();
                    File.Copy(src, dst, true);
                }
            else MessageBox.Show("Niewłaściwa ścieżka", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void CopyFilesRecursively(DirectoryInfo source, DirectoryInfo target) // COPY THE CONTENTS OF THE COPIED FOLDER TO ANOTHER FOLDER 
        {
            foreach (DirectoryInfo dir in source.GetDirectories())
                CopyFilesRecursively(dir, target.CreateSubdirectory(dir.Name));
            foreach (FileInfo file in source.GetFiles())
                file.CopyTo(Path.Combine(target.FullName, file.Name), true);
        }
        private void Move_file(ListViewItem src, DirectoryInfo dst) // MOVE A FILE OR FOLDER TO A SPECIFIC DESTINATION
        {
            if (src.Tag is DirectoryInfo)
            {
                DirectoryInfo temp = (DirectoryInfo)src.Tag;
                DirectoryInfo copy = new DirectoryInfo(dst.FullName + '\\' + temp.Name);
                if (temp.FullName != copy.FullName)
                {
                    Copy_Folder(temp, copy);
                    Directory.Delete(temp.FullName, true);
                }
                else
                {
                    src.BeginEdit();
                }
            }
            if (src.Tag is FileInfo)
            {
                FileInfo temp = (FileInfo)src.Tag;
                if (temp.FullName != dst.FullName + '\\' + temp.Name)
                {
                    Copy_file(temp.FullName, dst.FullName + '\\' + temp.Name);
                    File.Delete(temp.FullName);
                }
                else
                {
                    src.BeginEdit();
                }
            }
        }
        private void listViewRight_DragDrop(object sender, DragEventArgs e)
        {
            int count = 0;
            foreach (ListViewItem es in listViewLeft.SelectedItems)
            {
                if (listViewRight.FindItemWithText(es.Text) == null)
                {
                    Move_file(es, currentRight);
                }
                if (listViewRight.FindItemWithText(es.Text) != null && count == 0)
                {
                    count++;
                    Move_file(es, currentRight);
                }
                Load_Directory(currentRight, listViewRight, tbright, Hidden);
                Load_Directory(currentLeft, listViewLeft, tbleft, Hidden);
            }
        }  //MOVE OPERATION 
        private void listViewLeft_DragDrop(object sender, DragEventArgs e)
        {
            int count = 0;
            foreach (ListViewItem es in listViewRight.SelectedItems)
            {
                if (listViewLeft.FindItemWithText(es.Text) == null)
                {
                    Move_file(es, currentLeft);
                }
                if (listViewLeft.FindItemWithText(es.Text) != null && count == 0)
                {
                    count++;
                    Move_file(es, currentLeft);
                }
                Load_Directory(currentRight, listViewRight, tbright, Hidden);
                Load_Directory(currentLeft, listViewLeft, tbleft, Hidden);
            }
        }  //MOVE OPERATION 
        private void listViewRight_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(List<ListViewItem>)))
            {
                e.Effect = DragDropEffects.Move;
            }
        } //DETECT MOVE
        private void listViewLeft_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(List<ListViewItem>)))
            {
                e.Effect = DragDropEffects.Move;                
            }
        } //DETECT MOVE
        private void listViewRight_ItemDrag(object sender, ItemDragEventArgs e)
        {
            List<ListViewItem> items = new List<ListViewItem>();
            foreach (ListViewItem item in listViewRight.SelectedItems)
            {
                items.Add(item);
            }
            listViewRight.DoDragDrop(items, DragDropEffects.Move);
        }  //DOWNLOAD TO CLIPBOARD 
        private void listViewLeft_ItemDrag(object sender, ItemDragEventArgs e)
        {
            List<ListViewItem> items = new List<ListViewItem>();
            foreach (ListViewItem item in listViewLeft.SelectedItems)
            {
                items.Add(item);
            }
            listViewLeft.DoDragDrop(items, DragDropEffects.Move);
        }  //DOWNLOAD TO CLIPBOARD 
    }
}