using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
namespace ClassLibrary1
{
    public class Poljoin
    {
        [CommandMethod("Join")]
        public void Join()
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }
    }
}
